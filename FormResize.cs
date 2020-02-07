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
        public int mapWidth = 0, mapHeight = 0;

        public FormResize(int width, int height)
        {
            InitializeComponent();

            lblOldWidth. Text = width. ToString();
            lblOldHeight.Text = height.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mapWidth  = (int)nudWidth. Value;
            mapHeight = (int)nudHeight.Value;
        }
    }
}
