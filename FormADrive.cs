using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormADrive : Form
    {
        private const String IniFileName = "ADrive.ini";
        private const String FloatFormat = "f2";

        public static FSPins Pins = new FSPins(7, 7, 3, 3,
            new int[][]{
                // Normal
                new int[] {
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x7F00A000, 0x7F00A000, 0x7F00A000, 0x00000000, 0x00000000,
                    0x00000000, 0x7F00A000, 0x7F004000, 0x7F004000, 0x7F004000, 0x7F00A000, 0x00000000,
                    0x00000000, 0x7F00A000, 0x7F004000, 0x7F004000, 0x7F004000, 0x7F00A000, 0x00000000,
                    0x00000000, 0x7F00A000, 0x7F004000, 0x7F004000, 0x7F004000, 0x7F00A000, 0x00000000,
                    0x00000000, 0x00000000, 0x7F00A000, 0x7F00A000, 0x7F00A000, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000},
                // Flaged
                new int[] {
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x7FEEEE00, 0x7FEEEE00, 0x7FEEEE00, 0x00000000, 0x00000000,
                    0x00000000, 0x7FEEEE00, 0x7F6E6E00, 0x7F6E6E00, 0x7F6E6E00, 0x7FEEEE00, 0x00000000,
                    0x00000000, 0x7FEEEE00, 0x7F6E6E00, 0x7F6E6E00, 0x7F6E6E00, 0x7FEEEE00, 0x00000000,
                    0x00000000, 0x7FEEEE00, 0x7F6E6E00, 0x7F6E6E00, 0x7F6E6E00, 0x7FEEEE00, 0x00000000,
                    0x00000000, 0x00000000, 0x7FEEEE00, 0x7FEEEE00, 0x7FEEEE00, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000}
            },
            // Selection
            new int[] {
                0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF,
                0x7F000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F000000,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7F000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F000000,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7F000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F000000,
                0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF, 0x7F000000, 0x7FFFFFFF},
            // Checking
            new int[] {
                0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F},
            new int[]{
                0x7F00C0F0,
                0x7F00C000,
                0x7F0000FF,
                0x7F00C000,
                0x7F00C0F0}
            );

        public class ADLink
        {
            public static int OutgoingBack = 0,
                              Outgoing = 1,
                              Bothway = 2,
                              Incoming = 3,
                              IncomingBack = 4;
            public int waypointID;
            public int direction;

            public ADLink(int setDirection, int setWaypointID)
            {
                direction = setDirection;
                waypointID = setWaypointID;
            }

            public static int ReverseDirection(int direction) => 4 - direction;

            public static int BuildDirection(bool In, bool Out, bool Back) =>
                (In && !Out) ? (Back) ? IncomingBack : Incoming :
                (!In && Out) ? (Back) ? OutgoingBack : Outgoing :
                Bothway;

            public static int CombineDirections(int a, int b) =>
                (a < Incoming && b > Outgoing) || (a > Outgoing && b < Incoming)
                    ? Bothway
                    : (a + b < Bothway)
                        ? Outgoing
                        : Incoming;

            public int CombineDirections(int otherDirection) =>
                (direction < Incoming && otherDirection > Outgoing) || (direction > Outgoing && otherDirection < Incoming)
                    ? Bothway
                    : (direction + otherDirection < Bothway)
                        ? Outgoing
                        : Incoming;

            public String GetLine() => "#" + waypointID;
        }

        public class ADWaypoint : FSObject
        {
            public bool flag = false;
            public List<ADLink> Links = new List<ADLink>();
            public int id = 1;

            public ADWaypoint() => Position = new XYZRDouble();

            override public String BuildListLine() =>
                "#" + id + " " +
                  Position.X.ToString(FloatFormat, ReadValue.FloatPoint) + ", " +
                  Position.Y.ToString(FloatFormat, ReadValue.FloatPoint) + ", " +
                  Position.Z.ToString(FloatFormat, ReadValue.FloatPoint) + ", " +
                  flag;
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
                if (set) XMLLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "n", out name, out tmp);
                if (0 < ReadValue.TagsAttribute(line, "i", out line, out tmp)) int.TryParse(line, out order);
            }

            public String BuildListLine() => "#" + order + " " + name;

            public String GetXMLLine() => (Edited)
                ? XMLLine = "        <g n=\"" + name +
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
                if (set) XMLLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "n", out name, out tmp);
                ReadValue.TagsAttribute(line, "g", out groupName, out tmp);
                if (ReadValue.TagsAttribute(line, "i", out waypoint, out tmp) < 1) waypoint = "1";
                int.TryParse(waypoint, out waypointIdx);
                waypointIdx--;
            }

            public String BuildListLine() => "#" + waypointIdx + " " + name + " <" + groupName + ">";

            public String GetXMLLine() => (Edited)
                ? XMLLine = "        <m i=\"" + (waypointIdx + 1) +
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
            public String otherLines = "";
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
                if (set) XMLLine = line;

                int tmp;
                ReadValue.TagsAttribute(line, "name", out name, out tmp);
                ReadValue.TagsAttribute(line, "fileName", out fileName, out tmp);
                ReadValue.TagsAttribute(line, "map", out map, out tmp);
                ReadValue.TagsAttribute(line, "revision", out revision, out tmp);
                ReadValue.TagsAttribute(line, "date", out date, out tmp);
            }

            public String GetXMLLine() => ((InfoEdited)
                ? XMLLine = "        <route name=\"" + name +
                    "\" fileName=\"" + fileName +
                    "\" map=\"" + map +
                    "\" revision=\"" + revision +
                    "\" date=\"" + date +
                    "\">"
                : XMLLine);

            public String GetXMLLines() => GetXMLLine() + "\r\n" + otherLines + "\r\n        </route>";
        }

        private bool postpondListing = false;
        private bool lockFilter = true, lockComparing = true, lockSwitch = true;
        private String ManagerFileName = "", RouteFilesPath = "";
        private List<ADRoute> Routes = new List<ADRoute> { };
        private int linkDirection = 0;
        private RadioButton[] LinkDirectionRBs;
        // Visible outside
        private List<ADWaypoint> WaypointsShow  = new List<ADWaypoint> { };
        public  List<ADWaypoint> WaypointsShown = new List<ADWaypoint> { };
        public ADRoute    SelectedRoute    = null;
        public ADWaypoint SelectedWaypoint = null;
        public ADLink     SelectedLink     = null;

        #region Form
        public FormADrive()//Ok
        {
            InitializeComponent();
            LinkDirectionRBs = new RadioButton[]{ rbLinkDirectionOutB, rbLinkDirectionOut, rbLinkDirectionBoth, rbLinkDirectionIn, rbLinkDirectionInB };
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
                                case "PositionStep"  : ReadValue.NUDDouble(nudPositionStep,   value); break;
                                case "PositionOffset": ReadValue.NUDDouble(nudPositionOffset, value); break;
                                case "LimitXMin"     : ReadValue.NUDDouble(nudLimitXMin,      value); break;
                                case "LimitXMax"     : ReadValue.NUDDouble(nudLimitXMax,      value); break;
                                case "LimitYMin"     : ReadValue.NUDDouble(nudLimitYMin,      value); break;
                                case "LimitYMax"     : ReadValue.NUDDouble(nudLimitYMax,      value); break;
                                case "LimitZMin"     : ReadValue.NUDDouble(nudLimitZMin,      value); break;
                                case "LimitZMax"     : ReadValue.NUDDouble(nudLimitZMax,      value); break;
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
                    file.WriteLine("PositionStep\t" + nudPositionStep.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitXMin\t" + nudLimitXMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitXMax\t" + nudLimitXMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitYMin\t" + nudLimitYMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitYMax\t" + nudLimitYMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitZMin\t" + nudLimitZMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("LimitZMax\t" + nudLimitZMax.Value.ToString(ReadValue.FloatPoint));
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
                List<String> otherLines = new List<String>();
                TreeNode routeNode, selectRouteNode = null;
                Routes.Clear();
                tvRoutes.BeginUpdate();
                tvRoutes.Nodes.Clear();
                // Load info
                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        XMLLine = file.ReadLine();
                        if (!XMLLine.Contains("<route ")) continue;
                        // Add route record
                        Routes.Add(route = new ADRoute(XMLLine));
                        while (!file.EndOfStream)
                        {
                            XMLLine = file.ReadLine();
                            if (XMLLine.Contains("</route>")) break;
                            otherLines.Add(XMLLine);
                        }
                        route.otherLines = String.Join("\r\n", otherLines);
                        otherLines.Clear();
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
            SelectedRoute.InfoEdited = true;
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
                        file.WriteLine(r.GetXMLLines());
                        r.InfoEdited = false;
                    }
                    file.WriteLine("    </routes>\r\n</autoDriveRoutesManager>");
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
            int c = s.Length;
            double[] v = new double[c];
            for (int i = 0; i < c; i++)
                Double.TryParse(s[i], NumberStyles.Float, ReadValue.FloatPoint, out v[i]);
            return v;
        }

        private int[] BreakLine_Integer(String line, char spliter)
        {
            String[] s = line.Split(spliter);
            int c = s.Length;
            int[] v = new int[c];
            for (int i = 0; i < c; i++)
                int.TryParse(s[i], out v[i]);
            return v;
        }

        private void btnRouteReload_Click(object sender, EventArgs e)
        {
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
                String[] flag  = new String[0],
                         iIDsS = new String[0],
                         oIDsS = new String[0];
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
                            case "x": x = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "y": y = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "z": z = BreakLine_Float(ExtractTagContent(s),      ';'); break;
                            case "flags":          flag = ExtractTagContent(s).Split(';'); break;
                            case "in":            iIDsS = ExtractTagContent(s).Split(';'); break;
                            case "out":           oIDsS = ExtractTagContent(s).Split(';'); break;
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
                     Math.Max(iIDsS.Length,
                     Math.Max(oIDsS.Length,
                     Math.Max(x.Length,
                     Math.Max(y.Length,
                     Math.Max(z.Length,
                              flag.Length)))));
                int[] iIDs, oIDs;
                IEnumerable<int> IDBD;
                for (int i = 0; i < SelectedRoute.newLineID; i++)
                {
                    SelectedRoute.Waypoints.Add(p = new ADWaypoint());
                    p.id = i + 1;
                    if (i < x.Length) p.Position.X = x[i];
                    if (i < y.Length) p.Position.Y = y[i];
                    if (i < z.Length) p.Position.Z = z[i];
                    if (i < flag.Length) p.flag = (flag[i] == "1");
                    p.PinState = p.flag ? 1 : 0;
                    iIDs = new int[0];    if (i < iIDsS.Length)    if (iIDsS[i] != "-1") iIDs = BreakLine_Integer(iIDsS[i], ',');
                    oIDs = new int[0];    if (i < oIDsS.Length)    if (oIDsS[i] != "-1") oIDs = BreakLine_Integer(oIDsS[i], ',');
                    IDBD = iIDs.Intersect(oIDs);
                    foreach (int ID in             IDBD ) p.Links.Add(new ADLink(ADLink.Bothway,  ID - 1));
                    foreach (int ID in iIDs.Except(IDBD)) p.Links.Add(new ADLink(ADLink.Incoming, ID - 1)); // No IncomingBack
                    foreach (int ID in oIDs.Except(IDBD)) p.Links.Add(new ADLink(ADLink.Outgoing, ID - 1)); // Or OutgoingBack
                    p.ListLine = p.BuildListLine();
                }
                // Mark IncomingBack/OutgoingBack
                for (int pi = SelectedRoute.Waypoints.Count - 1; 0 <= pi; pi--)
                {
                    p = SelectedRoute.Waypoints[pi];
                    for (int li = p.Links.Count - 1; 0 <= li; li--)
                    {
                        ADLink l = p.Links[li];
                        ADWaypoint pFar = SelectedRoute.Waypoints[l.waypointID];
                        if (pFar.Links.FindIndex(link => (link.waypointID == pi)) < 0) // If not found record in far waypoint
                        {
                            l.direction = ADLink.OutgoingBack;                   // Mark own as OutgoingBack
                            pFar.Links.Add(new ADLink(ADLink.IncomingBack, pi)); // Add IncomingBack to far waypoint
                        }
                    }
                }
                // Sort and add groups
                SelectedRoute.Groups.Sort((a, b) => (a.order < b.order) ? -1 : (a.order > b.order) ? 1 : 0);
                foreach (ADGroup group in SelectedRoute.Groups)
                    group.ListLine = group.BuildListLine();
                SelectedRoute.newGroupID = SelectedRoute.Groups.Count + 1;
                // Add markers
                foreach (ADMarker marker in SelectedRoute.Markers)
                {
                    marker.ListLine = marker.BuildListLine();
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
                tvMarkers.SelectedNode =
                tvGroups.SelectedNode = null;
                clbWaypoints.SelectedIndex = -1;
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
            {
                ADWaypoint p;
                int n = SelectedRoute.Waypoints.Count;
                for (int i = 0; i < n; i++)
                {
                    p = SelectedRoute.Waypoints[i];
                    p.Show = false;
                    if (limitX) if (p.Position.X < minX || maxX < p.Position.X) continue;
                    if (limitY) if (p.Position.Y < minY || maxY < p.Position.Y) continue;
                    if (limitZ) if (p.Position.Z < minZ || maxZ < p.Position.Z) continue;
                    // Allowed
                    WaypointsShow.Add(p);
                    p.Show = true;
                }
            }
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void cbListVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (lockFilter) return;
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void tListTimeout_Tick(object sender, EventArgs e)
        {
            if (postpondListing) ListItems();
            postpondListing = false;
            tListTimeout.Enabled = false;
        }

        public void Relist(bool force = false)
        {
            if (lockFilter) return;
            if (SelectedRoute != null) FormSHME.Main.ProjectObjects(SelectedRoute.Waypoints);
            if (cbListVisible.Checked || force) // Skip if wasn't checked in first place
            {
                WaypointsShown = (cbListVisible.Checked)
                    ? FormSHME.Main.CheckObjectsVisibility(WaypointsShow, Pins).Cast<ADWaypoint>().ToList()
                    : WaypointsShow;
                // List or postpond
                if (tListTimeout.Enabled)
                    postpondListing = true;
                else
                    ListItems();
                tListTimeout.Enabled = true; // Set timeout
            }
        }

        public void ListItems()
        {
            lockSwitch = true;
            clbWaypoints.SelectedIndex = -1;
            clbWaypoints.BeginUpdate();
            clbWaypoints.Items.Clear();
            if (SelectedRoute != null)
            {
                // Uncheck unvisible
                foreach (ADWaypoint waypoint in SelectedRoute.Waypoints)
                    waypoint.Checked &= waypoint.Shown;
                // Fit
                int n = WaypointsShown.Count;
                for (int li = 0; li < n; li++)
                {
                    clbWaypoints.Items.Add(WaypointsShown[li].ListLine, WaypointsShown[li].Checked);
                    if (WaypointsShown[li].Selected)
                        clbWaypoints.SelectedIndex = li;
                }
            }
            lockSwitch = false;
            clbWaypoints.EndUpdate();
            clbWaypoints_SelectedIndexChanged(null, null);
        }

        public void TryToSelectItemAt(double x, double y, int zoom)
        {
            int n = WaypointsShown.Count;
            if (n < 1) return;
            double magnitude = 2 / (double)(1 << zoom);
            double l = x - (Pins.CenterX * magnitude), r = l + (Pins.Width  * magnitude),
                   t = y - (Pins.CenterY * magnitude), b = t + (Pins.Height * magnitude);
            int s = clbWaypoints.SelectedIndex < 0 ? 0 : clbWaypoints.SelectedIndex;
            int i = s;
            XYZRDouble xyzr;
            do
            {
                i++;
                if (n <= i) i = 0; // Loop to beginning
                if ((xyzr = WaypointsShown[i].Position) != null)
                    if (l <= xyzr.X && xyzr.X < r &&
                        t <= xyzr.Z && xyzr.Z < b)
                    {
                        clbWaypoints.SelectedIndex = (clbWaypoints.SelectedIndex == i) ? -1 : i;
                        return;
                    }
            } while (i != s);
        }

        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lockSwitch) return;
            if (SelectedWaypoint != null) SelectedWaypoint.Selected = false;
            tvLinks.Nodes.Clear();
            btnPointSave.Visible = false;
            tvLinks.SelectedNode = null;
            tvLinks_AfterSelect(null, null);
            lockComparing = true;
            if (clbWaypoints.SelectedIndex < 0)
            {
                gbWaypoint.Enabled = false;
                SelectedWaypoint = null;
                nudX.Value = 0;
                nudY.Value = 0;
                nudZ.Value = 0;
                chbFlag.Checked = false;
                return;
            }
            SelectedWaypoint = WaypointsShown[clbWaypoints.SelectedIndex];
            if (!SelectedWaypoint.Selected)
            {
                nudX.Value = (decimal)SelectedWaypoint.Position.X;
                nudY.Value = (decimal)SelectedWaypoint.Position.Y;
                nudZ.Value = (decimal)SelectedWaypoint.Position.Z;
                chbFlag.Checked = SelectedWaypoint.flag;
                SelectedWaypoint.Selected = true;
                TreeNode tn;
                tvLinks.BeginUpdate();
                foreach (ADLink l in SelectedWaypoint.Links)
                {
                    tvLinks.Nodes.Add(tn = new TreeNode(SelectedRoute.Waypoints[l.waypointID].ListLine));
                    tn.StateImageIndex = l.direction;
                }
                tvLinks.EndUpdate();
                gbWaypoint.Enabled = true;
            }
            lockComparing = false;
            FormSHME.Main.IAC_Redraw();
        }

        private void clbWaypoints_MouseClick(object sender, MouseEventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (0 <= i)
            {
                bool newChecked = clbWaypoints.GetItemChecked(i);
                if (20 < e.X) clbWaypoints.SetItemChecked(i, !(WaypointsShown[i].Checked =  newChecked));
                else                                           WaypointsShown[i].Checked = !newChecked;
                FormSHME.Main.IAC_Redraw();
            }
        }

        private void Limit_ValueChanged(object sender, EventArgs e)
        {
            if (cbLimitX.Checked || cbLimitX.Checked || cbLimitZ.Checked)
                FilterWaypoints();
        }

        private void btnPointsSetChecks_Click(object sender, EventArgs e)
        {
            bool newChecked = (sender == btnPointsCheckAll);
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, WaypointsShown[i].Checked = newChecked);
            FormSHME.Main.IAC_Redraw();
        }

        private void btnPointsInvertChecks_Click(object sender, EventArgs e)
        {
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, WaypointsShown[i].Checked = !clbWaypoints.GetItemChecked(i));
            FormSHME.Main.IAC_Redraw();
        }

        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            if (clbWaypoints.CheckedIndices.Count < 1) return;
            Double step = (Double)nudPositionStep.Value;
            Double offset = (Double)nudPositionOffset.Value;
            clbWaypoints.BeginUpdate();
            ADWaypoint waypoint;
            for (int i = clbWaypoints.CheckedIndices.Count - 1; 0 <= i; i--)
            {
                waypoint = WaypointsShow[clbWaypoints.CheckedIndices[i]];
                if (waypoint.Position.Align(step, offset, true, false, true))
                {
                    waypoint.Edited = true;
                    waypoint.GetListLine();
                }
            }
            // Finish
            clbWaypoints.EndUpdate();
            FilterWaypoints();
        }

        private void btnWaypointsDeleteSelected_Click(object sender, EventArgs e)
        {
            clbWaypoints.SelectedIndex = -1;
            clbWaypoints.BeginUpdate();
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                if (clbWaypoints.GetItemChecked(i))
                    RemoveWaypoint(WaypointsShown[i]);
            clbWaypoints.EndUpdate();
            FormSHME.Main.IAC_Redraw();
        }

        private void btnRouteSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = File.CreateText(RouteFilesPath + "\\routes\\" + SelectedRoute.fileName))
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
                    sX = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.X.ToString(FloatFormat, ReadValue.FloatPoint)));
                    sY = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.Y.ToString(FloatFormat, ReadValue.FloatPoint)));
                    sZ = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.Position.Z.ToString(FloatFormat, ReadValue.FloatPoint)));
                    sF = String.Join(";", SelectedRoute.Waypoints.ConvertAll((ADWaypoint wp) => wp.flag ? "1" : "0"));
                    for (int i = 0; i < n; i++)
                    {
                        p = SelectedRoute.Waypoints[i];
                        sO = String.Join(",", p.Links.Where(l => (l.direction <= ADLink.Bothway                                  )).ToList().ConvertAll(l => (l.waypointID + 1).ToString()));
                        sI = String.Join(",", p.Links.Where(l => (l.direction == ADLink.Bothway || l.direction == ADLink.Incoming)).ToList().ConvertAll(l => (l.waypointID + 1).ToString()));
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
                    file.Write("    </waypoints>\r\n    <markers>"); for (int i = SelectedRoute.Markers.Count - 1; 0 <= i; i--) file.WriteLine(SelectedRoute.Markers[i].GetXMLLine());
                    file.Write("    </markers>\r\n    <groups>");    for (int i = SelectedRoute.Groups. Count - 1; 0 <= i; i--) file.WriteLine(SelectedRoute. Groups[i].GetXMLLine());
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
        private void WaypointInfo_Changed(object sender, EventArgs e)
        {
            if (lockComparing) return;
            btnPointSave.Visible = (
                (double)nudX.Value != SelectedWaypoint.Position.X ||
                (double)nudY.Value != SelectedWaypoint.Position.Y ||
                (double)nudZ.Value != SelectedWaypoint.Position.Z ||
                chbFlag.Checked != SelectedWaypoint.flag);
        }

        private void btnWaypointSave_Click(object sender, EventArgs e) => WaypointSave(clbWaypoints.SelectedIndex);

        private void WaypointSave(int i)
        {
            int idx = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            SelectedWaypoint.Position.X = (double)nudX.Value;
            SelectedWaypoint.Position.Y = (double)nudY.Value;
            SelectedWaypoint.Position.Z = (double)nudZ.Value;
            SelectedWaypoint.PinState = (SelectedWaypoint.flag = chbFlag.Checked) ? 1 : 0;
            SelectedWaypoint.Edited = true;
            clbWaypoints.Items[i]
                = cbbLinkPoint.Items[idx]
                = cbbMarkerWaypoint.Items[idx]
                = SelectedWaypoint.GetListLine();
            btnPointSave.Visible = false;
            FormSHME.Main.ProjectObject(SelectedWaypoint);
            FormSHME.Main.IAC_Redraw();
        }

        private void btnWaypointAdd_Click(object sender, EventArgs e)
        {
            SelectedWaypoint = new ADWaypoint();
            SelectedWaypoint.id = SelectedRoute.newLineID++;
            SelectedRoute.Waypoints.Add(SelectedWaypoint);
            WaypointsShown.Add(SelectedWaypoint);
            WaypointsShow.Add(SelectedWaypoint);
            clbWaypoints.BeginUpdate();
            int i = clbWaypoints.Items.Add("-");
            cbbMarkerWaypoint.Items.Add("-");
            cbbLinkPoint.Items.Add("-");
            WaypointSave(i);
            clbWaypoints.EndUpdate();
            clbWaypoints.SelectedIndexChanged -= clbWaypoints_SelectedIndexChanged;
            clbWaypoints.SelectedIndex = i;
            clbWaypoints.SelectedIndexChanged += clbWaypoints_SelectedIndexChanged;
        }

        private void btnWaypointDelete_Click(object sender, EventArgs e)
        {
            if (clbWaypoints.SelectedIndex < 0) return;
            RemoveWaypoint(SelectedWaypoint);
            SelectedWaypoint = null;
            clbWaypoints.SelectedIndex = -1;
            FormSHME.Main.IAC_Redraw();
        }

        private void RemoveWaypoint(ADWaypoint waypoint)
        {
            int id = SelectedRoute.Waypoints.IndexOf(waypoint);
            if (id < 0) return;
            // Remove from lists
            clbWaypoints.Items.RemoveAt(WaypointsShown.IndexOf(waypoint));
            SelectedRoute.Waypoints.Remove(waypoint);
            WaypointsShown.Remove(waypoint);
            WaypointsShow.Remove(waypoint);
            // Remove from links
            cbbLinkPoint.Items.RemoveAt(id);
            for (int i = SelectedRoute.Waypoints.Count - 1; 0 <= i; i--)
                SelectedRoute.Waypoints[i].Links.RemoveAll(l => (id <= l.waypointID) ? (l.waypointID-- == id) : false); // Remove links and decrement higer points IDs in search loop
            // Remove from markers
            cbbMarkerWaypoint.Items.RemoveAt(id);
            SelectedRoute.Markers.RemoveAll(l => (id <= l.waypointIdx) ? (l.waypointIdx-- == id) : false); // Remove markers and decrement higer points IDs in search loop
        }
        #endregion

        #region Links
        private void tvLinks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedLink = null;
            btnLinkAdd.Visible =
            btnLinkSave.Visible = false;
            int li = tvLinks.SelectedNode?.Index ?? -1;
            if (li < 0)
            {
                cbbLinkPoint.SelectedIndex = -1;
                btnLinkDelete.Visible =
                btnLinkSplit .Visible = false;
                linkDirection = ADLink.Bothway;
                LinkDirectionRBs[linkDirection].Checked = true;
                return;
            }
            ADLink link = SelectedWaypoint.Links[li];
            cbbLinkPoint.SelectedIndex = link.waypointID;
            LinkDirectionRBs[linkDirection = link.direction].Checked = true;
            SelectedLink = link;
            btnLinkSplit.Visible =
            btnLinkDelete.Visible = true;
        }

        private void cbbWaypointLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = cbbLinkPoint.SelectedIndex;
            if (id < 0)
            {
                btnLinkAdd.Visible =
                btnLinkSave.Visible = false;
                return;
            }
            btnLinkAdd.Visible = (SelectedWaypoint.Links.Find(l => (l.waypointID == id)) == null) && (id != SelectedRoute.Waypoints.IndexOf(SelectedWaypoint));
            if (SelectedLink != null)
                btnLinkSave.Visible = ((btnLinkAdd.Visible && (id != SelectedLink.waypointID)) || (linkDirection != SelectedLink.direction));
        }

        private void rbLinkDirection_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectedLink == null) return;
            if ((sender as RadioButton).Checked)
            {
                linkDirection = (int)((sender as RadioButton).Tag);
                cbbWaypointLink_SelectedIndexChanged(null, null);
            }
        }

        private void btnLinkSave_Click(object sender, EventArgs e)
        {
            if (SelectedWaypoint == null) return;
            int linkID = tvLinks.SelectedNode.Index;
            if (linkID < 0) return;
            int ThisPID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int ThatPIDNew = cbbLinkPoint.SelectedIndex;
            int ThatPIDLast = SelectedLink.waypointID;
            int direction = linkDirection;
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
                    direction = SelectedWaypoint.Links[ThisLIDNew].CombineDirections(direction); // Combine direction
                    SelectedWaypoint.Links.RemoveAt(ThisLIDNew);
                    if (ThisLIDNew < linkID) linkID--; // Index correction
                    ThatLLast = ThatLNew;
                }
                else
                    ThatPNew.Links.Add(ThatLLast);
                // Update far point of this link
                SelectedLink.waypointID = ThatPIDNew;
            }
            // Update link directions
            SelectedLink.direction = direction;
            ThatLLast.direction = ADLink.ReverseDirection(direction); // Reverse
            tvLinks.Nodes[linkID].StateImageIndex = direction;
            LinkDirectionRBs[direction].Checked = true;
            SelectedWaypoint.Edited = true;
            btnLinkAdd.Visible =
            btnLinkSave.Visible = false;
            FormSHME.Main.IAC_Redraw();
        }

        private void btnLinkAdd_Click(object sender, EventArgs e)
        {
            if (SelectedWaypoint == null) return;
            int direction = linkDirection;
            int ThisPID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int ThatPID = cbbLinkPoint.SelectedIndex;
            ADWaypoint ThatP = SelectedRoute.Waypoints[ThatPID];
            int ThisLID = SelectedWaypoint.Links.FindIndex(l => (l.waypointID == ThatPID));
            ADLink ThisL, ThatL;
            if (ThisLID < 0)
            {
                ThisLID = SelectedWaypoint.Links.Count;
                SelectedWaypoint.Links.Add(ThisL = new ADLink(                        direction,  ThatPID));
                           ThatP.Links.Add(ThatL = new ADLink(ADLink.ReverseDirection(direction), ThisPID));
                tvLinks.Nodes.Add(ThatP.ListLine);
            }
            else
            {
                ThisL = SelectedWaypoint.Links[ThisLID];
                direction = ThisL.direction = ThisL.CombineDirections(direction);
                ThatL = ThatP.Links.Find(l => (l.waypointID == ThisPID));
                ThatL.direction = ADLink.ReverseDirection(direction);
            }
            tvLinks.Nodes[ThisLID].StateImageIndex = direction;
            btnLinkAdd.Visible =
            btnLinkSave.Visible = false;
            FormSHME.Main.IAC_Redraw();
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)
        {
            int li = tvLinks.SelectedNode.Index;
            int pThisID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int pFarID = SelectedLink.waypointID;
            SelectedRoute.Waypoints[pFarID].Links.RemoveAll(l => (l.waypointID == pThisID));
            SelectedWaypoint.Links.RemoveAt(li);
            tvLinks.Nodes.RemoveAt(li);
            SelectedRoute.Waypoints[pFarID].Edited = true;
            SelectedWaypoint.Edited = true;
            if (tvLinks.Nodes.Count == 0) tvLinks_AfterSelect(null, null);
            FormSHME.Main.IAC_Redraw();
        }

        private void btnLinkSplit_Click(object sender, EventArgs e)//O
        {
            int pThisID = SelectedRoute.Waypoints.IndexOf(SelectedWaypoint);
            int pFarID = SelectedLink.waypointID;
            ADWaypoint waypointFar = SelectedRoute.Waypoints[pFarID];
            // Add waypoint
            int pNewID = SelectedRoute.Waypoints.Count;
            ADWaypoint waypoint = new ADWaypoint();
            SelectedRoute.Waypoints.Add(waypoint);
            WaypointsShown.Add(waypoint);
            WaypointsShow.Add(waypoint);
            waypoint.id = SelectedRoute.newLineID++;
            waypoint.Position.X = (SelectedWaypoint.Position.X + waypointFar.Position.X) / 2;
            waypoint.Position.Y = (SelectedWaypoint.Position.Y + waypointFar.Position.Y) / 2;
            waypoint.Position.Z = (SelectedWaypoint.Position.Z + waypointFar.Position.Z) / 2;
            waypoint.Position.R = (SelectedWaypoint.Position.R + waypointFar.Position.R) / 2;
            waypoint.Links.Add(new ADLink(                        SelectedLink.direction,  pFarID ));
            waypoint.Links.Add(new ADLink(ADLink.ReverseDirection(SelectedLink.direction), pThisID));
            waypoint.Edited =
            waypoint.Shown =
            waypoint.Show = true;
            // Interconnect old ones
            waypointFar.Links.Find(l => (l.waypointID == pThisID)).waypointID = pNewID;
            waypointFar.Edited = true;
            SelectedLink.waypointID = pNewID;
            SelectedWaypoint.Edited = true;
            // Update UI
            tvLinks.SelectedNode.StateImageIndex = SelectedLink.direction;
            tvLinks.SelectedNode.Text =
            waypoint.ListLine = waypoint.BuildListLine();
            clbWaypoints.Items.Add(waypoint.ListLine);
            cbbLinkPoint.Items.Add(waypoint.ListLine);
            cbbMarkerWaypoint.Items.Add(waypoint.ListLine);
            cbbLinkPoint.SelectedIndex = pNewID;
            FormSHME.Main.ProjectObject(waypoint);
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
                = marker.BuildListLine();
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
                = group.BuildListLine();
            ADMarker marker;
            for (int markerIdx = SelectedRoute.Markers.Count - 1; 0 <= markerIdx; markerIdx--)
            {
                marker = SelectedRoute.Markers[markerIdx];
                if (groupIdx == marker.groupIdx)
                {
                    marker.groupName = group.name;
                    tvMarkers.Nodes[markerIdx].Text
                        = marker.ListLine
                        = marker.BuildListLine();
                }
            }
        }

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
                        = marker.BuildListLine();
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