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
    
    public partial class SupplierWorker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplierWorker()
        {
            this.Suppliers = new HashSet<Supplier>();
        }
    
        public int ID { get; set; }
        public string sw_name { get; set; }
        public Nullable<int> departmentID { get; set; }
        public string phone { get; set; }
        public Nullable<int> titleID { get; set; }
        public string fax { get; set; }
        public string mobilephone { get; set; }
        public string sw_email { get; set; }
        public Nullable<int> supplieradressID { get; set; }
        public string supplierID { get; set; }
        public Nullable<int> supplierNoteID { get; set; }
        public Nullable<int> languageID { get; set; }
        public string PhoneExternalNum { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Note Note { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual SupplierAddress SupplierAddress { get; set; }
    }
}
