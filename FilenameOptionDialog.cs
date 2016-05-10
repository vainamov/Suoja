using System;
using System.Windows.Forms;

namespace Suoja
{
    public partial class FilenameOptionDialog : Form
    {

        public enum Filenameoption
        {
            Keep,
            Encode
        }

        public Filenameoption Option { get; set; }

        public FilenameOptionDialog()
        {
            InitializeComponent();
        }

        private void rbtKeep_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtKeep.Checked)
            {
                Option = Filenameoption.Keep;
            }
            else
            {
                Option = Filenameoption.Encode;
            }
        }

        private void FilenameOptionDialog_Shown(object sender, EventArgs e)
        {
            if (Option == Filenameoption.Encode)
            {
                rbtEncode.Checked = true;
            }
        }
    }
}
