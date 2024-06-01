using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace SHME
{
    public static class ReadValue
    {
        public static readonly NumberFormatInfo FloatPoint = new CultureInfo("en-US", false).NumberFormat;

        public static void NUDInteger(NumericUpDown nud, String s)
        {
            Int32.TryParse(s, out int d);
            Decimal v = (Decimal)d;
            nud.Value = (nud.Maximum < v) ? nud.Maximum
                      : (nud.Minimum > v) ? nud.Minimum
                                          : v;
        }

        public static void NUDDouble(NumericUpDown nud, String s)
        {
            double d;
            Double.TryParse(s, NumberStyles.Float, ReadValue.FloatPoint, out d);
            Decimal v = (Decimal)d;
            nud.Value = (nud.Maximum < v) ? nud.Maximum
                      : (nud.Minimum > v) ? nud.Minimum
                                          : v;
        }

        public static void NUDDouble360(NumericUpDown nud, String s)
        {
            double v,
                min = (double)nud.Minimum,
                max = (double)nud.Maximum;
            double range = max - min;
            Double.TryParse(s, NumberStyles.Float, ReadValue.FloatPoint, out v);
            nud.Value = (Decimal)((0 < v && max < v) ? v - Math.Floor  (v / range) * range // loop back
                                : (0 > v && min > v) ? v + Math.Ceiling(v / range) * range // loop back
                                                     : v);
        }

        public static int TagsAttribute(String line, String attribute, out String value, out int end)
        {
            end = 0;
            value = "";
            // Find attribute
            int start = line.IndexOf(' ' + attribute + '=');
            if (start < 0) return 0;
            // Extract value
            int q1, q2;
            if ((q1 = line.IndexOf('"', start) + 1) < 1) return 0; // Position first second "
            if ((q2 = line.IndexOf('"', q1)) < 1) return 0; // Position after second "
            value = line.Substring(q1, q2 - q1);
            end = q2 + 1;
            return start;
        }
    }

    public static class UIBasics
    {
        public delegate void CallBackDelegate();
        
        public static void TreeView_NodeSwitchState(TreeNode Node, int increment = 1)
        {
            int stateBase = Node.TreeView.StateImageList.Images.Count;
            Node.StateImageIndex = (stateBase + Node.StateImageIndex + increment) % stateBase;
        }

        public static void TreeView_NodeSwitchStateMouseLR(object sender, TreeNodeMouseClickEventArgs e, CallBackDelegate callBack)
        {
            e.Node.TreeView.SelectedNode = e.Node;
            if (e.Node.Bounds.X < e.X) return;
            TreeView_NodeSwitchState(e.Node, (e.Button == MouseButtons.Left) ? 1 : -1);
            callBack?.Invoke();
        }

        public static void TreeView_KeyPressBeginEdit(object tv, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            (tv as TreeView).SelectedNode.BeginEdit();
            e.Handled = true;
        }

        public static void TreeView_SetStates(TreeView tv, int state, CallBackDelegate callBack)
        {
            foreach (TreeNode Node in tv.Nodes)
                Node.StateImageIndex = state;
            callBack?.Invoke();
        }

        public static void CheckedListBox_MouseClick(CheckedListBox clb, MouseEventArgs e)
        {
            int i = clb.SelectedIndex;
            if (20 < e.X && 0 <= i)
                clb.SetItemChecked(i, !clb.GetItemChecked(i));
        }

        public static void CheckedListBox_SetChecks(CheckedListBox clb, bool newState)
        {
            for (int i = clb.Items.Count - 1; 0 <= i; i--)
                clb.SetItemChecked(i, newState);
        }

        public static void CheckedListBox_InvertChecks(CheckedListBox clb)
        {
            for (int i = clb.Items.Count - 1; 0 <= i; i--)
                clb.SetItemChecked(i, !clb.GetItemChecked(i));
        }

        public static void TextBox_KeyPressLeave(object sender, KeyPressEventArgs e, CallBackDelegate callBack)//Ok
        {
            if (e.KeyChar != '\r') return;
            callBack?.Invoke();
            e.Handled = true;
        }
    }

    public class FSPins
    {
        public readonly int Width,  CenterX,
                            Height, CenterY;
        public readonly int[][] Icons;
        public readonly int[] Selection;
        public readonly int[] Checking;
        public readonly int[] Pens;

        public FSPins(int width, int height, int centerX, int centerY, int[][] icons, int[] selection, int[] checking, int[] pens)
        {
            Width  = width;
            Height = height;
            CenterX = centerX;
            CenterY = centerY;
            Icons = icons;
            Selection = selection;
            Checking = checking;
            Pens = pens;
        }
    }

    public class XYZRDouble
    {
        public double X = 0, Y = 0, Z = 0, R = 0;
        public int canvasX, canvasY;

        public void ReadXMLLine(String line)
        {
            X = Y = Z = R = 0;
            // Extract value
            string[] v = line.Replace("  ", " ").Split(' ');
            if (0 < v.Length) Double.TryParse(v[0], NumberStyles.Float, ReadValue.FloatPoint, out X);
            if (1 < v.Length) Double.TryParse(v[1], NumberStyles.Float, ReadValue.FloatPoint, out Y);
            if (2 < v.Length) Double.TryParse(v[2], NumberStyles.Float, ReadValue.FloatPoint, out Z);
            if (3 < v.Length) Double.TryParse(v[3], NumberStyles.Float, ReadValue.FloatPoint, out R);
        }

        public bool Align(double step, double offset, Boolean doX, Boolean doY, Boolean doZ, Boolean doR = false)
        {
            if (step == 0 && offset == 0) return false;
            double ix = X, iy = Y, iz = Z, ir = R;
            if (doX) X = Math.Round((X - offset) / step) * step + offset;
            if (doY) Y = Math.Round((Y - offset) / step) * step + offset;
            if (doZ) Z = Math.Round((Z - offset) / step) * step + offset;
            if (doR) R = Math.Round((R - offset) / step) * step + offset;
            return ix != X || iy != Y || iz != Z || ir != R;
        }

        public void Increment(double stepX, double stepY, double stepZ, double stepR = 0)
        {
            X += stepX;
            Y += stepY;
            Z += stepZ;
            R += stepR;
        }

        public String GetListLine(String floatFormat, char splitCharR = '-') =>
                         X.ToString(floatFormat, ReadValue.FloatPoint) + 
                   " " + Y.ToString(floatFormat, ReadValue.FloatPoint) + 
                   " " + Z.ToString(floatFormat, ReadValue.FloatPoint) + (splitCharR == '-' ? "" :
            splitCharR + R.ToString(floatFormat, ReadValue.FloatPoint));
    }

    abstract public class FSObject
    {
        public int PinState = 0;
        public XYZRDouble Position;
        // Own
        public String XMLLine = "", ListLine = "";
        public bool Show  = false, Checked  = false,
                    Shown = false, Selected = false,
                    Edited = false;

        abstract public String BuildListLine();
        public String GetListLine() => Edited ? ListLine = BuildListLine() : ListLine;
    }

    abstract public class FSObjectString : FSObject
    {
        public FSObjectString(String line) => ReadXMLLine(line, true);

        abstract public void DecodeXMLLine(String line);
        public void ReadXMLLine(String line = null, bool set = false)
        {
            DecodeXMLLine(line ?? (line = XMLLine));
            if (set) XMLLine = line;
        }

        abstract public String BuildXMLLine();
        public String GetXMLLine () => Edited ? XMLLine = BuildXMLLine() : XMLLine;
    }
}