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
    public partial class PurchaseExportFiles : MyForm
    {
        IMEEntities IME = new IMEEntities();
        List<DataGridViewRow> rowList = new List<DataGridViewRow>();
        List<Mail> MailList = new List<Mail>();
        int puchaseId;
        int purchaseNo;
        SmtpClient sc = new SmtpClient();
        MailMessage mail = new MailMessage();
        List<string> ccList = new List<string>();
        List<string> toList = new List<string>();
        string AccountNumber;
        string filename;
        public PurchaseExportFiles()
        {
            InitializeComponent();
            dgMail.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgCc.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        }

        public PurchaseExportFiles(List<DataGridViewRow> List, int purchase_Id, int purchase_No)
        {
            InitializeComponent();
            dgMail.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgCc.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            rowList = List;
            puchaseId = purchase_Id;
            purchaseNo = purchase_No;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailForm form = new MailForm();
            form.ShowDialog();
            this.Show();
            ToFill(); CCFill();
            RefreshMailList();
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

            dgMail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            dgCc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void PurchaseExportFiles_Load(object sender, EventArgs e)
        {
            IME = new IMEEntities();
            #region Filler
            ToFill();
            CCFill();
            txtDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString();
            RefreshMailList();
            #endregion
            var txt = CreateTxt();
            for (int i = 0; i < txt.Count(); i++)
            {
                txtMail.Text = txtMail.Text + txt[i] + "\r\n";
            }

            filename = txtCreate.newTxt(txt, AccountNumber);
            groupBox2.Text = filename;
            lblPicture.Text = filename;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain f = new PurchaseOrderMain();
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
            decimal s = (decimal)rowList[0].Cells["SaleID"].Value;

            SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderID == s).FirstOrDefault();

            po.purchaseOrderId = puchaseId;
            po.CustomerID = IME.SaleOrders.Where(a => a.SaleOrderID == s).FirstOrDefault().CustomerID;
            po.PurchaseOrderDate = DateTime.Today.Date;
            po.CameDate = IME.SaleOrders.Where(a => a.SaleOrderID == s).FirstOrDefault().SaleDate;
            po.FicheNo = filename;
            po.PurchaseNo = purchaseNo;

            IME.PurchaseOrders.Add(po);
            IME.SaveChanges();

            so.PurchaseOrderID = po.purchaseOrderId;
            IME.SaveChanges();


            po = IME.PurchaseOrders.Where(x => x.purchaseOrderId == po.purchaseOrderId).FirstOrDefault();

            List<PurchaseOrderDetail> podList = new List<PurchaseOrderDetail>();

            foreach (DataGridViewRow row in rowList)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();

                //pod.QuotationNo = row.Cells[2].Value.ToString();
                pod.SaleOrderID = Convert.ToDecimal(row.Cells[15].Value);
                pod.ItemCode = row.Cells[4].Value.ToString();
                pod.ItemDescription = row.Cells[5].Value.ToString();
                //if (row.Cells[5].Value.ToString() == null || row.Cells[5].Value.ToString() =="") pod.ItemDescription = null;
                //else pod.ItemDescription = row.Cells[5].Value.ToString();
                pod.UnitPrice = (decimal)row.Cells[6].Value;
                pod.SendQty = (int)row.Cells[7].Value;
                pod.Hazardous = (bool)row.Cells[8].Value;
                pod.Calibration = (bool)row.Cells[9].Value;
                pod.SaleOrderNature = row.Cells[10].Value.ToString();
                if ((row.Cells[11].Value.ToString() == "IME GENERAL COMPONENTS") && (row.Cells[12].Value.ToString() == "IME GENERAL COMPONENTS"))
                {
                    pod.AccountNumber = 8828170;
                }
                if ((row.Cells[11].Value.ToString() == "3RD PARTY") && (row.Cells[12].Value.ToString() == "3RD PARTY"))
                {
                    pod.AccountNumber = 8894479;
                }
                
                pod.purchaseOrderId = po.purchaseOrderId;
                //pod.purchaseOrderId = puchaseId;
                pod.Unit = row.Cells[13].Value.ToString();
                podList.Add(pod);
            }

            IME.PurchaseOrderDetails.AddRange(podList);
            IME.SaveChanges();

            MessageBox.Show("PuchaseOrders is successfully added", "Success");
            #endregion

            #region SendMail
            sc.Port = Convert.ToInt32(txtPort.Text);
            sc.Host = txtHost.Text;
            sc.EnableSsl = true;

            sc.Credentials = new NetworkCredential(txtEmail.Text, txtPass.Text);

            mail.From = new MailAddress(txtEmail.Text, "");
            mail.Subject = "ORDER"; mail.IsBodyHtml = true; mail.Body = "";
            Attachment attachment;
            //attachment = new Attachment(@"C:\Users\pomak\Desktop\Order.txt");
            //attachment = new Attachment(@"C:\Users\pomak\Desktop\"+ filename+".txt");
            attachment = new Attachment(@"C:\RsFiles\" + filename + ".txt");
            mail.Attachments.Add(attachment);
            int i = 0;
            toList.Clear();
            ccList.Clear();
            RefreshMailList();
            for (i = 0; i < toList.Count; i++)
            {
                mail.To.Add(toList[i]);
            }
            MessageBox.Show("Please wait a moment ", "Wait !");

            for (i = 0; i < ccList.Count; i++)
            {
                mail.CC.Add(ccList[i]);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
            sc.Send(mail);

            string messageText = String.Empty;

            foreach (string item in toList)
            {
                messageText += item + "\n";
            }

            messageText += "CC E-Mails successfully sent." + "\n\n";

            foreach (string item in ccList)
            {
                messageText += item + "\n";
            }

            messageText += "To E-Mails successfully sent.";

            MessageBox.Show(messageText, "Success !");
            #endregion

            PurchaseOrderMain f = new PurchaseOrderMain();
            f.Show();
            this.Close();

        }

        private string[] CreateTxt()
        {
            List<string> TXTList = new List<string>();
            string Line1;
            //TODO ! 's' hiçbiryerde kullanılmadığı için yorumlandı
            //string s = rowList[0].Cells["SaleID"].Value.ToString();
            string orderN= rowList[0].Cells[10].Value.ToString();
            string billTo = rowList[0].Cells[11].Value.ToString();
            string COO ="   ";//TO DO COUNTRYCODE
            string OrderDate = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd.MM.yyyy");//TransmissionDate
            string OrderTime = Convert.ToDateTime(IME.CurrentDate().First()).ToString("HH.mm");//TransmissionDate
            string filler1 ="";
            for (int i = 0; i < 130; i++)
            {
                filler1 = filler1 + " ";
            }
            
            Line1 = "FH" + COO + OrderDate + OrderTime + filler1;
            TXTList.Add(Line1);
            string Line2 = "";

            AccountNumber = "0008828170";//accounting numarası
            int AccountNumberlength = AccountNumber.Length;
            for (int i = 0; i < 10 - AccountNumberlength; i++)

            {
                AccountNumber += " ";
            }
            //string saleOrderN = rowList.FirstOrDefault().Cells["SaleOrderNo"].Value.ToString();
            decimal saleID = (decimal)rowList.FirstOrDefault().Cells["SaleID"].Value;

            string OrderNature = "";
            if (orderN == "XDOC")
            {
                OrderNature = "E";
            }
            else { OrderNature = "D"; }
            string PackType = " ";
            string OrderNumber = "     ";
            string CustomerDistOrderReference = Convert.ToString(purchaseNo)+"RS";
            CustomerDistOrderReference = CustomerDistOrderReference.ToUpper()+"/BAH/"+Convert.ToDateTime(IME.CurrentDate().First()).ToString("MMM").ToUpper() +"/"+Convert.ToDateTime(IME.CurrentDate().First()).ToString("yy");
            int CustomerDistOrderReferencelength = CustomerDistOrderReference.Length;
            for (int i = 0; i < 30- CustomerDistOrderReferencelength; i++)

            {
                CustomerDistOrderReference += " ";
            }
            string MethodofDespatch = "";
            switch (IME.SaleOrders.Where(a => a.SaleOrderID == saleID).FirstOrDefault().ShippingType)
            {
                case "Air Freight":
                    MethodofDespatch = "AFT";
                    break;
                case "Sea Freight":
                    MethodofDespatch = "SFT";
                    break;
                case "Truck":
                    MethodofDespatch = "TRA";
                    break;
                case "Express":
                    MethodofDespatch = "EXP";
                    break;
            }


            string AutomaticBackOrderAllowed = " ";
            string CustomerPONumber = "";
            for (int i = 0; i < 22; i++)
            {
                CustomerPONumber += " ";
            }
            string SupplyingCompany = "GB01";
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

            Line2 = "OH" + AccountNumber+ AccountNumber + OrderNature+ PackType+ OrderNumber+ CustomerDistOrderReference+ MethodofDespatch+
                AutomaticBackOrderAllowed+ CustomerPONumber+ SupplyingCompany+ RequestDelDate+filler1;
            TXTList.Add(Line2);
            if (OrderNature=="D")
            {
                string Line3 = "";
                string CustomerName = "INSTALLATIONS MIDDLE EAST";
                int CustomerNamelength = CustomerName.Length;
                for (int i = 0; i < 35 - CustomerNamelength; i++)
                {
                    CustomerName = CustomerName + " ";
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
                string adress = "SHEIKH MAJID BUILDING, SHOP No.4, SHEIKH ZAYED ROAD, AL QUOS AREA";
                string Line4 = "";
                filler1 = "";
                int adresslenght = adress.Length;
                for (int i = 0; i < 148 - adresslenght; i++)
                {
                    filler1 = filler1 + " ";
                }
                Line4 = "C2" + adress + filler1;
                TXTList.Add(Line4);


                string line5 = "";
                string CustomerAddressLine4 = "DUBAI";
                for (int i = 0; i < 30; i++)
                {
                    CustomerAddressLine4 += " ";
                }
                string saleOrderNo = rowList.FirstOrDefault().Cells["SaleOrderNo"].Value.ToString();
                string ForAttentionof = saleOrderNo;//saleordernumber
                int forattentionoflenght = ForAttentionof.Length;
                for (int i = 0; i < 30 - forattentionoflenght; i++)
                {
                    ForAttentionof += " ";
                }
                string Postcode = "5253";
                for (int i = 0; i < 5; i++)
                {
                    Postcode = Postcode + " ";
                }
                string Countrycode = "AE";
                string ContacttelephoneNumber = "3433444";
                for (int i = 0; i < 23; i++)
                {
                    ContacttelephoneNumber += " ";
                }
                filler1 = "";
                for (int i = 0; i < 42; i++)
                {
                    filler1 += " ";
                }
                line5 = "C3" + CustomerAddressLine4 + ForAttentionof + Postcode + Countrycode + ContacttelephoneNumber + filler1;
                TXTList.Add(line5);
                string Line6 = "";
                string DeliveryInstruction = "0";
                for (int i = 0; i < 39; i++)
                {
                    DeliveryInstruction += " ";
                }
                filler1 = "";
                for (int i = 0; i < 108; i++)
                {
                    filler1 += " ";
                }
                Line6 = "C4" + DeliveryInstruction + filler1;
                TXTList.Add(Line6);

            }
            int totalquantity = 0;
            int totalitemLine = 0;
            foreach (var item in rowList)
            {
                string productNumber = item.Cells["ItemCode"].Value.ToString();
                //string saleOrderNumber = item.Cells["SaleOrderNo"].Value.ToString();
                //TODO Grid'e SaleOrderID eklenecek
                decimal saleOrderID = Convert.ToDecimal(item.Cells["SaleID"].Value.ToString());
                SaleOrderDetail po = IME.SaleOrderDetails.Where(b=>b.SaleOrderID== saleOrderID).Where(a => a.ItemCode == productNumber).FirstOrDefault();
                //if (productNumber.Length == 6) productNumber = "0" + productNumber;
                int productnumberlenght = productNumber.Length;
                for (int i = 0; i < 18- productnumberlenght; i++)
                {
                    productNumber += " ";
                }
                string itemLine = "";
                int orderqty = 0;
                if(po!=null)orderqty=Int32.Parse(po.Quantity.ToString());

                
                if (po.UnitContent > 1) orderqty = (orderqty / (int)po.UnitContent);
                string OrderQuantity = orderqty.ToString();
                totalquantity += orderqty;
                int orderqtylenght = orderqty.ToString().Length;
                for (int i = 0; i < 5- orderqtylenght; i++)
                {
                    OrderQuantity = "0" + OrderQuantity;
                }

                string PackType1 = "S";
                string ProductDescription="";
                if (po.ItemDescription != null) ProductDescription = "";//item desc boş gönderiliyor
                int ProductDescriptionlenght = ProductDescription.ToString().Length;
                for (int i = 0; i < 40 - ProductDescriptionlenght; i++)

                {
                    ProductDescription = " " + ProductDescription;
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
                totalitemLine++;
                PurchaseOrderItemNumber = totalitemLine.ToString();
                int totalitemLinelen = totalitemLine.ToString().Length;
                for (int i = 0; i < 6- totalitemLinelen; i++)
                {
                    PurchaseOrderItemNumber = "0" + PurchaseOrderItemNumber;
                }
                string ItemRequestedDeliveryDate = "";//boş bırakılacak
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
            int totalquantitylenght = totalquantity.ToString().Length;
            for (int i = 0; i < 10- totalquantitylenght; i++)
            {
                OrderQuantityControl = "0"+ OrderQuantityControl;
            }
            string OrderLineControl = totalitemLine.ToString();
            int totalitemLinelenght = totalitemLine.ToString().Length;
            for (int i = 0; i < 4 - totalitemLinelenght; i++)
            {
                OrderLineControl = "0" + OrderLineControl;
            }
            filler1 = "";
            for (int i = 0; i < 134; i++)
            {
                filler1 += " ";
            }
            lineOT = "OT" + OrderQuantityControl + OrderLineControl + filler1;
            TXTList.Add(lineOT);
            string lineFT;

            lineFT = "FT" + OrderQuantityControl + OrderLineControl + filler1;
            TXTList.Add(lineFT);
            return TXTList.ToArray();
        }

        private void RefreshMailList()
        {
            for (int i = 0; i < dgCc.RowCount; i++)
            {
                ccList.Add(dgCc.Rows[i].Cells[1].Value.ToString());
            }

            for (int i = 0; i < dgMail.RowCount; i++)
            {
                toList.Add(dgMail.Rows[i].Cells[1].Value.ToString());
            }
        }
    }
}
