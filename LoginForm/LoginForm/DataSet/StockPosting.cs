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
    
    public partial class StockPosting
    {
        public decimal stockPostingId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> voucherTypeId { get; set; }
        public string voucherNo { get; set; }
        public string invoiceNo { get; set; }
        public Nullable<decimal> productId { get; set; }
        public Nullable<decimal> batchId { get; set; }
        public Nullable<decimal> unitId { get; set; }
        public Nullable<decimal> godownId { get; set; }
        public Nullable<decimal> rackId { get; set; }
        public Nullable<decimal> againstVoucherTypeId { get; set; }
        public string againstInvoiceNo { get; set; }
        public string againstVoucherNo { get; set; }
        public Nullable<decimal> inwardQty { get; set; }
        public Nullable<decimal> outwardQty { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> financialYearId { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Godown Godown { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }
}