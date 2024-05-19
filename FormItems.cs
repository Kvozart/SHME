using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormItems : Form
    {
        public static readonly int[] pinSelection = {
            0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FBFBFBF,
            0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF, 0x7FBFBFBF};

        public static readonly int[] pinDefault = {
            0x00000000, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x00000000,
            0x7F007F00, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x7FFF0000, 0x00000000, 0x7FFF0000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x00000000, 0x7FFF0000, 0x00000000, 0x7FFF0000, 0x00000000, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x00000000, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x00000000, 0x7F007F00,
            0x7F007F00, 0x7FFFFF00, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFF00, 0x7F007F00,
            0x00000000, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x7F007F00, 0x00000000};

        public static FSPins Pins = new FSPins(9, 9, 4, 4,
            new int[][]{
                pinDefault},
            pinSelection,
            new Pen[]{
                new Pen(Color.White)}
            );

        public class FSItem : FSObject
        {
            new public static readonly String FloatFormat = "f4";

            public String A = "", B = "", C = "";
            public XYZRDouble Rotation = new XYZRDouble();
            // Own
            int pStart, rStart;

            public FSItem(String line) : base(line) { }

            override public void DecodeXMLLine(String line)
            {
                String tmp;
                if (Position.Present = (0 < (pStart = ReadValue.TagsAttribute(line, "position", out tmp, out int pEnd)))) Position.ReadXMLLine(tmp, FloatPoint);
                if (Rotation.Present = (0 < (rStart = ReadValue.TagsAttribute(line, "rotation", out tmp, out int rEnd)))) Rotation.ReadXMLLine(tmp, FloatPoint);
                // A + position + B + rotation + C | "" + 0 + B + rotation + C
                if (pStart < rStart)
                {
                    A = line.Substring(0, pStart);
                    B = line.Substring(pEnd, rStart - pEnd);
                    C = line.Substring(rEnd);
                }
                // A + rotation + B + position + C | "" + 0 + B + position + C | "" + 0 + "" + 0 + C
                else
                {
                    A = line.Substring(0, rStart);
                    B = line.Substring(rEnd, pStart - rEnd);
                    C = line.Substring(pEnd);
                }
            }

            override public String BuildListLine() => BuildXMLLine();

            override public String BuildXMLLine() =>
                A +
                (Position.Present ? " position=\"" + Position.GetListLine(FloatFormat, FloatPoint) + "\"" : "") +
                B +
                (Rotation.Present ? " rotation=\"" + Rotation.GetListLine(FloatFormat, FloatPoint) + "\"" : "") +
                C;
        }

        private const String IniFileName = "Items.ini";
        private static readonly NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        private bool lockFilter = true;
        private String FileName = "";
        private List<FSItem> FSItems      = new List<FSItem> { };
        public  List<FSItem> FSItemsShow  = new List<FSItem> { };
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
                                   value  = rec[1];
                            // Action
                            switch (option)
                            {
                                case "File": tbFile.Text = value; break;
                                case "Filter":
                                    tvFilters.Nodes.Add(value).StateImageIndex = (rec[2] == "+") ? 1 : (rec[2] == "-") ? 2 : 0;
                                    break;
                                // PositionNFI
                                case "PositionStep"  : ReadValue.NUDDouble(nudPositionStep,   value, NFI); break;
                                case "PositionOffset": ReadValue.NUDDouble(nudPositionOffset, value, NFI); break;
                                case "PositionXMin"  : ReadValue.NUDDouble(nudPositionXMin,   value, NFI); break;
                                case "PositionXMax"  : ReadValue.NUDDouble(nudPositionXMax,   value, NFI); break;
                                case "PositionYMin"  : ReadValue.NUDDouble(nudPositionYMin,   value, NFI); break;
                                case "PositionYMax"  : ReadValue.NUDDouble(nudPositionYMax,   value, NFI); break;
                                case "PositionZMin"  : ReadValue.NUDDouble(nudPositionZMin,   value, NFI); break;
                                case "PositionZMax"  : ReadValue.NUDDouble(nudPositionZMax,   value, NFI); break;
                                case "PositionLimitX": cbLimitPositionX.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitY": cbLimitPositionY.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitZ": cbLimitPositionZ.Checked = (value.ToLower() == "true"); break;
                                // Rotation
                                case "RotationStep"  : ReadValue.NUDDouble360(nudRotationStep,   value, NFI); break;
                                case "RotationOffset": ReadValue.NUDDouble360(nudRotationOffset, value, NFI); break;
                                case "RotationXMin"  : ReadValue.NUDDouble360(nudRotationXMin,   value, NFI); break;
                                case "RotationXMax"  : ReadValue.NUDDouble360(nudRotationXMax,   value, NFI); break;
                                case "RotationYMin"  : ReadValue.NUDDouble360(nudRotationYMin,   value, NFI); break;
                                case "RotationYMax"  : ReadValue.NUDDouble360(nudRotationYMax,   value, NFI); break;
                                case "RotationZMin"  : ReadValue.NUDDouble360(nudRotationZMin,   value, NFI); break;
                                case "RotationZMax"  : ReadValue.NUDDouble360(nudRotationZMax,   value, NFI); break;
                                case "RotationLimitX": cbLimitRotationX.Checked = (value.ToLower() == "true"); break;
                                case "RotationLimitY": cbLimitRotationY.Checked = (value.ToLower() == "true"); break;
                                case "RotationLimitZ": cbLimitRotationZ.Checked = (value.ToLower() == "true"); break;
                                // Find & Replace
                                case "Find"   : tbFind   .Text = value.Replace("&#9;", "\t"); break;
                                case "Replace": tbReplace.Text = value.Replace("&#9;", "\t"); break;
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
                    file.WriteLine("ListVisibleOnly\t" + cbListVisible.Checked.ToString());
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
                FSItem item;
                FSItems.Clear();
                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                    {
                        item = new FSItem(file.ReadLine());
                        item.ListLine = item.BuildListLine();
                        FSItems.Add(item);
                    }
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
                    foreach (FSItem item in FSItems)
                    {
                        if (item.Edited) item.XMLLine = item.BuildXMLLine();
                        file.WriteLine(item.XMLLine);
                        item.Edited = false;
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
            Update_FiltersButtons();
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

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e) => UIBasics.TextBox_KeyPressLeave(sender, e, () =>
            btnFilterSave_Click((btnFilterSave.Visible) ? btnFilterSave : btnFilterAdd, null));

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            if (tvFilters.SelectedNode == null)
                btnFilterAdd.Visible = (tbFilter.Text != "");
            else
                btnFilterAdd.Visible
                    = btnFilterSave.Visible
                    = (tbFilter.Text != tvFilters.SelectedNode.Text);
        }

        private void tvFilters_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) => UIBasics.TreeView_NodeSwitchStateMouseLR(sender, e, FilterItems);

        private void tvFilters_KeyPress(object sender, KeyPressEventArgs e) => UIBasics.TreeView_KeyPressBeginEdit(sender, e);

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

        private void btnDeselect_Click       (object sender, EventArgs e) => UIBasics.TreeView_SetStates(tvFilters, 0, FilterItems);
        private void btnSelect_Click         (object sender, EventArgs e) => UIBasics.TreeView_SetStates(tvFilters, 1, FilterItems);
        private void btnInvertSelection_Click(object sender, EventArgs e) => UIBasics.TreeView_SetStates(tvFilters, 2, FilterItems);
        #endregion

        #region Items list
        private void FilterItems()//
        {
            if (lockFilter) return;
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
                        if (item.ListLine.Contains(filter.Text) == (2 == filter.StateImageIndex))
                        {
                            skip = true;
                            break;
                        }
                if (skip)
                    continue;
                if (limitP)
                {
                    if (!item.Position.Present) continue;
                    if (limitPX) if (item.Position.X < minPX || maxPX < item.Position.X) continue;
                    if (limitPY) if (item.Position.Y < minPY || maxPY < item.Position.Y) continue;
                    if (limitPZ) if (item.Position.Z < minPZ || maxPZ < item.Position.Z) continue;
                }
                if (limitR)
                {
                    if (!item.Rotation.Present) continue;
                    if (limitRX) if (item.Rotation.X < minRX || maxRX < item.Rotation.X) continue;
                    if (limitRY) if (item.Rotation.Y < minRY || maxRY < item.Rotation.Y) continue;
                    if (limitRZ) if (item.Rotation.Z < minRZ || maxRZ < item.Rotation.Z) continue;
                }
                // Allowed
                FSItemsShow.Add(item);
                item.Show = true;
            }
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void chbListVisible_CheckedChanged(object sender, EventArgs e) => Relist(true);

        public void Relist(bool force = false)
        {
            if (lockFilter) return;
            FormSHME.Main.ProjectObjects(FSItems);
            if (cbListVisible.Checked || force) // Skip if wasn't checked in first place
            {
                FSItemsShown = (cbListVisible.Checked)
                    ? FormSHME.Main.CheckObjectsVisibility(FSItemsShow, Pins).Cast<FSItem>().ToList()
                    : FSItemsShow;
                // List
                clbItems.BeginUpdate();
                clbItems.Items.Clear();
                foreach (FSItem item in FSItemsShown)
                    clbItems.Items.Add(item.ListLine);
                clbItems.EndUpdate();
            }
        }

        private void LimitFilter_ValueChanged(object sender, EventArgs e)
        {
            if (cbLimitPositionX.Checked || cbLimitPositionY.Checked || cbLimitPositionZ.Checked ||
                cbLimitRotationX.Checked || cbLimitRotationY.Checked || cbLimitRotationZ.Checked)
                FilterItems();
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e) => FilterItems();

        private void btnAlign_Click(object sender, EventArgs e)
        {
            bool changed, doLocatoin = (sender == btnPositionAlign);
            Double step   = (Double)(doLocatoin ? nudPositionStep  : nudRotationStep   ).Value;
            Double offset = (Double)(doLocatoin ? nudPositionOffset: nudRotationOffset ).Value;
            if (clbItems.CheckedIndices.Count < 1)
                return;
            clbItems.BeginUpdate();
            foreach (int i in clbItems.CheckedIndices)
            {
                if (doLocatoin) changed = FSItemsShown[i].Position.Align(step, offset, true,  false, true );
                else            changed = FSItemsShown[i].Rotation.Align(step, offset, false, true,  false);
                if (changed)
                {
                    FSItemsShown[i].Edited = true;
                    clbItems.Items[i]
                        = FSItemsShown[i].ListLine
                        = FSItemsShown[i].BuildListLine();
                }
            }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Redraw();
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
            if (clbItems.SelectedItem != null)
                tbLine.Text = clbItems.SelectedItem.ToString();
        }

        private void clbItems_MouseClick(object sender, MouseEventArgs e) => UIBasics.CheckedListBox_MouseClick(clbItems, e);

        private void btnItemsSetChecks_Click   (object sender, EventArgs e) => UIBasics.CheckedListBox_SetChecks   (clbItems, (sender == btnItemsCheckAll));
        private void btnItemsInvertChecks_Click(object sender, EventArgs e) => UIBasics.CheckedListBox_InvertChecks(clbItems);

        private void tbLine_Leave(object sender, EventArgs e)
        {
            if (clbItems.SelectedItem?.ToString() == tbLine.Text)
                return;
            int i = clbItems.SelectedIndex;
            FSItem item = FSItemsShown[i];
            item.Edited = true;
            item.DecodeXMLLine(tbLine.Text);
            clbItems.Items[i]
                = item.ListLine
                = item.BuildListLine();
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Redraw();
        }

        private void tbLine_KeyPress(object sender, KeyPressEventArgs e) => UIBasics.TextBox_KeyPressLeave(sender, e, () => tbLine_Leave(null, null));

        private void XYZIncrement(double x, double y, double z, bool doRotation)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1) return;
            FSItem item;
            clbItems.BeginUpdate();
            foreach (int i in clbItems.CheckedIndices)
            {
                item = FSItemsShown[i];
                if (doRotation) item.Rotation.Increment(x, y, z);
                else            item.Position.Increment(x, y, z);
                item.Edited = true;
                clbItems.Items[i]
                    = item.ListLine
                    = item.BuildListLine();
            }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Redraw();
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
            if (f == "") return;
            clbItems.BeginUpdate();
            for (int i = FSItemsShown.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, FSItemsShown[i].ListLine.Contains(f));
            clbItems.EndUpdate();
        }

        private void btnReplace_Click(object sender, EventArgs e)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1) return;
            String f = tbFind.Text;    if (f == "") return;
            String r = tbReplace.Text; if (f ==  r) return;
            FSItem item;
            clbItems.BeginUpdate();
            foreach (int i in clbItems.CheckedIndices)
            {
                item = FSItemsShown[i];
                item.Edited = true;
                item.DecodeXMLLine(item.ListLine.Replace(f, r));
                clbItems.Items[i]
                    = item.ListLine
                    = item.BuildListLine();
            }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = true;
            FormSHME.Main.IAC_Redraw();
        }

        private void btnItemsUnroll_Click(object sender, EventArgs e)//Ok
        {
            for (int i = FSItems.Count - 1; 0 <= i; i--)
                if (FSItems[i].Edited)
                {
                    FSItems[i].ReadXMLLine();
                    FSItems[i].ListLine = FSItems[i].BuildListLine();
                    FSItems[i].Edited = false;
                }
            clbItems.EndUpdate();
            btnItemsUnroll.Visible = false;
            FilterItems();
        }
        #endregion
    }
}