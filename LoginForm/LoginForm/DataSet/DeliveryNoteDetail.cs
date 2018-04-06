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
    
    public partial class DeliveryNoteDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryNoteDetail()
        {
            this.SalesDetails = new HashSet<SalesDetail>();
        }
    
        public decimal deliveryNoteDetailsId { get; set; }
        public Nullable<decimal> deliveryNoteMasterId { get; set; }
        public int SaleOrderDetailId { get; set; }
        public string productId { get; set; }
        public Nullable<decimal> qty { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> unitId { get; set; }
        public Nullable<decimal> unitConversionId { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> batchId { get; set; }
        public Nullable<decimal> godownId { get; set; }
        public Nullable<decimal> rackId { get; set; }
        public Nullable<int> slNo { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<int> taxId { get; set; }
        public Nullable<decimal> taxAmount { get; set; }
        public Nullable<decimal> grossAmount { get; set; }
        public Nullable<decimal> netAmount { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual DeliveryNoteMaster DeliveryNoteMaster { get; set; }
        public virtual Godown Godown { get; set; }
        public virtual Rack Rack { get; set; }
        public virtual SaleOrderDetail SaleOrderDetail { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
