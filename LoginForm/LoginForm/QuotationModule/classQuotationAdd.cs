using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginForm.QuotationModule
{

    class classQuotationAdd
    {
        public static string customersearchID;
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
                c = IME.Customers.Where(a => a.ID.Contains(customersearchID)).ToList().Where(a=>a.c_name!=null).Where(b=>b.c_name!=string.Empty).ToList();
            }
            else
            {
                c = IME.Customers.Where(a => a.c_name.Contains(customersearchname)).ToList().Where(a => a.c_name != null).Where(b => b.c_name != string.Empty).ToList();
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
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            ExtendedRange er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal result;
            try
            {
                if ((quantity < sp.Col2Break && sp.DiscountedPrice1 != 0)||(sp.Col2Break==0&& sp.DiscountedPrice1 != 0))
                {
                    return result = Decimal.Parse(sp.DiscountedPrice1.ToString());
                }
                else if (quantity < sp.Col3Break)
                {
                    if(sp.DiscountedPrice2 == 0) { return result = Decimal.Parse(sp.DiscountedPrice1.ToString()); }
                    return result = Decimal.Parse(sp.DiscountedPrice2.ToString());
                }
                else if (quantity < sp.Col4Break && sp.DiscountedPrice3 != 0)
                {
                    if (sp.DiscountedPrice3 == 0) { return result = Decimal.Parse(sp.DiscountedPrice2.ToString()); }
                    return result = Decimal.Parse(sp.DiscountedPrice3.ToString());
                }
                else if (quantity < sp.Col5Break && sp.DiscountedPrice4 != 0)
                {
                    if (sp.DiscountedPrice4 == 0) { return result = Decimal.Parse(sp.DiscountedPrice3.ToString()); }
                    return result = Decimal.Parse(sp.DiscountedPrice4.ToString());
                }
                else if (sp.DiscountedPrice4 != 0) { return result = Decimal.Parse(sp.DiscountedPrice5.ToString()); }else { return result = Decimal.Parse(sp.DiscountedPrice1.ToString()); }
            }
            catch { }
            try
            {
                if ((quantity < er.Col2Break && er.DiscountedPrice1 != 0)|| er.Col2Break==0 && er.DiscountedPrice1 != 0)
                {
                    return result = Decimal.Parse(er.DiscountedPrice1.ToString());
                }
                else if (quantity < er.Col3Break)
                {
                    if (er.DiscountedPrice2 == 0) { return result = Decimal.Parse(er.DiscountedPrice1.ToString()); }
                    return result = Decimal.Parse(er.DiscountedPrice2.ToString());
                }
                else if (quantity < er.Col4Break && er.DiscountedPrice3 != 0)
                {
                    if (er.DiscountedPrice3 == 0) { return result = Decimal.Parse(er.DiscountedPrice2.ToString()); }
                    return result = Decimal.Parse(er.DiscountedPrice3.ToString());
                }
                else if (quantity < sp.Col5Break && er.DiscountedPrice4 != 0)
                {
                    if (er.DiscountedPrice4 == 0) { return result = Decimal.Parse(er.DiscountedPrice3.ToString()); }
                    return result = Decimal.Parse(er.DiscountedPrice4.ToString());
                }
                else if (er.DiscountedPrice4 != 0) { return result = Decimal.Parse(er.DiscountedPrice5.ToString()); } else { return result = Decimal.Parse(er.DiscountedPrice1.ToString()); }
            }
            catch { }
            return 0;// fiyatının olmadığı gösteriyor
            #endregion
        }
        public static decimal GetLandingCost(string ArticleNo, bool Product, bool Weight, bool CustomsDuties, int quantity)
        {
            #region Calculating LandingCost
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal p = 0;
            if (sp != null)
            {
                p = GetCost(ArticleNo, quantity);
            }
            else if(er!=null)
            {
                p= GetCost(ArticleNo, quantity);
            }
            decimal w = 0;
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            
            if (sd != null)
            {
                w = Decimal.Parse(sd.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            else if (sdP != null)
            {
                w = Decimal.Parse(sdP.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            else if (er != null)
            {
                try
                {
                    w = Decimal.Parse(er.ExtendedRangeWeight.ToString());
                    w = (w / (decimal)1000);
                }
                catch { }
            }

            decimal l = 0;
            if (Product == false) { p = 0; }
            if (Weight == false) { w = 0; }
            l = (p + (w * ((decimal)1.7)) + (((decimal)0.0675) * (p + (w * ((decimal)1.7)))));
            if (CustomsDuties == false) { l = (p + (w * ((decimal)1.7))); }

            return l;
            #endregion
        }
        public static decimal GetLandingCost(string ArticleNo, bool Product, bool Weight, bool CustomsDuties)
        {
            #region Calculating LandingCost
            IMEEntities IME = new IMEEntities();
            SlidingPrice sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            ExtendedRange er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNo).FirstOrDefault();
            decimal p = 0;
            if (sp != null)
            {
                p = Decimal.Parse(sp.DiscountedPrice1.ToString());
            }
            else
            {
                p= Decimal.Parse(er.DiscountedPrice1.ToString());

            }
            decimal w = 0;
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNo).FirstOrDefault();
            
            if (sd != null)
            {
                w = Decimal.Parse(sd.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            else if (sdP != null)
            {
                w = Decimal.Parse(sdP.Standard_Weight.ToString());
                w = (w / (decimal)1000);
            }
            else if (er != null)
            {
                try
                {
                    w = Decimal.Parse(er.ExtendedRangeWeight.ToString());
                    w = (w / (decimal)1000);
                }
                catch { }
            }

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
            decimal result;
            try
            {
                //FOR TURKEY
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

                return result = Decimal.Parse(sp.Col1Price.ToString()); // FOR DUBAI
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
        
    }
}
