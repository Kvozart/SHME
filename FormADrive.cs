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
    public partial class FormADrive : Form
    {
        Form Main;
        public FormADrive(Form main)
        {
            InitializeComponent();
            Main = main;
        }

        private void FormADrive_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
            Hide();
            e.Cancel = true;
        }
    }
}
