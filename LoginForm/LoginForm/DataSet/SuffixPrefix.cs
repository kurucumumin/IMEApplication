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
    
    public partial class SuffixPrefix
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuffixPrefix()
        {
            this.DeliveryNoteMasters = new HashSet<DeliveryNoteMaster>();
            this.JournalMasters = new HashSet<JournalMaster>();
        }
    
        public decimal suffixprefixId { get; set; }
        public Nullable<decimal> voucherTypeId { get; set; }
        public Nullable<System.DateTime> fromDate { get; set; }
        public Nullable<System.DateTime> toDate { get; set; }
        public Nullable<decimal> startIndex { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public Nullable<int> widthOfNumericalPart { get; set; }
        public Nullable<bool> prefillWithZero { get; set; }
        public string narration { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryNoteMaster> DeliveryNoteMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JournalMaster> JournalMasters { get; set; }
        public virtual VoucherType VoucherType { get; set; }
    }
}