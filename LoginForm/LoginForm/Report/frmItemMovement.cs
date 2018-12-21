using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;
using ImeLogoLibrary;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class frmItemMovement : Form
    {
        IMEEntities IME = new IMEEntities();
        string txtSelected = "";
        LogoSQL logosql = new LogoSQL();
        string server = @"159.69.213.172";
        string logodatabase = "LOGO";
        string sqluser = "sa";
        string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";

        string hata = "Error";
        DataTable currencyList = new DataTable();
        public frmItemMovement()
        {
            InitializeComponent();

            dgItem.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;
            dgMovement.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgItem, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgMovement, new object[] { true });

            var gridAdapterPC = (from a in IME.Items
                                 select new
                                 {
                                     ArticleNo = a.ArticleNo,
                                     ArticleDesc = a.ArticleDesc
                                 }
                        ).Take(100).ToList();

            populateGridItem(gridAdapterPC.ToList());
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ReportQuotvsSale(dgMovement);
            Utils.LogKayit("ItemMovement Report", "Item Movement Report excel");
        }

        private void btnItemFind_Click(object sender, EventArgs e)
        {
            if (txtItem.Text == "")
            {
                MessageBox.Show("Please enter product code");
            }
            else
            {
                itemSelect();
                dgItem.Select();
            }
        }

        private void itemSelect()
        {
            #region itemssearch
            txtSelected = txtItem.Text;
            #region Itemcode Format
            if (txtSelected.ToString().Contains("-")) { txtSelected = txtSelected.ToString().Replace("-", string.Empty).ToString(); }
            if (txtSelected != null && txtSelected.ToString().Length == 6 || (txtSelected.ToString().Contains("P") && txtSelected.ToString().Length == 7)) { txtSelected = 0.ToString() + txtSelected.ToString(); }
            //0100-124 => 0100124
            #endregion

            var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleNo.Contains(txtSelected))
                                 select new
                                 {
                                     ArticleNo = a.ArticleNo,
                                     ArticleDesc = a.ArticleDesc
                                 }
                        ).ToList();

            #endregion

            populateGridItem(gridAdapterPC.ToList());

        }

        private void populateGridItem<T>(List<T> queryable)
        {   
            dgItem.Rows.Clear();
            dgItem.Refresh();
            foreach (dynamic item in queryable)
            {
                int rowIndex = dgItem.Rows.Add();
                DataGridViewRow row = dgItem.Rows[rowIndex];

                row.Cells[Code.Index].Value = item.ArticleNo;
                row.Cells[ArticleName.Index].Value = item.ArticleDesc;

            }

            if (dgItem.RowCount == 0)
            {
                MessageBox.Show("There is no such a data");
            }
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItem.Text == "")
                {
                    MessageBox.Show("Please enter product code");
                }
                else
                {
                    itemSelect();
                    dgItem.Select();
                }
            }
        }

        private void btnItemClear_Click(object sender, EventArgs e)
        {
            txtItem.Text = "";
        }

        private void btnMovementClear_Click(object sender, EventArgs e)
        {
            txtMovement.Text = "";
        }


        public DataTable getItem(string hata, SqlConnection LogoSQL, string article_no)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ITEMCODE", typeof(string));
            dt.Columns.Add("ITEMDESC", typeof(string));
            dt.Columns.Add("DATE", typeof(DateTime));
            dt.Columns.Add("DOCUMENT NO", typeof(int));
            dt.Columns.Add("DOCUMENT TYPE", typeof(string));
            dt.Columns.Add("IN/OUT", typeof(string));
            dt.Columns.Add("QTY", typeof(double));
            dt.Columns.Add("PRICE", typeof(double));
            dt.Columns.Add("TOTAL", typeof(double));
            dt.Columns.Add("CURR", typeof(string));



            hata = "";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = LogoSQL;
                cmd.CommandText = @"SELECT
     LGMAIN.DATE_, LGMAIN.FTIME, LGMAIN.LOGICALREF, LGMAIN.INVOICEREF, LGMAIN.STOCKREF, LGMAIN.LINETYPE, LGMAIN.TRCODE, LGMAIN.AMOUNT, LGMAIN.PRICE, LGMAIN.TOTAL, LGMAIN.INVOICELNNO,
      CASE
  WHEN LGMAIN.LINETYPE IN (4)   THEN SRVCARD.CODE
  WHEN LGMAIN.LINETYPE IN (2,3) THEN DECARDS.CODE
  WHEN LGMAIN.LINETYPE NOT IN (2,3,4)   THEN ITEM.CODE
   ELSE '' END AS CODE,
      CASE
  WHEN LGMAIN.LINETYPE IN (4)   THEN SRVCARD.DEFINITION_
  WHEN LGMAIN.LINETYPE IN (2,3) THEN DECARDS.DEFINITION_
  WHEN LGMAIN.LINETYPE NOT IN (2,3,4)   THEN ITEM.NAME
   ELSE '' END AS LINEEXP,
   CASE LGMAIN.TRCODE WHEN 1 THEN 'PURCHASE INVOICE' WHEN 8 THEN 'SALES INVOICE' END AS TYPE,
   CASE LGMAIN.TRCODE WHEN 1 THEN 'IN' WHEN 8 THEN 'OUT' END AS IO,
   CURR=''
FROM
     LG_002_01_STLINE LGMAIN WITH(NOLOCK)
  LEFT OUTER JOIN LG_002_ITEMS ITEM WITH(NOLOCK) ON LGMAIN.STOCKREF = ITEM.LOGICALREF
  LEFT OUTER JOIN LG_002_DECARDS DECARDS WITH(NOLOCK) ON LGMAIN.STOCKREF = DECARDS.LOGICALREF
  LEFT OUTER JOIN LG_002_SRVCARD SRVCARD WITH(NOLOCK) ON LGMAIN.STOCKREF = SRVCARD.LOGICALREF
where ITEM.CODE = '" + article_no + "'";

                SqlDataReader drCurr = cmd.ExecuteReader();

                while (drCurr.Read())

                {
                    DataRow dr = dt.NewRow();

                    dr["ITEMCODE"] = drCurr.GetString(11);
                    dr["ITEMDESC"] = drCurr.GetString(12);
                    dr["DATE"] = drCurr.GetDateTime(0);
                    dr["DOCUMENT NO"] = drCurr.GetInt32(1);
                    dr["DOCUMENT TYPE"] = drCurr.GetString(13);
                    dr["IN/OUT"] = drCurr.GetString(14);
                    dr["QTY"] = drCurr.GetDouble(7);
                    dr["PRICE"] = drCurr.GetDouble(8);
                    dr["TOTAL"] = drCurr.GetDouble(9);
                    //if (IME.SaleOrderDetails.Where(x => x.ItemCode == drCurr.GetString(11).ToString()).FirstOrDefault() != null)
                    //{

                    //}
                    //dr["CURR"] = drCurr.GetString(15);
                    dr["CURR"] = IME.SaleOrderDetails.Where(x => x.ItemCode == article_no).FirstOrDefault().SaleOrder.CurrName;

                    dt.Rows.Add(dr);
                }
            }
            catch (Exception ex) { hata = ex.ToString(); }
            finally { LogoSQL.Close(); }

            return dt;
        }

        private void dgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal In = 0;
            decimal Out = 0;
            decimal qty = 0;
            string Article_No = dgItem.CurrentRow.Cells[Code.Index].Value.ToString();

            currencyList = getItem(hata, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword), Article_No);
            dgMovement.DataSource = currencyList;

            for (int i = 0; i < dgMovement.RowCount; i++)
            {
                if (dgMovement.Rows[i].Cells["DOCUMENT TYPE"].Value.ToString() == "PURCHASE INVOICE")
                {
                    In = In + Decimal.Parse(dgMovement.Rows[i].Cells["TOTAL"].Value.ToString());
                }
                else if (dgMovement.Rows[i].Cells["DOCUMENT TYPE"].Value.ToString() == "SALES INVOICE")
                {
                    Out = Out + Decimal.Parse(dgMovement.Rows[i].Cells["TOTAL"].Value.ToString());
                }
                else
                {
                    qty = qty + Decimal.Parse(dgMovement.Rows[i].Cells["QTY"].Value.ToString());
                }
            }
            txtIN.Text = In.ToString();
            txtOUT.Text = Out.ToString();
            txtQty.Text = qty.ToString();
        }

        private void populateGridMovement<T>(List<T> queryable)
        {
            //int In = 0;
            //int Out = 0;
            //int qty = 0;
            //dgMovement.Rows.Clear();
            //dgMovement.Refresh();
            //foreach (dynamic item in queryable)
            //{
            //    int rowIndex = dgMovement.Rows.Add();
            //    DataGridViewRow row = dgMovement.Rows[rowIndex];

            //    row.Cells[Date.Index].Value = item.Date;
            //    row.Cells[FicheNo.Index].Value = item.FicheNo;
            //    row.Cells[CustomerName.Index].Value = item.Customer;
            //    row.Cells[Qty.Index].Value = item.Qty;
            //    row.Cells[InOut.Index].Value = item.InOut;
            //    if (item.InOut == "IN")
            //    {
            //        row.Cells[Type.Index].Value = "Purchase invoice";
            //    }
            //    else
            //    {
            //        row.Cells[Type.Index].Value = "Sales Invoice";
            //    }
            //    row.Cells[UnitOfMeasure.Index].Value = item.UOM;
            //    row.Cells[UKPrice.Index].Value = item.Price;
            //    row.Cells[Total.Index].Value = item.Total;
            //    row.Cells[Currency.Index].Value = item.Currency;
            //}

            //for (int i = 0; i < dgMovement.RowCount; i++)
            //{
            //    if (dgMovement.Rows[i].Cells[InOut.Index].Value.ToString() == "IN")
            //    {
            //        In = In + Int32.Parse(dgMovement.Rows[i].Cells[Qty.Index].Value.ToString());
            //    }
            //    else if (dgMovement.Rows[i].Cells[InOut.Index].Value.ToString() == "OUT")
            //    {
            //        Out = Out + Int32.Parse(dgMovement.Rows[i].Cells[Qty.Index].Value.ToString());
            //    }
            //    else
            //    {
            //        qty = qty + Int32.Parse(dgMovement.Rows[i].Cells[Qty.Index].Value.ToString());
            //    }
            //}
            //txtIN.Text = In.ToString();
            //txtOUT.Text = Out.ToString();
            //txtQty.Text = qty.ToString();
        }

        private void btnMovementItem_Click(object sender, EventArgs e)
        {
            MovementSelect(txtMovement.Text);
            dgMovement.Select();
        }

        private void txtMovement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MovementSelect(txtMovement.Text);
                dgMovement.Select();
            }
        }

        private void MovementSelect(string name)
        {
            string Article_No = dgItem.CurrentRow.Cells[Code.Index].Value.ToString();
            string cName= name.ToUpperInvariant();
            if (name != "")
            {
                var gridAdapterPC = (from a in IME.ItemMovement(Article_No)
                                     where a.c_name.Intersect(cName).Any()
                                     select new
                                     {
                                         Date = a.SaleDate,
                                         FicheNo = a.FicheNo,
                                         Customer = a.c_name,
                                         Qty = a.Quantity,
                                         InOut = a.InOut,
                                         Type = a.Type,
                                         UOM = a.UnitMeasure,
                                         Price = a.UKPrice,
                                         Total = a.SubTotal,
                                         Currency = a.CurrName
                                     }
                       ).ToList();

                populateGridMovement(gridAdapterPC.ToList());
            }
            else
            {
                var gridAdapterPC = (from a in IME.ItemMovement(Article_No)
                                     select new
                                     {
                                         Date = a.SaleDate,
                                         FicheNo = a.FicheNo,
                                         Customer = a.c_name,
                                         Qty = a.Quantity,
                                         InOut = a.InOut,
                                         Type = a.Type,
                                         UOM = a.UnitMeasure,
                                         Price = a.UKPrice,
                                         Total = a.SubTotal,
                                         Currency = a.CurrName
                                     }
                       ).ToList();

                populateGridMovement(gridAdapterPC.ToList());
            }
        }
    }
}
