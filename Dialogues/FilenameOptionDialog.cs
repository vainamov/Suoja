using System;
using System.Windows.Forms;

namespace Suoja
{
    public partial class FilenameOptionDialog : Form
    {
        public EnumerationTypes.FileNameOption Option { get; set; }

        public FilenameOptionDialog()
        {
            InitializeComponent();
        }

        private void rbtKeep_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtKeep.Checked)
            {
                Option = EnumerationTypes.FileNameOption.Keep;
            }
            else
            {
                Option = EnumerationTypes.FileNameOption.Encode;
            }
        }

        private void FilenameOptionDialog_Shown(object sender, EventArgs e)
        {
            if (Option == EnumerationTypes.FileNameOption.Encode)
            {
                rbtEncode.Checked = true;
            }
        }
    }
}
