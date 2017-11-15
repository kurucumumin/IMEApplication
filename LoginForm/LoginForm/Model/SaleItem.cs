namespace LoginForm.Model
{
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
}
