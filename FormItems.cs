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

        private static readonly String NumberFormat = "f4";
        private static readonly String IniFileName = "Items.ini";
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
                end = 0;
                // Find attribute
                start = line.IndexOf(' ' + attribute); // Position before attribute ' attribute=""'
                if (start < 0)
                {
                    start = 0;
                    return;
                }
                // Extract value
                int q1, q2;
                if ((q1 = line.IndexOf('"', start) + 1) < 1) return; // Position first second "
                if ((q2 = line.IndexOf('"', q1)) < 1) return; // Position after second "
                string[] v = line.Substring(q1, q2 - q1).Replace("  ", " ").Replace(',', '.').Split(' ');
                end = q2 + 1;
                // Set XYZ
                if (0 < v.Length) Double.TryParse(v[0], NumberStyles.Float, nfi, out x);
                if (1 < v.Length) Double.TryParse(v[1], NumberStyles.Float, nfi, out y);
                if (2 < v.Length) Double.TryParse(v[2], NumberStyles.Float, nfi, out z);
                present = true;
            }

            public void Align(double step, double offset, Boolean doRotation)
            {
                if (present || step == 0) return;
                if (doRotation)
                    y = Math.Round((y - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
            }

            public String GetLine(String format, NumberFormatInfo nfi) =>
                x.ToString(format, nfi) + " " + 
                y.ToString(format, nfi) + " " + 
                z.ToString(format, nfi);
        }

        public class FSItem
        {
            public String A = "", B = "", C = "", XMLLine = "", Line = "";
            public xyzDouble Rotation = new xyzDouble(),
                             Position = new xyzDouble();
            public bool Edited = false;

            public FSItem(String line) => ReadXMLLine(line, true);

            public void ReadXMLLine(String line = null, bool set = false)//
            {
                if (line == null) line = XMLLine;
                if (set) XMLLine = line;
                Line = line;

                Position.ReadXMLLine(line, "position", NFI);
                Rotation.ReadXMLLine(line, "rotation", NFI);

                // A + rotation + B + position + C | "" + B + position + C
                if (Rotation.start < Position.start)
                {
                    A = line.Substring(0, Rotation.start);
                    B = line.Substring(Rotation.end, Position.start - Rotation.end);
                    C = line.Substring(Position.end);
                }
                // A + position + B + rotation + C | "" + B + rotation + C | "" + "" + C
                else
                {
                    A = line.Substring(0, Position.start);
                    B = line.Substring(Position.end, Rotation.start - Position.end);
                    C = line.Substring(Rotation.end);
                }
            }

            public String GetXMLLine() => //
                A + (Position.present
                    ? " position=\"" + Position.GetLine(NumberFormat, NFI) + '"'
                    : "" ) +
                B + (Rotation.present
                    ? " rotation=\"" + Rotation.GetLine(NumberFormat, NFI) + '"'
                    : "" ) +
                C;
        }

        private bool lockFilter = false;
        private String FileName = "";
        private List<FSItem> FSItems = new List<FSItem> { };
        public  List<FSItem> FSItemsShown = new List<FSItem> { };

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
                                // Position
                                case "PositionStep"  : nudPositionStep.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionOffset": nudPositionOffset.Value = (Decimal)Double.Parse(value); break;
                                case "PositionXMin"  : nudPositionXMin.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionXMax"  : nudPositionXMax.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionYMin"  : nudPositionYMin.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionYMax"  : nudPositionYMax.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionZMin"  : nudPositionZMin.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionZMax"  : nudPositionZMax.Value   = (Decimal)Double.Parse(value); break;
                                case "PositionRange" : cbLimitPositionX.Checked = (value == "true"); break;
                                // Rotation
                                case "RotationStep"  : nudRotationStep.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationOffset": nudRotationOffset.Value = (Decimal)Double.Parse(value); break;
                                case "RotationXMin"  : nudRotationXMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationXMax"  : nudRotationXMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationYMin"  : nudRotationYMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationYMax"  : nudRotationYMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationZMin"  : nudRotationZMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationZMax"  : nudRotationZMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationRange" : cbLimitRotationX.Checked = (value == "true"); break;
                                // Find & Replace
                                case "Find": tbFind.Text = value.Replace("&#9;", "\t"); break;
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
                    for (int i = 0; i < tvFilters.Nodes.Count; i++)
                        file.WriteLine("Filter\t" + tvFilters.Nodes[i].Text + "\t" + "*+-"[tvFilters.Nodes[i].StateImageIndex]);
                    // Position
                    file.WriteLine("PositionStep\t"   + nudPositionStep.Value);
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                    file.WriteLine("PositionRange\t"  + cbLimitPositionX.Checked.ToString());
                    file.WriteLine("PositionXMin\t"   + nudPositionXMin.Value); file.WriteLine("PositionXMax\t" + nudPositionXMax.Value);
                    file.WriteLine("PositionYMin\t"   + nudPositionYMin.Value); file.WriteLine("PositionYMax\t" + nudPositionYMax.Value);
                    file.WriteLine("PositionZMin\t"   + nudPositionZMin.Value); file.WriteLine("PositionZMax\t" + nudPositionZMax.Value);
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep.Value);
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value);
                    file.WriteLine("RotationRange\t"  + cbLimitRotationX.Checked.ToString());
                    file.WriteLine("RotationXMin\t"   + nudRotationXMin.Value); file.WriteLine("RotationXMax\t" + nudRotationXMax.Value);
                    file.WriteLine("RotationYMin\t"   + nudRotationYMin.Value); file.WriteLine("RotationYMax\t" + nudRotationYMax.Value);
                    file.WriteLine("RotationZMin\t"   + nudRotationZMin.Value); file.WriteLine("RotationZMax\t" + nudRotationZMax.Value);
                    // Find & Replace
                    file.WriteLine("Find\t"    + tbFind.Text.Replace("\t", "&#9;"));
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
                        file.WriteLine(line.GetXMLLine());
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
        private void FilterItems()//
        {
            if (lockFilter) return;
            clbItems.BeginUpdate();
            clbItems.Items.Clear();
            FSItemsShown.Clear();
            // Select
            bool skip;
            String s;
            foreach (FSItem item in FSItems)
            {
                skip = false;
                s = item.Line;
                foreach (TreeNode Filter in tvFilters.Nodes)
                    if (0 < Filter.StateImageIndex)
                        if (s.Contains(Filter.Text) == (2 == Filter.StateImageIndex))
                        {
                            skip = true;
                            break;
                        }
                if (skip)
                    continue;
                if (cbLimitPositionX.Checked || cbLimitPositionY.Checked || cbLimitPositionZ.Checked)
                {
                    if (!item.Position.present)
                        continue;
                    if (cbLimitPositionX.Checked) if (item.Position.x < (Double)nudPositionXMin.Value || (Double)nudPositionXMax.Value < item.Position.x) continue;
                    if (cbLimitPositionY.Checked) if (item.Position.y < (Double)nudPositionYMin.Value || (Double)nudPositionYMax.Value < item.Position.y) continue;
                    if (cbLimitPositionZ.Checked) if (item.Position.z < (Double)nudPositionZMin.Value || (Double)nudPositionZMax.Value < item.Position.z) continue;
                }
                if (cbLimitRotationX.Checked || cbLimitRotationY.Checked || cbLimitRotationZ.Checked)
                {
                    if (!item.Rotation.present)
                        continue;
                    if (cbLimitRotationX.Checked) if (item.Rotation.x < (Double)nudRotationXMin.Value || (Double)nudRotationXMax.Value < item.Rotation.x) continue;
                    if (cbLimitRotationY.Checked) if (item.Rotation.y < (Double)nudRotationYMin.Value || (Double)nudRotationYMax.Value < item.Rotation.y) continue;
                    if (cbLimitRotationZ.Checked) if (item.Rotation.z < (Double)nudRotationZMin.Value || (Double)nudRotationZMax.Value < item.Rotation.z) continue;
                }
                // Allowed
                FSItemsShown.Add(item);
                clbItems.Items.Add(s);
            }
            clbItems.EndUpdate();
            FormSHME.Main.IAC_Update();
        }

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
            tbFilter.Text = (tvFilters.SelectedNode != null)
                ? tvFilters.SelectedNode.Text
                : "";
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

        private void LimitFilter_Changed(object sender, EventArgs e) => FilterItems();

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
            tbFilter.TextChanged -= tbFilter_TextChanged;
            tbFilter.Text = (e.Label == null) ? e.Node.Text : e.Label;
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
        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudPositionStep.Value;
            Double offset = (Double)nudPositionOffset.Value;
            if (clbItems.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbItems.CheckedIndices)
            {
                FSItemsShown[i].Position.Align(step, offset, false);
                clbItems.Items[i]
                    = FSItemsShown[i].Line
                    = FSItemsShown[i].GetXMLLine();
                FSItemsShown[i].Edited = true;
            }
            btnItemsReload.Visible = true;
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
                FSItemsShown[i].Rotation.Align(step, offset, true);
                clbItems.Items[i]
                    = FSItemsShown[i].Line
                    = FSItemsShown[i].GetXMLLine();
                FSItemsShown[i].Edited = true;
            }
            btnItemsReload.Visible = true;
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
                = FSItemsShown[i].Line
                = tbLine.Text;
            FSItemsShown[i].ReadXMLLine();
            FSItemsShown[i].Edited = true;
            btnItemsReload.Visible = true;
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
            foreach (int i in clbItems.CheckedIndices)
            {
                if (doRotation)
                {
                    FSItemsShown[i].Rotation.x += x;
                    FSItemsShown[i].Rotation.y += y;
                    FSItemsShown[i].Rotation.z += z;
                }
                else
                {
                    FSItemsShown[i].Position.x += x;
                    FSItemsShown[i].Position.y += y;
                    FSItemsShown[i].Position.z += z;
                }
                clbItems.Items[i]
                    = FSItemsShown[i].Line
                    = FSItemsShown[i].GetXMLLine();
                FSItemsShown[i].Edited = true;
            }
            btnItemsReload.Visible = true;
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
            String f = tbFind.Text;
            for (int i = FSItemsShown.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, FSItemsShown[i].Line.Contains(f));
        }

        private void btnReplace_Click(object sender, EventArgs e)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1)
                return;
            String f = tbFind.Text,
                   r = tbReplace.Text;
            clbItems.BeginUpdate();
            foreach (int i in clbItems.CheckedIndices)
            {
                clbItems.Items[i]
                    = FSItemsShown[i].Line
                    = FSItemsShown[i].Line.Replace(f, r);
                FSItemsShown[i].ReadXMLLine();
                FSItemsShown[i].Edited = true;
            }
            clbItems.EndUpdate();
            btnItemsReload.Visible = true;
            FormSHME.Main.IAC_Update();
        }

        private void btnItemsReload_Click(object sender, EventArgs e)//Ok
        {
            clbItems.BeginUpdate();
            for (int i = FSItemsShown.Count - 1; 0 <= i; i--)
                if (FSItemsShown[i].Edited)
                    clbItems.Items[i] = FSItemsShown[i].XMLLine;
            // Reset lines
            for (int i = FSItems.Count - 1; 0 <= i; i--)
                if (FSItems[i].Edited)
                {
                    FSItems[i].ReadXMLLine();
                    FSItems[i].Edited = false;
                }
            clbItems.EndUpdate();
            btnItemsReload.Visible = false;
            FormSHME.Main.IAC_Update();
        }
        #endregion
    }
}