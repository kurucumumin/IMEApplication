using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.Quotation
{
    public partial class FormQuotationItemSearch : Form
    {
        IMEEntities IME = new IMEEntities();
        string ArticleCode;

        public FormQuotationItemSearch()
        {
            InitializeComponent();
        }
        public FormQuotationItemSearch(string ItemCode)
        {
            ArticleCode = ItemCode;
            InitializeComponent();
        }

        private void FormQuotationItemSearch_Load(object sender, EventArgs e)
        {

        }

        private void txtQuotationItemCode_TextChanged(object sender, EventArgs e)
        {
            #region List Birleştirme
            string txtSelected = txtQuotationItemCode.Text;
            var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_No.Contains(txtSelected))
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
            var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(txtSelected))
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
            var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(txtSelected))
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
            //
            #endregion
            dgQuotationItemSearch.DataSource = gridAdapterPC;
            if (gridAdapterPC.Count == 0)
            {
                MessageBox.Show("There is no such a data");
            }
        }
    }
}
