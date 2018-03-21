using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.Account.Services;
using LoginForm.DataSet;
using LoginForm.Services;
namespace LoginForm
{
    public partial class frmAccountGroup : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        string strAccountGroupName;
        int inNarrationCount;
        decimal decAccountGroupId;
        frmAccountLedger frmAccountLedgerobj;
        decimal decIdForOtherForms = 0;
        decimal decAccountGroupIdForEdit;
        int inId;
        bool isDefault;
        #endregion
        #region Functions
        
        public frmAccountGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to fill master grid
        /// </summary>
        public void GridFill()
        {
            try
            {
                DataTable dtblAccountName = new DataTable();
                AccountGroupSP spAccountGroup = new AccountGroupSP();
                if (cmbGroupUnderSearch.Text.Trim() == string.Empty)
                {
                    cmbGroupUnderSearch.Text = "All";
                }
                dtblAccountName = spAccountGroup.AccountGroupSearch(txtAccountGroupNameSearch.Text.Trim(), cmbGroupUnderSearch.Text);
                dgvAccountGroup.DataSource = dtblAccountName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Function to fill account group combo
        /// </summary>
        public void GroupUnderComboFill()
        {
            try
            {
                AccountGroupSP spAccountGroup = new AccountGroupSP();
                DataTable dtblEmployeeCode = new DataTable();
                dtblEmployeeCode = spAccountGroup.AccountGroupViewAllComboFill();
                cmbGroupUnder.DataSource = dtblEmployeeCode;
                cmbGroupUnder.ValueMember = "accountGroupId";
                cmbGroupUnder.DisplayMember = "accountGroupName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG2:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill account group combo for Search
        /// </summary>
        public void GroupUnderSearchComboFill()
        {
                cmbGroupUnderSearch.DataSource = IME.AccountGroups.ToList();
            cmbGroupUnderSearch.ValueMember = "accountGroupId";
                cmbGroupUnderSearch.DisplayMember = "accountGroupName";
           
        }
        /// <summary>
        /// resetting the Account group page
        /// </summary>
        public void Clear()
        {
                txtAccountGroupName.Clear();
                cmbAffectGrossProfit.SelectedIndex = -1;
                cmbGroupUnderSearch.SelectedIndex = -1;
                txtAccountGroupNameSearch.Clear();
                cmbNature.SelectedIndex = -1;
                txtNarration.Clear();
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                txtAccountGroupName.Enabled = true;
                cmbAffectGrossProfit.Enabled = true;
                cmbGroupUnder.Enabled = true;
                cmbNature.Enabled = true;
                GridFill();
                txtAccountGroupName.Select();
                GroupUnderComboFill();
                cmbGroupUnder.SelectedIndex = -1;
                GroupUnderSearchComboFill();
        }
        /// <summary>
        /// Function to check existance of account group in DataBase
        /// </summary>
        /// <returns></returns>
        public bool CheckExistanceOfGroupName()
        {
            bool isExist = false;
            try
            {
                //Check whether a group name already exist in DB
                //AccountGroupSP spAccountGroup = new AccountGroupSP();
                //isExist = spAccountGroup.AccountGroupCheckExistence(txtAccountGroupName.Text.Trim(), 0);
                //if (isExist)
                //{
                //    if (txtAccountGroupName.Text.ToLower() == strAccountGroupName.ToLower())
                //    {
                //        isExist = false;
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isExist;
        }
        /// <summary>
        /// Function to save and edit account group
        /// </summary>
        public void Save()
        {

            //strAccountGroupName = btnSave.Text == "Save" ? string.Empty : strAccountGroupName;
            if (txtAccountGroupName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter account group name");
                txtAccountGroupName.Focus();
            }
            else if (cmbGroupUnder.SelectedIndex == -1)
            {
                MessageBox.Show("Select under");
                cmbGroupUnder.Focus();
            }
            else if (cmbNature.SelectedIndex == -1)
            {
                MessageBox.Show("Select nature");
                cmbNature.Focus();
            }
            else
            {
                AccountGroup ag = new AccountGroup();
                ag.accountGroupName = txtAccountGroupName.Text.Trim();
                ag.groupUnder = Int32.Parse(cmbGroupUnder.SelectedValue.ToString());
                ag.nature = cmbNature.SelectedItem.ToString();
                if (cmbAffectGrossProfit.SelectedIndex == -1)
                {
                    ag.affectGrossProfit = "No";
                }
                else
                {
                    ag.affectGrossProfit = cmbAffectGrossProfit.SelectedItem.ToString();
                }
                ag.narration = txtNarration.Text.Trim();
                IME.AccountGroups.Add(ag);
                IME.SaveChanges();
                GridFill();
            }
        }
        /// <summary>
        /// Function to delete account group
        /// </summary>
        public void Delete()
        {
            try
            {
                if (isDefault == true)
                {
                    Messages.InformationMessage("Can't delete build in account group");
                }
                //else if (PublicVariables.isMessageDelete)
                //{
                else if (Messages.DeleteConfirmation())
                {
                    //AccountGroup InfoAccountGroup = new AccountGroup();
                    AccountGroupSP spAccountGroup = new AccountGroupSP();
                    if ((spAccountGroup.AccountGroupReferenceDelete(decAccountGroupIdForEdit) == -1))
                    {
                        Messages.ReferenceExistsMessage();
                    }
                    else
                    {
                        Messages.DeletedMessage();
                        btnSave.Text = "Save";
                        btnDelete.Enabled = false;
                        Clear();
                    }
                }
                //}
                //else
                //{
                //    AccountGroupInfo InfoAccountGroup = new AccountGroupInfo();
                //    AccountGroupSP spAccountGroup = new AccountGroupSP();
                //    if ((spAccountGroup.AccountGroupReferenceDelete(decAccountGroupIdForEdit) == -1))
                //    {
                //        Messages.ReferenceExistsMessage();
                //    }
                //    else
                //    {
                //        Messages.DeletedMessage();
                //        btnSave.Text = "Save";
                //        btnDelete.Enabled = false;
                //        Clear();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        


        public void CallFromAccountLedger(frmAccountLedger frmAccountledger)
        {
            try
            {
                gbxAccountGroupSearch.Enabled = false;
                this.frmAccountLedgerobj = frmAccountledger;
                base.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events
        /// <summary>
        /// To close this form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrmClose_Click(object sender, EventArgs e)
        {
                btnClose_Click(sender, e);
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccountGroup_Load(object sender, EventArgs e)
        {         
                Clear();
        }
        /// <summary>
        /// To close this form on 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// Escape ,Save,Delete on Form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAccountGroup_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    if (cmbGroupUnder.Focused)
                    {
                        cmbGroupUnder.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                    else
                    {
                        cmbGroupUnder.DropDownStyle = ComboBoxStyle.DropDownList;
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


        private void btnClear_Click(object sender, EventArgs e)
        {   
                Clear();
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (CheckUserPrivilege.PrivilegeCheck(PublicVariables._decCurrentUserId, this.Name, btnSave.Text))
                //{
                    SaveOrEdit();
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (ControlID(txtAccountGroupName.Text))
            //{
            //    Edit();
            //}
            //else
            //{
            //    Save();
            //}

        }

        /// <summary>
        /// Function to save and edit account group
        /// </summary>
        public void SaveOrEdit()
        {
            try
            {
                strAccountGroupName = btnSave.Text == "Save" ? string.Empty : strAccountGroupName;
                if (CheckExistanceOfGroupName() == false)
                {
                    if (txtAccountGroupName.Text.Trim() == string.Empty)
                    {
                        Messages.InformationMessage("Enter account group name");
                        txtAccountGroupName.Focus();
                    }
                    else if (cmbGroupUnder.SelectedIndex == -1)
                    {
                        Messages.InformationMessage("Select under");
                        cmbGroupUnder.Focus();
                    }
                    else if (cmbNature.SelectedIndex == -1)
                    {
                        Messages.InformationMessage("Select nature");
                        cmbNature.Focus();
                    }else if (IME.AccountGroups.Where(a=>a.accountGroupName== txtAccountGroupName.Text.Trim())!=null)
                    {
                        MessageBox.Show("There is already exist a Group Name");
                    }
                    else
                    {
                        AccountGroup infoAccountGroup = new AccountGroup();
                        AccountGroupSP spAccountGroup = new AccountGroupSP();
                        infoAccountGroup.accountGroupName = txtAccountGroupName.Text.Trim();
                        infoAccountGroup.groupUnder = Convert.ToInt32(cmbGroupUnder.SelectedValue.ToString());
                        infoAccountGroup.nature = cmbNature.SelectedItem.ToString();
                        if (cmbAffectGrossProfit.SelectedIndex == -1)
                        {
                            infoAccountGroup.affectGrossProfit = "No";
                        }
                        else
                        {
                            infoAccountGroup.affectGrossProfit = cmbAffectGrossProfit.SelectedItem.ToString();
                        }
                        infoAccountGroup.isDefault = false;
                        infoAccountGroup.narration = txtNarration.Text.Trim();
                        if (btnSave.Text == "Save")
                        {
                            if (Messages.SaveConfirmation())
                            {
                                decAccountGroupId = spAccountGroup.AccountGroupAddWithIdentity(infoAccountGroup);
                                Messages.SavedMessage();
                                decIdForOtherForms = decAccountGroupId;
                                if (frmAccountLedgerobj != null)
                                {
                                    this.Close();
                                }
                                GridFill();
                                Clear();
                            }
                        }
                        else
                        {
                            if (isDefault == true)
                            {
                                Messages.InformationMessage("Can't update build in account group");
                            }
                            else if (txtAccountGroupName.Text.Trim().ToLower() != cmbGroupUnder.Text.ToLower())
                            {
                                if (Messages.UpdateConfirmation())
                                {
                                    infoAccountGroup.accountGroupId = Convert.ToInt32(decAccountGroupIdForEdit);
                                    if (spAccountGroup.AccountGroupUpdate(infoAccountGroup))
                                    {
                                        Messages.UpdatedMessage();
                                    }
                                    GridFill();
                                    Clear();
                                }
                            }
                            else
                            {
                                Messages.InformationMessage(" Can't save under same group");
                            }
                        }
                    }
                }
                else
                {
                    Messages.InformationMessage(" Account group already exist");
                    txtAccountGroupName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Edit()
        {
            //strAccountGroupName = btnSave.Text == "Save" ? string.Empty : strAccountGroupName;
            if (txtAccountGroupName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter account group name");
                txtAccountGroupName.Focus();
            }
            else if (cmbGroupUnder.SelectedIndex == -1)
            {
                MessageBox.Show("Select under");
                cmbGroupUnder.Focus();
            }
            else if (cmbNature.SelectedIndex == -1)
            {
                MessageBox.Show("Select nature");
                cmbNature.Focus();
            }
            else
            {
                AccountGroup ag = IME.AccountGroups.Where(a => a.accountGroupName == txtAccountGroupName.Text.Trim()).FirstOrDefault();
                ag.groupUnder = Int32.Parse(cmbGroupUnder.SelectedValue.ToString());
                ag.nature = cmbNature.SelectedItem.ToString();
                if (cmbAffectGrossProfit.SelectedIndex == -1)
                {
                    ag.affectGrossProfit = "No";
                }
                else
                {
                    ag.affectGrossProfit = cmbAffectGrossProfit.SelectedItem.ToString();
                }
                ag.narration = txtNarration.Text.Trim();
                IME.SaveChanges();
                GridFill();

            }
        }

        private bool ControlID(string AccountGroupName)
        {
            if (IME.AccountGroups.Where(a => a.accountGroupName == AccountGroupName).FirstOrDefault() != null) return true;
            return false;
        }


        private void dgvAccountGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    AccountGroup InfoAccountGroup = new AccountGroup();
                    AccountGroupSP spAccountGroup = new AccountGroupSP();
                    InfoAccountGroup = spAccountGroup.AccountGroupViewForUpdate(Convert.ToDecimal(dgvAccountGroup.CurrentRow.Cells["dgvtxtAccountGroupId"].Value.ToString()));
                    bool Isdefault = (bool)InfoAccountGroup.isDefault;
                    txtAccountGroupName.Text = InfoAccountGroup.accountGroupName;
                    cmbGroupUnder.SelectedValue = InfoAccountGroup.groupUnder.ToString();
                    decimal decAccountGroupId = Convert.ToDecimal(cmbGroupUnder.SelectedValue.ToString());
                    string strNature = spAccountGroup.AccountGroupNatureUnderGroup(decAccountGroupId);
                    if (strNature != "NA")
                    {
                        cmbNature.Text = InfoAccountGroup.nature;
                        cmbNature.Enabled = false;
                    }
                    else
                    {
                        cmbNature.Text = InfoAccountGroup.nature;
                        cmbNature.Enabled = true;
                    }
                    if (Isdefault)
                    {
                        decimal decAffectGrossProfit = Convert.ToDecimal(InfoAccountGroup.affectGrossProfit);
                        if (decAffectGrossProfit == 0)
                        {
                            cmbAffectGrossProfit.Text = "No";

                        }
                        else
                        {
                            cmbAffectGrossProfit.Text = "Yes";
                        }
                    }
                    else
                    {
                        cmbAffectGrossProfit.Text = InfoAccountGroup.affectGrossProfit;
                    }
                    txtNarration.Text = InfoAccountGroup.narration;
                    btnSave.Text = "Update";
                    txtAccountGroupName.Focus();
                    btnDelete.Enabled = true;
                    strAccountGroupName = InfoAccountGroup.accountGroupName;
                    decAccountGroupIdForEdit = Convert.ToDecimal(dgvAccountGroup.CurrentRow.Cells["dgvtxtAccountGroupId"].Value.ToString());
                    inId = Convert.ToInt32(InfoAccountGroup.accountGroupId.ToString());
                    isDefault = Convert.ToBoolean(InfoAccountGroup.isDefault);

                    if (isDefault == true && strNature != "NA")
                    {
                        txtAccountGroupName.Enabled = false;
                        cmbAffectGrossProfit.Enabled = false;
                        cmbGroupUnder.Enabled = false;
                        cmbNature.Enabled = false;
                    }
                    else
                    {
                        if (strNature == "NA")
                        {
                            txtAccountGroupName.Enabled = true;
                            cmbAffectGrossProfit.Enabled = true;
                            cmbGroupUnder.Enabled = true;
                            cmbNature.Enabled = true;
                        }

                    }
                    if (isDefault == false)
                    {
                        if (spAccountGroup.AccountGroupCheckExistenceOfUnderGroup(Convert.ToDecimal(inId.ToString())) == false)
                        {
                            cmbAffectGrossProfit.Enabled = false;
                            cmbGroupUnder.Enabled = false;
                            cmbNature.Enabled = false;
                        }
                        else
                        {
                            if (strNature == "NA")
                            {
                                cmbAffectGrossProfit.Enabled = true;
                                cmbGroupUnder.Enabled = true;
                                cmbNature.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.RowIndex != -1)
            {
                int agID = Int32.Parse(dgvAccountGroup.Rows[e.RowIndex].Cells[1].Value.ToString());
                AccountGroup ag = IME.AccountGroups.Where(a => a.accountGroupId == agID).FirstOrDefault();
                bool Isdefault = (bool)ag.isDefault;
                txtAccountGroupName.Text = ag.accountGroupName;
                cmbGroupUnder.SelectedValue = ag.groupUnder.ToString();
                string strNature = IME.AccountGroups.Where(a => a.accountGroupId == agID).FirstOrDefault().nature;
                if (strNature != "NA")
                {
                    cmbNature.Text = ag.nature;
                    cmbNature.Enabled = false;
                }
                else
                {
                    cmbNature.Text = ag.nature;
                    cmbNature.Enabled = true;
                }
                if (Isdefault)
                {
                    decimal decAffectGrossProfit = Convert.ToDecimal(ag.affectGrossProfit);
                    if (decAffectGrossProfit == 0)
                    {
                        cmbAffectGrossProfit.Text = "No";
                    }
                    else
                    {
                        cmbAffectGrossProfit.Text = "Yes";
                    }
                }
                else
                {
                    cmbAffectGrossProfit.Text = ag.affectGrossProfit;
                }
                txtNarration.Text = ag.narration;
                btnSave.Text = "Update";
                txtAccountGroupName.Focus();
                btnDelete.Enabled = true;
                strAccountGroupName = ag.accountGroupName;
                decAccountGroupIdForEdit = Convert.ToDecimal(dgvAccountGroup.CurrentRow.Cells[1].Value.ToString());
                inId = Convert.ToInt32(ag.accountGroupId.ToString());
                isDefault = Convert.ToBoolean(ag.isDefault);

                if (isDefault == true && strNature != "NA")
                {
                    txtAccountGroupName.Enabled = false;
                    cmbAffectGrossProfit.Enabled = false;
                    cmbGroupUnder.Enabled = false;
                    cmbNature.Enabled = false;
                }
                else
                {
                    if (strNature == "NA")
                    {
                        txtAccountGroupName.Enabled = true;
                        cmbAffectGrossProfit.Enabled = true;
                        cmbGroupUnder.Enabled = true;
                        cmbNature.Enabled = true;
                    }

                }
                if (isDefault == false)
                {
                    if (IME.AccountGroups.Where(a => a.accountGroupId == inId).FirstOrDefault() == null)
                    {
                        cmbAffectGrossProfit.Enabled = false;
                        cmbGroupUnder.Enabled = false;
                        cmbNature.Enabled = false;
                    }
                    else
                    {
                        if (strNature == "NA")
                        {
                            cmbAffectGrossProfit.Enabled = true;
                            cmbGroupUnder.Enabled = true;
                            cmbNature.Enabled = true;
                        }
                    }
                }
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
                    Delete();
                //}
                //else
                //{
                //    Messages.NoPrivillageMessage();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                GridFill();   
        }

        private void dgvAccountGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
                dgvAccountGroup.ClearSelection();
        }
       
        private void cmbGroupUnderSearch_Leave(object sender, EventArgs e)
        {
                if (cmbGroupUnderSearch.SelectedIndex == -1)
                {
                    cmbGroupUnderSearch.Text = "All";
                }
        }

        private void cmbNature_KeyPress(object sender, KeyPressEventArgs e)
        {
                cmbNature.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        private void cmbAffectGrossProfit_KeyPress(object sender, KeyPressEventArgs e)
        {     
                cmbAffectGrossProfit.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        //On GroupUnder combo keypress
        private void cmbGroupUnderSearch_KeyPress(object sender, KeyPressEventArgs e)
        {  
                cmbGroupUnderSearch.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        
        private void frmAccountGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (frmAccountLedgerobj != null)
                {
                    frmAccountLedgerobj.ReturnFromAccountGroupForm(decIdForOtherForms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AG26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmbGroupUnder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbGroupUnder.SelectedValue != null && cmbGroupUnder.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    decimal decAccountGroupId = Convert.ToDecimal(cmbGroupUnder.SelectedValue.ToString());
                    AccountGroupSP spAccountGroup = new AccountGroupSP();
                    AccountGroup infoAccountGroup = new AccountGroup();
                    infoAccountGroup = spAccountGroup.AccountGroupView(decAccountGroupId);
                    string strNature = infoAccountGroup.nature;
                    string strIsAffectGrossProfit = infoAccountGroup.affectGrossProfit;
                    // string strNature = spAccountGroup.AccountGroupNatureUnderGroup(decAccountGroupId);
                    if (strNature != "NA")
                    {
                        cmbNature.Text = strNature;
                        if (infoAccountGroup.affectGrossProfit == "1")
                        {
                            cmbAffectGrossProfit.SelectedIndex = 0;
                        }
                        else
                        {
                            cmbAffectGrossProfit.SelectedIndex = 1;
                        }
                        cmbNature.Enabled = false;
                        cmbAffectGrossProfit.Enabled = false;

                    }
                    else
                    {
                        cmbNature.Enabled = true;
                        cmbAffectGrossProfit.Enabled = true;
                        //    }
                    }
                }
            }
            catch (Exception)
            {


            }
            if (txtAccountGroupName.Text != null && txtAccountGroupName.Text != string.Empty)
            {


            }
            else
            {
                cmbNature.Enabled = true;
            }
        }
        #endregion
        #region Navigation
        /// <summary>
        /// Enter key navigation on txtAccountGroupName textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAccountGroupName_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbGroupUnder.Enabled)
                    {
                        cmbGroupUnder.Focus();
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }

        }
        /// <summary>
        ///  Enter key and backspace navigation on cmbGroupUnder KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroupUnder_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbNature.Enabled)
                    {
                        cmbNature.Focus();
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbGroupUnder.Text == string.Empty || cmbGroupUnder.SelectionStart == 0)
                    {
                        txtAccountGroupName.SelectionStart = 0;
                        txtAccountGroupName.SelectionLength = 0;
                        txtAccountGroupName.Focus();
                    }
                }
        }
        /// <summary>
        /// Enter key and backspace navigation on cmbNature KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbNature_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbAffectGrossProfit.Enabled)
                    {
                        cmbAffectGrossProfit.Focus();
                    }
                    else
                    {
                        txtNarration.Focus();
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbNature.SelectionStart == 0 || cmbNature.Text == string.Empty)
                    {
                        cmbGroupUnder.SelectionStart = 0;
                        cmbGroupUnder.SelectionLength = 0;
                        cmbGroupUnder.Focus();
                    }
                }
        }
        /// <summary>
        /// Enter key and backspace navigation on cmbAffectGrossProfit KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAffectGrossProfit_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbAffectGrossProfit.SelectionStart == 0 || cmbAffectGrossProfit.Text == string.Empty)
                    {
                        cmbNature.SelectionStart = 0;
                        cmbNature.SelectionLength = 0;
                        cmbNature.Focus();
                    }
                }
            
        }
        /// <summary>
        /// Backspace navigation on txtNarration KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        cmbAffectGrossProfit.Focus();
                        cmbAffectGrossProfit.SelectionStart = 0;
                        cmbAffectGrossProfit.SelectionLength = 0;
                    }
                }
            
        }
        /// <summary>
        /// Enter key  navigation on txtNarration Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
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
        /// <summary>
        /// Enter key  navigation on txtNarration textbox KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        ///  Backspace navigation on btnSave button KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                }
        }
        /// <summary>
        /// Backspace navigation on btnSearch button KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    cmbGroupUnderSearch.Focus();
                }
        }
        /// <summary>
        /// Enter key navigation on txtAccountGroupNameSearch textbox KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAccountGroupNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroupUnderSearch.Focus();
                }
           
        }
        /// <summary>
        ///  Enter key and backspace navigation on cmbGroupUnderSearch combobox KeyDown 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroupUnderSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbGroupUnderSearch.SelectionStart == 0 || cmbGroupUnderSearch.Text == string.Empty)
                    {
                        txtAccountGroupNameSearch.SelectionStart = 0;
                        txtAccountGroupNameSearch.SelectionLength = 0;
                        txtAccountGroupNameSearch.Focus();
                    }
                }
            
        }
        /// <summary>
        /// Enter key and backspace navigation on dgvAccountGroup datagridview KeyUp 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccountGroup_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (dgvAccountGroup.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvAccountGroup.CurrentCell.ColumnIndex, dgvAccountGroup.CurrentCell.RowIndex);
                        dgvAccountGroup_CellDoubleClick(sender, ex);
                    }
                }
            
        }
        /// <summary>
        /// Backspace navigation on dgvAccountGroup datagridview KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAccountGroup_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (e.KeyCode == Keys.Back)
                {
                    cmbGroupUnderSearch.Focus();
                }
        }

        #endregion

        private void dgvAccountGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
