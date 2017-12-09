using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.DataSet;
using LoginForm.Services;
namespace LoginForm
{
    public partial class frmExchangeRate : Form
    {
        #region Public Variables
        /// <summary>
        /// Public variable declaration part
        /// </summary>
        IMEEntities IME = new IMEEntities();
        int decExchangeRateId;
        int inNarrationCount = 0;
        int decId;
        string strCurrencyName;
        static int decimalCount = 0;
        #endregion
        #region Functions
        /// <summary>
        /// Creates an instance of frmExchangeRate class
        /// </summary>
        public frmExchangeRate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Function to check exchangerate is greater than zero or not
        /// </summary>
        /// <returns></returns>
        public bool ExchangeRateCheck()
        {
            bool isOk = true;
            try
            {
                if (Convert.ToDecimal(txtExchangeRate.Text.Trim().ToString()) == 0)
                {
                    isOk = false;
                    MessageBox.Show("Exchange rate Should be greater than zero");
                    txtExchangeRate.Focus();
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                MessageBox.Show("ER1:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isOk;
        }
        /// <summary>
        /// Function to save
        /// </summary>
        public void SaveFunction()
        {
            ExchangeRate rate = new ExchangeRate();         
            decimal currencyID = Convert.ToDecimal(cmbCurrency.SelectedValue.ToString());
            if (IME.ExchangeRates.Where(a => a.date == dtpDate.Value).Where(b => b.currencyId == currencyID).FirstOrDefault() == null)
            {

                if (ExchangeRateCheck())
                {
                    rate.currencyId = Convert.ToDecimal(cmbCurrency.SelectedValue.ToString());
                    rate.date = dtpDate.Value;
                    rate.rate = Convert.ToDecimal(txtExchangeRate.Text.Trim().ToString());
                    IME.ExchangeRates.Add(rate);
                    IME.SaveChanges();
                    MessageBox.Show("Currency Updated");
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("You can't update,reference exist");
            }
        }
        /// <summary>
        /// Function to edit
        /// </summary>
        public void Editfunction()
        {
            decimal currencyID = Convert.ToDecimal(cmbCurrency.SelectedValue.ToString());
            ExchangeRate er = IME.ExchangeRates.Where(a => a.date == dtpDate.Value).
                    Where(b => b.currencyId == currencyID).FirstOrDefault();

            if (er != null)
            {
                if (ExchangeRateCheck())
                {
                    er.currencyId = Convert.ToDecimal(cmbCurrency.SelectedValue.ToString());
                    er.date = Convert.ToDateTime(dtpDate.Text.Trim().ToString());
                    er.rate = Convert.ToDecimal(txtExchangeRate.Text.Trim().ToString());
                    er.exchangeRateID = decId;
                    IME.SaveChanges();
                    MessageBox.Show("Exchange Rate updated");
                    SearchClear();
                    Clear();
                }
            }
        }
        /// <summary>
        /// Function to call save or edit
        /// </summary>
        public void SaveOrEdit()
        {
                if (cmbCurrency.SelectedIndex == -1)
                {
                    MessageBox.Show("Select currency");
                    cmbCurrency.Focus();
                }
                else if (txtExchangeRate.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Enter exchange rate");
                    txtExchangeRate.Focus();
                }
                else
                {
                    if (btnSave.Text == "Save")
                    {
                        SaveFunction();

                    }
                    else
                    {
                        Editfunction();
                    }
                }

        }
        /// <summary>
        /// Function to fill Currency combobox
        /// </summary>
        public void CurrencyComboFill()
        {
            //kullanılan tüm currency leri getiriyor(USD,EURO,GBP gibi)

            //dtblCurrency = spCurrency.CurrencyViewAllForExchangeRateCombo();
            cmbCurrency.DataSource = IME.Currencies.ToList();
            cmbCurrency.ValueMember = "currencyId";
            cmbCurrency.DisplayMember = "currencyName";

        }
        /// <summary>
        /// Function to fill Currency combobox
        /// </summary>
        public void CurrencyRateComboFill()
        {
            try
            {
                //DataTable dtblCurrencyRate = new DataTable();
                //CurrencySP spCurrency = new CurrencySP();
                //dtblCurrencyRate = spCurrency.CurrencyViewAllForCombo();
                //DataRow dr = dtblCurrencyRate.NewRow();
                //dr[2] = "All";
                //dtblCurrencyRate.Rows.InsertAt(dr, 0);
                cmbCurrencyRate.DataSource = IME.Currencies.ToList();
                cmbCurrencyRate.ValueMember = "currencyId";
                cmbCurrencyRate.DisplayMember = "currencyName";
            }
            catch (Exception ex)
            {
                MessageBox.Show("ER6:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to clear
        /// </summary>
        public void Clear()
        {
            try
            {
                txtExchangeRate.Clear();
                txtNarration.Clear();
                cmbCurrency.SelectedIndex = -1;
                dtpDate.Value = DateTime.Today;
                dtpDate.MinDate = DateTime.Today;
                dtpDate.MaxDate = DateTime.Today;
                txtDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                btnDelete.Enabled = false;
                pnlExchange.Visible = false;
                btnSave.Text = "Save";
                cmbCurrency.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ER7:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to clear
        /// </summary>
        public void SearchClear()
        {
            try
            {
                cmbCurrencyRate.SelectedIndex = 0;
                //dtpDateTo.MinDate = PublicVariables._dtFromDate;
                //dtpDateTo.MaxDate = PublicVariables._dtToDate;
                //txtDateTo.Text = PublicVariables._dtCurrentDate.ToString("dd-MMM-yyyy");
                //dtpDateFrom.MinDate = PublicVariables._dtFromDate;
                //dtpDateFrom.MaxDate = PublicVariables._dtToDate;
                //txtDatefrom.Text = PublicVariables._dtCurrentDate.ToString("dd-MMM-yyyy");
                cmbCurrencyRate.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ER8:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Function to fill datagridview
        /// </summary>
        public void GridFill()
        {
            var dgExchangeRate = from a in IME.ExchangeRates.Where(a => a.Currency.currencyName == cmbCurrencyRate.Text.ToString())
            .Where(b => b.date == DateTime.Today).ToList() select new
            {
                Date=a.date,
                CurrencyName=a.Currency.currencyName,
                Rate=a.rate,
                ExchangeRateID= a.exchangeRateID,
            };
            dgvExchangeRate.DataSource = dgExchangeRate.ToList();

        }
        /// <summary>
        /// Function to delete
        /// </summary>
        public void DeleteFunction()
        {
            var er = IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault();
            if (er != null)
            {
                IME.ExchangeRates.Remove(er);
                MessageBox.Show("Deleted successfully ");
                Clear();
                GridFill();
            }

        }
        /// <summary>
        /// Function to call delete
        /// </summary>
        public void Delete()
        {

            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to delete this currency?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteFunction();
            }

        }

        //TO DO frmCurrencyDetails formundan bu forma geçişte kullanılacak kod burada
        //public void CallFromCurrenCyDetails(frmCurrencyDetails frmCurrencyDetails, decimal decId) //PopUp
        //{
        //    //try
        //    //{
        //    //    base.Show();
        //    //    this.frmCurrencyObj = frmCurrencyDetails;
        //        CurrencyComboFill();
        //        cmbCurrency.SelectedValue = decId;
        //        cmbCurrency.Focus();
        //}


        public void FillControls()
        {

            //ExchangeRateInfo infoExchangeRate = new ExchangeRateInfo();
            //ExchangeRateP spExchangeRate = new ExchangeRateP();
            // infoExchangeRate = spExchangeRate.ExchangeRateView(decId);
            var infoExchangeRate = IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault();

            //int inNoOfDecimalPlaces = 
            //spExchangeRate.NoOfDecimalNumberViewByExchangeRateId(decId);
            cmbCurrency.SelectedValue = infoExchangeRate.currencyId.ToString();
            dtpDate.Text = infoExchangeRate.date.ToString();
            txtExchangeRate.Text = Convert.ToDecimal(infoExchangeRate.rate.ToString()).ToString();
            //txtExchangeRate.Text = Math.Round(Convert.ToDecimal(infoExchangeRate.Rate.ToString()), inNoOfDecimalPlaces).ToString();
            decExchangeRateId = infoExchangeRate.exchangeRateID;

        }


        public void ReturnFromCurrencyForm(decimal decId)//Form Currency 
        {
                CurrencyRateComboFill();
                CurrencyComboFill();
                if (decId.ToString() != "0")
                {
                    cmbCurrency.SelectedValue = decId;
                }
                else if (strCurrencyName != string.Empty)
                {
                    cmbCurrency.SelectedValue = strCurrencyName;
                }
                else
                {
                    cmbCurrency.SelectedIndex = -1;
                }
                this.Enabled = true;
                cmbCurrency.Focus();
           
        }
        public int GetDecimalCount(decimal val)
        {
            try
            {
                if (val == val * 10)
                {
                    return int.MaxValue; // no decimal.Epsilon I don't use this type enough to know why... this will work
                }
                while (val != Math.Floor(val))
                {
                    val = (val - Math.Floor(val)) * 10;
                    decimalCount++;
                }
                return decimalCount;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public int NoofDecimalPlacesFind()
        //{
        //    int inNoOfDecimalPlaces = 0;
        //    //try
        //    //{
        //    //    ExchangeRateP spExchangeRate = new ExchangeRateP();
        //    //    if (cmbCurrency.SelectedValue != null)
        //    //    {
        //    //        inNoOfDecimalPlaces = spExchangeRate.NoOfDecimalNumberViewByCurrencyId(Convert.ToDecimal(cmbCurrency.SelectedValue.ToString()));
        //    //    }
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    throw;
        //    //}
        //    return inNoOfDecimalPlaces;
        //}
        #endregion
        #region Events


        private void frmExchangeRate_Load(object sender, EventArgs e)
        {
                CurrencyComboFill();
                CurrencyRateComboFill();
                dtpDateTo.Value = DateTime.Today;
                dtpDateTo.MinDate = DateTime.Today;
                dtpDateTo.MaxDate = DateTime.Today;
                txtDateTo.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                dtpDateFrom.Value = DateTime.Today; ;
                dtpDateFrom.MinDate = DateTime.Today.AddYears(-1); 
                dtpDateFrom.MaxDate = DateTime.Today; 
                txtDatefrom.Text = DateTime.Today.ToString("dd-MMM-yyyy");
                Clear();
                GridFill();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrEdit();
            GridFill();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

                Clear();


        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

            Delete();

        }


        private void btnFrmClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
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
            DialogResult dialogResult = MessageBox.Show("Sure", "Are you sure to close this page?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
                GridFill();

        }
        private void btnSearchClear_Click(object sender, EventArgs e)
        {

                SearchClear();
                GridFill();

        }
        /// <summary>
        /// On 'ExchangeRate' textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExchangeRate_TextChanged(object sender, EventArgs e)
        {
            //CurrencySP SpCurrency = new CurrencySP();
            //String strSymbol = SpCurrency.GetDefaultCurrencySymbol();
            if (IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault()!=null)
            {
                var strSymbol = IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault().Currency.currencySymbol;
                pnlExchange.Visible = true;
                lblSymbol.Text = "1" + cmbCurrency.Text;
                lblRate.Text = txtExchangeRate.Text + strSymbol;/*"Rs"*/;
                lblRate.Text = txtExchangeRate.Text;
            }

        }
        /// <summary>
        /// On 'Narration' textbox key enter
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
                    txtNarration.Focus();
                }
                else
                {
                    txtNarration.SelectionStart = txtNarration.Text.Length;
                    txtNarration.Focus();
                }

        }


        private void dgvExchangeRate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                decId = Convert.ToInt32(dgvExchangeRate.Rows[e.RowIndex].Cells["ExchangeRateID"].Value.ToString());
                //TO DO edit past currencies Status 
                bool Status = true;
                if (Status)
                {
                    FillControls();
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    cmbCurrency.Focus();
                }
                else
                {
                    MessageBox.Show("You dont have the privilege");
                }
            }
        }


        private void btnCurrencyAdd_Click(object sender, EventArgs e)
        {
            //TO DO CUrrency ekleme sayfası
            //try
            //{
            //    if (cmbCurrency.SelectedValue != null)
            //    {
            //        strCurrencyName = cmbCurrency.SelectedValue.ToString();
            //    }
            //    else
            //    {
            //        strCurrencyName = string.Empty;
            //    }

            //    frmCurrency frmCurrency = new frmCurrency();
            //    frmCurrency.MdiParent = formMDI.MDIObj;
            //    frmCurrency open = Application.OpenForms["frmCurrency"] as frmCurrency;
            //    if (open == null)
            //    {
            //        frmCurrency.WindowState = FormWindowState.Normal;
            //        frmCurrency.MdiParent = formMDI.MDIObj;
            //        frmCurrency.CallFromExchangerate(this);
            //    }
            //    else
            //    {
            //        open.MdiParent = formMDI.MDIObj;
            //        open.CallFromExchangerate(this);
            //        open.BringToFront();
            //        if (open.WindowState == FormWindowState.Minimized)
            //        {
            //            open.WindowState = FormWindowState.Normal;
            //        }
            //    }
            //    this.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ER26:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void dgvExchangeRate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

                dgvExchangeRate.ClearSelection();

        }



        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

                this.txtDate.Text = this.dtpDate.Value.ToString("dd-MMM-yyyy");

        }


        private void txtDate_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateValidation objDateValidation = new DateValidation();
            //    objDateValidation.DateValidationFunction(txtDate);
            //    if (txtDate.Text == string.Empty)
            //    {
            //        txtDate.Text = PublicVariables._dtCurrentDate.ToString("dd-MMM-yyyy");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ER29:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void txtDateTo_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateValidation objDateValidation = new DateValidation();
            //    objDateValidation.DateValidationFunction(txtDateTo);
            //    if (txtDateTo.Text == string.Empty)
            //    {
            //        txtDateTo.Text = PublicVariables._dtCurrentDate.ToString("dd-MMM-yyyy");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("ER30:" + ex.Message, "OpenMiracle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }


        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {

                this.txtDateTo.Text = this.dtpDateTo.Value.ToString("dd-MMM-yyyy");

        }


        private void txtDatefrom_Leave(object sender, EventArgs e)
        {


            if (txtDatefrom.Text == string.Empty)
            {
                txtDatefrom.Text = DateTime.Today.ToString();
            }
        }


        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {

                this.txtDatefrom.Text = this.dtpDateFrom.Value.ToString("dd-MMM-yyyy");

        }


        private void txtExchangeRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //Common.DecimalValidation(sender, e, false);
            }
            catch
            {
                MessageBox.Show("This is not proper for Rate Value");
            }
        }
        /// <summary>
        /// On 'Date' textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_TextChanged(object sender, EventArgs e)
        {
                if (txtDate.Text.Trim() == string.Empty)
                {
                    txtDate_Leave(sender, e);
                }
        }
        /// <summary>
        /// On 'Date To' textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDateTo_TextChanged(object sender, EventArgs e)
        {
                if (txtDateTo.Text.Trim() == string.Empty)
                {
                    txtDateTo_Leave(sender, e);
                }

        }
        /// <summary>
        /// On 'Date From' textbox textchanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDatefrom_TextChanged(object sender, EventArgs e)
        {
                if (txtDatefrom.Text.Trim() == string.Empty)
                {
                    txtDatefrom_Leave(sender, e);
                }

        }
        /// <summary>
        /// On 'Currency' combobox selected valuechanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCurrency_SelectedValueChanged(object sender, EventArgs e)
        {

            if (IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault()!=null)
            {
                String strSymbol = IME.ExchangeRates.Where(a => a.exchangeRateID == decId).FirstOrDefault().Currency.currencySymbol;
                pnlExchange.Visible = true;
                lblSymbol.Text = "1" + cmbCurrency.Text;
                lblRate.Text = txtExchangeRate.Text + strSymbol;
            }

        }
        #endregion
        #region Navigation
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDate.Focus();
            }
        }
        /// <summary>
        /// On 'ExchangeRate' textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtExchangeRate_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNarration.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtExchangeRate.Text == string.Empty || txtExchangeRate.SelectionStart == 0)
                    {
                        txtDate.Focus();
                        txtDate.SelectionStart = 0;
                        txtDate.SelectionLength = 0;
                    }
                }

        }
        /// <summary>
        /// On 'Narration' textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNarration_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
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
                if (e.KeyCode == Keys.Back)
                {
                    if (txtNarration.Text == string.Empty || txtNarration.SelectionStart == 0)
                    {
                        txtExchangeRate.Focus();
                        txtExchangeRate.SelectionStart = 0;
                        txtExchangeRate.SelectionLength = 0;
                    }
                }
        }
        /// <summary>
        /// On 'Save' button KeyDown
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
        /// On 'Date' textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Enter)
                {
                    txtExchangeRate.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDate.Text == string.Empty || txtDate.SelectionStart == 0)
                    {
                        cmbCurrency.Focus();
                        cmbCurrency.SelectionStart = 0;
                        cmbCurrency.SelectionLength = 0;
                    }
                }

        }
        /// <summary>
        /// On datagridview keyUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvExchangeRate_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (dgvExchangeRate.CurrentRow != null)
                    {
                        DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(dgvExchangeRate.CurrentCell.ColumnIndex, dgvExchangeRate.CurrentCell.RowIndex);
                        dgvExchangeRate_CellDoubleClick(sender, ex);
                    }
                }
                if (e.KeyCode == Keys.Back)
                {
                    txtDatefrom.Focus();
                    txtDatefrom.SelectionLength = 0;
                    txtDatefrom.SelectionStart = 0;
                }

        }
        /// <summary>
        /// On Currency' combobox key down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCurrencyRate_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDateTo.Focus();
                    txtDateTo.SelectionLength = 0;
                    txtDateTo.SelectionStart = 0;
                }

        }
        /// <summary>
        /// On 'Date To' textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDateTo_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Enter)
                {
                    txtDatefrom.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDateTo.Text == string.Empty || txtDateTo.SelectionStart == 0)
                    {
                        cmbCurrencyRate.Focus();
                        cmbCurrencyRate.SelectionStart = 0;
                        cmbCurrencyRate.SelectionLength = 0;
                    }
                }

        }
        /// <summary>
        /// On 'Date From' textbox KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDatefrom_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch.Focus();
                }
                if (e.KeyCode == Keys.Back)
                {
                    if (txtDatefrom.Text == string.Empty || txtDatefrom.SelectionStart == 0)
                    {
                        txtDateTo.Focus();
                        txtDateTo.SelectionStart = 0;
                        txtDateTo.SelectionLength = 0;
                    }
                }
        }
        /// <summary>
        /// On form KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmExchangeRate_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose_Click(sender, e);
                }
                if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control) //Save
                {
                    if (cmbCurrency.Focused)
                    {
                        cmbCurrency.DropDownStyle = ComboBoxStyle.DropDown;
                    }
                    else
                    {
                        cmbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
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
        /// <summary>
        /// On 'Clear'  button KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchClear_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    btnSearch.Focus();
                }
        }
        /// <summary>
        /// On 'Search' button KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Back)
                {
                    txtDatefrom.Focus();
                    txtDatefrom.SelectionLength = 0;
                    txtDatefrom.SelectionStart = 0;
                }
        }
        #endregion
    }
}