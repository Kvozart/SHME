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
        public static readonly int[][] pinStates = { pinWork, pinEngage, pinStop };
        public static readonly Pen pinConection = new Pen(Color.LightGray);

        private const String FloatFormat = "f2";
        private const String IniFileName = "CPlay.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class CPWaypoint
        {
            public double x, y, z, r;
            public int f05 = 0;
            public int Action = 0; // {" " "E"ngage "S"top}
            public bool f07 = false, f08 = false, f09 = false, f10 = false;
            public String f11 = "";
            public int f12 = 0;
            public String f13 = "";
            public bool f14 = false;
            // Own
            public String XMLLine = "", Line = "";
            public bool Edited = false, Show, Shown;
            public int canvasX, canvasY;

            public CPWaypoint(String line) => ReadXMLLine(line, true);

            public bool ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                string[] v = line.Replace("  ", " ").Replace(',', '.').Split(';');
                if (v.Length < 12) return false;

                string[] p = v[0].Split(' ');
                if (p.Length < 3) return false;
                Double.TryParse(p[0], NumberStyles.Float, NFI, out x);
                Double.TryParse(p[1], NumberStyles.Float, NFI, out y);
                Double.TryParse(p[2], NumberStyles.Float, NFI, out z);
                Double.TryParse(v[1], NumberStyles.Float, NFI, out r);
                int.TryParse(v[2], out f05);
                Action = (v[3] == "E") ? 1
                       : (v[3] == "S") ? 2 : 0;
                f07 = (v[4][0] == 'Y');
                f08 = (v[5][0] == 'Y');
                f09 = (v[6][0] == 'Y');
                f10 = (v[7][0] == 'Y');
                f11 = v[8];
                if (v[9] == "") f12 = -1; else int.TryParse(v[9], out f12);
                f13 = v[10];
                f14 = (v[11][0] == 'Y');
                return true;
            }

            public bool Align(double step, double offset, Boolean doRotation)
            {
                if (step == 0 && offset == 0) return false;
                double ix =x, iz = z, ir = r;
                if (doRotation)
                    r = Math.Round((r - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
                return ix != x || iz != z || ir != r;
            }

            public String GetXMLLine() => (Edited)
                ? x.ToString(FloatFormat, NFI) + " " +
                  y.ToString(FloatFormat, NFI) + " " +
                  z.ToString(FloatFormat, NFI) + ";" +
                  r.ToString(FloatFormat, NFI) + ";" +
                  f05.ToString() + ";" +
                  (Action == 0 ? "" : "-ES"[Action].ToString()) + ";" +
                  (f07 ? "Y" : "N") + ";" +
                  (f08 ? "Y" : "N") + ";" +
                  (f09 ? "Y" : "N") + ";" +
                  (f10 ? "Y" : "N") + ";" +
                  f11 + ";" +
                  (f12 < 0 ? "" : f12.ToString()) + ";" +
                  f13 + ";" +
                  (f14 ? "Y" : "N") + "|"
                : XMLLine;
        }

        public class CPRoute
        {
            public bool isUsed = false;
            public int id = 0, parent = 0;
            public String ManagerXMLLine = "", ManagerLine = "";
            public String name = "", fileName = "";
            public bool InfoEdited = false;
            // In file
            public String workWidth = "1";
            public String numHeadlandLanes = "1";
            public String headlandDirectionCW = "true";
            public String version = "1";
            public List<CPWaypoint> Waypoints = new List<CPWaypoint> { };
            public String XMLLine = "", Line = "";
            public bool Loaded = false, Edited = false;

            public CPRoute(String line) => ReadManagerXMLLine(line, true);

            public void ReadManagerXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = ManagerXMLLine;
                if (set) ManagerXMLLine = ManagerLine = line;

                int tmp;
                String s;
                        ReadValue.TagsAttribute(line, "fileName", out fileName, out tmp);
                if (0 < ReadValue.TagsAttribute(line, "isUsed",   out s,        out tmp)) isUsed = (s.ToLower() == "true");
                if (0 < ReadValue.TagsAttribute(line, "id",       out s,        out tmp)) int.TryParse(s, out id);
                if (0 < ReadValue.TagsAttribute(line, "parent",   out s,        out tmp)) int.TryParse(s, out parent);
                        ReadValue.TagsAttribute(line, "name",     out name,     out tmp);
            }

            public void ReadXMLLine(String line = null, bool set = false)
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                int tmp;
                ReadValue.TagsAttribute(line, "workWidth",           out workWidth,           out tmp);
                ReadValue.TagsAttribute(line, "numHeadlandLanes",    out numHeadlandLanes,    out tmp);
                ReadValue.TagsAttribute(line, "headlandDirectionCW", out headlandDirectionCW, out tmp);
                ReadValue.TagsAttribute(line, "version",             out version,             out tmp);
            }

            public String GetManagerXMLLine() => (InfoEdited) 
                ? "        <slot fileName=\"" + fileName +
                             "\" isUsed=\""   + isUsed.ToString().ToLower() +
                             "\" id=\""       + id +
                             "\" parent=\""   + parent +
                             "\" name=\""     + name +
                             "\"/>"
                : ManagerXMLLine;

            public String GetRouteXMLLine() => (Edited)
                ? "<course workWidth=\""           + workWidth +
                       "\" numHeadlandLanes=\""    + numHeadlandLanes +
                       "\" headlandDirectionCW=\"" + headlandDirectionCW +
                       "\" version=\""             + version +
                       "\">"
                : XMLLine;
        }
        private bool lockFilter = true, lockComparing = true;
        private String ManagerFileName = "", RouteFilesPath = "";
        private List<CPRoute> Routes = new List<CPRoute> { };
        // Visible outside
        public List<CPWaypoint> WaypointsShow = new List<CPWaypoint> { };
        public CPRoute    SelectedRoute    = null;
        public CPWaypoint SelectedWaypoint = null;

        #region Form
        public FormCPlay()//Ok
        {
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()//Ok
        {
            lockFilter = true;
            String selectRouteName = "";
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
                                case "Route": selectRouteName = value; break;
                                // Position
                                case "PositionStep"  : ReadValue.NUDDouble(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": ReadValue.NUDDouble(nudPositionOffset, value, NFI); break;
                                case "LimitXMin"     : ReadValue.NUDDouble(nudLimitXMin,      value, NFI); break;
                                case "LimitXMax"     : ReadValue.NUDDouble(nudLimitXMax,      value, NFI); break;
                                case "LimitYMin"     : ReadValue.NUDDouble(nudLimitYMin,      value, NFI); break;
                                case "LimitYMax"     : ReadValue.NUDDouble(nudLimitYMax,      value, NFI); break;
                                case "LimitZMin"     : ReadValue.NUDDouble(nudLimitZMin,      value, NFI); break;
                                case "LimitZMax"     : ReadValue.NUDDouble(nudLimitZMax,      value, NFI); break;
                                case "LimitX"        : cbLimitX.Checked = (value.ToLower() == "true"); break;
                                case "LimitY"        : cbLimitY.Checked = (value.ToLower() == "true"); break;
                                case "LimitZ"        : cbLimitZ.Checked = (value.ToLower() == "true"); break;
                                // Rotation
                                case "RotationStep"  : ReadValue.NUDDouble(nudRotationStep,   value, NFI); break;
                                case "RotationOffset": ReadValue.NUDDouble(nudRotationOffset, value, NFI); break;
                                case "LimitRMin"     : ReadValue.NUDDouble360(nudLimitRMin,   value, NFI); break;
                                case "LimitRMax"     : ReadValue.NUDDouble360(nudLimitRMax,   value, NFI); break;
                                case "LimitR"        : cbLimitR.Checked = (value.ToLower() == "true"); break;
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
                Routes_Load(tbManagerFile.Text, selectRouteName);
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
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value.ToString(NFI));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(NFI));
                    file.WriteLine("LimitXMin\t"      + nudLimitXMin     .Value.ToString(NFI));
                    file.WriteLine("LimitXMax\t"      + nudLimitXMax     .Value.ToString(NFI));
                    file.WriteLine("LimitYMin\t"      + nudLimitYMin     .Value.ToString(NFI));
                    file.WriteLine("LimitYMax\t"      + nudLimitYMax     .Value.ToString(NFI));
                    file.WriteLine("LimitZMin\t"      + nudLimitZMin     .Value.ToString(NFI));
                    file.WriteLine("LimitZMax\t"      + nudLimitZMax     .Value.ToString(NFI));
                    file.WriteLine("LimitX\t"         + cbLimitX.Checked.ToString());
                    file.WriteLine("LimitY\t"         + cbLimitY.Checked.ToString());
                    file.WriteLine("LimitZ\t"         + cbLimitZ.Checked.ToString());
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep  .Value.ToString(NFI));
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value.ToString(NFI));
                    file.WriteLine("LimitRMin\t"      + nudLimitRMin     .Value.ToString(NFI));
                    file.WriteLine("LimitRMax\t"      + nudLimitRMax     .Value.ToString(NFI));
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
        private void btnManagerFileReload_Click(object sender, EventArgs e) => Routes_Load(tbManagerFile.Text, SelectedRoute?.fileName);//Ok
        private void btnManagerFileLoad_Click(object sender, EventArgs e)//Ok
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
                CPRoute r;
                TreeNode n, sn = null;
                Routes.Clear();
                tvRoutes.BeginUpdate();
                tvRoutes.Nodes.Clear();
                SelectedWaypoint = null;
                clbWaypoints.SelectedIndex = -1;

                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        r = new CPRoute(file.ReadLine());
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
            SelectedWaypoint = null;
            clbWaypoints.SelectedIndex = -1;
            SelectedRoute = (tvRoutes.SelectedNode?.Tag as CPRoute);
            btnRouteInfoSave.Visible = false;
            tbRouteName.Enabled
                = chbRouteEnabled.Enabled
                = (SelectedRoute != null);
            if (SelectedRoute == null) return;
            // Apply values
            chbRouteEnabled.Checked = SelectedRoute.isUsed;
            tbRouteName.Text = SelectedRoute.name;
            if (SelectedRoute.Loaded)
                FilterWaypoints();
            else
                Route_Load();
        }

        private void RouteInfo_Changed(object sender, EventArgs e) => btnRouteInfoSave.Visible = 
            ((tvRoutes.SelectedNode.Tag as CPRoute).isUsed != chbRouteEnabled.Checked) || 
            ((tvRoutes.SelectedNode.Tag as CPRoute).name != tbRouteName.Text);

        private void tvRoutes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Bounds.X < e.X)
                return;
            CPRoute r = (e.Node.Tag as CPRoute);
            e.Node.StateImageIndex = (r.isUsed ^= true) ? 1 : 0;
            r.InfoEdited = true;
            r.Line = r.GetManagerXMLLine();
            if (e.Node == tvRoutes.SelectedNode)
                chbRouteEnabled.Checked = r.isUsed;
        }

        private void tbRoute_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            btnRouteInfoSave_Click(null, null);
            e.Handled = true;
        }

        private void tvRoutes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            String s = e.Label ?? e.Node.Text;
            if (tbRouteName.Text == s) return;
            tbRouteName.TextChanged -= RouteInfo_Changed;
            tbRouteName.Text
                = SelectedRoute.name
                = s;
            SelectedRoute.InfoEdited = true;
            SelectedRoute.Line = SelectedRoute.GetManagerXMLLine();
            tbRouteName.TextChanged += RouteInfo_Changed;
            btnRouteInfoSave.Visible = false;
        }

        private void btnRouteInfoSave_Click(object sender, EventArgs e)
        {
            TreeNode tn = tvRoutes.SelectedNode;
            if (tn == null) return;
            CPRoute r = (tn.Tag as CPRoute);
            tn.Text
                = r.name
                = tbRouteName.Text;
            r.isUsed = chbRouteEnabled.Checked;
            r.InfoEdited = true;
            r.Line = r.GetManagerXMLLine();
            // Update UI
            tn.StateImageIndex = (r.isUsed) ? 1 : 0;
            btnRouteInfoSave.Visible = false;
        }

        private void btnManagerFileSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(ManagerFileName))
                {
                    file.WriteLine("<courseManager>\r\n    <saveSlot>");
                    foreach (CPRoute r in Routes)
                    {
                        file.WriteLine((r.InfoEdited)
                            ? r.ManagerXMLLine = r.ManagerLine
                            : r.ManagerXMLLine);
                        r.InfoEdited = false;
                    }
                    file.Write("    </saveSlot>\r\n</courseManager>");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Waypoints
        private void btnReloadRoute_Click(object sender, EventArgs e) => Route_Load();
        private void Route_Load()
        {
            if (SelectedRoute == null) return;
            SelectedWaypoint = null;
            clbWaypoints.SelectedIndex = -1;
            try
            {
                String s;
                SelectedRoute.Waypoints.Clear();
                using (StreamReader file = File.OpenText(RouteFilesPath + "\\" + SelectedRoute.fileName))
                    while (!file.EndOfStream)
                    {
                        s = file.ReadLine();
                        // Load heading
                        if (s.Contains("<course "))
                        {
                            SelectedRoute.ReadXMLLine(s, true);
                            SelectedRoute.Edited = false;
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
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            SelectedRoute.Loaded = true;
            FilterWaypoints();
        }

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
            FormSHME.Main.IAC_Redraw();
        }

        public void Relist(bool force = false)
        {

        }

        private void nudPositionStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitXMin.Increment = nudLimitXMax.Increment = nudX.Increment =
            nudLimitYMin.Increment = nudLimitYMax.Increment = nudY.Increment =
            nudLimitZMin.Increment = nudLimitZMax.Increment = nudZ.Increment = nudPositionStep.Value;

        private void nudRotationStep_ValueChanged(object sender, EventArgs e) => //Ok
            nudLimitRMin.Increment = nudLimitRMax.Increment = nudR.Increment = nudRotationStep.Value;

        private void cbLimit_ValueChanged(object sender, EventArgs e)
        {
            if (cbLimitX.Checked || cbLimitX.Checked || cbLimitZ.Checked || cbLimitR.Checked)
                FilterWaypoints();
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e) => FilterWaypoints();

        private void clbWaypoints_MouseClick(object sender, MouseEventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            if (20 < e.X && 0 <= i)
                clbWaypoints.SetItemChecked(i, !clbWaypoints.GetItemChecked(i));
        }

        private void btnAlign_Click(object sender, EventArgs e)
        {
            if (clbWaypoints.CheckedIndices.Count < 1) return;
            bool doRotation = (sender == btnRotationAlign);
            Double step   = (Double)((doRotation) ? nudRotationStep  .Value : nudPositionStep  .Value);
            Double offset = (Double)((doRotation) ? nudRotationOffset.Value : nudPositionOffset.Value);
            CPWaypoint waypoint;
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                waypoint = WaypointsShow[i];
                if (waypoint.Align(step, offset, doRotation))
                {
                    waypoint.Edited = true;
                    waypoint.Line = waypoint.GetXMLLine();
                }
            }
            FilterWaypoints();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            String f = tbFind.Text;
            if (f == "") return;
            clbWaypoints.BeginUpdate();
            for (int i = WaypointsShow.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, WaypointsShow[i].Line.Contains(f));
            clbWaypoints.EndUpdate();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (clbWaypoints.CheckedIndices.Count < 1) return;
            String f = tbFind.Text;    if (f == "") return;
            String r = tbReplace.Text; if (f ==  r) return;
            CPWaypoint waypoint;
            foreach (int i in clbWaypoints.CheckedIndices)
            {
                waypoint = WaypointsShow[i];
                if (waypoint.ReadXMLLine(waypoint.Line.Replace(f, r)))
                {
                    waypoint.Edited = true;
                    waypoint.Line = waypoint.GetXMLLine();
                }
            }
            FilterWaypoints();
        }

        private void btnWaypointsDeleteSelected_Click(object sender, EventArgs e)
        {
            if (clbWaypoints.SelectedIndices.Count < 1) return;
            SelectedWaypoint = null;
            clbWaypoints.SelectedIndex = -1;
            clbWaypoints.BeginUpdate();
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                if (clbWaypoints.GetItemChecked(i))
                {
                    SelectedRoute.Waypoints.Remove(WaypointsShow[i]);
                    clbWaypoints.Items.RemoveAt(i);
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
                    file.WriteLine(SelectedRoute.GetRouteXMLLine());
                    file.WriteLine("    <waypoints>");
                    foreach (CPWaypoint waypoint in SelectedRoute.Waypoints)
                        file.WriteLine(waypoint.GetXMLLine());
                    file.Write("    </waypoints>\r\n</course>");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        #endregion

        #region Waypoint
        private void btnWaypointsCheckAll_Click(object sender, EventArgs e)
        {
            bool newState = (sender == btnPointsCheckAll);
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, newState);
        }

        private void btnWaypointsCheckInvert_Click(object sender, EventArgs e)
        {
            for (int i = clbWaypoints.Items.Count - 1; 0 <= i; i--)
                clbWaypoints.SetItemChecked(i, !clbWaypoints.GetItemChecked(i));
        }

        private void clbWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            btnWaypointSave.Visible = false;
            if (i < 0)
            {
                if (SelectedWaypoint != null) return; // Work in progress
                lockComparing = true;
                nudX    .Value =          0;
                nudY    .Value =          0;
                nudZ    .Value =          0;
                nudR    .Value =          0;
                nud05   .Value =          0;
                cbbAction.SelectedIndex = 0;
                chb07 .Checked =      false;
                chb08 .Checked =      false;
                chb09 .Checked =      false;
                chb10 .Checked =      false;
                tb11     .Text =         "";
                nud12   .Value =          0;
                tb13     .Text =         "";
                chb14 .Checked =      false;
                return;
            }
            // Set options
            lockComparing = true;
            SelectedWaypoint = WaypointsShow[i];
            nudX    .Value = (Decimal)SelectedWaypoint.x;
            nudY    .Value = (Decimal)SelectedWaypoint.y;
            nudZ    .Value = (Decimal)SelectedWaypoint.z;
            nudR    .Value = (Decimal)SelectedWaypoint.r;
            nud05   .Value = (Decimal)SelectedWaypoint.f05;
            cbbAction.SelectedIndex = SelectedWaypoint.Action;
            chb07 .Checked =          SelectedWaypoint.f07;
            chb08 .Checked =          SelectedWaypoint.f08;
            chb09 .Checked =          SelectedWaypoint.f09;
            chb10 .Checked =          SelectedWaypoint.f10;
            tb11     .Text =          SelectedWaypoint.f11;
            nud12   .Value = (Decimal)SelectedWaypoint.f12;
            tb13     .Text =          SelectedWaypoint.f13;
            chb14 .Checked =          SelectedWaypoint.f14;
            lockComparing = false;
        }

        private void Waypoint_ValueChanged(object sender, EventArgs e)
        {
            if (lockComparing) return;
            btnWaypointSave.Visible =
                SelectedWaypoint.x      !=  (Double)nudX    .Value ||
                SelectedWaypoint.y      !=  (Double)nudY    .Value ||
                SelectedWaypoint.z      !=  (Double)nudZ    .Value ||
                SelectedWaypoint.r      !=  (Double)nudR    .Value ||
                SelectedWaypoint.f05    !=     (int)nud05   .Value ||
                SelectedWaypoint.Action != cbbAction.SelectedIndex ||
                SelectedWaypoint.f07    !=          chb07 .Checked ||
                SelectedWaypoint.f08    !=          chb08 .Checked ||
                SelectedWaypoint.f09    !=          chb09 .Checked ||
                SelectedWaypoint.f10    !=          chb10 .Checked ||
                SelectedWaypoint.f11    !=          tb11     .Text ||
                SelectedWaypoint.f12    !=     (int)nud12   .Value ||
                SelectedWaypoint.f13    !=          tb13     .Text ||
                SelectedWaypoint.f14    !=          chb14 .Checked;
        }

        private void WaypointSave(CPWaypoint waypoint, int i)
        {
            waypoint.x = (Double)nudX.Value;
            waypoint.y = (Double)nudY.Value;
            waypoint.z = (Double)nudZ.Value;
            waypoint.r = (Double)nudR.Value;

            waypoint.f05 = (int)nud05.Value;
            waypoint.Action = (cbbAction.SelectedIndex < 0) ? 0 : cbbAction.SelectedIndex;

            waypoint.f07 = chb07.Checked;
            waypoint.f08 = chb08.Checked;
            waypoint.f09 = chb09.Checked;
            waypoint.f10 = chb10.Checked;

            waypoint.f11 = tb11.Text;
            waypoint.f12 = (int)nud12.Value;
            waypoint.f13 = tb13.Text;
            waypoint.f14 = chb14.Checked;

            waypoint.Edited = true;
            waypoint.Line = waypoint.GetXMLLine();
            clbWaypoints.Items[i] = waypoint.Line;
            btnWaypointSave.Visible = false;
        }

        private void btnWaypointSave_Click(object sender, EventArgs e)
        {
            WaypointSave(SelectedWaypoint, clbWaypoints.SelectedIndex);
            FormSHME.Main.IAC_Redraw(); // ? Fillter
        }

        private void btnWaypointInsert_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            SelectedWaypoint = new CPWaypoint("");
            if (i < 0)
            {
                SelectedRoute.Waypoints.Add(SelectedWaypoint);
                i++;
            }
            else
            {
                SelectedRoute.Waypoints.Insert(SelectedRoute.Waypoints.IndexOf(WaypointsShow[i]), SelectedWaypoint);
                WaypointsShow.Insert(i, SelectedWaypoint);
            }
            clbWaypoints.Items.Insert(i, "-");
            WaypointSave(SelectedWaypoint, i);
            FormSHME.Main.IAC_Redraw(); // ? Fillter
        }

        private void btnWaypointDelete_Click(object sender, EventArgs e)
        {
            int i = clbWaypoints.SelectedIndex;
            // Find and delete
            SelectedRoute.Waypoints.Remove(SelectedWaypoint);
            clbWaypoints.Items.RemoveAt(i);
            WaypointsShow.RemoveAt(i);
            // Update UI
//            SelectedWaypoint = (i < 0) ? null : WaypointsShow[i];
            if (clbWaypoints.Items.Count <= i) i--;
            if (i < 0) SelectedWaypoint = null;
            clbWaypoints.SelectedIndex = i;
            FormSHME.Main.IAC_Redraw();
        }
        #endregion
    }
}