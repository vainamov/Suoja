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
            Method = HandleMethod.Individual;
        }

        public enum HandleMethod
        {
            Compress,
            Individual,
            Equal
        }

        public HandleMethod Method { get; set; }

        private void rbtCompress_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCompress.Checked)
            {
                Method = HandleMethod.Compress;
            }
            else if (rbtIndividual.Checked)
            {
                Method = HandleMethod.Individual;
            }
            else if (rbtEqual.Checked)
            {
                Method = HandleMethod.Equal;
            }
        }

        private void rbtIndividual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCompress.Checked)
            {
                Method = HandleMethod.Compress;
            }
            else if (rbtIndividual.Checked)
            {
                Method = HandleMethod.Individual;
            }
            else if (rbtEqual.Checked)
            {
                Method = HandleMethod.Equal;
            }
        }

        private void rbtEqual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCompress.Checked)
            {
                Method = HandleMethod.Compress;
            }
            else if (rbtIndividual.Checked)
            {
                Method = HandleMethod.Individual;
            }
            else if (rbtEqual.Checked)
            {
                Method = HandleMethod.Equal;
            }
        }
    }
}
