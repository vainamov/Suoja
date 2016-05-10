namespace Suoja
{
    partial class JobDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOriginal = new System.Windows.Forms.Label();
            this.btnShowOriginal = new System.Windows.Forms.Button();
            this.btnShowOutput = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOption = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnShowKey = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxInformation = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Details";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 44);
            this.panel1.TabIndex = 21;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(255, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 25);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Schließen";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ursprungsdatei";
            // 
            // lblOriginal
            // 
            this.lblOriginal.AutoSize = true;
            this.lblOriginal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOriginal.Location = new System.Drawing.Point(9, 70);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(100, 19);
            this.lblOriginal.TabIndex = 23;
            this.lblOriginal.Text = "Ursprung.datei";
            // 
            // btnShowOriginal
            // 
            this.btnShowOriginal.Location = new System.Drawing.Point(255, 68);
            this.btnShowOriginal.Name = "btnShowOriginal";
            this.btnShowOriginal.Size = new System.Drawing.Size(120, 23);
            this.btnShowOriginal.TabIndex = 24;
            this.btnShowOriginal.Text = "Im Explorer zeigen";
            this.btnShowOriginal.UseVisualStyleBackColor = true;
            this.btnShowOriginal.Click += new System.EventHandler(this.btnShowOriginal_Click);
            // 
            // btnShowOutput
            // 
            this.btnShowOutput.Enabled = false;
            this.btnShowOutput.Location = new System.Drawing.Point(255, 122);
            this.btnShowOutput.Name = "btnShowOutput";
            this.btnShowOutput.Size = new System.Drawing.Size(120, 23);
            this.btnShowOutput.TabIndex = 27;
            this.btnShowOutput.Text = "Im Explorer zeigen";
            this.btnShowOutput.UseVisualStyleBackColor = true;
            this.btnShowOutput.Click += new System.EventHandler(this.btnShowOutput_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOutput.Location = new System.Drawing.Point(9, 124);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(63, 19);
            this.lblOutput.TabIndex = 26;
            this.lblOutput.Text = "Ziel.datei";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(10, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Zieldatei";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Location = new System.Drawing.Point(9, 238);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(114, 19);
            this.lblStatus.TabIndex = 29;
            this.lblStatus.Text = "In Warteschlange";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(10, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Status";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAction.Location = new System.Drawing.Point(9, 294);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(90, 19);
            this.lblAction.TabIndex = 31;
            this.lblAction.Text = "Verschlüsseln";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(10, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Aktion";
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOption.Location = new System.Drawing.Point(251, 294);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(86, 19);
            this.lblOption.TabIndex = 33;
            this.lblOption.Text = "Unverändert";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(252, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Dateinamenoption";
            // 
            // btnStart
            // 
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStart.Enabled = false;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Location = new System.Drawing.Point(255, 236);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(120, 23);
            this.btnStart.TabIndex = 34;
            this.btnStart.Text = "Starten";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // btnShowKey
            // 
            this.btnShowKey.Location = new System.Drawing.Point(255, 179);
            this.btnShowKey.Name = "btnShowKey";
            this.btnShowKey.Size = new System.Drawing.Size(120, 23);
            this.btnShowKey.TabIndex = 37;
            this.btnShowKey.Text = "Im Explorer zeigen";
            this.btnShowKey.UseVisualStyleBackColor = true;
            this.btnShowKey.Click += new System.EventHandler(this.btnShowKey_Click);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKey.Location = new System.Drawing.Point(9, 181);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(125, 19);
            this.lblKey.TabIndex = 36;
            this.lblKey.Text = "Schlüssel.suojadata";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(10, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Keydatei";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(10, 330);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Informationen";
            // 
            // tbxInformation
            // 
            this.tbxInformation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbxInformation.Location = new System.Drawing.Point(13, 355);
            this.tbxInformation.Multiline = true;
            this.tbxInformation.Name = "tbxInformation";
            this.tbxInformation.ReadOnly = true;
            this.tbxInformation.Size = new System.Drawing.Size(363, 117);
            this.tbxInformation.TabIndex = 40;
            // 
            // JobDetails
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(388, 531);
            this.Controls.Add(this.tbxInformation);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnShowKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnShowOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnShowOriginal);
            this.Controls.Add(this.lblOriginal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Details";
            this.Shown += new System.EventHandler(this.JobDetails_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOriginal;
        private System.Windows.Forms.Button btnShowOriginal;
        private System.Windows.Forms.Button btnShowOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnShowKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbxInformation;
    }
}