//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginForm.DataSet
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockReserve
    {
        public int ReserveID { get; set; }
        public decimal StockID { get; set; }
        public int Qty { get; set; }
        public string CustomerID { get; set; }
        public Nullable<System.DateTime> ValidationDate { get; set; }
        public string ProductID { get; set; }
        public Nullable<decimal> SaleOrderID { get; set; }
        public Nullable<int> NotConfirmedQ { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
