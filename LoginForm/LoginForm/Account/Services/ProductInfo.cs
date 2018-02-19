
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginForm.Account.Services
{
    class ProductInfo
    {
        private string _productId;
        private string _productCode;
        private string _productName;
        private decimal _groupId;
        private decimal _brandId;
        private decimal _unitId;
        private decimal _sizeId;
        private decimal _modelNoId;
        private decimal _taxId;
        private string _taxapplicableOn;
        private decimal _purchaseRate;
        private decimal _salesRate;
        private decimal _mrp;
        private decimal _minimumStock;
        private decimal _maximumStock;
        private decimal _reorderLevel;
        private decimal _godownId;
        private decimal _rackId;
        private bool _isallowBatch;
        private bool _ismultipleunit;
        private bool _isBom;
        private bool _isopeningstock;
        private string _narration;
        private bool _isActive;
        private bool _isshowRemember;
        private string _partNo;

        public string ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        public decimal GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        public decimal BrandId
        {
            get { return _brandId; }
            set { _brandId = value; }
        }
        public decimal UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }
        public decimal SizeId
        {
            get { return _sizeId; }
            set { _sizeId = value; }
        }
        public decimal ModelNoId
        {
            get { return _modelNoId; }
            set { _modelNoId = value; }
        }
        public decimal TaxId
        {
            get { return _taxId; }
            set { _taxId = value; }
        }
        public string TaxapplicableOn
        {
            get { return _taxapplicableOn; }
            set { _taxapplicableOn = value; }
        }
        public decimal PurchaseRate
        {
            get { return _purchaseRate; }
            set { _purchaseRate = value; }
        }
        public decimal SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }
        public decimal Mrp
        {
            get { return _mrp; }
            set { _mrp = value; }
        }
        public decimal MinimumStock
        {
            get { return _minimumStock; }
            set { _minimumStock = value; }
        }
        public decimal MaximumStock
        {
            get { return _maximumStock; }
            set { _maximumStock = value; }
        }
        public decimal ReorderLevel
        {
            get { return _reorderLevel; }
            set { _reorderLevel = value; }
        }
        public decimal GodownId
        {
            get { return _godownId; }
            set { _godownId = value; }
        }
        public decimal RackId
        {
            get { return _rackId; }
            set { _rackId = value; }
        }
        public bool IsallowBatch
        {
            get { return _isallowBatch; }
            set { _isallowBatch = value; }
        }
        public bool Ismultipleunit
        {
            get { return _ismultipleunit; }
            set { _ismultipleunit = value; }
        }
        public bool IsBom
        {
            get { return _isBom; }
            set { _isBom = value; }
        }
        public bool Isopeningstock
        {
            get { return _isopeningstock; }
            set { _isopeningstock = value; }
        }
        public string Narration
        {
            get { return _narration; }
            set { _narration = value; }
        }
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        public bool IsshowRemember
        {
            get { return _isshowRemember; }
            set { _isshowRemember = value; }
        }
        public string PartNo
        {
            get { return _partNo; }
            set { _partNo = value; }
        }
    }
}
