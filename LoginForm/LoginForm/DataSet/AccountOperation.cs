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
    
    public partial class AccountOperation
    {
        public int ID { get; set; }
        public int FromAccountID { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public int ToAccountID { get; set; }
        public int RepresentativeID { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Account Account1 { get; set; }
        public virtual Worker Worker { get; set; }
    }
}