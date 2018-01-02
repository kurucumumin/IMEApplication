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
    
    public partial class AccountLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountLedger()
        {
            this.AdvancePayments = new HashSet<AdvancePayment>();
            this.CreditNoteDetails = new HashSet<CreditNoteDetail>();
            this.DebitNoteDetails = new HashSet<DebitNoteDetail>();
            this.DeliveryNoteMasters = new HashSet<DeliveryNoteMaster>();
            this.LedgerPostings = new HashSet<LedgerPosting>();
            this.PartyBalances = new HashSet<PartyBalance>();
            this.PaymentDetails = new HashSet<PaymentDetail>();
            this.PaymentMasters = new HashSet<PaymentMaster>();
            this.PDCClearanceMasters = new HashSet<PDCClearanceMaster>();
            this.PDCPayableMasters = new HashSet<PDCPayableMaster>();
            this.PDCReceivableMasters = new HashSet<PDCReceivableMaster>();
            this.ReceiptDetails = new HashSet<ReceiptDetail>();
            this.SalaryVoucherMasters = new HashSet<SalaryVoucherMaster>();
        }
    
        public decimal ledgerId { get; set; }
        public Nullable<int> accountGroupID { get; set; }
        public string ledgerName { get; set; }
        public Nullable<decimal> openingBalance { get; set; }
        public Nullable<bool> isDefault { get; set; }
        public string crOrDr { get; set; }
        public string narration { get; set; }
        public string mailingName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public Nullable<int> creditPeriod { get; set; }
        public Nullable<decimal> creditLimit { get; set; }
        public Nullable<decimal> pricinglevelId { get; set; }
        public Nullable<bool> billByBill { get; set; }
        public string tin { get; set; }
        public string cst { get; set; }
        public string pan { get; set; }
        public Nullable<decimal> routeId { get; set; }
        public string bankAccountNumber { get; set; }
        public string branchName { get; set; }
        public string branchCode { get; set; }
        public Nullable<System.DateTime> extraDate { get; set; }
        public Nullable<decimal> areaId { get; set; }
    
        public virtual AccountGroup AccountGroup { get; set; }
        public virtual Area Area { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvancePayment> AdvancePayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditNoteDetail> CreditNoteDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DebitNoteDetail> DebitNoteDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryNoteMaster> DeliveryNoteMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LedgerPosting> LedgerPostings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartyBalance> PartyBalances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentMaster> PaymentMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCClearanceMaster> PDCClearanceMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCPayableMaster> PDCPayableMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCReceivableMaster> PDCReceivableMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryVoucherMaster> SalaryVoucherMasters { get; set; }
    }
}
