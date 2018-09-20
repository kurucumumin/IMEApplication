using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services.SP
{
    class Sp_RSInvoice
    {
        public Sp_RSInvoice() { }

        public DataTable GetRSInvoiceAll()
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableRsInvoice = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetRSInvoiceAll]"
                };

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(tableRsInvoice);
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
            return tableRsInvoice;
        }

        public DataTable GetRSInvoiceBetweenDates(DateTime FromDate, DateTime ToDate)
        {
            SqlConnection conn = new Utils().ImeSqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction imeTransaction = null;
            DataTable tableRsInvoice = new DataTable();

            try
            {
                imeTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = imeTransaction,
                    CommandText = @"[prc_GetRSInvoiceBetweenDates]"
                };
                cmd.Parameters.AddWithValue("@FromDate", FromDate);
                cmd.Parameters.AddWithValue("@ToDate", ToDate);

                SqlDataAdapter daRsInvoice = new SqlDataAdapter(cmd);
                daRsInvoice.Fill(tableRsInvoice);
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
            return tableRsInvoice;
        }

        public DataTable GetRSInvoiceDetailWithInvoiceID(int InvoiceID)
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
                    CommandText = @"[prc_GetRSInvoiceDetailWithInvoiceID]"
                };
                cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);

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

        public DataTable GetRSInvoiceWithInvoiceID(int InvoiceID)
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
                    CommandText = @"[prc_GetRSInvoiceWithInvoiceID]"
                };
                cmd.Parameters.AddWithValue("@InvoiceID", InvoiceID);

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

        public bool RsInvoiceAdd(RS_Invoice Invoice)
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
                    CommandText = @"[prc_RSInvoiceAdd]"
                };
                cmd.Parameters.AddWithValue("@ShipmentReference", Invoice.BillingDocumentReference);
                cmd.Parameters.AddWithValue("@BillingDocumentReference", Invoice.BillingDocumentReference);
                cmd.Parameters.AddWithValue("@ShippingCondition", Invoice.ShippingCondition);
                cmd.Parameters.AddWithValue("@BillingDocumentDate", Invoice.BillingDocumentDate);
                cmd.Parameters.AddWithValue("@SupplyingECCompany", Invoice.SupplyingECCompany);
                cmd.Parameters.AddWithValue("@CustomerReference", Invoice.CustomerReference);
                cmd.Parameters.AddWithValue("@InvoiceTaxValue", Invoice.InvoiceTaxValue);
                cmd.Parameters.AddWithValue("@InvoiceGoodsValue", Invoice.InvoiceGoodsValue);
                cmd.Parameters.AddWithValue("@InvoiceNettValue", Invoice.InvoiceNettValue);
                cmd.Parameters.AddWithValue("@Currency", Invoice.Currency);
                cmd.Parameters.AddWithValue("@AirwayBillNumber", Invoice.AirwayBillNumber);
                cmd.Parameters.AddWithValue("@Discount", Invoice.Discount);
                cmd.Parameters.AddWithValue("@Surcharge", Invoice.Surcharge);
                cmd.Parameters.AddWithValue("@SupplierID", Invoice.SupplierID);
                cmd.Parameters.AddWithValue("@CreateDate", new IMEEntities().CurrentDate().FirstOrDefault());
                cmd.Parameters.AddWithValue("@UserID", Invoice.UserID);

                cmd.ExecuteNonQuery();

                int RSInvoiceID = Convert.ToInt32(GetRSInvoiceWithBillingDocumentReference(Invoice.BillingDocumentReference).Rows[0]["ID"]);

                foreach (RS_InvoiceDetails item in Invoice.RS_InvoiceDetails)
                {
                    SqlCommand _cmd;

                    _cmd = new SqlCommand
                    {
                        Connection = conn,
                        CommandType = CommandType.StoredProcedure,
                        Transaction = imeTransaction,
                        CommandText = @"[prc_RSInvoiceDetailsAdd]"
                    };
                    cmd.Parameters.AddWithValue("@RS_InvoiceID", RSInvoiceID);
                    cmd.Parameters.AddWithValue("@PurchaseOrderNumber", item.PurchaseOrderNumber);
                    cmd.Parameters.AddWithValue("@PurchaseOrderItemNumber", item.PurchaseOrderItemNumber);
                    cmd.Parameters.AddWithValue("@ProductNumber", item.ProductNumber);
                    cmd.Parameters.AddWithValue("@BillingItemNumber", item.BillingItemNumber);
                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                    cmd.Parameters.AddWithValue("@SalesUnit", item.SalesUnit);
                    cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                    cmd.Parameters.AddWithValue("@Discount", item.Discount);
                    cmd.Parameters.AddWithValue("@GoodsValue", item.GoodsValue);
                    cmd.Parameters.AddWithValue("@Amount", item.Amount);
                    cmd.Parameters.AddWithValue("@CCCNNO", item.CCCNNO);
                    cmd.Parameters.AddWithValue("@CountryofOrigin", item.CountryofOrigin);
                    cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                    cmd.Parameters.AddWithValue("@DeliveryNumber", item.DeliveryNumber);
                    cmd.Parameters.AddWithValue("@DeliveryItemNumber", item.DeliveryItemNumber);
                    cmd.Parameters.AddWithValue("@PurchaseOrderID", item.PurchaseOrderID);

                    cmd.ExecuteNonQuery();
                }
                
                imeTransaction.Commit();
            }
            catch (Exception ex)
            {
                imeTransaction.Rollback();
                MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}
