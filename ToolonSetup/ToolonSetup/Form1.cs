using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolonSetup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectInstallDir sidir = new SelectInstallDir();
            sidir.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("lif.exe"))
            {
                System.Diagnostics.Process.Start("lif.exe");
            }
            else
            {
                OnlineLicense olif = new OnlineLicense();
                olif.ShowDialog();
            }
        }
    }
}
