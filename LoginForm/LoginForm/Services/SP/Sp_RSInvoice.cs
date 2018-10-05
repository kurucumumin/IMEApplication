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
            SqlTransaction invoiceTransaction = null;
            SqlTransaction detailTransaction = null;
            DataTable dataTableResult = new DataTable();

            int RSInvoiceID = 0;

            try
            {
                invoiceTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = invoiceTransaction,
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
                cmd.Parameters.AddWithValue("@CreateDate", Utils.GetCurrentDateTime();
                cmd.Parameters.AddWithValue("@UserID", Invoice.UserID);

                cmd.ExecuteNonQuery();
                invoiceTransaction.Commit();
                try
                {
                    RSInvoiceID = Convert.ToInt32(GetRSInvoiceWithBillingDocumentReference(Invoice.BillingDocumentReference).Rows[0]["ID"]);

                    SqlCommand _cmd;
                    detailTransaction = conn.BeginTransaction();
                    foreach (RS_InvoiceDetails item in Invoice.RS_InvoiceDetails)
                    {
                        _cmd = new SqlCommand
                        {
                            Connection = conn,
                            CommandType = CommandType.StoredProcedure,
                            Transaction = detailTransaction,
                            CommandText = @"[prc_RSInvoiceDetailsAdd]"
                        };
                        _cmd.Parameters.AddWithValue("@RS_InvoiceID", RSInvoiceID);
                        _cmd.Parameters.AddWithValue("@PurchaseOrderNumber", item.PurchaseOrderNumber);
                        _cmd.Parameters.AddWithValue("@PurchaseOrderItemNumber", item.PurchaseOrderItemNumber);
                        _cmd.Parameters.AddWithValue("@ProductNumber", item.ProductNumber);
                        _cmd.Parameters.AddWithValue("@BillingItemNumber", item.BillingItemNumber);
                        _cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                        _cmd.Parameters.AddWithValue("@SalesUnit", item.SalesUnit);
                        _cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        _cmd.Parameters.AddWithValue("@Discount", item.Discount);
                        _cmd.Parameters.AddWithValue("@GoodsValue", item.GoodsValue);
                        _cmd.Parameters.AddWithValue("@Amount", item.Amount);
                        _cmd.Parameters.AddWithValue("@CCCNNO", item.CCCNNO);
                        _cmd.Parameters.AddWithValue("@CountryofOrigin", item.CountryofOrigin);
                        _cmd.Parameters.AddWithValue("@ArticleDescription", item.ArticleDescription);
                        _cmd.Parameters.AddWithValue("@DeliveryNumber", item.DeliveryNumber);
                        _cmd.Parameters.AddWithValue("@DeliveryItemNumber", item.DeliveryItemNumber);
                        _cmd.Parameters.AddWithValue("@PurchaseOrderID", item.PurchaseOrderID);

                        _cmd.ExecuteNonQuery();
                    }
                    detailTransaction.Commit();
                }
                catch (Exception _ex)
                {
                    MessageBox.Show("Database Connection Error. \n\nError Message: " + _ex.ToString(), "Error");
                    IMEEntities db = new IMEEntities();
                    db.RS_Invoice.Remove(db.RS_Invoice.Where(x=>x.ID == RSInvoiceID).FirstOrDefault());
                    detailTransaction.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                invoiceTransaction.Rollback();
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
