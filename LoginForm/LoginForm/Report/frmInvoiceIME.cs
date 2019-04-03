using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;
using ImeLogoLibrary;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class frmInvoiceIME : Form
    {
        IMEEntities IME = new IMEEntities();
        string txtSelected = "";
        LogoSQL logosql = new LogoSQL();
        string server = @"ime.resetbulut.com,47500";
        string logodatabase = "LOGO";
        string sqluser = "sa";
        string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";

        string hata = "Error";
        DataTable currencyList = new DataTable();

        public frmInvoiceIME()
        {
            InitializeComponent();

            dgInvoice.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgInvoice, new object[] { true });
        }

        public DataTable getInvoice(string hata, SqlConnection LogoSQL)
        {
            string so = "";

            DataTable dt = new DataTable();

            dt.Columns.Add("IME Invoice No", typeof(int));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Customer Name", typeof(string));
            dt.Columns.Add("Invoice Total", typeof(double));
            dt.Columns.Add("Currency", typeof(string));
            dt.Columns.Add("Sales Order No", typeof(string));
            dt.Columns.Add("Sales Date", typeof(DateTime));
            dt.Columns.Add("Quotation No", typeof(string));
            dt.Columns.Add("Quotation Date", typeof(DateTime));



            hata = "";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = LogoSQL;
                cmd.CommandText = @"SELECT DISTINCT s.INVOICEREF, s.DATE_, s.TOTAL, o.DOCODE, o.DATE_
                                    FROM LG_002_01_STLINE s
                                    LEFT OUTER JOIN LG_002_01_ORFICHE o ON s.ORDFICHEREF = o.LOGICALREF
                                    where s.TRCODE=8 and o.DOCODE IS NOT NULL and s.TOTAL <>0";

                SqlDataReader drCurr = cmd.ExecuteReader();

                while (drCurr.Read())

                {
                    DataRow dr = dt.NewRow();
                    so = "";
                    dr["IME Invoice No"] = drCurr.GetInt32(0);
                    dr["Date"] = drCurr.GetDateTime(1);
                    dr["Sales Order No"] = drCurr.GetString(3);
                    dr["Sales Date"] = drCurr.GetDateTime(4);
                    so = dr["Sales Order No"].ToString();
                    dr["Customer Name"] = IME.SaleOrderDetails.Where(x => x.SaleOrderID.ToString() == so).FirstOrDefault().SaleOrder.Customer.c_name;
                    dr["Invoice Total"] = drCurr.GetDouble(2);
                    dr["Currency"] = IME.SaleOrderDetails.Where(x => x.SaleOrderID.ToString() == so).FirstOrDefault().SaleOrder.CurrName;
                    dr["Quotation No"] = IME.SaleOrderDetails.Where(x => x.SaleOrderID.ToString() == so).FirstOrDefault().SaleOrder.QuotationNos;
                    dr["Quotation Date"] = IME.Quotations.Where(x => x.SaleOrderID.ToString() == so).FirstOrDefault().StartDate;

                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex) { hata = ex.ToString(); }
            finally { LogoSQL.Close(); }

            return dt;
        }

        private void frmInvoiceIME_Load(object sender, EventArgs e)
        {
            currencyList = getInvoice(hata, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword));
            dgInvoice.DataSource = currencyList;

            if (dgInvoice.RowCount > 0)
            {
                for (int i = 0; i < dgInvoice.ColumnCount; i++)
                {
                    dgInvoice.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgInvoice.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgInvoice.Columns[8].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgInvoice.Columns[2].DefaultCellStyle.Format = "N2";
                }
            }
        }
    }
}
