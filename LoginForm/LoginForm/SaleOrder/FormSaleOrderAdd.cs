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
        List<SaleItem> itemList = new List<SaleItem>();
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
            itemList = ConvertToSaleItem(list);
            dgSaleItems.DataSource = itemList;
        }

        private List<SaleItem> ConvertToSaleItem(List<QuotationDetail> list)
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
                //s.Discount = (decimal)q.Disc;
                s.isDeleted = (q.IsDeleted == 1) ? 1 : 0;
                s.Qty = (int)q.Qty;
                //s.UC_UP = (decimal)q.UPIME;
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

                saleItemList.Add(s);
            }

            return saleItemList;
        }

        private decimal CalculateMargin(decimal landingCost, decimal UCUPCurr)
        {
            return (((1 - landingCost / UCUPCurr)) * 100)/*.ToString("G29")*/;
        }

        //private void CalculateLandingCost()
        //{
        //    dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = (classQuotationAdd.GetLandingCost(dgQuotationAddedItems.Rows[Rowindex].Cells["dgProductCode"].Value.ToString(), ckItemCost.Checked, ckWeightCost.Checked, ckCustomsDuties.Checked
        //            )).ToString("G29");
        //    dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value = String.Format("{0:0.0000}", dgQuotationAddedItems.Rows[Rowindex].Cells["dgLandingCost"].Value.ToString()).ToString();
        //}




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
            IMEEntities IME = new IMEEntities();

            var c = IME.Customers.Where(a => a.ID == customer.ID).FirstOrDefault();

            if (c != null)
            {
                txtCustomerName.Text = c.c_name;
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(c.CurrNameQuo);
                cbCurrType.SelectedIndex = cbCurrType.FindStringExact(c.CurrTypeQuo);
                if (c.paymentmethodID != null)
                {
                    cbPayment.SelectedIndex = cbPayment.FindStringExact(c.PaymentMethod.Payment);
                }
                try { txtContactNote.Text = c.CustomerWorker.Note.Note_name; } catch { }
                try { txtCustomerNote.Text = c.Note.Note_name; } catch { }
                try { txtAccountingNote.Text = IME.Notes.Where(a => a.ID == c.customerAccountantNoteID).FirstOrDefault().Note_name; } catch { }
            }
            cbRep.SelectedValue = c.representaryID;
        }

        private void FormSaleOrderAdd_Load(object sender, EventArgs e)
        {
            #region Combobox

            cbRep.DataSource = IME.Workers.ToList();
            cbRep.DisplayMember = "NameLastName";
            cbRep.ValueMember = "WorkerID";
           // cbRep.SelectedValue = Utils.getCurrentUser().WorkerID;

            cbWorkers.DataSource = IME.CustomerWorkers.Where(a => a.customerID == customer.ID).ToList();
            cbWorkers.DisplayMember = "cw_name";
            cbWorkers.ValueMember = "ID";
            #endregion

            FillCustomer();
        }


    }
}
