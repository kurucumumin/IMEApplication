using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationItemSearch : MyForm
    {
        IMEEntities IME = new IMEEntities();
        string ArticleCode;
        public string[] itemProps = new string[2];
        List<CompleteItem> itemList;
        public string ItemCode; 


        public FormQuotationItemSearch(string searchItemCode, List<CompleteItem> itemList)
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgQuotationItemSearch, new object[] { true });

            dgQuotationItemSearch.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            txtQuotationItemCode.Text = searchItemCode;
            this.itemList = itemList;
        }

        public FormQuotationItemSearch(string ItemCode)
        {
            QuotationUtils.ItemCode = null;
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
          System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
          dgQuotationItemSearch, new object[] { true });

            dgQuotationItemSearch.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            ArticleCode = ItemCode;
            if (ArticleCode != null)
            {
                txtQuotationItemCode.Text = ArticleCode;
                dgQuotationItemSearch.Select();
            }
            var gridAdapterPC = IME.ArticleSearch(txtQuotationItemCode.Text).ToList();

            dgQuotationItemSearch.DataSource = gridAdapterPC;
            if (gridAdapterPC.Count() == 0)
            {
                MessageBox.Show("There is no such a data");
            }
        }
        

        private void itemsearch()
        {
            string QuotationNote = null;
            string QuotationMPN = null;
            string QuotationArticleDesc = null;
            string QuotationItemCode = null;

            if (txtQuotationNote.Text != "") QuotationNote = txtQuotationNote.Text;
            if (txtQuotationMPN.Text != "") QuotationMPN = txtQuotationMPN.Text;
            if (txtQuotationArticleDesc.Text != "") QuotationArticleDesc = txtQuotationArticleDesc.Text;
            if (txtQuotationItemCode.Text != "") QuotationItemCode = txtQuotationItemCode.Text;

            var gridAdapterPC = IME.ArticleSearchWithAll(QuotationItemCode, QuotationArticleDesc, QuotationMPN, QuotationNote).ToList();

            dgQuotationItemSearch.DataSource = gridAdapterPC;
            if (gridAdapterPC.Count() == 0)
            {
                //MessageBox.Show("There is no such a data");
                MessageBox.Show("Product not found!");
            }
        }

        private void dgQuotationItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChooseItem();
              
            }
        }

        private void dgQuotationItemSearch_DoubleClick(object sender, EventArgs e)
        {
            ChooseItem();
           
        }

        private void ChooseItem()
        {
            if (dgQuotationItemSearch.DataSource != null)
            {
                if (dgQuotationItemSearch.CurrentRow.Cells[1].Value.ToString() != "")
                {
                    QuotationUtils.ItemCode = dgQuotationItemSearch.CurrentRow.Cells["Article_No"].Value.ToString();
                    ItemCode = dgQuotationItemSearch.CurrentRow.Cells["Article_No"].Value.ToString();
                    itemProps[0] = dgQuotationItemSearch.CurrentRow.Cells["Article_No"].Value.ToString();
                    itemProps[1] = dgQuotationItemSearch.CurrentRow.Cells["Article_Desc"].Value.ToString();
                    this.DialogResult = DialogResult.OK;

                    //var MPNItemList = IME.ArticleSearchwithMPN(dgQuotationItemSearch.CurrentRow.Cells[7].Value.ToString()).ToList();
                    string mpn = dgQuotationItemSearch.CurrentRow.Cells["MPN"].Value.ToString();
                    var MPNItemList = IME.CompleteItems.Where(x => x.MPN == mpn).ToList();
                    if (MPNItemList.Count > 1)
                    {
                        FormQuotationMPN form = new FormQuotationMPN(this, MPNItemList);
                        form.ShowDialog();
                    }
                }
            }
            //classQuotationAdd.ItemCode = dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells["Article_No"].Value.ToString();
            this.Close();
        }

        private void txtQuotationItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                itemsearch();
            }
        }

        private void FormQuotationItemSearch_Load(object sender, EventArgs e)
        {
            if(itemList != null)
            {

                dgQuotationItemSearch.DataSource = itemList.ToList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            itemsearch();
        }
    }
}
