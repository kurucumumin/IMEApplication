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
    public partial class frmCurrency : Form
    {
        #region Public Variables
        IMEEntities IME = new IMEEntities();
        /// <summary>
        /// Public varaible declaration part
        /// </summary>
        decimal decCurrencyId;
        decimal decCurrency;
        int inNarrationCount = 0;
        int decIdForOtherForms = 0;
        frmExchangeRate frmExchangeRateObj;
        decimal decId;
        #endregion
        #region Function
        /// <summary>
        /// Creates an instance of frmCurrency class
        /// </summary>
        public frmCurrency()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to save
        /// </summary>
        public void SaveFunction()
        {
            if (IME.Currencies.Where(a => a.currencyName == txtName.Text.Trim()).FirstOrDefault() == null)
            {
                Currency c = new Currency();
                c.currencySymbol = txtSymbol.Text.Trim();
                c.currencyName = txtName.Text.Trim();
                c.subunitName = txtSubUnit.Text.Trim();
                //c.isDefault = false;
                IME.Currencies.Add(c);
                IME.SaveChanges();
                MessageBox.Show("Currency is saved succesfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Currency name already exist");
                txtName.Focus();
            }
        }
        /// <summary>
        /// Function to Edit
        /// </summary>
        public void EditFunction()
        {

            //infoCurrency.CurrencySymbol = txtSymbol.Text.Trim();
            //infoCurrency.CurrencyName = txtName.Text.Trim();
            //infoCurrency.SubunitName = txtSubUnit.Text.Trim();
            //infoCurrency.NoOfDecimalPlaces = Convert.ToInt32(txtDecimalPlaces.Text.Trim());
            //infoCurrency.Narration = txtNarration.Text.Trim();
            //infoCurrency.IsDefault = false;
            //infoCurrency.Extra1 = String.Empty;
            //infoCurrency.Extra2 = String.Empty;
            //infoCurrency.CurrencyId = decId;
            if (IME.Currencies.Where(a => a.currencyName == txtName.Text.Trim()).Where(b=>b.currencySymbol==txtSymbol.Text.Trim()).FirstOrDefault() == null)
            {
                Currency c = IME.Currencies.Where(a => a.currencyID == decId).FirstOrDefault();
                c.currencySymbol = txtSymbol.Text.Trim();
                c.currencyName = txtName.Text.Trim();
                c.subunitName = txtSubUnit.Text.Trim();
                //c.isDefault = false;
                IME.SaveChanges();

                MessageBox.Show("Currency is updated successfully");
                SearchClear();
                Clear();
            }
            else
            {
                MessageBox.Show("Currency name already exist");
                txtName.Focus();
            }

        }
        /// <summary>
        /// FUNCTION TO CALL SAVE OR EDIT
        /// </summary>
        public void SaveOrEdit()
        {
            if (txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter currency name");
                txtName.Focus();
            }
            else if (txtSymbol.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter symbol");
                txtSymbol.Focus();
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
        /// <summary>
        /// Function to fill controls for update
        /// </summary>
        public void FillControls()
        {
            var c = IME.Currencies.Where(a => a.currencyID == decId).FirstOrDefault();
            txtName.Text = c.currencyName;
            txtSymbol.Text = c.currencySymbol;
            txtSubUnit.Text = c.subunitName;
            decCurrencyId = c.currencyID;
        }
        /// <summary>
        /// Function to clear controls
        /// </summary>
        public void Clear()
        {
            try
            {
                txtName.Clear();
                txtSubUnit.Clear();
                txtSymbol.Clear();
                txtName.Focus();
                btnSave.Text = "Save";
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("C5:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to clear
        /// </summary>
        public void SearchClear()
        {
            try
            {
                txtNameSearch.Clear();
                txtSymbolSearch.Clear();
                txtNameSearch.Focus();
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GridFill()
        {
            if (txtNameSearch.Text.Trim() == "" && txtSymbolSearch.Text.Trim() != "")
            {
                dgvCurrency.DataSource = IME.Currencies.Where(b => b.currencySymbol.Contains(txtSymbolSearch.Text.Trim())).ToList();
            }
            else if (txtSymbolSearch.Text.Trim() == "" && txtNameSearch.Text.Trim() != "")
            {
                dgvCurrency.DataSource = IME.Currencies.Where(a => a.currencyName.Contains(txtNameSearch.Text.Trim())).ToList();
            }
            else if (txtNameSearch.Text.Trim() == "" && txtNameSearch.Text.Trim() == "")
            {
                dgvCurrency.DataSource = IME.Currencies.ToList();
            }
            else
            {
                dgvCurrency.DataSource = IME.Currencies.Where(a => a.currencyName.Contains(txtNameSearch.Text.Trim())).Where(b => b.currencySymbol.Contains(txtSymbolSearch.Text.Trim())).ToList();
            }
        }

        public void DeleteFunction()
        {
            try
            {
                var c = IME.Currencies.Where(a => a.currencyID == decId).FirstOrDefault();
                if (c != null)
                {
                    IME.Currencies.Remove(c);
                    IME.SaveChanges();
                    MessageBox.Show("Currency Deleted Successfully");
                    Clear();
                    GridFill();
                }
            }
            catch
            {
                MessageBox.Show("Currency does not deleted because there is some relations of this currency");
            }
        }

        public void Delete()
        {
            DeleteFunction();
        }


        public void CallFromExchangerate(frmExchangeRate frmExchangeRate)
        {
            try
            {
                groupBox2.Enabled = false;
                this.frmExchangeRateObj = frmExchangeRate;
                base.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C10:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Events

        private void frmCurrency_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C11:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Save' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrEdit();
            GridFill();
        }
        /// <summary>
        /// On form closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFrmClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete this currency?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// On 'Close' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete this currency?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        /// <summary>
        /// On 'Clear' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /// <summary>
        /// On 'Delete' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }
        /// <summary>
        /// On datagridview cell double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                decId = Convert.ToDecimal(dgvCurrency.Rows[e.RowIndex].Cells["CurrencyID"].Value.ToString());
                //if (IME.Currencies.Where(a => a.currencyID == decId).FirstOrDefault().isDefault == false)
                //{
                //    FillControls();
                //    btnDelete.Enabled = true;
                //    btnSave.Text = "Update";
                //    txtName.Focus();
                //}
                //else
                //{
                //    MessageBox.Show("Default currency cannot update or delete");
                //    Clear();
                //}
            }
        }
        /// <summary>
        /// Clears selection datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCurrency_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCurrency.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C18:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Serach' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GridFill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C19:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Clear' button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchClear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("C20:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtDecimalPlaces_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127;
        }
        #endregion
        #region Navigation
        /// <summary>
        /// On form keydown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
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
                MessageBox.Show("C24:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Name' textbox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSymbol.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C25:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Symbol' textbox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSymbol_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubUnit.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtSymbol.Text == string.Empty || txtSymbol.SelectionStart == 0)
                    {
                        txtName.Focus();
                        txtName.SelectionStart = 0;
                        txtName.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'SubUnit' textbox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSubUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSymbol.Focus();
            }
            if (e.KeyCode == Keys.Back)
            {
                if (txtSubUnit.Text == string.Empty || txtSubUnit.SelectionStart == 0)
                {
                    txtSymbol.Focus();
                    txtSymbol.SelectionStart = 0;
                    txtSymbol.SelectionLength = 0;
                }
            }
        }
        private void txtNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSymbolSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Symbol' textbox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSymbolSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtSymbolSearch.Text == string.Empty || txtSymbolSearch.SelectionStart == 0)
                    {
                        txtNameSearch.Focus();
                        txtNameSearch.SelectionStart = 0;
                        txtNameSearch.SelectionLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C31:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Save' button key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {

        }
        /// <summary>
        /// On 'Search' button key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    txtSymbolSearch.Focus();
                    txtSymbolSearch.SelectionLength = 0;
                    txtSymbolSearch.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C33:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On 'Clear' button key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    btnSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C34:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// On datagridview keyup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCurrency_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (dgvCurrency.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvCurrency.CurrentCell.ColumnIndex, dgvCurrency.CurrentCell.RowIndex);
                        dgvCurrency_CellDoubleClick(sender, ex);
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtSymbolSearch.Focus();
                    txtSymbolSearch.SelectionLength = 0;
                    txtSymbolSearch.SelectionStart = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("C35:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}