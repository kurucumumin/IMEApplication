using LoginForm.DataSet;
using LoginForm.MyClasses;
using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void SetDataGridItemsRsInvoice(DataTable dataTable)
        {
            Color LogoColor = Color.FromArgb(183, 240, 154);
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
    }
}
