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
    
    public partial class OrderAcknowledgementDetail
    {
        public int ID { get; set; }
        public string PurchaseOrderItemNumber { get; set; }
        public string ProductNumber { get; set; }
        public string ReasonCode { get; set; }
        public string ReasonCodeText { get; set; }
        public string OrderQuantity { get; set; }
        public string SalesUnit { get; set; }
        public string PurchaseOrderItem { get; set; }
        public string ScheduleLineNumber { get; set; }
        public string ScheduleLineDate { get; set; }
        public string ScheduleLineConfirmedQty { get; set; }
        public string ScheduleLineDeliveredQty { get; set; }
        public string SecheduleLineDeliveryBlock { get; set; }
        public string PurchaseOrderItemNumber_SC { get; set; }
        public string TotalNumberofScheduleLines { get; set; }
        public Nullable<int> OrderAcknowledgementID { get; set; }
    
        public virtual OrderAcknowledgement OrderAcknowledgement { get; set; }
    }
}
