using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using LoginForm.Services;
using LoginForm.Account.Services;
using LoginForm.Account;

namespace LoginForm
{
    public partial class frmBudgetVariance : Form
    {
        #region VARIABLES
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        #endregion
        #region FUNCTIONS
        /// <summary>
        /// Creates an instance of frmbudgetvariance class
        /// </summary>
        public frmBudgetVariance()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function to fill datagridview
        /// </summary>
        public void GridFill()
        {
                
                DataTable dtbl = new DataTable();
                BudgetMasterSP spbudgetmaster = new BudgetMasterSP();
                dgvBudgetVariance.Rows.Clear();
                
                decimal decId;
            if (cmbBudget.SelectedValue.ToString()!="Select")
            {
                decId = Convert.ToDecimal(cmbBudget.SelectedValue.ToString());
                dtbl = spbudgetmaster.BudgetVariance(decId);
            }                
                
                decimal decrindx = dgvBudgetVariance.Rows.Count;
                int index = 0;
            if (dtbl != null)
            {
                foreach (DataRow rw in dtbl.Rows)
                {
                    dgvBudgetVariance.Rows.Add();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtSlNo"].Value = rw[0].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtParticulars"].Value = rw["Particular"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtBudgetDr"].Value = rw["BudgetDr"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtActualDr"].Value = rw["ActualDr"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtVarianceDr"].Value = rw["VarianceDr"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtBudgetCr"].Value = rw["BudgetCr"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtActualCr"].Value = rw["ActualCr"].ToString();
                    dgvBudgetVariance.Rows[index].Cells["dgvtxtVarianceCr"].Value = rw["VarianceCr"].ToString();
                    index++;
                }
            }
        }
        /// <summary>
        /// function to fill budget combo
        /// </summary>
        public void BudgetComboFill()
        {
            try
            {
                BudgetMasterSP spBudgetMaster = new BudgetMasterSP();
                DataTable dtbl = new DataTable();
                dtbl = spBudgetMaster.BudgetViewAll();
                //DataRow drow = dtbl.NewRow();
                //drow[0] = 0;
                //drow[1] = "Select";
                //drow[2] = 0;
                //drow[3] = 0;
                //dtbl.Rows.InsertAt(drow, 0);
                cmbBudget.ValueMember = "budgetMasterId";
                cmbBudget.DisplayMember = "budgetName";
                
                cmbBudget.DataSource = dtbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("BV:02" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// function to convert datagridview data to a datatable
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable dtbl = new DataTable();
            try
            {
                dtbl.Columns.Add("SlNo");
                dtbl.Columns.Add("Particulars");
                dtbl.Columns.Add("BudgetDr");
                dtbl.Columns.Add("ActualDr");
                dtbl.Columns.Add("VarianceDr");
                dtbl.Columns.Add("BudgetCr");
                dtbl.Columns.Add("ActualCr");
                dtbl.Columns.Add("VarianceCr");
                DataRow drow = null;
                foreach (DataGridViewRow dr in dgvBudgetVariance.Rows)
                {
                    drow = dtbl.NewRow();
                    drow["SlNo"] = dr.Cells["dgvtxtSlNo"].Value;
                    drow["Particulars"] = dr.Cells["dgvtxtParticulars"].Value;
                    drow["BudgetDr"] = dr.Cells["dgvtxtBudgetDr"].Value;
                    drow["ActualDr"] = dr.Cells["dgvtxtActualDr"].Value;
                    drow["VarianceDr"] = dr.Cells["dgvtxtVarianceDr"].Value;
                    drow["BudgetCr"] = dr.Cells["dgvtxtBudgetCr"].Value;
                    drow["ActualCr"] = dr.Cells["dgvtxtActualCr"].Value;
                    drow["VarianceCr"] = dr.Cells["dgvtxtVarianceCr"].Value;
                    dtbl.Rows.Add(drow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BV:03" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dtbl;
        }
        /// <summary>
        /// Function to create datasets
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet getdataset()
        {
            FinancialStatementSP spfinancial = new FinancialStatementSP();
            System.Data.DataSet dsBudget = new System.Data.DataSet();
            try
            {
                DataTable dtblbudget = GetDataTable();
                DataTable dtblCompany = new DataTable();
                dtblCompany = spfinancial.FundFlowReportPrintCompany(1);
                dsBudget.Tables.Add(dtblbudget);
                dsBudget.Tables.Add(dtblCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show("BV:04" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dsBudget;
        }
        /// <summary>
        /// function to print the data
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public void Print(DateTime fromDate, DateTime toDate)
        {
            //try
            //{
            //    DataSet dsBudget = getdataset();
            //    frmReport frmReport = new frmReport();
            //    frmReport.MdiParent = formMDI.MDIObj;
            //    frmReport.Budget(dsBudget);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("BV:05" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        #endregion
        #region EVENTS
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBudgetVariance_Load(object sender, EventArgs e)
        {
                           BudgetComboFill();
                GridFill();
           
        }
        /// <summary>
        /// Function to fill datagridview on 'Budget' combo selected index change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                GridFill();
            
        }
        /// <summary>
        /// On 'print' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvBudgetVariance.Rows.Count > 0)
                {
                    Print(Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate),Convert.ToDateTime(Utils.getManagement().FinancialYear.toDate));
                }
                else
                {
                    MessageBox.Show("No data found", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BV:08" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// On form keypress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBudgetVariance_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 27)
                {
                    //if (PublicVariables.isMessageClose)
                    //{
                        Messages.CloseMessage(this);
                    //}
                    //else
                    //{
                        this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BV:09" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
