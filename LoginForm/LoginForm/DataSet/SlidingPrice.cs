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
    
    public partial class SlidingPrice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SlidingPrice()
        {
            this.DiscountValues = new HashSet<DiscountValue>();
        }
    
        public string ArticleNo { get; set; }
        public string ArticleDescription { get; set; }
        public Nullable<int> ItemTypeCode { get; set; }
        public string ItemTypeDesc { get; set; }
        public string IntroductionDate { get; set; }
        public string DiscontinuedDate { get; set; }
        public Nullable<int> Quantity1 { get; set; }
        public Nullable<decimal> Col1Price { get; set; }
        public Nullable<decimal> Col3Price { get; set; }
        public Nullable<decimal> Col4Price { get; set; }
        public Nullable<decimal> Col5Price { get; set; }
        public Nullable<int> Col1Break { get; set; }
        public Nullable<int> Col2Break { get; set; }
        public Nullable<int> Col3Break { get; set; }
        public Nullable<int> Col4Break { get; set; }
        public Nullable<int> Col5Break { get; set; }
        public Nullable<decimal> DiscountedPrice1 { get; set; }
        public Nullable<decimal> DiscountedPrice2 { get; set; }
        public Nullable<decimal> DiscountedPrice3 { get; set; }
        public Nullable<decimal> DiscountedPrice4 { get; set; }
        public Nullable<decimal> DiscountedPrice5 { get; set; }
        public string SuperSectionNo { get; set; }
        public string SupersectionName { get; set; }
        public string BrandID { get; set; }
        public string Brandname { get; set; }
        public string SectionID { get; set; }
        public string SectionName { get; set; }
        public Nullable<decimal> Col2Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountValue> DiscountValues { get; set; }
    }
}
