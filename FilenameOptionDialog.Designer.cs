namespace Suoja
{
    partial class FilenameOptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilenameOptionDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.rbtKeep = new System.Windows.Forms.RadioButton();
            this.rbtEncode = new System.Windows.Forms.RadioButton();
            this.lblKeyNewDesc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(206, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dateinamenoptionen auswählen";
            // 
            // rbtKeep
            // 
            this.rbtKeep.AutoSize = true;
            this.rbtKeep.Checked = true;
            this.rbtKeep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbtKeep.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rbtKeep.Location = new System.Drawing.Point(25, 46);
            this.rbtKeep.Name = "rbtKeep";
            this.rbtKeep.Size = new System.Drawing.Size(148, 19);
            this.rbtKeep.TabIndex = 7;
            this.rbtKeep.TabStop = true;
            this.rbtKeep.Text = "Unverändert (Standard)";
            this.rbtKeep.UseVisualStyleBackColor = true;
            this.rbtKeep.CheckedChanged += new System.EventHandler(this.rbtKeep_CheckedChanged);
            // 
            // rbtEncode
            // 
            this.rbtEncode.AutoSize = true;
            this.rbtEncode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbtEncode.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rbtEncode.Location = new System.Drawing.Point(25, 126);
            this.rbtEncode.Name = "rbtEncode";
            this.rbtEncode.Size = new System.Drawing.Size(141, 19);
            this.rbtEncode.TabIndex = 8;
            this.rbtEncode.Text = "Versteckt (Empfohlen)";
            this.rbtEncode.UseVisualStyleBackColor = true;
            // 
            // lblKeyNewDesc
            // 
            this.lblKeyNewDesc.ForeColor = System.Drawing.Color.Black;
            this.lblKeyNewDesc.Location = new System.Drawing.Point(16, 16);
            this.lblKeyNewDesc.Name = "lblKeyNewDesc";
            this.lblKeyNewDesc.Size = new System.Drawing.Size(328, 46);
            this.lblKeyNewDesc.TabIndex = 9;
            this.lblKeyNewDesc.Text = "Der Dateiname und die Endung bleiben erhalten und lesbar. Es wird lediglich .suoj" +
    "a angehängt.";
            this.lblKeyNewDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 78);
            this.label4.TabIndex = 12;
            this.label4.Text = "Der Dateiname wird kodiert, wodurch keine Rückschlüsse auf die Originaldatei mögl" +
    "ich sind. Allerdings wird Suoja benötigt, um den Dateinamen wieder zu dekodieren" +
    ".";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 95);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "                                     ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblKeyNewDesc);
            this.groupBox2.Location = new System.Drawing.Point(13, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 71);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "                                                  ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 44);
            this.panel1.TabIndex = 15;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(255, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 25);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Übernehmen";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // FilenameOptionDialog
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(388, 282);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbtKeep);
            this.Controls.Add(this.rbtEncode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FilenameOptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dateinamenoptionen";
            this.Shown += new System.EventHandler(this.FilenameOptionDialog_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtKeep;
        private System.Windows.Forms.RadioButton rbtEncode;
        private System.Windows.Forms.Label lblKeyNewDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
    }
}