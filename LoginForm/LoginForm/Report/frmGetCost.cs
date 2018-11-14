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
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class frmGetCost : DevExpress.XtraEditors.XtraForm
    {
        IMEEntities IME = new IMEEntities();
        int gridselectedindex = 0;
        decimal defaultCurrencyRate = 0;
        string txtSelected = "";
        public frmGetCost()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgItemList, new object[] { true });

            string currencySymbol = Utils.getManagement().Currency.currencySymbol;
            defaultCurrencyRate = (decimal)Utils.getManagement().Currency.ExchangeRates.OrderByDescending(a => a.date).FirstOrDefault().rate;
            dgItemList.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;
            label65.Text = "WEB (" + currencySymbol + ")";
            textBox1.Text = Utils.GetCurrentDateTime().Date.ToString();
        }

        private void ArticleNoSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridselectedindex = 0;
                itemSelect();
                dgItemList.Select();
            }
        }

        private void itemSelect()
        {
            #region itemssearch
            txtSelected = ArticleNoSearch.Text;
            string ArticleSearch = "";
            #region Itemcode Format
            if (txtSelected.ToString().Contains("-")) { txtSelected = txtSelected.ToString().Replace("-", string.Empty).ToString(); }
            if (txtSelected != null && txtSelected.ToString().Length == 6 || (txtSelected.ToString().Contains("P") && txtSelected.ToString().Length == 7)) { txtSelected = 0.ToString() + txtSelected.ToString(); }
            //0100-124 => 0100124
            #endregion

            //List Birleştirme
            #region List Birleştirme
            if (rbProductCode.Checked == true)
            {
                var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleNo.Contains(txtSelected))
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN,
                                         a.UnitMeasure,
                                         a.UnitContent,
                                         a.PackQuantity
                                     }
                         ).ToList();

                #endregion
                dgItemList.DataSource = gridAdapterPC;
                for (int i = 0; i < dgItemList.ColumnCount; i++)
                {
                    dgItemList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (gridAdapterPC.Count != 0)
                {
                    ArticleSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
            }
            else if (rbProductName.Checked == true)
            {
                //List Birleştirme
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.Items.Where(a => a.ArticleDesc.Contains(txtSelected))
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN,
                                         a.UnitMeasure,
                                         a.UnitContent,
                                         a.PackQuantity
                                     }
                             ).ToList();
                
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                dgItemList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (gridAdapterPC.Count != 0)
                {
                    ArticleSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
            }
            else if (rbMPNCode.Checked == true)
            {
                #region List Birleştirme
                var gridAdapterPC = (from a in IME.Items.Where(a => a.MPN.Contains(txtSelected))
                                     select new
                                     {
                                         ArticleNo = a.ArticleNo,
                                         ArticleDesc = a.ArticleDesc,
                                         a.MPN,
                                         a.UnitMeasure,
                                         a.UnitContent,
                                         a.PackQuantity
                                     }
                             ).ToList();
               
                #endregion
                dgItemList.DataSource = gridAdapterPC;
                dgItemList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (gridAdapterPC.Count != 0)
                {
                    ArticleSearch = gridAdapterPC[gridselectedindex].ArticleNo;
                }
                else
                {
                    MessageBox.Show("There is no such a data");
                }
            }
            #endregion


            if (dgItemList.RowCount > 0)
            {
                dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                Filler(ArticleSearch);
                Utils.LogKayit("Item Card Main", "Item Card Main search");
            }
        }

        private void Filler(string ArticleNoSearch)
        {
            #region Filler
            //Seçili olan item ı text lere yazdıran fonksiyon yazılacak
            var sd = IME.SuperDisks.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            var sdP = IME.SuperDiskPs.Where(a => a.Article_No == ArticleNoSearch).FirstOrDefault();
            var er = IME.ExtendedRanges.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var os = IME.OnSales.Where(a => a.ArticleNumber == ArticleNoSearch).FirstOrDefault();
            var sp = IME.SlidingPrices.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var dd = IME.DailyDiscontinueds.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var h = IME.Hazardous.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var du = IME.DualUses.Where(a => a.ArticleNo == ArticleNoSearch).FirstOrDefault();
            var i = IME.tbl_Item.Where(a => a.StockNo == ArticleNoSearch).FirstOrDefault();
            var rsf = IME.RsFileHistories.Where(a => a.FileType == "OnSale").OrderByDescending(x => x.Date).FirstOrDefault();


            int coefficient = (int)IME.CompleteItems.Where(x => x.Article_No == ArticleNoSearch).FirstOrDefault().Unit_Content;


            if (sd != null)
            {
                if (sd.Unit_Measure != null && sd.Unit_Measure != "")
                { }
                else
                {
                    dgItemList.Rows[gridselectedindex].Cells[3].Value = "Each";
                }
            }

            if (sdP != null)
            {
                
                if (sdP.Unit_Measure != null && sdP.Unit_Measure != "")
                {}
                else
                {
                    dgItemList.Rows[gridselectedindex].Cells[3].Value = "Each";
                }
            }
            if (er != null)
            {                
                txtUK1.Text = (er.Col1Price / coefficient).ToString();
                txtUK2.Text = (er.Col2Price / coefficient).ToString();
                txtUK3.Text = (er.Col3Price / coefficient).ToString();
                txtUK4.Text = (er.Col4Price / coefficient).ToString();
                txtUK5.Text = (er.Col5Price / coefficient).ToString();
                txtUnitCount1.Text = (er.Col1Break * coefficient).ToString();
                txtUnitCount2.Text = (er.Col2Break * coefficient).ToString();
                txtUnitCount3.Text = (er.Col3Break * coefficient).ToString();
                txtUnitCount4.Text = (er.Col4Break * coefficient).ToString();
                txtUnitCount5.Text = (er.Col5Break * coefficient).ToString();
                txtCost1.Text = (er.DiscountedPrice1 / coefficient).ToString();
                txtCost2.Text = (er.DiscountedPrice2 / coefficient).ToString();
                txtCost3.Text = (er.DiscountedPrice3 / coefficient).ToString();
                txtCost4.Text = (er.DiscountedPrice4 / coefficient).ToString();
                txtCost5.Text = (er.DiscountedPrice5 / coefficient).ToString();
                WebandMarginPrices();
            }
            if (sp != null)
            {
                txtUnitCount1.Text = (sp.Col1Break * coefficient).ToString();
                txtUnitCount2.Text = (sp.Col2Break * coefficient).ToString();
                txtUnitCount3.Text = (sp.Col3Break * coefficient).ToString();
                txtUnitCount4.Text = (sp.Col4Break * coefficient).ToString();
                txtUnitCount5.Text = (sp.Col5Break * coefficient).ToString();
                txtUK1.Text = (sp.Col1Price / coefficient).ToString();
                txtUK2.Text = (sp.Col2Price / coefficient).ToString();
                txtUK3.Text = (sp.Col3Price / coefficient).ToString();
                txtUK4.Text = (sp.Col4Price / coefficient).ToString();
                txtUK5.Text = (sp.Col5Price / coefficient).ToString();

                txtCost1.Text = (sp.DiscountedPrice1 / coefficient).ToString();
                txtCost2.Text = (sp.DiscountedPrice2 / coefficient).ToString();
                txtCost3.Text = (sp.DiscountedPrice3 / coefficient).ToString();
                txtCost4.Text = (sp.DiscountedPrice4 / coefficient).ToString();
                txtCost5.Text = (sp.DiscountedPrice5 / coefficient).ToString();
                WebandMarginPrices();
            }
            if (os != null)
            {
                txtRSStock.Text = os.OnhandStockBalance.ToString();
                textBox14.Text = rsf.Date.ToString();
                txtRSOnOrder.Text = os.QuantityonOrder.ToString();
            }
            if (i != null)
            {
                
                if (i.Col1Break != null && i.Col1Break.ToString() != "") { txtUnitCount1.Text = i.Col1Break.ToString(); }
                if (i.Col2Break != null && i.Col2Break.ToString() != "") { txtUnitCount2.Text = i.Col2Break.ToString(); }
                if (i.Col3Break != null && i.Col3Break.ToString() != "") { txtUnitCount3.Text = i.Col3Break.ToString(); }
                if (i.Col4Break != null && i.Col4Break.ToString() != "") { txtUnitCount4.Text = i.Col4Break.ToString(); }
                if (i.Col5Break != null && i.Col5Break.ToString() != "") { txtUnitCount5.Text = i.Col5Break.ToString(); }
                if (i.DiscountedPrice1 != null && i.DiscountedPrice1.ToString() != "")
                {
                    txtCost1.Text = String.Format("{0:0}", Decimal.Parse(i.DiscountedPrice1.ToString())).ToString();
                    if (i.DiscountedPrice2 != null && i.DiscountedPrice2.ToString() != "") { txtCost2.Text = i.DiscountedPrice2.ToString(); }
                    if (i.DiscountedPrice3 != null && i.DiscountedPrice3.ToString() != "") { txtCost3.Text = i.DiscountedPrice3.ToString(); }
                    if (i.DiscountedPrice4 != null && i.DiscountedPrice4.ToString() != "") { txtCost4.Text = i.DiscountedPrice4.ToString(); }
                    if (i.DiscountedPrice5 != null && i.DiscountedPrice5.ToString() != "") { txtCost5.Text = i.DiscountedPrice5.ToString(); }
                }
            }
            #endregion
        }

        private void WebandMarginPrices()
        {
            decimal factor;
            factor = Utils.getManagement().Factor / defaultCurrencyRate;
            if (txtUK1.Text != "" && txtUK1.Text != null) txtWeb1.Text = (decimal.Parse(txtUK1.Text) * factor).ToString();
            if (txtUK2.Text != "" && txtUK2.Text != null) txtWeb2.Text = (decimal.Parse(txtUK2.Text) * factor).ToString();
            if (txtUK3.Text != "" && txtUK3.Text != null) txtWeb3.Text = (decimal.Parse(txtUK3.Text) * factor).ToString();
            if (txtUK4.Text != "" && txtUK4.Text != null) txtWeb4.Text = (decimal.Parse(txtUK4.Text) * factor).ToString();
            if (txtUK5.Text != "" && txtUK5.Text != null) txtWeb5.Text = (decimal.Parse(txtUK5.Text) * factor).ToString();
            txtMargin1.Text = ""; txtMargin2.Text = ""; txtMargin3.Text = ""; txtMargin4.Text = ""; txtMargin5.Text = "";
            if (txtCost1.Text != "" && txtCost1.Text != null && Int32.Parse(txtUnitCount1.Text) != 0) txtMargin1.Text = ((1 - (decimal.Parse(txtCost1.Text) / decimal.Parse(txtUK1.Text))) * 100).ToString();
            if (txtCost2.Text != "" && txtCost2.Text != null && Int32.Parse(txtUnitCount2.Text) != 0) txtMargin2.Text = ((1 - (decimal.Parse(txtCost2.Text) / decimal.Parse(txtUK2.Text))) * 100).ToString();
            if (txtCost3.Text != "" && txtCost3.Text != null && Int32.Parse(txtUnitCount3.Text) != 0) txtMargin3.Text = ((1 - (decimal.Parse(txtCost3.Text) / decimal.Parse(txtUK3.Text))) * 100).ToString();
            if (txtCost4.Text != "" && txtCost4.Text != null && Int32.Parse(txtUnitCount4.Text) != 0) txtMargin4.Text = ((1 - (decimal.Parse(txtCost4.Text) / decimal.Parse(txtUK4.Text))) * 100).ToString();
            if (txtCost5.Text != "" && txtCost5.Text != null && Int32.Parse(txtUnitCount5.Text) != 0) txtMargin5.Text = ((1 - (decimal.Parse(txtCost5.Text) / decimal.Parse(txtUK5.Text))) * 100).ToString();
        }

        private void dgItemList_Click(object sender, EventArgs e)
        {
            if (dgItemList.DataSource != null)
            {
                ClearAll(this);
                if (dgItemList.RowCount > 0)
                {
                    gridselectedindex = dgItemList.CurrentCell.RowIndex;
                }
                Filler(dgItemList.Rows[gridselectedindex].Cells["ArticleNo"].Value.ToString());
                if (dgItemList.RowCount > 0)
                {
                    dgItemList.ClearSelection();
                    dgItemList.CurrentCell = dgItemList.Rows[gridselectedindex].Cells[0];
                }
            }
        }

        private void ClearAll(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }
            }
        }

        private void rbProductCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbProductName_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }

        private void rbMPNCode_CheckedChanged(object sender, EventArgs e)
        {
            dgItemList.DataSource = null;
            ClearAll(this);
        }
    }
}