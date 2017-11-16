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
    
    public partial class Quotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quotation()
        {
            this.QuotationDetails = new HashSet<QuotationDetail>();
        }
    
        public string CustomerID { get; set; }
        public Nullable<int> NoteForUsID { get; set; }
        public Nullable<int> NoteForCustomerID { get; set; }
        public Nullable<int> ForFinancelIsTrue { get; set; }
        public Nullable<int> ShippingMethodID { get; set; }
        public Nullable<int> IsItemCost { get; set; }
        public Nullable<int> IsWeightCost { get; set; }
        public Nullable<int> IsCustomsDuties { get; set; }
        public Nullable<decimal> DiscOnSubTotal2 { get; set; }
        public Nullable<decimal> ExtraCharges { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> ValidationDay { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<decimal> Curr { get; set; }
        public Nullable<decimal> Factor { get; set; }
        public Nullable<int> IsVatValue { get; set; }
        public Nullable<decimal> VatValue { get; set; }
        public string CurrName { get; set; }
        public string QuotationNo { get; set; }
        public string RFQNo { get; set; }
        public string CurrType { get; set; }
        public Nullable<int> QuotationMainContact { get; set; }
    
        public virtual Note Note { get; set; }
        public virtual Note Note1 { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationDetail> QuotationDetails { get; set; }
    }
}
