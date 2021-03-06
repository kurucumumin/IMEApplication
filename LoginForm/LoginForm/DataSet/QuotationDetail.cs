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
    
    public partial class QuotationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuotationDetail()
        {
            this.SaleOrderDetails = new HashSet<SaleOrderDetail>();
        }
    
        public int ID { get; set; }
        public Nullable<decimal> dgNo { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<decimal> UCUPCurr { get; set; }
        public Nullable<decimal> Disc { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> TargetUP { get; set; }
        public string Competitor { get; set; }
        public string ItemDescription { get; set; }
        public string CustomerStockCode { get; set; }
        public string QuotationNo { get; set; }
        public Nullable<decimal> UPIME { get; set; }
        public Nullable<decimal> Marge { get; set; }
        public string UnitOfMeasure { get; set; }
        public Nullable<int> UC { get; set; }
        public Nullable<int> SSM { get; set; }
        public Nullable<decimal> UnitWeight { get; set; }
        public string DependantTable { get; set; }
        public Nullable<decimal> unitConversionId { get; set; }
        public Nullable<int> quotationDeliveryID { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> LandingCost { get; set; }
        public string MPN { get; set; }
        public Nullable<decimal> UKPrice { get; set; }
        public string Status { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public string CustomerName { get; set; }
        public Nullable<decimal> UnitNetWeight { get; set; }
        public string DubaiStatus { get; set; }
        public Nullable<decimal> PacketUP { get; set; }
        public Nullable<decimal> FirstUPIME { get; set; }
        public string CustomerDesc { get; set; }
        public string Manufacturer { get; set; }
        public string SupplierName { get; set; }
        public Nullable<decimal> ReportIME { get; set; }
    
        public virtual Quotation Quotation { get; set; }
        public virtual QuotationDelivery QuotationDelivery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaleOrderDetail> SaleOrderDetails { get; set; }
    }
}
