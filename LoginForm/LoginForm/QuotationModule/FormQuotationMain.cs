using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationMain : Form
    {
        DateTime dateNow;

        public FormQuotationMain()
        {
            IMEEntities IME = new IMEEntities();
            InitializeComponent();
            dateNow = Convert.ToDateTime(new IMEEntities().CurrentDate().First());
            dtpFromDate.Value = Convert.ToDateTime(IME.CurrentDate().First()).AddMonths(-1);
        }

        private void btnNewQuotation_Click(object sender, EventArgs e)
        {
            var a = dtpFromDate.Value;
            FormQuotationAdd quotationForm = new FormQuotationAdd(this);
            quotationForm.Show();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            BringQuotationList(dtpFromDate.Value, dtpToDate.Value);
        }

        private void dgQuotation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1125).FirstOrDefault() != null)//Can Edit any Quotation
            {
                ModifyQuotation();
            }
           
        }

        private void btnDeleteQuotation_Click(object sender, EventArgs e)
        {
            if (dgQuotation.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show("Selected quotation(s) will be deleted! Do you confirm?", "Delete Quotation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        IMEEntities IME = new IMEEntities();

                        foreach (DataGridViewRow row in dgQuotation.SelectedRows)
                        {
                            string QuotationNo = row.Cells["QuotationNo"].Value.ToString();

                            Quotation quo = IME.Quotations.Where(q => q.QuotationNo == QuotationNo).FirstOrDefault();

                            IME.QuotationDetails.RemoveRange(quo.QuotationDetails);

                            IME.Quotations.Remove(quo);
                        }

                        IME.SaveChanges();

                        BringQuotationList();

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

        private void btnModifyQuotation_Click(object sender, EventArgs e)
        {
            ModifyQuotation();
        }

        private void FormQuotationMain_Load(object sender, EventArgs e)
        {
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1126).FirstOrDefault() == null)//Can Delete Quotation
            {
               btnDeleteQuotation.Enabled = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1125).FirstOrDefault() == null)//Can Delete edit
            {
                btnModifyQuotation.Enabled = false;
            }
            if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1127).FirstOrDefault() == null)//Can Delete Quotation
            {
                btnNewQuotation.Enabled = false;
            }
            BringQuotationList();
            #region Refresh
            BringQuotationList(dtpFromDate.Value, dtpToDate.Value);
            #endregion
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if(cbSearch.SelectedItem != null && cbSearch.SelectedItem.ToString() == "QUOT NUMBER")
                {
                    IMEEntities IME = new IMEEntities();

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
                Quotation quo;

                IMEEntities IME = new IMEEntities();
                try
                {
                    quo = IME.Quotations.Where(q => q.QuotationNo == QuotationNo).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
                if (quo != null)
                {
                    FormQuotationAdd newForm = new FormQuotationAdd(quo);
                    newForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
        }

        public void BringQuotationList()
        {
            IMEEntities IME = new IMEEntities();
            BringQuotationList(dateNow.AddMonths(-1), dateNow.AddDays(1));
        }

        private void BringQuotationList(DateTime fromDate, DateTime toDate)
        {
            
            IMEEntities IME = new IMEEntities();
           // DateTime time = Convert.ToDateTime(IME.CurrentDate().FirtsOrDefault());
          //  MessageBox.Show(time.ToString());
            var list = (from q in IME.Quotations
                       join c in IME.Customers on q.CustomerID equals c.ID
                       where q.StartDate >= fromDate && q.StartDate < toDate 
                       select new
                       {
                           Date = (DateTime)q.StartDate,
                           QuotationNo = q.QuotationNo,
                           RFQ = q.RFQNo,
                           CustomerName = c.c_name
                       }).OrderByDescending(x=> x.QuotationNo);

            populateGrid(list.ToList());
            //.OrderByDescending(x => int.Parse(x.QuotationNo.Substring(5)).ToList());
        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgQuotation.DataSource = null;
            dgQuotation.DataSource = queryable;
            dgQuotation.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgQuotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Utils.getCurrentUser().AuthorizationValues.Where(a => a.AuthorizationID == 1126).FirstOrDefault() == null)//Can Delete Quotation
                {
                    btnDeleteQuotation.PerformClick();
                }

                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.QuotationMainExport(dgQuotation, dtpFromDate.Value, dtpToDate.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
