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
    }
}
