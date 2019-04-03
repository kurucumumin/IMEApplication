using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        LogoSQL logosql = new LogoSQL();
        private readonly string server = @"ime.resetbulut.com,47500";
        private readonly string logodatabase = "LOGO";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";

        DataTable currencyList = new DataTable();
        LogoLibrary logoLibrary = new LogoLibrary();

        public frmCustomerGroup()
        {
            InitializeComponent();


            dgMonthly.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgMonthly, new object[] { true });
        }

        public DataTable Monthly_Sales(int monthly)
        {
            dgMonthly.DataSource = null;
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
                    CommandText = @"[prc_Monthly_Sales]"
                };
                cmd.Parameters.AddWithValue("@year", monthly);

                SqlDataAdapter daMonthly = new SqlDataAdapter(cmd);
                daMonthly.Fill(dataTableResult);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkSalesOrders.Checked==true)
            {
                currencyList = Monthly_Sales(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
                dgMonthly.DataSource = currencyList;
            }
            else
            {
                currencyList = IME_CustomerGroupReport(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
                dgMonthly.DataSource = currencyList;
            }

            if (dgMonthly.RowCount > 0)
            {
                for (int i = 7; i < dgMonthly.ColumnCount; i++)
                {
                    dgMonthly.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgMonthly.Columns[6].DefaultCellStyle.Format = "N2";
                    dgMonthly.Columns[i].DefaultCellStyle.Format = "N2";
                }

                for (int i = 0; i < dgMonthly.RowCount; i++)
                {

                    if (dgMonthly.Rows[i].Cells["Y1_Total"].FormattedValue.ToString() != "0.00")
                    {
                        dgMonthly.Rows[i].Cells["Status"].Value = "Existing";
                    }
                    else if (dgMonthly.Rows[i].Cells["Y1_Total"].FormattedValue.ToString() == "0.00")
                    {
                        if (dgMonthly.Rows[i].Cells["Total"].Value.ToString() != "0")
                        {
                            dgMonthly.Rows[i].Cells["Status"].Value = "Returned";
                        }
                        else if (dgMonthly.Rows[i].Cells["Total"].Value.ToString() == "0")
                        {
                            if (Convert.ToDateTime(dgMonthly.Rows[i].Cells["CUST_ADDED_DATE"].Value) < Convert.ToDateTime(01/01/2018))
                            {
                                dgMonthly.Rows[i].Cells["Status"].Value = "Lost";
                            }
                            else
                            {
                                dgMonthly.Rows[i].Cells["Status"].Value = "New";
                            }
                        }
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgMonthly);
            Utils.LogKayit("CustomerGroup Report", "Customer Group Report excel");
        }

        public DataTable IME_CustomerGroupReport(int monthly)
        {
            dgMonthly.DataSource = null;
            SqlConnection conn = new LogoSQL().LogoSqlConnect(server, logodatabase, sqluser, sqlpassword);
            SqlCommand cmd = new SqlCommand();
            SqlTransaction logoTransaction = null;
            DataTable dataTableResult = new DataTable();

            try
            {
                logoTransaction = conn.BeginTransaction();
                cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    Transaction = logoTransaction,
                    CommandText = @"[prc_IME_CustomerGroupReport]"
                };
                cmd.Parameters.AddWithValue("@year", monthly);

                SqlDataAdapter daMonthly = new SqlDataAdapter(cmd);
                daMonthly.Fill(dataTableResult);
                logoTransaction.Commit();
            }
            catch (Exception ex)
            {
                logoTransaction.Rollback();
                MessageBox.Show("Database Connection Error. \n\nError Message: " + ex.ToString(), "Error");
                return null;
            }
            finally
            {
                conn.Close();
            }
            return dataTableResult;
        }

        private void chkSalesOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalesOrders.Checked == true)
            {
                chkSalesInvoice.Checked = false;
            }
        }

        private void chkSalesInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalesInvoice.Checked == true)
            {
                chkSalesOrders.Checked = false;
            }
        }
    }
}