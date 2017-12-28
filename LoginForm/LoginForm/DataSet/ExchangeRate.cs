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
    
    public partial class ExchangeRate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExchangeRate()
        {
            this.DebitNoteDetails = new HashSet<DebitNoteDetail>();
            this.DeliveryNoteMasters = new HashSet<DeliveryNoteMaster>();
            this.JournalDetails = new HashSet<JournalDetail>();
            this.PartyBalances = new HashSet<PartyBalance>();
            this.ReceiptDetails = new HashSet<ReceiptDetail1>();
            this.PaymentDetails = new HashSet<PaymentDetail>();
        }
    
        public int exchangeRateID { get; set; }
        public Nullable<decimal> currencyId { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> rate { get; set; }
    
        public virtual Currency Currency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DebitNoteDetail> DebitNoteDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryNoteMaster> DeliveryNoteMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JournalDetail> JournalDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartyBalance> PartyBalances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceiptDetail1> ReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
    }
}
