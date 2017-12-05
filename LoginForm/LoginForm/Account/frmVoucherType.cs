using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.DataSet;
namespace LoginForm
{
    public partial class frmVoucherType : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        bool IsActive = false;
        bool isEditMode = false;
        bool isTax = false;
        decimal decVoucherTypeId = 0;
        int inNarrationCount = 0;
        int inDeclarationCount = 0;
        int q = 0;
        #endregion

        #region Functions
        /// <summary>
        /// combo fill function of dotmatrix
        /// </summary>
        public void DotMatrixComboFill()
        {
            //dr[0] = 0;
            //dr[1] = "Not Applicable";
            //dtbl.Rows.InsertAt(dr, 0);
            cmbDotMatrix.DataSource = IME.PrintFormats.ToList();
                cmbDotMatrix.ValueMember = "ID";
                cmbDotMatrix.DisplayMember = "formName";
                cmbDotMatrix.SelectedIndex = -1;
        }

        public void Clear()
        {
            try
            {
                btnSave.Text = "Save";
                isEditMode = false;
                txtNarration.Text = string.Empty;
                txtVoucherName.Text = string.Empty;
                btnDelete.Enabled = false;
                cmbMethodOfvoucherNumbering.SelectedIndex = -1;
                cmbTypeOfVoucher.SelectedIndex = -1;
                cmbDotMatrix.SelectedIndex = -1;
                cbxActive.Checked = false;
                int inRowCount = dgvApplicableTaxes.RowCount;
                for (int i = 0; i < inRowCount; i++)
                {
                    dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value = false;
                }
                dgvApplicableTaxes.ClearSelection();
                dgvVoucherType.ClearSelection();
                txtVoucherName.Enabled = true;
                cmbTypeOfVoucher.Enabled = true;
                dgvApplicableTaxes.Enabled = false;
                txtDeclaration.Text = string.Empty;
                txtHeading1.Text = string.Empty;
                txtHeading2.Text = string.Empty;
                txtHeading3.Text = string.Empty;
                txtHeading4.Text = string.Empty;
                gbxHeading.Visible = false;
                txtVoucherName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT01:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// checking the invalid entry's for save or update
        /// </summary>
        public void SaveOrEdit()
        {
                if (txtVoucherName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter voucher name");
                    txtVoucherName.Focus();
                }
                else if (cmbTypeOfVoucher.SelectedIndex == -1)
                {
                    MessageBox.Show("Select voucher type");
                    cmbTypeOfVoucher.Focus();

                }
                else if (cmbMethodOfvoucherNumbering.SelectedIndex == -1)
                {
                    MessageBox.Show("Select method of voucher numbering");
                    cmbMethodOfvoucherNumbering.Focus();

                }
                else if (cmbDotMatrix.SelectedIndex == -1)
                {
                    MessageBox.Show("Select Dot-Matrix print format");
                    cmbDotMatrix.Focus();
                }
                else
                {
                    if (isEditMode == false)
                    {
                                SaveFunction();
                    }
                    else if (isEditMode)
                    {
                                EditFunction();
                    }
                }
                SearchGridFill();
            
        }
        /// <summary>
        /// save function
        /// </summary>
        public void SaveFunction()
        {
                if (IME.VoucherTypes.Where(a=>a.voucherTypeName== txtVoucherName.Text.Trim()).FirstOrDefault()==null)
                {
                    VoucherType vt = new VoucherType();
                    vt.voucherTypeName = txtVoucherName.Text.Trim();
                    vt.typeOfVoucher = cmbTypeOfVoucher.Text;
                    vt.methodOfVoucherNumbering = cmbMethodOfvoucherNumbering.Text;
                    int inRowCount = dgvApplicableTaxes.RowCount;
                    for (int i = 0; i <= inRowCount - 1; i++)
                    {
                        if (dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value != null)
                        {

                            if (dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value.ToString() != "False")
                            {
                                isTax = bool.Parse(dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value.ToString());
                            }
                        }
                    }
                    vt.isTaxApplicable = isTax;
                    if (cbxActive.Checked)
                    {
                        IsActive = true;
                    }
                    vt.isActive = IsActive;
                    vt.isDefault = false;
                    vt.narration = txtNarration.Text.Trim();
                    vt.masterId = Convert.ToInt32(cmbDotMatrix.SelectedValue);
                    vt.declaration = txtDeclaration.Text;
                    vt.heading1 = txtHeading1.Text;
                    vt.heading2 = txtHeading2.Text;
                    vt.heading3 = txtHeading3.Text;
                    vt.heading4 = txtHeading4.Text;
                    IME.VoucherTypes.Add(vt);
                    IME.SaveChanges();
                    decVoucherTypeId = vt.voucherTypeId;
                    if (isTax)
                    {
                        for (int i = 0; i <= inRowCount - 1; i++)
                        {
                            if (dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value != null)
                            {
                                if (dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value.ToString() != "False")
                                {
                                    VoucherTypeTax vtt = new VoucherTypeTax();
                                    vtt.voucherTypeId = decVoucherTypeId;
                                    vtt.taxId = Convert.ToDecimal(dgvApplicableTaxes.Rows[i].Cells["dgvtxtTaxId"].Value.ToString());
                                    IME.VoucherTypeTaxes.Add(vtt);
                                    IME.SaveChanges();
                                }
                            }

                        }

                    }
                    MessageBox.Show("VoucherType is saved successfully");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Voucher name already exists");
                }

        }


        public void EditFunction()
        {

            if (IME.VoucherTypes.Where(a => a.voucherTypeName == txtVoucherName.Text.Trim()).Where(b => b.voucherTypeId != decVoucherTypeId).ToList().Count == 0)
            {
                //referans ı var mı kontrol et
                //eğer referans ı varsa kaydetmez hata verir
                try
                {
                    VoucherType vt = IME.VoucherTypes.Where(a => a.voucherTypeId == decVoucherTypeId).FirstOrDefault();
                    vt.voucherTypeName = txtVoucherName.Text.Trim();
                    vt.typeOfVoucher = cmbTypeOfVoucher.Text;
                    vt.methodOfVoucherNumbering = cmbMethodOfvoucherNumbering.Text;
                    vt.narration = txtNarration.Text.Trim();
                    if (cbxActive.Checked)
                    {
                        IsActive = true;
                    }
                    vt.isActive = IsActive;
                    int inRowCount = dgvApplicableTaxes.RowCount;
                    for (int i = 0; i <= inRowCount - 1; i++)
                    {

                        if (dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value != null && dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value.ToString() != "False")
                        {
                            isTax = bool.Parse(dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value.ToString());

                        }
                    }
                    vt.isTaxApplicable = isTax;
                    vt.masterId = int.Parse(cmbDotMatrix.SelectedValue.ToString());
                    vt.declaration = txtDeclaration.Text;
                    vt.heading1 = txtHeading1.Text;
                    vt.heading2 = txtHeading2.Text;
                    vt.heading3 = txtHeading3.Text;
                    vt.heading4 = txtHeading4.Text;
                    IME.SaveChanges();

                    var vouchertaxList = IME.VoucherTypeTaxes.Where(a => a.voucherTypeId == decVoucherTypeId).ToList();
                    MessageBox.Show("Updated successfully");
                    Clear();
                }
                catch
                {
                    MessageBox.Show("You can't update,voucher already in use");
                }
            }
            else
            {
                MessageBox.Show("Voucher name already exists");
            }


        }

        public void SearchGridFill()
        {
            
                dgvVoucherType.DataSource = IME.VoucherTypes.Where(a => a.voucherTypeName == txtVoucherNameSearch.Text.Trim()).Where(b => b.typeOfVoucher == cmbTypeOfVoucherSearch.Text).ToList();
            
        }

        public void VoucherTypeComboFill()
        {
                cmbTypeOfVoucher.DataSource = IME.VoucherTypes.ToList();
                cmbTypeOfVoucher.ValueMember = "voucherTypeId";
                cmbTypeOfVoucher.DisplayMember = "typeOfVoucher";
                cmbTypeOfVoucher.SelectedIndex = -1;
                gbxHeading.Visible = false;
        }

        public void VoucherTypeSearchComboFill()
        {
                cmbTypeOfVoucher.DataSource = IME.VoucherTypes.ToList();
                cmbTypeOfVoucher.ValueMember = "voucherTypeId";
                cmbTypeOfVoucher.DisplayMember = "typeOfVoucher";
                cmbTypeOfVoucher.SelectedIndex = -1;
        }


        public void TaxGridFill()
        {
            dgvApplicableTaxes.DataSource = IME.Taxes.ToList();
        }

        public void SearchClear()
        {
                txtVoucherNameSearch.Text = string.Empty;
                cmbTypeOfVoucherSearch.Text = string.Empty;
                txtVoucherNameSearch.Focus();
                cmbTypeOfVoucherSearch.SelectedIndex = -1;
                SearchGridFill();
           
        }
        /// <summary>
        /// checking privilage for delete
        /// </summary>
        public void Delete()
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
        }
        /// <summary>
        /// delete function
        /// </summary>
        public void DeleteFunction()
        {
            try
            {
                if (IME.VoucherTypes.Where(a => a.voucherTypeId == decVoucherTypeId).FirstOrDefault().isDefault == false)
                {
                    try
                    {
                        VoucherType vt = IME.VoucherTypes.Where(a => a.voucherTypeId == decVoucherTypeId).FirstOrDefault();
                        if (vt!=null)
                        {
                            IME.VoucherTypes.Remove(vt);
                            IME.SaveChanges();
                            var vtt = IME.VoucherTypeTaxes.Where(a => a.voucherTypeId == decVoucherTypeId).ToList();
                            foreach (var item in vtt)
                            {
                                IME.VoucherTypeTaxes.Remove(item);
                                IME.SaveChanges();
                            }
                        }
                        MessageBox.Show("Voucher Deleted successfully");
                        SearchGridFill();
                    }
                    catch
                    {
                        MessageBox.Show("You can't delete,reference exist");
                    }

                }
                else
                {
                    MessageBox.Show("You can't delete default voucher types");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("VT11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Creates an instance of a frmVoucherType class.
        /// </summary>
        public frmVoucherType()
        {
            InitializeComponent();
        }
        /// <summary>
        /// checking the vouchertype for displaying heading fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTypeOfVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbTypeOfVoucher.Text == "Sales Invoice" || cmbTypeOfVoucher.Text == "Sales Return" || cmbTypeOfVoucher.Text == "Purchase Invoice" || cmbTypeOfVoucher.Text == "Purchase Return")
                {
                    dgvApplicableTaxes.Enabled = true;
                }
                else
                {
                    dgvApplicableTaxes.Enabled = false;
                }
                if (cmbTypeOfVoucher.Text == "Sales Invoice" || cmbTypeOfVoucher.Text == "Purchase Invoice" || cmbTypeOfVoucher.Text == "Sales Return" || cmbTypeOfVoucher.Text == "Purchase Return")
                {
                    gbxHeading.Visible = true;
                }
                else
                {
                    gbxHeading.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT12:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// save button click, checking privilage for save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
                    SaveOrEdit();
        }
        /// <summary>
        /// search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
                SearchGridFill();
        }
        /// <summary>
        /// when form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherType_Load(object sender, EventArgs e)
        {
                SearchGridFill();
                TaxGridFill();
                VoucherTypeComboFill();
                VoucherTypeSearchComboFill();
                DotMatrixComboFill();
        }
        /// <summary>
        /// search clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            try
            {
                SearchClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// when cell double click for update function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherType_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    isEditMode = true;
                    btnSave.Text = "Update";
                    txtVoucherNameSearch.Focus();
                    btnDelete.Enabled = true;
                    int inRowCount = dgvApplicableTaxes.RowCount;
                    for (int i = 0; i < inRowCount; i++)
                    {
                        dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value = false;
                    }
                    decVoucherTypeId = Convert.ToDecimal(dgvVoucherType.CurrentRow.Cells["dgvtxtvoucherTypeId"].Value.ToString());
                    VoucherType vt = IME.VoucherTypes.Where(a => a.voucherTypeId == decVoucherTypeId).FirstOrDefault();
                    txtVoucherName.Text = vt.voucherTypeName;
                    cmbTypeOfVoucher.Text = vt.typeOfVoucher;
                    cmbMethodOfvoucherNumbering.Text = vt.methodOfVoucherNumbering;
                    txtNarration.Text = vt.narration;
                    txtDeclaration.Text = vt.declaration;
                    cmbDotMatrix.SelectedValue = vt.masterId;
                    txtHeading1.Text = vt.heading1;
                    txtHeading2.Text = vt.heading2;
                    txtHeading3.Text = vt.heading3;
                    txtHeading4.Text = vt.heading4;
                    if (vt.isActive==true)
                    {
                        cbxActive.Checked = true;
                    }
                    else
                    {
                        cbxActive.Checked = false;
                    }
                    //dgvApplicableTaxes.DataSource = IME.VoucherTypeTaxes.Where(a => a.voucherTypeId == decVoucherTypeId).ToList();

                    var vtt = IME.VoucherTypeTaxes.Where(a => a.voucherTypeId == decVoucherTypeId).ToList();

                    foreach (var dr in vtt)
                    {
                        string strTaxId = dr.taxId.ToString();

                        for (int i = 0; i < inRowCount; i++)
                        {
                            if (dgvApplicableTaxes.Rows[i].Cells["dgvtxtTaxId"].Value.ToString() == strTaxId)
                            {
                                dgvApplicableTaxes.Rows[i].Cells["dgvcbxSelect"].Value = true;
                            }
                        }


                    }
                    
                    if (IME.VoucherTypes.Where(a => a.voucherTypeId == decVoucherTypeId).FirstOrDefault().isActive == false)
                    {
                        txtVoucherName.Enabled = true;
                        cmbTypeOfVoucher.Enabled = true;
                    }
                    else
                    {
                        txtVoucherName.Enabled = false;
                        cmbTypeOfVoucher.Enabled = false;
                    }
                    if (cmbTypeOfVoucher.Text == "Sales Return" || cmbTypeOfVoucher.Text == "Sales Invoice" || cmbTypeOfVoucher.Text == "Purchase Return" || cmbTypeOfVoucher.Text == "Purchase Invoice")
                    {
                        dgvApplicableTaxes.Enabled = true;

                    }
                    else
                    {
                        dgvApplicableTaxes.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("VT17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// close button click
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
        /// to clear the tax grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApplicableTaxes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvApplicableTaxes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// vouchertype grid clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvVoucherType.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// butten delete click, privilage check and delete function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
                    Delete();
                    Clear();
        }

        #endregion

        #region Navigation
        /// <summary>
        /// voucher name keydown event. its for working enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTypeOfVoucher.Focus();
                    cmbTypeOfVoucher.SelectionStart = 0;
                    cmbTypeOfVoucher.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// vouchertype combobox keydown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTypeOfVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbMethodOfvoucherNumbering.Focus();
                    cmbMethodOfvoucherNumbering.SelectionStart = 0;
                    cmbMethodOfvoucherNumbering.SelectionLength = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtVoucherName.Focus();
                    txtVoucherName.SelectionStart = 0;
                    txtVoucherName.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// combobox MethodOfvoucherNumbering key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMethodOfvoucherNumbering_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = txtNarration.Text.Length;

                }
                if (e.KeyCode == Keys.Back)
                {
                    cmbTypeOfVoucher.Focus();
                    cmbTypeOfVoucher.SelectionStart = 0;
                    cmbTypeOfVoucher.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// textbox narration keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        if (dgvApplicableTaxes.Enabled)
                        {
                            if (dgvApplicableTaxes.RowCount > 0)
                            {
                                dgvApplicableTaxes.Focus();
                                dgvApplicableTaxes.Rows[0].Cells["dgvcbxSelect"].Selected = true;
                                dgvApplicableTaxes.CurrentCell = dgvApplicableTaxes.Rows[0].Cells["dgvcbxSelect"];
                            }
                            else
                            {
                                cmbDotMatrix.Focus();
                            }
                        }
                        else
                        {
                            cmbDotMatrix.Focus();
                        }
                    }

                }
                else
                {
                    inNarrationCount = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text.Trim() == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        cmbMethodOfvoucherNumbering.Focus();
                        cmbMethodOfvoucherNumbering.SelectionStart = 0;
                        cmbMethodOfvoucherNumbering.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// VoucherType form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherType_KeyPress(object sender, KeyPressEventArgs e)
        {

                if (e.KeyChar == 27)
                {
                    DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }

        }
        /// <summary>
        /// tax grid keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApplicableTaxes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvApplicableTaxes.CurrentCell == dgvApplicableTaxes.Rows[dgvApplicableTaxes.Rows.Count - 1].Cells["dgvcbxSelect"])
                    {
                        cmbDotMatrix.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT28:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// active checkbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxActive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (dgvApplicableTaxes.RowCount > 1)
                    {
                        dgvApplicableTaxes.Focus();
                        dgvApplicableTaxes.Rows[dgvApplicableTaxes.RowCount - 1].Cells["dgvcbxSelect"].Selected = true;
                    }
                    else
                    {
                        txtDeclaration.Focus();
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// textbox narration key enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtNarration.Text = txtNarration.Text.Trim();
                if (txtNarration.Text.Trim() == string.Empty)
                {
                    txtNarration.SelectionStart = 0;
                    txtNarration.SelectionLength = 0;
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Trim().Length;
                    txtNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// enter key of textbox narration for enter key 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVoucherNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbTypeOfVoucherSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// vouchertype search combobox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTypeOfVoucherSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtVoucherNameSearch.Focus();
                    txtVoucherNameSearch.SelectionStart = 0;
                    txtVoucherNameSearch.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT32:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// butten close key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (btnDelete.Enabled == true)
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
                MessageBox.Show("VT33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// delete button key down
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
                MessageBox.Show("VT34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        /// <summary>
        /// clear button keydown
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
                MessageBox.Show("VT35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// save button key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cbxActive.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT36:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// vouchertype grid keyup event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherType_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvVoucherType.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvVoucherType.CurrentCell.ColumnIndex, dgvVoucherType.CurrentCell.RowIndex);
                        dgvVoucherType_CellDoubleClick(sender, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT37:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// vouchertype grid keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbTypeOfVoucherSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT38:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// form keydown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVoucherType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {
                    if (dgvApplicableTaxes.Focused)
                    {
                        cbxActive.Focus();
                    }
                    btnSave_Click(sender, e);
                }
                if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
                {
                    if (btnDelete.Enabled)
                    {
                        btnDelete_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT39:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// search button keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    cmbTypeOfVoucherSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT40:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// dotmatrix combobox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDotMatrix_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDeclaration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtNarration.Focus();
                    txtNarration.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("VT41:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        /// <summary>
        /// declaration text box keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeclaration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    inDeclarationCount++;
                    if (inDeclarationCount == 2)
                    {
                        inDeclarationCount = 0;
                        if (gbxHeading.Visible == true)
                        {
                            txtHeading1.Focus();
                        }
                        else
                        {
                            cbxActive.Focus();
                        }
                    }
                }
                else
                {
                    inDeclarationCount = 0;
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDeclaration.Text.Trim() == string.Empty || txtDeclaration.SelectionStart == 0)
                    {
                        cmbDotMatrix.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT42:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// heading 1 textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeading1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHeading2.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtHeading1.Text == string.Empty || txtHeading1.SelectionStart == 0)
                    {
                        txtDeclaration.Focus();
                        txtDeclaration.SelectionStart = 0;
                        txtDeclaration.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("VT43:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// heading 2 textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeading2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHeading3.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtHeading2.Text == string.Empty || txtHeading2.SelectionStart == 0)
                    {
                        txtHeading1.Focus();
                        txtHeading1.SelectionStart = 0;
                        txtHeading1.SelectionLength = 0;

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("VT44:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// heading 3 textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeading3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHeading4.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtHeading3.Text == string.Empty || txtHeading3.SelectionStart == 0)
                    {
                        txtHeading2.Focus();
                        txtHeading2.SelectionStart = 0;
                        txtHeading2.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("VT45:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// heading 4 textbox keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeading4_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cbxActive.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtHeading4.Text == string.Empty || txtHeading4.SelectionStart == 0)
                    {
                        txtHeading3.Focus();
                        txtHeading3.SelectionStart = 0;
                        txtHeading3.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("VT46:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// textbox declaration key enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDeclaration_Enter(object sender, EventArgs e)
        {
            try
            {
                inDeclarationCount = 0;
                txtDeclaration.Text = txtDeclaration.Text.Trim();
                if (txtDeclaration.Text.Trim() == string.Empty)
                {
                    txtDeclaration.SelectionStart = 0;
                    txtDeclaration.SelectionLength = 0;
                    txtDeclaration.Focus();
                }
                else
                {
                    txtDeclaration.SelectionStart = txtDeclaration.Text.Trim().Length;
                    txtDeclaration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("VT47:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
