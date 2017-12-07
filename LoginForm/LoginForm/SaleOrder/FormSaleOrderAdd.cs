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
        decimal customerFactor = 0;
        decimal currency;


        List<SaleItem> addedItemList = new List<SaleItem>();
        List<SaleItem> removedItemList = new List<SaleItem>();

        List<SlidingPrice> priceList = new List<SlidingPrice>();
        List<OnSale> onSaleList = new List<OnSale>();
        List<Hazardou> hazardousList = new List<Hazardou>();
        CustomerAddress invoiceAddress = new CustomerAddress();

        Customer customer;

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

        private void FormSaleOrderAdd_Load(object sender, EventArgs e)
        {
            numFactor.Value = Utils.getManagement().Factor;
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
                SaleItem s = new SaleItem
                {
                    ItemCode = q.ItemCode,
                    Competitor = q.Competitor,
                    CustItemDescription = q.CustomerDescription,
                    CustItemStockCode = q.CustomerStockCode,
                    NO = (int)q.dgNo,
                    Discount = (q.Disc != null) ? (decimal)q.Disc : 0,
                    isDeleted = (q.IsDeleted == 1) ? 1 : 0,
                    Qty = (int)q.Qty,
                    UC_UP = (decimal)q.UPIME
                };
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
                        s.Manufacturer = itemEXT.ManufacturerCode ?? String.Empty;
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
            row.Cells["sCost"].Value = item.Cost1;
            row.Cells["sCR"].Style.BackColor = (item.CR == true) ? Color.IndianRed : Color.White;
            row.Cells["sCustItemDescription"].Value = item.CustItemDescription;
            row.Cells["sCustItemStockCode"].Value = item.CustItemStockCode;
            row.Cells["sDelivery"].Value = item.Delivery;
            row.Cells["sDescription"].Value = item.Description;
            row.Cells["sDiscount"].Value = item.Discount;
            row.Cells["sHS"].Style.BackColor = (item.HS == true) ? Color.Red : Color.White;
            row.Cells["sHZ"].Style.BackColor = (item.HZ == true) ? Color.IndianRed : Color.White;
            row.Cells["sItemCode"].Value = item.ItemCode;
            row.Cells["sLandingCost"].Value = item.LandingCost;
            row.Cells["sLC"].Style.BackColor = (item.LC == true) ? Color.BurlyWood : Color.White;
            row.Cells["sLI"].Style.BackColor = (item.LI == true) ? Color.Ivory : Color.White;
            row.Cells["sLM"].Style.BackColor = (item.LM == true) ? Color.Blue : Color.White;
            row.Cells["sMargin"].Value = (item.Qty != 0) ? CalculateMargin(item.LandingCost, item.UC_UP) : 0;
            row.Cells["sMPN"].Value = item.MPN;
            row.Cells["sSSM"].Value = item.SSM;
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

            dgSaleItems.CurrentCell = dgSaleItems.Rows[row.Index].Cells[14];
        }

        private decimal CalculateMargin(decimal landingCost, decimal UCUPCurr)
        {
            return (((1 - landingCost / UCUPCurr)) * 100)/*.ToString("G29")*/;
        }

        private void FillCustomer()
        {

            IMEEntities IME = new IMEEntities();
            txtCustomerName.Text = customer.c_name;
            CustomerCode.Text = customer.ID;
            //if (customer.Currency != null) { cbCurrency.SelectedItem = customer.Currency; } else { cbCurrency.SelectedIndex = 0; }
            cbRep.SelectedValue = customer.representaryID;
            cbPaymentTerm.SelectedValue = customer.PaymentTerm;
            cbPayment.SelectedItem = customer.PaymentMethod;
            cbWorkers.SelectedValue = (customer.MainContactID != null) ? customer.MainContactID : -1;

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
            cbDeliveryAddress.SelectedItem = deliveryAddress ?? invoiceAddress;
        }

        private void populateComboBoxes()
        {
            IMEEntities IME = new IMEEntities();
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";

            cbWorkers.DataSource = customer.CustomerWorkers.ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";

            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";

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

        //TODO customer açılmıyor
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
            IMEEntities IME = new IMEEntities();
            //try
            //{
            SaleOrder so = new SaleOrder
            {
                SaleOrderNo = txtSONo.Text,
                SaleDate = DateTime.Today.Date,
                currencyID = (decimal)cbCurrency.SelectedValue,
                OnlineConfirmationNo = txtOnlineConfirmationNo.Text,
                QuotationNos = txtQuotationNo.Text
            };
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
            //so.InvoiceAddressID = (invoiceAddress.ID);
            so.InvoiceAddressID = 1010;
            so.DeliveryAddressID = 1010;
                //so.DeliveryAddressID = (int)cbDeliveryAddress.SelectedValue;
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
                    SaleOrderDetail sod = new SaleOrderDetail
                    {
                        ItemCode = row.Cells["sItemCode"].Value.ToString(),
                        Quantity = (int)row.Cells["sQty"].Value,
                        UCUPCurr = (decimal)row.Cells["sUCUPCurr"].Value,
                        Discount = (decimal?)row.Cells["sDiscount"].Value,
                        Total = (decimal)row.Cells["sTotal"].Value,
                        TargetUP = (decimal?)row.Cells["sTargetUP"].Value,
                        Competitor = row.Cells["sCompetitor"].Value?.ToString(),
                        CustomerDescription = row.Cells["sCustItemDescription"].Value.ToString(),
                        //sod.IsDeleted = row.Cells[sdel].Value.ToString();
                        UPIME = (decimal)row.Cells["sUPIMELP"].Value,
                        Margin = (decimal)row.Cells["sMargin"].Value,
                        UnitOfMeasure = row.Cells["sUOM"].Value.ToString(),
                        UnitContent = (int)row.Cells["sUC"].Value,
                        SSM = (int?)row.Cells["sSSM"].Value,
                        UnitWeight = (decimal?)row.Cells["sUnitWeight"].Value,
                        DependantTable = row.Cells["sDependantTable"].Value.ToString()
                    };

                    so.SaleOrderDetails.Add(sod);
                    }
                    IME.SaveChanges();
                }
            //}
            //catch (Exception)
            //{
            //    //throw;
            //}
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
                # region Itemcode
                case 7:
                    FormSaleItemSearch form = new FormSaleItemSearch(dgSaleItems.CurrentCell.Value.ToString());
                    DialogResult result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        SaleItem s = ItemToSaleItem(form.selectedItemCode, form.selectedItemTable);
                        SaleItemToRow(s, dgSaleItems.Rows[e.RowIndex]);
                        addedItemList.Add(s);
                    }
                    else
                    {
                        MessageBox.Show("You did not choose an item","Attention");
                    }
                    break;
                #endregion
                #region Qty
                case 14:


                    break;
                    #endregion
            }
        }
        private SaleItem ItemToSaleItem(string itemCode, string tableName)
        {
            IMEEntities db = new IMEEntities();
            SaleItem s = new SaleItem
            {
                ItemCode = itemCode
            };

            decimal exchangeRate = (decimal)((Currency)cbCurrency.SelectedItem).ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate;

            //TO DO yerini Değiştir ve coefficient exchange rate e bağla
            switch (tableName)
            {
                #region SuperDisk
                case "sd":
                    SuperDisk sdTable = db.SuperDisks.Where(x=>x.Article_No == itemCode).FirstOrDefault();
                    s.SSM = (int)sdTable.Pack_Quantity;
                    SlidingPrice sdPriceTable = db.SlidingPrices.Where(x => x.ArticleNo == itemCode).FirstOrDefault();
                    s.Brand = sdPriceTable.Brandname ?? null;
                    OnSale sdOnSaleTable = db.OnSales.Where(os => os.ArticleNumber == itemCode).FirstOrDefault();
                    if (sdOnSaleTable != null)
                    {
                        s.OnHandStockBalance = (int)sdOnSaleTable.OnhandStockBalance;
                        s.QuantityOnOrder = (int)sdOnSaleTable.QuantityonOrder;
                    }
                    if (sdTable.Hazardous_Ind == "Y")
                    {
                        Hazardou h = db.Hazardous.Where(x => itemCode.Contains(x.ArticleNo)).FirstOrDefault();
                        if (h == null) { h = db.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemCode)).ToString()).FirstOrDefault(); }
                        s.HE = (h.Environment != null) ? true : false;
                        s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                        s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                    }
                    s.Brand = sdPriceTable.Brandname;
                    s.CCCNO = sdTable.CCCN_No ?? String.Empty;
                    s.CL = (sdTable.Calibration_Ind == "Y") ? true : false;
                    s.Col1Break = (int)sdPriceTable.Col1Break;
                    s.Col2Break = (int)sdPriceTable.Col2Break;
                    s.Col3Break = (int)sdPriceTable.Col3Break;
                    s.Col4Break = (int)sdPriceTable.Col4Break;
                    s.Col5Break = (int)sdPriceTable.Col5Break;
                    s.UK1Price = (int)sdPriceTable.Col1Price;
                    s.UK2Price = (int)sdPriceTable.Col2Price;
                    s.UK3Price = (int)sdPriceTable.Col3Price;
                    s.UK4Price = (int)sdPriceTable.Col4Price;
                    s.UK5Price = (int)sdPriceTable.Col5Price;
                    s.Cost1 = (decimal)sdPriceTable.DiscountedPrice1;
                    s.Cost2 = (decimal)sdPriceTable.DiscountedPrice2;
                    s.Cost3 = (decimal)sdPriceTable.DiscountedPrice3;
                    s.Cost4 = (decimal)sdPriceTable.DiscountedPrice4;
                    s.Cost5 = (decimal)sdPriceTable.DiscountedPrice5;
                    s.COO = sdTable.CofO;
                    //s.Cost
                    s.dependentTable = tableName;
                    s.Description = sdTable.Article_Desc;
                    s.Height = (decimal)sdTable.Heigh;
                    s.ItemCode = itemCode;
                    s.LandingCost = classQuotationAdd.GetLandingCost(itemCode, true, true, true);
                    s.Length = (decimal)sdTable.Length;
                    s.Manufacturer = sdTable.Manufacturer;
                    s.MHLevel1 = sdTable.MH_Code_Level_1;
                    s.MPN = sdTable.MPN;
                    ItemNote note = db.ItemNotes.Where(x => x.ArticleNo == itemCode).FirstOrDefault();
                    s.Note = note?.Note.Note_name;
                    s.Section = sdPriceTable.SectionName;
                    s.SuperSection = sdPriceTable.SupersectionName;
                    //s.Stock
                    //s.Supplier
                    //if (q.TargetUP != null) { s.TargetUP = (decimal)q.TargetUP; }
                    //s.TotalWeight
                    s.UC = (int)sdTable.Unit_Content;
                    s.UKDiscDate = sdTable.Uk_Disc_Date;
                    s.UKIntroDate = sdTable.Uk_Intro_Date;
                    s.UOM = (sdTable.Unit_Measure != "") ? sdTable.Unit_Measure : "Each";
                    s.UPIMELP = (s.UK1Price * numFactor.Value/*Utils.getManagement().Factor*/)/exchangeRate;
                    s.UC_UP = s.UPIMELP;
                    s.Width = (decimal)sdTable.Width;
                    s.UnitWeight = (s.Height * s.Length * s.Width) / 6000;
                    break;
                #endregion
                #region SuperDiskP
                case "sdp":
                    SuperDiskP sdpTable = db.SuperDiskPs.Where(x => x.Article_No == itemCode).FirstOrDefault();
                    s.SSM = (int)sdpTable.Pack_Quantity;
                    SlidingPrice sdpPriceTable = db.SlidingPrices.Where(x => x.ArticleNo == itemCode).FirstOrDefault();
                    s.Brand = sdpPriceTable.Brandname ?? null;
                    OnSale sdpOnSaleTable = db.OnSales.Where(os => os.ArticleNumber == itemCode).FirstOrDefault();
                    if (sdpOnSaleTable != null)
                    {
                        s.OnHandStockBalance = (int)sdpOnSaleTable.OnhandStockBalance;
                        s.QuantityOnOrder = (int)sdpOnSaleTable.QuantityonOrder;
                    }
                    if (sdpTable.Hazardous_Ind == "Y")
                    {
                        Hazardou h = db.Hazardous.Where(x => itemCode.Contains(x.ArticleNo)).FirstOrDefault();
                        if (h == null) { h = db.Hazardous.Where(x => x.ArticleNo == (Int32.Parse(itemCode)).ToString()).FirstOrDefault(); }
                        s.HE = (h.Environment != null) ? true : false;
                        s.HS = (h.Shipping != null && h.Shipping != String.Empty) ? true : false;
                        s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                    }
                    s.Brand = sdpPriceTable.Brandname;
                    s.CCCNO = sdpTable.CCCN_No ?? String.Empty;
                    s.CL = (sdpTable.Calibration_Ind == "Y") ? true : false;
                    s.Col1Break = (int)sdpPriceTable.Col1Break;
                    s.Col2Break = (int)sdpPriceTable.Col2Break;
                    s.Col3Break = (int)sdpPriceTable.Col3Break;
                    s.Col4Break = (int)sdpPriceTable.Col4Break;
                    s.Col5Break = (int)sdpPriceTable.Col5Break;
                    s.UK1Price = (int)sdpPriceTable.Col1Price;
                    s.UK2Price = (int)sdpPriceTable.Col2Price;
                    s.UK3Price = (int)sdpPriceTable.Col3Price;
                    s.UK4Price = (int)sdpPriceTable.Col4Price;
                    s.UK5Price = (int)sdpPriceTable.Col5Price;
                    s.Cost1 = (decimal)sdpPriceTable.DiscountedPrice1;
                    s.Cost2 = (decimal)sdpPriceTable.DiscountedPrice2;
                    s.Cost3 = (decimal)sdpPriceTable.DiscountedPrice3;
                    s.Cost4 = (decimal)sdpPriceTable.DiscountedPrice4;
                    s.Cost5 = (decimal)sdpPriceTable.DiscountedPrice5;
                    s.COO = sdpTable.CofO;
                    //s.Cost
                    s.dependentTable = tableName;
                    s.Description = sdpTable.Article_Desc;
                    s.Height = (decimal)sdpTable.Heigh;
                    s.ItemCode = itemCode;
                    s.LandingCost = classQuotationAdd.GetLandingCost(itemCode, true, true, true);
                    s.Length = (decimal)sdpTable.Length;
                    s.Manufacturer = sdpTable.Manufacturer;
                    s.MHLevel1 = sdpTable.MH_Code_Level_1;
                    s.MPN = sdpTable.MPN;
                    ItemNote notesdp = db.ItemNotes.Where(x => x.ArticleNo == itemCode).FirstOrDefault();
                    s.Note = notesdp?.Note.Note_name;
                    s.Section = sdpPriceTable.SectionName;
                    s.SuperSection = sdpPriceTable.SupersectionName;
                    //s.Stock
                    //s.Supplier
                    //if (q.TargetUP != null) { s.TargetUP = (decimal)q.TargetUP; }
                    //s.TotalWeight
                    s.UC = (int)sdpTable.Unit_Content;
                    s.UKDiscDate = sdpTable.Uk_Disc_Date;
                    s.UKIntroDate = sdpTable.Uk_Intro_Date;
                    s.UOM = (sdpTable.Unit_Measure != "") ? sdpTable.Unit_Measure : "Each"; 
                    s.UPIMELP = (s.UK1Price * numFactor.Value/*Utils.getManagement().Factor*/) / exchangeRate;
                    s.Width = (decimal)sdpTable.Width;
                    s.UnitWeight = (s.Height * s.Length * s.Width) / 6000;
                    break;
                #endregion
                #region ExtendedRange
                case "ext":
                    ExtendedRange extTable = db.ExtendedRanges.Where(ext => ext.ArticleNo == itemCode).FirstOrDefault();
                    s.Description = extTable.ArticleDescription;
                    s.Brand = extTable.Brand;
                    s.MPN = extTable.MPN;
                    s.SSM = (int)extTable.PackSize;
                    s.UnitWeight = (extTable.ExtendedRangeWeight != null) ? extTable.ExtendedRangeWeight / 1000 : null;
                    s.LandingCost = classQuotationAdd.GetLandingCost(s.ItemCode, true, true, true);


                     
                    s.Col1Break = (int)extTable.Col1Break;
                    s.Col2Break = extTable.Col2Break;
                    s.Col3Break = extTable.Col3Break;
                    s.Col4Break = extTable.Col4Break;
                    s.Col5Break = extTable.Col5Break;
                    s.Cost1 = (decimal)extTable.DiscountedPrice1;
                    s.Cost2 = extTable.DiscountedPrice2;
                    s.Cost3 = extTable.DiscountedPrice3;
                    s.Cost4 = extTable.DiscountedPrice4;
                    s.Cost5 = extTable.DiscountedPrice5;
                    s.UK1Price = (decimal)extTable.Col1Price;
                    s.UK2Price = extTable.Col2Price;
                    s.UK3Price = extTable.Col3Price;
                    s.UK4Price = extTable.Col4Price;
                    s.UK5Price = extTable.Col5Price;
                    s.Manufacturer = extTable.ManufacturerCode ?? String.Empty;
                    s.COO = extTable.CountryofOrigin ?? String.Empty;
                    s.CCCNO = extTable.CCCN.ToString() ?? String.Empty;
                    s.Height = extTable.Height;
                    s.Width = (extTable.Width != null) ? (decimal)extTable.Width : s.Width;
                    s.Length = extTable.ExtendedRangeLength;
                    s.UC = (int)extTable.PackSize;
                    s.TotalWeight = s.UnitWeight * extTable.PackSize;
                    s.UPIMELP = (s.UK1Price * numFactor.Value/*Utils.getManagement().Factor*/) / exchangeRate;

                    s.UOM = extTable.UnitofMeasure ?? "Each";
                    break;
                    #endregion
            }
            return s;
        }

        private void QuotationToSaleItem()
        {

        }
    }
}
