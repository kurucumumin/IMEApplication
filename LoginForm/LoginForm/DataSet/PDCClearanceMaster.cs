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
    
    public partial class PDCClearanceMaster
    {
        public decimal PDCClearanceMasterId { get; set; }
        public string voucherNo { get; set; }
        public string invoiceNo { get; set; }
        public Nullable<decimal> suffixPrefixId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> ledgerId { get; set; }
        public string type { get; set; }
        public Nullable<decimal> againstId { get; set; }
        public Nullable<decimal> voucherTypeId { get; set; }
        public string narration { get; set; }
        public string status { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<decimal> financialYearId { get; set; }
    
        public virtual AccountLedger AccountLedger { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual SuffixPrefix SuffixPrefix { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }
}