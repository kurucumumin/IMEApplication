using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmCustomerGroup : DevExpress.XtraEditors.XtraForm
    {
        DataTable currencyList = new DataTable();

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
            currencyList = Monthly_Sales(Convert.ToInt32(cmbYear.GetItemText(cmbYear.SelectedItem)));
            dgMonthly.DataSource = currencyList;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgMonthly);
            Utils.LogKayit("CustomerGroup Report", "Customer Group Report excel");
        }
    }
}