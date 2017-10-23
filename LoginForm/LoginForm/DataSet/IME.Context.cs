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
    
        public virtual DbSet<AuthorizationValue> AuthorizationValues { get; set; }
        public virtual DbSet<Capital> Capitals { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAdress> CustomerAdresses { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<CustomerCategorySubCategory> CustomerCategorySubCategories { get; set; }
        public virtual DbSet<CustomerDepartment> CustomerDepartments { get; set; }
        public virtual DbSet<CustomerSubCategory> CustomerSubCategories { get; set; }
        public virtual DbSet<CustomerTitle> CustomerTitles { get; set; }
        public virtual DbSet<CustomerWorker> CustomerWorkers { get; set; }
        public virtual DbSet<DailyDiscontinued> DailyDiscontinueds { get; set; }
        public virtual DbSet<DiscountValue> DiscountValues { get; set; }
        public virtual DbSet<DualUse> DualUses { get; set; }
        public virtual DbSet<ExtendedRange> ExtendedRanges { get; set; }
        public virtual DbSet<Hazardou> Hazardous { get; set; }
        public virtual DbSet<ItemNote> ItemNotes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<OnSale> OnSales { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<RoleValue> RoleValues { get; set; }
        public virtual DbSet<RSPro> RSProes { get; set; }
        public virtual DbSet<SlidingPrice> SlidingPrices { get; set; }
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
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Management> Managements { get; set; }
    }
}
