using LoginForm.DataSet;
using LoginForm.QuotationModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.SaleOrder
{
    public partial class FormSaleOrderAdd : Form
    {
        List<SaleItem> addedItemList = new List<SaleItem>();
        List<SaleItem> removedItemList = new List<SaleItem>();

        List<Hazardou> hazarousList = new List<Hazardou>();
        List<SlidingPrice> priceList = new List<SlidingPrice>();

        Customer customer;
        IMEEntities IME = new IMEEntities();

        public FormSaleOrderAdd()
        {
            InitializeComponent();
        }

        public FormSaleOrderAdd(Customer customer,List<QuotationDetail> list)
        {
            InitializeComponent();
            this.customer = customer;
            BringPriceList(list);
            ConvertToSaleItem(list, addedItemList, removedItemList);
            SortTheList(addedItemList);
            SortTheList(removedItemList);
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
            FillCustomer();
            populateComboBoxes();
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
                if (q.TargetUP != null) { s.TargetUP = (decimal)q.TargetUP; }
                s.Total = (decimal)q.Total;

                // TODO !Important dependantTable verisi eklenmeli
                s.dependentTable = q.dependantTable;

                switch (q.dependantTable)
                {
                    case "sd":
                        SuperDisk itemSD = IME.SuperDisks.Where(sd => sd.Article_No == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemSD.Standard_Weight / 1000;

                        s.CL = (itemSD.Calibration_Ind == "Y") ? true : false;
                        s.LC = (itemSD.Licensed_Ind == "Y") ? true : false;
                        s.Manufacturer = itemSD.Manufacturer;
                        s.COO = itemSD.CofO;
                        s.CCCNO = itemSD.CCCN_No;
                        // TODO Aşağıdaki 2 tarih verisi güncel olan tablodan alınacak.
                        s.UKIntroDate = itemSD.Uk_Intro_Date;
                        s.UKDiscDate = itemSD.Uk_Disc_Date;
                        s.Height = (decimal)itemSD.Heigh;
                        s.Width = (decimal)itemSD.Width;
                        s.Length = (decimal)itemSD.Length;
                        s.TotalWeight = (decimal)(s.UnitWeight * itemSD.Unit_Content);


                        if (itemSD.Hazardous_Ind == "Y")
                        {
                            Hazardou h = IME.Hazardous.Where(x => x.ArticleNo == itemSD.Article_No).FirstOrDefault();
                            s.HS = (h.Environment != null) ? true : false;
                            s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                            hazarousList.Add(h);
                        }


                        break;
                    case "sdp":
                        SuperDiskP itemSDP = IME.SuperDiskPs.Where(sdp => sdp.Article_No == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemSDP.Standard_Weight / 1000;
                        if (itemSDP.Hazardous_Ind == "Y")
                        {
                            Hazardou h = IME.Hazardous.Where(x => x.ArticleNo == itemSDP.Article_No).FirstOrDefault();
                            s.HS = (h.Environment != null) ? true : false;
                            s.LI = (h.Lithium != null && h.Lithium != String.Empty) ? true : false;
                            hazarousList.Add(h);
                        }

                        break;
                    case "ext":
                        ExtendedRange itemEXT = IME.ExtendedRanges.Where(ext => ext.ArticleNo == q.ItemCode).FirstOrDefault();
                        s.UnitWeight = (decimal)itemEXT.ExtendedRangeWeight / 1000;

                        break;
                }
                
                s.TotalWeight = s.UnitWeight * s.Qty;
                // TODO item 3 listeden kontrol edilecek
                //s.Stock
                //s.Supplier
                
                // TODO 2 İndicator'ları tekrar kontrol et ve çek

                /*s.UC = (int)item.Unit_Content;
                s.UOM = item.Unit_Measure;
                s.UPIMELP = (decimal)q.UCUPCurr;
                s.HZ = (item.Hazardous_Ind == "Y") ? true : false;
                s.CL = (item.Calibration_Ind == "Y") ? true : false;
                s.LC = (item.Licensed_Ind == "" && item.Licensed_Ind != null) ? true : false;*/

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
            row.Cells["sCR"].Value = item.CR;
            row.Cells["sCustItemDescription"].Value = item.CustItemDescription;
            row.Cells["sCustItemStockCode"].Value = item.CustItemStockCode;
            row.Cells["sDelivery"].Value = item.Delivery;
            row.Cells["sDescription"].Value = item.Description;
            row.Cells["sDiscount"].Value = item.Discount;
            row.Cells["sHS"].Style.BackColor = (item.HS == true) ? Color.Red : Color.White;
            row.Cells["sHZ"].Value = item.HZ;
            //row.Cells["sisDeleted"].Value = item.isDeleted;
            row.Cells["sItemCode"].Value = item.ItemCode;
            row.Cells["sLandingCost"].Value = item.LandingCost;
            row.Cells["sLC"].Style.BackColor = (item.LM == true) ? Color.BurlyWood : Color.White;
            row.Cells["sLI"].Style.BackColor = (item.LI == true) ? Color.Ivory : Color.White;
            row.Cells["sLM"].Style.BackColor = (item.LM == true) ? Color.Blue : Color.White;
            row.Cells["sMargin"].Value = item.Margin;
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
        }

        private decimal CalculateMargin(decimal landingCost, decimal UCUPCurr)
        {
            return (((1 - landingCost / UCUPCurr)) * 100)/*.ToString("G29")*/;
        }


        public partial class SaleItem
        {
            public int NO { get; set; }
            public bool HZ { get; set; }
            public bool HE { get; set; }
            public bool HS { get; set; }
            public bool LI { get; set; }
            public bool CL { get; set; }
            public bool LC { get; set; }
            public bool LM { get; set; }
            public string Supplier { get; set; }
            public string ItemCode { get; set; }
            public string Brand { get; set; }
            public string MPN { get; set; }
            public string Description { get; set; }
            public decimal Cost { get; set; }
            public decimal LandingCost { get; set; }
            public decimal Margin { get; set; }
            public int Qty { get; set; }
            public int Stock { get; set; }
            public string UOM { get; set; }
            public int UC { get; set; }
            public decimal UPIMELP { get; set; }
            public decimal Discount { get; set; }
            public decimal UC_UP { get; set; }
            public decimal Total { get; set; }
            public decimal TargetUP { get; set; }
            public string Competitor { get; set; }
            public bool CR { get; set; }
            public string Delivery { get; set; }
            public decimal UnitWeight { get; set; }
            public decimal TotalWeight { get; set; }
            public string CustItemStockCode { get; set; }
            public string CustItemDescription { get; set; }
            public string COO { get; set; }
            public string CCCNO { get; set; }
            public int isDeleted { get; set; }
            public string Manufacturer { get; set; }
            public string dependentTable { get; set; }
            public string UKIntroDate { get; set; }
            public string UKDiscDate { get; set; }
            public decimal Height { get; set; }
            public decimal Width { get; set; }
            public decimal Length { get; set; }
        }

        private void FillCustomer()
        {
            txtCustomerName.Text = customer.c_name;
            CustomerCode.Text = customer.ID;
            cbCurrency.SelectedIndex = cbCurrency.FindStringExact(customer.CurrNameQuo);
            cbCurrType.SelectedIndex = cbCurrType.FindStringExact(customer.CurrTypeQuo);
            if (customer.paymentmethodID != null)
            {
                cbPayment.SelectedIndex = cbPayment.FindStringExact(customer.PaymentMethod.Payment);
            }
            try { txtContactNote.Text = customer.CustomerWorker.Note.Note_name; } catch { }
            try { txtCustomerNote.Text = customer.Note.Note_name; } catch { }
            try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == customer.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }

            
        }

        private void populateComboBoxes()
        {
            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
            cbRep.SelectedValue = customer.representaryID;

            cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == customer.ID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";

            cbCurrency.DataSource = IME.Rates.Where(a => a.rate_date == dtpDate.Value).ToList();
            cbCurrency.DisplayMember = "CurType";
            cbCurrency.ValueMember = "ID";

            cbPayment.DataSource = IME.PaymentMethods.ToList();
            cbPayment.DisplayMember = "Payment";
            cbPayment.ValueMember = "ID";
        }

        private void dgSaleItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(dgSaleItems.DataSource != null)
            {
                FillItemCard(dgSaleItems.CurrentRow.Cells["sItemCode"].Value.ToString());
            }
        }

        private void FillItemCard(string itemCode)
        {



            //throw new NotImplementedException();
        }
    }
}
