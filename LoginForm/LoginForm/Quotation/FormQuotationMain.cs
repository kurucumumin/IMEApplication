using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginForm.Quotation
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
            //IMEEntities IME = new IMEEntities();

            //quotationList = IME.Quotations.toList();
        }
        private void bringQuotationList(DateTime startDate, DateTime endDate)
        {
            //IMEEntities IME = new IMEEntities();

            //var a = datetimeStart.Value;

            //quotationList = IME.Workers.Where(q => (q.date >= startDate) && (q.date <= endDate)).toList();
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
    }
    public class Quotation
    {
        public Quotation()
        {
        }
    }
}
