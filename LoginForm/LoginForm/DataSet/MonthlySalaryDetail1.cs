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
    
    public partial class MonthlySalaryDetail1
    {
        public decimal monthlySalaryDetailsId { get; set; }
        public Nullable<decimal> employeeId { get; set; }
        public Nullable<decimal> salaryPackageId { get; set; }
        public Nullable<decimal> monthlySalaryId { get; set; }
    
        public virtual MonthlySalary MonthlySalary { get; set; }
    }
}
