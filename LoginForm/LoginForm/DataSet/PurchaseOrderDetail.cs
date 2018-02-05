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
    
    public partial class PurchaseOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderDetail()
        {
            this.MaterialReceiptDetails = new HashSet<MaterialReceiptDetail>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
            this.PurchaseReturnDetails = new HashSet<PurchaseReturnDetail>();
        }
    
        public int ID { get; set; }
        public string QuotationNo { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> SendQty { get; set; }
        public string SaleOrderNature { get; set; }
        public string FrtType { get; set; }
        public string ItemDescription { get; set; }
        public bool Hazardous { get; set; }
        public bool Calibration { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public string Unit { get; set; }
        public string FicheNo { get; set; }
        public Nullable<int> AccountNumber { get; set; }
        public Nullable<decimal> unitConversionId { get; set; }
        public Nullable<decimal> unitId { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> SaleOrderID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialReceiptDetail> MaterialReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual UnitConvertion UnitConvertion { get; set; }
        public virtual Unit Unit1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
    }
}
