using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suoja
{
    public partial class DragDropDialog : Form
    {
        public DragDropDialog()
        {
            InitializeComponent();
            Method = EnumerationTypes.HandleMethod.Individual;
        }

        public EnumerationTypes.HandleMethod Method { get; set; }

        private void rbtCompress_CheckedChanged(object sender, EventArgs e)
        {
            setHandleMethod();
        }

        private void rbtIndividual_CheckedChanged(object sender, EventArgs e)
        {
            setHandleMethod();
        }

        private void rbtEqual_CheckedChanged(object sender, EventArgs e)
        {
            setHandleMethod();
        }

        private void setHandleMethod()
        {
            if (rbtCompress.Checked)
            {
                Method = EnumerationTypes.HandleMethod.Compress;
            }
            else if (rbtIndividual.Checked)
            {
                Method = EnumerationTypes.HandleMethod.Individual;
            }
            else if (rbtEqual.Checked)
            {
                Method = EnumerationTypes.HandleMethod.Equal;
            }
        }
    }
}
