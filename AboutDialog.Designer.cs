namespace Suoja
{
    partial class AboutDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llblTwitter = new System.Windows.Forms.LinkLabel();
            this.llblFestival = new System.Windows.Forms.LinkLabel();
            this.llblJson = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.llblIcon = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.llblZip = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRemoveDocumentPopup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 517);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 44);
            this.panel1.TabIndex = 17;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Entwickler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fabian Krahtz";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // llblTwitter
            // 
            this.llblTwitter.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.llblTwitter.AutoSize = true;
            this.llblTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblTwitter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblTwitter.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llblTwitter.Location = new System.Drawing.Point(12, 129);
            this.llblTwitter.Name = "llblTwitter";
            this.llblTwitter.Size = new System.Drawing.Size(187, 19);
            this.llblTwitter.TabIndex = 22;
            this.llblTwitter.TabStop = true;
            this.llblTwitter.Text = "https://twitter.com/vainamov";
            this.llblTwitter.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.llblTwitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTwitter_LinkClicked);
            // 
            // llblFestival
            // 
            this.llblFestival.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.llblFestival.AutoSize = true;
            this.llblFestival.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblFestival.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblFestival.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llblFestival.Location = new System.Drawing.Point(13, 151);
            this.llblFestival.Name = "llblFestival";
            this.llblFestival.Size = new System.Drawing.Size(119, 19);
            this.llblFestival.TabIndex = 23;
            this.llblFestival.TabStop = true;
            this.llblFestival.Text = "https://festival.ml/";
            this.llblFestival.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.llblFestival.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblFestival_LinkClicked);
            // 
            // llblJson
            // 
            this.llblJson.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.llblJson.AutoSize = true;
            this.llblJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblJson.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblJson.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llblJson.Location = new System.Drawing.Point(12, 246);
            this.llblJson.Name = "llblJson";
            this.llblJson.Size = new System.Drawing.Size(209, 19);
            this.llblJson.TabIndex = 26;
            this.llblJson.TabStop = true;
            this.llblJson.Text = "http://www.newtonsoft.com/json";
            this.llblJson.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.llblJson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblJson_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(12, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Newtonsoft.Json";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = "Externe Bibliotheken";
            // 
            // llblIcon
            // 
            this.llblIcon.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.llblIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblIcon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblIcon.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llblIcon.Location = new System.Drawing.Point(12, 388);
            this.llblIcon.Name = "llblIcon";
            this.llblIcon.Size = new System.Drawing.Size(363, 41);
            this.llblIcon.TabIndex = 29;
            this.llblIcon.TabStop = true;
            this.llblIcon.Text = "https://www.iconfinder.com/icons/532631/insurance_protection_safe_safety_secure_s" +
    "ecurity_shield_icon";
            this.llblIcon.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.llblIcon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblIcon_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(12, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "Verändert nach";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(12, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 21);
            this.label6.TabIndex = 27;
            this.label6.Text = "Icon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(258, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "Version 2.0.14 RC";
            // 
            // llblZip
            // 
            this.llblZip.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.llblZip.AutoSize = true;
            this.llblZip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.llblZip.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.llblZip.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.llblZip.Location = new System.Drawing.Point(12, 296);
            this.llblZip.Name = "llblZip";
            this.llblZip.Size = new System.Drawing.Size(202, 19);
            this.llblZip.TabIndex = 32;
            this.llblZip.TabStop = true;
            this.llblZip.Text = "https://dotnetzip.codeplex.com/";
            this.llblZip.VisitedLinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.llblZip.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblZip_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(12, 271);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 19);
            this.label8.TabIndex = 31;
            this.label8.Text = "DotNetZip (Ionic.Zip)";
            // 
            // btnRemoveDocumentPopup
            // 
            this.btnRemoveDocumentPopup.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveDocumentPopup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveDocumentPopup.Location = new System.Drawing.Point(16, 476);
            this.btnRemoveDocumentPopup.Name = "btnRemoveDocumentPopup";
            this.btnRemoveDocumentPopup.Size = new System.Drawing.Size(120, 25);
            this.btnRemoveDocumentPopup.TabIndex = 14;
            this.btnRemoveDocumentPopup.Text = "Hinweis entfernen";
            this.btnRemoveDocumentPopup.UseVisualStyleBackColor = true;
            this.btnRemoveDocumentPopup.Click += new System.EventHandler(this.btnRemoveDocumentPopup_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(13, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 21);
            this.label9.TabIndex = 33;
            this.label9.Text = "Office-Dokumente-Hinweis";
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(388, 561);
            this.Controls.Add(this.btnRemoveDocumentPopup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.llblZip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.llblIcon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.llblJson);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.llblFestival);
            this.Controls.Add(this.llblTwitter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Über Suoja";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llblTwitter;
        private System.Windows.Forms.LinkLabel llblFestival;
        private System.Windows.Forms.LinkLabel llblJson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel llblIcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel llblZip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemoveDocumentPopup;
        private System.Windows.Forms.Label label9;
    }
}