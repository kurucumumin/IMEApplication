using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm.BackOrder
{
    public partial class frmBackOrderMain : Form
    {
        public frmBackOrderMain()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBackOrderLoader form = new frmBackOrderLoader();
            form.Show();
        }

        private void btnbackOrderViewDetail_Click(object sender, EventArgs e)
        {
            if (dg.CurrentRow != null)
            {
                frmBackOrderDetailView form = new frmBackOrderDetailView(Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString()));
                form.Show();
            }
            else
            {
                MessageBox.Show("Please select a row");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateLoaderFunction();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmbackOrderAnalize form = new frmbackOrderAnalize(DateTime.Parse(dg.CurrentRow.Cells[Date.Index].Value.ToString()));
            form.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Close", "Are you sure to close this page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmBackOrderMain_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
            UpdateLoaderFunction();
        }

        #region Functions

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            VisibleAll();

                foreach (DataGridViewRow item in dg.Rows)
                {
                    for (int i = 0; i < item.Cells.Count; i++)
                    {
                        DataGridViewCell cell;
                        cell = item.Cells[i];
                        cell.Style.BackColor = Color.White;
                        if (cell.Value != null && cell.Value.ToString().Contains(txtSearch.Text))
                        {
                            cell.Style.BackColor = Color.Yellow;
                        }
                        //else
                        //{
                        //    try { item.Visible = false; } catch { }
                        //}
                    }
                }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dg.Rows)
            {
                for (int i = 0; i < item.Cells.Count; i++)
                {
                    DataGridViewCell cell;
                    cell = item.Cells[i];
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            int BackOrderMainID = Int32.Parse(dg.CurrentRow.Cells[ID.Index].Value.ToString());
            BackOrderMain bod = IME.BackOrderMains.Where(a => a.ID == BackOrderMainID).FirstOrDefault();
            txtItemDesc.Text = bod.description;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            QuotationExcelExport.ExportToItemHistory(dg);
        }

        private void btnAnalize_Click(object sender, EventArgs e)
        {
            frmbackOrderAnalize form = new frmbackOrderAnalize(DateTime.Parse(dg.CurrentRow.Cells[Date.Index].Value.ToString()));
            form.Show();
        }

        private void VisibleAll()
        {
            //foreach (DataGridViewRow item in dg.Rows)
            //{
            //    item.Visible = true;

            //}
        }
        private void    UpdateLoaderFunction()
        {
            dg.DataSource = null;

            IMEEntities IME = new IMEEntities();
            foreach (var item in IME.BackOrderMains.Where(a=>a.Date<=dtpEndDate.Value && a.Date>=dtpStartDate.Value))
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[ID.Index].Value = item.ID;
                row.Cells[Date.Index].Value = item.Date;
                row.Cells[Description.Index].Value = item.description;
                if(IME.Workers.Where(a => a.WorkerID == item.userID).FirstOrDefault()!=null)
                {
                    row.Cells[UserName.Index].Value = IME.Workers.Where(a => a.WorkerID == item.userID).FirstOrDefault().NameLastName;
                }
                dg.Rows.Add(row);
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            BackOrderProductSearch form = new BackOrderProductSearch();
            form.Show();
        }
    }
}
