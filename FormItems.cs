using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormItems : Form
    {
        public class TagValues
        {
            NumberFormatInfo NFI = new CultureInfo("en-US", false).NumberFormat;
            public String Before = "", After = "";
            public double x = 0, y = 0, z = 0;

            public TagValues() { }

            public TagValues(String line, String tag) => Read(line, tag);

            public void Read(String line, String tag)
            {
                int t = line.ToUpper().IndexOf(tag); // position of tag
                x = y = z = 0;
                if (t < 0)
                {
                    Before = line;
                    After = "";
                    return;
                }
                int p = line.IndexOf('"', t) + 1; // first "
                int c = line.IndexOf('"', p); // second "

                Before = line.Substring(0, p);
                After = line.Substring(c);

                string[] v = line.Substring(p, c - p).Replace("  ", " ").Replace(',', '.').Split(' ');
                if (0 < v.Length) x = Double.Parse(v[0], NFI);
                if (1 < v.Length) y = Double.Parse(v[1], NFI);
                if (2 < v.Length) z = Double.Parse(v[2], NFI);
            }

            public void AlignValues(double step, double offset, Boolean doY)
            {
                if (After == "" || step == 0)
                    return;
                if (doY)
                    y = Math.Round((y - offset) / step) * step + offset;
                else
                {
                    x = Math.Round((x - offset) / step) * step + offset;
                    z = Math.Round((z - offset) / step) * step + offset;
                }
            }

            public String Concatenate() => (After == "") ? Before : Before + x.ToString("f4", NFI) + " " + y.ToString("f4", NFI) + " " + z.ToString("f4", NFI) + After;
        }

        String FileName = "";
        List<String> Lines   = new List<String> { };
        List<String> FLines  = new List<String> { };
        List<Int32>  Entries = new List<Int32>  { };
        TagValues tv = new TagValues();

        public FormItems()
        {
            InitializeComponent();

            // Load options
            try
            {
                if (File.Exists("FormItems.ini"))
                    using (StreamReader file = File.OpenText("FormItems.ini"))
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
                                    tvFilters.Nodes.Add(value).StateImageIndex = (rec[2] == "+")? 1 : (rec[2] == "-") ? 2 : 0;
                                    break;
                                // Position
                                case "PositionStep"  : nudPositionStep.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionOffset": nudPositionOffset.Value = (Decimal)Double.Parse(value); break;
                                case "PositionXMin"  : nudPositionXMin.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionXMax"  : nudPositionXMax.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionYMin"  : nudPositionYMin.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionYMax"  : nudPositionYMax.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionZMin"  : nudPositionZMin.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionZMax"  : nudPositionZMax.  Value = (Decimal)Double.Parse(value); break;
                                case "PositionRange" :  cbPositionRange.Checked= (value == "true"); break;
                                // Rotation
                                case "RotationStep"  : nudRotationStep.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationOffset": nudRotationOffset.Value = (Decimal)Double.Parse(value); break;
                                case "RotationXMin"  : nudRotationXMin.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationXMax"  : nudRotationXMax.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationYMin"  : nudRotationYMin.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationYMax"  : nudRotationYMax.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationZMin"  : nudRotationZMin.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationZMax"  : nudRotationZMax.  Value = (Decimal)Double.Parse(value); break;
                                case "RotationRange" :  cbRotationRange.Checked= (value == "true"); break;
                                // Find & Replace
                                case "Find"   : tbFind   .Text = value.Replace("&#9;", "\t"); break;
                                case "Replace": tbReplace.Text = value.Replace("&#9;", "\t"); break;
                                default:
                                    break;
                            }
                        }
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
            btnFilterDeleteAll.Visible = (0 < tvFilters.Nodes.Count);
            nudPositionStep_ValueChanged(null, null);
            nudRotationStep_ValueChanged(null, null);

            // Load file to edit
            if (tbFile.Text != "")
                FileLoad();
        }

        private void FormItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter file = File.CreateText("FormItems.ini"))
            {
                file.WriteLine("File\t" + tbFile.Text);
                for (int i = 0; i < tvFilters.Nodes.Count; i++)
                    file.WriteLine("Filter\t" + tvFilters.Nodes[i].Text + "\t" + "*+-"[tvFilters.Nodes[i].StateImageIndex]);
                // Position
                file.WriteLine("PositionStep\t"   + nudPositionStep  .Value);
                file.WriteLine("PositionOffset\t" + nudPositionOffset.Value);
                file.WriteLine("PositionRange\t"  + cbPositionRange.Checked.ToString());
                file.WriteLine("PositionXMin\t"   + nudPositionXMin.Value);    file.WriteLine("PositionXMax\t" + nudPositionXMax.Value);
                file.WriteLine("PositionYMin\t"   + nudPositionYMin.Value);    file.WriteLine("PositionYMax\t" + nudPositionYMax.Value);
                file.WriteLine("PositionZMin\t"   + nudPositionZMin.Value);    file.WriteLine("PositionZMax\t" + nudPositionZMax.Value);
                // Rotation
                file.WriteLine("RotationStep\t"   + nudRotationStep  .Value);
                file.WriteLine("RotationOffset\t" + nudRotationOffset.Value);
                file.WriteLine("RotationRange\t"  + cbRotationRange.Checked.ToString());
                file.WriteLine("RotationXMin\t"   + nudRotationXMin.Value);    file.WriteLine("RotationXMax\t" + nudRotationXMax.Value);
                file.WriteLine("RotationYMin\t"   + nudRotationYMin.Value);    file.WriteLine("RotationYMax\t" + nudRotationYMax.Value);
                file.WriteLine("RotationZMin\t"   + nudRotationZMin.Value);    file.WriteLine("RotationZMax\t" + nudRotationZMax.Value);
                // Find & Replace
                file.WriteLine("Find\t"    + tbFind   .Text.Replace("\t", "&#9;"));
                file.WriteLine("Replace\t" + tbReplace.Text.Replace("\t", "&#9;"));
            }
            Hide();
            e.Cancel = true;
        }

        private void btnFileLoad_Click(object sender, EventArgs e)
        {
            dlgOpen.FileName = Path.GetFileName(tbFile.Text);
            if (tbFile.Text != "")
                dlgOpen.InitialDirectory = Path.GetFullPath(tbFile.Text).Replace(Path.GetFileName(tbFile.Text), "");
            if (dlgOpen.ShowDialog() != DialogResult.OK)
                return;
            tbFile.Text = dlgOpen.FileName;
            FileLoad();
        }

        private void FileLoad()
        {
            List<String> lines = new List<String> { };
            try
            {
                using (StreamReader file = File.OpenText(tbFile.Text))
                    while (!file.EndOfStream)
                        lines.Add(file.ReadLine());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
            // Successful
            FileName = tbFile.Text;
            Lines = lines;
            FilterLines();
        }

        private void button1_Click(object sender, EventArgs e) => FileLoad();

        private void btnFileSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter file = File.CreateText(FileName))
                    foreach (String s in Lines)
                        file.WriteLine(s);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #region Filters
        private void timer_Tick(object sender, EventArgs e)
        {
            FilterLines();
            timer.Enabled = false;
        }

        private void FilterLines()
        {
            clbLines.BeginUpdate();
            clbLines.Items.Clear();
            FLines.Clear();
            Entries.Clear();
            // Select
            for (int i = 0; i < Lines.Count; i++)
            {
                bool add = true;
                foreach (TreeNode Filter in tvFilters.Nodes)
                    if (0 < Filter.StateImageIndex)
                        if (Lines[i].Contains(Filter.Text) == (2 == Filter.StateImageIndex))
                        {
                            add = false;
                            break;
                        }
                if (cbPositionRange.Checked)
                {
                    tv.Read(Lines[i], "POSITION");
                    if (tv.x < (Double)nudPositionXMin.Value || (Double)nudPositionXMax.Value < tv.x ||
                        tv.y < (Double)nudPositionYMin.Value || (Double)nudPositionYMax.Value < tv.y ||
                        tv.z < (Double)nudPositionZMin.Value || (Double)nudPositionZMax.Value < tv.z)
                        add = false;
                }
                if (cbRotationRange.Checked)
                {
                    tv.Read(Lines[i], "ROTATION");
                    if (tv.x < (Double)nudRotationXMin.Value || (Double)nudRotationXMax.Value < tv.x ||
                        tv.y < (Double)nudRotationYMin.Value || (Double)nudRotationYMax.Value < tv.y ||
                        tv.z < (Double)nudRotationZMin.Value || (Double)nudRotationZMax.Value < tv.z)
                        add = false;
                }
                if (!add)
                    continue;
                // Allowed
                Entries.Add(i);
                FLines.Add(Lines[i]);
                clbLines.Items.Add(Lines[i]);
            }
            clbLines.EndUpdate();
        }

        private void btnFilterAdd_Click(object sender, EventArgs e)
        {
            tvFilters.Nodes.Add(tbFilter.Text).StateImageIndex = 1;
            FilterLines();
        }

        private void btnFilterDelete_Click(object sender, EventArgs e)
        {
            tvFilters.SelectedNode.Remove();
            btnFilterDelete.   Visible = (tvFilters.SelectedNode != null);
            btnFilterDeleteAll.Visible = (0 < tvFilters.Nodes.Count);
            FilterLines();
        }

        private void btnFilterDeleteAll_Click(object sender, EventArgs e)
        {
            tvFilters.Nodes.Clear();
            btnFilterDelete.   Visible =
            btnFilterDeleteAll.Visible = false;
            FilterLines();
        }

        private void tvFilters_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnFilterDelete.Visible = (tvFilters.SelectedNode != null);
            tbFilter.Text = tvFilters.SelectedNode.Text;
        }

        private void btnFilterLines_Click(object sender, EventArgs e) => FilterLines();
        private void PositionRange_Change(object sender, EventArgs e) { if (cbPositionRange.Checked) FilterLines(); }
        private void RotationRange_Change(object sender, EventArgs e) { if (cbRotationRange.Checked) FilterLines(); }

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
            FilterLines();
        }

        private void btnDeselect_Click       (object sender, EventArgs e) { foreach (TreeNode Node in tvFilters.Nodes) Node.StateImageIndex = 0; FilterLines(); }
        private void btnSelect_Click         (object sender, EventArgs e) { foreach (TreeNode Node in tvFilters.Nodes) Node.StateImageIndex = 1; FilterLines(); }
        private void btnInvertSelection_Click(object sender, EventArgs e) { foreach (TreeNode Node in tvFilters.Nodes) Node.StateImageIndex = 2; FilterLines(); }
        #endregion

        #region Filtered Lines
        private void AlignLines(string tag, Double step, Double offset, Boolean doY)
        {
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                tv.Read(FLines[i], tag); // Get stored line
                tv.AlignValues(step, offset, doY);
                clbLines.Items[i] = FLines[i] = tv.Concatenate();
            }
            btnLinesReload.Visible =
            btnLinesSave.  Visible = true;
        }

        private void btnPositionAlign_Click(object sender, EventArgs e) => AlignLines("POSITION", (Double)nudPositionStep.Value, (Double)nudPositionOffset.Value, false);
        private void btnRotationAlign_Click(object sender, EventArgs e) => AlignLines("ROTATION", (Double)nudRotationStep.Value, (Double)nudRotationOffset.Value, true);

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
            tbLine.Enabled = false;
            int fi = clbLines.SelectedIndex;
            clbLines.Items[fi] =
            Lines[Entries[fi]] =
            FLines[fi]         = tbLine.Text;
            tbLine.Enabled = true;
        }

        private void tbLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            tbLine_Leave(null, null);
            e.Handled = true;
        }

        private void ValueXYZIncrement(String tag, double x, double y, double z)
        {
            if (clbLines.CheckedIndices.Count < 1)
                return;
            foreach (int i in clbLines.CheckedIndices)
            {
                tv.Read(FLines[i], tag); // Get stored line
                tv.x += x;
                tv.y += y;
                tv.z += z;
                clbLines.Items[i] = FLines[i] = tv.Concatenate();
            }
            btnLinesReload.Visible =
            btnLinesSave.  Visible = true;
        }

        private void btnPositionXsub_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION", -(Double)nudPositionStep.Value, 0, 0);
        private void btnPositionXadd_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION",  (Double)nudPositionStep.Value, 0, 0);
        private void btnPositionYsub_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION", 0, -(Double)nudPositionStep.Value, 0);
        private void btnPositionYadd_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION", 0,  (Double)nudPositionStep.Value, 0);
        private void btnPositionZsub_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION", 0, 0, -(Double)nudPositionStep.Value);
        private void btnPositionZadd_Click(object sender, EventArgs e) => ValueXYZIncrement("POSITION", 0, 0,  (Double)nudPositionStep.Value);

        private void btnRotationXsub_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION", -(Double)nudRotationStep.Value, 0, 0);
        private void btnRotationXadd_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION",  (Double)nudRotationStep.Value, 0, 0);
        private void btnRotationYsub_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION", 0, -(Double)nudRotationStep.Value, 0);
        private void btnRotationYadd_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION", 0,  (Double)nudRotationStep.Value, 0);
        private void btnRotationZsub_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION", 0, 0, -(Double)nudRotationStep.Value);
        private void btnRotationZadd_Click(object sender, EventArgs e) => ValueXYZIncrement("ROTATION", 0, 0,  (Double)nudRotationStep.Value);

        private void btnFind_Click(object sender, EventArgs e)
        {
            for (int i = FLines.Count - 1; 0 <= i; i--)
                clbLines.SetItemChecked(i, FLines[i].Contains(tbFind.Text));
        }

        private void btnFindAndReplace_Click(object sender, EventArgs e)
        {
            foreach (int i in clbLines.CheckedIndices)
                clbLines.Items[i] =
                Lines[Entries[i]] =
                FLines[i] = FLines[i].Replace(tbFind.Text, tbReplace.Text);
        }

        private void btnLinesSave_Click(object sender, EventArgs e)
        {
            for (int i = clbLines.Items.Count - 1; 0 <= i; i--)
                Lines[Entries[i]] = FLines[i] = clbLines.Items[i].ToString();
            btnLinesReload.Visible =
            btnLinesSave.  Visible = false;
        }

        private void btnLinesReload_Click(object sender, EventArgs e)
        {
            for (int i = FLines.Count - 1; 0 <= i; i--)
                clbLines.Items[i] = FLines[i] = Lines[Entries[i]];
            btnLinesReload.Visible =
            btnLinesSave.  Visible = false;
        }
        #endregion
    }
}
