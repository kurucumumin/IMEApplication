using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LoginForm.DataSet;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationPrint : DevExpress.XtraEditors.XtraForm
    {
        public FormQuotationPrint()
        {
            InitializeComponent();
        }

        public void Print(Quotation qd, List<QuotationDetail> data, bool vat)
        {
            IMEEntities IME = new IMEEntities();
            ReportQuotation report = new ReportQuotation();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in report.Parameters)
            {
                p.Visible = false;
            }
            report.InitData(qd.QuotationNo, qd.Customer?.c_name, qd.MainContactName, qd.Customer?.telephone, qd.RFQNo, Int32.Parse(qd.ValidationDay?.ToString()), qd.StartDate, qd.Customer?.CustomerWorker?.cw_name, qd.Customer?.CustomerWorker?.phone, qd.PaymentTerm?.term_name, qd.FirstNote, qd.Currency?.currencySymbol, qd.Currency?.currencyName, qd.Customer.CustomerAddresses.Where(x=> x.CustomerID == qd.Customer.ID).FirstOrDefault().Pobox, qd.Customer.CustomerAddresses.Where(x => x.CustomerID == qd.Customer.ID).FirstOrDefault().City.City_name, qd.DiscOnSubTotal2.ToString(), qd.DiscOnSubTotal.ToString(), qd.GrossTotal.ToString(), qd.Currency?.subunitName, qd.SubTotal.ToString(), data, vat, Int32.Parse(qd.IsVatValue?.ToString()));
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
            //report.ExportToPdf("C:\\Users\\pomak\\Desktop\\ReportQuotation.pdf");
        }
    }
}