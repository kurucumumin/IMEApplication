using LoginForm.DataSet;
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
        Quotation quo;
        List<QuotationDetail> list;

        public frmPrintOptions()
        {
            InitializeComponent();
        }

        public frmPrintOptions(Quotation qd, List<QuotationDetail> data)
        {
            InitializeComponent();
            quo = qd;
            list = data;
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
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FormQuotationPrint form = new FormQuotationPrint();
            if (chkVat.Checked==false)
            {
                form.Print(quo, list, false);
                form.ShowDialog();
            }
            else
            {
                form.Print(quo, list, true);
                form.ShowDialog();
            }

            
        }
    }
}
