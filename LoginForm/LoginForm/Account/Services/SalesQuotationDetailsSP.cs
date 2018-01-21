using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class SalesQuotationDetailsSP
    {

        public DataTable SalesInvoiceGridfillAgainestQuotationUsingQuotationDetails(decimal decQuotationMasterId, decimal salesOrderMasterId, decimal voucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                //var adaptor = db.SalesInvoiceGridfillAgainestQuotationUsingQuotationDetails().ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }

    }
}
