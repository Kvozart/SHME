using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.LinkLabel;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace SHME
{
    public partial class FormItems : Form
    {
        FormSHME Main;
        NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;

        public class xyzDouble
        {
            public int start = 0, end = 0;
            public double x = 0, y = 0, z = 0;

            public xyzDouble() { }

            public void Read(String line, String tag, NumberFormatInfo nfi)
            {
                start = line.ToUpper().IndexOf(tag); // position of tag
                x = y = z = 0;
                end = 0;
                if (start < 0)
                {
                    start = 0;
                    return;
                }

                int q1 = line.IndexOf('"', start) + 1; // first "
                int q2 = line.IndexOf('"', q1); // second "
                string[] v = line.Substring(q1, q2 - q1).Replace("  ", " ").Replace(',', '.').Split(' ');
                end = q2 + 1;

                if (0 < v.Length) x = Double.Parse(v[0], nfi);
                if (1 < v.Length) y = Double.Parse(v[1], nfi);
                if (2 < v.Length) z = Double.Parse(v[2], nfi);
            }

            public void Align(double step, double offset, Boolean doRotation)
            {
                if (start < 1 || step == 0)
                    return;
                if (doRotation)
                    y = Math.Round((y - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
            }

            public String Concatenate(String format, NumberFormatInfo nfi) =>
                x.ToString(format, nfi) + " " + 
                y.ToString(format, nfi) + " " + 
                z.ToString(format, nfi);
        }

        public class LineValues
        {
            NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;
            public String A = "", B = "", C = "", Text = "";
            public xyzDouble R = new xyzDouble(),
                             P = new xyzDouble();
            public bool Edited = false;

            public LineValues(String line) => Read(line, true);

            public void Read(String line = null, bool set = false)//
            {
                if (line == null) line = Text;
                if (set) Text = line;

                P.Read(line, "POSITION", NFI);
                R.Read(line, "ROTATION", NFI);

                if (R.start < P.start)
                {
                    A = line.Substring(0, R.start);
                    B = line.Substring(R.end, P.start - R.end);
                    C = line.Substring(P.end);
                }
                else // even if R = P = 0
                {
                    A = line.Substring(0, P.start);
                    B = line.Substring(P.end, R.start - P.end);
                    C = line.Substring(R.end);
                }
            }

            public String Concatenate() => //
                A + (0 < P.start 
                    ? "position=\"" + P.Concatenate("f4", NFI) + '"'
                    : "" ) +
                B + (0 < R.start 
                    ? "rotation=\"" + R.Concatenate("f4", NFI) + '"'
                    : "" ) +
                C;
        }

        private String FileName = "";
        private List<LineValues> LinesLoaded = new List<LineValues> { };
        public  List<LineValues> LinesBuffer = new List<LineValues> { };

        #region Form
        public FormItems(FormSHME main)//Ok
        {
            Main = main;
            InitializeComponent();
            OptionsLoad();
        }

        public void OptionsLoad()
        {
            try
            {
                if (File.Exists("Items.ini"))
                    using (StreamReader file = File.OpenText("Items.ini"))
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
                                case "PositionRange" : cbPositionRange.Checked = (value == "true"); break;
                                // Rotation
                                case "RotationStep"  : nudRotationStep.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationOffset": nudRotationOffset.Value = (Decimal)Double.Parse(value); break;
                                case "RotationXMin"  : nudRotationXMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationXMax"  : nudRotationXMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationYMin"  : nudRotationYMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationYMax"  : nudRotationYMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationZMin"  : nudRotationZMin.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationZMax"  : nudRotationZMax.Value   = (Decimal)Double.Parse(value); break;
                                case "RotationRange" : cbRotationRange.Checked = (value == "true"); break;
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
            if (tbFile.Text != "")
                Items_Load(tbFile.Text);
        }

        private void FormItems_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            Hide();
            e.Cancel = true;
        }

        public void OptionSave()//Ok
        {
            using (StreamWriter file = File.CreateText("Items.ini"))
            {
                file.WriteLine("File\t" + tbFile.Text);
                for (int i = 0; i < tvFilters.Nodes.Count; i++)
                    file.WriteLine("Filter\t" + tvFilters.Nodes[i].Text + "\t" + "*+-"[tvFilters.Nodes[i].StateImageIndex]);
                // Position
                file.WriteLine("PositionStep\t"   + nudPositionStep.Value);
                file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                file.WriteLine("PositionRange\t"  + cbPositionRange.Checked.ToString());
                file.WriteLine("PositionXMin\t"   + nudPositionXMin.Value); file.WriteLine("PositionXMax\t" + nudPositionXMax.Value);
                file.WriteLine("PositionYMin\t"   + nudPositionYMin.Value); file.WriteLine("PositionYMax\t" + nudPositionYMax.Value);
                file.WriteLine("PositionZMin\t"   + nudPositionZMin.Value); file.WriteLine("PositionZMax\t" + nudPositionZMax.Value);
                // Rotation
                file.WriteLine("RotationStep\t"   + nudRotationStep.Value);
                file.WriteLine("RotationOffset\t" + nudRotationOffset.Value);
                file.WriteLine("RotationRange\t"  + cbRotationRange.Checked.ToString());
                file.WriteLine("RotationXMin\t"   + nudRotationXMin.Value); file.WriteLine("RotationXMax\t" + nudRotationXMax.Value);
                file.WriteLine("RotationYMin\t"   + nudRotationYMin.Value); file.WriteLine("RotationYMax\t" + nudRotationYMax.Value);
                file.WriteLine("RotationZMin\t"   + nudRotationZMin.Value); file.WriteLine("RotationZMax\t" + nudRotationZMax.Value);
                // Find & Replace
                file.WriteLine("Find\t" + tbFind.Text.Replace("\t", "&#9;"));
                file.WriteLine("Replace\t" + tbReplace.Text.Replace("\t", "&#9;"));
                return;
            }
        }

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
                LinesLoaded.Clear();
                using (StreamReader file = File.OpenText(fileName))
                    while (!file.EndOfStream)
                        LinesLoaded.Add(new LineValues(file.ReadLine()));
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

        private void btnFileReload_Click(object sender, EventArgs e) => Items_Load(tbFile.Text);//Ok

        private void btnFileSave_Click(object sender, EventArgs e)//Ok
        {
            try
            {
                using (StreamWriter file = File.CreateText(FileName))
                    foreach (LineValues line in LinesLoaded)
                    {
                        file.WriteLine(line.Concatenate());
                    }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void Update_FiltersButtons()
        {
            btnFilterDelete.   Visible = (tvFilters.SelectedNode != null);
            btnFilterDeleteAll.Visible = (0 < tvFilters.Nodes.Count);
        }
        #endregion

        #region Filters
        private void timer_Tick(object sender, EventArgs e)
        {
            FilterItems();
            timer.Enabled = false;
        }

        private void FilterItems()//
        {
            clbLines.BeginUpdate();
            clbLines.Items.Clear();
            LinesBuffer.Clear();
            // Select
            bool skip;
            String s;
            foreach (LineValues line in LinesLoaded)
            {
                skip = false;
                s = line.Concatenate();
                foreach (TreeNode Filter in tvFilters.Nodes)
                    if (0 < Filter.StateImageIndex)
                        if (s.Contains(Filter.Text) == (2 == Filter.StateImageIndex))
                        {
                            skip = true;
                            break;
                        }
                if (skip)
                    continue;
                if (cbPositionRange.Checked)
                    if (line.P.x < (Double)nudPositionXMin.Value || (Double)nudPositionXMax.Value < line.P.x ||
                        line.P.y < (Double)nudPositionYMin.Value || (Double)nudPositionYMax.Value < line.P.y ||
                        line.P.z < (Double)nudPositionZMin.Value || (Double)nudPositionZMax.Value < line.P.z)
                        continue;
                if (cbRotationRange.Checked)
                    if (line.R.x < (Double)nudRotationXMin.Value || (Double)nudRotationXMax.Value < line.R.x ||
                        line.R.y < (Double)nudRotationYMin.Value || (Double)nudRotationYMax.Value < line.R.y ||
                        line.R.z < (Double)nudRotationZMin.Value || (Double)nudRotationZMax.Value < line.R.z)
                        continue;
                // Allowed
                LinesBuffer.Add(line);
                clbLines.Items.Add(s);
            }
            clbLines.EndUpdate();
            Main.Canvas_Update();
        }

        private void btnFilterAdd_Click(object sender, EventArgs e)//Ok
        {
            TreeNode tn = tvFilters.Nodes.Add(tbFilter.Text);
            tn.StateImageIndex = 1;
            tvFilters.SelectedNode = tn;
        }

        private void btnFilterDelete_Click(object sender, EventArgs e)//Ok
        {
            tvFilters.SelectedNode.Remove();
            Update_FiltersButtons();
            FilterItems();
        }

        private void btnFilterDeleteAll_Click(object sender, EventArgs e)//Ok
        {
            tvFilters.Nodes.Clear();
            Update_FiltersButtons();
            FilterItems();
        }

        private void tvFilters_AfterSelect(object sender, TreeViewEventArgs e)//Ok
        {
            tbFilter.Text = tvFilters.SelectedNode.Text;
            Update_FiltersButtons();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)//Ok
        {
            if (e.KeyChar != '\r')
                return;
            if (tvFilters.SelectedNode == null)
                btnFilterAdd_Click(null, null);
            else
            {
                tvFilters.SelectedNode.Text = tbFilter.Text;
                FilterItems();
            }
            e.Handled = true;
        }

        private void RangeFilter_Click(object sender, EventArgs e) => FilterItems();
        private void PositionRange_Change(object sender, EventArgs e) { if (cbPositionRange.Checked) FilterItems(); }
        private void RotationRange_Change(object sender, EventArgs e) { if (cbRotationRange.Checked) FilterItems(); }

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
            if (e.KeyChar == '\r')
            {
                (sender as TreeView).SelectedNode.BeginEdit();
                e.Handled = true;
            }
        }

        private void tvFilters_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) => timer.Enabled = true;

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

        #region Lines
        private void btnPositionAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudPositionStep.Value;
            Double offset = (Double)nudPositionOffset.Value;
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                LinesBuffer[i].P.Align(step, offset, false);
                clbLines.Items[i] = LinesBuffer[i].Concatenate();
                LinesBuffer[i].Edited = true;
            }
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void btnRotationAlign_Click(object sender, EventArgs e)
        {
            Double step   = (Double)nudRotationStep.Value;
            Double offset = (Double)nudRotationOffset.Value;
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                LinesBuffer[i].R.Align(step, offset, true);
                clbLines.Items[i] = LinesBuffer[i].Concatenate();
                LinesBuffer[i].Edited = true;
            }
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void nudPositionStep_ValueChanged(object sender, EventArgs e) =>
            nudPositionXMin.Increment = nudPositionXMax.Increment =
            nudPositionYMin.Increment = nudPositionYMax.Increment =
            nudPositionZMin.Increment = nudPositionZMax.Increment = nudPositionStep.Value;

        private void nudRotationStep_ValueChanged(object sender, EventArgs e) =>
            nudRotationXMin.Increment = nudRotationXMax.Increment =
            nudRotationYMin.Increment = nudRotationYMax.Increment =
            nudRotationZMin.Increment = nudRotationZMax.Increment = nudRotationStep.Value;

        private void clbLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbLine.Enabled && clbLines.SelectedItem != null)
                tbLine.Text = clbLines.SelectedItem.ToString();
        }

        private void clbLines_MouseClick(object sender, MouseEventArgs e)
        {
            if (20 < e.X && 0 <= clbLines.SelectedIndex)
                clbLines.SetItemChecked(clbLines.SelectedIndex, !clbLines.GetItemChecked(clbLines.SelectedIndex));
        }

        private void btnLinesCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = clbLines.Items.Count - 1; 0 <= i; i--)
                clbLines.SetItemChecked(i, true);
        }

        private void btnLinesUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = clbLines.Items.Count - 1; 0 <= i; i--)
                clbLines.SetItemChecked(i, false);
        }

        private void tbLine_Leave(object sender, EventArgs e)
        {
            if (clbLines.SelectedItem?.ToString() == tbLine.Text)
                return;
            int i = clbLines.SelectedIndex;
            clbLines.Items[i] = tbLine.Text;
            LinesBuffer[i].Read(tbLine.Text);
            LinesBuffer[i].Edited = true;
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void tbLine_KeyPress(object sender, KeyPressEventArgs e)//Ok
        {
            if (e.KeyChar != '\r')
                return;
            tbLine_Leave(null, null);
            e.Handled = true;
        }

        private void PositionIncrement(double x, double y, double z)//Ok
        {
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                LinesBuffer[i].P.x += x;
                LinesBuffer[i].P.y += y;
                LinesBuffer[i].P.z += z;
                clbLines.Items[i] = LinesBuffer[i].Concatenate();
                LinesBuffer[i].Edited = true;
            }
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void RotationIncrement(double x, double y, double z)//Ok
        {
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                LinesBuffer[i].R.x += x;
                LinesBuffer[i].R.y += y;
                LinesBuffer[i].R.z += z;
                clbLines.Items[i] = LinesBuffer[i].Concatenate();
                LinesBuffer[i].Edited = true;
            }
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void btnPositionXsub_Click(object sender, EventArgs e) => PositionIncrement(-(Double)nudPositionStep.Value, 0, 0);
        private void btnPositionXadd_Click(object sender, EventArgs e) => PositionIncrement( (Double)nudPositionStep.Value, 0, 0);
        private void btnPositionYsub_Click(object sender, EventArgs e) => PositionIncrement(0, -(Double)nudPositionStep.Value, 0);
        private void btnPositionYadd_Click(object sender, EventArgs e) => PositionIncrement(0,  (Double)nudPositionStep.Value, 0);
        private void btnPositionZsub_Click(object sender, EventArgs e) => PositionIncrement(0, 0, -(Double)nudPositionStep.Value);
        private void btnPositionZadd_Click(object sender, EventArgs e) => PositionIncrement(0, 0,  (Double)nudPositionStep.Value);

        private void btnRotationXsub_Click(object sender, EventArgs e) => RotationIncrement(-(Double)nudRotationStep.Value, 0, 0);
        private void btnRotationXadd_Click(object sender, EventArgs e) => RotationIncrement( (Double)nudRotationStep.Value, 0, 0);
        private void btnRotationYsub_Click(object sender, EventArgs e) => RotationIncrement(0, -(Double)nudRotationStep.Value, 0);
        private void btnRotationYadd_Click(object sender, EventArgs e) => RotationIncrement(0,  (Double)nudRotationStep.Value, 0);
        private void btnRotationZsub_Click(object sender, EventArgs e) => RotationIncrement(0, 0, -(Double)nudRotationStep.Value);
        private void btnRotationZadd_Click(object sender, EventArgs e) => RotationIncrement(0, 0,  (Double)nudRotationStep.Value);

        private void btnFind_Click(object sender, EventArgs e)//Ok
        {
            for (int i = LinesBuffer.Count - 1; 0 <= i; i--)
                clbLines.SetItemChecked(i, clbLines.Items[i].ToString().Contains(tbFind.Text));
        }

        private void btnFindAndReplace_Click(object sender, EventArgs e)//Ok
        {
            if (clbLines.CheckedIndices.Count < 1)
                return;
            String s;
            foreach (int i in clbLines.CheckedIndices)
            {
                clbLines.Items[i] = s = clbLines.Items[i].ToString().Replace(tbFind.Text, tbReplace.Text);
                LinesBuffer[i].Read(s);
                LinesBuffer[i].Edited = true;
            }
            btnLinesReload.Visible = true;
            Main.Canvas_Update();
        }

        private void btnLinesReload_Click(object sender, EventArgs e)//Ok
        {
            clbLines.BeginUpdate();
            for (int i = LinesBuffer.Count - 1; 0 <= i; i--)
                if (LinesBuffer[i].Edited)
                    clbLines.Items[i] = LinesBuffer[i].Text;
            clbLines.EndUpdate();
            // Reset lines
            for (int i = LinesLoaded.Count - 1; 0 <= i; i--)
                if (LinesLoaded[i].Edited)
                {
                    LinesLoaded[i].Read();
                    LinesLoaded[i].Edited = false;
                }
            btnLinesReload.Visible = false;
            Main.Canvas_Update();
        }
        #endregion
    }
}