using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static SHME.FormADrive;

namespace SHME
{
    public partial class FormADrive : Form
    {
        public const int pinW = 5, pinCX = 2,
                         pinH = 5, pinCY = 2;
        public static readonly int[] pinNormal = {
            0x00000000, 0x7F00A000, 0x7F00A000, 0x7F00A000, 0x00000000,
            0x7F00A000, 0x7F00A000, 0x00000000, 0x7F00A000, 0x7F00A000,
            0x7F00A000, 0x00000000, 0x00000000, 0x00000000, 0x7F00A000,
            0x7F00A000, 0x7F00A000, 0x00000000, 0x7F00A000, 0x7F00A000,
            0x00000000, 0x7F00A000, 0x7F00A000, 0x7F00A000, 0x00000000};
        public static readonly int[] pinFlaged = {
            0x00000000, 0x7FEEEE00, 0x7FEEEE00, 0x7FEEEE00, 0x00000000,
            0x7FEEEE00, 0x7FEEEE00, 0x00000000, 0x7FEEEE00, 0x7FEEEE00,
            0x7FEEEE00, 0x00000000, 0x00000000, 0x00000000, 0x7FEEEE00,
            0x7FEEEE00, 0x7FEEEE00, 0x00000000, 0x7FEEEE00, 0x7FEEEE00,
            0x00000000, 0x7FEEEE00, 0x7FEEEE00, 0x7FEEEE00, 0x00000000};

        private const String FloatFormat = "f2";
        private const String IniFileName = "ADrive.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class ADLink
        {
            public int  waypoint  = 0;
            public byte direction = 0;
            public static readonly Pen OD = new Pen(Color.Green);
            public static readonly Pen BD = new Pen(Color.Blue);

            public ADLink(byte setDirection, int setWaypoint)
            {
                direction = setDirection;
                waypoint  = setWaypoint;
            }

            public String GetLine() =>
                "#" + waypoint;
        }

        public class ADWaypoint
        {
            public double x, y, z;
            public bool flag = false;
            public List<ADLink> Links = new List<ADLink>();
            public int id = 0;
            // Own
            public String XMLLine = "", Line = "";
            public bool Edited = false, Show, Shown;
            public int canvasX, canvasY;

            public bool Align(double step, double offset)
            {
                if (step == 0 && offset == 0) return false;
                double ix = x, iz = z;
                x = Math.Round((x - offset) / step) * step + offset;
                z = Math.Round((z - offset) / step) * step + offset;
                return ix != x || iz != z;
            }

            public String GetLine() =>
                '#' + id + ' ' +
                  x.ToString(FloatFormat, NFI) + ", " +
                  y.ToString(FloatFormat, NFI) + ", " +
                  z.ToString(FloatFormat, NFI) + ", " +
                  flag;

            public String GetXMLLine() => (Edited)
                ? GetLine()
                : XMLLine;
        }

        public class ADGroup
        {
            public String name = "";
            public int order = 0;
            // Own
            public String XMLLine = "", Line = "";
            public bool Edited = false;

            public ADGroup(String line) => ReadXMLLine(Line = line, true);
            public void ReadXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                int tmp;
                FormSHME.ReadTagsAttribute(line, "n", out name, out tmp);
                if (0 < FormSHME.ReadTagsAttribute(line, "i", out line, out tmp)) int.TryParse(line, out order);
            }

            public String GetLine() =>
                "#" + order + " " + name;

            public String GetXMLLine() => (Edited)
                ? "        <g n=\"" + name +
                  "\" i=\"" + order +
                  "\"/>"
                : XMLLine;
        }

        public class ADMarker
        {
            public String name = "";
            public String groupName = "";
            public String waypoint = "1";
            // Own
            public int waypointID = 1;
            public String XMLLine = "", Line = "";
            public int groupID = 0;
            public bool Edited = false, Show, Shown;

            public ADMarker(String line) => ReadXMLLine(line, true);
            public void ReadXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                int tmp;
                FormSHME.ReadTagsAttribute(line, "n", out name, out tmp);
                FormSHME.ReadTagsAttribute(line, "g", out groupName, out tmp);
                if (FormSHME.ReadTagsAttribute(line, "i", out waypoint, out tmp) < 1) waypoint = "1";
                int.TryParse(waypoint, out waypointID);
                waypointID--;
            }

            public String GetLine() =>
                "#" + waypointID +
                " " + name +
                " <" + groupName +
                ">";

            public String GetXMLLine() => (Edited)
                ? "        <m i=\"" + waypointID +
                  "\" n=\"" + name +
                  "\" g=\"" + groupName +
                  "\"/>"
                : XMLLine;
        }

        public class ADRoute
        {
            public String name;
            public String fileName;
            public String map;
            public String revision;
            public String date;
            public List<String> otherLines = new List<String>();
            public String XMLLine, Line = "";
            public bool InfoEdited = false;
            // Route file
            public List<ADWaypoint> Waypoints = new List<ADWaypoint>();
            public List<ADMarker>   Markers   = new List<ADMarker>();
            public List<ADGroup>    Groups    = new List<ADGroup>();
            public bool Edited = false;

            public ADRoute(String line) => ReadXMLLine(line, true);
            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                int tmp;
                FormSHME.ReadTagsAttribute(line, "name",     out name,     out tmp);
                FormSHME.ReadTagsAttribute(line, "fileName", out fileName, out tmp);
                FormSHME.ReadTagsAttribute(line, "map",      out map,      out tmp);
                FormSHME.ReadTagsAttribute(line, "revision", out revision, out tmp);
                FormSHME.ReadTagsAttribute(line, "date",     out date,     out tmp);
            }

            public String GetXMLLine() => ((InfoEdited)
                ? "<route name=\""     + name +
                      "\" fileName=\"" + fileName +
                      "\" map=\""      + map +
                      "\" revision=\"" + revision +
                      "\" date=\""     + date +
                      "\">\r\n"
                : XMLLine + "\r\n")
                + String.Join("\r\n", otherLines) + "\r\n</route>";
        }

        private bool lockFilter = true;
        private String ManagerFileName = "", RouteFilesPath = "";
        private List<ADRoute> Routes = new List<ADRoute> { };
        public ADRoute SelectedRoute = null;
        private ADWaypoint SelectedWaypoint = null;

        #region Form
        public FormADrive()//Ok
        {
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()//Ok
        {
            lockFilter = true;
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
                                case "File" : tbManagerFile.Text = value; break;
                                case "Route": selectRouteFile    = value; break;
                                // Position
                                case "PositionStep"  : FormSHME.SetNUD(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": FormSHME.SetNUD(nudPositionOffset, value, NFI); break;
                                case "LimitXMin"     : FormSHME.SetNUD(nudLimitXMin,      value, NFI); break;
                                case "LimitXMax"     : FormSHME.SetNUD(nudLimitXMax,      value, NFI); break;
                                case "LimitYMin"     : FormSHME.SetNUD(nudLimitYMin,      value, NFI); break;
                                case "LimitYMax"     : FormSHME.SetNUD(nudLimitYMax,      value, NFI); break;
                                case "LimitZMin"     : FormSHME.SetNUD(nudLimitZMin,      value, NFI); break;
                                case "LimitZMax"     : FormSHME.SetNUD(nudLimitZMax,      value, NFI); break;
                                case "LimitX"        : cbLimitX.Checked = (value.ToLower() == "true"); break;
                                case "LimitY"        : cbLimitY.Checked = (value.ToLower() == "true"); break;
                                case "LimitZ"        : cbLimitZ.Checked = (value.ToLower() == "true"); break;
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
            lockFilter = false;
            if (tbManagerFile.Text != "")
                Routes_Load(tbManagerFile.Text, selectRouteFile);
        }

        public void OptionSave()//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(IniFileName))
                {
                    file.WriteLine("File\t" + tbManagerFile.Text);
                    if (SelectedRoute != null) file.WriteLine("Route\t" + SelectedRoute.fileName);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value.ToString(NFI));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(NFI));
                    file.WriteLine("LimitXMin\t"      + nudLimitXMin     .Value.ToString(NFI));
                    file.WriteLine("LimitXMax\t"      + nudLimitXMax     .Value.ToString(NFI));
                    file.WriteLine("LimitYMin\t"      + nudLimitYMin     .Value.ToString(NFI));
                    file.WriteLine("LimitYMax\t"      + nudLimitYMax     .Value.ToString(NFI));
                    file.WriteLine("LimitZMin\t"      + nudLimitZMin     .Value.ToString(NFI));
                    file.WriteLine("LimitZMax\t"      + nudLimitZMax     .Value.ToString(NFI));
                    file.WriteLine("LimitX\t"         + cbLimitX.Checked       .ToString());
                    file.WriteLine("LimitY\t"         + cbLimitY.Checked       .ToString());
                    file.WriteLine("LimitZ\t"         + cbLimitZ.Checked       .ToString());
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
        private void btnManagerReload_Click(object sender, EventArgs e) => Routes_Load(tbManagerFile.Text, SelectedRoute?.fileName);//Ok
        private void btnManagerLoad_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(tbManagerFile.Text);
            if (tbManagerFile.Text != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(tbManagerFile.Text).Replace(Path.GetFileName(tbManagerFile.Text), "");
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            Routes_Load(dlgOpen.FileName);
        }

        private void Routes_Load(String fileName, String selectRouteFile = "")
        {
            try
            {
                ADRoute r;
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
                        Routes.Add(r = new ADRoute(s));
                        while (!file.EndOfStream)
                        {
                            s = file.ReadLine();
                            if (s.Contains("</route>")) break;
                            r.otherLines.Add(s);
                        }
                        // Add to list
                        tvRoutes.Nodes.Add(n = new TreeNode(r.name));
                        if (selectRouteFile == r.fileName)
                            sn = n;
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
            tbRouteName.Enabled = (tvRoutes.SelectedNode != null);
            SelectedRoute = (tvRoutes.SelectedNode?.Tag as ADRoute);
            // Apply values
            tbRouteName.Text = SelectedRoute.name;
            Route_Load();
        }

        private void RouteInfo_ValueChanged(object sender, EventArgs e) =>
            btnRouteInfoSave.Visible = ((tvRoutes.SelectedNode.Tag as ADRoute).name != tbRouteName.Text);

        private void tbRouteName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnRouteInfoSave_Click(null, null);
            e.Handled = true;
        }

        private void tvRoutes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            String s = e.Label ?? e.Node.Text;
            if (tbRouteName.Text == s) return;
            tbRouteName.TextChanged -= RouteInfo_ValueChanged;
            tbRouteName.Text
                = SelectedRoute.name
                = s;
            SelectedRoute.InfoEdited = true;
            SelectedRoute.Line = SelectedRoute.GetXMLLine();
            tbRouteName.TextChanged += RouteInfo_ValueChanged;
            btnRouteInfoSave.Visible = false;
        }

        private void btnRouteInfoSave_Click(object sender, EventArgs e)
        {
            ADRoute r = (tvRoutes.SelectedNode?.Tag as ADRoute);
            if (r == null) return;
            tvRoutes.SelectedNode.Text
                = r.name
                = tbRouteName.Text;
            r.InfoEdited = true;
            r.Line = r.GetXMLLine();
            // Update UI
            btnRouteInfoSave.Visible = false;
        }

        private void btnRoutesSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<autoDriveRoutesManager>\r\n    <routes>");
                    foreach (ADRoute r in Routes)
                    {
                        file.WriteLine((r.InfoEdited)
                            ? r.XMLLine = r.Line
                            : r.XMLLine);
                        r.InfoEdited = false;
                    }
                    file.WriteLine("    </routes>\r\n</autoDriveRoutesManager>");
                }
                btnManagerFileSave.Visible = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Route
        private void btnRouteReload_Click(object sender, EventArgs e) => Route_Load();
        private void Route_Load()
        {

            //gbEdit.Enabled = false;
            if (SelectedRoute == null)
                return;
            try
            {
                clbWaypoints.BeginUpdate();     clbWaypoints.Items.Clear();
                cbbLinkPoint.BeginUpdate();     cbbLinkPoint.Items.Clear();
                tvLinks.BeginUpdate();          tvLinks.Nodes.Clear();
                //
                cbbMarkerPoint.BeginUpdate();   cbbMarkerPoint.Items.Clear();
                cbbMarkerGroup.BeginUpdate();   cbbMarkerGroup.Items.Clear();
                clbMarkers.BeginUpdate();       clbMarkers.Items.Clear();
                //
                clbGroups.BeginUpdate();        clbGroups.Items.Clear();
                // Prepare
                int q1, q2;
                String s, tag;
                double[] x    = new double[0],
                         y    = new double[0],
                         z    = new double[0];
                String[] flag = new String[0],
                         iIDs = new String[0],
                         oIDs = new String[0];
                SelectedRoute.Groups.Clear();
                SelectedRoute.Markers.Clear();
                SelectedRoute.Waypoints.Clear();
                using (StreamReader file = File.OpenText(RouteFilesPath + "\\routes\\" + SelectedRoute.fileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        // Get container
                        q1 = s.IndexOf("<") + 1;
                        if (q1 < 1) continue;
                        q2 = s.IndexOf(">", q1);
                        if (q2 < 1) continue;
                        tag = s.Substring(q1, q2 - q1);
                        // Case
                        switch (tag)
                        {
                            case "x"    : x    = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "y"    : y    = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "z"    : z    = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "flags": flag =                 ExtractTagContent(s).Split(';'); break;
                            case "in"   : iIDs =                 ExtractTagContent(s).Split(';'); break;
                            case "out"  : oIDs =                 ExtractTagContent(s).Split(';'); break;
                            default:
                                tag = tag.Substring(0, 2);
                                     if (tag == "m ") SelectedRoute.Markers.Add(new ADMarker(s));
                                else if (tag == "g ") SelectedRoute.Groups .Add(new ADGroup (s));
                                break;
                        }
                    }

                // Sort and add groups
                SelectedRoute.Groups.Sort((a, b) => (a.order < b.order) ? -1 : (a.order > b.order) ? 1 : 0);
                foreach (ADGroup g in SelectedRoute.Groups)
                {
                    cbbMarkerGroup.Items.Add(s = g.GetLine());
                    clbGroups.Items.Add(s);
                }
                // Build and add points
                ADWaypoint p;
                q2 = Math.Max(iIDs.Length,
                     Math.Max(oIDs.Length,
                     Math.Max(x   .Length,
                     Math.Max(y   .Length,
                     Math.Max(z   .Length,
                              flag.Length)))));
                int[] iID, oID;
                IEnumerable<int> IDBD;
                for (int i = 0; i < q2; i++)
                {
                    SelectedRoute.Waypoints.Add(p = new ADWaypoint());
                    p.id = i + 1;
                    if (i < x.Length) p.x = x[i];
                    if (i < y.Length) p.y = y[i];
                    if (i < z.Length) p.z = z[i];
                    if (i < flag.Length) p.flag = (flag[i] == "1");
                    iID = new int[0];
                    oID = new int[0];
                    if (i < iIDs.Length) if (iIDs[i] != "-1") iID = BreakLine_Integer(iIDs[i], ',');
                    if (i < oIDs.Length) if (oIDs[i] != "-1") oID = BreakLine_Integer(oIDs[i], ',');
                    IDBD = iID.Intersect(oID);
                    foreach (int ID in IDBD)             p.Links.Add(new ADLink(3, ID - 1)); // Bidirectional
                    foreach (int ID in iID.Except(IDBD)) p.Links.Add(new ADLink(2, ID - 1)); // In
                    foreach (int ID in oID.Except(IDBD)) p.Links.Add(new ADLink(1, ID - 1)); // Out
                    p.Links.Sort((a, b) => (a.waypoint < b.waypoint) ? -1 : (a.waypoint > b.waypoint) ? 1 : 0);
                    cbbMarkerPoint.Items.Add(p.Line = p.GetLine());
                }
                // Add markers
                foreach (ADMarker m in SelectedRoute.Markers)
                {
                    clbMarkers.Items.Add(m.GetLine());
                    m.groupID = SelectedRoute.Groups.FindIndex(i => (i.name == m.groupName));
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            clbWaypoints.EndUpdate();
            cbbLinkPoint.EndUpdate();
            tvLinks.EndUpdate();
            //
            cbbMarkerPoint.EndUpdate();
            cbbMarkerGroup.EndUpdate();
            clbMarkers.EndUpdate();
            //
            clbGroups.EndUpdate();
            FilterWaypoints();
        }

        private void nudPositionStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitXMin.Increment = nudLimitXMax.Increment =
            nudLimitYMin.Increment = nudLimitYMax.Increment =
            nudLimitZMin.Increment = nudLimitZMax.Increment = nudPositionStep.Value;

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
                btnRouteSave.Visible
                    = btnRouteReload.Visible
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

        private void FilterWaypoints()//Ok
        {
            if (lockFilter) return;
            clbWaypoints.BeginUpdate();
            clbWaypoints.Items.Clear();
            // Prepare
            Double minX = (Double)nudLimitXMin.Value, maxX = (Double)nudLimitXMax.Value,
                   minY = (Double)nudLimitYMin.Value, maxY = (Double)nudLimitYMax.Value,
                   minZ = (Double)nudLimitZMin.Value, maxZ = (Double)nudLimitZMax.Value;
            bool limitX = cbLimitX.Checked,
                 limitY = cbLimitY.Checked,
                 limitZ = cbLimitZ.Checked;
            // Select
            foreach (ADWaypoint p in SelectedRoute.Waypoints)
            {
                p.Show = false;
                if (cbLimitX.Checked) if (p.x < (Double)nudLimitXMin.Value || (Double)nudLimitXMax.Value < p.x) continue;
                if (cbLimitY.Checked) if (p.y < (Double)nudLimitYMin.Value || (Double)nudLimitYMax.Value < p.y) continue;
                if (cbLimitZ.Checked) if (p.z < (Double)nudLimitZMin.Value || (Double)nudLimitZMax.Value < p.z) continue;
                // Allowed
                clbWaypoints.Items.Add(p.Line);
                p.Show = true;
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
            ADWaypoint p;
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                p = SelectedRoute.Waypoints[i];
                if (p.Align(step, offset))
                {
                    p.Edited = true;
                    clbWaypoints.Items[i]
                        = p.Line
                        = p.GetLine();
                }
            }
            // Finish
            clbWaypoints.EndUpdate();
            FilterWaypoints();
        }
        #endregion

        #region Point
        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPointSave.Visible = false;
            if (clbWaypoints.SelectedIndex < 0 || SelectedRoute == null)
            {
                SelectedWaypoint = null;
                gbWaypoint.Enabled = false;
                tvLinks.Nodes.Clear();
                return;
            }
            SelectedWaypoint = SelectedRoute.Waypoints[clbWaypoints.SelectedIndex];
            nudX.Value = (decimal)SelectedWaypoint.x;
            nudY.Value = (decimal)SelectedWaypoint.y;
            nudZ.Value = (decimal)SelectedWaypoint.z;
            chbFlag.Checked = SelectedWaypoint.flag;
            TreeNode tn;
            foreach (ADLink l in SelectedWaypoint.Links)
            {
                tvLinks.Nodes.Add(tn = new TreeNode(SelectedRoute.Waypoints[l.waypoint].Line));
                tn.StateImageIndex = l.direction;
            }
            gbWaypoint.Enabled = true;
        }

        private void WaypointInfo_Changed(object sender, EventArgs e) =>
            btnPointSave.Visible = (
                (double)nudX.Value != SelectedWaypoint.x ||
                (double)nudY.Value != SelectedWaypoint.y ||
                (double)nudZ.Value != SelectedWaypoint.z ||
                chbFlag.Checked    != SelectedWaypoint.flag);

        private void btnWaypointSave_Click(object sender, EventArgs e)
        {
            SelectedWaypoint.x = (double)nudX.Value; 
            SelectedWaypoint.y = (double)nudY.Value;
            SelectedWaypoint.z = (double)nudZ.Value;
            SelectedWaypoint.flag = chbFlag.Checked;
            // Update UI
            clbWaypoints.SelectedItem
                = SelectedWaypoint.Line
                = SelectedWaypoint.GetLine();
            btnRouteSave.Visible
                = btnRouteReload.Visible
                = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnWaypointInsert_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnWaypointDelete_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Links
        private void tvLinks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //
        }

        private void cbbWaypointLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnLinkInsert_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnLinkSave_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)
        {
            //
        }
        #endregion

        #region Markers
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
            ADMarker m = SelectedRoute.Markers[id];
            tbMarkerName.Text = m.name;
            cbbMarkerGroup.SelectedIndex = m.groupID;
            cbbMarkerPoint.SelectedIndex = m.waypointID - 1;
            gbMarker.Enabled = true;
        }

        private void Marker_ValueChanged(object sender, EventArgs e)
        {
            int id = clbMarkers.SelectedIndex;
            if (id < 0) return;
            ADMarker m = SelectedRoute.Markers[id];
            btnSaveMarker.Visible = (
                tbMarkerName.Text != m.name ||
                cbbMarkerGroup.SelectedIndex != m.groupID ||
                cbbMarkerPoint.SelectedIndex + 1 != m.waypointID);
        }

        private void btnMarkerSave_Click(object sender, EventArgs e)
        {
            btnSaveMarker.Visible = false;
            int id = clbMarkers.SelectedIndex;
            if (id < 0) return;
            ADMarker m = SelectedRoute.Markers[id];
            m.name = tbMarkerName.Text;
            m.groupID = cbbMarkerGroup.SelectedIndex;
            m.groupName = SelectedRoute.Groups[m.groupID].name;
            m.waypointID = cbbMarkerPoint.SelectedIndex + 1;
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

        #region Groups
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
            ADGroup g = SelectedRoute.Groups[clbGroups.SelectedIndex];
            lblGroupID.Text = g.order.ToString();
            tbGroupName.Text = g.name;
            btnDeleteGroup.Visible = (g.order != 1);
        }

        private void Limit_ValueChanged(object sender, EventArgs e)
        {
            if (cbLimitX.Checked || cbLimitX.Checked || cbLimitZ.Checked) ;
                //FilterWaypoints();
        }

        private void Group_ValueChanged(object sender, EventArgs e) =>
            btnSaveGroup.Visible = (tbGroupName.Text != SelectedRoute.Groups[clbGroups.SelectedIndex].name);

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            int id = clbGroups.SelectedIndex;
            btnSaveGroup.Visible = false;
            if (id < 0) return;
            ADGroup g = SelectedRoute.Groups[id];
            g.name = tbGroupName.Text;
            g.Line = g.GetLine();
            cbbMarkerGroup.Items[id]
                = clbGroups.Items[id]
                = g.Line;
            int i = 0;
            foreach (ADMarker m in SelectedRoute.Markers)
            {
                if (id == m.groupID)
                {
                    m.groupName = g.Line;
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
            foreach (ADGroup g in SelectedRoute.Groups)
            {
                if (id < i)
                {
                    g.order--;
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
            foreach (ADMarker m in SelectedRoute.Markers)
            {
                if (id <= m.groupID)
                    if (id == m.groupID)
                    {
                        m.groupID = 0;
                        m.groupName = g0Name;
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
