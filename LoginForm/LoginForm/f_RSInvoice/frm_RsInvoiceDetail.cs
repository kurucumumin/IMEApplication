﻿using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;
using LoginForm.Services;
using System.Data.SqlClient;

namespace LoginForm.f_RSInvoice
{
    public partial class frm_RsInvoiceDetail : Form
    {
        int InvoiceID;
        RS_Invoice Invoice;
        DataTable RsInvoiceDetails = new DataTable();
        DataTable RsInvoiceMaster = new DataTable();

        public frm_RsInvoiceDetail(int InvoiceID)
        {
            InitializeComponent();
            this.InvoiceID = InvoiceID;
            lblSave.Visible = false;
            btnSave.Visible = false;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgRsInvoiceItems, new object[] { true });
        }

        public frm_RsInvoiceDetail(RS_Invoice Invoice)
        {
            InitializeComponent();
            this.Invoice = Invoice;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgRsInvoiceItems, new object[] { true });
        }

        private void frm_RsInvoiceDetail_Load(object sender, EventArgs e)
        {
            if (Invoice == null)
            {
                bgw_RsInvoiceDetail.RunWorkerAsync();
                bgw_RsInvoiceMaster.RunWorkerAsync();
            }
            else
            {
                SetRsInvoiceMaster();
                SetRsInvoiceDetails();
            }
        }

        private void SetRsInvoiceDetails()
        {
            dgRsInvoiceItems.Rows.Clear();
            SetDataGridItemsFromListRsInvoiceDetail();
            dgRsInvoiceItems.Refresh();
        }

        private void SetRsInvoiceMaster()
        {
            txtBillingDocumentDate.Text = Invoice.BillingDocumentDate.ToString();
            txtBillingDocumentReference.Text = Invoice.BillingDocumentReference.ToString();
            txtCustomerReference.Text = Invoice.CustomerReference.ToString();
            txtAirwayBillNumber.Text = Invoice.AirwayBillNumber.ToString();
            txtSupplyingECCompany.Text = Invoice.SupplyingECCompany.ToString();
            txtSupplyingECCompany.Text = Invoice.SupplyingECCompany.ToString();
            txtShipmentReference.Text = Invoice.ShipmentReference.ToString();
            txtShippingCondition.Text = Invoice.ShippingCondition.ToString();
            txtStatus.Text = Invoice.Status?.ToString();
            txtDeleted.Text = Invoice.Deleted.ToString();
            txtCurrency.Text = Invoice.Currency.ToString();
            txtInvoiceTaxValue.Text = Invoice.InvoiceTaxValue.ToString();
            txtInvoiceGoodsValue.Text = Invoice.InvoiceGoodsValue.ToString();
            txtInvoiceNettValue.Text = Invoice.InvoiceNettValue.ToString();
            txtDiscount.Text = Invoice.Discount.ToString();
            txtSurcharge.Text = Invoice.Surcharge.ToString();
        }

        private void bgw_RsInvoiceDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            RsInvoiceDetails = new Sp_RSInvoice().GetRSInvoiceDetailWithInvoiceID(InvoiceID);
        }

        private void bgw_RsInvoiceDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgRsInvoiceItems.Rows.Clear();
            SetDataGridItemsFromDataTableRsInvoiceDetail(RsInvoiceDetails);
            dgRsInvoiceItems.Refresh();
        }

        private void SetDataGridItemsFromDataTableRsInvoiceDetail(DataTable dataTable)
        {
            foreach (DataRow dRow in dataTable.Rows)
            {
                DataGridViewRow gRow = dgRsInvoiceItems.Rows[dgRsInvoiceItems.Rows.Add()];

                gRow.Cells[dgPurchaseOrderNumber.Index].Value = dRow["PurchaseOrderNumber"].ToString();
                gRow.Cells[dgPurchaseOrderItemNumber.Index].Value = dRow["PurchaseOrderItemNumber"].ToString();
                gRow.Cells[dgProductNumber.Index].Value = dRow["ProductNumber"].ToString();
                gRow.Cells[dgBillingItemNumber.Index].Value = dRow["BillingItemNumber"].ToString();
                gRow.Cells[dgQuantity.Index].Value = dRow["Quantity"].ToString();
                gRow.Cells[dgSalesUnit.Index].Value = dRow["SalesUnit"].ToString();
                gRow.Cells[dgDiscount.Index].Value = dRow["Discount"].ToString();
                gRow.Cells[dgGoodsValue.Index].Value = dRow["GoodsValue"].ToString();
                gRow.Cells[dgAmount.Index].Value = dRow["Amount"].ToString();
                gRow.Cells[dgCCCNNO.Index].Value = dRow["CCCNNO"].ToString();
                gRow.Cells[dgCountryofOrigin.Index].Value = dRow["CountryofOrigin"].ToString();
                gRow.Cells[dgArticleDescription.Index].Value = dRow["ArticleDescription"].ToString();
                gRow.Cells[dgDeliveryNumber.Index].Value = dRow["DeliveryNumber"].ToString();
                gRow.Cells[dgDeliveryItemNumber.Index].Value = dRow["DeliveryItemNumber"].ToString();
                gRow.Cells[dgPurchaseOrderID.Index].Value = dRow["PurchaseOrderID"].ToString();
                gRow.Cells[dgTax.Index].Value = dRow["Tax"].ToString();
            }
        }
        private void SetDataGridItemsFromListRsInvoiceDetail()
        {
            foreach (RS_InvoiceDetails item in Invoice.RS_InvoiceDetails)
            {
                DataGridViewRow gRow = dgRsInvoiceItems.Rows[dgRsInvoiceItems.Rows.Add()];

                gRow.Cells[dgPurchaseOrderNumber.Index].Value = item.PurchaseOrderNumber.ToString();
                gRow.Cells[dgPurchaseOrderItemNumber.Index].Value = item.PurchaseOrderItemNumber.ToString();
                gRow.Cells[dgProductNumber.Index].Value = item.ProductNumber.ToString();
                gRow.Cells[dgBillingItemNumber.Index].Value = item.BillingItemNumber.ToString();
                gRow.Cells[dgQuantity.Index].Value = item.Quantity.ToString();
                gRow.Cells[dgSalesUnit.Index].Value = item.SalesUnit.ToString();
                gRow.Cells[dgDiscount.Index].Value = item.Discount.ToString();
                gRow.Cells[dgGoodsValue.Index].Value = item.GoodsValue.ToString();
                gRow.Cells[dgAmount.Index].Value = item.Amount.ToString();
                gRow.Cells[dgCCCNNO.Index].Value = item.CCCNNO.ToString();
                gRow.Cells[dgCountryofOrigin.Index].Value = item.CountryofOrigin.ToString();
                gRow.Cells[dgArticleDescription.Index].Value = item.ArticleDescription.ToString();
                gRow.Cells[dgDeliveryNumber.Index].Value = item.DeliveryNumber.ToString();
                gRow.Cells[dgDeliveryItemNumber.Index].Value = item.DeliveryItemNumber.ToString();
                gRow.Cells[dgPurchaseOrderID.Index].Value = item.PurchaseOrderID.ToString();
                gRow.Cells[dgTax.Index].Value = item.Tax.ToString();
            }
        }

        private void bgw_RsInvoiceMaster_DoWork(object sender, DoWorkEventArgs e)
        {
            RsInvoiceMaster = new Sp_RSInvoice().GetRSInvoiceWithInvoiceID(InvoiceID);
        }

        private void bgw_RsInvoiceMaster_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtBillingDocumentDate.Text = RsInvoiceMaster.Rows[0]["BillingDocumentDate"].ToString();
            txtBillingDocumentReference.Text = RsInvoiceMaster.Rows[0]["BillingDocumentReference"].ToString();
            txtCustomerReference.Text = RsInvoiceMaster.Rows[0]["CustomerReference"].ToString();
            txtAirwayBillNumber.Text = RsInvoiceMaster.Rows[0]["AirwayBillNumber"].ToString();
            txtSupplyingECCompany.Text = RsInvoiceMaster.Rows[0]["SupplyingECCompany"].ToString();
            txtSupplyingECCompany.Text = RsInvoiceMaster.Rows[0]["SupplyingECCompany"].ToString();
            txtShipmentReference.Text = RsInvoiceMaster.Rows[0]["ShipmentReference"].ToString();
            txtShippingCondition.Text = RsInvoiceMaster.Rows[0]["ShippingCondition"].ToString();
            txtStatus.Text = RsInvoiceMaster.Rows[0]["Status"].ToString();
            txtDeleted.Text = RsInvoiceMaster.Rows[0]["Deleted"].ToString();
            txtCurrency.Text = RsInvoiceMaster.Rows[0]["Currency"].ToString();
            txtInvoiceTaxValue.Text = RsInvoiceMaster.Rows[0]["InvoiceTaxValue"].ToString();
            txtInvoiceGoodsValue.Text = RsInvoiceMaster.Rows[0]["InvoiceGoodsValue"].ToString();
            txtInvoiceNettValue.Text = RsInvoiceMaster.Rows[0]["InvoiceNettValue"].ToString();
            txtDiscount.Text = RsInvoiceMaster.Rows[0]["Discount"].ToString();
            txtSurcharge.Text = RsInvoiceMaster.Rows[0]["Surcharge"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int RSInvoiceID = 0;
            try
            {
                IMEEntities IME = new IMEEntities();

                RS_Invoice rs = new RS_Invoice();

                rs.ShipmentReference = Invoice.ShipmentReference.ToString();
                rs.BillingDocumentReference = Invoice.BillingDocumentReference.ToString();
                rs.ShippingCondition = Invoice.ShippingCondition.ToString();
                rs.BillingDocumentDate = Invoice.BillingDocumentDate;
                rs.SupplyingECCompany= Invoice.SupplyingECCompany.ToString();
                rs.CustomerReference= Invoice.CustomerReference.ToString();
                rs.InvoiceTaxValue= Invoice.InvoiceTaxValue;
                rs.InvoiceGoodsValue= Invoice.InvoiceGoodsValue;
                rs.InvoiceNettValue= Invoice.InvoiceNettValue;
                rs.Currency= Invoice.Currency.ToString();
                rs.AirwayBillNumber= Invoice.AirwayBillNumber.ToString();
                rs.Discount = Invoice.Discount;
                rs.Surcharge= Invoice.Surcharge;
                rs.SupplierID = IME.Suppliers.Where(x => x.s_name == "RS").FirstOrDefault().ID;
                rs.CreateDate= Utils.GetCurrentDateTime();
                rs.UserID = Utils.getCurrentUser().WorkerID;
                rs.Deleted= Invoice.Deleted;

                IME.RS_Invoice.Add(rs);
                IME.SaveChanges();

                foreach (RS_InvoiceDetails item in Invoice.RS_InvoiceDetails)
                {
                    RS_InvoiceDetails rsd = new RS_InvoiceDetails();
                    DataGridViewRow gRow = dgRsInvoiceItems.Rows[dgRsInvoiceItems.Rows.Add()];

                    RSInvoiceID = Convert.ToInt32(GetRSInvoiceWithBillingDocumentReference(Invoice.BillingDocumentReference).Rows[0]["ID"]);

                    rsd.RS_InvoiceID = RSInvoiceID;
                    rsd.PurchaseOrderNumber = item.PurchaseOrderNumber.ToString();
                    rsd.PurchaseOrderItemNumber= item.PurchaseOrderItemNumber;
                    rsd.ProductNumber = item.ProductNumber.ToString();
                    rsd.BillingItemNumber = item.BillingItemNumber;
                    rsd.Quantity = item.Quantity;
                    rsd.SalesUnit = item.SalesUnit.ToString();
                    rsd.UnitPrice = item.UnitPrice;
                    rsd.Discount = item.Discount;
                    rsd.GoodsValue = item.GoodsValue;
                    rsd.Amount = item.Amount;
                    rsd.CCCNNO = item.CCCNNO.ToString();
                    rsd.CountryofOrigin = item.CountryofOrigin.ToString();
                    rsd.ArticleDescription = item.ArticleDescription.ToString();
                    rsd.DeliveryNumber = item.DeliveryNumber;
                    rsd.DeliveryItemNumber = item.DeliveryItemNumber;
                    rsd.PurchaseOrderID = item.PurchaseOrderID;
                    rsd.Tax = item.Tax;

                    IME.RS_InvoiceDetails.Add(rsd);
                    IME.SaveChanges();
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("An error was encountered", "Error!");
                throw;
            }

            this.Close();
            //try
            //{
            //    new Sp_RSInvoice().RsInvoiceAdd(Invoice);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }

        public DataTable GetRSInvoiceWithBillingDocumentReference(string reference)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable dataTableResult = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetRSInvoiceWithBillingDocumentReference]"
                };
                cmd.Parameters.AddWithValue("@BillingDocumentReference", reference);

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(dataTableResult);
                imeTransaction.Commit();
            }
            catch (Exception ex)
            {
                imeTransaction.Rollback();
                MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return dataTableResult;
        }
    }
}
