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
using LoginForm.Services;

namespace LoginForm.QuotationModule
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
            InitializeComponent();
            ArticleCode = ItemCode;
            txtQuotationItemCode.Text = ArticleCode;
            
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

        private void dgQuotationItemSearch_DoubleClick(object sender, EventArgs e)
        {
            if (dgQuotationItemSearch.DataSource != null)
            {
              classQuotationAdd.ItemCode  =  dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }this.Close();
        }

        private void dgQuotationItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (dgQuotationItemSearch.DataSource != null)
                {
                    classQuotationAdd.ItemCode = dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells[0].Value.ToString();
                }
                this.Close();
            }
        }

        private void txtQuotationArticleDesc_TextChanged(object sender, EventArgs e)
        {
            #region List Birleştirme
            string txtSelected = txtQuotationArticleDesc.Text;
            var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_Desc.Contains(txtSelected))
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
            var list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_Desc.Contains(txtSelected))
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
            var list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleDescription.Contains(txtSelected))
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

        private void txtQuotationMPN_TextChanged(object sender, EventArgs e)
        {
            #region List Birleştirme
            string txtSelected = txtQuotationMPN.Text;
            var gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.MPN.Contains(txtSelected))
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
            var list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN.Contains(txtSelected))
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
            var list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN.Contains(txtSelected))
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

        private void txtQuotationNote_TextChanged(object sender, EventArgs e)
        {
            #region List Birleştirme
            string txtSelected = txtQuotationNote.Text;
            var gridAdapterPC = (from a in IME.ItemNotes.Where(a => a.ArticleNo.Contains(txtSelected))
                                 join sp in IME.SuperDisks on a.ArticleNo equals sp.Article_No
                                 select new
                                 {
                                     ArticleNo = a.ArticleNo,
                                     ArticleDesc = sp.Article_Desc,
                                     sp.MPN,
                                     a.Note.Note_name,
                                 }
                              ).ToList();
            var list2 = (from a in IME.ItemNotes.Where(a => a.ArticleNo.Contains(txtSelected))
                         join sp in IME.SuperDiskPs on a.ArticleNo equals sp.Article_No
                         select new
                         {
                             ArticleNo = a.ArticleNo,
                             ArticleDesc = sp.Article_Desc,
                             sp.MPN,
                             a.Note.Note_name,
                         }
                        ).ToList();
            var list3 = (from a in IME.ItemNotes.Where(a => a.ArticleNo.Contains(txtSelected))
                         join sp in IME.ExtendedRanges on a.ArticleNo equals sp.ArticleNo
                         select new
                         {
                             ArticleNo = a.ArticleNo,
                             ArticleDesc = sp.ArticleNo,
                             sp.MPN,
                             a.Note.Note_name,
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
