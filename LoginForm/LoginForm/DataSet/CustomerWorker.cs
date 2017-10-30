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
            this.Customers = new HashSet<Customer>();
            this.CustomerAdresses = new HashSet<CustomerAdress>();
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerAdress> CustomerAdresses { get; set; }
        public virtual CustomerDepartment CustomerDepartment { get; set; }
        public virtual CustomerTitle CustomerTitle { get; set; }
        public virtual Note Note { get; set; }
        public virtual Language Language { get; set; }
    }
}
