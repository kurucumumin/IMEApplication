using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using System.Data.SqlClient;
using LoginForm.Services;
using LoginForm.PurchaseOrder;

namespace LoginForm
{
    public partial class FormNewPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        int saleID;
        SqlDataAdapter adapter;
        DataTable dt;
        public FormNewPurchaseOrder()
        {
            SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void FormNewPurchaseOrder_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ImeSettings.ConnectionStringIME;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter(" select SaleOrderID,SaleDate,QuotationNos,SubTotal,TotalPrice,TotalMargin,SaleOrderNature from SaleOrder where PurchaseOrderID is null", con);
                dt = new DataTable();
                adapter.Fill(dt);
                gridControl1.DataSource = dt;
                con.Close();
            }
        }

        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            saleID = Int32.Parse(gridView1.GetFocusedRowCellValue("SaleOrderID").ToString());
            NewPurchaseOrder f = new NewPurchaseOrder(saleID);
            this.Close();
            f.ShowDialog();
            f.Dispose();
            Utils.LogKayit("New Purchase Order", "New Purchase Order menu send to purchase order");
        }
    }
}