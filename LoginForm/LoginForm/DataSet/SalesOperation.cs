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
    
    public partial class SalesOperation
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> RepreresentetiveID { get; set; }
        public Nullable<decimal> CurrencyID { get; set; }
    
        public virtual Currency Currency { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
