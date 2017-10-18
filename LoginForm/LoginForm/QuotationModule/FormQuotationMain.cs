using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationMain : Form
    {
        List<Quotation> quotationList;

        public FormQuotationMain()
        {
            InitializeComponent();
            bringQuotationList();
        }

        private void btnNewQuotation_Click(object sender, EventArgs e)
        {
            var a = datetimeStart.Value;
            this.Hide();
            QuotationAdd quotationForm = new QuotationAdd();
            quotationForm.ShowDialog();
            this.Show();
        }

        private void bringQuotationList()
        {
            IMEEntities IME = new IMEEntities();
            bringQuotationList(DateTime.Today, DateTime.Today.AddDays(-7));
        }
        private void bringQuotationList(DateTime startDate, DateTime endDate)
        {
            IMEEntities IME = new IMEEntities();

            quotationList = IME.Quotations.Where(q => (q.StartDate >= endDate) && (q.StartDate <= startDate)).ToList();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            //bringQuotationList(datetimeStart.Value, datetimeEnd.Value);
        }

        private void populateGrid()
        {
            //dgQuotation.DataSource = null;
            //dgQuotation.DataSource = quotationList;
        }

        private void btnModifyQuotation_Click(object sender, EventArgs e)
        {
            //Quotation q = (Quotation)dgQuotation.CurrentRow.DataBoundItem;

            //QuotationAdd formQuot = new QuotationAdd( );
        }

        private void FormQuotationMain_Load(object sender, EventArgs e)
        {
            bringQuotationList();

            dgQuotation.DataSource = quotationList;
        }
    }
}
