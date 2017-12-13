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
using LoginForm.Services;

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
            for (int i = 0; i < CreateTxt().Count(); i++)
            {
                txtMail.Text = CreateTxt()[i] + " \r\n";
            }

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
            #region SAVE
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




            txtCreate.newTxt(CreateTxt());
            #region SendMail
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential("kurucumumin94@gmail.com", "6231962319+**");

            mail.From = new MailAddress("kurucumumin94@gmail.com", "Mümin Kurucu");
            mail.Subject = "TeamERP"; mail.IsBodyHtml = true; mail.Body = "IME programı test mail";
            Attachment attachment;
            attachment = new Attachment(@"C:\Users\pomak\Desktop\Yeni Metin Belgesi.txt");
            mail.Attachments.Add(attachment);
            int i = 0;

            for (i = 0; i < toList.Count; i++)
            {
                mail.To.Add(toList[i]);
            }
            MessageBox.Show(i + " E-Mails successfully sent.", "Success !");

            for (i = 0; i < ccList.Count; i++)
            {
                mail.CC.Add(ccList[i]);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            sc.Send(mail);
            MessageBox.Show(i + " E-Mails successfully sent.", "Success !");
            #endregion

        }

        private string[] CreateTxt()
        {
            List<string> TXTList = new List<string>();
            string Line1;
            string s = rowList[0].Cells[3].Value.ToString();

            string COO ="   ";//TO DO COUNTRYCODE
            string OrderDate = DateTime.Today.ToShortDateString();//TransmissionDate
            string OrderTime = DateTime.Today.ToShortTimeString();//TransmissionDate
            string filler1 ="";
            for (int i = 0; i < 130; i++)
            {
                filler1 = filler1 + " ";
            }
            //switch (sale.SaleOrderDetails.FirstOrDefault().DependantTable)
            //{
            //    case "sd":
            //        COO = IME.SuperDisks.Where(a => a.Article_No == articleNO).FirstOrDefault().CofO;
            //        break;
            //    case "sdP":
            //        COO = IME.SuperDiskPs.Where(a => a.Article_No == articleNO).FirstOrDefault().CofO;
            //        break;
            //    case "exd":
            //        COO = IME.ExtendedRanges.Where(a => a.ArticleNo == articleNO).FirstOrDefault().CountryofOrigin;
            //        break;
            //}
            Line1 = "FH" + COO + OrderDate + OrderTime + filler1;
            TXTList.Add(Line1);
            string Line2 = "";
            string AccountNumber = "";
            for (int i = 0; i < 10; i++)
            {
                AccountNumber += " ";
            }
            string ShiptoAccountNumber = "";
            for (int i = 0; i < 10; i++)
            {
                ShiptoAccountNumber += " ";
            }
            string OrderNature = " ";
            string PackType = " ";
            string OrderNumber = "     ";
            string CustomerDistOrderReference = "";
            for (int i = 0; i < 30; i++)
            {
                CustomerDistOrderReference += " ";
            }
            string MethodofDespatch = "   ";
            string AutomaticBackOrderAllowed = " ";
            string CustomerPONumber = "";
            for (int i = 0; i < 22; i++)
            {
                CustomerPONumber += " ";
            }
            string SupplyingCompany = "    ";
            string RequestDelDate = "";
            for (int i = 0; i < 8; i++)
            {
                RequestDelDate += " ";
            }
            filler1 = "";
            for (int i = 0; i < 53; i++)
            {
                filler1 += " ";
            }

            Line2 = "OH" + AccountNumber+ ShiptoAccountNumber+ OrderNature+ PackType+ OrderNumber+ CustomerDistOrderReference+ MethodofDespatch+
                AutomaticBackOrderAllowed+ CustomerPONumber+ SupplyingCompany+ RequestDelDate+filler1;
            TXTList.Add(Line2);
            string Line3 = "";
            string CustomerName = "";
            for (int i = 0; i < 35; i++)
            {
                CustomerName += " ";
            }
            string CustomerAddressLine1 = "";
            for (int i = 0; i < 35; i++)
            {
                CustomerAddressLine1 += " ";
            }
            filler1 = "";
            for (int i = 0; i < 78; i++)
            {
                filler1 += " ";
            }
            Line3 = "C1" + CustomerName + CustomerAddressLine1 + filler1;
            TXTList.Add(Line3);
            string Line4 = "";
            string CustomerName2 = "";
            for (int i = 0; i < 35; i++)
            {
                CustomerName2 += " ";
            }
            string CustomerAddressLine1_2 = "";
            for (int i = 0; i < 35; i++)
            {
                CustomerAddressLine1_2 += " ";
            }

            Line4 = "C2" + CustomerName2 + CustomerAddressLine1_2 + filler1;
            TXTList.Add(Line4);


            string line5 = "";
            string CustomerAddressLine4 = "";
            for (int i = 0; i < 35; i++)
            {
                CustomerAddressLine4 += " ";
            }
            string ForAttentionof = "";
            for (int i = 0; i < 30; i++)
            {
                ForAttentionof += " ";
            }
            string Postcode = "";
            for (int i = 0; i < 9; i++)
            {
                Postcode += " ";
            }
            string Countrycode = "  ";
            string ContacttelephoneNumber = "";
            for (int i = 0; i < 30; i++)
            {
                ContacttelephoneNumber += " ";
            }
            filler1 = "";
            for (int i = 0; i < 42; i++)
            {
                filler1 += " ";
            }
            line5 = "C3" + CustomerAddressLine4 + ForAttentionof+ Postcode+ Countrycode + ContacttelephoneNumber + filler1;
            TXTList.Add(line5);
            string Line6="";
            string DeliveryInstruction = "";
            for (int i = 0; i < 40; i++)
            {
                DeliveryInstruction += " ";
            }
            filler1 = "";
            for (int i = 0; i < 108; i++)
            {
                filler1 += " ";
            }
            TXTList.Add(Line6);
            int totalquantity = 0;
            foreach (var item in rowList)
            {
                string productNumber = item.Cells["ItemCode"].Value.ToString();
                int pn = Int32.Parse(productNumber);
                PurchaseOrderDetail po = IME.PurchaseOrderDetails.Where(a => a.ID == pn).FirstOrDefault();
                string itemLine = "";
                int orderqty = 0;
                if(po.SendQty!=null)orderqty=Int32.Parse(po.SendQty.ToString());
                string OrderQuantity = "";
                string zeronumber = "";
                for (int i = 0; i < 5- orderqty.ToString().Length; i++)
                {
                    zeronumber += " ";
                }
                if (orderqty != 0)
                {
                    OrderQuantity = zeronumber + orderqty.ToString();
                    totalquantity += orderqty;
                }

                string PackType1 = " ";
                string ProductDescription;
                ProductDescription = po.ItemDescription;
                for (int i = 0; i < 40 - ProductDescription.ToString().Length; i++)
                {
                    ProductDescription += " " + ProductDescription;
                }
                string LocalStoresLocation="";
                for (int i = 0; i < 20; i++)
                {
                    LocalStoresLocation += " ";
                }
                string LocalPrePickReference = "";
                for (int i = 0; i < 40; i++)
                {
                    LocalPrePickReference += " ";
                }
                string PurchaseOrderItemNumber = "";
                PurchaseOrderItemNumber = item.Index.ToString();
                string ItemRequestedDeliveryDate = "";
                for (int i = 0; i < 8; i++)
                {
                    ItemRequestedDeliveryDate += " ";
                }
                filler1 = "";
                for (int i = 0; i < 10; i++)
                {
                    filler1 += " ";
                }
                itemLine = "OL" + productNumber + OrderQuantity + PackType1 + ProductDescription + LocalStoresLocation + LocalPrePickReference + PurchaseOrderItemNumber + ItemRequestedDeliveryDate + filler1;
                TXTList.Add(itemLine);
            }
            string lineOT = "";
            string OrderQuantityControl = "";
            OrderQuantityControl = totalquantity.ToString();
            for (int i = 0; i < 10-totalquantity.ToString().Length; i++)
            {
                OrderQuantityControl += " ";
            }
            string OrderLineControl = "    ";
            filler1 = "";
            for (int i = 0; i < 134; i++)
            {
                filler1 += " ";
            }
            lineOT = "OT" + OrderQuantityControl + OrderLineControl + filler1;
            TXTList.Add(lineOT);
            string lineFT;
            OrderQuantityControl = OrderQuantityControl;//Bunun diğeri ile ne farkı var ???

            lineFT = "OT" + OrderQuantityControl + OrderLineControl + filler1;
            TXTList.Add(lineFT);
            return TXTList.ToArray();
        }
    }
}
