using LoginForm.DataSet;
using LoginForm.QuotationModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.SaleOrder
{
    public partial class FormSaleOrderAdd : Form
    {
        List<SaleItem> addedItemList = new List<SaleItem>();
        List<SaleItem> removedItemList = new List<SaleItem>();

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
            ConvertToSaleItem(list, addedItemList, removedItemList);
            SortTheList();
        }

        private void FormSaleOrderAdd_Load(object sender, EventArgs e)
        {
            foreach (SaleItem item in addedItemList)
            {
                int newRowIndex = dgSaleItems.Rows.Add();
                SaleItemToRow(item,dgSaleItems.Rows[newRowIndex]);
            }

            //dgSaleItems.Rows.Add(itemList);
            populateComboBoxes();
            FillCustomer();
        }

        private void SortTheList()
        {
            int i = 1;
            foreach (SaleItem item in addedItemList)
            {
                item.NO = i;
                i++;
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
                var item = IME.SuperDisks.Where(x => x.Article_No == s.ItemCode).First();
                s.Competitor = q.Competitor;
                s.CustItemDescription = q.CustomerDescription;
                s.CustItemStockCode = q.CustomerStockCode;
                s.NO = (int)q.dgNo;
                s.Discount = (decimal)q.Disc;
                s.isDeleted = (q.IsDeleted == 1) ? 1 : 0;
                s.Qty = (int)q.Qty;
                s.UC_UP = (decimal)q.UPIME;
                bool isItemCost = (q.Quotation.IsItemCost == 1) ? true : false;
                bool isWeightCost =(q.Quotation.IsWeightCost == 1) ? true : false;
                bool isCustomsDuties = (q.Quotation.IsCustomsDuties == 1) ? true : false;
                s.LandingCost = classQuotationAdd.GetLandingCost(s.ItemCode, isItemCost, isWeightCost, isCustomsDuties);
                s.Margin = CalculateMargin(s.LandingCost, s.UC_UP);
                //s.Stock
                //s.Supplier
                if(q.TargetUP != null) {s.TargetUP = (decimal)q.TargetUP;}
                s.Total = (decimal)q.Total;
                s.UnitWeight = (decimal)item.Standard_Weight / 1000;
                s.TotalWeight = s.UnitWeight * s.Qty;
                s.UC = (int)item.Unit_Content;
                s.UOM = item.Unit_Measure;
                s.UPIMELP = (decimal)q.UCUPCurr;
                s.HZ = (item.Hazardous_Ind == "Y") ? true : false;

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

            item.NO = (int)row.Cells["No"].Value;
            
            return item;
        }

        private void SaleItemToRow(SaleItem item, DataGridViewRow row)
        {
            row.Cells["sNo"].Value = item.NO;
            row.Cells["sBrand"].Value = item.Brand;
            row.Cells["sCCCNO"].Value = item.CCCNO;
            row.Cells["sCL"].Value = item.CL;
            row.Cells["sCompetitor"].Value = item.Competitor;
            row.Cells["sCOO"].Value = item.COO;
            row.Cells["sCost"].Value = item.Cost;
            row.Cells["sCR"].Value = item.CR;
            row.Cells["sCustItemDescription"].Value = item.CustItemDescription;
            row.Cells["sCustItemStockCode"].Value = item.CustItemStockCode;
            row.Cells["sDelivery"].Value = item.Delivery;
            row.Cells["sDescription"].Value = item.Description;
            row.Cells["sDiscount"].Value = item.Discount;
            row.Cells["sHS"].Value = item.HS;
            row.Cells["sHZ"].Value = item.HZ;
            //row.Cells["sisDeleted"].Value = item.isDeleted;
            row.Cells["sItemCode"].Value = item.ItemCode;
            row.Cells["sLandingCost"].Value = item.LandingCost;
            row.Cells["sLC"].Value = item.LC;
            row.Cells["sLI"].Value = item.LI;
            row.Cells["sLM"].Value = item.LM;
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
            public bool HZ { get; set; }
            public bool CR { get; set; }
            public string Delivery { get; set; }
            public decimal UnitWeight { get; set; }
            public decimal TotalWeight { get; set; }
            public string CustItemStockCode { get; set; }
            public string CustItemDescription { get; set; }
            public string COO { get; set; }
            public string CCCNO { get; set; }
            public int isDeleted { get; set; }
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


    }
}
