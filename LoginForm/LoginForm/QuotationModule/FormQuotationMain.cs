using LoginForm.DataSet;
using System;
using System.Collections.Generic;
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
            datetimeEnd.Value = DateTime.Now.AddDays(-7);
            bringQuotationList();
        }

        private void btnNewQuotation_Click(object sender, EventArgs e)
        {
            var a = datetimeStart.Value;
            this.Hide();
            FormQuotationAdd quotationForm = new FormQuotationAdd();
            quotationForm.ShowDialog();
            //deneme quotationForm = new deneme();
            //quotationForm.Show();
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

            //quotationList = IME.Quotations.Where(q => (q.StartDate >= endDate) && (q.StartDate <= startDate)).ToList();

            var list = from q in IME.Quotations
                       join c in IME.Customers on q.CustomerID equals c.ID
                       where q.StartDate >= endDate && q.StartDate <= startDate
                       select new
                       {
                           Date = q.StartDate,
                           QuotationNo = q.QuotationNo,
                           RFQ = q.RFQNo,
                           CustomerName = c.c_name
                       };

            populateGrid(list.ToList());
        }

        private void populateGrid(List<object> list)
        {
            throw new NotImplementedException();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            bringQuotationList(datetimeStart.Value, datetimeEnd.Value);
            //populateGrid();
        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgQuotation.DataSource = null;
            dgQuotation.DataSource = queryable;
        }

        private void btnModifyQuotation_Click(object sender, EventArgs e)
        {
            ModifyQuotation();
        }

        private void FormQuotationMain_Load(object sender, EventArgs e)
        {
            bringQuotationList();
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if(cbSearch.SelectedItem != null && cbSearch.SelectedItem.ToString() == "QUOT NUMBER")
                {
                    IMEEntities IME = new IMEEntities();

                    //quotationList = IME.Quotations.Where(q => (q.StartDate >= endDate) && (q.StartDate <= startDate)).ToList();

                    var list = from q in IME.Quotations
                               join c in IME.Customers on q.CustomerID equals c.ID
                               where q.QuotationNo.Contains(txtSearchText.Text)
                               select new
                               {
                                   Date = q.StartDate,
                                   QuotationNo = q.QuotationNo,
                                   CustomerName = c.c_name
                               };

                    populateGrid(list.ToList());
                }
            }
        }

        private void ModifyQuotation()
        {
            if (dgQuotation.CurrentRow != null)
            {
                string QuotationNo = dgQuotation.CurrentRow.Cells["QuotationNo"].Value.ToString();

                IMEEntities IME = new IMEEntities();
                Quotation quo = IME.Quotations.Where(q => q.QuotationNo == QuotationNo).FirstOrDefault();

                FormQuotationAdd newForm = new FormQuotationAdd(quo);
                newForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
        }

        private void dgQuotation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ModifyQuotation();
        }

        private void btnDeleteQuotation_Click(object sender, EventArgs e)
        {
            if (dgQuotation.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Selected quotation will be deleted! Do you confirm?", "Delete Quotation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        string QuotationNo = dgQuotation.CurrentRow.Cells["QuotationNo"].Value.ToString();

                        IMEEntities IME = new IMEEntities();
                        Quotation quo = IME.Quotations.Where(q => q.QuotationNo == QuotationNo).FirstOrDefault();

                        quo.QuotationDetails.Clear();
                        IME.SaveChanges();

                        IME.Quotations.Remove(quo);
                        IME.SaveChanges();

                        bringQuotationList();

                        MessageBox.Show("Quotation is successfully deleted.", "Success!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error was encountered", "Error!");
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
        }
    }
}
