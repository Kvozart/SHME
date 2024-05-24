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
        private const String IniFileName = "Items.ini";
        private const String FloatFormat = "f4";

        public static FSPins Pins = new FSPins(11, 11, 5, 5,
            new int[][]{
                // 0 - Default
                new int[] {
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F000000, 0x7F000000, 0x7F000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000, 0x00000000, 0x00000000,
                    0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000,
                    0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000,
                    0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000,
                    0x7F000000, 0x7FFFFF00, 0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7F000000,
                    0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000,
                    0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000,
                    0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7FFFFF00, 0x7FFFFF00, 0x7FFFFF00, 0x7F000000, 0x7F000000,
                    0x00000000, 0x00000000, 0x7F000000, 0x7F000000, 0x7FFFFF00, 0x7F000000, 0x7FFFFF00, 0x7F000000, 0x7F000000, 0x00000000, 0x00000000,
                    0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F000000, 0x7F000000, 0x7F000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000}
            },
            // Selection
            new int[] {
                0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7FFFFFFF,
                0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF, 0x7FFFFFFF},
            // Checking
            new int[] {
                0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x7F7F7F7F,
                0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F, 0x7F7F7F7F},
            null
            );

        public class FSItem : FSObjectString
        {

            public String A = "", B = "", C = "";
            public XYZRDouble Rotation = new XYZRDouble();

            public FSItem(String line) : base(line) { }

            override public void DecodeXMLLine(String line)
            {
                String tmp;
                int pStart, rStart;
                if (Position.Present = (0 < (pStart = ReadValue.TagsAttribute(line, "position", out tmp, out int pEnd)))) Position.ReadXMLLine(tmp);
                if (Rotation.Present = (0 < (rStart = ReadValue.TagsAttribute(line, "rotation", out tmp, out int rEnd)))) Rotation.ReadXMLLine(tmp);
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

            override public String BuildListLine() =>
                A +
                (Position.Present ? " position=\"" + Position.GetListLine(FloatFormat) + "\"" : "") +
                B +
                (Rotation.Present ? " rotation=\"" + Rotation.GetListLine(FloatFormat) + "\"" : "") +
                C;
        }

        private bool postpondListing = false;
        private bool lockFilter = true;
        private String FileName = "";
        private List<FSItem> FSItems = new List<FSItem> { };
        public List<FSItem> FSItemsShow = new List<FSItem> { };
        public List<FSItem> FSItemsShown = new List<FSItem> { };
        private FSItem SelectedFSItem = null;

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
                                case "PositionStep"  : ReadValue.NUDDouble(nudPositionStep,   value); break;
                                case "PositionOffset": ReadValue.NUDDouble(nudPositionOffset, value); break;
                                case "PositionXMin"  : ReadValue.NUDDouble(nudPositionXMin,   value); break;
                                case "PositionXMax"  : ReadValue.NUDDouble(nudPositionXMax,   value); break;
                                case "PositionYMin"  : ReadValue.NUDDouble(nudPositionYMin,   value); break;
                                case "PositionYMax"  : ReadValue.NUDDouble(nudPositionYMax,   value); break;
                                case "PositionZMin"  : ReadValue.NUDDouble(nudPositionZMin,   value); break;
                                case "PositionZMax"  : ReadValue.NUDDouble(nudPositionZMax,   value); break;
                                case "PositionLimitX": cbLimitPositionX.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitY": cbLimitPositionY.Checked = (value.ToLower() == "true"); break;
                                case "PositionLimitZ": cbLimitPositionZ.Checked = (value.ToLower() == "true"); break;
                                // Rotation
                                case "RotationStep"  : ReadValue.NUDDouble360(nudRotationStep,   value); break;
                                case "RotationOffset": ReadValue.NUDDouble360(nudRotationOffset, value); break;
                                case "RotationXMin"  : ReadValue.NUDDouble360(nudRotationXMin,   value); break;
                                case "RotationXMax"  : ReadValue.NUDDouble360(nudRotationXMax,   value); break;
                                case "RotationYMin"  : ReadValue.NUDDouble360(nudRotationYMin,   value); break;
                                case "RotationYMax"  : ReadValue.NUDDouble360(nudRotationYMax,   value); break;
                                case "RotationZMin"  : ReadValue.NUDDouble360(nudRotationZMin,   value); break;
                                case "RotationZMax"  : ReadValue.NUDDouble360(nudRotationZMax,   value); break;
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
                    file.WriteLine("PositionStep\t"   + nudPositionStep  .Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionOffset\t" + nudPositionOffset.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionLimitX\t" + cbLimitPositionX.Checked.ToString());
                    file.WriteLine("PositionLimitY\t" + cbLimitPositionY.Checked.ToString());
                    file.WriteLine("PositionLimitZ\t" + cbLimitPositionZ.Checked.ToString());
                    file.WriteLine("PositionXMin\t"   + nudPositionXMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionXMax\t"   + nudPositionXMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionYMin\t"   + nudPositionYMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionYMax\t"   + nudPositionYMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionZMin\t"   + nudPositionZMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("PositionZMax\t"   + nudPositionZMax.Value.ToString(ReadValue.FloatPoint));
                    // Rotation
                    file.WriteLine("RotationStep\t"   + nudRotationStep  .Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationOffset\t" + nudRotationOffset.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationLimitX\t" + cbLimitRotationX.Checked.ToString());
                    file.WriteLine("RotationLimitY\t" + cbLimitRotationY.Checked.ToString());
                    file.WriteLine("RotationLimitZ\t" + cbLimitRotationZ.Checked.ToString());
                    file.WriteLine("RotationXMin\t"   + nudRotationXMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationXMax\t"   + nudRotationXMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationYMin\t"   + nudRotationYMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationYMax\t"   + nudRotationYMax.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationZMin\t"   + nudRotationZMin.Value.ToString(ReadValue.FloatPoint));
                    file.WriteLine("RotationZMax\t"   + nudRotationZMax.Value.ToString(ReadValue.FloatPoint));
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
                        FSItems.Add(item = new FSItem(file.ReadLine()));
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
                        file.WriteLine(item.GetXMLLine());
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
            // Select
            TreeNode filter;
            int i, nodesCount = tvFilters.Nodes.Count - 1;
            List<String> filtersInc = new List<String>();
            List<String> filtersExc = new List<String>();
            for (i = nodesCount; 0 <= i; i--)
            {
                filter = tvFilters.Nodes[i];
                if (1 == filter.StateImageIndex) filtersInc.Add(filter.Text);
                if (2 == filter.StateImageIndex) filtersExc.Add(filter.Text);
            }
            int incN = filtersInc.Count - 1,
                excN = filtersExc.Count - 1;
            String line;
            FSItem item;
            XYZRDouble p, r;
            int idx, n = FSItems.Count;
            for (idx = 0; idx < n; idx++)
            {
                item = FSItems[idx];
                item.Show = false;
                line = item.XMLLine;
                for (i = excN; 0 <= i; i--)    if ( line.Contains(filtersExc[i])) break;    if (0 <= i) continue;
                for (i = incN; 0 <= i; i--)    if (!line.Contains(filtersInc[i])) break;    if (0 <= i) continue;
                if (limitP)
                {
                    p = item.Position;
                    if (!p.Present) continue;
                    if (limitPX) if (p.X < minPX || maxPX < p.X) continue;
                    if (limitPY) if (p.Y < minPY || maxPY < p.Y) continue;
                    if (limitPZ) if (p.Z < minPZ || maxPZ < p.Z) continue;
                }
                if (limitR)
                {
                    r = item.Rotation;
                    if (!r.Present) continue;
                    if (limitRX) if (r.X < minRX || maxRX < r.X) continue;
                    if (limitRY) if (r.Y < minRY || maxRY < r.Y) continue;
                    if (limitRZ) if (r.Z < minRZ || maxRZ < r.Z) continue;
                }
                // Allowed
                FSItemsShow.Add(item);
                item.Show = true;
            }
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void chbListVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (lockFilter) return;
            Relist(true);
            FormSHME.Main.IAC_Redraw();
        }

        private void tListTimeout_Tick(object sender, EventArgs e)
        {
            if (postpondListing)
            {
                ListItems();
                postpondListing = false;
            }
            tListTimeout.Enabled = false;
        }

        public void Relist(bool force = false)
        {
            FormSHME.Main.ProjectObjects(FSItems);
            if (cbListVisible.Checked || force) // Skip if wasn't checked in first place
            {
                // Mark visibility
                FSItemsShown = (cbListVisible.Checked)
                    ? FormSHME.Main.CheckObjectsVisibility(FSItemsShow, Pins).Cast<FSItem>().ToList()
                    : FSItemsShow;
                // Uncheck unvisible
                for (int i = FSItems.Count - 1; 0 <= i; i--)
                    FSItems[i].Checked &= FSItems[i].Shown;
                // List or postpond
                if (tListTimeout.Enabled)
                    postpondListing = true;
                else
                {
                    ListItems();
                    tListTimeout.Enabled = true; // Set timeout
                }
            }
        }

        public void ListItems()
        {
            clbItems.BeginUpdate();
            clbItems.Items.Clear();
            int si = FSItemsShown.Count;
            for (int i = 0; i < si; i++)
            {
                clbItems.Items.Add(FSItemsShown[i].XMLLine, FSItemsShown[i].Checked);
                if (FSItemsShown[i].Selected)
                    clbItems.SelectedIndex = i;
            }
            clbItems.EndUpdate();
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
            if (clbItems.CheckedIndices.Count < 1) return;
            bool doLocatoin = (sender == btnPositionAlign);
            Double step   = (Double)(doLocatoin ? nudPositionStep  : nudRotationStep  ).Value;
            Double offset = (Double)(doLocatoin ? nudPositionOffset: nudRotationOffset).Value;
            clbItems.BeginUpdate();
            FSItem item;
            for (int i = clbItems.CheckedIndices.Count - 1; 0 <= i; i--)
            {
                item = FSItemsShown[clbItems.CheckedIndices[i]];
                if ((doLocatoin) ? item.Position.Align(step, offset, true,  false, true )
                                 : item.Rotation.Align(step, offset, false, true,  false))
                {
                    item.Edited = true;
                    item.GetXMLLine();
                }
            }
            clbItems.EndUpdate();
            FilterItems();
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
            if (SelectedFSItem != null) SelectedFSItem.Selected = false;
            if (clbItems.SelectedItem != null)
            {
                SelectedFSItem = FSItemsShown[clbItems.SelectedIndex];
                SelectedFSItem.Selected = true;
                tbLine.Text = SelectedFSItem.XMLLine;
            }
            else
                tbLine.Text = "";
            FormSHME.Main.IAC_Redraw();
        }

        private void clbItems_MouseClick(object sender, MouseEventArgs e)
        {
            int i = clbItems.SelectedIndex;
            if (0 <= i)
            {
                bool newChecked = clbItems.GetItemChecked(i);
                if (20 < e.X) clbItems.SetItemChecked(i, !(FSItemsShown[i].Checked =  newChecked));
                else                                       FSItemsShown[i].Checked = !newChecked;
                FormSHME.Main.IAC_Redraw();
            }
        }

        private void btnItemsSetChecks_Click   (object sender, EventArgs e)
        {
            bool newChecked = (sender == btnItemsCheckAll);
            for (int i = clbItems.Items.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, FSItemsShown[i].Checked = newChecked);
            FormSHME.Main.IAC_Redraw();
        }

        private void btnItemsInvertChecks_Click(object sender, EventArgs e)
        {
            for (int i = clbItems.Items.Count - 1; 0 <= i; i--)
                clbItems.SetItemChecked(i, FSItemsShown[i].Checked = !clbItems.GetItemChecked(i));
            FormSHME.Main.IAC_Redraw();
        }

        private void tbLine_Leave(object sender, EventArgs e)
        {
            if (clbItems.SelectedItem?.ToString() == tbLine.Text) return;
            int li = clbItems.SelectedIndex;
            FSItem item = FSItemsShown[li];
            item.Edited = true;
            item.DecodeXMLLine(tbLine.Text);
            clbItems.Items[li] = item.GetXMLLine();
            FormSHME.Main.ProjectObjects(new List<FSObject>() {item});
            FormSHME.Main.IAC_Redraw();
        }

        private void tbLine_KeyPress(object sender, KeyPressEventArgs e) => UIBasics.TextBox_KeyPressLeave(sender, e, () => tbLine_Leave(null, null));

        private void XYZIncrement(double x, double y, double z, bool doRotation)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1) return;
            clbItems.BeginUpdate();
            FSItem item;
            int li;
            for (int i = clbItems.CheckedIndices.Count - 1; 0 <= i; i--)
            {
                li = clbItems.CheckedIndices[i];
                item = FSItemsShown[li];
                if (doRotation) item.Rotation.Increment(x, y, z);
                else            item.Position.Increment(x, y, z);
                item.Edited = true;
                clbItems.Items[li] = item.GetXMLLine();
            }
            clbItems.EndUpdate();
            FormSHME.Main.ProjectObjects(FSItemsShown);
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
                clbItems.SetItemChecked(i, FSItemsShown[i].XMLLine.Contains(f));
            clbItems.EndUpdate();
        }

        private void btnReplace_Click(object sender, EventArgs e)//Ok
        {
            if (clbItems.CheckedIndices.Count < 1) return;
            String f = tbFind.Text;    if (f == "") return;
            String r = tbReplace.Text; if (f ==  r) return;
            clbItems.BeginUpdate();
            FSItem item;
            for (int i = clbItems.CheckedIndices.Count - 1; 0 <= i; i--)
            {
                item = FSItemsShown[i];
                item.Edited = true;
                item.DecodeXMLLine(item.XMLLine.Replace(f, r));
                item.GetXMLLine();
            }
            clbItems.EndUpdate();
            FilterItems();
        }
        #endregion
    }
}