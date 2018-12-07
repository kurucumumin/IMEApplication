using ImeLogoLibrary;
using LoginForm.Services;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LoginForm.MyClasses
{
    public class LogoLibrary
    {
        private readonly string server = @"159.69.213.172";
        private readonly string imedatabase = "IME";
        private readonly string logodatabase = "LOGO";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";


        public LogoLibrary() {

        }

        public string SendToLogo_SaleOrder(int SoNO)
        {
            ImeLogoSalesOrder order = new ImeLogoSalesOrder();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();
            string dnmNo = Utils.dbDnmNo();
            string frmNo = Utils.dbFrmNo();
            return order.addSalesOrder(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), SoNO.ToString(), logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), frmNo, dnmNo);
        }

        public DataTable getCurrency(string hata, SqlConnection LogoSQL)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CURNAME", typeof(string));
            dt.Columns.Add("RATES1", typeof(double));
            dt.Columns.Add("RATES2", typeof(double));
            dt.Columns.Add("RATES3", typeof(double));
            dt.Columns.Add("RATES4", typeof(double));
            dt.Columns.Add("EDATE", typeof(DateTime));

            hata = "";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = LogoSQL;
                cmd.CommandText = @"SELECT DISTINCT c.CURNAME,d.RATES1,d.RATES2,d.RATES3,d.RATES4,d.EDATE
  FROM L_DAILYEXCHANGES as d, L_CURRENCYLIST c where d.CRTYPE=c.CURTYPE and d.RATES1 is not null and d.RATES1 <> '1E-06'  and d.RATES4 <> '0' and d.EDATE = CAST(GETDATE() as date)";

                SqlDataReader drCurr = cmd.ExecuteReader();

                while (drCurr.Read())

                {
                    DataRow dr = dt.NewRow();

                    dr["CURNAME"] = drCurr.GetString(0);
                    dr["RATES1"] = drCurr.GetDouble(1);
                    dr["RATES2"] = drCurr.GetDouble(2);
                    dr["RATES3"] = drCurr.GetDouble(3);
                    dr["RATES4"] = drCurr.GetDouble(4);
                    dr["EDATE"] = drCurr.GetDateTime(5);

                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex) { hata = ex.ToString(); }
            finally {   LogoSQL.Close();}

            return dt;
        }

        public string SendToLogo_RSInvoice(string RSInvoiceID)
        {
            ImeLogoPurchaseInvoice invoice = new ImeLogoPurchaseInvoice();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();
            string dnmNo = Utils.dbDnmNo();
            string frmNo = Utils.dbFrmNo();
            return invoice.addPurchaseInvoice(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), RSInvoiceID, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), frmNo, dnmNo);
        }

        public string BackFromLogo_SaleOrder(int SoNO)
        {
            ImeLogoSalesOrder order = new ImeLogoSalesOrder();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();
            string dnmNo = Utils.dbDnmNo();
            string frmNo = Utils.dbFrmNo();
            return order.deleteSalesOrder(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), SoNO.ToString(), logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), frmNo, dnmNo);
        }

        public string BackFromLogo_RSInvoice(string RSInvoiceID)
        {
            ImeLogoPurchaseInvoice invoice = new ImeLogoPurchaseInvoice();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();
            return invoice.deletePurchaseInvoice(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), RSInvoiceID, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), "001", "01");
        }
    }
}
