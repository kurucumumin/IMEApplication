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
    
    public partial class SaleOrder_SaleOrderNo_Result
    {
        public decimal SaleOrderNo { get; set; }
        public System.DateTime SaleDate { get; set; }
        public string OnlineConfirmationNo { get; set; }
        public string QuotationNos { get; set; }
        public int PaymentTermID { get; set; }
        public Nullable<System.DateTime> RequestedDeliveryDate { get; set; }
        public Nullable<decimal> Vat { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public string CustomerID { get; set; }
        public int ContactID { get; set; }
        public int DeliveryContactID { get; set; }
        public int InvoiceAddressID { get; set; }
        public int DeliveryAddressID { get; set; }
        public int RepresentativeID { get; set; }
        public int PaymentMethodID { get; set; }
        public string NoteForUs { get; set; }
        public string NoteForCustomer { get; set; }
        public Nullable<int> NoteForFinance { get; set; }
        public string SaleOrderNature { get; set; }
        public string ShippingType { get; set; }
        public string LPONO { get; set; }
        public Nullable<decimal> Factor { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> DiscOnSubtotal { get; set; }
        public Nullable<decimal> ExtraCharges { get; set; }
        public Nullable<decimal> TotalMargin { get; set; }
        public string invoiceNo { get; set; }
        public Nullable<int> exchangeRateID { get; set; }
        public decimal SaleOrderID { get; set; }
        public decimal financialYearId { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> TotalDiscount { get; set; }
        public Nullable<int> PurchaseOrderID { get; set; }
    }
}