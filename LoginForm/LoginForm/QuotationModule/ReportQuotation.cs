using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using LoginForm.DataSet;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraPrinting;
using System.Globalization;
using System.Text.RegularExpressions;
using LoginForm.Services;

namespace LoginForm
{
    public partial class ReportQuotation : DevExpress.XtraReports.UI.XtraReport
    {

        decimal sayi;
        string currency;
        string subnit;
        CultureInfo culture = new CultureInfo("en-US", true);
        IMEEntities IME = new IMEEntities();
        bool vat;
        int quoVat;
        public ReportQuotation()
        {
            InitializeComponent();
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public void InitData(string quotationNo,string customerName, string mainContact, string cTel, string rFQNo, int validaty, DateTime date, string represantative, string tel,string payment, string note, string currencySymbol, string currencyName, string pobox, string city, string disc, string disc2, string gross, string subnitName, string sub, List<QuotationDetail> data,bool vat,int quoVat)
        {
            DataTable table = ConvertToDataTable<QuotationDetail>(data);
            this.vat = vat;
            this.quoVat = quoVat;
            decimal grosstotal = 0;
            culture.NumberFormat.CurrencySymbol = currencySymbol;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            DevExpress.Utils.FormatInfo.AlwaysUseThreadFormat = true;

            pQutationNo.Value = quotationNo;
            pCustomerName.Value = customerName;
            pMainContact.Value = mainContact;
            pTelephone.Value = cTel;
            pRfqNo.Value = rFQNo;
            pValidity.Value = validaty;
            pDate.Value = date;
            pRepresantative.Value = represantative;
            pContactTel.Value = tel;
            pPayment.Value = payment;
            sub = Math.Round(Convert.ToDecimal(sub), 2).ToString();
            pSubTotal.Value = sub;
            if (pobox == null)
            {
                xrLabel6.Visible = false;
            }
            pPoBox.Value = pobox;
            pCity.Value = city;
            pDisc.Value = Math.Round(Convert.ToDecimal(disc), 2).ToString();
            pGross.Value = Math.Round(Convert.ToDecimal(gross), 2).ToString();

            if (currencyName == "Pound")
            {
                currency = currencyName;
                subnit = subnitName;
                currencyName = "Sterling " + currencyName;
                pCurrencyName.Value = currencyName;
            }
            else if (currencyName == "Dollar")
            {

                currency = currencyName;
                subnit = subnitName;
                currencyName = "US " + currencyName;
                pCurrencyName.Value = currencyName;
            }
            else
            {
                currency = currencyName;
                subnit = subnitName;
                pCurrencyName.Value = currencyName;
            }

            if (pNote.Value.ToString() == "")
            {
                xrLabel32.Visible = false;
            }

            foreach (QuotationDetail array in data)
            {
                if (array.UnitOfMeasure == "")
                {
                    if (array.UC == 1 && array.SSM == 1)
                    {
                        array.UnitOfMeasure = "EACH ";
                        array.TargetUP = array.Qty / (array.SSM * array.UC);
                        array.Qty = Convert.ToInt32(array.TargetUP);
                    }
                    else
                    {
                        array.UnitOfMeasure = "PACKET OF " + array.SSM * array.UC;
                        array.TargetUP = array.Qty / (array.SSM * array.UC);
                        array.Qty = Convert.ToInt32(array.TargetUP * array.SSM * array.UC);
                    }
                }
                else if (array.UnitOfMeasure == "REEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "MREEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC + " M";
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "GREEL")
                {
                    array.UnitOfMeasure = "REEL OF " + array.SSM * array.UC + " G";
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "KIT")
                {
                    array.UnitOfMeasure = "KIT OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "BAG")
                {
                    array.UnitOfMeasure = "BAG OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "MBAG")
                {
                    array.UnitOfMeasure = "BAG OF " +array.SSM * array.UC + " M";
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "BOX")
                {
                    array.UnitOfMeasure = "BOX OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "SET")
                {
                    array.UnitOfMeasure = "SET OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "PAIR")
                {
                    array.UnitOfMeasure = "PAIR OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "LOT")
                {
                    array.UnitOfMeasure = "LOT OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "XXX")
                {
                    array.UnitOfMeasure = "EACH";
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "M")
                {
                    array.UnitOfMeasure = "METER " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "TUBE")
                {
                    array.UnitOfMeasure = "TUBE OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                else if (array.UnitOfMeasure == "PACKET OF")
                {
                    array.UnitOfMeasure = "PACKET OF " + array.SSM * array.UC;
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP * array.SSM * array.UC);
                }
                else if (array.UnitOfMeasure == "EACH")
                {
                    array.UnitOfMeasure = "EACH ";
                    array.TargetUP = array.Qty / (array.SSM * array.UC);
                    array.Qty = Convert.ToInt32(array.TargetUP);
                }
                xrTableCell2.Text = Math.Round(Convert.ToDecimal(array.Quotation.SubTotal - array.Quotation.DiscOnSubTotal2), 2).ToString();
            }

            objectDataSource1.DataSource = data;

            xrTableCell11.Text = "Price Per UOM " + currencySymbol;
            xrTableCell14.Text = " Total                " + currencySymbol;
            xrTableCell1.Text = " Total " + currencySymbol;
            xrTableCell9.Text = " Sub Total " + currencySymbol;
            xrTableCell20.Text = " Net " + currencySymbol;
            xrTableCell30.DataBindings["Text"].FormatString = "{0: 0.00}";
            xrTableCell21.DataBindings["Text"].FormatString = "{0: 0.00}";
           
            if (vat == false)
            {
                xrTableCell3.Text = "";
                xrTableCell28.Text = "";
                xrLabel18.Visible = true;
            }
            else
            {
                xrTableCell3.Visible = true;
                xrTableCell28.Visible = true;
                xrLabel18.Visible = false;
            }

            if (gross != "")
            {
                grosstotal = Convert.ToDecimal(gross);
                gross = Math.Round(grosstotal, 1).ToString();
                xrTableCell21.Text = gross;
                xrTableCell10.Text = Math.Round((grosstotal - Convert.ToDecimal(disc2)),2).ToString();
                NumberConvertString();
            }

            if (disc2 != "" && disc2 != "0.00000")
            {
                xrTableCell29.Text = " Discount " + Math.Round(Convert.ToDecimal(disc2), 0).ToString() + " %";
            }

            xrLabel37.Text = Utils.getManagement().Note;
        }

        private void NumberConvertString()
        {
            sayi = decimal.Parse(xrTableCell21.Text);
            string sTutar = sayi.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] onlar = { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] binler = { "Quadrillion", "Trillion", "Billion", "Million", "Thousand", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
                                //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "Hundred "; //yüzler

                if (grupDegeri == "OneHundred") //biryüz düzeltiliyor.
                    grupDegeri = "Hundred ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "OneThousand") //birbin düzeltiliyor.
                    grupDegeri = "Thousand ";

                yazi += grupDegeri;
            }

            if (yazi != "")
                
                yazi = currency + "s only " + yazi + " ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi = yazi + ", and " + subnit + " " + onlar[Convert.ToInt32(kurus.Substring(0, 1))];
            else if (kurus.Substring(0, 1) == "0")
            {
                if (kurus.Substring(1, 1) != "0") //kuruş birler
                    yazi = yazi + ", and " + subnit + " " + birler[Convert.ToInt32(kurus.Substring(1, 1))];
            }
            else
            {
                if (kurus.Substring(1, 1) != "0") //kuruş birler
                    yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];
            }
           

            //if (yazi.Length > yaziUzunlugu)
            //    yazi = yazi + " ";
            //else
            //    yazi = yazi + " ";

            xrLabel53.Text = yazi + ".";
        }

        private void xrTableCell2_TextChanged(object sender, EventArgs e)
        {
            if (xrTableCell2.Text != "")
            {
                double sayi = Convert.ToDouble(xrTableCell2.Text);
                double sonuc = (sayi * 5) / 100;

                if (vat == true)
                {
                    if (quoVat == 1)
                    {
                        xrTableCell28.Text = Math.Round(Convert.ToDecimal(sonuc), 2).ToString();
                    }
                    else
                    {
                        xrTableCell28.Text = "0.00";
                    }
                }
                
            }
        }
    }
}
