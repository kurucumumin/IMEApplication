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
        int ficheNumber;

        public PurchaseOrderMain()
        {
            InitializeComponent();
        }

        public PurchaseOrderMain(int ficheNo)
        {
            InitializeComponent();
            ficheNumber = ficheNo;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            #region ProductHistory
            int fish_no =0;

            if (dgPurchase.CurrentRow.Cells["FicheNo"].Value != null)
                fish_no = (int)dgPurchase.CurrentRow.Cells["FicheNo"].Value;
            if (dgPurchase.CurrentRow.Cells["FicheNo"].Value == null)
                MessageBox.Show("Please Enter a Fiche No", "Eror !");
            else
            {
                fish_no = (int)dgPurchase.CurrentRow.Cells["FicheNo"].Value;
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
                int ID = (int)row.Cells[FicheNo.Index].Value;
                if (row.Cells[FicheNo.Index].Value != null)
                {
                    var adapter = IME.PurchaseOrders.Where(a => a.FicheNo == ID).FirstOrDefault();
                    adapter.FicheNo = (int)row.Cells[FicheNo.Index].Value;
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
                this.Close();
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
                
                var cname = IME.PurchaseOrders.Where(a => a.Customer.c_name == search).FirstOrDefault();
                if (cname != null)
                {
                    var fichenolist = (from p in IME.PurchaseOrders.Where(p => p.Customer.c_name == search)
                                       select new
                                       {
                                           p.FicheNo,
                                           p.PurchaseOrderDate,
                                           p.CustomerID,
                                           p.Customer.c_name,
                                           p.CameDate,
                                           p.Reason
                                       }
                            ).ToList();
                    #region Visible Columns
                    dgPurchase.Columns[0].Visible = false;
                    dgPurchase.Columns[1].Visible = false;
                    dgPurchase.Columns[2].Visible = false;
                    dgPurchase.Columns[3].Visible = false;
                    dgPurchase.Columns[4].Visible = false;
                    dgPurchase.Columns[5].Visible = false;
                    #endregion
                    dgPurchase.DataSource = fichenolist.ToList();
                }
                else
                {
                    int sayac = Convert.ToInt32(search);
                 var fno = IME.PurchaseOrders.Where(b => b.FicheNo == sayac).FirstOrDefault();
                    if (fno != null)
                    {
                        var fichenolist = (from p in IME.PurchaseOrders.Where(p => p.FicheNo == sayac)
                                           select new
                                           {
                                               p.FicheNo,
                                               p.PurchaseOrderDate,
                                               p.CustomerID,
                                               p.Customer.c_name,
                                               p.CameDate,
                                               p.Reason
                                           }
                             ).ToList();
                        #region Visible Columns
                        dgPurchase.Columns[0].Visible = false;
                        dgPurchase.Columns[1].Visible = false;
                        dgPurchase.Columns[2].Visible = false;
                        dgPurchase.Columns[3].Visible = false;
                        dgPurchase.Columns[4].Visible = false;
                        dgPurchase.Columns[5].Visible = false;
                        #endregion
                        dgPurchase.DataSource = fichenolist.ToList();
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

        private void dgPurchase_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message=="DataGridViewComboBox value is not valid.")
            {
                object value = dgPurchase.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgPurchase.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgPurchase.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}