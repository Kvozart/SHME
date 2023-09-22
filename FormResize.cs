using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormResize : Form
    {
        public int newWidth = 1, newHeight = 1;

        public FormResize(int width, int height)
        {
            InitializeComponent();

            lblOldWidth. Text = width. ToString();
            lblOldHeight.Text = height.ToString();
            
            nudWidth. Value = width;
            nudHeight.Value = height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newWidth  = (int)nudWidth. Value;
            newHeight = (int)nudHeight.Value;
        }
    }
}
