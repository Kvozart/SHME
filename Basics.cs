using System;
using System.Globalization;
using System.Windows.Forms;

namespace SHME
{
    public static class ReadValue
    {
        public static void NUDInteger(NumericUpDown nud, String s, NumberFormatInfo nfi)
        {
            int d;
            Int32.TryParse(s, NumberStyles.Integer, nfi, out d);
            Decimal v = (Decimal)d;
            nud.Value = (nud.Maximum < v) ? nud.Maximum
                      : (nud.Minimum > v) ? nud.Minimum
                                          : v;
        }

        public static void NUDDouble(NumericUpDown nud, String s, NumberFormatInfo nfi)
        {
            double d;
            Double.TryParse(s, NumberStyles.Float, nfi, out d);
            Decimal v = (Decimal)d;
            nud.Value = (nud.Maximum < v) ? nud.Maximum
                      : (nud.Minimum > v) ? nud.Minimum
                                          : v;
        }

        public static void NUDDouble360(NumericUpDown nud, String s, NumberFormatInfo nfi)
        {
            double v,
                min = (double)nud.Minimum,
                max = (double)nud.Maximum;
            double range = max - min;
            Double.TryParse(s, NumberStyles.Float, nfi, out v);
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

        public static void TreeView_BeginEdit(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') return;
            (sender as TreeView).SelectedNode.BeginEdit();
            e.Handled = true;
        }

        public static void TreeView_SetStates(object sender, int state, CallBackDelegate callBack)
        {
            foreach (TreeNode Node in (sender as TreeView).Nodes)
                Node.StateImageIndex = state;
            callBack?.Invoke();
        }

        public static void CheckedListBox_MouseClick(object sender, MouseEventArgs e)
        {
            int i = (sender as CheckedListBox).SelectedIndex;
            if (20 < e.X && 0 <= i)
                (sender as CheckedListBox).SetItemChecked(i, !(sender as CheckedListBox).GetItemChecked(i));
        }

        public static void CheckedListBox_SetChecks(object sender, bool newState)
        {
            for (int i = (sender as CheckedListBox).Items.Count - 1; 0 <= i; i--)
                (sender as CheckedListBox).SetItemChecked(i, newState);
        }

        public static void CheckedListBox_InvertChecks(object sender)
        {
            for (int i = (sender as CheckedListBox).Items.Count - 1; 0 <= i; i--)
                (sender as CheckedListBox).SetItemChecked(i, !(sender as CheckedListBox).GetItemChecked(i));
        }

        public static void TextBox_KeyPressLeave(object sender, KeyPressEventArgs e, CallBackDelegate callBack)//Ok
        {
            if (e.KeyChar != '\r') return;
            callBack?.Invoke();
            e.Handled = true;
        }
    }

    public class XYZDouble
    {
        public double X = 0, Y = 0, Z = 0, R = 0;
        public bool Present;

        public void ReadXMLLine(String line, NumberFormatInfo nfi)
        {
            X = Y = Z = 0;
            // Extract value
            string[] v = line.Replace("  ", " ").Split(' ');
            if (0 < v.Length) Double.TryParse(v[0], NumberStyles.Float, nfi, out X);
            if (1 < v.Length) Double.TryParse(v[1], NumberStyles.Float, nfi, out Y);
            if (2 < v.Length) Double.TryParse(v[2], NumberStyles.Float, nfi, out Z);
        }

        public bool Align(double step, double offset, Boolean doX, Boolean doY, Boolean doZ, Boolean doR = false)
        {
            if (!Present || (step  == 0 && offset == 0)) return false;
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

        public String GetListLine(String floatFormat, NumberFormatInfo nfi, bool includeR = false) =>
                  X.ToString(floatFormat, nfi) + 
            " " + Y.ToString(floatFormat, nfi) + 
            " " + Z.ToString(floatFormat, nfi) + (includeR ?
            " " + R.ToString(floatFormat, nfi) : "");
    }

    abstract public class FSObject
    {
        public static readonly NumberFormatInfo FloatPoint = new CultureInfo("en-US", false).NumberFormat;
        public static readonly String FloatFormat = "f4";

        public XYZDouble Position = new XYZDouble();
        // Own
        public String XMLLine = "", ListLine = "";
        public bool Edited = false, Show = false, Shown = false;

        public FSObject(String line) => ReadXMLLine(line, true);

        abstract public void DecodeXMLLine(String line);
        public void ReadXMLLine(String line = null, bool set = false)
        {
            DecodeXMLLine((line == null) ? line = XMLLine : line);
            if (set) XMLLine = line;
        }
    
        abstract public String BuildListLine();
        public String GetListLine() => ListLine = BuildListLine();

        abstract public String BuildXMLLine ();
        public String GetXMLLine () => (Edited) ? BuildXMLLine () : XMLLine;
    }

    public class FSItem : FSObject
    {
        public String A = "", B = "", C = "";
        public XYZDouble Rotation = new XYZDouble();
        // Own
        int pStart, rStart;

        public FSItem(String line) : base(line) {}

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

}
