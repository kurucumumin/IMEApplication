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
    
    public partial class CustomerWorker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerWorker()
        {
            this.CustomerAddresses = new HashSet<CustomerAddress>();
            this.SaleOrders = new HashSet<SaleOrder>();
            this.SaleOrders1 = new HashSet<SaleOrder>();
            this.Customers = new HashSet<Customer>();
        }
    
        public int ID { get; set; }
        public string cw_name { get; set; }
        public Nullable<int> departmentID { get; set; }
        public string phone { get; set; }
        public Nullable<int> titleID { get; set; }
        public string fax { get; set; }
        public string mobilephone { get; set; }
        public string cw_email { get; set; }
        public string customerID { get; set; }
        public Nullable<int> customerNoteID { get; set; }
        public Nullable<int> languageID { get; set; }
        public Nullable<int> ContactTypeID { get; set; }
        public Nullable<int> CustomerWorkerAdress { get; set; }
    
        public virtual ContactType ContactType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual CustomerDepartment CustomerDepartment { get; set; }
        public virtual CustomerTitle CustomerTitle { get; set; }
        public virtual Note Note { get; set; }
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleOrder> SaleOrders1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
