using LoginForm.DataSet;
using LoginForm.Services;
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
        List<SaleItem> ItemList = new List<SaleItem>();
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
          
            //cbRep.DataSource = IME.CustomerWorkers.Where(a => a.customerID == IME.Customers.Where(b => b.ID == customer.ID).FirstOrDefault().ID).ToList();
            //cbRep.DisplayMember = "cw_name";
            ConvertToSaleItem(list);
            dgSaleItems.DataSource = list;
        }

        private void ConvertToSaleItem(List<QuotationDetail> list)
        {
            IMEEntities IME = new IMEEntities();

            //foreach (QuotationDetail q in list)
            //{
            //    SaleItem s = new SaleItem();
            //    s.ItemCode = q.ItemCode;
            //    var item = IME.SuperDisks.Where(x => x.Article_No == s.ItemCode).First();
            //    s.Competitor = q.Competitor;
            //    s.CustItemDescription = q.CustomerDescription;
            //    s.CustItemStockCode = q.CustomerStockCode;
            //    s.NO = (int)q.dgNo;
            //    //s.Discount = (decimal)q.Disc;
            //    s.isDeleted = (int)q.IsDeleted;
            //    s.Margin = (decimal)q.Marge;
            //    s.Qty = (int)q.Qty;
            //    //s.Stock
            //    //s.Supplier
            //    s.TargetUP = (decimal)q.TargetUP;
            //    s.Total = (decimal)q.Total;
            //    s.UnitWeight = (decimal)item.Standard_Weight/1000;
            //    s.TotalWeight = s.UnitWeight * s.Qty;
            //    s.UC = (int)item.Unit_Content;
            //    s.UC_UP = (decimal)q.UCUPCurr;
            //    s.UOM = item.Unit_Measure;
            //    s.UPIMELP = (decimal)q.UPIME;
            //    //s.HZ = (item.Hazardous_Ind);
            //}
        }




        class SaleItem
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
