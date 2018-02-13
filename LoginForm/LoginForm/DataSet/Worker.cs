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
    
    public partial class Worker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Worker()
        {
            this.AdvancePayments = new HashSet<AdvancePayment>();
            this.BonusDeductions = new HashSet<BonusDeduction>();
            this.CreditNoteMasters = new HashSet<CreditNoteMaster>();
            this.Customers = new HashSet<Customer>();
            this.Customers1 = new HashSet<Customer>();
            this.Customers2 = new HashSet<Customer>();
            this.DebitNoteMasters = new HashSet<DebitNoteMaster>();
            this.DeliveryNoteMasters = new HashSet<DeliveryNoteMaster>();
            this.DiscountValues = new HashSet<DiscountValue>();
            this.JournalMasters = new HashSet<JournalMaster>();
            this.MaterialReceiptMasters = new HashSet<MaterialReceiptMaster>();
            this.PaymentMasters = new HashSet<PaymentMaster>();
            this.PDCClearanceMasters = new HashSet<PDCClearanceMaster>();
            this.PDCPayableMasters = new HashSet<PDCPayableMaster>();
            this.PDCReceivableMasters = new HashSet<PDCReceivableMaster>();
            this.PurchaseMasters = new HashSet<PurchaseMaster>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.PurchaseReturnMasters = new HashSet<PurchaseReturnMaster>();
            this.Quotations = new HashSet<Quotation>();
            this.Quotations1 = new HashSet<Quotation>();
            this.RejectionInMasters = new HashSet<RejectionInMaster>();
            this.RejectionOutMasters = new HashSet<RejectionOutMaster>();
            this.SaleOrders = new HashSet<SaleOrder>();
            this.SalesMasters = new HashSet<SalesMaster>();
            this.SalesReturnMasters = new HashSet<SalesReturnMaster>();
            this.ServiceMasters = new HashSet<ServiceMaster>();
            this.Suppliers = new HashSet<Supplier>();
            this.Suppliers1 = new HashSet<Supplier>();
            this.SalaryVoucherDetails = new HashSet<SalaryVoucherDetail>();
            this.AuthorizationValues = new HashSet<AuthorizationValue>();
        }
    
        public int WorkerID { get; set; }
        public string NameLastName { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Email { get; set; }
        public Nullable<int> WorkerNoteID { get; set; }
        public string Phone { get; set; }
        public Nullable<decimal> MinMarge { get; set; }
        public Nullable<decimal> MinRate { get; set; }
        public Nullable<int> Title { get; set; }
        public Nullable<int> isActive { get; set; }
        public Nullable<decimal> desinationID { get; set; }
        public Nullable<decimal> designationId { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string maritalStatus { get; set; }
        public string gender { get; set; }
        public string qualification { get; set; }
        public string address { get; set; }
        public string mobileNumber { get; set; }
        public Nullable<System.DateTime> joiningDate { get; set; }
        public Nullable<System.DateTime> terminationDate { get; set; }
        public string narration { get; set; }
        public string bloodGroup { get; set; }
        public string passportNo { get; set; }
        public Nullable<System.DateTime> passportExpiryDate { get; set; }
        public string labourCardNumber { get; set; }
        public Nullable<System.DateTime> labourCardExpiryDate { get; set; }
        public string visaNumber { get; set; }
        public Nullable<System.DateTime> visaExpiryDate { get; set; }
        public string salaryType { get; set; }
        public Nullable<decimal> dailyWage { get; set; }
        public string bankName { get; set; }
        public string branchName { get; set; }
        public string bankAccountNumber { get; set; }
        public string branchCode { get; set; }
        public string panNumber { get; set; }
        public string pfNumber { get; set; }
        public string esiNumber { get; set; }
        public Nullable<decimal> defaultPackageId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdvancePayment> AdvancePayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonusDeduction> BonusDeductions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditNoteMaster> CreditNoteMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DebitNoteMaster> DebitNoteMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryNoteMaster> DeliveryNoteMasters { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual Designation Designation1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountValue> DiscountValues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JournalMaster> JournalMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialReceiptMaster> MaterialReceiptMasters { get; set; }
        public virtual Note Note { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentMaster> PaymentMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCClearanceMaster> PDCClearanceMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCPayableMaster> PDCPayableMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PDCReceivableMaster> PDCReceivableMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseMaster> PurchaseMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseReturnMaster> PurchaseReturnMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RejectionInMaster> RejectionInMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RejectionOutMaster> RejectionOutMasters { get; set; }
        public virtual SalaryPackage SalaryPackage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesMaster> SalesMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnMaster> SalesReturnMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServiceMaster> ServiceMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalaryVoucherDetail> SalaryVoucherDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorizationValue> AuthorizationValues { get; set; }
    }
}
