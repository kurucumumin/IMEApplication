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
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.SupplierAdresses = new HashSet<SupplierAdress>();
            this.SupplierCategorySubCategories = new HashSet<SupplierCategorySubCategory>();
            this.SupplierWorkers = new HashSet<SupplierWorker>();
        }
    
        public string ID { get; set; }
        public string s_name { get; set; }
        public string telephone { get; set; }
        public Nullable<int> paymentmethodID { get; set; }
        public string fax { get; set; }
        public Nullable<int> creditlimit { get; set; }
        public string webadress { get; set; }
        public Nullable<int> payment_termID { get; set; }
        public Nullable<int> representaryID { get; set; }
        public Nullable<int> rate_ID { get; set; }
        public string taxoffice { get; set; }
        public Nullable<int> taxnumber { get; set; }
        public Nullable<int> accountrepresentaryID { get; set; }
        public Nullable<int> SupplierNoteID { get; set; }
        public Nullable<int> MainContactID { get; set; }
        public Nullable<int> BankID { get; set; }
        public string PoBox { get; set; }
        public Nullable<decimal> discountrate { get; set; }
        public string iban { get; set; }
        public string branchcode { get; set; }
        public string accountnumber { get; set; }
    
        public virtual Note Note { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PaymentTerm PaymentTerm { get; set; }
        public virtual Rate Rate { get; set; }
        public virtual SupplierBank SupplierBank { get; set; }
        public virtual SupplierMainContact SupplierMainContact { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierAdress> SupplierAdresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierCategorySubCategory> SupplierCategorySubCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierWorker> SupplierWorkers { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Worker Worker1 { get; set; }
    }
}
