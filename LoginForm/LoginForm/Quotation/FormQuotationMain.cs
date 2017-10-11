using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Quotation
{
    public partial class FormQuotationMain : Form
    {
        public FormQuotationMain()
        {
            InitializeComponent();
        }

        private void btnNewQuotation_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuotationAdd quotationForm = new QuotationAdd();
            quotationForm.ShowDialog();
            this.Show();
        }
    }
}
