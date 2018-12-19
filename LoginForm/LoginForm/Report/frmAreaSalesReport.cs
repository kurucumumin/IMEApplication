using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmAreaSalesReport : DevExpress.XtraEditors.XtraForm
    {
        LogoSQL logosql = new LogoSQL();
        private readonly string server = @"159.69.213.172";
        private readonly string logodatabase = "LOGO";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";

        DataTable currencyList = new DataTable();
        LogoLibrary logoLibrary = new LogoLibrary();
        public frmAreaSalesReport()
        {
            InitializeComponent();

            dgArea.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgArea, new object[] { true });
        }

        public DataTable Area_Sales(int monthly)
        {
            dgArea.DataSource = null;
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
                    CommandText = @"[prc_Area_Sales]"
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgArea);
            Utils.LogKayit("AreaSales Report", "Area Sales Report excel");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkSalesOrders.Checked==true)
            {
                currencyList = Area_Sales(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
                dgArea.DataSource = currencyList;
            }
            else
            {
                currencyList = IME_AreaSalesReport(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
                dgArea.DataSource = currencyList;
            }

            for (int i = 1; i < dgArea.ColumnCount; i++)
            {
                dgArea.Columns[i].DefaultCellStyle.Format = "N2";
            }
        }

        public DataTable IME_AreaSalesReport(int monthly)
        {
            dgArea.DataSource = null;
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
                    CommandText = @"[prc_IME_Area_Sales]"
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
            if (chkSalesOrders.Checked==true)
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

        private void frmAreaSalesReport_Load(object sender, EventArgs e)
        {

        }
    }
}
