using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static SHME.FormADrive;
using static SHME.FormCPlay;
using static SHME.FormItems;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SHME
{
    public partial class FormADrive : Form
    {
        public static readonly int[] pinSelection = {
            0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF};
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

        public static FSPins Pins = new FSPins(5, 5, 2, 2,
            new int[][]{
                pinNormal,
                pinFlaged},
            pinSelection,
            new Pen[]{
                new Pen(Color.DarkGray),
                new Pen(Color.Green),
                new Pen(Color.Green),
                new Pen(Color.Blue)}
            );

        private const String FloatFormat = "f2";
        private const String IniFileName = "ADrive.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public const byte ADLinkOut = 1,
                          ADLinkIn  = 2;
        public class ADLink
        {
            public int waypointID = 0;
            public byte direction = 0;

            public ADLink(byte setDirection, int setWaypoint)
            {
                direction = setDirection;
                waypointID = setWaypoint;
            }

            public String GetLine() =>
                "#" + waypointID;
        }

        public class ADWaypoint : FSObject
        {
            public bool flag = false;
            public List<ADLink> Links = new List<ADLink>();
            public int id = 1;

            public ADWaypoint() : base("") { }

            override public void DecodeXMLLine(String line) { }

            override public String BuildListLine() =>
                "#" + id + " " +
                  Position.X.ToString(FloatFormat, NFI) + ", " +
                  Position.Y.ToString(FloatFormat, NFI) + ", " +
                  Position.Z.ToString(FloatFormat, NFI) + ", " +
                  flag;

            override public String BuildXMLLine() => "";
        }

        public class ADGroup
        {
            public String name = "";
            public int order = 1;
            // Own
            public String XMLLine = "", ListLine = "";
            public bool Edited = false;

            public ADGroup(String line) => ReadXMLLine(ListLine = line, true);
            public void ReadXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = ListLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "n", out name, out tmp);
                if (0 < ReadValue.TagsAttribute(line, "i", out line, out tmp)) int.TryParse(line, out order);
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
            public int waypointIdx = 1;
            public String XMLLine = "", ListLine = "";
            public int groupIdx = 0;
            public bool Edited = false, Show, Shown;

            public ADMarker(String line) => ReadXMLLine(line, true);
            public void ReadXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = ListLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "n", out name, out tmp);
                ReadValue.TagsAttribute(line, "g", out groupName, out tmp);
                if (ReadValue.TagsAttribute(line, "i", out waypoint, out tmp) < 1) waypoint = "1";
                int.TryParse(waypoint, out waypointIdx);
                waypointIdx--;
            }

            public String GetLine() =>
                "#" + waypointIdx +
                " " + name +
                " <" + groupName +
                ">";

            public String GetXMLLine() => (Edited)
                ? "        <m i=\"" + (waypointIdx + 1) +
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
            public String XMLLine, ListLine = "";
            public bool InfoEdited = false;
            // Route file
            public List<ADWaypoint> Waypoints = new List<ADWaypoint>();
            public List<ADMarker> Markers = new List<ADMarker>();
            public List<ADGroup> Groups = new List<ADGroup>();
            public bool Edited = false, Loaded = false;
            public int newLineID = 1;
            public int newGroupID = 1;

            public ADRoute(String line) => ReadXMLLine(line, true);
            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = ListLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "name", out name, out tmp);
                ReadValue.TagsAttribute(line, "fileName", out fileName, out tmp);
                ReadValue.TagsAttribute(line, "map", out map, out tmp);
                ReadValue.TagsAttribute(line, "revision", out revision, out tmp);
                ReadValue.TagsAttribute(line, "date", out date, out tmp);
            }

            public String GetXMLLine() => ((InfoEdited)
                ? "<route name=\"" + name +
                      "\" fileName=\"" + fileName +
                      "\" map=\"" + map +
                      "\" revision=\"" + revision +
                      "\" date=\"" + date +
                      "\">\r\n"
                : XMLLine + "\r\n")
                + String.Join("\r\n", otherLines) + "\r\n</route>";
        }

        private bool lockFilter = true;
        private String ManagerFileName = "", RouteFilesPath = "";
        private List<ADRoute> Routes = new List<ADRoute> { };
        // Visible outside
        private List<ADWaypoint> WaypointsShow  = new List<ADWaypoint> { };
        public  List<ADWaypoint> WaypointsShown = new List<ADWaypoint> { };
        public ADRoute SelectedRoute = null;
        public ADWaypoint SelectedWaypoint = null;
        public ADLink SelectedLink = null;

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
                                case "File": tbManagerFile.Text = value; break;
                                case "Route": selectRouteFile = value; break;
                                // Position
                                case "PositionStep"  : ReadValue.NUDDouble(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": ReadValue.NUDDouble(nudPositionOffset, value, NFI); break;
                                case "LimitXMin"     : ReadValue.NUDDouble(nudLimitXMin,      value, NFI); break;
                                case "LimitXMax"     : ReadValue.NUDDouble(nudLimitXMax,      value, NFI); break;
                                case "LimitYMin"     : ReadValue.NUDDouble(nudLimitYMin,      value, NFI); break;
                                case "LimitYMax"     : ReadValue.NUDDouble(nudLimitYMax,      value, NFI); break;
                                case "LimitZMin"     : ReadValue.NUDDouble(nudLimitZMin,      value, NFI); break;
                                case "LimitZMax"     : ReadValue.NUDDouble(nudLimitZMax,      value, NFI); break;
                                case "LimitX": cbLimitX.Checked = (value.ToLower() == "true"); break;
                                case "LimitY": cbLimitY.Checked = (value.ToLower() == "true"); break;
                                case "LimitZ": cbLimitZ.Checked = (value.ToLower() == "true"); break;
                                case "ListVisibleOnly": cbListVisible.Checked = (value.ToLower() == "true"); break;
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
                    file.WriteLine("PositionStep\t" + nudPositionStep.Value.ToString(NFI));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(NFI));
                    file.WriteLine("LimitXMin\t" + nudLimitXMin.Value.ToString(NFI));
                    file.WriteLine("LimitXMax\t" + nudLimitXMax.Value.ToString(NFI));
                    file.WriteLine("LimitYMin\t" + nudLimitYMin.Value.ToString(NFI));
                    file.WriteLine("LimitYMax\t" + nudLimitYMax.Value.ToString(NFI));
                    file.WriteLine("LimitZMin\t" + nudLimitZMin.Value.ToString(NFI));
                    file.WriteLine("LimitZMax\t" + nudLimitZMax.Value.ToString(NFI));
                    file.WriteLine("LimitX\t" + cbLimitX.Checked.ToString());
                    file.WriteLine("LimitY\t" + cbLimitY.Checked.ToString());
                    file.WriteLine("LimitZ\t" + cbLimitZ.Checked.ToString());
                    file.WriteLine("ListVisibleOnly\t" + cbListVisible.Checked.ToString());
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
                ADRoute route;
                String XMLLine;
                TreeNode routeNode, selectRouteNode = null;
                Routes.Clear();
                tvRoutes.BeginUpdate();
                tvRoutes.Nodes.Clear();
                // Load info
                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        XMLLine = file.ReadLine();
                        if (!XMLLine.Contains("<route "))
                            continue;
                        // Add route record
                        Routes.Add(route = new ADRoute(XMLLine));
                        while (!file.EndOfStream)
                        {
                            XMLLine = file.ReadLine();
                            if (XMLLine.Contains("</route>")) break;
                            route.otherLines.Add(XMLLine);
                        }
                        // Add to list
                        tvRoutes.Nodes.Add(routeNode = new TreeNode(route.name));
                        if (selectRouteFile == route.fileName)
                            selectRouteNode = routeNode;
                        routeNode.Tag = route;
                    }
                RouteFilesPath = Path.GetDirectoryName(
                    tbManagerFile.Text
                        = ManagerFileName
                        = fileName);
                tvRoutes.EndUpdate();
                // Select ordered file
                if (selectRouteNode == null)
                {
                    SelectedRoute = null;
                    tvRoutes_AfterSelect(null, null);
                }
                else
                {
                    tvRoutes.SelectedNode = selectRouteNode;
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
            SelectedRoute = (tvRoutes.SelectedNode?.Tag as ADRoute);
            tcADrive.Enabled = (SelectedRoute != null);
            if (SelectedRoute?.Loaded ?? true)
                Route_Select();
            else
                btnRouteReload_Click(null, null);
        }

        private void tvRoutes_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvRoutes.GetNodeAt(e.X, e.Y) != null) return;
            tvRoutes.SelectedNode = null;
            tvRoutes_AfterSelect(null, null);
        }

        private void tvRoutes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            String routeName = e.Label ?? e.Node.Text;
            if (routeName == "")
            {
                e.CancelEdit = true;
                return;
            }
            SelectedRoute.name = routeName;
        }

        private void btnManagerFileSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<autoDriveRoutesManager>\r\n    <routes>");
                    foreach (ADRoute r in Routes)
                    {
                        file.WriteLine((r.InfoEdited)
                            ? r.XMLLine = r.GetXMLLine()
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
        private void nudPositionStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitXMin.Increment = nudLimitXMax.Increment =
            nudLimitYMin.Increment = nudLimitYMax.Increment =
            nudLimitZMin.Increment = nudLimitZMax.Increment = nudPositionStep.Value;

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
            foreach (String c in s)
                Double.TryParse(c, NumberStyles.Float, NFI, out v[i++]);
            return v;
        }

        private int[] BreakLine_Integer(String line, char spliter)
        {
            String[] s = line.Split(spliter);
            int[] v = new int[s.Length];
            int i = 0;
            foreach (String c in s)
                int.TryParse(c, out v[i++]);
            return v;
        }

        private void btnRouteReload_Click(object sender, EventArgs e)
        {
            //gbEdit.Enabled = false;
            if (SelectedRoute == null) return;
            try
            {
                SelectedRoute.Groups.Clear();
                SelectedRoute.Markers.Clear();
                SelectedRoute.Waypoints.Clear();
                // Prepare
                int q1, q2;
                String s, tag;
                double[] x = new double[0],
                         y = new double[0],
                         z = new double[0];
                String[] flag = new String[0],
                         iIDs = new String[0],
                         oIDs = new String[0];
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
                            case "x": x = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "y": y = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "z": z = BreakLine_Float(ExtractTagContent(s), ';'); break;
                            case "flags": flag = ExtractTagContent(s).Split(';'); break;
                            case "in": iIDs = ExtractTagContent(s).Split(';'); break;
                            case "out": oIDs = ExtractTagContent(s).Split(';'); break;
                            default:
                                tag = tag.Substring(0, 2);
                                if (tag == "m ") SelectedRoute.Markers.Add(new ADMarker(s));
                                else if (tag == "g ") SelectedRoute.Groups.Add(new ADGroup(s));
                                break;
                        }
                    }

                // Build and add points
                ADWaypoint p;
                SelectedRoute.newGroupID = SelectedRoute.Groups.Count + 1;
                SelectedRoute.newLineID =
                     Math.Max(iIDs.Length,
                     Math.Max(oIDs.Length,
                     Math.Max(x.Length,
                     Math.Max(y.Length,
                     Math.Max(z.Length,
                              flag.Length)))));
                int[] iID, oID;
                IEnumerable<int> IDBD;
                for (int i = 0; i < SelectedRoute.newLineID; i++)
                {
                    SelectedRoute.Waypoints.Add(p = new ADWaypoint());
                    p.id = i + 1;
                    p.Position.Present = true;
                    if (i < x.Length) p.Position.X = x[i];
                    if (i < y.Length) p.Position.Y = y[i];
                    if (i < z.Length) p.Position.Z = z[i];
                    if (i < flag.Length) p.flag = (flag[i] == "1");
                    p.PinState = p.flag ? 1 : 0;
                    iID = new int[0];
                    oID = new int[0];
                    if (i < iIDs.Length) if (iIDs[i] != "-1") iID = BreakLine_Integer(iIDs[i], ',');
                    if (i < oIDs.Length) if (oIDs[i] != "-1") oID = BreakLine_Integer(oIDs[i], ',');
                    IDBD = iID.Intersect(oID);
                    foreach (int ID in IDBD) p.Links.Add(new ADLink(3, ID - 1)); // Bidirectional
                    foreach (int ID in iID.Except(IDBD)) p.Links.Add(new ADLink(2, ID - 1)); // In
                    foreach (int ID in oID.Except(IDBD)) p.Links.Add(new ADLink(1, ID - 1)); // Out
                    p.Links.Sort((a, b) => (a.waypointID < b.waypointID) ? -1 : (a.waypointID > b.waypointID) ? 1 : 0);
                    p.ListLine = p.GetListLine();
                }
                // Sort and add groups
                SelectedRoute.Groups.Sort((a, b) => (a.order < b.order) ? -1 : (a.order > b.order) ? 1 : 0);
                foreach (ADGroup group in SelectedRoute.Groups)
                    group.ListLine = group.GetLine();
                // Add markers
                foreach (ADMarker marker in SelectedRoute.Markers)
                {
                    marker.ListLine = marker.GetLine();
                    marker.groupIdx = SelectedRoute.Groups.FindIndex(g => (g.name == marker.groupName));
                }
                SelectedRoute.newLineID++;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            Route_Select();
        }

        private void Route_Select()
        {
            clbWaypoints.BeginUpdate(); clbWaypoints.Items.Clear();
            cbbLinkPoint.BeginUpdate(); cbbLinkPoint.Items.Clear();
            tvLinks     .BeginUpdate(); tvLinks     .Nodes.Clear();
            //
            cbbMarkerWaypoint.BeginUpdate(); cbbMarkerWaypoint.Items.Clear();
            cbbMarkerGroup   .BeginUpdate(); cbbMarkerGroup   .Items.Clear();
            tvMarkers        .BeginUpdate(); tvMarkers        .Nodes.Clear();
            //
            tvGroups.BeginUpdate(); tvGroups.Nodes.Clear();
            if (SelectedRoute != null)
            {
                SelectedRoute.newGroupID = SelectedRoute.Groups.Count + 1;
                foreach (ADWaypoint waypoint in SelectedRoute.Waypoints)
                {
                    cbbMarkerWaypoint.Items.Add(waypoint.ListLine);
                    cbbLinkPoint.Items.Add(waypoint.ListLine);
                }
                foreach (ADGroup group in SelectedRoute.Groups)
                {
                    cbbMarkerGroup.Items.Add(group.ListLine);
                    tvGroups.Nodes.Add(group.ListLine);
                }
                foreach (ADMarker marker in SelectedRoute.Markers)
                    tvMarkers.Nodes.Add(marker.ListLine);
            }
            else
            {
                clbWaypoints.SelectedIndex = -1;
                tvMarkers.SelectedNode =
                tvGroups.SelectedNode = null;
                clbWaypoints_SelectedIndexChanged(null, null);
                tvMarkers_AfterSelect(null, null);
                tvGroups_AfterSelect(null, null);
                tcADrive.SelectTab(0);
            }
            // Finish
            clbWaypoints.EndUpdate();
            cbbLinkPoint.EndUpdate();
            tvLinks     .EndUpdate();
            //
            cbbMarkerWaypoint.EndUpdate();
            cbbMarkerGroup   .EndUpdate();
            tvMarkers        .EndUpdate();
            //
            tvGroups.EndUpdate();
            FilterWaypoints();
        }

        private void FilterWaypoints()//Ok
        {
            if (lockFilter) return;
            WaypointsShow.Clear();
            // Prepare
            Double minX = (Double)nudLimitXMin.Value, maxX = (Double)nudLimitXMax.Value,
                   minY = (Double)nudLimitYMin.Value, maxY = (Double)nudLimitYMax.Value,
                   minZ = (Double)nudLimitZMin.Value, maxZ = (Double)nudLimitZMax.Value;
            bool limitX = cbLimitX.Checked,
                 limitY = cbLimitY.Checked,
                 limitZ = cbLimitZ.Checked;
            // Select
            if (SelectedRoute != null)
                foreach (ADWaypoint p in SelectedRoute.Waypoints)
                {
                    p.Show = false;
                    if (limitX) if (p.Position.X < minX || maxX < p.Position.X) continue;
                    if (limitY) if (p.Position.Y < minY || maxY < p.Position.Y) continue;
                    if (limitZ) if (p.Position.Z < minZ || maxZ < p.Position.Z) continue;
                    // Allowed
                    WaypointsShow.Add(p);
                    p.Show = true;
                }
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void cbListVisible_CheckedChanged(object sender, EventArgs e) => Relist(true);

        public void Relist(bool force = false)
        {
            if (lockFilter) return;
            if (SelectedRoute != null) FormSHME.Main.ProjectObjects(SelectedRoute.Waypoints);
            if (cbListVisible.Checked || force) // Skip if wasn't checked in first place
            {
                clbWaypoints.SelectedIndex = -1; // Temp
                clbWaypoints_SelectedIndexChanged(null, null);
                //
                WaypointsShown = (cbListVisible.Checked)
                    ? FormSHME.Main.CheckObjectsVisibility(WaypointsShow, Pins).Cast<ADWaypoint>().ToList()
                    : WaypointsShow;
                // List
                clbWaypoints.BeginUpdate();
                clbWaypoints.Items.Clear();
                if (SelectedRoute != null)
                    foreach (ADWaypoint waypoint in WaypointsShown)
                        clbWaypoints.Items.Add(waypoint.ListLine);
                clbWaypoints.EndUpdate();
            }
        }

        private void Limit_ValueChanged(object sender, EventArgs e)
        {
            if (cbLimitX.Checked || cbLimitX.Checked || cbLimitZ.Checked)
                FilterWaypoints();
        }

        private void clbWaypoints_MouseClick(object sender, MouseEventArgs e) => UIBasics.CheckedListBox_MouseClick(clbWaypoints, e);

        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            Double step = (Double)nudPositionStep.Value;
            Double offset = (Double)nudPositionOffset.Value;
            if (clbWaypoints.CheckedIndices.Count < 1)
                return;
            ADWaypoint p;
            clbWaypoints.BeginUpdate();
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                p = WaypointsShow[i];
                if (p.Position.Align(step, offset, true, false, true))
                {
                    p.Edited = true;
                    clbWaypoints.Items[i]
                        = p.ListLine
                        = p.GetListLine();
                }
            }
            // Finish
            clbWaypoints.EndUpdate();
            FilterWaypoints();
        }

        private void btnRouteClear_Click(object sender, EventArgs e)
        {
            clbWaypoints.BeginUpdate();
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                if (clbWaypoints.GetItemChecked(i))
                {
                    clbWaypoints.Items.RemoveAt(i);
                    SelectedRoute.Waypoints.Remove(WaypointsShow[i]);
                    WaypointsShow.RemoveAt(i);
                }
            clbWaypoints.EndUpdate();
            FormSHME.Main.IAC_Redraw();
        }

        private void btnRouteSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = File.CreateText(RouteFilesPath + "\\" + SelectedRoute.fileName))
                {
                    ADWaypoint p;
                    String sX = "", sI = "",
                           sY = "", sO = "",
                           sZ = "", sF = "";
                    List<String> sIs = new List<String>(),
                                 sOs = new List<String>();
                    int n = SelectedRoute.Waypoints.Count;
                    file.WriteLine("<routeExport>");
                    file.WriteLine("    <waypoints =\"" + n + "\">");
                    sX = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.X.ToString(FloatFormat, NFI)));
                    sY = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.Y.ToString(FloatFormat, NFI)));
                    sZ = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.Z.ToString(FloatFormat, NFI)));
                    sF = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.flag ? "1" : "0"));
                    for (int i = 0; i < n; i++)
                    {
                        p = SelectedRoute.Waypoints[i];
                        sO = String.Join(",", p.Links.Where(l => l.direction != ADLinkIn ).ToList().ConvertAll(l => (l.waypointID + 1).ToString()));
                        sI = String.Join(",", p.Links.Where(l => l.direction != ADLinkOut).ToList().ConvertAll(l => (l.waypointID + 1).ToString()));
                        sOs.Add((sO == "") ? "-1" : sO);
                        sIs.Add((sI == "") ? "-1" : sI);
                    }
                    // Output
                    file.WriteLine("        <x>" + sX + "</x>");
                    file.WriteLine("        <y>" + sY + "</y>");
                    file.WriteLine("        <z>" + sZ + "</z>");
                    file.WriteLine("        <out>" + String.Join(";", sOs) + "</out>");
                    file.WriteLine("        <in>"  + String.Join(";", sIs) + "</in>" );
                    file.WriteLine("        <flag>" + sF + "</flag>");
                    file.Write("    </waypoints>\r\n    <markers>"); foreach (ADMarker m in SelectedRoute.Markers) file.WriteLine(m.GetXMLLine());
                    file.Write("    </markers>\r\n    <groups>"); foreach (ADGroup g in SelectedRoute.Groups) file.WriteLine(g.GetXMLLine());
                    file.Write("    </groups>\r\n</routeExport>");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Point
        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvLinks.Nodes.Clear();
            btnPointSave.Visible = false;
            tvLinks.SelectedNode = null;
            tvLinks_AfterSelect(null, null);
            if (clbWaypoints.SelectedIndex < 0)
            {
                nudX.Value = 0;
                nudY.Value = 0;
                nudZ.Value = 0;
                chbFlag.Checked = false;
                gbWaypoint.Enabled = false;
                return;
            }
            SelectedWaypoint = WaypointsShown[clbWaypoints.SelectedIndex];
            nudX.Value = (decimal)SelectedWaypoint.Position.X;
            nudY.Value = (decimal)SelectedWaypoint.Position.Y;
            nudZ.Value = (decimal)SelectedWaypoint.Position.Z;
            chbFlag.Checked = SelectedWaypoint.flag;
            TreeNode tn;
            foreach (ADLink l in SelectedWaypoint.Links)
            {
                tvLinks.Nodes.Add(tn = new TreeNode(SelectedRoute.Waypoints[l.waypointID].ListLine));
                tn.StateImageIndex = l.direction;
            }
            gbWaypoint.Enabled = true;
        }

        private void WaypointInfo_Changed(object sender, EventArgs e) =>
            btnPointSave.Visible = (
                (double)nudX.Value != SelectedWaypoint.Position.X ||
                (double)nudY.Value != SelectedWaypoint.Position.Y ||
                (double)nudZ.Value != SelectedWaypoint.Position.Z ||
                chbFlag.Checked != SelectedWaypoint.flag);

        private void btnWaypointSave_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (i < 0) return;
            WaypointSave(SelectedWaypoint, i);
        }

        private void WaypointSave(ADWaypoint p, int i)
        {
            int idx = SelectedRoute.Waypoints.IndexOf(p);
            p.Edited = true;
            p.Position.X = (double)nudX.Value;
            p.Position.Y = (double)nudY.Value;
            p.Position.Z = (double)nudZ.Value;
            p.flag = chbFlag.Checked;
            p.PinState = p.flag ? 1 : 0;
            p.ListLine = p.GetListLine();
            clbWaypoints.Items[i] = p.ListLine;
            cbbLinkPoint.Items[idx] = p.ListLine;
            cbbMarkerWaypoint.Items[idx] = p.ListLine;
            btnPointSave.Visible = false;
            FormSHME.Main.IAC_Redraw();
        }

        private void btnWaypointAdd_Click(object sender, EventArgs e)
        {
            SelectedWaypoint = new ADWaypoint();
            SelectedWaypoint.id = SelectedRoute.newLineID++;
            SelectedRoute.Waypoints.Add(SelectedWaypoint);
            WaypointsShow.Add(SelectedWaypoint);
            WaypointsShown.Add(SelectedWaypoint);
            clbWaypoints.BeginUpdate();
            int i = clbWaypoints.Items.Add("-");
            cbbMarkerWaypoint.Items.Add("-");
            cbbLinkPoint.Items.Add("-");
            WaypointSave(SelectedWaypoint, i);
            clbWaypoints.EndUpdate();
            clbWaypoints.SelectedIndexChanged -= clbWaypoints_SelectedIndexChanged;
            clbWaypoints.SelectedIndex = i;
            clbWaypoints.SelectedIndexChanged += clbWaypoints_SelectedIndexChanged;
        }

        private void btnWaypointDelete_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (i < 0) return;
            int idx = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            SelectedRoute.Waypoints.Remove(SelectedWaypoint);
            WaypointsShow.Remove(SelectedWaypoint);
            WaypointsShown.Remove(SelectedWaypoint);
            clbWaypoints.Items.RemoveAt(i);
            // Remove from links
            cbbLinkPoint.Items.RemoveAt(idx);
            foreach (ADWaypoint p in SelectedRoute.Waypoints)
                p.Links.RemoveAll(l => (idx <= l.waypointID) ? (l.waypointID-- == idx) : false);
            // Remove from markers
            cbbMarkerWaypoint.Items.RemoveAt(idx);
            SelectedRoute.Markers.RemoveAll(l => (idx <= l.waypointIdx) ? (l.waypointIdx-- == idx) : false); // Decrement id in search loop
            FormSHME.Main.IAC_Redraw();
        }
        #endregion

        #region Links
        private void tvLinks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedLink = null;
            btnLinkSave.Visible
                = btnLinkDelete.Visible
                = false;
            int li = tvLinks.SelectedNode?.Index ?? -1;
            if (li < 0)
            {
                cbbLinkPoint.SelectedIndex = -1;
                chbLinkOut.Checked =
                chbLinkIn.Checked  = false;
                return;
            }
            SelectedLink = SelectedWaypoint.Links[li];
            cbbLinkPoint.SelectedIndex = SelectedLink.waypointID;
            chbLinkIn.Checked = 0 < (SelectedLink.direction & ADLinkIn);
            chbLinkOut.Checked = 0 < (SelectedLink.direction & ADLinkOut);
            btnLinkDelete.Visible = true;
        }

        private void cbbWaypointLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbLinkPoint.SelectedIndex;
            if (i < 0 || SelectedLink == null)
                return;
            btnLinkInsert.Visible = (SelectedWaypoint.Links.Find(l => (l.waypointID == i)) == null);
            btnLinkSave.Visible = btnLinkInsert.Visible && (i != SelectedLink.waypointID);
        }

        private void chbLinkInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbLinkIn.Checked && !chbLinkOut.Checked)
                if (sender == chbLinkIn) chbLinkOut.Checked = true;
                else chbLinkIn.Checked = true;
            cbbWaypointLink_SelectedIndexChanged(null, null);
        }

        private void btnLinkSave_Click(object sender, EventArgs e)
        {
            if (SelectedWaypoint == null) return;
            int linkID = tvLinks.SelectedNode.Index;
            if (linkID < 0) return;
            ADLink link = SelectedWaypoint.Links[linkID];
            tvLinks.BeginUpdate();
            int ThisPID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int ThatPIDNew = cbbLinkPoint.SelectedIndex;
            int ThatPIDLast = link.waypointID;
            byte direction = (byte)(
                (chbLinkIn.Checked ? ADLinkIn : 0) &
                (chbLinkOut.Checked ? ADLinkOut : 0));
            ADWaypoint ThatPLast = SelectedRoute.Waypoints[ThatPIDLast];
            ADLink ThatLLast = ThatPLast.Links.Find(l => (l.waypointID == ThisPID));
            // Move
            if (ThatPIDLast != ThatPIDNew)
            {
                ADWaypoint ThatPNew = SelectedRoute.Waypoints[ThatPIDNew];
                ADLink ThatLNew = ThatPNew.Links.Find(l => (l.waypointID == ThisPID));
                ThatPLast.Links.Remove(ThatLLast);
                // Look if already has
                if (ThatLNew != null)
                {
                    int ThisLIDNew = SelectedWaypoint.Links.FindIndex(l => (l.waypointID == ThatPIDNew));
                    direction |= SelectedWaypoint.Links[ThisLIDNew].direction; // Combine direction
                    SelectedWaypoint.Links.RemoveAt(ThisLIDNew);
                    tvLinks.Nodes.RemoveAt(ThisLIDNew);
                    if (ThisLIDNew < linkID) linkID--; // Index correction
                    ThatLLast = ThatLNew;
                }
                else
                    ThatPNew.Links.Add(ThatLLast);

                // Update far point of this link
                tvLinks.Nodes[linkID].Text = SelectedRoute.Waypoints[ThatPIDNew].id.ToString();
                link.waypointID = ThatPIDNew;
            }
            // Update link directions
            link.direction = direction;
            ThatLLast.direction = (byte)((direction << 1) | (direction >> 1) & 3); // Reverse
            tvLinks.Nodes[linkID].StateImageIndex = direction;
            SelectedWaypoint.Edited = true;
            tvLinks.EndUpdate();
            FormSHME.Main.IAC_Redraw();
        }

        private void btnLinkAdd_Click(object sender, EventArgs e)
        {
            if (SelectedWaypoint == null) return;
            byte direction = (byte)(
                (chbLinkIn.Checked ? ADLinkIn : 0) &
                (chbLinkOut.Checked ? ADLinkOut : 0));
            int ThisPID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int ThatPID = cbbLinkPoint.SelectedIndex;
            ADWaypoint ThisP = SelectedRoute.Waypoints[ThisPID];
            ADWaypoint ThatP = SelectedRoute.Waypoints[ThatPID];
            int ThisLID = ThisP.Links.FindIndex(l => (l.waypointID == ThatPID));
            ADLink ThisL, ThatL;
            if (ThisLID < 0)
            {
                ThisLID = ThisP.Links.Count;
                ThisP.Links.Add(ThisL = new ADLink(direction, ThatPID));
                ThatP.Links.Add(ThatL = new ADLink(0, ThisPID));
            }
            else
            {
                ThisL = ThisP.Links[ThisLID];
                direction = ThisL.direction |= direction;
                ThatL = ThatP.Links.Find(l => (l.waypointID == ThisPID));
            }
            ThatL.direction = (byte)((direction << 1) | (direction >> 1) & 3);
            tvLinks.Nodes[ThisLID].StateImageIndex = direction;
            FormSHME.Main.IAC_Redraw();
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)
        {
            if (SelectedWaypoint == null) return;
            int li = tvLinks.SelectedNode.Index;
            if (li < 0) return;
            int pThisID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int pFarID = SelectedWaypoint.Links[li].waypointID;
            SelectedRoute.Waypoints[pFarID].Links.RemoveAll(l => (l.waypointID == pThisID));
            SelectedWaypoint.Links.RemoveAt(li);
            tvLinks.Nodes.RemoveAt(li);
            SelectedRoute.Waypoints[pFarID].Edited = true;
            SelectedWaypoint.Edited = true;
            FormSHME.Main.IAC_Redraw();
        }
        #endregion

        #region Markers
        private void tvMarkers_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnMarkerSave.Visible = false;
            int markerIdx = tvMarkers.SelectedNode?.Index ?? -1;
            gbMarker.Enabled
                = btnMarkerDelete.Visible
                = (0 <= markerIdx);
            if (markerIdx < 0)
            {
                tbMarkerName.Text = "";
                cbbMarkerGroup.SelectedIndex = -1;
                cbbMarkerWaypoint.SelectedIndex = -1;
                return;
            }
            else
            {
                ADMarker marker = SelectedRoute.Markers[markerIdx];
                tbMarkerName.Text = marker.name;
                cbbMarkerGroup.SelectedIndex = marker.groupIdx;
                cbbMarkerWaypoint.SelectedIndex = marker.waypointIdx;
            }
            FormSHME.Main.IAC_Redraw();
        }

        private void Marker_ValueChanged(object sender, EventArgs e)
        {
            int markerIdx = tvMarkers.SelectedNode?.Index ?? -1;
            if (markerIdx < 0) return;
            ADMarker marker = SelectedRoute.Markers[markerIdx];
            btnMarkerSave.Visible = (
                tbMarkerName.Text != marker.name ||
                cbbMarkerGroup.SelectedIndex != marker.groupIdx ||
                cbbMarkerWaypoint.SelectedIndex != marker.waypointIdx);
        }

        private void tbMarkerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r' || !btnMarkerSave.Visible) return;
            btnMarkerSave_Click(null, null);
            e.Handled = true;
        }

        private void btnMarkerSave_Click(object sender, EventArgs e)
        {
            btnMarkerSave.Visible = false;
            int markerIdx = tvMarkers.SelectedNode?.Index ?? -1;
            if (markerIdx < 0) return;
            ADMarker marker = SelectedRoute.Markers[markerIdx];
            marker.name = tbMarkerName.Text;
            marker.groupIdx = cbbMarkerGroup.SelectedIndex;
            marker.groupName = SelectedRoute.Groups[marker.groupIdx].name;
            marker.waypointIdx = cbbMarkerWaypoint.SelectedIndex;
            tvMarkers.SelectedNode.Text
                = marker.ListLine
                = marker.GetLine();
            FormSHME.Main.IAC_Redraw();
        }

        private void btnMarkerDelete_Click(object sender, EventArgs e)
        {
            int markerIdx = tvMarkers.SelectedNode?.Index ?? -1;
            if (markerIdx < 0) return;
            tvMarkers.Nodes.RemoveAt(markerIdx);
            SelectedRoute.Markers.RemoveAt(markerIdx);
        }
        #endregion

        #region Groups
        private void tvGroups_AfterSelect(object sender, TreeViewEventArgs e) =>
            btnGroupDelete.Visible = (0 < tvGroups.SelectedNode?.Index);

        private void tvGroups_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e) =>
            e.Node.Text = SelectedRoute.Groups[e.Node.Index].name;

        private void tvGroups_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            int groupIdx = e.Node.Index;
            ADGroup group = SelectedRoute.Groups[groupIdx];
            group.name = e.Label ?? e.Node.Text;
            group.Edited = true;
            // Update UI
            cbbMarkerGroup.Items[groupIdx]
                = e.Node.Text
                = group.ListLine
                = group.GetLine();
            ADMarker marker;
            for (int markerIdx = SelectedRoute.Markers.Count - 1; 0 <= markerIdx; markerIdx--)
            {
                marker = SelectedRoute.Markers[markerIdx];
                if (groupIdx == marker.groupIdx)
                {
                    marker.groupName = group.name;
                    tvMarkers.Nodes[markerIdx].Text
                        = marker.ListLine
                        = marker.GetLine();
                }
            }
        }

        private void btnPointsSetChecks_Click   (object sender, EventArgs e) => UIBasics.CheckedListBox_SetChecks   (clbWaypoints, (sender == btnPointsCheckAll));
        private void btnPointsInvertChecks_Click(object sender, EventArgs e) => UIBasics.CheckedListBox_InvertChecks(clbWaypoints);

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            tvMarkers.BeginUpdate();
            int groupIdx = tvGroups.SelectedNode.Index;
            String group0Name = SelectedRoute.Groups[0].name;
            // Update markers
            for (int markerIdx = SelectedRoute.Markers.Count - 1; 0 <= markerIdx; markerIdx--)
            {
                ADMarker marker = SelectedRoute.Markers[markerIdx];
                // Decrease index
                if (marker.groupIdx > groupIdx)
                    marker.groupIdx--;
                // Replace with first one in list
                else if (marker.groupIdx == groupIdx)
                {
                    marker.groupIdx = 0;
                    marker.groupName = group0Name;
                    tvMarkers.Nodes[markerIdx].Text
                        = marker.ListLine
                        = marker.GetLine();
                }
            }
            // Remove all entries
            SelectedRoute.Groups.RemoveAt(groupIdx);
            cbbMarkerGroup.Items.RemoveAt(groupIdx);
            tvGroups.Nodes.RemoveAt(groupIdx);
            tvMarkers.EndUpdate();
            // Update if shown
            if (tvMarkers.SelectedNode != null)
                cbbMarkerGroup.SelectedIndex = SelectedRoute.Markers[tvMarkers.SelectedNode.Index].groupIdx;
        }
        #endregion

        public void treeView_KeyPress(object sender, KeyPressEventArgs e) => UIBasics.TreeView_KeyPressBeginEdit(sender, e);
    }
}