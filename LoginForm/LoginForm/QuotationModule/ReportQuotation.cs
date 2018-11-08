using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LoginForm.DataSet;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class ReportQuotation : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportQuotation()
        {
            InitializeComponent();
        }

        public void InitData(string quotationNo,string customerName, string mainContact, string cTel, string cEmail, string fax, string rFQNo, string paymentdate, DateTime date, string represantative, string mail, string tel,string paymentMethod, /*string totalWeight,*/ List<QuotationDetail> data)
        {
            pQutationNo.Value = quotationNo;
            pCustomerName.Value = customerName;
            pMainContact.Value = mainContact;
            pTelephone.Value = cTel;
            pCustomerEmail.Value = cEmail;
            pFax.Value = fax;
            pRfqNo.Value = rFQNo;
            pPayment.Value = paymentdate;
            pDate.Value = date;
            pRepresantative.Value = represantative;
            pContactMail.Value = mail;
            pContactTel.Value = tel;
            pPaymentMethod.Value = paymentMethod;
            //pTotalWeight.Value = totalWeight;
            objectDataSource1.DataSource = data;
           
        }

        private void xrTable3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrTableCell2_TextChanged(object sender, EventArgs e)
        {
            if (xrTableCell2.Text != "")
            {
                double sayi = Convert.ToDouble(xrTableCell2.Text);
                double sonuc = (sayi * 5) / 100;
                xrTableCell28.Text = sonuc.ToString();
            }
        }
    }
}
