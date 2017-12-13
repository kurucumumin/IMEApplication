using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Timers;
using System.Threading;

namespace LoginForm.PurchaseOrder
{
    public partial class PurchaseExportFiles : Form
    {
        IMEEntities IME = new IMEEntities();
        List<DataGridViewRow> rowList = new List<DataGridViewRow>();
        List<Mail> MailList = new List<Mail>();
        string fiche = "";
        SmtpClient sc = new SmtpClient();
        MailMessage mail = new MailMessage();
        List<string> ccList = new List<string>();
        List<string> toList = new List<string>();

        public PurchaseExportFiles()
        {
            InitializeComponent();
        }

        public PurchaseExportFiles(List<DataGridViewRow> List, string ficheNo)
        {
            InitializeComponent();
            rowList = List;
            fiche = ficheNo;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailForm form = new MailForm();
            form.ShowDialog();
        }

        private void ToFill()
        {
            IME = new IMEEntities();
            var adapter = (from m in IME.Mails.Where(m=> m.too!=null && m.too==true)
                           select new
                           {
                               m.FirstName,
                               m.MailAddress
                           }).ToList();
            dgMail.DataSource = adapter;
        }

        private void CCFill()
        {
            IME = new IMEEntities();
            var adapter = (from m in IME.Mails.Where(m => m.cc != null && m.cc == true)
                           select new
                           {
                               m.FirstName,
                               m.MailAddress
                           }).ToList();
            dgCc.DataSource = adapter;
        }

        private void PurchaseExportFiles_Load(object sender, EventArgs e)
        {
            IME = new IMEEntities();
            #region Filler
            ToFill();
            CCFill();
            txtDate.Text = DateTime.Now.ToString();
            for (int i = 0; i < dgCc.RowCount; i++)
            {
                ccList.Add(dgCc.Rows[i].Cells[1].Value.ToString());
            }

            for (int i = 0; i < dgMail.RowCount; i++)
            {
                toList.Add(dgCc.Rows[i].Cells[1].Value.ToString());
            }
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            NewPurchaseOrder f = new NewPurchaseOrder();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            #region Save
            DataSet.PurchaseOrder po = new DataSet.PurchaseOrder();
            string s = rowList[0].Cells[3].Value.ToString();

            po.FicheNo = fiche;
            po.CustomerID = IME.SaleOrders.Where(a => a.SaleOrderNo == s).FirstOrDefault().CustomerID;
            po.PurchaseOrderDate = DateTime.Today.Date;
            po.CameDate = IME.SaleOrders.Where(a => a.SaleOrderNo == s).FirstOrDefault().SaleDate;

            IME.PurchaseOrders.Add(po);
            IME.SaveChanges();

            po = IME.PurchaseOrders.Where(x => x.FicheNo == fiche).FirstOrDefault();

            List<PurchaseOrderDetail> podList = new List<PurchaseOrderDetail>();

            foreach (DataGridViewRow row in rowList)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();

                pod.QuotationNo = row.Cells[2].Value.ToString();
                pod.SaleOrderNo = row.Cells[3].Value.ToString();
                pod.ItemCode = row.Cells[4].Value.ToString();
                pod.ItemDescription = row.Cells[5].Value.ToString();
                pod.Unit = row.Cells[6].Value.ToString();
                pod.SendQty = (int)row.Cells[7].Value;
                pod.Hazardous = (bool)row.Cells[8].Value;
                pod.Calibration = (bool)row.Cells[9].Value;
                pod.SaleOrderNature = row.Cells[10].Value.ToString();
                pod.FicheNo = po.FicheNo;

                podList.Add(pod);
            }

            IME.PurchaseOrderDetails.AddRange(podList);
            IME.SaveChanges();

            MessageBox.Show("PuchaseOrders is successfully added", "Success");
            #endregion

            #region SendMail

            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
           
            sc.Credentials = new NetworkCredential("kurucumumin94@gmail.com", "6231962319+**");

            mail.From = new MailAddress("kurucumumin94@gmail.com", "Mümin Kurucu");

            int sayac = 0;

            for (int i = 0; i < toList.Count; i++)
            {
                mail.To.Add(toList[i]);
                sayac = sayac + 1;
                Wait(sayac);
            }
            //sayac = 0;
            for (int i = 0; i < ccList.Count; i++)
            {
                mail.CC.Add(ccList[i]);
                sayac = sayac + 1;
                Wait(sayac);
            }
            #endregion
        }

        private void Wait(int sayac)
        {
            if (sayac % 5 == 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                mail.Subject = "TeamERP"; mail.IsBodyHtml = true; mail.Body = "IME programı test mail";
                Attachment attachment;
                attachment = new Attachment(@"C:\Users\pomak\Desktop\Yeni Metin Belgesi.txt");
                mail.Attachments.Add(attachment);
                sc.Send(mail);
                MessageBox.Show(sayac + " E-Mails successfully sent.", "Success !");
            }
        }
    }
}
