using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.QuotationModule
{
    class QuotationHelper
    {
        public static dynamic BringItems(string code, bool isMPN)
        {
            IMEEntities IME = new IMEEntities();

            dynamic gridAdapterPC = new object();
            dynamic list2 = new object();
            dynamic list3 = new object();

            switch (isMPN)
            {
                case false:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_No.Contains(code))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(code))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(code))
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
                case true:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.MPN == code)
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         a.MPN,
                                         customerworker.Note.Note_name,
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN == code)
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 a.MPN,
                                 customerworker.Note.Note_name,
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN == code)
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 a.MPN,
                                 customerworker.Note.Note_name
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
            }

            return gridAdapterPC;
        }
    }
}
