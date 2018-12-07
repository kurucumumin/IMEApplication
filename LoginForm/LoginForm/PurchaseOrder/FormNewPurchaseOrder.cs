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
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class FormNewPurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        int saleID;
        SqlDataAdapter adapter;
        DataTable dt;
        List<SaleOrderDetail> itemList = new List<SaleOrderDetail>();
        public FormNewPurchaseOrder()
        {
            SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void FormNewPurchaseOrder_Load(object sender, EventArgs e)
        {
            gridControl1.Rows.Clear();
            gridControl1.Refresh();

            IMEEntities IME = new IMEEntities();

            var list = (from sd in IME.SaleOrders
                        where sd.PurchaseOrderID == null
                        select new
                        {
                            SaleID = sd.SaleOrderID,
                            SaleDate = sd.SaleDate,
                            QuotationNo = sd.QuotationNos,
                            SubTotal = sd.SubTotal,
                            TotalPrice = sd.TotalPrice,
                            TotalMargin = sd.TotalMargin,
                            SaleOrderNature = sd.SaleOrderNature
                        }).OrderByDescending(s => s.SaleID);
            populateGrid(list.ToList());

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = ImeSettings.ConnectionStringIME;
            //con.Open();
            //if (con.State == ConnectionState.Open)
            //{
            //    adapter = new SqlDataAdapter(" select SaleOrderID,SaleDate,QuotationNos,SubTotal,TotalPrice,TotalMargin,SaleOrderNature from SaleOrder where PurchaseOrderID is null", con);
            //    dt = new DataTable();
            //    adapter.Fill(dt);
            //    gridControl1.DataSource = dt;
            //    con.Close();
            //}
        }

        private void populateGrid<T>(List<T> queryable)
        {
            //gridControl1.Rows.Clear();
            //gridControl1.Refresh();


            foreach (dynamic item in queryable)
            {
                int rowIndex = gridControl1.Rows.Add();
                DataGridViewRow row = gridControl1.Rows[rowIndex];


                row.Cells[SaleOrderID.Index].Value = item.SaleID;
                row.Cells[SaleDate.Index].Value = item.SaleDate;
                row.Cells[QuotationNos.Index].Value = item.QuotationNo;
                row.Cells[SubTotal.Index].Value = item.SubTotal;
                row.Cells[TotalPrice.Index].Value = item.TotalPrice;
                row.Cells[TotalMargin.Index].Value = item.TotalMargin;
                row.Cells[SaleOrderNature.Index].Value = item.SaleOrderNature;
            }
        }

            private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            List<SaleOrder> list = new List<SaleOrder>();
            IMEEntities IME = new IMEEntities();

            foreach (DataGridViewRow item in gridControl1.Rows)
            {
                if (item.Cells[0].Value != null && (bool)item.Cells[0].Value == true)
                {
                    decimal quotNo = Decimal.Parse(item.Cells[SaleOrderID.Index].Value.ToString());
                    SaleOrder quot = IME.SaleOrders.Where(q => q.SaleOrderID == quotNo).FirstOrDefault();
                    itemList.AddRange(quot.SaleOrderDetails);

                    SaleOrderDetail qd = itemList.Where(x => x.SaleOrderID == Convert.ToDecimal(item.Cells[SaleOrderID.Index].Value)).First();
                    list.Add(qd.SaleOrder);
                }
            }

            if (list.Count > 0)
            {

                //List<string> PurchaseNos = new List<string>();
                //for (int i = 0; i < list.Count; i++)
                //{
                //    if (PurchaseNos.Where(x => x == list[i].SaleOrderID.ToString()).FirstOrDefault() == null)
                //    {
                //        PurchaseNos.Add(list[i].SaleOrderID.ToString());
                //    }
                //}

                //string quotNo = dgItems.CurrentRow.Cells[QuotationNo.Index].Value.ToString();

                NewPurchaseOrder f = new NewPurchaseOrder(itemList,list);
                this.Close();
                f.ShowDialog();
                f.Dispose();
                Utils.LogKayit("New Purchase Order", "New Purchase Order menu send to purchase order");
            }
            else
            {
                MessageBox.Show("You have to choose at leaset one item", "Warning", MessageBoxButtons.OK);
            }




            //saleID = Int32.Parse(gridView1.GetFocusedRowCellValue("SaleOrderID").ToString());
            //NewPurchaseOrder f = new NewPurchaseOrder(saleID);
            //this.Close();
            //f.ShowDialog();
            //f.Dispose();
            //Utils.LogKayit("New Purchase Order", "New Purchase Order menu send to purchase order");
        }
        
    }
}