using LoginForm.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmAreaSalesReport : DevExpress.XtraEditors.XtraForm
    {
        DataTable currencyList = new DataTable();
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
            currencyList = Area_Sales(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
            dgArea.DataSource = currencyList;
        }
    }
}
