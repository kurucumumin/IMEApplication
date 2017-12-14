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

namespace LoginForm.PurchaseOrder
{
    public partial class PurchaseOrderMain : Form
    {
        IMEEntities IME = new IMEEntities();
        string ficheNumber;

        public PurchaseOrderMain()
        {
            InitializeComponent();
        }

        public PurchaseOrderMain(string ficheNo)
        {
            InitializeComponent();
            ficheNumber = ficheNo;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            #region ProductHistory
            string fish_no = null;

            if (dgPurchase.CurrentRow.Cells["FicheNo"].Value != null)
                fish_no = dgPurchase.CurrentRow.Cells["FicheNo"].Value.ToString();
            if (fish_no == null)
                MessageBox.Show("Please Enter a Fiche No", "Eror !");
            else
            {

                NewPurchaseOrder f = new NewPurchaseOrder(fish_no, 1);
                try { this.Hide(); f.ShowDialog(); this.Show(); } catch { }
            }
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IME = new IMEEntities();

            #region Update Purchase Order Reason
            for (int i = 0; i < dgPurchase.RowCount - 1; i++)
            {
                DataGridViewRow row = dgPurchase.Rows[i];
                string ID = row.Cells[FicheNo.Index].Value.ToString();
                if (ID != null)
                {
                    var adapter = IME.PurchaseOrders.Where(a => a.FicheNo == ID).FirstOrDefault();
                    adapter.FicheNo = row.Cells[FicheNo.Index].Value.ToString();
                    adapter.PurchaseOrderDate = (DateTime)row.Cells[PurchaseOrderDate.Index].Value;
                    adapter.CustomerID = row.Cells[CustomerID.Index].Value.ToString();
                    adapter.Customer.c_name = row.Cells[c_name.Index].Value.ToString();
                    adapter.CameDate = (DateTime)row.Cells[CameDate.Index].Value;
                    if (row.Cells[Reason.Index].Value == null || row.Cells[Reason.Index].Value.ToString() == "")
                    {
                        adapter.Reason = "";
                    }
                    else adapter.Reason = row.Cells[Reason.Index].Value.ToString();


                }
            }
            IME.SaveChanges();
            #endregion
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Hide();
            }
        }

        private void PurchaseOrderMain_Load(object sender, EventArgs e)
        {
            PurchaseOrderFill(DateTime.Today, DateTime.Today.AddDays(-7));
        }

        private void PurchaseOrderFill(DateTime startDate, DateTime endDate)
        {
            IME = new IMEEntities();
            #region PurchaseOrderFill
            var adapter = (from p in IME.PurchaseOrders
                           where p.PurchaseOrderDate >= endDate && p.PurchaseOrderDate <= startDate
                           select new
                           {
                               p.FicheNo,
                               p.PurchaseOrderDate,
                               p.CustomerID,
                               p.Customer.c_name,
                               p.CameDate,
                               p.Reason
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                row.Cells[FicheNo.Index].Value = item.FicheNo;
                row.Cells[PurchaseOrderDate.Index].Value = item.PurchaseOrderDate;
                row.Cells[CustomerID.Index].Value = item.CustomerID;
                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[CameDate.Index].Value = item.CameDate;
                row.Cells[Reason.Index].Value = item.Reason;
            }
            #endregion
            //dgPurchase.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgPurchase.Columns[0].HeaderText = "Fiche No";
            //dgPurchase.Columns[1].HeaderText = "Date";
            //dgPurchase.Columns[2].HeaderText = "Customer Code";
            //dgPurchase.Columns[3].HeaderText = "Customer Title";
            //dgPurchase.Columns[4].HeaderText = "Came Date";
            //dgPurchase.Columns[5].HeaderText = "Reason";
            #region ReadOnly
            //dgPurchase.Columns["FicheNo"].ReadOnly = true;

            //dgPurchase.Columns["PurchaseOrderDate"].ReadOnly = true;

            //dgPurchase.Columns["CustomerID"].ReadOnly = true;

            //dgPurchase.Columns["c_name"].ReadOnly = true;

            //dgPurchase.Columns["CameDate"].ReadOnly = true;
            #endregion
        }

        private void btnPurchaseOrders_Click(object sender, EventArgs e)
        {
            PurchaseOrderFill(dateEnding.Value, dateStarting.Value);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPurchaseOrder(txtSearch.Text);
        }

        private void SearchPurchaseOrder(string search)
        {
            if (search != null)
            {
                PurchaseOrderDetail quotation;
                var saleorder = IME.PurchaseOrderDetails.Where(a => a.SaleOrderNo == search).FirstOrDefault();
                if (saleorder != null)
                {
                    var fichenolist = (from p in IME.PurchaseOrderDetails.Where(p => p.SaleOrderNo == search)
                                       join po in IME.PurchaseOrders on p.PurchaseOrder.FicheNo equals po.FicheNo
                                       select new
                                       {
                                           po.FicheNo,
                                           po.PurchaseOrderDate,
                                           po.CustomerID,
                                           po.Customer.c_name,
                                           po.CameDate,
                                           po.Reason
                                       }
                            ).ToList();
                    dgPurchase.DataSource = fichenolist;
                }
                else
                {
                    quotation = IME.PurchaseOrderDetails.Where(b => b.QuotationNo == search).FirstOrDefault();
                    if (quotation != null)
                    {
                        var fichenolist = (from p in IME.PurchaseOrderDetails.Where(p => p.QuotationNo == search)
                                           join po in IME.PurchaseOrders on p.PurchaseOrder.FicheNo equals po.FicheNo
                                           select new
                                           {
                                               po.FicheNo,
                                               po.PurchaseOrderDate,
                                               po.CustomerID,
                                               po.Customer.c_name,
                                               po.CameDate,
                                               po.Reason
                                           }
                             ).ToList();
                        dgPurchase.DataSource = fichenolist;
                    }
                    else
                    {
                        MessageBox.Show("There is no such data");
                    }
                }
            }
            else
                MessageBox.Show("There is no such a data");
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            PurchaseOrderFill(DateTime.Today, DateTime.Today.AddDays(-7));
        }

        private void radioNotSent_CheckedChanged(object sender, EventArgs e)
        {
            RadioPurchase(false);
        }

        private void radioSent_CheckedChanged(object sender, EventArgs e)
        {
            RadioPurchase(true);
        }

        private void RadioPurchase(bool sayac)
        {
            IME = new IMEEntities();
            var adapter = (from po in IME.PurchaseOrders.Where(po => po.Invoice != null && po.Invoice == sayac)
                           select new
                           {
                               po.FicheNo,
                               po.PurchaseOrderDate,
                               po.CustomerID,
                               po.Customer.c_name,
                               po.CameDate,
                               po.Reason
                           }).ToList();
            dgPurchase.DataSource = adapter;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string PurchaseNo = dgPurchase.CurrentRow.Cells[0].Value.ToString();
            ExcelPurchaseOrder.Export(dgPurchase, PurchaseNo);
        }
    }
}