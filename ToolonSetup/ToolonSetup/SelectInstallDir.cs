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
    public partial class SelectInstallDir : Form
    {
        public string instpath = @"C:\toolson";

        public SelectInstallDir()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            installingscr iscr = new installingscr(instpath);
            iscr.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "Select Install location";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = textBox1.Text;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath.ToString();
                instpath = fbd.SelectedPath.ToString();
            }
        }
    }
}
