using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suoja
{
    public partial class JobDetails : Form
    {

        public string OriginalFilepath { get; set; }
        public string OutputFilepath { get; set; }
        public string KeyFilepath { get; set; }
        public SuojaJob.JobStatus Status { get; set; }
        public AddJobDialog.JobAction Action { get; set; }
        public FilenameOptionDialog.Filenameoption Option { get; set; }
        public string Message { get; set; }

        public JobDetails()
        {
            InitializeComponent();
        }

        private void JobDetails_Shown(object sender, EventArgs e)
        {
            lblOriginal.Text = OriginalFilepath.Split('\\').Last();
            lblOutput.Text = OutputFilepath.Split('\\').Last();
            lblKey.Text = KeyFilepath.Split('\\').Last();
            switch (Status)
            {
                case SuojaJob.JobStatus.Queued:
                    lblStatus.Text = "In Wartschlange";
                    btnStart.Enabled = true;
                    break;
                case SuojaJob.JobStatus.Finished:
                    lblStatus.Text = "Abgeschlossen";
                    btnShowOutput.Enabled = true;
                    break;
                case SuojaJob.JobStatus.Failed:
                    lblStatus.Text = "Fehlgeschlagen";
                    break;
            }
            if (Action == AddJobDialog.JobAction.Encrypt)
            {
                lblAction.Text = "Verschlüsseln";
            }
            else
            {
                lblAction.Text = "Entschlüsseln";
            }
            if (Option == FilenameOptionDialog.Filenameoption.Keep)
            {
                lblOption.Text = "Unverändert";
            }
            else
            {
                lblOption.Text = "Kodiert";
            }
            tbxInformation.Text = Message;
        }

        private void btnShowOriginal_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + OriginalFilepath);
        }

        private void btnShowOutput_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + OutputFilepath);
        }

        private void btnShowKey_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + KeyFilepath);
        }
    }
}
