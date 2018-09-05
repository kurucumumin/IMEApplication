using ImeLogoLibrary;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.MyClasses
{
    public class LogoLibrary
    {
        private readonly string server = @"195.201.76.136";
        private readonly string imedatabase = "IME";
        private readonly string logodatabase = "TEST";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "ime1453..";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";


        public LogoLibrary() {

        }

        public string SendToLogo_SaleOrder(int SoNO)
        {
            ImeLogoSalesOrder order = new ImeLogoSalesOrder();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();

            return order.addSalesOrder(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), SoNO.ToString(), logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), Utils.FrmNo, Utils.DnmNo);
        }

        public string SendToLogo_RSInvoice(string RSInvoiceID)
        {
            ImeLogoPurchaseInvoice invoice = new ImeLogoPurchaseInvoice();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();

            return invoice.addPurchaseInvoice(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), RSInvoiceID, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), Utils.FrmNo, Utils.DnmNo);
        }

        public string BackFromLogo_SaleOrder(int SoNO)
        {
            ImeLogoSalesOrder order = new ImeLogoSalesOrder();
            ImeSQL imesql = new ImeSQL();
            LogoSQL logosql = new LogoSQL();
            
            return order.deleteSalesOrder(imesql.ImeSqlConnect(server, imedatabase, sqluser, sqlpassword), SoNO.ToString(), logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), Utils.FrmNo, Utils.DnmNo);
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
