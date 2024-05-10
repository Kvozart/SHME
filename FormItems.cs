using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormItems : Form
    {
        public const int iconW = 9, iconCX = 4,
                         iconH = 9, iconCY = 4;
        public static readonly int[] icon = {
            0x00000000, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x00000000,
            0x7F007F00, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x7FFF0000, 0x00000000, 0x7FFF0000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x7FFF0000, 0x00000000, 0x7FFF0000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x7F007F00,
            0x00000000, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x00000000};

        private const String FloatFormat = "f4";
        private const String IniFileName = "Items.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class xyzDouble
        {
            public int start, end;
            public double x = 0, y = 0, z = 0;
            public bool present;

            public void ReadXMLLine(String line, String attribute, NumberFormatInfo nfi)
            {
                present = false;
                x = y = z = 0;
                start = FormSHME.ReadTagsAttribute(line, attribute, out line, out end);
                if (start < 1) return;
                // Extract value
                string[] v = line.Replace("  ", " ").Replace(',', '.').Split(' ');
                if (0 < v.Length) Double.TryParse(v[0], NumberStyles.Float, nfi, out x);
                if (1 < v.Length) Double.TryParse(v[1], NumberStyles.Float, nfi, out y);
                if (2 < v.Length) Double.TryParse(v[2], NumberStyles.Float, nfi, out z);
                present = true;
            }

            public bool Align(double step, double offset, Boolean doRotation)
            {
                if (step == 0 && offset == 0) return false;
                double ix = x, iy = y, iz = z;
                if (doRotation)
                    y = Math.Round((y - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
                return ix != x || iy != y || iz != z;
            }

            public void Increment(double stepX, double stepY, double stepZ)
            {
                y += stepX;
                x += stepY;
                z += stepZ;
            }

            public String GetLine() =>
                x.ToString(FloatFormat, NFI) + " " + 
                y.ToString(FloatFormat, NFI) + " " + 
                z.ToString(FloatFormat, NFI);
        }

        public class FSItem
        {
            public String A = "", B = "", C = "";
            public xyzDouble Rotation = new xyzDouble(),
                             Position = new xyzDouble();
            // Own
            public String XMLLine = "", Line = "";
            public bool Edited = false, Show, Shown;

            public FSItem(String line) => ReadXMLLine(line, true);

            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = Line = line;

                Position.ReadXMLLine(line, "position", NFI);
                Rotation.ReadXMLLine(line, "rotation", NFI);

                // A + rotation + B + position + C | "" + 0 + B + position + C
                if (Rotation.start < Position.start)
                {
                    A = line.Substring(0, Rotation.start);
                    B = line.Substring(Rotation.end, Position.start - Rotation.end);
                    C = line.Substring(Position.end);
                }
                // A + position + B + rotation + C | "" + 0 + B + rotation + C | "" + 0 + "" + 0 + C
                else
                {
                    A = line.Substring(0, Position.start);
                    B = line.Substring(Position.end, Rotation.start - Position.end);
                    C = line.Substring(Rotation.end);
                }
            }

            public String GetXMLLine() => (Edited)
                ? A + (Position.present ? " position=\"" + Position.GetLine() + '"' : "" ) +
                  B + (Rotation.present ? " rotation=\"" + Rotation.GetLine() + '"' : "" ) +
                  C
                : XMLLine;
        }

        private bool lockFilter = true;
        private String FileName = "";
        private List<FSItem> FSItems = new List<FSItem> { };
        public  List<FSItem> FSItemsShow = new List<FSItem> { };

        #region Form
        public FormItems()//Ok
        {
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()//Ok
        {
            lockFilter = true;
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
                                case "File": tbFile.Text = value; break;
                                case "Filter":
                                    tvFilters.Nodes.Add(value).StateImageIndex = (rec[2] == "+") ? 1 : (rec[2] == "-") ? 2 : 0;
                                    break;
                                // PositionNFI
                                case "PositionStep"  : FormSHME.SetNUD(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": FormSHME.SetNUD(nudPositionOffset, value, NFI); break;
                                case "PositionXMin"  : FormSHME.SetNUD(nudPositionXMin,   value, NFI); break;
                                case "PositionXMax"  : FormSHME.SetNUD(nudPositionXMax,   value, NFI); break;
                                case "PositionYMin"  : FormSHME.SetNUD(nudPositionYMin,   value, NFI); break;
                                case "PositionYMax"  : FormSHME.SetNUD(nudPositionYMax,   value, NFI); break;
                                case "PositionZMin"  : FormSHME.SetNUD(nudPositionZMin,   value, NFI); break;
                                case "PositionZMax"  : FormSHME.SetNUD(nudPositionZMax,   value, NFI); break;
                                case "PositionLimitX": cbLimitPositionX.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitY": cbLimitPositionY.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitZ": cbLimitPositionZ.Checked = (value.ToLower() == "true"); break;
                                // Rotation
                                case "RotationStep"  : FormSHME.SetNUD(nudRotationStep,   value, NFI); break;
                                case "RotationOffset": FormSHME.SetNUD(nudRotationOffset, value, NFI); break;
                                case "RotationXMin"  : FormSHME.SetNUD(nudRotationXMin,   value, NFI); break;
                                case "RotationXMax"  : FormSHME.SetNUD(nudRotationXMax,   value, NFI); break;
                                case "RotationYMin"  : FormSHME.SetNUD(nudRotationYMin,   value, NFI); break;
                                case "RotationYMax"  : FormSHME.SetNUD(nudRotationYMax,   value, NFI); break;
                                case "RotationZMin"  : FormSHME.SetNUD(nudRotationZMin,   value, NFI); break;
                                case "RotationZMax"  : FormSHME.SetNUD(nudRotationZMax,   value, NFI); break;
                                case "RotationLimitX": cbLimitRotationX.Checked = (value.ToLower() == "true"); break;
                                case "RotationLimitY": cbLimitRotationY.Checked = (value.ToLower() == "true"); break;
                                case "RotationLimitZ": cbLimitRotationZ.Checked = (value.ToLower() == "true"); break;
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
            Update_FiltersButtons();
            nudPositionStep_ValueChanged(null, null);
            nudRotationStep_ValueChanged(null, null);
            // Load file to edit
            lockFilter = false;
            if (tbFile.Text != "")
                Items_Load(tbFile.Text);
        }

        public void OptionsSave()//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(IniFileName))
                {
                    file.WriteLine("File\t" + tbFile.Text);
                    foreach (TreeNode tn in tvFilters.Nodes)
                        file.WriteLine("Filter\t" + tn.Text + "\t" + "*+-"[tn.StateImageIndex]);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep.Value.ToString(NFI));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(NFI));
                    file.WriteLine("PositionLimitX\t" + cbLimitPositionX.Checked.ToString());
                    file.WriteLine("PositionLimitY\t" + cbLimitPositionY.Checked.ToString());
                    file.WriteLine("PositionLimitZ\t" + cbLimitPositionZ.Checked.ToString());
                    file.WriteLine("PositionXMin\t"   + nudPositionXMin.Value.ToString(NFI));
                    file.WriteLine("PositionXMax\t"   + nudPositionXMax.Value.ToString(NFI));
                    file.WriteLine("PositionYMin\t"   + nudPositionYMin.Value.ToString(NFI));
                    file.WriteLine("PositionYMax\t"   + nudPositionYMax.Value.ToString(NFI));
                    file.WriteLine("PositionZMin\t"   + nudPositionZMin.Value.ToString(NFI));
                    file.WriteLine("PositionZMax\t"   + nudPositionZMax.Value.ToString(NFI));
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep.Value.ToString(NFI));
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value.ToString(NFI));
                    file.WriteLine("RotationLimitX\t" + cbLimitRotationX.Checked.ToString());
                    file.WriteLine("RotationLimitY\t" + cbLimitRotationY.Checked.ToString());
                    file.WriteLine("RotationLimitZ\t" + cbLimitRotationZ.Checked.ToString());
                    file.WriteLine("RotationXMin\t"   + nudRotationXMin.Value.ToString(NFI));
                    file.WriteLine("RotationXMax\t"   + nudRotationXMax.Value.ToString(NFI));
                    file.WriteLine("RotationYMin\t"   + nudRotationYMin.Value.ToString(NFI));
                    file.WriteLine("RotationYMax\t"   + nudRotationYMax.Value.ToString(NFI));
                    file.WriteLine("RotationZMin\t"   + nudRotationZMin.Value.ToString(NFI)); 
                    file.WriteLine("RotationZMax\t"   + nudRotationZMax.Value.ToString(NFI));
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

        private void btnFileReload_Click(object sender, EventArgs e) => Items_Load(tbFile.Text);//Ok
        private void btnFileLoad_Click(object sender, EventArgs e)//Ok
        {
            dlgOpen.FileName = Path.GetFileName(tbFile.Text);
            if (tbFile.Text != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(tbFile.Text).Replace(Path.GetFileName(tbFile.Text), "");
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            Items_Load(dlgOpen.FileName);
        }

        private void Items_Load(String fileName)//Ok
        {
            try
            {
                FSItems.Clear();
                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                        FSItems.Add(new FSItem(file.ReadLine()));
                FileName
                    = tbFile.Text
                    = fileName;
                FilterItems();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnFileSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(FileName))
                    foreach (FSItem line in FSItems)
                    {
                        if (line.Edited) line.XMLLine = line.GetXMLLine();
                        file.WriteLine(line.XMLLine);
                        line.Edited = false;
                    }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void FormItems_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            Hide();
            e.Cancel = true;
        }
        #endregion

        #region Filters
        private void Update_FiltersButtons()
        {
            btnFilterDelete   .Visible = (tvFilters.SelectedNode != null);
            btnFilterDeleteAll.Visible = (1 < tvFilters.Nodes.Count);
            btnFilterSave.Visible
                = btnFilterAdd.Visible
                = false;
        }

        private void tvFilters_AfterSelect(object sender, TreeViewEventArgs e)//Ok
        {
            tbFilter.Text = tvFilters.SelectedNode?.Text ?? "";
            Update_FiltersButtons();
        }

        private void btnFilterSave_Click(object sender, EventArgs e)//Ok
        {
            if (sender == btnFilterSave)
                tvFilters.SelectedNode.Text = tbFilter.Text;
            else
                (tvFilters.SelectedNode
                    = tvFilters.Nodes.Add(tbFilter.Text))
                    .StateImageIndex = 1;
            btnFilterAdd.Visible
                = btnFilterSave.Visible
                = false;
            FilterItems();
        }

        private void btnFilterDelete_Click(object sender, EventArgs e)//Ok
        {
            tvFilters.SelectedNode.Remove();
            if (tvFilters.SelectedNode == null)
            {
                tbFilter.Text = "";
                Update_FiltersButtons();
            }
            FilterItems();
        }

        private void btnFilterDeleteAll_Click(object sender, EventArgs e)//Ok
        {
            tvFilters.Nodes.Clear();
            tvFilters_AfterSelect(null, null);
            FilterItems();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)//Ok
        {
            if (e.KeyChar != '\r') return;
            if (btnFilterSave.Visible) btnFilterSave_Click(btnFilterSave, null);
            else                       btnFilterSave_Click(btnFilterAdd,  null);
            e.Handled = true;
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tvFilters.SelectedNode == null)
                btnFilterAdd.Visible = (tbFilter.Text != "");
            else
                btnFilterAdd.Visible
                    = btnFilterSave.Visible
                    = (tbFilter.Text != tvFilters.SelectedNode.Text);
        }

        private void LimitFilter_Changed(object sender, EventArgs e)
        {
            if (cbLimitPositionX.Checked || cbLimitPositionX.Checked || cbLimitPositionZ.Checked ||
                cbLimitRotationX.Checked || cbLimitRotationX.Checked || cbLimitRotationZ.Checked)
                FilterItems();
        }

        private void tvFilters_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.TreeView.SelectedNode = e.Node;
            if (e.X < e.Node.Bounds.X)
                NodeSwitchState(e.Node, (e.Button == MouseButtons.Left)? 1 : -1);
        }

        private void tvFilters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                NodeSwitchState((sender as TreeView).SelectedNode);
                e.Handled = true;
            }
            else if (e.KeyChar == '\r')
            {
                (sender as TreeView).SelectedNode.BeginEdit();
                e.Handled = true;
            }
        }

        private void tvFilters_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            String s = e.Label ?? e.Node.Text;
            if (tbFilter.Text == s) return;
            tbFilter.TextChanged -= tbFilter_TextChanged;
            tbFilter.Text = s;
            tbFilter.TextChanged += tbFilter_TextChanged;
            btnFilterAdd.Visible
                = btnFilterSave.Visible
                = false;
        }

        private void NodeSwitchState(TreeNode Node, int increment = 1)
        {
            int stateBase = Node.TreeView.StateImageList.Images.Count;
            Node.StateImageIndex = (stateBase + Node.StateImageIndex + increment) % stateBase;
            FilterItems();
        }

        private void btnDeselect_Click       (object sender, EventArgs e) => BatchFilterSelection(0);
        private void btnSelect_Click         (object sender, EventArgs e) => BatchFilterSelection(1);
        private void btnInvertSelection_Click(object sender, EventArgs e) => BatchFilterSelection(2);
        private void BatchFilterSelection(int state)
        {
            foreach (TreeNode Node in tvFilters.Nodes)
                Node.StateImageIndex = state;
            FilterItems();
        }
        #endregion

        #region Items list
        private void FilterItems()//
        {
            if (lockFilter) return;
            clbItems.BeginUpdate();
            clbItems.Items.Clear();
            FSItemsShow.Clear();
            // Prepare
            Double minPX = (Double)nudPositionXMin.Value,  maxPX = (Double)nudPositionXMax.Value,
                   minPY = (Double)nudPositionYMin.Value,  maxPY = (Double)nudPositionYMax.Value,
                   minPZ = (Double)nudPositionZMin.Value,  maxPZ = (Double)nudPositionZMax.Value,
                   minRX = (Double)nudRotationXMin.Value,  maxRX = (Double)nudRotationXMax.Value,
                   minRY = (Double)nudRotationYMin.Value,  maxRY = (Double)nudRotationYMax.Value,
                   minRZ = (Double)nudRotationZMin.Value,  maxRZ = (Double)nudRotationZMax.Value;
            bool limitPX =     cbLimitPositionX.Checked, limitRX =     cbLimitRotationX.Checked,
                 limitPY =     cbLimitPositionY.Checked, limitRY =     cbLimitRotationY.Checked,
                 limitPZ =     cbLimitPositionZ.Checked, limitRZ =     cbLimitRotationZ.Checked;
            bool limitP = (limitPX || limitPY || limitPZ),
                 limitR = (limitRX || limitRY || limitRZ);
            bool skip;
            // Select
            foreach (FSItem item in FSItems)
            {
                item.Show
                    = skip
                    = false;
                foreach (TreeNode filter in tvFilters.Nodes)
                    if (0 < filter.StateImageIndex)
                        if (item.Line.Contains(filter.Text) == (2 == filter.StateImageIndex))
                        {
                            skip = true;
                            break;
                        }
                if (skip)
                    continue;
                if (limitP)
                {
                    if (!item.Position.present) continue;
                    if (limitPX) if (item.Position.x < minPX || maxPX < item.Position.x) continue;
                    if (limitPY) if (item.Position.y < minPY || maxPY < item.Position.y) continue;
                    if (limitPZ) if (item.Position.z < minPZ || maxPZ < item.Position.z) continue;
                }
                if (limitR)
                {
                    if (!item.Rotation.present) continue;
                    if (limitRX) if (item.Rotation.x < minRX || maxRX < item.Rotation.x) continue;
                    if (limitRY) if (item.Rotation.y < minRY || maxRY < item.Rotation.y) continue;
                    if (limitRZ) if (item.Rotation.z < minRZ || maxRZ < item.Rotation.z) continue;
                }
                // Allowed
                clbItems.Items.Add(item.Line);
                FSItemsShow.Add(item);
                item.Show = true;
            }
            clbItems.EndUpdate();
            FormSHME.Main.IAC_Update();
        }

        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudPositionStep.Value;
            Double offset = (Double)nudPositionOffset.Value;
            if (clbItems.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbItems.CheckedIndices)
            {
                if (FSItemsShow[i].Position.Align(step, offset, false))
                {
                    FSItemsShow[i].Edited = true;
                    clbItems.Items[i]
                        = FSItemsShow[i].Line
                        = FSItemsShow[i].GetXMLLine();
                }
            }
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnRotationAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudRotationStep.Value;
            Double offset = (Double)nudRotationOffset.Value;
            if (clbItems.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbItems.CheckedIndices)
            {
                if (FSItemsShow[i].Rotation.Align(step, offset, true))
                {
                    FSItemsShow[i].Edited = true;
                    clbItems.Items[i]
                        = FSItemsShow[i].Line
                        = FSItemsShow[i].GetXMLLine();
                }
            }
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void nudPositionStep_ValueChanged(object sender, EventArgs e) =>
            nudPositionXMin.Increment = nudPositionXMax.Increment =
            nudPositionYMin.Increment = nudPositionYMax.Increment =
            nudPositionZMin.Increment = nudPositionZMax.Increment = nudPositionStep.Value;

        private void nudRotationStep_ValueChanged(object sender, EventArgs e) =>
            nudRotationXMin.Increment = nudRotationXMax.Increment =
            nudRotationYMin.Increment = nudRotationYMax.Increment =
            nudRotationZMin.Increment = nudRotationZMax.Increment = nudRotationStep.Value;

        private void clbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbLine.Enabled && clbItems.SelectedItem != null)
                tbLine.Text = clbItems.SelectedItem.ToString();
        }

        private void clbItems_MouseClick(object sender, MouseEventArgs e)
        {
            int i = clbItems.SelectedIndex;
            if (20 < e.X && 0 <= i)
                clbItems.SetItemChecked(i, !clbItems.GetItemChecked(i));
        }

        private void btnItemsSetAllChecks_Click(object sender, EventArgs e)
        {
            bool newState = (sender == btnItemsCheckAll);
            for (int i = clbItems.Items.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, newState);
        }

        private void btnItemsInvertChecks_Click(object sender, EventArgs e)
        {
            for (int i = clbItems.Items.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, !clbItems.GetItemChecked(i));
        }

        private void tbLine_Leave(object sender, EventArgs e)
        {
            if (clbItems.SelectedItem?.ToString() == tbLine.Text)
                return;
            int i = clbItems.SelectedIndex;
            clbItems.Items[i]
                = FSItemsShow[i].Line
                = tbLine.Text;
            FSItemsShow[i].Edited = true;
            FSItemsShow[i].ReadXMLLine(tbLine.Text);
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void tbLine_KeyPress(object sender, KeyPressEventArgs e)//Ok
        {
            if (e.KeyChar != '\r') return;
            tbLine_Leave(null, null);
            e.Handled = true;
        }

        private void XYZIncrement(double x, double y, double z, bool doRotation)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1) return;
            FSItem item;
            foreach (int i in clbItems.CheckedIndices)
            {
                item = FSItemsShow[i];
                if (doRotation) item.Rotation.Increment(x, y, z);
                else            item.Position.Increment(x, y, z);
                item.Edited = true;
                clbItems.Items[i]
                    = item.Line
                    = item.GetXMLLine();
            }
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnPositionXsub_Click(object sender, EventArgs e) => XYZIncrement(-(Double)nudPositionStep.Value, 0, 0, false);
        private void btnPositionXadd_Click(object sender, EventArgs e) => XYZIncrement( (Double)nudPositionStep.Value, 0, 0, false);
        private void btnPositionYsub_Click(object sender, EventArgs e) => XYZIncrement(0, -(Double)nudPositionStep.Value, 0, false);
        private void btnPositionYadd_Click(object sender, EventArgs e) => XYZIncrement(0,  (Double)nudPositionStep.Value, 0, false);
        private void btnPositionZsub_Click(object sender, EventArgs e) => XYZIncrement(0, 0, -(Double)nudPositionStep.Value, false);
        private void btnPositionZadd_Click(object sender, EventArgs e) => XYZIncrement(0, 0,  (Double)nudPositionStep.Value, false);

        private void btnRotationXsub_Click(object sender, EventArgs e) => XYZIncrement(-(Double)nudRotationStep.Value, 0, 0, true);
        private void btnRotationXadd_Click(object sender, EventArgs e) => XYZIncrement( (Double)nudRotationStep.Value, 0, 0, true);
        private void btnRotationYsub_Click(object sender, EventArgs e) => XYZIncrement(0, -(Double)nudRotationStep.Value, 0, true);
        private void btnRotationYadd_Click(object sender, EventArgs e) => XYZIncrement(0,  (Double)nudRotationStep.Value, 0, true);
        private void btnRotationZsub_Click(object sender, EventArgs e) => XYZIncrement(0, 0, -(Double)nudRotationStep.Value, true);
        private void btnRotationZadd_Click(object sender, EventArgs e) => XYZIncrement(0, 0,  (Double)nudRotationStep.Value, true);

        private void btnFind_Click(object sender, EventArgs e)//Ok
        {
            clbItems.BeginUpdate();
            String f = tbFind.Text;
            for (int i = FSItemsShow.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, FSItemsShow[i].Line.Contains(f));
            clbItems.EndUpdate();
        }

        private void btnReplace_Click(object sender, EventArgs e)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1)
                return;
            FSItem item;
            String f = tbFind.Text,
                   r = tbReplace.Text;
            clbItems.BeginUpdate();
            foreach (int i in clbItems.CheckedIndices)
            {
                item = FSItemsShow[i];
                clbItems.Items[i]
                    = item.Line
                    = item.Line.Replace(f, r);
                item.Edited = true;
                item.ReadXMLLine(item.Line);
            }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnItemsUnroll_Click(object sender, EventArgs e)//Ok
        {
            clbItems.BeginUpdate();
            for (int i = FSItemsShow.Count - 1; 0 <= i; i--)
                if (FSItemsShow[i].Edited)
                    clbItems.Items[i] = FSItemsShow[i].XMLLine;
            // Reset lines
            for (int i = FSItems.Count - 1; 0 <= i; i--)
                if (FSItems[i].Edited)
                {
                    FSItems[i].ReadXMLLine();
                    FSItems[i].Edited = false;
                }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = false;
            FormSHME.Main.IAC_Update();
        }
        #endregion
    }
}