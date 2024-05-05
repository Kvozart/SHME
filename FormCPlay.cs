using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SHME.FormItems;

namespace SHME
{
    public partial class FormCPlay : Form
    {
        FormSHME Main;
        static readonly String NumberFormat = "f2";
        static readonly String IniFileName = "CPlay.ini";
        static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class Waypoint
        {
            public String Text = "";
            public double x, y, z, r;
            public int f05 = 0;
            public String Action = ""; // ""/"S"top/"E"ngage
            public bool f07 = false, f08 = false, f09 = false, f10 = false;
            public String f11 = "";
            public int f12 = 0;
            public String f13 = "";
            public bool f14 = false;
            public bool Edited = false;

            public Waypoint(String line) => Read(line);

            public void Read(String line = null)//
            {
                if (line == null) line = Text;
                string[] v = line.Replace("  ", " ").Replace(',', '.').Split(';');
                if (v.Length < 12) return;

                string[] xyz = v[0].Split(' ');
                Double.TryParse(xyz[0], NumberStyles.Float, NFI, out x);
                Double.TryParse(xyz[1], NumberStyles.Float, NFI, out y);
                Double.TryParse(xyz[2], NumberStyles.Float, NFI, out z);
                Double.TryParse(v[1],   NumberStyles.Float, NFI, out r);
                int.TryParse(v[2], out f05);
                Action = v[3];
                f07 = (v[4][0] == 'Y') ? true : false;
                f08 = (v[5][0] == 'Y') ? true : false;
                f09 = (v[6][0] == 'Y') ? true : false;
                f10 = (v[7][0] == 'Y') ? true : false;
                f11 = v[8];
                if (v[9] == "") f12 = -1; else int.TryParse(v[9], out f12);
                f13 = v[10];
                f14 = (v[11][0] == 'Y') ? true : false;
                Text = line;
            }

            public void Align(double step, double offset, Boolean doRotation)
            {
                if (step == 0)
                    return;
                if (doRotation)
                    y = Math.Round((y - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
            }

            public String Concatenate(String format) => //
                x.ToString(format, NFI) + " " +
                y.ToString(format, NFI) + " " +
                z.ToString(format, NFI) + ";" +
                r.ToString(format, NFI) + ";" +
                f05.ToString() + ";" +
                Action + ";" +
                (f07 ? "Y" : "N") + ";" +
                (f08 ? "Y" : "N") + ";" +
                (f09 ? "Y" : "N") + ";" +
                (f10 ? "Y" : "N") + ";" +
                f11 + ";" +
                (f12 < 0 ? "" : f12.ToString()) + ";" +
                f13 + ";" +
                (f14 ? "Y" : "N") + "|";
        }

        public class Route
        {
            public bool isUsed = false;
            public int id = 0, parent = 0;
            public String name = "", fileName = "";
            // In file
            public String workWidth = "1";
            public String numHeadlandLanes = "1";
            public String headlandDirectionCW = "true";
            public String version = "1";
            public List<Waypoint> Points = new List<Waypoint> { };

            public Route(String line)
            {
                String s = "";
                if (FormSHME.ReadTag(line, "fileName", ref s)) fileName = s;
                if (FormSHME.ReadTag(line, "isUsed",   ref s)) isUsed = (s == "true");
                if (FormSHME.ReadTag(line, "id",       ref s)) int.TryParse(s, out id);
                if (FormSHME.ReadTag(line, "parent",   ref s)) int.TryParse(s, out parent);
                if (FormSHME.ReadTag(line, "name",     ref s)) name = s;
            }

            public String Concatenate() => //
                "<slot fileName=\"" + fileName +
                "\" isUsed=\"" + isUsed.ToString().ToLower() + 
                "\" id=\"" + id.ToString() +
                "\" parent=\"" + parent.ToString() + 
                "\" name=\"" + name + 
                "\"/>";
        }

        private String ManagerFileName = "", SelectedRouteFileName = "";
        private List<Route> Routes = new List<Route> { };
        public  Route SelectedRoute = null;

        #region Form
        public FormCPlay(FormSHME main)//Ok
        {
            Main = main;
            InitializeComponent();
            OptionsLoad();
        }

        static public void SetNUD(NumericUpDown nud, String s)
        {
            double d = 0;
            Double.TryParse(s, NumberStyles.Float, NFI, out d);
            Decimal v = (Decimal)d;
            nud.Value = (nud.Maximum < v)
                ? nud.Maximum
                : (nud.Minimum > v)
                    ? nud.Minimum
                    : v;
        }

        static public void SetNUD360(NumericUpDown nud, String s)
        {
            double v = 0;
            Double.TryParse(s, NumberStyles.Float, NFI, out v);
            v = (0 < v && (double)nud.Maximum < v)
                ? v - Math.Floor(v / 360) * 360
                : (0 >= v && (double)nud.Minimum > v)
                    ? v + Math.Ceiling(v / 360) * 360
                    : v;
            nud.Value = (Decimal)v;
        }

        public void OptionsLoad()//Ok
        {
            String routeName = "";
            try
            {
                if (File.Exists(IniFileName))
                    using (StreamReader file = File.OpenText(IniFileName))
                        while (!file.EndOfStream)
                        {
                            String line = file.ReadLine();
                            // Decompress
                            String[] rec = line.Split('\t');
                            // Skip empty
                            if (rec.Length < 2)
                                continue;
                            String option = rec[0],
                                   value = rec[1];
                            // Action
                            switch (option)
                            {
                                case "File" : tbFile.Text = value; break;
                                case "Route": routeName   = value; break;
                                // Position
                                case "PositionStep"  : SetNUD(nudPositionStep,   value); break;
                                case "PositionOffset": SetNUD(nudPositionOffset, value); break;
                                case "LimitXMin"     : SetNUD(nudLimitXMin,      value); break;
                                case "LimitXMax"     : SetNUD(nudLimitXMax,      value); break;
                                case "LimitYMin"     : SetNUD(nudLimitYMin,      value); break;
                                case "LimitYMax"     : SetNUD(nudLimitYMax,      value); break;
                                case "LimitZMin"     : SetNUD(nudLimitZMin,      value); break;
                                case "LimitZMax"     : SetNUD(nudLimitZMax,      value); break;
                                case "LimitX"        : cbLimitX.Checked = (value == "true"); break;
                                case "LimitY"        : cbLimitY.Checked = (value == "true"); break;
                                case "LimitZ"        : cbLimitZ.Checked = (value == "true"); break;
                                // Rotation
                                case "RotationStep"  : SetNUD(nudRotationStep,   value); break;
                                case "RotationOffset": SetNUD(nudRotationOffset, value); break;
                                case "LimitRMin"     : SetNUD360(nudLimitRMin,   value); break;
                                case "LimitRMax"     : SetNUD360(nudLimitRMax,   value); break;
                                case "LimitR"        : cbLimitR.Checked = (value == "true"); break;
                                // Find & Replace
                                case "Find"   : tbFind   .Text = value.Replace("&#9;", "\t"); break;
                                case "Replace": tbReplace.Text = value.Replace("&#9;", "\t"); break;
                                default:
                                    break;
                            }
                        }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            // Update states
            nudPositionStep_ValueChanged(null, null);
            nudRotationStep_ValueChanged(null, null);
            // Load file to edit
            if (tbFile.Text != "")
                Routes_Load(tbFile.Text, routeName);
        }

        public void OptionSave()//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(IniFileName))
                {
                    file.WriteLine("File\t"  + tbFile.Text);
                    if (SelectedRoute != null) file.WriteLine("Route\t" + SelectedRoute.fileName);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value);
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                    file.WriteLine("LimitX\t"         + cbLimitX.Checked.ToString());
                    file.WriteLine("LimitY\t"         + cbLimitY.Checked.ToString());
                    file.WriteLine("LimitZ\t"         + cbLimitZ.Checked.ToString());
                    file.WriteLine("LimitXMin\t"      + nudLimitXMin.Value); 
                    file.WriteLine("LimitYMin\t"      + nudLimitYMin.Value); 
                    file.WriteLine("LimitZMin\t"      + nudLimitZMin.Value);
                    file.WriteLine("LimitXMax\t"      + nudLimitXMax.Value);
                    file.WriteLine("LimitYMax\t"      + nudLimitYMax.Value);
                    file.WriteLine("LimitZMax\t"      + nudLimitZMax.Value);
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep  .Value);
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value);
                    file.WriteLine("LimitR\t"         + cbLimitR.Checked.ToString());
                    file.WriteLine("LimitRMin\t"      + nudLimitRMin.Value);
                    file.WriteLine("LimitRMax\t"      + nudLimitRMax.Value);
                    // Find & Replace
                    file.WriteLine("Find\t"    + tbFind   .Text.Replace("\t", "&#9;"));
                    file.WriteLine("Replace\t" + tbReplace.Text.Replace("\t", "&#9;"));
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FormCPlay_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            Hide();
            e.Cancel = true;
        }
        #endregion

        #region Routes
        private void btnFileReload_Click(object sender, EventArgs e) => Routes_Load(tbFile.Text, SelectedRoute?.fileName);//Ok
        private void btnFileLoad_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(tbFile.Text);
            if (tbFile.Text != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(tbFile.Text).Replace(Path.GetFileName(tbFile.Text), "");
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            Routes_Load(dlgOpen.FileName);
        }

        private void Routes_Load(String fileName, String selectRouteFile = "")//Ok
        {
            try
            {
                Route r;
                TreeNode n, sn = null;
                Routes.Clear();
                tvRoutes.BeginUpdate();
                tvRoutes.Nodes.Clear();

                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        r = new Route(file.ReadLine());
                        if (!r.isUsed)
                            continue;
                        Routes.Add(r);
                        tvRoutes.Nodes.Add(n = new TreeNode(r.name));
                        if (selectRouteFile == r.fileName)
                            sn = n;
                        n.StateImageIndex = r.isUsed ? 1 : 0;
                        n.Tag = r;
                    }
                ManagerFileName
                    = tbFile.Text
                    = fileName;
                tvRoutes.EndUpdate();
                if (sn != null)
                {
                    tvRoutes.SelectedNode = sn;
                    // In case of cold start
                    if (!this.Visible)
                        tvRoutes_AfterSelect(null, null);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void tvRoutes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Reset states
            btnRouteInfoSave.Visible = false;
            tbRouteName.Enabled
                = chbRouteEnabled.Enabled
                = (tvRoutes.SelectedNode != null);
            SelectedRoute = (tvRoutes.SelectedNode?.Tag as Route);
            // Apply values
            chbRouteEnabled.Checked = SelectedRoute.isUsed;
            tbRouteName.Text = SelectedRoute.name;
            Route_Load();
        }

        private void RouteInfo_Changed(object sender, EventArgs e) => btnRouteInfoSave.Visible = 
            ((tvRoutes.SelectedNode.Tag as Route).name != tbRouteName.Text) || 
            ((tvRoutes.SelectedNode.Tag as Route).isUsed != chbRouteEnabled.Checked);

        private void tvRoutes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.X < e.X)
                return;
            Route r = (e.Node.Tag as Route);
            r.isUsed = !r.isUsed;
            e.Node.StateImageIndex = (r.isUsed) ? 1 : 0;
            if (e.Node == tvRoutes.SelectedNode)
                chbRouteEnabled.Checked = r.isUsed;
        }

        private void tbRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnRouteInfoSave_Click(null, null);
            e.Handled = true;
        }

        private void btnRouteInfoSave_Click(object sender, EventArgs e)
        {
            if (tvRoutes.SelectedNode == null) return;
            Route r = (tvRoutes.SelectedNode.Tag as Route);
            tvRoutes.SelectedNode.Text
                = r.name
                = tbRouteName.Text;
            r.isUsed = chbRouteEnabled.Checked;
            // Update UI
            tvRoutes.SelectedNode.StateImageIndex = (r.isUsed) ? 1 : 0;
            btnRouteInfoSave.Visible = false;
        }

        private void btnSaveRoutes_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<courseManager>\r\n    <saveSlot>");
                    foreach (Route r in Routes)
                        file.WriteLine("        " + r.Concatenate());
                    file.WriteLine("    </saveSlot>\r\n</courseManager>");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Route
        private void nudPositionStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitXMin.Increment = nudLimitXMax.Increment =
            nudLimitYMin.Increment = nudLimitYMax.Increment =
            nudLimitZMin.Increment = nudLimitZMax.Increment = nudPositionStep.Value;

        private void nudRotationStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitRMin.Increment = nudLimitRMax.Increment = nudRotationStep.Value;

        private void btnReloadRoute_Click(object sender, EventArgs e) => Route_Load();

        private void btnSaveRoute_Click(object sender, EventArgs e)
        {
            if (btnSavePoint.Visible)
                btnSavePoint_Click(null, null);
            try
            {
                using (StreamWriter file = File.CreateText(SelectedRouteFileName))
                {
                    file.WriteLine(
                        "<course workWidth=\"" + SelectedRoute.workWidth +
                        "\" numHeadlandLanes=\"" + SelectedRoute.numHeadlandLanes +
                        "\" headlandDirectionCW=\"" + SelectedRoute.headlandDirectionCW +
                        "\" version=\"" + SelectedRoute.version +
                        "\">");
                    file.WriteLine("    <waypoints>");
                    foreach (Waypoint p in SelectedRoute.Points)
                        file.WriteLine(p.Concatenate(NumberFormat));
                    file.WriteLine("    </waypoints>");
                    file.WriteLine("</course>");
                }
                btnReloadRoute.Enabled
                    = btnSaveRoute.Enabled
                    = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            for (int i = SelectedRoute.Points.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, SelectedRoute.Points[i].Text.Contains(tbFind.Text));
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                clbWaypoints.Items[i] = SelectedRoute.Points[i].Text.Replace(tbFind.Text, tbReplace.Text);
                SelectedRoute.Points[i].Read();
            }
            clbWaypoints.EndUpdate();
            Main.Canvas_Update();
        }

        private void Route_Load()
        {
            gbEdit.Visible = false;
            btnReloadRoute.Enabled
                = btnSaveRoute.Enabled
                = false;
            if (SelectedRoute == null)
                return;
            try
            {
                String s;
                SelectedRoute.Points.Clear();
                SelectedRouteFileName = tbFile.Text.Replace("courseManager.xml", "") + SelectedRoute.fileName;
                using (StreamReader file = File.OpenText(SelectedRouteFileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        // Load heading
                        if (s.Contains("<course "))
                        {
                            FormSHME.ReadTag(s, "workWidth", ref SelectedRoute.workWidth);
                            FormSHME.ReadTag(s, "numHeadlandLanes", ref SelectedRoute.numHeadlandLanes);
                            FormSHME.ReadTag(s, "headlandDirectionCW", ref SelectedRoute.headlandDirectionCW);
                            FormSHME.ReadTag(s, "version", ref SelectedRoute.version);
                        }
                        // Load waypoints
                        if (s.Contains("<waypoints>"))
                            while (!file.EndOfStream)
                            {
                                s = file.ReadLine();
                                if (s.Contains("</waypoints>"))
                                    break;
                                SelectedRoute.Points.Add(new Waypoint(s));
                            }
                    }
                Waypoints_Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void cbLimit_ValueChanged(object sender, EventArgs e) => Waypoints_Show();

        private void btnAlign_Click(object sender, EventArgs e)
        {
            bool doRotation = (sender == btnRotationAlign);
            Double step   = (doRotation) ? (Double)nudRotationStep  .Value : (Double)nudPositionStep  .Value;
            Double offset = (doRotation) ? (Double)nudRotationOffset.Value : (Double)nudPositionOffset.Value;
            if (clbWaypoints.CheckedIndices.Count < 1)
                return;
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                SelectedRoute.Points[i].Align(step, offset, doRotation);
                clbWaypoints.Items[i] 
                    = SelectedRoute.Points[i].Text
                    = SelectedRoute.Points[i].Concatenate(NumberFormat);
                SelectedRoute.Points[i].Edited = true;
            }
            clbWaypoints.EndUpdate();
            btnReloadRoute.Visible
                = btnSaveRoute.Visible
                = true;
            Waypoints_Show();
        }

        private void Waypoints_Show()//Ok
        {
            clbWaypoints.BeginUpdate();
            clbWaypoints.Items.Clear();
            // Select
            foreach (Waypoint p in SelectedRoute.Points)
            {
                if (cbLimitX.Checked)
                    if (p.x < (Double)nudLimitXMin.Value || (Double)nudLimitXMax.Value < p.x)
                        continue;
                if (cbLimitX.Checked)
                    if (p.y < (Double)nudLimitYMin.Value || (Double)nudLimitYMax.Value < p.y)
                        continue;
                if (cbLimitX.Checked)
                    if (p.z < (Double)nudLimitZMin.Value || (Double)nudLimitZMax.Value < p.z)
                        continue;
                if (cbLimitR.Checked)
                    if (p.r < (Double)nudLimitRMin.Value || (Double)nudLimitRMax.Value < p.r)
                        continue;
                // Allowed
                clbWaypoints.Items.Add(p.Text);
            }
            clbWaypoints.EndUpdate();
            Main.Canvas_Update();
        }
        #endregion

        #region Point
        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbWaypoints.SelectedIndex < 0)
            {
                gbEdit.Visible
                    = btnSavePoint.Visible
                    = false;
                return;
            }
            Waypoint p = SelectedRoute.Points[clbWaypoints.SelectedIndex];

            nudX.Value = (Decimal)p.x;
            nudY.Value = (Decimal)p.y;
            nudZ.Value = (Decimal)p.z;
            nudR.Value = (Decimal)p.r;

            nud05.Value = (Decimal)p.f05;
            dudAction.Text = p.Action;

            chb07.Checked = p.f07;
            chb08.Checked = p.f08;
            chb09.Checked = p.f09;
            chb10.Checked = p.f10;

            tb11.Text = p.f11;
            nud12.Value = (Decimal)p.f12;
            tb13.Text = p.f13;
            chb14.Checked = p.f14;

            btnSavePoint.Visible = false;
            gbEdit.Visible = true;
        }

        private void Waypoint_ValueChanged(object sender, EventArgs e)
        {
            Waypoint p = SelectedRoute.Points[clbWaypoints.SelectedIndex];

            btnSavePoint.Visible =
                p.x != (Double)nudX.Value ||
                p.y != (Double)nudY.Value ||
                p.z != (Double)nudZ.Value ||
                p.r != (Double)nudR.Value ||

                p.f05 != (int)nud05.Value ||
                p.Action != dudAction.Text ||

                p.f07 != chb07.Checked ||
                p.f08 != chb08.Checked ||
                p.f09 != chb09.Checked ||
                p.f10 != chb10.Checked ||

                p.f11 != tb11.Text ||
                p.f12 != (int)nud12.Value ||
                p.f13 != tb13.Text ||
                p.f14 != chb14.Checked;
        }

        private void btnSavePoint_Click(object sender, EventArgs e)
        {
            Waypoint p = SelectedRoute.Points[clbWaypoints.SelectedIndex];

            p.x = (Double)nudX.Value;
            p.y = (Double)nudY.Value;
            p.z = (Double)nudZ.Value;
            p.r = (Double)nudR.Value;

            p.f05 = (int)nud05.Value;
            p.Action = dudAction.Text;

            p.f07 = chb07.Checked;
            p.f08 = chb08.Checked;
            p.f09 = chb09.Checked;
            p.f10 = chb10.Checked;

            p.f11 = tb11.Text;
            p.f12 = (int)nud12.Value;
            p.f13 = tb13.Text;
            p.f14 = chb14.Checked;

            clbWaypoints.Items[clbWaypoints.SelectedIndex] = p.Text = p.Concatenate(NumberFormat);
            btnSavePoint.Visible = false;
        }

        private void btnDeletePoint_Click(object sender, EventArgs e)
        {
            //
            SelectedRoute.Points.RemoveAt(clbWaypoints.SelectedIndex);
            clbWaypoints.Items.RemoveAt(clbWaypoints.SelectedIndex);
            gbEdit.Visible = false;
        }
        #endregion
    }
}