using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginForm.QuotationModule
{

    class QuotationUtils
    {
        public static string customersearchID;
        public static string quotationNo;
        public static bool IsWithItems;
        public static string customersearchname;
        public static string customerID;
        public static string customername;
        public static string ItemCode;

        public static List<Customer> CustomerSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Customer> c = new List<Customer>();
            if (customersearchname == "")
            {
                c = IME.Customers.Where(a => a.ID.StartsWith(customersearchID)).ToList().Where(a=>a.c_name!=null).Where(b=>b.c_name!=string.Empty).ToList();
            }
            else
            {
                c = IME.Customers.Where(a => a.c_name.StartsWith(customersearchname)).ToList().Where(a => a.c_name != null).Where(b => b.c_name != string.Empty).ToList();
            }
            return c;
        }

        public static SuperDisk ItemGetSuperDisk(string ItemID)
        {
            IMEEntities IME = new IMEEntities();

            return IME.SuperDisks.Where(a => a.Article_No == ItemID).FirstOrDefault();

        }

        public static SuperDiskP ItemGetSuperDiskP(string ItemID)
        {
            IMEEntities IME = new IMEEntities();
            return IME.SuperDiskPs.Where(a => a.Article_No == ItemID).FirstOrDefault();

        }
        public static ExtendedRange ItemGetExtendedRange(string ItemID)
        {
            IMEEntities IME = new IMEEntities();
            return IME.ExtendedRanges.Where(a => a.ArticleNo == ItemID).FirstOrDefault();
        }
        public static decimal GetCost(string ArticleNo, int quantity)
        {
            #region GetCost
            if (quantity == 0) { return -1; }
            IMEEntities IME = new IMEEntities();
            //SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            ExtendedRange er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal result;

            CompleteItem item = IME.CompleteItems.Where(x => x.Article_No == ArticleNo).FirstOrDefault();

            /*Cofactor break değerleri ile çarpılacak*/
            int cofactor = (int)item.Unit_Content;
            
            try
            {
                if ((quantity < (item.Col2Break * cofactor) && item.DiscountedPrice1 != 0) || item.DiscountedPrice2 == 0)
                {
                    return result = Decimal.Parse((item.DiscountedPrice1 / cofactor).ToString());
                }
                else if ((quantity < (item.Col3Break * cofactor) && item.DiscountedPrice2 != 0) || item.DiscountedPrice3 == 0)
                {
                    if(item.DiscountedPrice2 == 0) { return result = Decimal.Parse((item.DiscountedPrice1 / cofactor).ToString()); }
                    return result = Decimal.Parse((item.DiscountedPrice2 / cofactor).ToString());
                }
                else if ((quantity < (item.Col4Break * cofactor) && item.DiscountedPrice3 != 0) || item.DiscountedPrice4 == 0)
                {
                    if (item.DiscountedPrice3 == 0) { return result = Decimal.Parse((item.DiscountedPrice2 / cofactor).ToString()); }
                    return result = Decimal.Parse((item.DiscountedPrice3 / cofactor).ToString());
                }
                else if ((quantity < (item.Col5Break * cofactor) && item.DiscountedPrice4 != 0) || item.DiscountedPrice5 == 0)
                {
                    if (item.DiscountedPrice4 == 0) { return result = Decimal.Parse((item.DiscountedPrice3 / cofactor).ToString()); }
                    return result = Decimal.Parse((item.DiscountedPrice4 / cofactor).ToString());
                }
                else if (item.DiscountedPrice4 != 0) { return result = Decimal.Parse((item.DiscountedPrice5 / cofactor).ToString()); }else { return result = Decimal.Parse((item.DiscountedPrice1 / cofactor).ToString()); }
            }
            catch { }
            return 0;// fiyatının olmadığı gösteriyor
            #endregion
        }
        public static decimal GetLandingCost(string ArticleNo, bool Product, bool Weight, bool CustomsDuties, int quantity)
        {
            #region Calculating LandingCost

            IMEEntities IME = new IMEEntities();
            var item = IME.CompleteItems.Where(x => x.Article_No == ArticleNo).FirstOrDefault();
            //var _slidingPrice = IME.prc_GetSlidingPriceWithArticleNumber(ArticleNo).FirstOrDefault();
            //var _extendedRange = IME.prc_GetExtendedRangeWithArticleNumber(ArticleNo).FirstOrDefault();
            decimal p = 0;
            if (item != null)
            {
                p = GetCost(ArticleNo, quantity);
            }
            //else if(_extendedRange!=null)
            //{
            //    p= GetCost(ArticleNo, quantity);
            //}
            decimal w = 0;
            //var _superDisk = IME.prc_GetSuperDiskItemWithArticleNumber(ArticleNo).FirstOrDefault();
            //var _superDiskP = IME.prc_GetSuperDiskPItemWithArticleNumber(ArticleNo).FirstOrDefault();
            
            if (item != null)
            {
                w = Decimal.Parse(item.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            //else if (_superDiskP != null)
            //{
            //    w = Decimal.Parse(_superDiskP.Standard_Weight.ToString());
            //    w = (w / (decimal)1000);
            //}
            //else if (_extendedRange != null)
            //{
            //    try
            //    {
            //        w = Decimal.Parse(_extendedRange.ExtendedRangeWeight.ToString());
            //        w = (w / (decimal)1000);
            //    }
            //    catch { }
            //}
            //var item = IME.CompleteItems.Where(x => x.Article_No == ArticleNo).FirstOrDefault();


            decimal? sWeight = 0;
            decimal? gWeight = 0;

            //if (item.Pack_Quantity > 1 && item.Unit_Content > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / (item.Pack_Quantity * item.Unit_Content);
            //    gWeight = ((((item.Length * item.Heigh * item.Width * 1000000) / 6000)) / (item.Pack_Quantity * item.Unit_Content));

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}else if (item.Pack_Quantity > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / item.Pack_Quantity;
            //    gWeight = (((item.Length * item.Heigh * item.Width * 1000000) / 6000) / item.Pack_Quantity);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}
            //else if(item.Unit_Content > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / item.Unit_Content;
            //    gWeight = (((item.Length * item.Heigh * item.Width * 1000000) / 6000) / item.Unit_Content);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}
            //else/*item.Pack_Quantity > 1 && item.Unit_Content > 1*/
            //{
            //    sWeight = item.Standard_Weight / 1000;
            //    gWeight = ((item.Length * item.Heigh * item.Width * 1000000) / 6000);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}

            sWeight = item.Standard_Weight / 1000 / (item.Pack_Quantity * item.Unit_Content);
            gWeight = ((((item.Length * item.Heigh * item.Width * 1000000) / 6000)) / (item.Pack_Quantity * item.Unit_Content));

            w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);

            decimal l = 0;
            if (Product == false) { p = 0; }
            if (Weight == false) { w = 0; }
            l = (p + (w * ((decimal)1.7)) + (((decimal)0.0675) * (p + (w * ((decimal)1.7)))));
            if (CustomsDuties == false) { l = (p + (w * ((decimal)1.7))); }

            return Math.Round(l,3);
            #endregion
        }
        public static decimal GetLandingCost(string ArticleNo, bool Product, bool Weight, bool CustomsDuties)
        {
            #region Calculating LandingCost
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            ExtendedRange er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            var item = IME.CompleteItems.Where(x => x.Article_No == ArticleNo).FirstOrDefault();
            decimal p = 0;
            if (sp != null)
            {
                p = Decimal.Parse(item.DiscountedPrice1.ToString());
            }
            else
            {
                p= Decimal.Parse(item.DiscountedPrice1.ToString());

            }
            decimal w = 0;
            //var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            //var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            
            if (item != null)
            {
                w = Decimal.Parse(item.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            //else if (sdP != null)
            //{
            //    w = Decimal.Parse(item.Standard_Weight.ToString());
            //    w = (w / (decimal)1000);
            //}
            //else if (er != null)
            //{
            //    try
            //    {
            //        w = Decimal.Parse(item.ExtendedRangeWeight.ToString());
            //        w = (w / (decimal)1000);
            //    }
            //    catch { }
            //}

            //var item = IME.CompleteItems.Where(x => x.Article_No == ArticleNo).FirstOrDefault();


            decimal? sWeight = 0;
            decimal? gWeight = 0;

            //if (item.Pack_Quantity > 1 && item.Unit_Content > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / (item.Pack_Quantity * item.Unit_Content);
            //    gWeight = ((((item.Length * item.Heigh * item.Width * 1000000) / 6000)) / (item.Pack_Quantity * item.Unit_Content));

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}
            //else if (item.Pack_Quantity > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / item.Pack_Quantity;
            //    gWeight = (((item.Length * item.Heigh * item.Width * 1000000) / 6000) / item.Pack_Quantity);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}
            //else if (item.Unit_Content > 1)
            //{
            //    sWeight = item.Standard_Weight / 1000 / item.Unit_Content;
            //    gWeight = (((item.Length * item.Heigh * item.Width * 1000000) / 6000) / item.Unit_Content);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}
            //else/*item.Pack_Quantity > 1 && item.Unit_Content > 1*/
            //{
            //    sWeight = item.Standard_Weight / 1000;
            //    gWeight = ((item.Length * item.Heigh * item.Width * 1000000) / 6000);

            //    w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);
            //}

            sWeight = (item.Standard_Weight / 1000) / (item.Pack_Quantity * item.Unit_Content);
            gWeight = (((item.Length * item.Heigh * item.Width) * 1000000) / 6000);

            w = (decimal)((sWeight > gWeight) ? sWeight : gWeight);


            decimal l = 0;
            if (Product == false) { p = 0; }
            if (Weight == false) { w = 0; }
            l = (p + (w * ((decimal)1.7)) + (((decimal)0.0675) * (p + (w * ((decimal)1.7)))));
            if (CustomsDuties == false) {l = (p + (w * ((decimal)1.7))); }
            
            return l;
            #endregion
        }
        public static decimal GetPrice(string ArticleNo, int quantity)
        {
            #region GetPrice
            if (quantity == 0) { return -1; }
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            ExtendedRange er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal result=-1;
            try
            {
                //FOR TURKEY
                #region
                //if (quantity < sp.Col2Break && sp.DiscountedPrice1 != 0)
                //{
                //    return result = Decimal.Parse(sp.Col1Price.ToString());
                //}
                //else if (quantity < sp.Col3Break && sp.DiscountedPrice2 != 0)
                //{
                //    return result = Decimal.Parse(sp.Col2Price.ToString());
                //}
                //else if (quantity < sp.Col4Break && sp.DiscountedPrice3 != 0)
                //{
                //    return result = Decimal.Parse(sp.Col3Price.ToString());
                //}
                //else if (quantity < sp.Col5Break && sp.DiscountedPrice4 != 0)
                //{
                //    return result = Decimal.Parse(sp.Col4Price.ToString());
                //}
                //else if (sp.DiscountedPrice4 != 0) { return result = Decimal.Parse(sp.Col5Price.ToString()); }
                #endregion
                if (sp!=null)
                {
                    result = Decimal.Parse(sp.Col1Price.ToString());
                }else if (er!=null)
                {
                    result = Decimal.Parse(er.Col1Price.ToString());
                }
                return result; // FOR DUBAI
            }
            catch { }
            if(er!=null)return result= Decimal.Parse(er.Col1Price.ToString()); // FOR DUBAI
            return -1;// fiyatının olmadığı gösteriyor
            #endregion
        }
        public static int HasMultipleItems(string ArticleNo)
        {
            IMEEntities IME = new IMEEntities();
            if (IME.SuperDisks.Where(a => a.Article_No.Contains(ArticleNo)).ToList().Count > 1 || IME.SuperDiskPs.Where(b => b.Article_No.Contains(ArticleNo)).ToList().Count > 1 || IME.ExtendedRanges.Where(c => c.ArticleNo.Contains(ArticleNo)).ToList().Count > 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalculateLandingCost(decimal P, decimal W)
        {
            DataSet.Management m = Utils.getManagement();
            decimal L = 0;
            decimal F = (decimal)m.FreightCharge;
            decimal C = (decimal)m.CustomsRate / (decimal)100;

            L = (P + (W * F)) + (C * (P + (W * F)));

            return Decimal.Parse(L.ToString("0.000"));
        }
        
        public decimal CalculateMargin(decimal Price, decimal Cost)
        {
            decimal M = (1 - (Cost / Price)) * 100;
            return Decimal.Parse(M.ToString("0.0000"));
        }
    }
}
