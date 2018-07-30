using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services.MyClasses
{
    class MyAuthority
    {
        public enum IMEAuthority
        {
            CanSeeCostandMarginInQuotationModule=1020,
            CanSeeTotalMarge=1021,
            CanSeeLoaderModule=1022,
            CanSeeDevelopmentModule = 1023,
            CanSeeManagementModule=1024,
            CanSeeCustomerModule=1089,
            CanAddCustomer=1090,
            CanEditCustomer=1091,
            CanSeePurchaseOrderModule=1092,
            CanAddPurchaseOrder=1093,
            CanSeeSupplierModule=1094,
            CanAddSupplier=1095,
            CanEditSupplier=1096,
            CanSeeUserModule=1097,
            CanSeeItemCardModule=1100,
            CanSeeAllBreakPointPricesinItemCard=1101,
            CanAddNoteinItemCard=1102,
            CanEditNoteinItemCard=1103,
            CanSeeSaleOrderModule=1104,
            CanAddSaleOrderModule=1105,
            CanEditLowMarginLimit=1107,
            CanEditVAT=1108,
            CanEditDefaultCurrency=1109,
            CanEditFactor=1110,
            CanEditDataSeperator=1111,
            CanEditDataBranchCode=1112,
            CanEditDataExchangeRate=1113,
            CanSeeSuperDisk=1114,
            CanSeeLicencedArticles=1115,
            CanSeeDiscontinuedList=1116,
            CanSeeSlidingPriceList=1117,
            CanSeeHazardousArticlesFileStrucure=1118,
            CanSeeStockLevelReport=1119,
            CanSeeOrderAcknowledgement=1120,
            CanSeeQuotationModule=1121,
            CanEditTermsofPayment=1122,
            CanEditRolesandAuthorities=1123,
            CanEditCategoryandSubCategory=1124,
            CanEditAnyQuotation=1125,
            CanDeleteQuotation=1126,
            CanAddQuotation=1127
        }
    }
}
