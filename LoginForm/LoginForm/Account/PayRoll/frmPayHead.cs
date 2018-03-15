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
    public partial class frmPayHead : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        string strPayHeadName = string.Empty;
        string strPayheadType = string.Empty;
        int inNarrationCount = 0;
        decimal decPayHeadId;

        #endregion

        #region Functions
        /// <summary>
        /// creates an instance of frmPayHead class
        /// </summary>
        public frmPayHead()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function for save
        /// </summary>
        public void SaveFunction()
        {
            if (IME.PayHeads.Where(a=>a.payHeadName==txtPayheadName.Text).FirstOrDefault()==null)
            {
                IME.PayHeadAdd(txtPayheadName.Text, cmbPayheadType.Text, txtPayheadNarration.Text, null);
                MessageBox.Show("Save successfully");
            }
            else
            {
                MessageBox.Show("There is already exist PayHead Name");
            }

            
        }
        /// <summary>
        /// Function for Edit
        /// </summary>
        public void EditFunction()
        {
            if (IME.PayHeads.Where(a=>a.payHeadName== txtPayheadName.Text.Trim()).FirstOrDefault()==null)
            {
                IME.PayHeadEdit(decPayHeadId, txtPayheadName.Text.Trim(), cmbPayheadType.Text, txtPayheadNarration.Text.Trim(), null);
                GridFill();
                MessageBox.Show("Update successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Payhead name already exist");
            }
           
        }
        /// <summary>
        /// Function to call Save or Edit
        /// </summary>
        public void SaveorEdit()
        {
                if (txtPayheadName.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter payhead name");
                    txtPayheadName.Focus();
                }
                else if (cmbPayheadType.Text == string.Empty)
                {
                    MessageBox.Show("Select type");
                    cmbPayheadType.Focus();
                }
                else
                {
                    if (btnPayheadSave.Text == "Save")
                    {
                            SaveFunction();
                    }
                    else
                    {
                            EditFunction();
                    }
                }
        }
        /// <summary>
        /// Function to fill Datagridview
        /// </summary>
        public void GridFill()
        {
            PayHeadSP spPayhead = new PayHeadSP();
            DataTable dtblPayhead = new DataTable();

            if (txtPayheadSearch.Text.Trim() != string.Empty)
            {
                dtblPayhead = spPayhead.PayHeadGetSearch(txtPayheadSearch.Text.Trim());
                dgvPayhead.DataSource = dtblPayhead;
            }
            else
            {
                dtblPayhead = spPayhead.PayHeadGetSearchAll(txtPayheadSearch.Text.Trim());
                dgvPayhead.DataSource = dtblPayhead;
            }
                
        }
        /// <summary>
        /// Function to reset the form
        /// </summary>
        public void Clear()
        {
            try
            {
                txtPayheadName.Focus();
                txtPayheadName.Clear();
                cmbPayheadType.SelectedIndex = -1;
                txtPayheadNarration.Clear();
                btnPayheadSave.Text = "Save";
                btnPayheadDelete.Enabled = false;
                txtPayheadSearch.Clear();
                dgvPayhead.ClearSelection();
                cmbPayheadType.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function for Delete
        /// </summary>
        public void DeleteFunction()
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    MessageBox.Show("Deleted successfully");
                    Clear();
                    GridFill();
                }
                catch
                {
                    MessageBox.Show("You can't delete,reference exist");
                    txtPayheadName.Focus();
                }
            }
        }
        #endregion

        #region Events
        private void btnPayheadSave_Click(object sender, EventArgs e)
        {
                    SaveorEdit();
        }
        private void frmPayHead_Load(object sender, EventArgs e)
        {
            try
            {
               // dgvPayhead.DataSource = IME.PayHeadGetAll();
                btnPayheadDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnPayheadClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
        private void txtPayheadSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnPayheadDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }
        }

        private void btnPayheadClear_Click(object sender, EventArgs e)
        {
            
                Clear();
            
        }


        private void dgvPayhead_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvPayhead.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH13:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
     
        private void dgvPayhead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    PayHead p = new PayHead();
                    decimal pID = decimal.Parse(dgvPayhead.CurrentRow.Cells["dgvtxtPayheadId"].Value.ToString());
                    p = IME.PayHeads.Where(a => a.payHeadId == pID).FirstOrDefault();
                    txtPayheadName.Text = p.payHeadName;
                    cmbPayheadType.Text = p.type;
                    strPayheadType = cmbPayheadType.Text;
                    txtPayheadNarration.Text = p.narration;
                    btnPayheadSave.Text = "Update";
                    btnPayheadDelete.Enabled = true;
                    strPayHeadName = p.payHeadName;
                    decPayHeadId = Convert.ToDecimal(dgvPayhead.CurrentRow.Cells["dgvtxtPayheadId"].Value.ToString());
                    //if (spPayhead.payheadTypeCheckeferences(p.payHeadId, txtPayheadName.Text, cmbPayheadType.Text, txtPayheadNarration.Text))
                    //{
                    //    if (e.RowIndex != -1)
                    //    {
                    //        cmbPayheadType.Enabled = true;
                    //    }
                    //}
                    //else
                    //{
                    //    cmbPayheadType.Enabled = false;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH14:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region Navigation
        /// <summary>
        /// Escape key navigation and quick access
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPayHead_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                        this.Close();
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
                {

                    btnPayheadSave_Click(sender, e);
                }
                if (btnPayheadDelete.Enabled == true)
                {
                    if (e.KeyCode == Keys.D && Control.ModifierKeys == Keys.Control)
                    {

                        btnPayheadDelete_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH15:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayheadName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (cmbPayheadType.Enabled == true)
                    {
                        cmbPayheadType.Focus();
                    }
                    else
                    {
                        txtPayheadNarration.Focus();
                        txtPayheadNarration.SelectionStart = 0;
                        txtPayheadNarration.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH16:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key and backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPayheadType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPayheadNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbPayheadType.Text == string.Empty || cmbPayheadType.SelectionStart == 0)
                    {
                        txtPayheadName.Focus();
                        txtPayheadName.SelectionStart = 0;
                        txtPayheadName.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH17:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayheadNarration_Enter(object sender, EventArgs e)
        {
            try
            {
                inNarrationCount = 0;
                txtPayheadNarration.Text = txtPayheadNarration.Text.Trim();
                if (txtPayheadNarration.Text == string.Empty)
                {
                    txtPayheadNarration.SelectionStart = 0;
                    txtPayheadNarration.SelectionLength = 0;
                    txtPayheadNarration.Focus();
                }
                else
                {
                    txtPayheadNarration.SelectionStart = txtPayheadNarration.Text.Trim().Length;
                    txtPayheadNarration.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayheadNarration_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    inNarrationCount++;
                    if (inNarrationCount == 2)
                    {
                        inNarrationCount = 0;
                        btnPayheadSave.Focus();
                    }
                }
                else
                {
                    inNarrationCount = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayheadNarration_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (cmbPayheadType.Enabled == true)
                    {
                        if (txtPayheadNarration.Text == string.Empty || txtPayheadNarration.SelectionStart == 0)
                        {
                            cmbPayheadType.Focus();
                            cmbPayheadType.SelectionStart = 0;
                            cmbPayheadType.SelectionLength = 0;
                        }
                    }
                    else
                    {
                        if (txtPayheadNarration.Text == string.Empty || txtPayheadNarration.SelectionStart == 0)
                        {
                            txtPayheadName.Focus();
                            txtPayheadName.SelectionStart = 0;
                            txtPayheadName.SelectionLength = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Fill controls for updation on Enter key in Datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPayhead_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if ( e.KeyCode == Keys.Enter)
                {
                    if (dgvPayhead.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs PayheadObj = new DataGridViewCellEventArgs(dgvPayhead.CurrentCell.ColumnIndex, dgvPayhead.CurrentCell.RowIndex);
                        dgvPayhead_CellDoubleClick(sender, PayheadObj);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH21:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Enter key navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPayheadSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dgvPayhead.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH22:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPayhead_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtPayheadSearch.Focus();
                    txtPayheadSearch.SelectionStart = 0;
                    txtPayheadSearch.SelectionLength = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PH23:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Backspace navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPayheadSave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtPayheadNarration.Focus();
                    txtPayheadNarration.SelectionStart = 0;
                    txtPayheadNarration.SelectionLength = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("PH24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #endregion


    }
}


