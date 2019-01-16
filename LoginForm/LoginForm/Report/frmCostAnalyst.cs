using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm
{
    public partial class frmCostAnalyst : Form
    {
        DataTable ListCost = new DataTable();
        string Document = "";

        public frmCostAnalyst(string DocumentReference)
        {
            InitializeComponent();

            dgCost.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgCost, new object[] { true });

            Document = DocumentReference;
        }

      
        public DataTable CostReport(string monthly)
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
                    CommandText = @"[prc_GetRSInvoiceCostAnaliz]"
                };
                cmd.Parameters.AddWithValue("@BillingDocumentReference", monthly);

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

        private void frmCostAnalyst_Load(object sender, EventArgs e)
        {
            ListCost = CostReport(Document);
            dgCost.DataSource = ListCost;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //frmInvoiceIME frm = new frmInvoiceIME();
            //frm.ShowDialog();
            this.Close();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgCost);
            Utils.LogKayit("CostAnalyst", "Cost Analyst excel");
        }
    }
}
