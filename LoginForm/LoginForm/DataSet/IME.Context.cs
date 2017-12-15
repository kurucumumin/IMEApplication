﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IMEEntities : DbContext
    {
        public IMEEntities()
            : base("name=IMEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<AccountLedger> AccountLedgers { get; set; }
        public virtual DbSet<AdvancePayment> AdvancePayments { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AuthorizationValue> AuthorizationValues { get; set; }
        public virtual DbSet<Capital> Capitals { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<CustomerDepartment> CustomerDepartments { get; set; }
        public virtual DbSet<CustomerSubCategory> CustomerSubCategories { get; set; }
        public virtual DbSet<CustomerTitle> CustomerTitles { get; set; }
        public virtual DbSet<CustomerWorker> CustomerWorkers { get; set; }
        public virtual DbSet<DailyDiscontinued> DailyDiscontinueds { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<DiscountValue> DiscountValues { get; set; }
        public virtual DbSet<DualUse> DualUses { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }
        public virtual DbSet<ExtendedRange> ExtendedRanges { get; set; }
        public virtual DbSet<FinancialYear> FinancialYears { get; set; }
        public virtual DbSet<Hazardou> Hazardous { get; set; }
        public virtual DbSet<ItemNote> ItemNotes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LedgerPosting> LedgerPostings { get; set; }
        public virtual DbSet<LoaderDate> LoaderDates { get; set; }
        public virtual DbSet<Mail> Mails { get; set; }
        public virtual DbSet<Management> Managements { get; set; }
        public virtual DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<OnSale> OnSales { get; set; }
        public virtual DbSet<PartyBalance> PartyBalances { get; set; }
        public virtual DbSet<PayHead> PayHeads { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<PrintFormat> PrintFormats { get; set; }
        public virtual DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public virtual DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<RoleValue> RoleValues { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RSPro> RSProes { get; set; }
        public virtual DbSet<SaleOrder> SaleOrders { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public virtual DbSet<SlidingPrice> SlidingPrices { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<SuperDisk> SuperDisks { get; set; }
        public virtual DbSet<SuperDiskP> SuperDiskPs { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierAdress> SupplierAdresses { get; set; }
        public virtual DbSet<SupplierBank> SupplierBanks { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }
        public virtual DbSet<SupplierCategorySubCategory> SupplierCategorySubCategories { get; set; }
        public virtual DbSet<SupplierDepartment> SupplierDepartments { get; set; }
        public virtual DbSet<SupplierMainContact> SupplierMainContacts { get; set; }
        public virtual DbSet<SupplierSubCategory> SupplierSubCategories { get; set; }
        public virtual DbSet<SupplierTitle> SupplierTitles { get; set; }
        public virtual DbSet<SupplierWorker> SupplierWorkers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<TaxDetail> TaxDetails { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<VoucherType> VoucherTypes { get; set; }
        public virtual DbSet<VoucherTypeTax> VoucherTypeTaxes { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
    
        public virtual int PayHeadAdd(string payHeadName, string type, string narration, Nullable<System.DateTime> extraDate)
        {
            var payHeadNameParameter = payHeadName != null ?
                new ObjectParameter("payHeadName", payHeadName) :
                new ObjectParameter("payHeadName", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var narrationParameter = narration != null ?
                new ObjectParameter("narration", narration) :
                new ObjectParameter("narration", typeof(string));
    
            var extraDateParameter = extraDate.HasValue ?
                new ObjectParameter("extraDate", extraDate) :
                new ObjectParameter("extraDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayHeadAdd", payHeadNameParameter, typeParameter, narrationParameter, extraDateParameter);
        }
    
        public virtual int PayHeadDelete(Nullable<decimal> payHeadId)
        {
            var payHeadIdParameter = payHeadId.HasValue ?
                new ObjectParameter("payHeadId", payHeadId) :
                new ObjectParameter("payHeadId", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayHeadDelete", payHeadIdParameter);
        }
    
        public virtual int PayHeadEdit(Nullable<decimal> payHeadId, string payHeadName, string type, string narration, Nullable<System.DateTime> extraDate)
        {
            var payHeadIdParameter = payHeadId.HasValue ?
                new ObjectParameter("payHeadId", payHeadId) :
                new ObjectParameter("payHeadId", typeof(decimal));
    
            var payHeadNameParameter = payHeadName != null ?
                new ObjectParameter("payHeadName", payHeadName) :
                new ObjectParameter("payHeadName", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(string));
    
            var narrationParameter = narration != null ?
                new ObjectParameter("narration", narration) :
                new ObjectParameter("narration", typeof(string));
    
            var extraDateParameter = extraDate.HasValue ?
                new ObjectParameter("extraDate", extraDate) :
                new ObjectParameter("extraDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PayHeadEdit", payHeadIdParameter, payHeadNameParameter, typeParameter, narrationParameter, extraDateParameter);
        }
    
        public virtual ObjectResult<PayHeadGet_Result> PayHeadGet(Nullable<decimal> payHeadId)
        {
            var payHeadIdParameter = payHeadId.HasValue ?
                new ObjectParameter("payHeadId", payHeadId) :
                new ObjectParameter("payHeadId", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayHeadGet_Result>("PayHeadGet", payHeadIdParameter);
        }
    
        public virtual ObjectResult<PayHeadGetAll_Result> PayHeadGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PayHeadGetAll_Result>("PayHeadGetAll");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
