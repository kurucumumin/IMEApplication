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
    
    public partial class BudgetDetail
    {
        public decimal budgetDetailsId { get; set; }
        public Nullable<decimal> budgetMasterId { get; set; }
        public string particular { get; set; }
        public Nullable<decimal> credit { get; set; }
        public Nullable<decimal> debit { get; set; }
    
        public virtual BudgetMaster BudgetMaster { get; set; }
    }
}