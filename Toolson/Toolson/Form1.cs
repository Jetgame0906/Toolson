using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toolson
{
    public partial class Form1 : Form
    {

        public string toolsondir;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(toolsondir + "\\run.exe");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                toolsondir = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Toolson System not found", "Toolson Cliant");
                Close();
            }
        }
    }
}
