using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;
using LoginForm.Account.Services;

namespace LoginForm
{
    public partial class frmMonthlySalarySettings : Form
    {
        #region Public variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        decimal decMasterIdForEdit = 0;
        int inNarrationCount = 0;
        int inq = 0;
        #endregion

        #region Function
        /// <summary>
        /// Creates an instance of frmMonthlySalarySettings class
        /// </summary>
        public frmMonthlySalarySettings()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to Update the Datagridview row colors
        /// </summary>
        public void UpdateDataGridViewRowColors()
        {
            try
            {
                int inRowCount = dgvMonthySalarySettings.RowCount;
                for (int i = 0; i < inRowCount; i++)
                {
                    string str = dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString();
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString() != string.Empty)
                    {

                        dgvMonthySalarySettings.Rows[i].DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS1" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Package combobox in Datagridview
        /// </summary>
        public void SalaryPackageComboFill()
        {
            try
            {
                DataTable dtblSalaryPackage = new DataTable();
                SalaryPackageSP spSalaryPackage = new SalaryPackageSP();
                dtblSalaryPackage = spSalaryPackage.SalaryPackageViewAllForMonthlySalarySettings();
                DataRow dr = dtblSalaryPackage.NewRow();
                dr[0] = "0";
                dr[1] = "--Select--";
                dtblSalaryPackage.Rows.InsertAt(dr, 0);

                dgvcmbPackage.DataSource = dtblSalaryPackage;
                dgvcmbPackage.ValueMember = "salaryPackageId";
                dgvcmbPackage.DisplayMember = "salaryPackageName";

            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS2" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to Enable/Disable delete button
        /// </summary>
        public void DeleteButtonEnableDisableChoose()
        {
            try
            {
                MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                if (spMonthlySalary.MonthlySalarySettingsMonthlySalaryIdSearchUsingSalaryMonth(Convert.ToDateTime(dtpSalaryMonth.Text)) > 0)
                {
                    btnDelete.Enabled = true;
                    btnSave.Text = "Update";
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnSave.Text = "Save";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS3" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void GridFill()
        {
            try
            {
                DataTable dtblMonthlySalaryDetails = new DataTable();
                MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                MonthlySalary infoMonthlySalary = new MonthlySalary();
                MonthlySalaryDetailsSP spMonthlySalaryDetails = new MonthlySalaryDetailsSP();
                MonthlySalaryDetail infoMonthlySalaryDetailsInfo = new MonthlySalaryDetail();
                dtblMonthlySalaryDetails = spMonthlySalary.MonthlySalarySettingsEmployeeViewAll(Convert.ToDateTime(dtpSalaryMonth.Text));
                dgvMonthySalarySettings.DataSource = dtblMonthlySalaryDetails;
                int inRowCount = dgvMonthySalarySettings.RowCount;
                string strNarration = string.Empty;
                for (int i = 0; i < inRowCount; i++)
                {
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtnarration"].Value.ToString() != string.Empty)
                    {
                        strNarration = dgvMonthySalarySettings.Rows[i].Cells["dgvtxtnarration"].Value.ToString();

                    }
                }
                for (int i = 0; i < inRowCount; i++)
                {
                    //select default package for employee
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtdefaultPackageId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtdefaultPackageId"].Value.ToString() != "")
                    {
                        dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value = dgvMonthySalarySettings.Rows[i].Cells["dgvtxtdefaultPackageId"].Value;
                    }
                }
                txtNarration.Text = strNarration;

            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS4" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for Delete
        /// </summary>
        public void DeleteFunction()
        {
            try
            {
                MonthlySalaryDetailsSP spMonthlySalaryDetails = new MonthlySalaryDetailsSP();
                MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                string strMonth = dtpSalaryMonth.Text;
                spMonthlySalary.MonthlySalaryDeleteAll(spMonthlySalary.MonthlySalarySettingsMonthlySalaryIdSearchUsingSalaryMonth(Convert.ToDateTime(dtpSalaryMonth.Text)));
                Messages.DeletedMessage();
                SalaryPackageComboFill();
                GridFill();
                UpdateDataGridViewRowColors();
                DeleteButtonEnableDisableChoose();
                dtpSalaryMonth.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS5" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call delete
        /// </summary>
        public void Delete()
        {
            try
            {
                decimal decRowCount = 0;
                decRowCount = dgvMonthySalarySettings.Rows.Count;
                if (decRowCount >= 1)
                {
                   
                        if (Messages.DeleteMessage() == true)
                        {
                            DeleteFunction();
                        }
                }
                else
                {
                    MessageBox.Show("Can't Delete Monthly salary settings without atleast one employee with complete details", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS6" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for Save
        /// </summary>
        public void SaveFunction()
        {
            try
            {
                MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                MonthlySalary infoMonthlySalary = new MonthlySalary();
                MonthlySalaryDetailsSP spMonthlySalaryDetails = new MonthlySalaryDetailsSP();
                MonthlySalaryDetail infoMonthlySalaryDetails = new MonthlySalaryDetail();
                infoMonthlySalary.salaryMonth = Convert.ToDateTime(dtpSalaryMonth.Text);
                infoMonthlySalary.narration = txtNarration.Text.Trim();
                decMasterIdForEdit = spMonthlySalary.MonthlySalaryAddWithIdentity(infoMonthlySalary);
                infoMonthlySalaryDetails.monthlySalaryId = decMasterIdForEdit;
                int RowCount = dgvMonthySalarySettings.RowCount;
                for (int i = 0; i < RowCount; i++)
                {
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString() != string.Empty)
                    {
                        infoMonthlySalaryDetails.employeeId = Convert.ToInt32(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString());
                        if (dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString() != "0")
                        {
                            infoMonthlySalaryDetails.salaryPackageId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString());
                            infoMonthlySalaryDetails.monthlySalaryId = decMasterIdForEdit;
                            spMonthlySalaryDetails.MonthlySalaryDetailsAddWithMonthlySalaryId(infoMonthlySalaryDetails);
                        }
                    }
                }
                Messages.SavedMessage();
                GridFill();
                dtpSalaryMonth.Focus();
                btnDelete.Enabled = true;
                DeleteButtonEnableDisableChoose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS7" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for Edit
        /// </summary>
        public void EditFunction()
        {
            try
            {
                MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                MonthlySalary infoMonthlySalary = new MonthlySalary();
                MonthlySalaryDetailsSP spMonthlySalaryDetails = new MonthlySalaryDetailsSP();
                MonthlySalaryDetail infoMonthlySalaryDetails = new MonthlySalaryDetail();
                EmployeeSP spEmployee = new EmployeeSP();
                infoMonthlySalary.salaryMonth = Convert.ToDateTime(dtpSalaryMonth.Text);
                infoMonthlySalary.narration = txtNarration.Text.Trim();
                int RowCount = dgvMonthySalarySettings.RowCount;
                for (int i = 0; i <= RowCount - 1; i++)
                {
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryId"].Value.ToString() != string.Empty)
                    {
                        decMasterIdForEdit = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryId"].Value.ToString());
                    }
                }
                infoMonthlySalary.monthlySalaryId = decMasterIdForEdit;
                spMonthlySalary.MonthlySalarySettingsEdit(infoMonthlySalary);
                infoMonthlySalaryDetails.monthlySalaryId = decMasterIdForEdit;
                for (int i = 0; i <= RowCount - 1; i++)
                {
                    if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString() != string.Empty)
                    {
                        string st = dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].FormattedValue.ToString();
                        if (dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].FormattedValue.ToString() != "--Select--")
                        {
                            if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString() != string.Empty)
                            {
                                infoMonthlySalaryDetails.employeeId = Convert.ToInt32(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString());
                            }
                            if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString() != string.Empty)
                            {
                                infoMonthlySalaryDetails.monthlySalaryDetailsId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString());
                            }
                            if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryId"].Value.ToString() != "0")
                            {
                                infoMonthlySalaryDetails.monthlySalaryId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtMonthlySalaryId"].Value.ToString());
                            }
                            if (dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString() != "0")
                            {
                                infoMonthlySalaryDetails.salaryPackageId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString());
                                spEmployee.EmployeePackageEdit(Convert.ToInt32(infoMonthlySalaryDetails.employeeId), Convert.ToDecimal(infoMonthlySalaryDetails.salaryPackageId));
                                spMonthlySalaryDetails.MonthlySalaryDetailsEditUsingMasterIdAndDetailsId(infoMonthlySalaryDetails);
                            }
                        }
                        else
                        {
                            decimal decMonthlySalaryDetailsId = 0;
                            for (int j = 0; j < RowCount; j++)
                            {
                                if (dgvMonthySalarySettings.Rows[j].Cells["dgvtxtMonthlySalaryDetailsId"].Value != null && dgvMonthySalarySettings.Rows[j].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString() != string.Empty)
                                {
                                    if (dgvMonthySalarySettings.Rows[j].Cells["dgvcmbPackage"].FormattedValue.ToString() == "--Select--")
                                    {
                                        decMonthlySalaryDetailsId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[j].Cells["dgvtxtMonthlySalaryDetailsId"].Value.ToString());
                                        spMonthlySalaryDetails.MonthlySalarySettingsDetailsIdDelete(decMonthlySalaryDetailsId);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString() != string.Empty)
                        {
                            infoMonthlySalaryDetails.employeeId = Convert.ToInt32(dgvMonthySalarySettings.Rows[i].Cells["dgvtxtEmployeeId"].Value.ToString());

                            if (dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value != null && dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString() != "0")
                            {
                                infoMonthlySalaryDetails.salaryPackageId = Convert.ToDecimal(dgvMonthySalarySettings.Rows[i].Cells["dgvcmbPackage"].Value.ToString());
                                infoMonthlySalaryDetails.monthlySalaryId = decMasterIdForEdit;
                                spMonthlySalaryDetails.MonthlySalaryDetailsAddWithMonthlySalaryId(infoMonthlySalaryDetails);
                            }
                        }
                    }
                }
                Messages.UpdatedMessage();
                GridFill();
                dtpSalaryMonth.Focus();
                btnDelete.Enabled = true;
                DeleteButtonEnableDisableChoose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS8" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to call Save or Edit
        /// </summary>
        public void SaveOrEdit()
        {
            try
            {
                if (btnSave.Text == "Save")
                {
                    decimal decRowCount = 0;
                    decRowCount = dgvMonthySalarySettings.Rows.Count;
                    if (decRowCount >= 1)
                    {
                        
                            if (Messages.SaveMessage())
                            {
                                SaveFunction();
                            }
                    }
                    else
                    {
                        MessageBox.Show("Can't save Monthly salary settings without atleast one employee with complete details", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    decimal decRowCount = 0;
                    decRowCount = dgvMonthySalarySettings.Rows.Count;
                    if (decRowCount >= 1)
                    {
                        
                            if (Messages.UpdateMessage())
                            {
                                EditFunction();
                            }
                        
                    }
                    else
                    {
                        MessageBox.Show("Can't Update Monthly salary settings without atleast one employee with complete details", "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS9" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Messages.CloseMessage(this);
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS10" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'clear' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                dtpSalaryMonth.MinDate = Utils.getManagement().FinancialYear.fromDate.Value;
                dtpSalaryMonth.MaxDate = Utils.getManagement().FinancialYear.toDate.Value;
                dtpSalaryMonth.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpSalaryMonth.Text = dtpSalaryMonth.Value.ToString("MMM-yyyy");
                dtpSalaryMonth.Focus();
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS11" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Save' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveOrEdit();
                Messages.NoPrivillageMessage();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS12" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMonthlySalarySettings_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                SalaryPackageComboFill();
                GridFill();
                dtpSalaryMonth.Value = IME.CurrentDate().FirstOrDefault().Value;
                dtpSalaryMonth.Focus();
                DeleteButtonEnableDisableChoose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS13" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Delete' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnDelete.Text))
                //{
                    MonthlySalarySP spMonthlySalary = new MonthlySalarySP();
                    if (spMonthlySalary.MonthlySalarySettingsMonthlySalaryIdSearchUsingSalaryMonth(Convert.ToDateTime(dtpSalaryMonth.Text)) > 0)
                    {
                        Delete();
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                    }
                //}
                //else
                //{
                    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS14" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fills Datagridview on dtpSalaryMonth datetimepicker ValueChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSalaryMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SalaryPackageComboFill();
                GridFill();
                DeleteButtonEnableDisableChoose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS15" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Clears selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMonthySalarySettings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvMonthySalarySettings.ClearSelection();
                UpdateDataGridViewRowColors();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS16" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void dgvMonthySalarySettings_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

        #region Navigation
        /// <summary>
        /// Quick access on form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMonthlySalarySettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Messages.CloseMessage(this);
                    this.Close();
                
                }

                //-------------------CTRL+S Save---------------------------------//
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    btnSave_Click(sender, e);
                }


                //-----------------------CTRL+D Delete-----------------------------//
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control) //Delete
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS17" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        btnSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS18" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        dgvMonthySalarySettings.Focus();
                        dgvMonthySalarySettings.ClearSelection();
                        dgvMonthySalarySettings.CurrentCell = dgvMonthySalarySettings.Rows[dgvMonthySalarySettings.Rows.Count - 1].Cells["dgvcmbPackage"];
                        dgvMonthySalarySettings.Rows[dgvMonthySalarySettings.Rows.Count - 1].Cells["dgvcmbPackage"].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS19" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter or Tab key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Length;
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS20" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
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
                    dgvMonthySalarySettings.Focus();
                    dgvMonthySalarySettings.ClearSelection();
                    if (dgvMonthySalarySettings.Rows.Count > 0)
                    {
                        dgvMonthySalarySettings.CurrentCell = dgvMonthySalarySettings.Rows[0].Cells[6];
                        dgvMonthySalarySettings.Rows[0].Cells[6].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS21" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMonthySalarySettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvMonthySalarySettings.CurrentCell == dgvMonthySalarySettings[dgvMonthySalarySettings.Columns["dgvcmbPackage"].Index, dgvMonthySalarySettings.Rows.Count - 1])
                    {
                        if (inq == 1)
                        {
                            inq = 0;
                            txtNarration.Focus();
                            dgvMonthySalarySettings.ClearSelection();
                            e.Handled = true;
                        }
                        else
                        {
                            inq++;
                        }
                    }
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (dgvMonthySalarySettings.Rows.Count > 0)
                    {
                        if (dgvMonthySalarySettings.CurrentCell == dgvMonthySalarySettings[dgvMonthySalarySettings.Columns["dgvcmbPackage"].Index, 0])
                        {
                            dtpSalaryMonth.Focus();
                        }
                        else if (dgvMonthySalarySettings.CurrentCell == dgvMonthySalarySettings[dgvMonthySalarySettings.Columns["dgvtxtEmployee"].Index, 0])
                        {
                            dtpSalaryMonth.Focus();
                        }
                        else if (dgvMonthySalarySettings.CurrentCell == dgvMonthySalarySettings[dgvMonthySalarySettings.Columns["dgvtxtEmployeeCode"].Index, 0])
                        {
                            dtpSalaryMonth.Focus();
                        }
                        else
                        {
                            dgvMonthySalarySettings.CurrentCell = dgvMonthySalarySettings[dgvMonthySalarySettings.Columns["dgvcmbPackage"].Index, dgvMonthySalarySettings.CurrentRow.Index - 1];
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS22" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS23" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS24" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete.Focus();
                    }
                    else
                    {
                        btnClear.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS25" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Back space key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnClear.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MSS26" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


    }
}

