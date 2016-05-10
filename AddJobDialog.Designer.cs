namespace Suoja
{
    partial class AddJobDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddJobDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.rbtActionEncrypt = new System.Windows.Forms.RadioButton();
            this.rbtActionDecrypt = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChooseFilenameoption = new System.Windows.Forms.Button();
            this.lblOriginal = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.tbxFilepath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChooseKeySave = new System.Windows.Forms.Button();
            this.btnChooseKey = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblKeyNewDesc = new System.Windows.Forms.Label();
            this.rbtKeyNew = new System.Windows.Forms.RadioButton();
            this.rbtKeyFromFile = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(171, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neuen Auftrag hinzufügen";
            // 
            // rbtActionEncrypt
            // 
            this.rbtActionEncrypt.AutoSize = true;
            this.rbtActionEncrypt.Checked = true;
            this.rbtActionEncrypt.ForeColor = System.Drawing.Color.Black;
            this.rbtActionEncrypt.Location = new System.Drawing.Point(10, 22);
            this.rbtActionEncrypt.Name = "rbtActionEncrypt";
            this.rbtActionEncrypt.Size = new System.Drawing.Size(95, 19);
            this.rbtActionEncrypt.TabIndex = 4;
            this.rbtActionEncrypt.TabStop = true;
            this.rbtActionEncrypt.Text = "Verschlüsseln";
            this.rbtActionEncrypt.UseVisualStyleBackColor = true;
            this.rbtActionEncrypt.CheckedChanged += new System.EventHandler(this.rbtActionEncrypt_CheckedChanged);
            // 
            // rbtActionDecrypt
            // 
            this.rbtActionDecrypt.AutoSize = true;
            this.rbtActionDecrypt.ForeColor = System.Drawing.Color.Black;
            this.rbtActionDecrypt.Location = new System.Drawing.Point(133, 22);
            this.rbtActionDecrypt.Name = "rbtActionDecrypt";
            this.rbtActionDecrypt.Size = new System.Drawing.Size(96, 19);
            this.rbtActionDecrypt.TabIndex = 6;
            this.rbtActionDecrypt.Text = "Entschlüsseln";
            this.rbtActionDecrypt.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtActionEncrypt);
            this.groupBox1.Controls.Add(this.rbtActionDecrypt);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 53);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aktion";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChooseFilenameoption);
            this.groupBox2.Controls.Add(this.lblOriginal);
            this.groupBox2.Controls.Add(this.btnChooseFile);
            this.groupBox2.Controls.Add(this.tbxFilepath);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(13, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datei";
            // 
            // btnChooseFilenameoption
            // 
            this.btnChooseFilenameoption.ForeColor = System.Drawing.Color.Black;
            this.btnChooseFilenameoption.Location = new System.Drawing.Point(213, 58);
            this.btnChooseFilenameoption.Name = "btnChooseFilenameoption";
            this.btnChooseFilenameoption.Size = new System.Drawing.Size(141, 25);
            this.btnChooseFilenameoption.TabIndex = 13;
            this.btnChooseFilenameoption.Text = "Dateinamenoptionen...";
            this.btnChooseFilenameoption.UseVisualStyleBackColor = true;
            this.btnChooseFilenameoption.Click += new System.EventHandler(this.btnChooseFilenameoption_Click);
            // 
            // lblOriginal
            // 
            this.lblOriginal.ForeColor = System.Drawing.Color.Black;
            this.lblOriginal.Location = new System.Drawing.Point(8, 55);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(198, 31);
            this.lblOriginal.TabIndex = 12;
            this.lblOriginal.Text = "\r\n";
            this.lblOriginal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.ForeColor = System.Drawing.Color.Black;
            this.btnChooseFile.Location = new System.Drawing.Point(323, 26);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(30, 21);
            this.btnChooseFile.TabIndex = 10;
            this.btnChooseFile.Text = "...";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // tbxFilepath
            // 
            this.tbxFilepath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbxFilepath.ForeColor = System.Drawing.Color.Black;
            this.tbxFilepath.Location = new System.Drawing.Point(9, 25);
            this.tbxFilepath.Name = "tbxFilepath";
            this.tbxFilepath.ReadOnly = true;
            this.tbxFilepath.Size = new System.Drawing.Size(345, 23);
            this.tbxFilepath.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnChooseKeySave);
            this.groupBox3.Controls.Add(this.btnChooseKey);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblKeyNewDesc);
            this.groupBox3.Controls.Add(this.rbtKeyNew);
            this.groupBox3.Controls.Add(this.rbtKeyFromFile);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Location = new System.Drawing.Point(12, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 198);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Schlüssel";
            // 
            // btnChooseKeySave
            // 
            this.btnChooseKeySave.ForeColor = System.Drawing.Color.Black;
            this.btnChooseKeySave.Location = new System.Drawing.Point(132, 67);
            this.btnChooseKeySave.Name = "btnChooseKeySave";
            this.btnChooseKeySave.Size = new System.Drawing.Size(141, 25);
            this.btnChooseKeySave.TabIndex = 12;
            this.btnChooseKeySave.Text = "Speicherort wählen...";
            this.btnChooseKeySave.UseVisualStyleBackColor = true;
            this.btnChooseKeySave.Click += new System.EventHandler(this.btnChooseKeySave_Click);
            // 
            // btnChooseKey
            // 
            this.btnChooseKey.Enabled = false;
            this.btnChooseKey.ForeColor = System.Drawing.Color.Black;
            this.btnChooseKey.Location = new System.Drawing.Point(132, 158);
            this.btnChooseKey.Name = "btnChooseKey";
            this.btnChooseKey.Size = new System.Drawing.Size(141, 25);
            this.btnChooseKey.TabIndex = 11;
            this.btnChooseKey.Text = "Schlüssel auswählen...";
            this.btnChooseKey.UseVisualStyleBackColor = true;
            this.btnChooseKey.Click += new System.EventHandler(this.btnChooseKey_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(130, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 37);
            this.label3.TabIndex = 8;
            this.label3.Text = "Zur Ver-/Entschlüsselung wird ein bereits vorhandener Schlüssel benutzt.";
            // 
            // lblKeyNewDesc
            // 
            this.lblKeyNewDesc.ForeColor = System.Drawing.Color.Black;
            this.lblKeyNewDesc.Location = new System.Drawing.Point(130, 24);
            this.lblKeyNewDesc.Name = "lblKeyNewDesc";
            this.lblKeyNewDesc.Size = new System.Drawing.Size(226, 46);
            this.lblKeyNewDesc.TabIndex = 7;
            this.lblKeyNewDesc.Text = "Zur Verschlüsselung wird ein zufällig generierter Schlüssel benutzt.";
            // 
            // rbtKeyNew
            // 
            this.rbtKeyNew.AutoSize = true;
            this.rbtKeyNew.Checked = true;
            this.rbtKeyNew.ForeColor = System.Drawing.Color.Black;
            this.rbtKeyNew.Location = new System.Drawing.Point(10, 22);
            this.rbtKeyNew.Name = "rbtKeyNew";
            this.rbtKeyNew.Size = new System.Drawing.Size(47, 19);
            this.rbtKeyNew.TabIndex = 4;
            this.rbtKeyNew.TabStop = true;
            this.rbtKeyNew.Text = "Neu";
            this.rbtKeyNew.UseVisualStyleBackColor = true;
            // 
            // rbtKeyFromFile
            // 
            this.rbtKeyFromFile.AutoSize = true;
            this.rbtKeyFromFile.ForeColor = System.Drawing.Color.Black;
            this.rbtKeyFromFile.Location = new System.Drawing.Point(10, 114);
            this.rbtKeyFromFile.Name = "rbtKeyFromFile";
            this.rbtKeyFromFile.Size = new System.Drawing.Size(75, 19);
            this.rbtKeyFromFile.TabIndex = 6;
            this.rbtKeyFromFile.Text = "Aus Datei";
            this.rbtKeyFromFile.UseVisualStyleBackColor = true;
            this.rbtKeyFromFile.CheckedChanged += new System.EventHandler(this.rbtKeyFromFile_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 44);
            this.panel1.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Enabled = false;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(129, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 25);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Hinzufügen";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(255, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 1);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // AddJobDialog
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(388, 471);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddJobDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neuer Auftrag";
            this.Shown += new System.EventHandler(this.AddJobDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtActionEncrypt;
        private System.Windows.Forms.RadioButton rbtActionDecrypt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox tbxFilepath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblKeyNewDesc;
        private System.Windows.Forms.RadioButton rbtKeyNew;
        private System.Windows.Forms.RadioButton rbtKeyFromFile;
        private System.Windows.Forms.Label lblOriginal;
        private System.Windows.Forms.Button btnChooseKey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChooseKeySave;
        private System.Windows.Forms.Button btnChooseFilenameoption;
    }
}