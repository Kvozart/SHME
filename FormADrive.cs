using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static SHME.FormADrive;

namespace SHME
{
    public partial class FormADrive : Form
    {
        FormSHME Main;
        static readonly String FloatFormat = "f2";
        static readonly String IniFileName = "ADrive.ini";
        static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class Waypoint
        {
            public double x, y, z;
            public bool flag = false;
            public bool Edited = false;
            public List<int> inID, outID;
            public String Line = "";
            public int id = 0;
            public int canvasX, canvasY;

            public void Align(double step, double offset)
            {
                if (step == 0)
                    return;
                x = Math.Round((x - offset) / step) * step + offset;
                z = Math.Round((z - offset) / step) * step + offset;
            }

            public String GetLine(String format) =>
                id + "# " +
                x.ToString(format, NFI) + ", " +
                y.ToString(format, NFI) + ", " +
                z.ToString(format, NFI) + ", " +
                flag;
        }

        public class Waygroup
        {
            public String name = "";
            public int id = 0;
            public String Line = "";

            public Waygroup(String line) => Read(line);

            public void Read(String line)
            {
                String s = "";
                if (FormSHME.ReadTag(line, " n=", ref s)) name = s;
                if (FormSHME.ReadTag(line, " i=", ref s)) int.TryParse(s, NumberStyles.Integer, NFI, out id);
            }

            public String GetLine() => 
                "#" + id.ToString() + " " + name;

            public String Concatenate() =>
                "<g n=\"" + name +
                "\" i=\"" + id.ToString() +
                "\"/>";
        }

        public class Waymarker
        {
            public String name = "";
            public String group = "";
            public int groupID = 0;
            public int point = 1;
            public String Line = "";

            public Waymarker(String line) => Read(line);

            public void Read(String line)
            {
                String s = "";
                if (FormSHME.ReadTag(line, " n=", ref s)) name = s;
                if (FormSHME.ReadTag(line, " g=", ref s)) group = s;
                if (FormSHME.ReadTag(line, " i=", ref s)) int.TryParse(s, NumberStyles.Integer, NFI, out point);
            }

            public String GetLine() =>
                "#" + point.ToString() +
                " " + name +
                " | " + group;

            public String Concatenate() =>
                "<m i=\"" + point.ToString() +
                "\" n=\"" + name +
                "\" g=\"" + group +
                "\"/>";
        }

        public class Route
        {
            public String map = "";
            public String name = "";
            public String date = "";
            public String fileName = "";
            public String revision = "";
            public List<String> lines = new List<String>();
            // In file
            public List<Waypoint>  Points  = new List<Waypoint>();
            public List<Waygroup>  Groups  = new List<Waygroup>();
            public List<Waymarker> Markers = new List<Waymarker>();

            public Route(String line)
            {
                String s = "";
                if (FormSHME.ReadTag(line, "name", ref s)) name = s;
                if (FormSHME.ReadTag(line, "fileName", ref s)) fileName = s;
                if (FormSHME.ReadTag(line, "map", ref s)) map = s;
                if (FormSHME.ReadTag(line, "revision", ref s)) revision = s;
                if (FormSHME.ReadTag(line, "date", ref s)) date = s;
            }

            public String Concatenate()
            {
                String s =
                    "<route name=\"" + name +
                    "\" fileName=\"" + fileName +
                    "\" map=\"" + map +
                    "\" revision=\"" + revision +
                    "\" date=\"" + date +
                    "\">\r\n";
                foreach (String l in lines)
                    s += l + "\r\n";
                s += "</route>";
                return s;
            }
        }

        private String ManagerFileName = "", SelectedRouteFileName = "";
        private List<Route> Routes = new List<Route> { };
        public Route SelectedRoute = null;
        private Waypoint SelectedWaypoint = null;

        #region Form
        public FormADrive(FormSHME main)//Ok
        {
            Main = main;
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()//Ok
        {
            String selectRouteFile = "";
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
                                case "Route": selectRouteFile   = value; break;
                                // Position
                                case "PositionStep"  : FormCPlay.SetNUD(nudPositionStep,   value); break;
                                case "PositionOffset": FormCPlay.SetNUD(nudPositionOffset, value); break;
                                case "LimitXMin"     : FormCPlay.SetNUD(nudLimitXMin,      value); break;
                                case "LimitXMax"     : FormCPlay.SetNUD(nudLimitXMax,      value); break;
                                case "LimitYMin"     : FormCPlay.SetNUD(nudLimitYMin,      value); break;
                                case "LimitYMax"     : FormCPlay.SetNUD(nudLimitYMax,      value); break;
                                case "LimitZMin"     : FormCPlay.SetNUD(nudLimitZMin,      value); break;
                                case "LimitZMax"     : FormCPlay.SetNUD(nudLimitZMax,      value); break;
                                case "LimitX"        : cbLimitX.Checked = (value == "true"); break;
                                case "LimitY"        : cbLimitY.Checked = (value == "true"); break;
                                case "LimitZ"        : cbLimitZ.Checked = (value == "true"); break;
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
            // Load file to edit
            if (tbFile.Text != "")
                Routes_Load(tbFile.Text, selectRouteFile);
        }

        public void OptionSave()//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(IniFileName))
                {
                    file.WriteLine("File\t" + tbFile.Text);
                    if (SelectedRoute != null) file.WriteLine("Route\t" + SelectedRoute.fileName);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value);
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                    file.WriteLine("LimitX\t" + cbLimitX.Checked.ToString());
                    file.WriteLine("LimitY\t" + cbLimitY.Checked.ToString());
                    file.WriteLine("LimitZ\t" + cbLimitZ.Checked.ToString());
                    file.WriteLine("LimitXMin\t" + nudLimitXMin.Value);
                    file.WriteLine("LimitYMin\t" + nudLimitYMin.Value);
                    file.WriteLine("LimitZMin\t" + nudLimitZMin.Value);
                    file.WriteLine("LimitXMax\t" + nudLimitXMax.Value);
                    file.WriteLine("LimitYMax\t" + nudLimitYMax.Value);
                    file.WriteLine("LimitZMax\t" + nudLimitZMax.Value);
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FormADrive_FormClosing(object sender, FormClosingEventArgs e)//Ok
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

        private void Routes_Load(String fileName, String selectRouteFile = "")
        {
            try
            {
                Route r;
                String s;
                TreeNode n, sn = null;
                Routes.Clear();
                tvRoutes.BeginUpdate();
                tvRoutes.Nodes.Clear();

                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        if (!s.Contains("<route "))
                            continue;
                        // Add route record
                        r = new Route(s);
                        Routes.Add(r);
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            if (s.Contains("</route>"))
                                break;
                            r.lines.Add(s);
                        }
                        // Add to list
                        tvRoutes.Nodes.Add(n = new TreeNode(r.name));
                        if (selectRouteFile == r.fileName)
                            sn = n;
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
            tbRouteName.Enabled = (tvRoutes.SelectedNode != null);
            SelectedRoute = (tvRoutes.SelectedNode?.Tag as Route);
            // Apply values
            tbRouteName.Text = SelectedRoute.name;
            Route_Load();
        }

        private void Route_ValueChanged(object sender, EventArgs e) =>
            btnRouteInfoSave.Visible = ((tvRoutes.SelectedNode.Tag as Route).name != tbRouteName.Text);

        private void tbRouteName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnRouteNameSave_Click(null, null);
            e.Handled = true;
        }

        private void btnRouteNameSave_Click(object sender, EventArgs e)
        {
            if (tvRoutes.SelectedNode == null) return;
            Route r = (tvRoutes.SelectedNode.Tag as Route);
            tvRoutes.SelectedNode.Text
                = r.name
                = tbRouteName.Text;
            // Update UI
            btnRouteInfoSave.Visible = false;
        }

        private void btnSaveRoutes_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<autoDriveRoutesManager>\r\n    <routes>");
                    foreach (Route r in Routes)
                        file.WriteLine("        " + r.Concatenate());
                    file.WriteLine("    </routes>\r\n</autoDriveRoutesManager>");
                }
                btnSaveRoutes.Visible = false;
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

        private void btnReloadRoute_Click(object sender, EventArgs e) => Route_Load();

        private void btnSaveRoute_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = File.CreateText(""))
                {
                    //file.WriteLine("<autoDriveRoutesManager>\r\n    <routes>");
                    //foreach (Route r in Routes)
                    //    file.WriteLine("        " + r.Concatenate());
                    //file.WriteLine("    </routes>\r\n</autoDriveRoutesManager>");
                }
                btnSaveRoute.Visible
                    = btnReloadRoute.Visible
                    = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private String ExtractTagContent(String line)
        {
            int q1, q2;
            q1 = line.IndexOf(">") + 1;
            if (q1 < 1) return "";
            q2 = line.IndexOf("<", q1);
            if (q2 < 1) return "";
            return line.Substring(q1, q2 - q1);
        }

        private double[] BreakLine_Float(String line, char spliter)
        {
            String[] s = line.Split(spliter);
            double[] v = new double[s.Length];
            int i = 0;
            foreach(String c in s)
                Double.TryParse(c, NumberStyles.Float, NFI, out v[i++]);
            return v;
        }

        private int[] BreakLine_Integer(String line, char spliter)
        {
            String[] s = line.Split(spliter);
            int[] v = new int[s.Length];
            int i = 0;
            foreach (String c in s)
                int.TryParse(c, NumberStyles.Integer, NFI, out v[i++]);
            return v;
        }

        private void Route_Load()
        {
            gbEdit.Visible
                = btnReloadRoute.Enabled
                = btnSaveRoute.Enabled
                = false;
            if (SelectedRoute == null)
                return;
            try
            {
                cbbMarkerPoint.BeginUpdate();    cbbMarkerPoint.Items.Clear();
                cbbMarkerGroup.BeginUpdate();    cbbMarkerGroup.Items.Clear();
                clbMarkers.BeginUpdate();        clbMarkers.Items.Clear();
                clbGroups.BeginUpdate();         clbGroups.Items.Clear();
                // Prepare
                int q1, q2;
                String s, tag;
                double[] x = new double[0],
                         y = new double[0],
                         z = new double[0];
                int[] flag = new int[0];
                String[] iID = new String[0],
                         oID = new String[0];
                Waypoint p;
                SelectedRoute.Points.Clear();
                SelectedRoute.Groups.Clear();
                SelectedRoute.Markers.Clear();
                SelectedRouteFileName = tbFile.Text.Replace("routes.xml", "routes\\") + SelectedRoute.fileName;
                using (StreamReader file = File.OpenText(SelectedRouteFileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        // Get container
                        q1 = s.IndexOf("<");
                        if (q1 < 1) continue;
                        q2 = s.IndexOf(">", q1);
                        if (q2 < 1) continue;
                        tag = s.Substring(q1, q2 - q1);
                        // Case
                        switch (tag)
                        {
                            case "<x": x = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "<y": y = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "<z": z = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "<flags": flag = BreakLine_Integer(ExtractTagContent(s), ';'); break;
                            case "<in": iID = ExtractTagContent(s).Split(';'); break;
                            case "<out": oID = ExtractTagContent(s).Split(';'); break;
                            default:
                                if (tag.Contains("<m "))
                                    SelectedRoute.Markers.Add(new Waymarker(tag));
                                if (tag.Contains("<g "))
                                    SelectedRoute.Groups.Add(new Waygroup(tag));
                                break;
                        }
                    }
                // Sort and add groups
                SelectedRoute.Groups.Sort(delegate (Waygroup a, Waygroup b)
                    { return (a.id < b.id) ? -1 : (a.id > b.id) ? 1 : 0; });
                foreach (Waygroup g in SelectedRoute.Groups)
                {
                    cbbMarkerGroup.Items.Add(s = g.GetLine());
                    clbGroups.Items.Add(s);
                }
                // Build and add points
                q2 = Math.Max(
                    Math.Max(iID.Length, oID.Length),
                    Math.Max(
                        Math.Max(x.Length, y.Length),
                        Math.Max(z.Length, flag.Length)));
                for (int i = 0; i < q2; i++)
                {
                    SelectedRoute.Points.Add(p = new Waypoint());
                    p.id = i + 1;
                    if (i < x.Length) p.x = x[i];
                    if (i < y.Length) p.y = y[i];
                    if (i < z.Length) p.z = z[i];
                    if (i < flag.Length) p.flag = (flag[i] != 0);
                    if (i < iID.Length) p.inID  = BreakLine_Integer(iID[i], ',').ToList();
                    if (i < oID.Length) p.outID = BreakLine_Integer(oID[i], ',').ToList();
                    cbbMarkerPoint.Items.Add(p.Line = p.GetLine(FloatFormat));
                }
                // Add markers
                foreach (Waymarker m in SelectedRoute.Markers)
                {
                    clbMarkers.Items.Add(m.GetLine());
                    m.groupID = SelectedRoute.Groups.FindIndex(i => (i.name == m.group));
                }
                Waypoints_Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            cbbMarkerPoint.EndUpdate();
            cbbMarkerGroup.EndUpdate();
            clbMarkers.EndUpdate();
            clbGroups.EndUpdate();
        }

        private void cbLimit_ValueChanged(object sender, EventArgs e) => Waypoints_Show();

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
                // Allowed
                clbWaypoints.Items.Add(p.Line);
            }
            clbWaypoints.EndUpdate();
            FormSHME.Main.IAC_Update();
        }

        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudPositionStep  .Value;
            Double offset = (Double)nudPositionOffset.Value;
            if (clbWaypoints.CheckedIndices.Count < 1)
                return;
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                SelectedRoute.Points[i].Align(step, offset);
                clbWaypoints.Items[i]
                    = SelectedRoute.Points[i].Line
                    = SelectedRoute.Points[i].GetLine(FloatFormat);
                SelectedRoute.Points[i].Edited = true;
            }
            // Finish
            clbWaypoints.EndUpdate();
            btnReloadRoute.Visible
                = btnSaveRoute.Visible
                = true;
            Waypoints_Show();
        }

        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSavePoint.Visible = false;
            if (clbWaypoints.SelectedIndex < 0 || SelectedRoute == null)
            {
                SelectedWaypoint = null;
                gbEdit.Visible = false;
                return;
            }
            SelectedWaypoint = SelectedRoute.Points[clbWaypoints.SelectedIndex];
            nudX.Value = (decimal)SelectedWaypoint.x;
            nudY.Value = (decimal)SelectedWaypoint.y;
            nudZ.Value = (decimal)SelectedWaypoint.z;
            chbFlag.Checked = SelectedWaypoint.flag;
            gbEdit.Visible = true;
        }

        private void PointInfo_Changed(object sender, EventArgs e) =>
            btnRouteInfoSave.Visible = (
                (double)nudX.Value != SelectedWaypoint.x ||
                (double)nudY.Value != SelectedWaypoint.y ||
                (double)nudZ.Value != SelectedWaypoint.z ||
                chbFlag.Checked != SelectedWaypoint.flag);

        private void btnSavePoint_Click(object sender, EventArgs e)
        {
            SelectedWaypoint.x = (double)nudX.Value; 
            SelectedWaypoint.y = (double)nudY.Value;
            SelectedWaypoint.z = (double)nudZ.Value;
            SelectedWaypoint.flag = chbFlag.Checked;
            // Update UI
            clbWaypoints.SelectedItem
                = SelectedWaypoint.Line
                = SelectedWaypoint.GetLine(FloatFormat);
            btnSaveRoute.Visible
                = btnReloadRoute.Visible
                = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnDeletePoint_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Waymarker
        private void clbMarkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveMarker.Visible = false;
            int id = clbMarkers.SelectedIndex;
            if (id < 0)
            {
                gbMarker.Enabled = false;
                tbMarkerName.Text = "";
                cbbMarkerGroup.SelectedIndex = -1;
                cbbMarkerPoint.SelectedIndex = -1;
                return;
            }
            Waymarker m = SelectedRoute.Markers[id];
            tbMarkerName.Text = m.name;
            cbbMarkerGroup.SelectedIndex = m.groupID;
            cbbMarkerPoint.SelectedIndex = m.point - 1;
            gbMarker.Enabled = true;
        }

        private void Marker_ValueChanged(object sender, EventArgs e)
        {
            int id = clbMarkers.SelectedIndex;
            if (id < 0) return;
            Waymarker m = SelectedRoute.Markers[id];
            btnSaveMarker.Visible = (
                tbMarkerName.Text != m.name ||
                cbbMarkerGroup.SelectedIndex != m.groupID ||
                cbbMarkerPoint.SelectedIndex + 1 != m.point);
        }

        private void btnMarkerSave_Click(object sender, EventArgs e)
        {
            btnSaveMarker.Visible = false;
            int id = clbMarkers.SelectedIndex;
            if (id < 0) return;
            Waymarker m = SelectedRoute.Markers[id];
            m.name = tbMarkerName.Text;
            m.groupID = cbbMarkerGroup.SelectedIndex;
            m.group = SelectedRoute.Groups[m.groupID].name;
            m.point = cbbMarkerPoint.SelectedIndex + 1;
            clbMarkers.Items[id]
                = m.Line
                = m.GetLine();
        }

        private void tbMarkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnMarkerSave_Click(null, null);
            e.Handled = true;
        }

        private void btnMarkerDelete_Click(object sender, EventArgs e)
        {
            int id = clbMarkers.SelectedIndex;
            if (id < 0) return;
            clbMarkers.Items.RemoveAt(id);
            SelectedRoute.Groups.RemoveAt(id);
        }
        #endregion

        #region Waygroup
        private void clbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveGroup.Visible = false;
            if (clbGroups.SelectedIndex < 0)
            {
                gbGroup.Enabled = false;
                tbGroupName.Text = "";
                lblGroupID.Text = "-";
                return;
            }
            gbGroup.Enabled = true;
            Waygroup g = SelectedRoute.Groups[clbGroups.SelectedIndex];
            lblGroupID.Text = g.id.ToString();
            tbGroupName.Text = g.name;
            btnDeleteGroup.Visible = (g.id != 1);
        }

        private void Group_ValueChanged(object sender, EventArgs e) =>
            btnSaveGroup.Visible = (tbGroupName.Text != SelectedRoute.Groups[clbGroups.SelectedIndex].name);

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            int id = clbGroups.SelectedIndex;
            btnSaveGroup.Visible = false;
            if (id < 0) return;
            Waygroup g = SelectedRoute.Groups[id];
            g.name = tbGroupName.Text;
            g.Line = g.GetLine();
            cbbMarkerGroup.Items[id]
                = clbGroups.Items[id]
                = g.Line;
            int i = 0;
            foreach (Waymarker m in SelectedRoute.Markers)
            {
                if (id == m.groupID)
                {
                    m.group = g.Line;
                    clbMarkers.Items[i]
                        = m.Line
                        = m.GetLine();
                }
                i++;
            }
        }

        private void tbGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnGroupSave_Click(null, null);
            e.Handled = true;
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            int id = clbGroups.SelectedIndex;
//clbMarkers.SelectedIndex = -1;
            clbGroups.BeginUpdate();
            clbMarkers.BeginUpdate();
            // Update group selectors
            int i = 0;
            foreach (Waygroup g in SelectedRoute.Groups)
            {
                if (id < i)
                {
                    g.id--;
                    clbGroups.Items[i]
                        = cbbMarkerGroup.Items[i]
                        = g.Line
                        = g.GetLine();
                }
                i++;
            }
            // Update markers
            i = 0;
            String g0Name = SelectedRoute.Groups[0].name;
            foreach (Waymarker m in SelectedRoute.Markers)
            {
                if (id <= m.groupID)
                    if (id == m.groupID)
                    {
                        m.groupID = 0;
                        m.group = g0Name;
                        clbMarkers.Items[i] = m.Line = m.GetLine();
                    }
                    else 
                        m.groupID--;
                i++;
            }
            // Remove all entries
            SelectedRoute.Groups.RemoveAt(id);
            cbbMarkerGroup.Items.RemoveAt(id);
            clbGroups.Items.RemoveAt(id);
            clbMarkers.EndUpdate();
            clbGroups.EndUpdate();
        }
        #endregion
    }
}
