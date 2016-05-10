namespace Suoja
{
    partial class DragDropDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DragDropDialog));
            this.rbtCompress = new System.Windows.Forms.RadioButton();
            this.rbtIndividual = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKeyNewDesc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtEqual = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtCompress
            // 
            this.rbtCompress.AutoSize = true;
            this.rbtCompress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbtCompress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rbtCompress.Location = new System.Drawing.Point(25, 86);
            this.rbtCompress.Name = "rbtCompress";
            this.rbtCompress.Size = new System.Drawing.Size(284, 19);
            this.rbtCompress.TabIndex = 17;
            this.rbtCompress.Text = "Alle Dateien zusammenfassen (nur Verschlüsseln)";
            this.rbtCompress.UseVisualStyleBackColor = true;
            this.rbtCompress.CheckedChanged += new System.EventHandler(this.rbtCompress_CheckedChanged);
            // 
            // rbtIndividual
            // 
            this.rbtIndividual.AutoSize = true;
            this.rbtIndividual.Checked = true;
            this.rbtIndividual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbtIndividual.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rbtIndividual.Location = new System.Drawing.Point(25, 219);
            this.rbtIndividual.Name = "rbtIndividual";
            this.rbtIndividual.Size = new System.Drawing.Size(176, 19);
            this.rbtIndividual.TabIndex = 18;
            this.rbtIndividual.TabStop = true;
            this.rbtIndividual.Text = "Jede Datei einzeln (Standard)";
            this.rbtIndividual.UseVisualStyleBackColor = true;
            this.rbtIndividual.CheckedChanged += new System.EventHandler(this.rbtIndividual_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Methode auswählen";
            // 
            // lblKeyNewDesc
            // 
            this.lblKeyNewDesc.ForeColor = System.Drawing.Color.Black;
            this.lblKeyNewDesc.Location = new System.Drawing.Point(16, 28);
            this.lblKeyNewDesc.Name = "lblKeyNewDesc";
            this.lblKeyNewDesc.Size = new System.Drawing.Size(328, 71);
            this.lblKeyNewDesc.TabIndex = 9;
            this.lblKeyNewDesc.Text = "Die Dateien werden kompressiert und zusammengefasst.\r\nDas entstandene Archiv wird" +
    " anschließend verschlüsselt.\r\n\r\nDieser Auftrag wird nicht in der Warteschlange e" +
    "ingereiht sondern sofort ausgeführt.";
            this.lblKeyNewDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(331, 34);
            this.label4.TabIndex = 12;
            this.label4.Text = "Jede Datei wird als einzelne Datei und individuell behandelt.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 44);
            this.panel1.TabIndex = 21;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(255, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 25);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Übernehmen";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 62);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "                                     ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblKeyNewDesc);
            this.groupBox2.Location = new System.Drawing.Point(13, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 118);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "                                                  ";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(362, 36);
            this.label2.TabIndex = 22;
            this.label2.Text = "Sie sind dabei mehrere Dateien hinzuzufügen.\r\nBitte wählen Sie die gewünschte Met" +
    "hode.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbtEqual
            // 
            this.rbtEqual.AutoSize = true;
            this.rbtEqual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbtEqual.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.rbtEqual.Location = new System.Drawing.Point(25, 295);
            this.rbtEqual.Name = "rbtEqual";
            this.rbtEqual.Size = new System.Drawing.Size(123, 19);
            this.rbtEqual.TabIndex = 23;
            this.rbtEqual.Text = "Alle Dateien gleich";
            this.rbtEqual.UseVisualStyleBackColor = true;
            this.rbtEqual.CheckedChanged += new System.EventHandler(this.rbtEqual_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 297);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 83);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "                                     ";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(331, 49);
            this.label3.TabIndex = 12;
            this.label3.Text = "Jede Datei wird als einzelne Datei behandelt, jedoch werden für alle Dateien die " +
    "gleichen Einstellungen verwendet.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DragDropDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(388, 443);
            this.ControlBox = false;
            this.Controls.Add(this.rbtEqual);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtCompress);
            this.Controls.Add(this.rbtIndividual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DragDropDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Methode auswählen";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtCompress;
        private System.Windows.Forms.RadioButton rbtIndividual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKeyNewDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtEqual;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
    }
}