using LoginForm.Services;
using LoginForm.Services.SP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class ViewProductHistory : MyForm
    {
        SqlDataAdapter da;
        System.Data.DataSet ds=new System.Data.DataSet();
        string ItemCode;

        public ViewProductHistory()
        {
            InitializeComponent();
            dgProductHistory.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        }

        public ViewProductHistory(string item_code)
        {
            InitializeComponent();
            this.ItemCode = item_code;
            dgProductHistory.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        }

        private void ViewProductHistory_Load(object sender, EventArgs e)
        {
            ProductHistory();
        }

        public void ProductHistory()
        {
            dgProductHistory.DataSource = new Sp_Item().GetProductHistoryWithArticleNo(ItemCode);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
