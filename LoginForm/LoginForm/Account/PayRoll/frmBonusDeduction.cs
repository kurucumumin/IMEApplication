using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using LoginForm.DataSet;
using LoginForm.Services;

namespace LoginForm
{

    public partial class frmBonusDeduction : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        decimal decBonusId;
        decimal decEmployeeIdForEdit = 0;
        DateTime dtMonth;
        int inNarrationCount = 0;
        #endregion

        #region Functions
        public frmBonusDeduction()
        {
            InitializeComponent();
        }
        public void EmployeeCodeComboFill()
        {
                cmbEmployeeCode.DataSource = IME.Workers.ToList();
                cmbEmployeeCode.ValueMember = "WorkerID";
                cmbEmployeeCode.DisplayMember = "NameLastName";
        }
        public void SaveFunction()
        {
            DateTime dt = Convert.ToDateTime(dtpMonth.Text.ToString());
            int worker = Convert.ToInt32(cmbEmployeeCode.SelectedValue.ToString());
            if (IME.BonusDeductions.Where(a=>a.month== dt).Where(b=>b.WorkerID== worker).FirstOrDefault()==null)
            {
                BonusDeduction d = new BonusDeduction();
                d.date = Convert.ToDateTime(dtpDate.Text.ToString());
                d.WorkerID = (int)worker;
                d.month = Convert.ToDateTime(dtpMonth.Text.ToString());
                d.bonusAmount = Convert.ToDecimal(txtBonusAmount.Text.ToString());
                d.deductionAmount = Convert.ToDecimal(txtDeductionAmount.Text.ToString());
                d.narration = txtNarration.Text;
                IME.BonusDeductions.Add(d);
                IME.SaveChanges();
                MessageBox.Show("Saved successfully");
                Clear();
            }
            else
            {
                MessageBox.Show(" Employee bonus deduction already exist");
                cmbEmployeeCode.Focus();
            }
        }
      
        public void EditFunction()
        {
                BonusDeduction b = IME.BonusDeductions.Where(a => a.bonusDeductionId == decBonusId).FirstOrDefault();

                if (b!=null)
                {
                    b.date = Convert.ToDateTime(dtpDate.Text.ToString());
                    b.WorkerID = Convert.ToInt32(cmbEmployeeCode.SelectedValue.ToString());
                    b.month = Convert.ToDateTime(dtpMonth.Text.ToString());
                    b.bonusAmount = Convert.ToDecimal(txtBonusAmount.Text.ToString());
                    b.deductionAmount = Convert.ToDecimal(txtDeductionAmount.Text.ToString());
                    b.narration = txtNarration.Text;
                    IME.SaveChanges();
                }

                MessageBox.Show("Update successfully");
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                dtpDate.Focus();
        }
       
        public void SaveOrEdit()
        {
                if (cmbEmployeeCode.SelectedIndex == -1)
                {
                   MessageBox.Show("Select employee code");
                    cmbEmployeeCode.Focus();
                }
                else if (txtBonusAmount.Text.Trim()!="" && Convert.ToDecimal(txtBonusAmount.Text.Trim()) == 0 && Convert.ToDecimal(txtDeductionAmount.Text.Trim())==0)
                {

                    MessageBox.Show("Enter bonus/deduction Amount");
                    txtBonusAmount.Focus();
                }
              
                else
                {
                    if (btnSave.Text == "Save")
                    {
                            SaveFunction();
                    }
                    else
                    {
                            EditFunction();
                    }
                }
            
        }

        public void LoadFunction()
        {
                EmployeeCodeComboFill();
                dtpDate.Value = Convert.ToDateTime(IME.CurrentDate().First());
                dtpMonth.Format = DateTimePickerFormat.Custom;
                dtpMonth.CustomFormat = "MMMM/yyyy";
                dtpDate.MinDate = Convert.ToDateTime(IME.CurrentDate().First()).AddYears(-1);
                dtpDate.MaxDate = Convert.ToDateTime(IME.CurrentDate().First()).AddMonths(2);
                txtDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
                cmbEmployeeCode.SelectedIndex = -1;
                txtBonusAmount.Clear();
                txtDeductionAmount.Clear();
                txtNarration.Clear();
                txtDate.Focus();
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                dtpMonth.Enabled = true;
                cmbEmployeeCode.Enabled = true;
        }
        /// <summary>
        /// Function to Call LoadFunction
        /// </summary>
        public void Clear()
        {

                LoadFunction();
        }

        public void Deletefunction()
        {
            try
            {
                IME.BonusDeductions.Remove(IME.BonusDeductions.Where(a => a.bonusDeductionId == decBonusId).FirstOrDefault());
            }
            catch
            {

                MessageBox.Show("Can't delete,reference exist");
            }
        }

        public void Delete()
        {
                        Deletefunction();
        }

        #endregion

        #region Events

        private void frmBonusDeduction_Load(object sender, EventArgs e)
        {
            try
            {

                LoadFunction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                    SaveOrEdit();
        }

        private void frmBonusDeduction_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    if (cmbEmployeeCode.Focused)
                    {
                        cmbEmployeeCode.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                    else
                    {
                        cmbEmployeeCode.DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                    btnSave_Click(sender, e);
                }
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
                MessageBox.Show("BD12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                    Delete();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtDate.Text = this.dtpDate.Value.ToString("dd-MMM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
                    txtDate.Text = Convert.ToDateTime(IME.CurrentDate().First()).ToString("dd-MMM-yyyy");
        }

        private void txtDeductionAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
                DecimalValidation(sender, e, false);
        }

        private void txtBonusAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
                DecimalValidation(sender, e, false);
        }

        private void txtDeductionAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDeductionAmount.Text.Trim() == string.Empty)
                {
                    txtDeductionAmount.Text = "0";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("BD20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBonusAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBonusAmount.Text.Trim() == string.Empty)
                {
                    txtBonusAmount.Text = "0";
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("BD20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Navigation
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
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
                MessageBox.Show("BD21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("BD22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        txtDeductionAmount.Focus();
                        txtDeductionAmount.SelectionStart = 0;
                        txtDeductionAmount.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbEmployeeCode.Enabled)
                    {
                        cmbEmployeeCode.Focus();
                    }
                    else
                    {
                        txtBonusAmount.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpMonth.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbEmployeeCode.Text == string.Empty || cmbEmployeeCode.SelectionStart == 0)
                    {
                        txtDate.SelectionStart = 0;
                        txtDate.SelectionLength = 0;
                        txtDate.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpMonth_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBonusAmount.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbEmployeeCode.Focus();
                    cmbEmployeeCode.SelectionStart = 0;
                    cmbEmployeeCode.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBonusAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDeductionAmount.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtBonusAmount.Text == string.Empty || txtBonusAmount.SelectionStart == 0)
                    {
                        if (dtpMonth.Enabled)
                        {
                            dtpMonth.Focus();
                        }
                        else if (cmbEmployeeCode.Enabled)
                        {
                            cmbEmployeeCode.SelectionStart = 0;
                            cmbEmployeeCode.SelectionLength = 0;
                            cmbEmployeeCode.Focus();
                        }
                        else
                        {
                            txtDate.SelectionStart = 0;
                            txtDate.SelectionLength = 0;
                            txtDate.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD27:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeductionAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDeductionAmount.Text == string.Empty || txtDeductionAmount.SelectionStart == 0)
                    {
                        txtBonusAmount.SelectionStart = 0;
                        txtBonusAmount.SelectionLength = 0;
                        txtBonusAmount.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("BD28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        ///Backspace navigation
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
                MessageBox.Show("BD29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        private void DecimalValidation(object sender, KeyPressEventArgs e, bool isNegativeFiled)
        {
                TextBox txt = (TextBox)sender;
                if (!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
                if (e.KeyChar == 46)
                {
                    if (txt.Text.Contains(".") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if (txt.Text == "" || txt.SelectionStart == 0)
                        {
                            txt.Clear();
                            txt.Text = "0.";
                            txt.SelectionStart = txt.Text.Length;
                        }
                        else
                        {
                            txt.Text = txt.Text + ".";
                            txt.SelectionStart = txt.Text.Length;
                        }
                    }
                }
                else if (e.KeyChar == 45 && (isNegativeFiled))
                {
                    if (txt.Text.Contains("-") && txt.SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        txt.Clear();
                        txt.Text = "-";
                        txt.SelectionStart = txt.Text.Length;
                    }
                }
            
        }


    }
}
