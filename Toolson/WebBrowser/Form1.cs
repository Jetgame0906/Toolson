using Gecko;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate("https://www.google.com");
            //geckoWebBrowser1.Navigate("http://localhost:8121"); //Tools on Web Server
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(toolStripTextBox1.Text);
        }

        private void geckoWebBrowser1_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            toolStripTextBox1.Text = geckoWebBrowser1.Url.ToString();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void geckoWebBrowser1_StatusTextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = geckoWebBrowser1.StatusText.ToString();
        }

        private void geckoWebBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            Text = "Web Browser - " + geckoWebBrowser1.DocumentTitle;
        }
    }
}
