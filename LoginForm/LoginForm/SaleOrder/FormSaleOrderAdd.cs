using LoginForm.DataSet;
using LoginForm.Model;
using LoginForm.nmSaleOrder;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.nsSaleOrder
{
    public partial class FormSaleOrderAdd : Form
    {
        decimal subtotal = 0;
        decimal totalMargin = 0;
        decimal customerFactor = (decimal)5.5;
        decimal currency;


        List<SaleItem> addedItemList = new List<SaleItem>();
        List<SaleItem> removedItemList = new List<SaleItem>();
        
        List<SlidingPrice> priceList = new List<SlidingPrice>();
        List<OnSale> onSaleList = new List<OnSale>();
        List<Hazardou> hazardousList = new List<Hazardou>(); 
        CustomerAddress invoiceAddress = new CustomerAddress();

        Customer customer;
        IMEEntities IME = new IMEEntities();

        public FormSaleOrderAdd()
        {
            InitializeComponent();
        }

        public FormSaleOrderAdd(Customer customer,List<QuotationDetail> list)
        {
            InitializeComponent();
            txtInvoiceAddress.ReadOnly = (customer.CustomerAddresses.Where(a => a.AddressType == "Invoice Address").FirstOrDefault() != null) ? true : false;
            this.customer = customer;
            dtpDate.Value = DateTime.Today;
            dtpRequestedDelvDate.MinDate = dtpDate.Value;
            dtpRequestedDelvDate.Value = dtpDate.Value;
            //BringPriceList(list);
            ConvertToSaleItem(list, addedItemList, removedItemList);
            SortTheList(addedItemList);
            SortTheList(removedItemList);
            populateComboBoxes();
            FillCustomer();
        }

        private void BringPriceList(List<QuotationDetail> list)
        {
            foreach (QuotationDetail item in list)
            {
                SlidingPrice sp = IME.SlidingPrices.Where(x => x.ArticleNo == item.ItemCode).FirstOrDefault();
                if (sp != null)
                {
                    priceList.Add(sp);
                }
            }
        }

        private void FormSaleOrderAdd_Load(object sender, EventArgs e)
        {
            PopulateList(addedItemList, dgSaleItems);
            PopulateList(removedItemList, dgSalesDeleted);
            CalculateSubtotal();
            CalculateTotalMargin();
            //currency = GetCurrency(dtpDate.Value);
        }

        private decimal GetCurrency(DateTime value)
        {
            decimal curr = 0;
            Rate rate = cbCurrency.SelectedItem as Rate;
            // TODO 100 comment i aç
            //switch (cbCurrType.SelectedItem)
            //{
            //    case "Buy":
            //        curr = (decimal)rate.RateBuy;
            //        break;
            //    case "Eff. Buy":
            //        curr = (decimal)rate.RateBuyEffective;
            //        break;
            //    case "Sell":
            //        curr = (decimal)rate.RateSell;
            //        break;
            //    case "Eff. Sell":
            //        curr = (decimal)rate.RateSellEffective;
            //        break;
            //}
            return curr;            
        }

        private void SortTheList(List<SaleItem> list)
        {
            int i = 1;
            foreach (SaleItem item in list)
            {
                item.NO = i;
                i++;
            }
        }

        private void PopulateList(List<SaleItem> list, DataGridView grid)
        {
            foreach (SaleItem item in list)
            {
                int newRowIndex = grid.Rows.Add();
                SaleItemToRow(item, grid.Rows[newRowIndex]);
            }
        }

        private void ConvertToSaleItem(List<QuotationDetail> list, List<SaleItem> itemList, List<SaleItem> deletedList)
        {
            IMEEntities IME = new IMEEntities();

            List<SaleItem> saleItemList = new List<SaleItem>();

            foreach (QuotationDetail q in list)
            {
                SaleItem s = new SaleItem();
                s.ItemCode = q.ItemCode;
                s.Competitor = q.Competitor;
                s.CustItemDescription = q.CustomerDescription;
                s.CustItemStockCode = q.CustomerStockCode; s.NO = (int)q.dgNo;
                s.Discount = (q.Disc != null) ? (decimal)q.Disc : 0;
                s.isDeleted = (q.IsDeleted == 1) ? 1 : 0;
                s.Qty = (int)q.Qty;
                s.UC_UP = (decimal)q.UPIME;
                bool isItemCost = (q.Quotation.IsItemCost == 1) ? true : false;
                bool isWeightCost = (q.Quotation.IsWeightCost == 1) ? true : false;
                bool isCustomsDuties = (q.Quotation.IsCustomsDuties == 1) ? true : false;
                s.LandingCost = classQuotationAdd.GetLandingCost(s.ItemCode, isItemCost, isWeightCost, isCustomsDuties);
                s.Margin = CalculateMargin(s.LandingCost, s.UC_UP);
                s.LM = (s.Margin < Utils.getCurrentUser().MinMarge) ? true : false;
                if (q.TargetUP != null) { s.TargetUP = (decimal)q.TargetUP; }
                s.Total = (decimal)q.Total;
                s.UPIMELP = (decimal)q.UCUPCurr;
                s.UOM = q.UnitOfMeasure;
                s.dependentTable = q.DependantTable;

                // TODO !Important dependantTable verisi eklenmeli

                switch (q.DependantTable)
                {
                    case "sd":
                        SuperDisk itemSD = IME.SuperDisks.Where(sd => sd.Article_No == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemSD.Standard_Weight / 1000;

                        OnSale itemSDOS = IME.OnSales.Where(os => os.ArticleNumber == q.ItemCode).FirstOrDefault();
                        if(itemSDOS != null)
                        {
                            s.OnHandStockBalance = (int)itemSDOS.OnhandStockBalance;
                            s.QuantityOnOrder = (int)itemSDOS.QuantityonOrder;
                        }

                        SlidingPrice itemSDPrice = IME.SlidingPrices.Where(sp => sp.ArticleNo == q.ItemCode).FirstOrDefault();
                        s.SuperSection = itemSDPrice.SupersectionName;
                        s.Section = itemSDPrice.SectionName;
                        s.MHLevel1 = itemSD.MH_Code_Level_1;

                        s.Col1Break = (int)itemSDPrice.Col1Break;
                        s.Col2Break = (int)itemSDPrice.Col2Break;
                        s.Col3Break = (int)itemSDPrice.Col3Break;
                        s.Col4Break = (int)itemSDPrice.Col4Break;
                        s.Col5Break = (int)itemSDPrice.Col5Break;
                        s.UK1Price = (int)itemSDPrice.Col1Price;
                        s.UK2Price = (int)itemSDPrice.Col2Price;
                        s.UK3Price = (int)itemSDPrice.Col3Price;
                        s.UK4Price = (int)itemSDPrice.Col4Price;
                        s.UK5Price = (int)itemSDPrice.Col5Price;
                        s.Cost1 = (decimal)itemSDPrice.DiscountedPrice1;
                        s.Cost2 = (decimal)itemSDPrice.DiscountedPrice2;
                        s.Cost3 = (decimal)itemSDPrice.DiscountedPrice3;
                        s.Cost4 = (decimal)itemSDPrice.DiscountedPrice4;
                        s.Cost5 = (decimal)itemSDPrice.DiscountedPrice5;

                        s.CL = (itemSD.Calibration_Ind == "Y") ? true : false;
                        s.Description = itemSD.Article_Desc;
                        s.LC = (itemSD.Licensed_Ind == "Y") ? true : false;
                        s.Manufacturer = itemSD.Manufacturer;
                        s.MPN = itemSD.MPN;
                        s.COO = itemSD.CofO;
                        s.CCCNO = itemSD.CCCN_No;
                        // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                        s.UKIntroDate = itemSD.Uk_Intro_Date;
                        s.UKDiscDate = itemSD.Uk_Disc_Date;
                        s.Height = (decimal)itemSD.Heigh;
                        s.Width = (decimal)itemSD.Width;
                        s.Length = (decimal)itemSD.Length;
                        // TODO  TotalWeight hesaplaması - Grossweight farkı
                        s.TotalWeight = (decimal)(s.UnitWeight * itemSD.Unit_Content);
                        s.UC = (int)itemSD.Unit_Content;
                        s.HZ = (itemSD.Hazardous_Ind == "Y") ? true : false;
                        s.CL = (itemSD.Calibration_Ind == "Y") ? true : false;
                        s.LC = (itemSD.Licensed_Ind == "" && itemSD.Licensed_Ind != null) ? true : false;
                        
                        if (itemSD.Hazardous_Ind == "Y")
                        {
                            Hazardou h = IME.Hazardous.Where(x => itemSD.Article_No.Contains(x.ArticleNo)).FirstOrDefault();
                            if (h == null) { h = IME.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemSD.Article_No)).ToString()).FirstOrDefault(); }
                            s.HE = (h.Environment != null) ? true : false;
                            s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                            s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                        }

                        break;
                    case "sdp":
                        SuperDiskP itemSDP = IME.SuperDiskPs.Where(sdp => sdp.Article_No == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemSDP.Standard_Weight / 1000;

                        OnSale itemSDPOS = IME.OnSales.Where(os => os.ArticleNumber == q.ItemCode).FirstOrDefault();
                        if (itemSDPOS != null)
                        {
                            s.OnHandStockBalance = (int)itemSDPOS.OnhandStockBalance;
                            s.QuantityOnOrder = (int)itemSDPOS.QuantityonOrder;
                        }

                        SlidingPrice itemSDPPrice = IME.SlidingPrices.Where(sp => sp.ArticleNo == q.ItemCode).FirstOrDefault();
                        s.SuperSection = itemSDPPrice.SupersectionName;
                        s.Section = itemSDPPrice.SectionName;
                        s.MHLevel1 = itemSDP.MH_Code_Level_1;

                        s.Col1Break = (int)itemSDPPrice.Col1Break;
                        s.Col2Break = (int)itemSDPPrice.Col2Break;
                        s.Col3Break = (int)itemSDPPrice.Col3Break;
                        s.Col4Break = (int)itemSDPPrice.Col4Break;
                        s.Col5Break = (int)itemSDPPrice.Col5Break;
                        s.UK1Price = (int)itemSDPPrice.Col1Price;
                        s.UK2Price = (int)itemSDPPrice.Col2Price;
                        s.UK3Price = (int)itemSDPPrice.Col3Price;
                        s.UK4Price = (int)itemSDPPrice.Col4Price;
                        s.UK5Price = (int)itemSDPPrice.Col5Price;
                        s.Cost1 = (decimal)itemSDPPrice.DiscountedPrice1;
                        s.Cost2 = (decimal)itemSDPPrice.DiscountedPrice2;
                        s.Cost3 = (decimal)itemSDPPrice.DiscountedPrice3;
                        s.Cost4 = (decimal)itemSDPPrice.DiscountedPrice4;
                        s.Cost5 = (decimal)itemSDPPrice.DiscountedPrice5;

                        s.CL = (itemSDP.Calibration_Ind == "Y") ? true : false;
                        s.LC = (itemSDP.Licensed_Ind == "Y") ? true : false;
                        s.Manufacturer = itemSDP.Manufacturer;
                        s.COO = itemSDP.CofO;
                        s.CCCNO = itemSDP.CCCN_No;
                        // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                        s.UKIntroDate = itemSDP.Uk_Intro_Date;
                        s.UKDiscDate = itemSDP.Uk_Disc_Date;
                        s.Height = (decimal)itemSDP.Heigh;
                        s.Width = (decimal)itemSDP.Width;
                        s.Length = (decimal)itemSDP.Length;
                        s.TotalWeight = (decimal)(s.UnitWeight * itemSDP.Unit_Content);
                        s.UC = (int)itemSDP.Unit_Content;
                        s.HZ = (itemSDP.Hazardous_Ind == "Y") ? true : false;
                        s.CL = (itemSDP.Calibration_Ind == "Y") ? true : false;
                        s.LC = (itemSDP.Licensed_Ind == "" && itemSDP.Licensed_Ind != null) ? true : false;

                        if (itemSDP.Hazardous_Ind == "Y")
                        {
                            Hazardou h = IME.Hazardous.Where(x => x.ArticleNo == itemSDP.Article_No).FirstOrDefault();
                            if (h == null) { h = IME.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemSDP.Article_No)).ToString()).FirstOrDefault(); }
                            s.HE = (h.Environment != null) ? true : false;
                            s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                            s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                        }

                        break;
                    case "ext":
                        ExtendedRange itemEXT = IME.ExtendedRanges.Where(ext => ext.ArticleNo == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemEXT.ExtendedRangeWeight / 1000;

                        //s.CL = (itemEXT.Calibration_Ind == "Y") ? true : false;
                        //s.LC = (itemEXT.Licensed_Ind == "Y") ? true : false;
                        s.Manufacturer = (itemEXT.ManufacturerCode != null) ? itemEXT.ManufacturerCode : String.Empty;
                        s.COO = itemEXT.CountryofOrigin;
                        if (itemEXT.CCCN != null) s.CCCNO = itemEXT.CCCN.ToString();
                        // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                        //s.UKIntroDate = itemEXT.Uk_Intro_Date;
                        //s.UKDiscDate = itemEXT.Uk_Disc_Date;
                        s.Height = (decimal)itemEXT.Height;
                        s.Width = (itemEXT.Width != null) ? (decimal)itemEXT.Width : s.Width;
                        s.Length = (decimal)itemEXT.ExtendedRangeLength;
                        s.UC = (int)itemEXT.PackSize;
                        s.TotalWeight = (decimal)(s.UnitWeight * itemEXT.PackSize);
                        
                        s.UOM = itemEXT.UnitofMeasure;
                        //s.HZ = (itemEXT.Hazardous_Ind == "Y") ? true : false;
                        //s.CL = (itemEXT.Calibration_Ind == "Y") ? true : false;
                        //s.LC = (itemEXT.Licensed_Ind == "" && itemEXT.Licensed_Ind != null) ? true : false;

                        //if (itemEXT.Hazardous_Ind == "Y")
                        //{
                        //    Hazardou h = IME.Hazardous.Where(x => x.ArticleNo == itemSDP.Article_No).FirstOrDefault();
                        //    s.HE = (h.Environment != null) ? true : false;
                        //    s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                        //    s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                        //}

                        break;




                        
                }
                //TODO item 3 listeden kontrol edilecek
                //s.Stock
                //s.Supplier

                //TODO 2 İndicator'ları tekrar kontrol et ve çek

                

                if (s.isDeleted == 1)
                {
                    removedItemList.Add(s);
                }
                else
                {
                    itemList.Add(s);
                }
            }
        }

        private SaleItem RowToSaleItem(DataGridViewRow row)
        {
            SaleItem item = new SaleItem();

            return item;
        }

        private void SaleItemToRow(SaleItem item, DataGridViewRow row)
        {
            row.Cells["sNo"].Value = item.NO;
            row.Cells["sBrand"].Value = item.Brand;
            row.Cells["sCCCNO"].Value = item.CCCNO;
            row.Cells["sCL"].Style.BackColor = (item.CL == true) ? Color.Green : Color.White;
            row.Cells["sCompetitor"].Value = item.Competitor;
            row.Cells["sCOO"].Value = item.COO;
            row.Cells["sCost"].Value = item.Cost;
            row.Cells["sCR"].Style.BackColor = (item.CR == true) ? Color.IndianRed : Color.White;
            row.Cells["sCustItemDescription"].Value = item.CustItemDescription;
            row.Cells["sCustItemStockCode"].Value = item.CustItemStockCode;
            row.Cells["sDelivery"].Value = item.Delivery;
            row.Cells["sDescription"].Value = item.Description;
            row.Cells["sDiscount"].Value = item.Discount;
            row.Cells["sHS"].Style.BackColor = (item.HS == true) ? Color.Red : Color.White;
            row.Cells["sHZ"].Style.BackColor = (item.HZ == true) ? Color.IndianRed : Color.White;
            //row.Cells["sisDeleted"].Value = item.isDeleted;
            row.Cells["sItemCode"].Value = item.ItemCode;
            row.Cells["sLandingCost"].Value = item.LandingCost;
            row.Cells["sLC"].Style.BackColor = (item.LM == true) ? Color.BurlyWood : Color.White;
            row.Cells["sLI"].Style.BackColor = (item.LI == true) ? Color.Ivory : Color.White;
            row.Cells["sLM"].Style.BackColor = (item.LM == true) ? Color.Blue : Color.White;
            //row.Cells["sMargin"].Value = CalculateMargin(item.LandingCost, item.UC_UP);
            row.Cells["sMPN"].Value = item.MPN;
            row.Cells["sNO"].Value = item.NO;
            row.Cells["sQty"].Value = item.Qty;
            row.Cells["sStock"].Value = item.Stock;
            row.Cells["sSupplier"].Value = item.Supplier;
            row.Cells["sTargetUP"].Value = item.TargetUP;
            row.Cells["sTotal"].Value = item.Total;
            row.Cells["sTotalWeight"].Value = item.TotalWeight;
            row.Cells["sUC"].Value = item.UC;
            row.Cells["sUCUPCurr"].Value = item.UC_UP;
            row.Cells["sUnitWeight"].Value = item.UnitWeight;
            row.Cells["sUOM"].Value = item.UOM;
            row.Cells["sUPIMELP"].Value = item.UPIMELP;
            row.Cells["sDependantTable"].Value = item.dependentTable;
        }

        private decimal CalculateMargin(decimal landingCost, decimal UCUPCurr)
        {
            return (((1 - landingCost / UCUPCurr)) * 100)/*.ToString("G29")*/;
        }

        private void FillCustomer()
        {
            txtCustomerName.Text = customer.c_name;
            CustomerCode.Text = customer.ID;

            if (customer.CurrNameQuo != null) { cbCurrency.SelectedValue = customer.CurrNameQuo; } else { cbCurrency.SelectedIndex = 0; }
            if (customer.CurrTypeQuo != null) { cbCurrType.SelectedItem = customer.CurrTypeQuo; } else { cbCurrType.SelectedIndex = 0; }
            if (customer.representaryID != null) { cbRep.SelectedValue = customer.representaryID; } else { cbRep.SelectedIndex = 0; }
            if (customer.PaymentTerm != null) { cbPaymentTerm.SelectedValue = customer.PaymentTerm; } else { cbPaymentTerm.SelectedIndex = 0; }
            if (customer.PaymentMethod != null) { cbPayment.SelectedItem = customer.PaymentMethod; } else { cbPayment.SelectedIndex = 0; }
            if (customer.MainContactID != null) { cbWorkers.SelectedValue = customer.MainContactID; } else { cbWorkers.SelectedIndex = 0; }  

            //cbCurrency.SelectedIndex = cbCurrency.FindStringExact(customer.CurrNameQuo);
            //cbCurrType.SelectedIndex = cbCurrType.FindStringExact(customer.CurrTypeQuo);

            if (customer.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentMethod.Payment);
            }
            try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
            try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }


            CustomerAddress deliveryAddress = customer.CustomerAddresses.Where(a => a.AddressType == "Delivery Address").FirstOrDefault();
            invoiceAddress = customer.CustomerAddresses.Where(a => a.AddressType == "Invoice Address").FirstOrDefault();

            if(invoiceAddress != null)
            {
                txtInvoiceAddress.Text = invoiceAddress.AdressDetails;
            }
            else
            {
                txtInvoiceAddress.ReadOnly = false;
                txtInvoiceAddress.Text = String.Empty;
            }
            cbDeliveryAddress.SelectedItem = (deliveryAddress != null) ? deliveryAddress : invoiceAddress;
        }

        private void populateComboBoxes()
        {
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";

            cbWorkers.DataSource = customer.CustomerWorkers.ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";

            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == dtpDate.Value).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "CurType";

            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";

            cbDeliveryAddress.DataSource = customer.CustomerAddresses.ToList();
            cbDeliveryAddress.DisplayMember = "AdressTitle";
            cbDeliveryAddress.ValueMember = "ID";

            cbDeliveryContact.DataSource = customer.CustomerWorkers.ToList();
            cbDeliveryContact.DisplayMember = "cw_name";
            cbDeliveryContact.ValueMember = "ID";

            cbPaymentTerm.DataSource = IME.PaymentTerms.ToList();
            cbPaymentTerm.DisplayMember = "term_name";
            cbPaymentTerm.ValueMember = "ID";
        }

        private void FillItemCard(string itemCode)
        {
            SaleItem s = new SaleItem();
            bool itemFound = false;
            try
            {
                s = addedItemList.Where(item => item.ItemCode.Contains(itemCode)).First();
                itemFound = true;
            }
            catch (Exception){}

            if (itemFound)
            {
                txtManufacturer.Text = s.Manufacturer;
                txtBrand.Text = s.Brand;
                txtSupersectionName.Text = s.SuperSection;
                txtSection.Text = s.Section;
                txtMHCodeLevel1.Text = s.MHLevel1;
                txtCofO.Text = s.COO;
                txtCCCN.Text = s.CCCNO;
                txtRSStock.Text = s.OnHandStockBalance.ToString();
                txtRSOnOrder.Text = s.QuantityOnOrder.ToString();
                txtHazardousInd.BackColor = (s.HZ) ? Color.IndianRed : Color.White;
                txtEnvironment.BackColor = (s.HE) ? Color.IndianRed : Color.White;
                txtShipping.BackColor = (s.HS) ? Color.IndianRed : Color.White;
                txtLithium.BackColor = (s.LI) ? Color.IndianRed : Color.White;
                txtCalibrationInd.BackColor = (s.CL) ? Color.IndianRed : Color.White;
                txtLicenceType.BackColor = (s.LC) ? Color.IndianRed : Color.White;
                //TODO Alttkileri ekle
                /*if (s.DC) { txtDiscCharge.BackColor = Color.IndianRed; }
                if (s.EC) { txtExpiringPro.BackColor = Color.IndianRed; }*/

                //TODO Intro(SD) veriyi kontrol et. DiskDate mi yoksa intro date mi?
                txtUKDiscDate.Text = s.UKIntroDate;

                txtDiscontinuationDate.Text = s.UKDiscDate;

                //TODO alttakileri doldur.
                /*txtSubstitutedBy.Text
                txtRunOn.Text
                txtReferral.Text
                textBox35.Text*/

                txtHeight.Text = (s.Height * 100).ToString();
                txtWidth.Text = (s.Width * 100).ToString();
                txtLength.Text = (s.Length * 100).ToString();
                txtStandartWeight.Text = s.UnitWeight.ToString();

                //TODO GrossWeight nedir, öğren
                txtGrossWeight.Text = s.TotalWeight.ToString();

                txtUnitCount1.Text = s.Col1Break.ToString();
                txtUnitCount2.Text = s.Col2Break.ToString();
                txtUnitCount3.Text = s.Col3Break.ToString();
                txtUnitCount4.Text = s.Col4Break.ToString();
                txtUnitCount5.Text = s.Col5Break.ToString();
                txtUK1.Text = s.UK1Price.ToString();
                txtUK2.Text = s.UK2Price.ToString();
                txtUK3.Text = s.UK3Price.ToString();
                txtUK4.Text = s.UK4Price.ToString();
                txtUK5.Text = s.UK5Price.ToString();
                txtCost1.Text = s.Cost1.ToString();
                txtCost2.Text = s.Cost2.ToString();
                txtCost3.Text = s.Cost3.ToString();
                txtCost4.Text = s.Cost4.ToString();
                txtCost5.Text = s.Cost5.ToString();
                //txtWeb1.Text = (s.UK1Price * customerFactor) / 
            }
        }

        private void btnViewMore_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null || CustomerCode.Text == string.Empty)
            {
                MessageBox.Show("Please Enter a Customer", "Eror !");
            }
            else
            {
                CustomerMain f = new CustomerMain(true, CustomerCode.Text);
                f.ShowDialog();
            }
        }

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null)
            {
                MessageBox.Show("Customer not selected !", "Eror !");
            }
            else
            {
                CustomerMain f = new CustomerMain(1, CustomerCode.Text);
                f.ShowDialog();
            }
        }

        private void btnContactUpdate_Click(object sender, EventArgs e)
        {
            if (CustomerCode.Text == null)
            {
                MessageBox.Show("Customer not selected !", "Eror !");
            }
            else
            {
                CustomerMain f = new CustomerMain(1, CustomerCode.Text);
                f.ShowDialog();
            }
        }

        private void dgSaleItems_Click(object sender, EventArgs e)
        {
            if (dgSaleItems.RowCount > 0 && dgSaleItems.CurrentRow.Cells["sItemCode"].Value != null)
            {
                FillItemCard(dgSaleItems.CurrentRow.Cells["sItemCode"].Value.ToString());
            }
        }

        private void CalculateSubtotal()
        {
            foreach (DataGridViewRow row in dgSaleItems.Rows)
            {
                if(row.Index != dgSaleItems.RowCount-1)
                {
                    subtotal += (decimal)row.Cells["sTotal"].Value;
                }
            }

            lblsubtotal.Text = subtotal.ToString();
        }

        private void CalculateTotalMargin()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgSaleItems.Rows)
            {
                if (row.Index != dgSaleItems.RowCount - 1)
                {
                    total += (decimal)row.Cells["sTotal"].Value * (decimal)row.Cells["sMargin"].Value;
                }
            }
            //totalMargin = total / subtotal;
            txtTotalMargin.Text = totalMargin.ToString();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // TODO SaleOrderAdd Tarih ile ilgili Yapılacakları Öğren
        }

        private void cbCurrency_SelectedValueChanged(object sender, EventArgs e)
        {
            currency = GetCurrency(dtpDate.Value);
        }

        private void ChangeCurrency()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaleOrder so = new SaleOrder();
                so.SaleOrderNo = txtSONo.Text;
                so.SaleDate = DateTime.Today.Date;
                so.CurrenyName = (string)cbCurrency.SelectedValue + " " + cbCurrType.SelectedItem;
                so.OnlineConfirmationNo = txtOnlineConfirmationNo.Text;
                so.QuotationNos = txtQuotationNo.Text;
                if (dtpRequestedDelvDate.Value != dtpDate.Value)
                {
                    so.RequestedDeliveryDate = dtpRequestedDelvDate.Value;
                }
                so.Vat = (chkVat.Checked) ? Convert.ToDecimal(lblVat.Text) : 0;
                so.TotalPrice = Convert.ToDecimal(lblGrossTotal.Text);
                so.NoteForUs = txtNoteForUs.Text;
                so.NoteForFinance = (chkForFinance.Checked) ? 1 : 0;

                so.PaymentTermID = (int)cbPaymentTerm.SelectedValue;
                so.CustomerID = customer.ID;
                so.ContactID = (int)cbWorkers.SelectedValue;
                so.DeliveryContactID = (int)cbDeliveryContact.SelectedValue;
                so.InvoiceAddressID = (invoiceAddress.ID);
                so.DeliveryAddressID = (int)cbDeliveryAddress.SelectedValue;
                so.RepresentativeID = (int)cbRep.SelectedValue;
                so.PaymentMethodID = (int)cbPayment.SelectedValue;
                so.SaleOrderNature = cbOrderNature.SelectedItem.ToString();
                
                IME.SaleOrders.Add(so);
                IME.SaveChanges();

                SaleOrder saleOrder = IME.SaleOrders.Where(s => s.SaleOrderNo == so.SaleOrderNo).FirstOrDefault();
                if (!RowsHasEmptyAreas())
                {
                    for(int i = 0; i < dgSaleItems.RowCount-1; i++)
                    {
                        DataGridViewRow row = dgSaleItems.Rows[i];
                        SaleOrderDetail sod = new SaleOrderDetail();
                        sod.ItemCode = row.Cells["sItemCode"].Value.ToString();
                        sod.Quantity = (int)row.Cells["sQty"].Value;
                        sod.UCUPCurr = (decimal)row.Cells["sUCUPCurr"].Value;
                        sod.Discount = (decimal?)row.Cells["sDiscount"].Value;
                        sod.Total = (decimal)row.Cells["sTotal"].Value;
                        sod.TargetUP = (decimal?)row.Cells["sTargetUP"].Value;
                        sod.Competitor = (row.Cells["sCompetitor"].Value == null) ? null : row.Cells["sCompetitor"].Value.ToString();
                        sod.CustomerDescription = row.Cells["sCustItemDescription"].Value.ToString();
                        //sod.IsDeleted = row.Cells[sdel].Value.ToString();
                        sod.UPIME= (decimal)row.Cells["sUPIMELP"].Value;
                        sod.Margin = (decimal)row.Cells["sMargin"].Value;
                        sod.UnitOfMeasure = row.Cells["sUOM"].Value.ToString();
                        sod.UnitContent = (int)row.Cells["sUC"].Value;
                        sod.SSM = (int?)row.Cells["sSSM"].Value;
                        sod.UnitWeight= (decimal?)row.Cells["sUnitWeight"].Value;
                        sod.DependantTable = row.Cells["sDependantTable"].Value.ToString();

                        so.SaleOrderDetails.Add(sod);
                    }
                    IME.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool RowsHasEmptyAreas()
        {
            int rowCount = addedItemList.Count;
            bool hasEmpty = false;

            for (int i = 0; i < rowCount; i++)
            {
                DataGridViewRow row = dgSaleItems.Rows[i];
                if(row.Cells["sItemCode"] == null || row.Cells["sItemCode"].Value.ToString() == "") { hasEmpty = true; break; }
                if((int)row.Cells["sQty"].Value == null || (int)row.Cells["sQty"].Value == 0) { hasEmpty = true; break; }
                if((decimal)row.Cells["sUCUPCurr"].Value == null || (decimal)row.Cells["sUCUPCurr"].Value == 0) { hasEmpty = true; break; }
                if((decimal)row.Cells["sTotal"].Value == null || (decimal)row.Cells["sTotal"].Value == 0) { hasEmpty = true; break; }
                if((decimal)row.Cells["sUPIMELP"].Value == null || (decimal)row.Cells["sUPIMELP"].Value == 0) { hasEmpty = true; break; }
                if((decimal)row.Cells["sMargin"].Value == null) { hasEmpty = true; break; }
                if(row.Cells["sUOM"].Value.ToString() == null || row.Cells["sUOM"].Value.ToString() == "") { hasEmpty = true; break; }
            }

            return hasEmpty;
        }

        private void dgSaleItems_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && dgSaleItems.CurrentCell.ColumnIndex == 7)
            //{
            //    FormSaleItemSearch form = new FormSaleItemSearch(dgSaleItems.CurrentCell.Value.ToString());
            //    form.ShowDialog();

            //    form.selectedItem.ToString();

            //    //if (form.DialogResult == DialogResult.Yes)
            //    //{

            //    //}
            //    //else
            //    //{

            //    //}
            //    //if (dgSaleItems.CurrentCell.Value != null)
            //    //{
                    
            //    //}
            //}
        }

        private void dgSaleItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                //ItemCode
                case 7:
                    FormSaleItemSearch form = new FormSaleItemSearch(dgSaleItems.CurrentCell.Value.ToString());
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        SaleItem s = ((SaleItem)form.selectedItem);
                        SaleItemToRow(s, dgSaleItems.Rows[e.RowIndex]);
                        addedItemList.Add(s);
                    }
                    else
                    {
                        MessageBox.Show("You did not choose an item","Attention");
                    }
                    break;
            }
        }
    }
}
