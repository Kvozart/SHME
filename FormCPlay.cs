using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormCPlay : Form
    {
        public const int pinW = 5, pinCX = 2,
                         pinH = 5, pinCY = 2;
        public static readonly int[] pinWork = {
            0x00000000, 0x7FC0C000, 0x7FC0C000, 0x7FC0C000, 0x00000000,
            0x7FC0C000, 0x00000000, 0x00000000, 0x00000000, 0x7FC0C000,
            0x7FC0C000, 0x00000000, 0x00000000, 0x00000000, 0x7FC0C000,
            0x7FC0C000, 0x00000000, 0x00000000, 0x00000000, 0x7FC0C000,
            0x00000000, 0x7FC0C000, 0x7FC0C000, 0x7FC0C000, 0x00000000};
        public static readonly int[] pinStop = {
            0x00000000, 0x7FFF0000, 0x7FFF0000, 0x7FFF0000, 0x00000000,
            0x7FFF0000, 0x00000000, 0x00000000, 0x00000000, 0x7FFF0000,
            0x7FFF0000, 0x00000000, 0x00000000, 0x00000000, 0x7FFF0000,
            0x7FFF0000, 0x00000000, 0x00000000, 0x00000000, 0x7FFF0000,
            0x00000000, 0x7FFF0000, 0x7FFF0000, 0x7FFF0000, 0x00000000};
        public static readonly int[] pinEngage = {
            0x00000000, 0x7F00cF00, 0x7F00cF00, 0x7F00cF00, 0x00000000,
            0x7F00cF00, 0x00000000, 0x00000000, 0x00000000, 0x7F00cF00,
            0x7F00cF00, 0x00000000, 0x00000000, 0x00000000, 0x7F00cF00,
            0x7F00cF00, 0x00000000, 0x00000000, 0x00000000, 0x7F00cF00,
            0x00000000, 0x7F00cF00, 0x7F00cF00, 0x7F00cF00, 0x00000000};
        public static readonly Pen pinConection = new Pen(Color.LightGray);

        private const String NumberFormat = "f2";
        private const String IniFileName = "CPlay.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class CPWaypoint
        {
            public String XMLLine = "", Line = "";
            public double x, y, z, r;
            public int f05 = 0;
            public String Action = ""; // ""/"S"top/"E"ngage
            public bool f07 = false, f08 = false, f09 = false, f10 = false;
            public String f11 = "";
            public int f12 = 0;
            public String f13 = "";
            public bool f14 = false;
            public bool Edited = false, Show;
            public int canvasX, canvasY;

            public CPWaypoint(String line) => ReadXMLLine(line);

            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = line;
                Line = line;

                string[] v = line.Replace("  ", " ").Replace(',', '.').Split(';');
                if (v.Length < 12) return;

                string[] p = v[0].Split(' ');
                Double.TryParse(p[0], NumberStyles.Float, NFI, out x);
                Double.TryParse(p[1], NumberStyles.Float, NFI, out y);
                Double.TryParse(p[2], NumberStyles.Float, NFI, out z);
                Double.TryParse(v[1], NumberStyles.Float, NFI, out r);
                int.TryParse(v[2], out f05);
                Action = v[3];
                f07 = (v[4][0] == 'Y');
                f08 = (v[5][0] == 'Y');
                f09 = (v[6][0] == 'Y');
                f10 = (v[7][0] == 'Y');
                f11 = v[8];
                if (v[9] == "") f12 = -1; else int.TryParse(v[9], out f12);
                f13 = v[10];
                f14 = (v[11][0] == 'Y');
            }

            public void Align(double step, double offset, Boolean doRotation)
            {
                if (step == 0)
                    return;
                if (doRotation)
                    r = Math.Round((r - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
            }

            public String GetXMLLine(String format) => //
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
                (f14 ? "Y" : "N");
        }

        public class Route
        {
            public bool isUsed = false;
            public int id = 0, parent = 0;
            public String XMLLine = "", Line = "";
            public String name = "", fileName = "";
            public bool InfoEdited = false;
            // In file
            public String workWidth = "1";
            public String numHeadlandLanes = "1";
            public String headlandDirectionCW = "true";
            public String version = "1";
            public List<CPWaypoint> Waypoints = new List<CPWaypoint> { };
            public bool Edited = false;

            public Route(String line) => ReadXMLLine(line, true);

            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = line;
                Line = line;

                int tmp;
                String s;
                FormSHME.ReadTag(line, "fileName", out fileName, out tmp);
                if (0 < FormSHME.ReadTag(line, "isUsed", out s, out tmp)) isUsed = (s.ToLower() == "true");
                if (0 < FormSHME.ReadTag(line, "id",     out s, out tmp)) int.TryParse(s, out id);
                if (0 < FormSHME.ReadTag(line, "parent", out s, out tmp)) int.TryParse(s, out parent);
                FormSHME.ReadTag(line, "name", out name, out tmp);
            }

            public String GetManagerXMLLine() => //
                "<slot fileName=\"" + fileName +
                "\" isUsed=\"" + isUsed.ToString().ToLower() +
                "\" id=\"" + id +
                "\" parent=\"" + parent +
                "\" name=\"" + name +
                "\"/>";

            public String GetRouteXMLLine() => //
                "<course workWidth=\"" + workWidth +
                "\" numHeadlandLanes=\"" + numHeadlandLanes +
                "\" headlandDirectionCW=\"" + headlandDirectionCW +
                "\" version=\"" + version +
                "\">";
        }

        private bool lockFilter = false;
        private String ManagerFileName = "", RouteFilesPath = "";
        private List<Route> Routes = new List<Route> { };
        public  Route SelectedRoute = null;
        public  List<CPWaypoint> WaypointsShow = new List<CPWaypoint> { };

        #region Form
        public FormCPlay()//Ok
        {
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()//Ok
        {
            lockFilter = true;
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
                                case "File" : RouteFilesPath = Path.GetDirectoryName(tbManagerFile.Text = value); break;
                                case "Route": routeName = value; break;
                                // Position
                                case "PositionStep"  : FormSHME.SetNUD(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": FormSHME.SetNUD(nudPositionOffset, value, NFI); break;
                                case "LimitXMin"     : FormSHME.SetNUD(nudLimitXMin,      value, NFI); break;
                                case "LimitXMax"     : FormSHME.SetNUD(nudLimitXMax,      value, NFI); break;
                                case "LimitYMin"     : FormSHME.SetNUD(nudLimitYMin,      value, NFI); break;
                                case "LimitYMax"     : FormSHME.SetNUD(nudLimitYMax,      value, NFI); break;
                                case "LimitZMin"     : FormSHME.SetNUD(nudLimitZMin,      value, NFI); break;
                                case "LimitZMax"     : FormSHME.SetNUD(nudLimitZMax,      value, NFI); break;
                                case "LimitX"        : cbLimitX.Checked = (value == "true"); break;
                                case "LimitY"        : cbLimitY.Checked = (value == "true"); break;
                                case "LimitZ"        : cbLimitZ.Checked = (value == "true"); break;
                                // Rotation
                                case "RotationStep"  : FormSHME.SetNUD(nudRotationStep,   value, NFI); break;
                                case "RotationOffset": FormSHME.SetNUD(nudRotationOffset, value, NFI); break;
                                case "LimitRMin"     : FormSHME.SetNUD360(nudLimitRMin,   value, NFI); break;
                                case "LimitRMax"     : FormSHME.SetNUD360(nudLimitRMax,   value, NFI); break;
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
            lockFilter = false;
            if (tbManagerFile.Text != "")
                Routes_Load(tbManagerFile.Text, routeName);
        }

        public void OptionSave()//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(IniFileName))
                {
                    file.WriteLine("File\t"  + tbManagerFile.Text);
                    if (SelectedRoute != null) file.WriteLine("Route\t" + SelectedRoute.fileName);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value);
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                    file.WriteLine("LimitXMin\t"      + nudLimitXMin     .Value); 
                    file.WriteLine("LimitYMin\t"      + nudLimitYMin     .Value); 
                    file.WriteLine("LimitZMin\t"      + nudLimitZMin     .Value);
                    file.WriteLine("LimitXMax\t"      + nudLimitXMax     .Value);
                    file.WriteLine("LimitYMax\t"      + nudLimitYMax     .Value);
                    file.WriteLine("LimitZMax\t"      + nudLimitZMax     .Value);
                    file.WriteLine("LimitX\t"         + cbLimitX.Checked.ToString());
                    file.WriteLine("LimitY\t"         + cbLimitY.Checked.ToString());
                    file.WriteLine("LimitZ\t"         + cbLimitZ.Checked.ToString());
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep  .Value);
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value);
                    file.WriteLine("LimitRMin\t"      + nudLimitRMin     .Value);
                    file.WriteLine("LimitRMax\t"      + nudLimitRMax     .Value);
                    file.WriteLine("LimitR\t"         + cbLimitR.Checked.ToString());
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
        private void btnFileReload_Click(object sender, EventArgs e) => Routes_Load(tbManagerFile.Text, SelectedRoute?.fileName);//Ok
        private void btnFileLoad_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(tbManagerFile.Text);
            if (tbManagerFile.Text != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(tbManagerFile.Text).Replace(Path.GetFileName(tbManagerFile.Text), "");
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
                RouteFilesPath = Path.GetDirectoryName(
                    tbManagerFile.Text
                    = ManagerFileName
                    = fileName);
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
            r.InfoEdited = true;
        }

        private void tbRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnRouteInfoSave_Click(null, null);
            e.Handled = true;
        }

        private void tvRoutes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            tbRouteName.TextChanged -= RouteInfo_Changed;
            tbRouteName.Text = e.Label ?? e.Node.Text;
            tbRouteName.TextChanged += RouteInfo_Changed;
            btnRouteInfoSave.Visible = false;
            (e.Node.Tag as Route).InfoEdited = true;
        }

        private void btnRouteInfoSave_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvRoutes.SelectedNode;
            if (tn == null) return;
            Route r = (tn.Tag as Route);
            tn.Text
                = r.name
                = tbRouteName.Text;
            r.isUsed = chbRouteEnabled.Checked;
            // Update UI
            tn.StateImageIndex = (r.isUsed) ? 1 : 0;
            btnRouteInfoSave.Visible = false;
            r.InfoEdited = true;
        }

        private void btnRoutesSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<courseManager>\r\n    <saveSlot>");
                    foreach (Route r in Routes)
                    {
                        file.WriteLine((r.InfoEdited)
                            ? "        " + r.GetManagerXMLLine()
                            : r.Line);
                        r.InfoEdited = false;
                    }
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
        private void FilterWaypoints()//Ok
        {
            if (lockFilter) return;
            clbWaypoints.BeginUpdate();
            clbWaypoints.Items.Clear();
            WaypointsShow.Clear();
            // Prepare
            Double minX = (Double)nudLimitXMin.Value, maxX = (Double)nudLimitXMax.Value,
                   minY = (Double)nudLimitYMin.Value, maxY = (Double)nudLimitYMax.Value,
                   minZ = (Double)nudLimitZMin.Value, maxZ = (Double)nudLimitZMax.Value,
                   minR = (Double)nudLimitRMin.Value, maxR = (Double)nudLimitRMax.Value;
            bool limitX = cbLimitX.Checked,
                 limitY = cbLimitY.Checked,
                 limitZ = cbLimitZ.Checked,
                 limitR = cbLimitR.Checked;
            // Select
            foreach (CPWaypoint p in SelectedRoute.Waypoints)
            {
                p.Show= false;
                if (limitX) if (p.x < minX || maxX < p.x) continue;
                if (limitY) if (p.y < minY || maxY < p.y) continue;
                if (limitZ) if (p.z < minZ || maxZ < p.z) continue;
                if (limitR) if (p.r < minR || maxR < p.r) continue;
                // Allowed
                clbWaypoints.Items.Add(p.Line);
                WaypointsShow.Add(p);
                p.Show = true;
            }
            clbWaypoints.EndUpdate();
            FormSHME.Main.IAC_Update();
        }

        private void nudPositionStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitXMin.Increment = nudLimitXMax.Increment = nudX.Increment =
            nudLimitYMin.Increment = nudLimitYMax.Increment = nudY.Increment =
            nudLimitZMin.Increment = nudLimitZMax.Increment = nudZ.Increment = nudPositionStep.Value;

        private void nudRotationStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitRMin.Increment = nudLimitRMax.Increment = nudR.Increment = nudRotationStep.Value;

        private void cbLimit_ValueChanged(object sender, EventArgs e) => FilterWaypoints();

        private void btnReloadRoute_Click(object sender, EventArgs e) => Route_Load();
        private void Route_Load()
        {
            if (SelectedRoute == null)
                return;
            try
            {
                int tmp;
                String s;
                SelectedRoute.Waypoints.Clear();
                using (StreamReader file = File.OpenText(RouteFilesPath + "\\" + SelectedRoute.fileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        // Load heading
                        if (s.Contains("<course "))
                        {
                            FormSHME.ReadTag(s, "workWidth", out SelectedRoute.workWidth, out tmp);
                            FormSHME.ReadTag(s, "numHeadlandLanes", out SelectedRoute.numHeadlandLanes, out tmp);
                            FormSHME.ReadTag(s, "headlandDirectionCW", out SelectedRoute.headlandDirectionCW, out tmp);
                            FormSHME.ReadTag(s, "version", out SelectedRoute.version, out tmp);
                        }
                        // Load waypoints
                        if (s.Contains("<waypoints>"))
                            while (!file.EndOfStream)
                            {
                                s = file.ReadLine();
                                if (s.Contains("</waypoints>")) break;
                                SelectedRoute.Waypoints.Add(new CPWaypoint(s));
                            }
                    }
                FilterWaypoints();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            clbWaypoints.BeginUpdate();
            String f = tbFind.Text;
            for (int i = WaypointsShow.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, WaypointsShow[i].Line.Contains(f));
            clbWaypoints.EndUpdate();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            clbWaypoints.BeginUpdate();
            CPWaypoint p;
            String f = tbFind.Text,
                   r = tbReplace.Text;
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                p = WaypointsShow[i];
                clbWaypoints.Items[i]
                    = p.Line
                    = p.Line.Replace(f, r);
                p.ReadXMLLine();
                p.Edited = true;
            }
            clbWaypoints.EndUpdate();
            FilterWaypoints();
        }

        private void btnAlign_Click(object sender, EventArgs e)
        {
            bool doRotation = (sender == btnRotationAlign);
            Double step   = (doRotation) ? (Double)nudRotationStep  .Value : (Double)nudPositionStep  .Value;
            Double offset = (doRotation) ? (Double)nudRotationOffset.Value : (Double)nudPositionOffset.Value;
            if (clbWaypoints.CheckedIndices.Count < 1)
                return;
            CPWaypoint p;
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                p = WaypointsShow[i];
                p.Align(step, offset, doRotation);
                clbWaypoints.Items[i]
                    = p.Line
                    = p.GetXMLLine(NumberFormat);
                p.Edited = true;
            }
            clbWaypoints.EndUpdate();
            FilterWaypoints();
        }

        private void btnRouteSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = File.CreateText(RouteFilesPath + "\\" + SelectedRoute.fileName))
                {
                    file.WriteLine(SelectedRoute.GetRouteXMLLine());
                    file.WriteLine("    <waypoints>");
                    foreach (CPWaypoint p in SelectedRoute.Waypoints)
                        file.WriteLine(p.GetXMLLine(NumberFormat) + '|');
                    file.WriteLine("    </waypoints>");
                    file.WriteLine("</course>");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Waypoint
        private void btnPointsCheckAll_Click(object sender, EventArgs e)
        {
            bool newState = (sender == btnPointsCheckAll);
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, newState);
        }

        private void btnPointsCheckInvert_Click(object sender, EventArgs e)
        {
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, !clbWaypoints.GetItemChecked(i));
        }

        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPointSave.Visible = false;
            if (clbWaypoints.SelectedIndex < 0)
                return;
            CPWaypoint p = SelectedRoute.Waypoints[clbWaypoints.SelectedIndex];

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
        }

        private void Waypoint_ValueChanged(object sender, EventArgs e)
        {
            CPWaypoint p = SelectedRoute.Waypoints[clbWaypoints.SelectedIndex];
            btnPointSave.Visible =
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

        private void PointSave(CPWaypoint p)
        {
            if (p == null) return;

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

            p.Line = p.GetXMLLine(NumberFormat);
        }

        private void btnPointSave_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (i < 0) return;
            CPWaypoint p = SelectedRoute.Waypoints[i];
            PointSave(p);
            // Update UI
            clbWaypoints.Items[i] = p.Line;
            p.Edited = true;
            btnPointSave.Visible = false;
            FilterWaypoints();
        }

        private void btnPointInsert_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            CPWaypoint p = new CPWaypoint("");
            if (i < 0) SelectedRoute.Waypoints.Add(p);
            else       SelectedRoute.Waypoints.Insert(
                       SelectedRoute.Waypoints.IndexOf(WaypointsShow[i]), p);
            PointSave(p);
            FilterWaypoints();
        }

        private void btnPointDelete_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (i < 0) return;
            // Find and delete
            SelectedRoute.Waypoints.RemoveAt(SelectedRoute.Waypoints.IndexOf(WaypointsShow[i]));
            clbWaypoints.Items.RemoveAt(i);
            WaypointsShow.RemoveAt(i);
            // Update UI
            FormSHME.Main.IAC_Update();
            if (clbWaypoints.Items.Count <= i) i--;
            clbWaypoints.SelectedIndex = i;
        }

        private void btnPointDeleteAll_Click(object sender, EventArgs e)
        {
            foreach (CPWaypoint p in WaypointsShow)
                if (p.Show) SelectedRoute.Waypoints.Remove(p);
            clbWaypoints.Items.Clear();
            WaypointsShow.Clear();
            FormSHME.Main.IAC_Update();
        }
        #endregion
    }
}