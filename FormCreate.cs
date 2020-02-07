using System;
using System.Windows.Forms;

namespace SHME
{
    public partial class FormCreate : Form
    {
        public int mapWidth = 0, mapHeight = 0;

        public FormCreate() => InitializeComponent();

        private void button1_Click(object sender, EventArgs e)
        {
            mapWidth  = (int)nudWidth. Value;
            mapHeight = (int)nudHeight.Value;
        }
    }
}
