using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace LoginForm
{

    public partial class frmPaySlip : Form
    {
        #region Public Variables
        /// <summary>
        /// public varaible declaration part
        /// </summary>
        #endregion

        #region Functions

        /// <summary>
        /// creates an instance of frmPaySlip class
        /// </summary>
        public frmPaySlip()
        {
            InitializeComponent();
        }
       /// <summary>
       /// Function to fill Employee combobox
       /// </summary>
        public void FillEmployee()
        {
            try
            {
                DataTable dtbl = new DataTable();
                EmployeeSP spEmployee = new EmployeeSP();
                dtbl = spEmployee.EmployeeViewForPaySlip();
                DataRow dr = dtbl.NewRow();
                dr[1] = "--Select--";
                dtbl.Rows.InsertAt(dr, 0);
                cmbEmployee.DataSource = dtbl;
                cmbEmployee.ValueMember = "WorkerID";
                cmbEmployee.DisplayMember = "NameLastName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 1: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to close form
        /// </summary>
        public void FormClose()                                                 
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }

        }
        /// <summary>
        /// Function for print
        /// </summary>
        public void Print()
        {
            try
            {

                    if (cmbEmployee.Text == string.Empty || cmbEmployee.Text == "--Select--")
                    {
                        Messages.InformationMessage("Select an employee");
                        cmbEmployee.Focus();
                    }
                    else
                    {
                        SalaryVoucherMasterSP spSalaryVoucherMaster = new SalaryVoucherMasterSP();
                        DateTime dtMon = DateTime.Parse(dtpSalaryMonth.Text);
                        DateTime dtSalaryMonth = new DateTime(dtMon.Year, dtMon.Month, 1);
                        decimal decEmployeeId = Convert.ToDecimal(cmbEmployee.SelectedValue.ToString());
                        System.Data.DataSet dsPaySlip = spSalaryVoucherMaster.PaySlipPrinting(decEmployeeId, dtSalaryMonth, 1);
                       
                        foreach (DataTable dtbl in dsPaySlip.Tables)
                        {
                            if (dtbl.TableName == "Table1")
                            {
                                if (dtbl.Rows.Count > 0)
                                {
                                //TODO frm report oluşturulduktan sonra bakılacak
                                    //frmReport frmReport = new frmReport();
                                    ////frmReport.MdiParent = formMDI.MDIObj;
                                    //frmReport.PaySlipPrinting(dsPaySlip);
                                }
                                else
                                {
                                    MessageBox.Show("Salary not paid", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 3: " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Events
        /// <summary>
        /// On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                FormClose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 4 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaySlip_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            SalaryVoucherMasterSP spSalaryVoucherMaster = new SalaryVoucherMasterSP();
            spSalaryVoucherMaster.PaySlipPrinting(1, DateTime.Now, 1);
            try
            {

                FillEmployee();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 5 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Print' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 6 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Navigation
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSalaryMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbEmployee.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 7 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPrint.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    dtpSalaryMonth.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 8 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbEmployee.Focus();
                    cmbEmployee.SelectionStart = 0;
                    cmbEmployee.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 9 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 10 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Escape key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPaySlip_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    FormClose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 11 : " + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
