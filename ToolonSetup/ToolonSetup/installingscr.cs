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
    public partial class installingscr : Form
    {
        System.Net.WebClient downloadClient = null;
        public string instdir;

        public int allprogressinst = 10;

        public installingscr(string instadir)
        {
            instdir = instadir;
            InitializeComponent();
        }

        private void installingscr_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Really install at : " + instdir,"Toolson Installing Process",MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                installing();
            }
            else if (result == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void installing()
        {
            progressBar1.Maximum = allprogressinst;
        }

        private void start_download(string downloadurl,string todownload)
        {
            string fileName = todownload;
            Uri u = new Uri(downloadurl);

            if (downloadClient == null)
            {
                downloadClient = new System.Net.WebClient();
                downloadClient.DownloadProgressChanged +=new System.Net.DownloadProgressChangedEventHandler(downloadClient_DownloadProgressChanged);
                downloadClient.DownloadFileCompleted +=new AsyncCompletedEventHandler(downloadClient_DownloadFileCompleted);
            }
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 100;
            downloadClient.DownloadFileAsync(u, fileName);
        }

        private void canbtn_Click(object sender, EventArgs e)
        {
            if (downloadClient != null)
                downloadClient.CancelAsync();
        }

        private void downloadClient_DownloadProgressChanged(object sender,System.Net.DownloadProgressChangedEventArgs e)
        {
            label2.Text = "Downloading : " + e.ProgressPercentage.ToString() + "%";
            progressBar2.Value = e.ProgressPercentage;
        }

        private void downloadClient_DownloadFileCompleted(object sender,AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                canbtn_Click(new object(),new EventArgs());
            }
            else
            {
                label1.Text = "Donwloaded";
                Close();
            }

        }
    }
}
