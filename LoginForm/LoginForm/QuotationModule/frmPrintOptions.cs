using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class frmPrintOptions : Form
    {
        public frmPrintOptions()
        {
            InitializeComponent();
        }

        public frmPrintOptions(String QuoNo)
        {
            InitializeComponent();
        }

        private void frmPrintOptions_Load(object sender, EventArgs e)
        {

        }

        private void chkIndirimKolonu_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = !this.chkIndirimKolonu.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Program ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
