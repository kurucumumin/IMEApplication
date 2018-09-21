using LoginForm.DataSet;
using LoginForm.MyClasses;
using LoginForm.Services;
using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.f_RSInvoice
{
    public partial class frm_RSInvoice : Form
    {
        DataTable dt_RsInvoiceList = new DataTable();
        LogoLibrary logoLibrary = new LogoLibrary();

        public frm_RSInvoice()
        {
            InitializeComponent();

            dgvRSInvoice.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);

            dtpToDate.MaxDate = DateTime.Today;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgvRSInvoice, new object[] { true });
        }

        private void frm_RSInvoice_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.AddMonths(-1).Date;

            bgw_RSInvoiceGetter.RunWorkerAsync();
            
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            if (!bgw_RSInvoiceGetter.IsBusy)
            {
                bgw_RSInvoiceGetter.RunWorkerAsync();
            }
        }

        private void ShowHiddenRows()
        {
            foreach (DataGridViewRow row in dgvRSInvoice.Rows)
            {
                if (!row.Visible)
                {
                    row.Visible = true;
                }
            }
        }

        private void HideChoosenRows()
        {
            if (dgvRSInvoice.SelectedRows.Count != 0)
            {
                CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgvRSInvoice.DataSource];
                currencyManager1.SuspendBinding();
                foreach (DataGridViewRow row in dgvRSInvoice.SelectedRows)
                {
                    row.Visible = false;
                }
                currencyManager1.ResumeBinding();
            }
        }

        private void dgRSInvoice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvRSInvoice.HitTest(e.X, e.Y);
                if (hti.ColumnIndex != -1 && hti.RowIndex != -1)
                {
                    dgvRSInvoice.ClearSelection();
                    dgvRSInvoice.Rows[hti.RowIndex].Selected = true;
                }
            }
        }

        private void btnNewInvoice_Click(object sender, EventArgs e)
        {
            RS_Invoice rsInv = RSInvoiceReader();
            if (rsInv != null)
            {
                rsInv.SupplierID = new IMEEntities().Suppliers.Where(x => x.s_name == "RS").FirstOrDefault().ID;
                rsInv.UserID = Utils.getCurrentUser().WorkerID;

                bool InvoiceExist = (new Sp_RSInvoice().GetRSInvoiceWithBillingDocumentReference(rsInv.BillingDocumentReference).Rows.Count > 0) ? true : false;

                if (InvoiceExist)
                {
                    MessageBox.Show("File Is Already Imported!", "Warning");
                }
                else
                {
                    frm_RsInvoiceDetail form = new frm_RsInvoiceDetail(rsInv);
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Correct text file is not choosen!");
            }
        }

        private void viewInvoicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRSInvoice.SelectedRows.Count > 0)
            {
                if (Int32.TryParse(dgvRSInvoice.SelectedRows[0].Cells[dgID.Index].Value.ToString(), out int InvoiceID))
                {
                    frm_RsInvoiceDetail form = new frm_RsInvoiceDetail(InvoiceID);
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select an RS Invoice to view");
            }
        }

        private void sendToLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRSInvoice.SelectedRows.Count > 0)
            {
                string Ref = dgvRSInvoice.SelectedRows[0].Cells[dgBillingDocumentReference.Index].Value.ToString();
                int InvoiceID = Int32.Parse(dgvRSInvoice.SelectedRows[0].Cells[dgID.Index].Value.ToString());
                string resultMessage = logoLibrary.SendToLogo_RSInvoice(Ref);

                if (resultMessage == LogoLibrary.AddSuccessful)
                {
                    IMEEntities db = new IMEEntities();

                    RS_Invoice so = db.RS_Invoice.Where(x => x.ID == InvoiceID).FirstOrDefault();
                    so.Status = "LOGO";
                    db.SaveChanges();

                    btnRefreshList.PerformClick();
                    MessageBox.Show("Sent To Logo Successfully");
                }
                else
                {
                    MessageBox.Show("Operation Failed" + "\n\nError Message: " + resultMessage);
                }
            }
            else
            {
                MessageBox.Show("You Should Choose An RS Invoice!");
            }

            
        }

        private void backFromLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvRSInvoice.SelectedRows.Count > 0)
            {
                string Ref = dgvRSInvoice.SelectedRows[0].Cells[dgBillingDocumentReference.Index].Value.ToString();
                int InvoiceID = Int32.Parse(dgvRSInvoice.SelectedRows[0].Cells[dgID.Index].Value.ToString());
                string resultMessage = logoLibrary.BackFromLogo_RSInvoice(Ref.ToString());

                if (resultMessage == LogoLibrary.DeleteSuccessful)
                {
                    IMEEntities db = new IMEEntities();

                    RS_Invoice so = db.RS_Invoice.Where(x => x.ID == InvoiceID).FirstOrDefault();
                    so.Status = "";
                    db.SaveChanges();

                    btnRefreshList.PerformClick();
                    MessageBox.Show("Deleted From Logo Successfully");
                }
                else
                {
                    MessageBox.Show("Operation Failed" + "\n\nError Message: " + resultMessage);
                }
            }
            else
            {
                MessageBox.Show("You Should Choose An RS Invoice!");
            }

            
        }

        private void bgw_RSInvoiceGetter_DoWork(object sender, DoWorkEventArgs e)
        {
            dt_RsInvoiceList = new Sp_RSInvoice().GetRSInvoiceBetweenDates(dtpFromDate.Value.Date, dtpToDate.Value.AddDays(1).Date);
        }

        private void bgw_RSInvoiceGetter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgvRSInvoice.Rows.Clear();
            SetDataGridItemsRsInvoice(dt_RsInvoiceList);
            dgvRSInvoice.Refresh();
            dgvRSInvoice.ClearSelection();
        }

        private void SetDataGridItemsRsInvoice(DataTable dataTable)
        {
            Color LogoColor = Color.FromArgb(134, 255, 128);
            foreach (DataRow dRow in dataTable.Rows)
            {
                DataGridViewRow gRow = dgvRSInvoice.Rows[dgvRSInvoice.Rows.Add()];

                gRow.Cells[dgID.Index].Value = dRow["ID"].ToString();
                gRow.Cells[dgShipmentReference.Index].Value = dRow["ShipmentReference"].ToString();
                gRow.Cells[dgBillingDocumentReference.Index].Value = dRow["BillingDocumentReference"].ToString();
                gRow.Cells[dgShippingCondition.Index].Value = dRow["ShippingCondition"].ToString();
                gRow.Cells[dgBillingDocumentDate.Index].Value = dRow["BillingDocumentDate"].ToString();
                gRow.Cells[dgSupplyingECCompany.Index].Value = dRow["SupplyingECCompany"].ToString();
                gRow.Cells[dgCustomerReference.Index].Value = dRow["CustomerReference"].ToString();
                gRow.Cells[dgInvoiceTaxValue.Index].Value = dRow["InvoiceTaxValue"].ToString();
                gRow.Cells[dgInvoiceGoodsValue.Index].Value = dRow["InvoiceGoodsValue"].ToString();
                gRow.Cells[dgInvoiceNettValue.Index].Value = dRow["InvoiceNettValue"].ToString();
                gRow.Cells[dgCurrency.Index].Value = dRow["Currency"].ToString();
                gRow.Cells[dgAirwayBillNumber.Index].Value = dRow["AirwayBillNumber"].ToString();
                gRow.Cells[dgDiscount.Index].Value = dRow["Discount"].ToString();
                gRow.Cells[dgSurcharge.Index].Value = dRow["Surcharge"].ToString();
                gRow.Cells[dgStatus.Index].Value = dRow["Status"].ToString();
                gRow.Cells[dgDeleted.Index].Value = dRow["Deleted"].ToString();
                gRow.Cells[dgSupplier.Index].Value = dRow["Supplier"].ToString();
                gRow.Cells[dgUser.Index].Value = dRow["User"].ToString();
                gRow.Cells[dgCreateDate.Index].Value = dRow["CreateDate"].ToString();
                gRow.Cells[dgSupplierID.Index].Value = dRow["SupplierID"].ToString();
                gRow.Cells[dgUserID.Index].Value = dRow["UserID"].ToString();

                if (dRow["Status"].ToString() == "LOGO")
                {
                    gRow.DefaultCellStyle.BackColor = LogoColor;
                }
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if(dtpFromDate.Value > dtpToDate.Value)
            {
                dtpToDate.Value = dtpFromDate.Value;
            }
            dtpToDate.MinDate = dtpFromDate.Value;
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (dgvRSInvoice.SelectedRows.Count != 0)
            {
                frm_RsInvoiceDetail form = new frm_RsInvoiceDetail(Int32.Parse(dgvRSInvoice.SelectedRows[0].Cells[dgID.Index].Value.ToString()));
                form.Show();
            }
            else
            {
                MessageBox.Show("You Should Choose An RS Invoice!");
            }
        }

        private RS_Invoice RSInvoiceReader()
        {
            //Show the dialog and get result.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.Multiselect = true;
            DialogResult result1 = openFileDialog1.ShowDialog();
            RS_Invoice RSInvoice = new RS_Invoice();

            if (result1 == DialogResult.OK) // Test result.
            {
                for (int i = 0; i < openFileDialog1.FileNames.Count(); i++)
                {
                    string[] lines = System.IO.File.ReadAllLines(openFileDialog1.FileNames[i]);
                    bool istrue = true;
                    bool isItem = false;
                    RS_InvoiceDetails RS_InvoiceDetails = new RS_InvoiceDetails();
                    if (lines[0].Length > 2 && lines[0].Substring(0, 2) == "FH")
                    {
                        if (lines[0].Substring(5, 14).ToString().Trim() != "") RSInvoice.BillingDocumentDate = DateTime.ParseExact(lines[0].Substring(5, 15).ToString(), "dd.MM.yyyyHH.mm", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        return null;
                    }

                    if (lines[1].Substring(0, 2) == "IV")
                    {
                        if (lines[1].Substring(2, 10).ToString().Trim() != "") RSInvoice.ShipmentReference = lines[1].Substring(2, 10).ToString().Trim();
                        if (lines[1].Substring(12, 10).ToString().Trim() != "") RSInvoice.BillingDocumentReference = lines[1].Substring(12, 10).ToString().Trim();
                        if (lines[1].Substring(22, 2).ToString().Trim() != "") RSInvoice.ShippingCondition = lines[1].Substring(22, 2).ToString().Trim();
                        if (lines[1].Substring(32, 4).ToString().Trim() != "") RSInvoice.SupplyingECCompany = lines[1].Substring(32, 4).Trim();
                        if (lines[1].Substring(36, 10).ToString().Trim() != "") RSInvoice.CustomerReference = lines[1].Substring(36, 10).Trim();
                        if (lines[1].Substring(46, 18).ToString().Trim() != "") RSInvoice.InvoiceTaxValue = Convert.ToDecimal(lines[1].Substring(46, 18).ToString().Trim());
                        if (lines[1].Substring(64, 18).ToString().Trim() != "") RSInvoice.InvoiceGoodsValue = Convert.ToDecimal(lines[1].Substring(64, 18).ToString().Trim());
                        if (lines[1].Substring(82, 18).ToString().Trim().ToString().Trim() != "") RSInvoice.InvoiceNettValue = Convert.ToDecimal(lines[1].Substring(82, 18).ToString().Trim());
                        if (lines[1].Substring(100, 3).ToString().Trim() != "") RSInvoice.Currency = lines[1].Substring(100, 3).ToString().Trim();
                        if (!String.IsNullOrEmpty(lines[1].Substring(113, 20).ToString().Trim()))
                        {
                            RSInvoice.AirwayBillNumber = "";
                        }
                        else
                        {
                            RSInvoice.AirwayBillNumber = lines[1].Substring(120, 20).ToString().Trim();
                        }
                    }

                    RSInvoice.Discount = 0;
                    RSInvoice.Surcharge = 0;

                    List<RS_InvoiceDetails> InvoiceDetails = new List<RS_InvoiceDetails>();
                    int a = 4;
                    while (lines.Count() > a)
                    {
                        RS_InvoiceDetails rs = new RS_InvoiceDetails();
                        if (lines[a].Substring(0, 2) == "OI")
                        {
                            if (lines[a].Substring(2, 30).ToString().Trim() != "") rs.PurchaseOrderNumber = lines[a].Substring(2, 30).ToString().Trim();
                            if (lines[a].Substring(32, 6).ToString().Trim() != "") rs.PurchaseOrderItemNumber = Convert.ToInt32(lines[a].Substring(32, 6).ToString().Trim());
                            if (lines[a].Substring(38, 18).ToString().Trim() != "") rs.ProductNumber = lines[a].Substring(38, 18).ToString().Trim();
                            if (lines[a].Substring(56, 6).ToString().Trim() != "") rs.BillingItemNumber = Convert.ToInt32(lines[a].Substring(56, 6).ToString().Trim());
                            if (lines[a].Substring(62, 15).ToString().Trim() != "") rs.Quantity = (int)Decimal.Parse(lines[a].Substring(62, 15).ToString().Trim());

                            if (lines[a].Substring(77, 3).ToString().Trim() != "") rs.SalesUnit = lines[a].Substring(77, 3).ToString().Trim();
                            if (lines[a].Substring(80, 11).ToString().Trim() != "") rs.UnitPrice = decimal.Parse(lines[a].Substring(80, 11).ToString().Trim());
                            if (lines[a].Substring(91, 11).ToString().Trim() != "") rs.Discount = decimal.Parse(lines[a].Substring(91, 11).ToString().Trim());
                            if (lines[a].Substring(113, 11).ToString().Trim() != "") rs.GoodsValue = decimal.Parse(lines[a].Substring(113, 11).ToString().Trim());
                            if (lines[a].Substring(124, 11).ToString().Trim() != "") rs.Amount = decimal.Parse(lines[a].Substring(124, 11).ToString().Trim());
                            if (lines[a].Substring(135, 15).ToString().Trim() != "") rs.CCCNNO = lines[a].Substring(135, 15).ToString().Trim();
                            if (lines[a].Substring(150, 3).ToString().Trim() != "") rs.CountryofOrigin = lines[a].Substring(150, 3).ToString().Trim();
                            if (lines[a].Substring(153, 40).ToString().Trim() != "") rs.ArticleDescription = lines[a].Substring(153, 40).ToString().Trim();
                            if (lines[a].Substring(193, 10).ToString().Trim() != "") rs.DeliveryNumber = decimal.Parse(lines[a].Substring(193, 10).ToString().Trim());
                            if (!String.IsNullOrEmpty(lines[a].Substring(203, 6).ToString().Trim()))
                            {
                                rs.DeliveryItemNumber = 0;
                            }
                            else
                            {
                                rs.DeliveryItemNumber = Int32.Parse(lines[a].Substring(203, 6).ToString().Trim());
                            }
                            rs.PurchaseOrderID = Int32.Parse(rs.PurchaseOrderNumber.ToString().Substring(0, rs.PurchaseOrderNumber.ToString().IndexOf('R')).ToString());
                            RSInvoice.RS_InvoiceDetails.Add(rs);
                        }
                        a++;
                    }
                    if (istrue == false)
                    {
                        MessageBox.Show("the contents of the file are not correct");
                    }
                }
            }
            else
            {
                return null;
            }
            return RSInvoice;
        }
        
    }
}
