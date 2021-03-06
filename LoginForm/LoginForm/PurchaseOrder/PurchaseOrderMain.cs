﻿using System;
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
using static LoginForm.Services.MyClasses.MyAuthority;

namespace LoginForm.PurchaseOrder
{
    public partial class PurchaseOrderMain : MyForm
    {
        IMEEntities IME = new IMEEntities();
        int purchaseId;

        public PurchaseOrderMain()
        {
            InitializeComponent();
            dgPurchase.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
        }

        public PurchaseOrderMain(int purchaseOrderId)
        {
            InitializeComponent();
            dgPurchase.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            purchaseId = purchaseOrderId;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormNewPurchaseOrder frm = new FormNewPurchaseOrder();
            this.Close();
            frm.ShowDialog();
            frm.Dispose();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            IME = new IMEEntities();

            #region Update Purchase Order Reason
            for (int i = 0; i < dgPurchase.RowCount - 1; i++)
            {
                DataGridViewRow row = dgPurchase.Rows[i];
                int ID =Convert.ToInt32(row.Cells[purchaseOrderId.Index].Value);
                if (row.Cells[FicheNo.Index].Value != null)
                {
                    var adapter = IME.PurchaseOrders.Where(a => a.purchaseOrderId == ID).FirstOrDefault();
                    adapter.purchaseOrderId = Convert.ToInt32(row.Cells[purchaseOrderId.Index].Value);
                    adapter.PurchaseNo= Convert.ToInt32(row.Cells[purchaseOrderId.Index].Value);
                    adapter.FicheNo = row.Cells[FicheNo.Index].Value.ToString();
                    adapter.PurchaseOrderDate = (DateTime)row.Cells[PurchaseOrderDate.Index].Value;
                    adapter.CustomerID = row.Cells[CustomerID.Index].Value.ToString();
                    adapter.Customer.c_name = row.Cells[c_name.Index].Value.ToString();
                    if (row.Cells[Reason.Index].Value == null || row.Cells[Reason.Index].Value.ToString() == "")
                    {
                        adapter.Reason = "";
                    }
                    else adapter.Reason = row.Cells[Reason.Index].Value.ToString();


                }
            }
            IME.SaveChanges();
            #endregion
            if (MessageBox.Show("Are You Sure ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
        private void ControlAutorization()
        {
            if (!Utils.AuthorityCheck(IMEAuthority.AddPurchaseOrder))
            {
                btnCreate.Visible = false;
            }
        }
        private void PurchaseOrderMain_Load(object sender, EventArgs e)
        {
            ControlAutorization();
            dateStarting.Value = Utils.GetCurrentDateTime();
            dateEnding.Value = Utils.GetCurrentDateTime().AddMonths(-3);
            PurchaseOrderFill(Utils.GetCurrentDateTime(), Utils.GetCurrentDateTime().AddMonths(-3));
        }

        private void PurchaseOrderFill(DateTime startDate, DateTime endDate)
        {
            IME = new IMEEntities();
            dgPurchase.Rows.Clear();
            #region PurchaseOrderFill
            var adapter = (from p in IME.PurchaseOrders
                           where p.PurchaseOrderDate >= endDate && p.PurchaseOrderDate <= startDate
                           select new
                           {
                               p.purchaseOrderId,
                               p.PurchaseNo,
                               p.FicheNo,
                               p.PurchaseOrderDate,
                               p.CustomerID,
                               p.Customer.c_name,
                               p.Reason
                           }).ToList();

            adapter = adapter.ToList().OrderByDescending(x => x.purchaseOrderId).ToList();
            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];


                row.Cells[purchaseOrderId.Index].Value = item.purchaseOrderId;
                row.Cells[PurchaseNo.Index].Value = item.PurchaseNo;
                row.Cells[PoNo.Index].Value = item.PurchaseNo + "/DXB/" + item.PurchaseOrderDate.Value.ToString("MMM") + "/" + item.PurchaseOrderDate.Value.    ToString("yy");
                row.Cells[FicheNo.Index].Value = item.FicheNo;
                row.Cells[PurchaseOrderDate.Index].Value = item.PurchaseOrderDate;
                row.Cells[CustomerID.Index].Value = item.CustomerID;
                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[Reason.Index].Value = item.Reason;

            }
            //dgPurchase.DataSource = null;
            //dgPurchase.DataSource = adapter;
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
                                           p.purchaseOrderId,
                                           p.PurchaseNo,
                                           p.FicheNo,
                                           p.PurchaseOrderDate,
                                           p.CustomerID,
                                           p.Customer.c_name,
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
                    dgPurchase.Columns[6].Visible = false;
                    dgPurchase.Columns[7].Visible = false;
                    #endregion
                    dgPurchase.DataSource = fichenolist.ToList();
                }
                else
                {
                    string sayac =search;
                 var fno = IME.PurchaseOrders.Where(b => b.purchaseOrderId == Convert.ToInt32(sayac)).FirstOrDefault();
                    if (fno != null)
                    {
                        var fichenolist = (from p in IME.PurchaseOrders.Where(p => p.purchaseOrderId == Convert.ToInt32(sayac))
                                           select new
                                           {
                                               p.purchaseOrderId,
                                               p.PurchaseNo,
                                               p.FicheNo,
                                               p.PurchaseOrderDate,
                                               p.CustomerID,
                                               p.Customer.c_name,
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
                        dgPurchase.Columns[6].Visible = false;
                        dgPurchase.Columns[7].Visible = false;
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
            dgPurchase.Rows.Clear();
            var adapter = (from po in IME.PurchaseOrders
                           //.Where(po => po.Invoice != null && po.Invoice == sayac)
                           select new
                           {
                               po.purchaseOrderId,
                               po.PurchaseNo,
                               po.FicheNo,
                               po.PurchaseOrderDate,
                               po.CustomerID,
                               po.Customer.c_name,
                               po.Reason
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgPurchase.Rows.Add();
                DataGridViewRow row = dgPurchase.Rows[rowIndex];

                row.Cells[purchaseOrderId.Index].Value = item.purchaseOrderId;
                row.Cells[PurchaseNo.Index].Value = item.PurchaseNo;
                row.Cells[PoNo.Index].Value = item.PurchaseNo + "/DXB/" + item.PurchaseOrderDate.Value.ToString("MMM") + "/" + item.PurchaseOrderDate.Value.ToString("yy");
                row.Cells[FicheNo.Index].Value = item.FicheNo;
                row.Cells[PurchaseOrderDate.Index].Value = item.PurchaseOrderDate;
                row.Cells[CustomerID.Index].Value = item.CustomerID;
                row.Cells[c_name.Index].Value = item.c_name;
                row.Cells[Reason.Index].Value = item.Reason;
            }
            //dgPurchase.DataSource = null;
            //dgPurchase.DataSource = adapter;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgPurchase.CurrentRow != null)
            {
                int PurchaseNo = Convert.ToInt32(dgPurchase.CurrentRow.Cells[0].Value);
                ExcelPurchaseOrder.Export(dgPurchase, PurchaseNo.ToString());
                Utils.LogKayit("Purchase Order", "Purchase Order excel");
            }
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

        private void dgPurchase_DoubleClick(object sender, EventArgs e)
        {
            #region ProductHistory
            int purchase_Id = 0;

            if (dgPurchase.CurrentRow.Cells["purchaseOrderId"].Value != null)
                purchase_Id = Convert.ToInt32(dgPurchase.CurrentRow.Cells["purchaseOrderId"].Value);
            if (dgPurchase.CurrentRow.Cells["purchaseOrderId"].Value == null)
                MessageBox.Show("Please Enter a purchaseOrderId", "Eror !");
            else
            {
                purchase_Id = Convert.ToInt32(dgPurchase.CurrentRow.Cells["purchaseOrderId"].Value);
                NewPurchaseOrder f = new NewPurchaseOrder(purchase_Id, 1);
                try { this.Hide(); f.ShowDialog(); this.Show(); } catch { }
            }
            #endregion
        }

        private void dgPurchase_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string note1 = "";
            if (dgPurchase.CurrentRow.Cells[Reason.Index].Value != null && dgPurchase.CurrentRow.Cells["Reason"].Value.ToString() != "")
            {
                note1 = dgPurchase.CurrentRow.Cells[Reason.Index].Value.ToString();
            }

            switch (dgPurchase.CurrentCell.ColumnIndex)
            {
                case 7:
                    if (dgPurchase.CurrentRow != null)
                    {
                        DialogResult result = MessageBox.Show("Note is added, please confirm", "PurchaseOrder Note", MessageBoxButtons.OKCancel);

                        if (result == DialogResult.OK)
                        {
                            try
                            {
                                IMEEntities IME = new IMEEntities();

                                foreach (DataGridViewRow row in dgPurchase.SelectedRows)
                                {
                                    int PurchaseOrderNo = Convert.ToInt32(row.Cells["purchaseOrderId"].Value);

                                   DataSet.PurchaseOrder quo = IME.PurchaseOrders.Where(q => q.purchaseOrderId == PurchaseOrderNo).FirstOrDefault();

                                    quo.Reason = note1;

                                    IME.SaveChanges();
                                }

                                IME.SaveChanges();

                              //  BringQuotationList();
                            }
                            catch (Exception)
                            {
                                dgPurchase.CurrentRow.Cells[Reason.Index].Value = "";
                                MessageBox.Show("Please press the enter key!", "Error!");
                            }
                        }
                    }

                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Utils.LogKayit("Purchase Order", "Purchase Order print");
        }
    }
}
