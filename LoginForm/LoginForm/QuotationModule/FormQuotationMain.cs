using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationMain : MyForm
    {
        DateTime dateNow;

        public FormQuotationMain()
        {
            IMEEntities IME = new IMEEntities();
            InitializeComponent();
            cbSearch.SelectedIndex = 0;
            dateNow = Convert.ToDateTime(new IMEEntities().CurrentDate().First());
            dtpFromDate.Value = Convert.ToDateTime(IME.CurrentDate().First()).AddMonths(-3);
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
            //BringQuotationList();
        }

        private void dgQuotation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Utils.AuthorityCheck(IMEAuthority.CanEditAnyQuotation))
            {
                ViewQuotation();
            }
           
        }

        private void ViewQuotation()
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
                    FormQuotationAdd newForm = new FormQuotationAdd(quo, "View");
                    newForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
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

                            quo.status = "Deleted";

                            IME.SaveChanges();
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
            if (!Utils.AuthorityCheck(IMEAuthority.CanDeleteQuotation))//Can Delete Quotation
            {
               btnDeleteQuotation.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanEditAnyQuotation))//Can Modify edit
            {
                btnModifyQuotation.Enabled = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.CanAddQuotation))//Can Add Quotation
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
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && cbSearch.SelectedItem != null)
            {
                IMEEntities IME = new IMEEntities();
                switch (cbSearch.SelectedItem.ToString())
                {
                    case "QUOT NUMBER":
                        var list1 = from q in IME.Quotations
                                   join c in IME.Customers on q.CustomerID equals c.ID
                                   where q.QuotationNo.Contains(txtSearchText.Text)
                                   select new
                                   {
                                       Date = (DateTime)q.StartDate,
                                       QuotationNo = q.QuotationNo,
                                       RFQ = q.RFQNo,
                                       CustomerCode = c.ID,
                                       CustomerName = c.c_name
                                   };

                        populateGrid(list1.ToList());
                        break;

                    case "CUSTOMER CODE":
                        string customerCode = txtSearchText.Text.ToUpperInvariant();
                        var list2 = from q in IME.Quotations
                                    join c in IME.Customers on q.CustomerID equals c.ID
                                    where c.ID.Contains(customerCode)
                                    select new
                                    {
                                        Date = (DateTime)q.StartDate,
                                        QuotationNo = q.QuotationNo,
                                        RFQ = q.RFQNo,
                                        CustomerCode = c.ID,
                                        CustomerName = c.c_name
                                    };

                        populateGrid(list2.ToList());
                        break;

                    case "CUSTOMER NAME":
                        string customerName = txtSearchText.Text.ToUpperInvariant();
                        var list3 = from q in IME.Quotations
                                   join c in IME.Customers on q.CustomerID equals c.ID
                                   where c.c_name.Contains(customerName)
                                    select new
                                   {
                                       Date = (DateTime)q.StartDate,
                                       QuotationNo = q.QuotationNo,
                                       RFQ = q.RFQNo,
                                       CustomerCode = c.ID,
                                       CustomerName = c.c_name
                                   };

                        populateGrid(list3.ToList());
                        break;

                    case "BY TOTAL AMOUNT":
                        decimal amountDecimal;
                        string searchTxt = txtSearchText.Text.Replace(",", ".");
                        if (Decimal.TryParse(searchTxt, out amountDecimal))
                        {
                            int amount = Decimal.ToInt32(amountDecimal);
                            var list4 = from q in IME.Quotations
                                        join c in IME.Customers on q.CustomerID equals c.ID
                                        where amount <= q.GrossTotal && q.GrossTotal < (amount+1) 
                                    select new
                                    {
                                        Date = (DateTime)q.StartDate,
                                        QuotationNo = q.QuotationNo,
                                        RFQ = q.RFQNo,
                                        CustomerCode = c.ID,
                                        CustomerName = c.c_name
                                    };

                            populateGrid(list4.ToList());
                        }
                        
                        break;

                    case "BY RFQ":
                        string rfq = txtSearchText.Text.ToUpperInvariant();
                        var list5 = from q in IME.Quotations
                                    join c in IME.Customers on q.CustomerID equals c.ID
                                    where q.RFQNo.Contains(rfq)
                                    select new
                                    {
                                        Date = (DateTime)q.StartDate,
                                        QuotationNo = q.QuotationNo,
                                        RFQ = q.RFQNo,
                                        CustomerCode = c.ID,
                                        CustomerName = c.c_name
                                    };

                        populateGrid(list5.ToList());
                        break;

                    case "BY MPN":
                        //string mpn = txtSearchText.Text.ToUpperInvariant();
                        //var list6 = from q in IME.Quotations
                        //            join qd in IME.QuotationDetails on q.QuotationNo equals qd.QuotationNo
                        //            join c in IME.Customers on q.CustomerID equals c.ID
                        //            where qd.MPN.Contains(mpn)
                        //            select new
                        //            {
                        //                Date = (DateTime)q.StartDate,
                        //                QuotationNo = q.QuotationNo,
                        //                RFQ = q.RFQNo,
                        //                CustomerCode = c.ID,
                        //                CustomerName = c.c_name
                        //            };

                        //populateGrid(list6.ToList());
                        MessageBox.Show("MPN filter is not implemented into the software","Error");
                        break;
                    default:
                        break;
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
                    FormQuotationAdd newForm = new FormQuotationAdd(quo, this);
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
            var list = (from q in IME.Quotations/*.AsEnumerable()*/
                       join c in IME.Customers on q.CustomerID equals c.ID
                       where q.StartDate >= fromDate && q.StartDate < toDate
                       select new
                       {
                           Date = q.StartDate,
                           QuotationNo = q.QuotationNo,
                           RFQ = q.RFQNo,
                           CustomerCode = c.ID,
                           CustomerName = c.c_name,
                           Representative = q.Worker.NameLastName
                       }).OrderByDescending(x => x.Date);

            populateGrid(list.ToList());
            //.OrderByDescending(x => int.Parse(x.QuotationNo.Substring(5)).ToList());
        }

        public Int32 ConvertInt(String id)
        {
            Int32 locID = Convert.ToInt32(id);
            return locID;
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
                if (!Utils.AuthorityCheck(IMEAuthority.CanDeleteQuotation))//Can Delete Quotation
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
            ExperimentQuotationAdd form = new ExperimentQuotationAdd();
            form.Show();
        }
        

        private string FixItemCode(string _itemCode)
        {
            string result = _itemCode.Replace("-", "");

            if (Int32.TryParse(result, out int x) && result.Length == 6)
            {
                result = "0" + result;
            }
            return result;
        }

        private void txtStockCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchStockNumber.PerformClick();
            }
        }

        private void btnSearchStockNumber_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtStockCode.Text))
            {
                IMEEntities db = new IMEEntities();

                string stockCode = txtStockCode.Text.ToUpperInvariant();

                if (!chcCustStockNumber.Checked)
                {
                    stockCode = FixItemCode(stockCode);
                    var list = from q in db.Quotations
                               join qd in db.QuotationDetails on q.QuotationNo equals qd.QuotationNo
                               join c in db.Customers on q.CustomerID equals c.ID
                               where qd.ItemCode.Contains(stockCode)
                               select new
                               {
                                   Date = (DateTime)q.StartDate,
                                   QuotationNo = q.QuotationNo,
                                   RFQ = q.RFQNo,
                                   CustomerCode = c.ID,
                                   CustomerName = c.c_name
                               };

                    populateGrid(list.ToList());
                }
                else
                {
                    var list2 = from q in db.Quotations
                                join qd in db.QuotationDetails on q.QuotationNo equals qd.QuotationNo
                                join c in db.Customers on q.CustomerID equals c.ID
                                where qd.CustomerStockCode.Contains(stockCode)
                                select new
                                {
                                    Date = (DateTime)q.StartDate,
                                    QuotationNo = q.QuotationNo,
                                    RFQ = q.RFQNo,
                                    CustomerCode = c.ID,
                                    CustomerName = c.c_name
                                };

                    populateGrid(list2.ToList());
                }
            }
            else
            {
                MessageBox.Show("You should enter a stock code", "Attention!");
                btnRefreshList.PerformClick();
            }
        }
    }
}
