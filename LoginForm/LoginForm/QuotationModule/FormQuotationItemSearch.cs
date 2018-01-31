using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            itemsearch();
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
                if (dgQuotationItemSearch.DataSource != null)
                {
                    classQuotationAdd.ItemCode = dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells["Article_No"].Value.ToString();
                    
                    var MPNItemList = IME.ArticleSearchwithMPN(dgQuotationItemSearch.CurrentRow.Cells["MPN"].Value.ToString()).ToList();
                    if (MPNItemList.Count > 1)
                    {
                        FormQuotationMPN form = new FormQuotationMPN(MPNItemList);
                        form.ShowDialog();
                    }
                }
                this.Close();
            }
        }

        private void dgQuotationItemSearch_DoubleClick(object sender, EventArgs e)
        {
                if (dgQuotationItemSearch.DataSource != null)
                {
                if (dgQuotationItemSearch.CurrentRow.Cells[2].Value.ToString()!="") {
                    classQuotationAdd.ItemCode = dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells["Article_No"].Value.ToString();

                    var MPNItemList = IME.ArticleSearchwithMPN(dgQuotationItemSearch.CurrentRow.Cells[2].Value.ToString()).ToList();
                    if (MPNItemList.Count > 1)
                    {
                        FormQuotationMPN form = new FormQuotationMPN(MPNItemList);
                        form.ShowDialog();
                    }
                }
                }
            classQuotationAdd.ItemCode = dgQuotationItemSearch.Rows[dgQuotationItemSearch.CurrentCell.RowIndex].Cells["Article_No"].Value.ToString();
            this.Close();
        }

        private void FormQuotationItemSearch_Load(object sender, EventArgs e)
        {

        }

        private void txtQuotationItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode==Keys.Tab)
            {
                itemsearch();
            }
        }
    }
}
