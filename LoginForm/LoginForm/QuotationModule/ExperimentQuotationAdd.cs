using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class ExperimentQuotationAdd : Form
    {
        Customer _customer;
        ExchangeRate _rate;
        decimal _factor;
        List<CompleteItem> ItemList;
        QuotationUtils qUtils = new QuotationUtils();

        public ExperimentQuotationAdd()
        {
            InitializeComponent();

            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = new IMEEntities().QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";

            ItemList = new List<CompleteItem>();
        }

        private void SetCustomer()
        {
            txtCustomerCode.Text = _customer.ID;
            txtCustomerName.Text = _customer.c_name;

            dtpDate.Value = DateTime.Now;

            if (_customer.CustomerWorkers.Count != 0)
            {
                cbWorkers.ValueMember = "ID";
                cbWorkers.DisplayMember = "cw_name";
                cbWorkers.DataSource = _customer.CustomerWorkers.ToList();
            }

            if (!String.IsNullOrEmpty(_customer.CurrNameQuo))
            {
                cbCurrency.SelectedIndex = cbCurrency.FindStringExact(_customer.CurrNameQuo);
            }

            if (_customer.representaryID != null)
            {
                cbRepresentative.SelectedValue = _customer.representaryID;
            }

            if (_customer.paymentmethodID != null)
            {
                cbPaymentMethod.SelectedValue = _customer.paymentmethodID;
            }

            if (_customer.factor != null)
            {
                _factor = Convert.ToDecimal(_customer.factor);
                txtFactor.Text = _factor.ToString();
            }

            if (_customer.customerNoteID != null)
            {
                txtCustomerNote.Text = _customer.Note.Note_name;
            }

            if (_customer.customerNoteID != null)
            {
                txtCustomerNote.Text = _customer.Note.Note_name;
            }

            if (_customer.Note1 != null)
            {
                txtAccountingNote.Text = _customer.Note1.Note_name;
            }
        }

        private decimal CalculateItemMargin(bool _Pitem, int _UC, int _SSM, decimal _LandingCost, decimal _Price, decimal currencyValue)
        {
            decimal currentGbpValue = Convert.ToDecimal(new IMEEntities().Currencies.Where(x => x.currencyName == "Pound").FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault().rate);

            decimal gbpPrice = (_Price * currencyValue) / currentGbpValue;

            if (_UC > 1 || _SSM > 1)
            {
                if (_UC > 1 && !_Pitem)
                {
                    gbpPrice *= _UC;
                }
                else
                {
                    if (_SSM > 1)
                    {
                        gbpPrice *= _SSM;
                    }
                }
            }

            return (1 - (_LandingCost / gbpPrice)) * 100;
        }

        private void CalculateTotalMargin()
        {
            decimal TotalCost = 0;
            decimal TotalUnitPrice = 0;

            foreach (DataGridViewRow row in dgAddedItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    TotalCost += Convert.ToDecimal(row.Cells[dgCost.Index].Value);
                    TotalUnitPrice += Convert.ToDecimal(row.Cells[dgUCUPCurr.Index].Value);
                }

                txtTotalMarginGrid.Text = qUtils.CalculateMargin(TotalUnitPrice, TotalCost).ToString("G29");
            }
        }

        private void CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgAddedItems.Rows)
            {
                if (!row.IsNewRow)
                {
                    subTotal += Convert.ToDecimal(row.Cells[dgTotal.Index].Value);
                }
            }
            txtSubtotal.Text = subTotal.ToString("G29");
        }

        private void ChangeDate()
        {
            throw new NotImplementedException();
        }

        private void ChangeFactor()
        {
            throw new NotImplementedException();
        }

        private void SetCurrency()
        {
            throw new NotImplementedException();
        }

        //private string CreateNewQuotationNumber()
        //{
        //    throw new NotImplementedException();
        //}
        private void ApplyDiscountOnSubtotal()
        {
            throw new NotImplementedException();
        }

        private void AddExtraCharges()
        {
            throw new NotImplementedException();
        }

        private void ApplyVAT()
        {
            throw new NotImplementedException();
        }

        private void SaveFunction()
        {
            throw new NotImplementedException();
        }

        private void SaveQuotation()
        {
            throw new NotImplementedException();
        }

        private void SaveQuotationDeTails()
        {
            throw new NotImplementedException();
        }

        private void ExperimentQuotationAdd_Load(object sender, EventArgs e)
        {
            Management management = Utils.getManagement();

            lblVat.Text = management.VAT.ToString();
            _factor = management.Factor;
            txtFactor.Text = _factor.ToString();
            dtpDate.Value = DateTime.Today;
            txtValidity.Text = 3.ToString();

            FillComboBoxes();

        }

        private void FillComboBoxes()
        {
            IMEEntities db = new IMEEntities();

            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
            cbCurrency.DataSource = db.Currencies.ToList();
            cbCurrency.SelectedValue = Utils.getManagement().DefaultCurrency;

            cbPaymentMethod.DisplayMember = "term_name";
            cbPaymentMethod.ValueMember = "ID";
            cbPaymentMethod.DataSource = db.PaymentTerms.ToList();

            cbRepresentative.DisplayMember = "NameLastName";
            cbRepresentative.ValueMember = "WorkerID";
            cbRepresentative.DataSource = db.Workers.ToList();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                List<Customer> customerList = new IMEEntities().Customers.
                    Where(x => x.c_name.Contains(txtCustomerCode.Text)).
                    ToList();

                if (customerList.Count == 1)
                {
                    _customer = customerList.FirstOrDefault();
                    SetCustomer();
                }
                else
                {
                    FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(txtCustomerCode.Text);
                    this.Enabled = false;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _customer = form.customer;
                        SetCustomer();
                    }
                    this.Enabled = true;
                }
            }
        }

        private void txtCustomerCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            List<Customer> custList = new IMEEntities().Customers.
                    Where(x => x.c_name.Contains(txtCustomerCode.Text)).
                    ToList();

            if (custList.Count == 1)
            {
                _customer = custList.FirstOrDefault();
                SetCustomer();
            }
            else
            {
                FormQuaotationCustomerSearch form = new FormQuaotationCustomerSearch(txtCustomerCode.Text);
                this.Enabled = false;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    _customer = form.customer;
                    SetCustomer();
                }
                this.Enabled = true;
            }
        }

        private void cbWorkers_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbWorkers.SelectedItem != null)
            {
                CustomerWorker cw = cbWorkers.SelectedItem as CustomerWorker;

                txtContactNote.Text = cw.Note.Note_name;
            }
        }

        private void cbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurrency.SelectedIndex != -1)
            {
                Currency currency = cbCurrency.SelectedItem as Currency;
                _rate = currency.ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();
                lblExcRate.Text = _rate.rate.ToString();
            }
        }

        private void dgAddedItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewCell cell = dgAddedItems.Rows[e.RowIndex - 1].Cells[dgDelivery.Index];
            cell.Value = 3;
        }

        private void dgAddedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgAddedItems.Rows[e.RowIndex];

            switch (e.ColumnIndex)
            {
                #region ItemCode
                case ((int)GridColumns.ItemCode):
                    if (row.Cells[e.ColumnIndex].Value != null)
                    {
                        IMEEntities db = new IMEEntities();

                        //Fixes article number that entered
                        string _itemCode = FixItemCode(row.Cells[e.ColumnIndex].Value.ToString());
                        row.Cells[e.ColumnIndex].Value = _itemCode;

                        List<CompleteItem> items = db.CompleteItems.Where(x => x.Article_No.Contains(_itemCode)).ToList();
                        switch (items.Count)
                        {
                            case 0:
                                MessageBox.Show("There is no item that contains article no '" + _itemCode + "'");
                                dgAddedItems.Rows.Remove(row);

                                break;
                            case 1:
                                CompleteItem item1 = items.FirstOrDefault();
                                List<CompleteItem> MPN_Items = db.CompleteItems.Where(x => x.MPN == item1.MPN).ToList();

                                if (MPN_Items.Count == 1)
                                {
                                    InsertItemToQuotation(row, db, item1);
                                }
                                else
                                {
                                    FormQuotationMPN formMPN = new FormQuotationMPN(this, MPN_Items);
                                    formMPN.ShowDialog();
                                    if (!String.IsNullOrEmpty(formMPN.ItemCode))
                                    {
                                        item1 = db.CompleteItems.Where(x => x.Article_No == formMPN.ItemCode).FirstOrDefault();
                                        InsertItemToQuotation(row, db, item1);
                                    }
                                }
                                break;
                            default:

                                FormQuotationItemSearch form = new FormQuotationItemSearch(_itemCode, items);
                                if (form.ShowDialog() == DialogResult.OK)
                                {
                                    CompleteItem item2 = db.CompleteItems.Where(x => x.Article_No == form.ItemCode).FirstOrDefault();
                                    InsertItemToQuotation(row, db, item2);
                                }
                                else
                                {
                                    MessageBox.Show("No item selected");
                                    dgAddedItems.Rows.Remove(row);
                                }
                                break;
                        }
                    }
                    break;
                #endregion
                #region Quantity
                case ((int)GridColumns.Quantity):
                    DataGridViewCell cell = row.Cells[dgQty.Index];
                    if (!row.IsNewRow && !String.IsNullOrEmpty(cell.Value?.ToString()))
                    {
                        string txtQty = cell.Value.ToString();
                        int ssm = Convert.ToInt32(row.Cells[dgSSM.Index].Value);
                        int uc = Convert.ToInt32(row.Cells[dgUC.Index].Value);
                        if (!Int32.TryParse(txtQty, out int qty))
                        {
                            MessageBox.Show("You Should Enter An Integer Number");
                            cell.Value = null;
                        }
                        else if (qty == 0)
                        {
                            MessageBox.Show("You Can Not Enter '0' As Quantity");
                            cell.Value = null;
                        }
                        else
                        {
                            if (!(qty % uc == 0))
                            {
                                MessageBox.Show("You Should Enter An Integer Multiple Of UC");
                                cell.Value = null;
                            }
                            else if (!(qty % ssm == 0))
                            {
                                MessageBox.Show("You Should Enter An Integer Multiple Of SSM");
                                cell.Value = null;
                            }
                            else
                            {
                                //Fiyat hesapla ve satırdaki fiyat alanlarını değiştir.

                                decimal price = Decimal.Parse(BringBreakPointPrices(qty));
                                decimal oldPrice = Convert.ToDecimal(row.Cells[dgUPIME.Index].Value);
                                if (oldPrice.ToString("G29") != price.ToString("G29"))
                                {
                                    row.Cells[dgUPIME.Index].Value = price.ToString("G29");
                                    row.Cells[dgUCUPCurr.Index].Value = price.ToString("G29");
                                }
                                decimal ucUpCurr = Convert.ToDecimal(row.Cells[dgUCUPCurr.Index].Value);
                                row.Cells[dgTotal.Index].Value = ((decimal)(ucUpCurr * qty)).ToString("G29");
                                decimal unitWeight = Convert.ToDecimal(row.Cells[dgUnitWeigt.Index].Value);
                                row.Cells[dgTotalWeight.Index].Value = ((decimal)(unitWeight * qty)).ToString("G29");

                                row.Cells[dgDelivery.Index].ReadOnly = false;
                                row.Cells[dgUCUPCurr.Index].ReadOnly = false;
                                row.Cells[dgTargetUP.Index].ReadOnly = false;
                                row.Cells[dgCompetitor.Index].ReadOnly = false;

                                CalculateTotalMargin();
                                CalculateSubTotal();

                                dgAddedItems.CurrentCell = row.Cells[dgUCUPCurr.Index];
                                SendKeys.Send("{UP}");
                            }
                        }
                    }

                    break;
                #endregion
                #region Price
                case (int)GridColumns.Price:
                    DataGridViewCell cell1 = row.Cells[e.ColumnIndex];
                    string currPrice = cell1.Value?.ToString();

                    if (!row.IsNewRow && !String.IsNullOrEmpty(currPrice))
                    {
                        if (!Decimal.TryParse(currPrice, out decimal price))
                        {
                            MessageBox.Show("You Should Enter A Number");
                            cell1.Value = null;
                        }
                        else
                        {
                            decimal landingCost = Convert.ToDecimal(row.Cells[dgLandingCost.Index].Value);
                            decimal upIme = Convert.ToDecimal(row.Cells[dgUPIME.Index].Value);
                            decimal qty = Convert.ToDecimal(row.Cells[dgQty.Index].Value);
                            row.Cells[dgMargin.Index].Value = qUtils.CalculateMargin(price, landingCost);
                            row.Cells[dgDisc.Index].Value = (100 - ((price / upIme) * 100)).ToString("G29");
                            row.Cells[dgTotal.Index].Value = (price * qty).ToString("G29");

                            dgAddedItems.CurrentCell = dgAddedItems.Rows[e.RowIndex + 1].Cells[dgProductCode.Index];

                            CalculateTotalMargin();
                            CalculateSubTotal();
                        }
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void InsertItemToQuotation(DataGridViewRow row, IMEEntities db, CompleteItem item)
        {
            ItemList.Add(item);
            foreach (DataGridViewCell cell in row.Cells)
            {
                switch (cell.ColumnIndex)
                {
                    case (int)GridColumns.ItemCode:

                        break;
                    case (int)GridColumns.No:

                        break;
                    case (int)GridColumns.Delivery:
                        cell.Value = 3;
                        cell.ReadOnly = true;
                        break;
                    default:
                        cell.Value = null;
                        cell.ReadOnly = true;
                        break;
                }

            }
            ItemDetailFill_Row(item, row);

            if (tabControl1.SelectedTab != tabItemDetails)
            {
                tabControl1.SelectedTab = tabItemDetails;
                ItemDetailFill_Tab(item);
                dgAddedItems.Focus();
            }

            if (item.Col1Break != null)
            {
                row.Cells[dgQty.Index].ReadOnly = false;
                dgAddedItems.CurrentCell = row.Cells[dgQty.Index];
                SendKeys.Send("{UP}");
            }
            else
            {
                MessageBox.Show("Item does not have a price!\nPrice values shold be entered manually", "Priceless Item");
                row.Cells[dgCost.Index].ReadOnly = false;
                row.Cells[dgUCUPCurr.Index].ReadOnly = false;
            }
        }

        private enum GridColumns
        {
            No = 0,
            ItemCode = 7,
            Quantity = 15,
            Price = 22,
            Delivery = 29
        }

        private string FixItemCode(string _itemCode)
        {
            string result = _itemCode.Replace("-", "");

            if (Int32.TryParse(result, out int x) && result.Length == 6)
            {
                result = "0" + result;
            }
            return result;
        }

        private void dgAddedItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgAddedItems.Rows[e.RowIndex];

            if (!row.IsNewRow && !String.IsNullOrEmpty(row.Cells[dgProductCode.Index].Value?.ToString()))
            {
                CompleteItem item = ItemList.Where(x => x.Article_No == row.Cells[dgProductCode.Index].Value.ToString()).FirstOrDefault();
                ItemDetailFill_Tab(item);
            }
        }

        private void ItemDetailFill_Tab(CompleteItem item)
        {
            if (tabControl1.SelectedTab == tabItemDetails)
            {
                txtManufacturer.Text = item.Manufacturer ?? "";
                txtBrand.Text = item.BrandName ?? "";
                txtSupersectionName.Text = item.SupersectionName ?? "";
                //txtSection.Text = item.Section ?? "";
                txtMHCodeLevel1.Text = item.MH_Code_Level_1 ?? "";
                txtCofO.Text = item.CofO ?? "";
                txtCCCN.Text = (item.CCCN_No != null) ? item.CCCN_No.ToString() : "";

                //txtItemNote.Text = item.Note ?? "";
                //txtIME01.Text = item.IME01;
                //txtIME02.Text = item.IME02;
                //txtIME03.Text = item.IME03;
                //txtIME04.Text = item.IME04;
                //txtOnOrder.Text = item.OnOrder;
                //txtGB01_a.Text = item.GB01_a;
                //txtGB01_b.Text = item.GB01_b;
                //txtOnOrder_a = item.OnOrder_a;
                //txtOnOrder_b = item.OnOrder_b;

                txtHazardousInd.BackColor = (!String.IsNullOrEmpty(item.Hazardous_Ind) && item.Hazardous_Ind == "Y") ? Color.Red : Color.Empty;
                if (item.Environment != null)
                {
                    txtEnvironment.BackColor = Color.Maroon;
                    txtEnvironment.Text = item.Environment.ToString();
                }
                else
                {
                    txtEnvironment.BackColor = Color.Empty;
                    txtEnvironment.Text = "";
                }
                if (!String.IsNullOrEmpty(item.Shipping))
                {
                    txtShipping.BackColor = Color.Red;
                    txtShipping.Text = item.Shipping;
                }
                else
                {
                    txtShipping.BackColor = Color.Empty;
                    txtShipping.Text = "";
                }
                if (!String.IsNullOrEmpty(item.Lithium))
                {
                    txtLithium.BackColor = Color.DodgerBlue;
                    txtLithium.Text = item.Lithium;
                }
                else
                {
                    txtLithium.BackColor = Color.Empty;
                    txtLithium.Text = "";
                }
                if (!String.IsNullOrEmpty(item.Calibration_Ind) && item.Calibration_Ind != "N")
                {
                    txtCalibrationInd.BackColor = Color.SeaGreen;
                }
                else
                {
                    txtCalibrationInd.BackColor = Color.Empty;
                }
                if (!String.IsNullOrEmpty(item.LicenceType))
                {
                    txtLicenceType.BackColor = Color.SeaGreen;
                }
                else
                {
                    txtLicenceType.BackColor = Color.Empty;
                }
                if (!String.IsNullOrEmpty(item.Disc_Change_Ind))
                {
                    txtDiscChange.BackColor = Color.SeaGreen;
                    txtDiscChange.Text = item.Disc_Change_Ind;
                }
                else
                {
                    txtDiscChange.BackColor = Color.Empty;
                    txtDiscChange.Text = "";
                }
                if (!String.IsNullOrEmpty(item.Expiring_Product_Change_Ind))
                {
                    txtExpiringPro.BackColor = Color.SeaGreen;
                    txtExpiringPro.Text = item.Expiring_Product_Change_Ind;
                }
                else
                {
                    txtExpiringPro.BackColor = Color.Empty;
                    txtExpiringPro.Text = "";
                }

                txtUKDiscDate.Text = item.Uk_Disc_Date ?? "";
                txtDiscontinuationDate.Text = item.DiscontinuationDate ?? "";
                //txtSubstitutedBy.Text = item.substitutedBy;
                txtRunOn.Text = (item.Runon != null) ? item.Runon.ToString() : "";
                txtReferral.Text = (item.Referral != null) ? item.Referral.ToString() : "";
                //txtPP.Text = item.PP;
                txtHeight.Text = ((decimal)(item.Heigh * (decimal)100)).ToString("G29");
                txtWidth.Text = ((decimal)(item.Width * (decimal)100)).ToString("G29");
                txtLength.Text = ((decimal)(item.Length * (decimal)100)).ToString("G29");
                txtStandardWeight.Text = (item.Standard_Weight != null) ? ((decimal)(item.Standard_Weight / 1000)).ToString("G29") : "";
                //txtGrossWeight.Text = item.GrossWeight;

                if (item.Col1Break != null && item.Col1Break != 0)
                {
                    txtCol1Break.Text = item.Col1Break.ToString();
                    txtUK1.Text = ((decimal)item.Col1Price).ToString("G29");
                    decimal web1 = (decimal)item.Col1Price * _factor /*CalculatePriceWithCurrency(item.Col1Price * _factor)*/;
                    txtWeb1.Text = web1.ToString();
                    txtCost1.Text = item.DiscountedPrice1.ToString();
                    txtMargin1.Text = qUtils.CalculateMargin(web1, (decimal)item.DiscountedPrice1).ToString();
                }
                else
                {
                    txtCol1Break.Text = "0";
                    txtUK1.Text = "0";
                    txtWeb1.Text = "0";
                    txtCost1.Text = "0";
                    txtMargin1.Text = "0";
                }

                if (item.Col2Break != null && item.Col2Break != 0)
                {
                    txtCol2Break.Text = item.Col2Break.ToString();
                    txtUK2.Text = item.Col2Price.ToString();
                    decimal web2 = (decimal)item.Col2Price * _factor /*CalculatePriceWithCurrency(item.Col1Price * _factor)*/;
                    txtWeb2.Text = web2.ToString();
                    txtCost2.Text = item.DiscountedPrice2.ToString();
                    txtMargin2.Text = qUtils.CalculateMargin(web2, (decimal)item.DiscountedPrice2).ToString();
                }
                else
                {
                    txtCol2Break.Text = "0";
                    txtUK2.Text = "0";
                    txtWeb2.Text = "0";
                    txtCost2.Text = "0";
                    txtMargin2.Text = "0";
                }

                if (item.Col3Break != null && item.Col3Break != 0)
                {
                    txtCol3Break.Text = item.Col3Break.ToString();
                    txtUK3.Text = item.Col3Price.ToString();
                    decimal web3 = (decimal)item.Col3Price * _factor /*CalculatePriceWithCurrency(item.Col3Price * _factor)*/;
                    txtWeb3.Text = web3.ToString();
                    txtCost3.Text = item.DiscountedPrice3.ToString();
                    txtMargin3.Text = qUtils.CalculateMargin(web3, (decimal)item.DiscountedPrice3).ToString();
                }
                else
                {
                    txtCol3Break.Text = "0";
                    txtUK3.Text = "0";
                    txtWeb3.Text = "0";
                    txtCost3.Text = "0";
                    txtMargin3.Text = "0";
                }

                if (item.Col4Break != null && item.Col4Break != 0)
                {
                    txtCol4Break.Text = item.Col4Break.ToString();
                    txtUK4.Text = item.Col4Price.ToString();
                    decimal web4 = (decimal)item.Col4Price * _factor /*CalculatePriceWithCurrency(item.Col4Price * _factor)*/;
                    txtWeb4.Text = web4.ToString();
                    txtCost4.Text = item.DiscountedPrice4.ToString();
                    txtMargin4.Text = qUtils.CalculateMargin(web4, (decimal)item.DiscountedPrice4).ToString();
                }
                else
                {
                    txtCol4Break.Text = "0";
                    txtUK4.Text = "0";
                    txtWeb4.Text = "0";
                    txtCost4.Text = "0";
                    txtMargin4.Text = "0";
                }

                if (item.Col5Break != null && item.Col5Break != 0)
                {
                    txtCol5Break.Text = item.Col5Break.ToString();
                    txtUK5.Text = item.Col5Price.ToString();
                    decimal web5 = (decimal)item.Col5Price * _factor /*CalculatePriceWithCurrency(item.Col5Price * _factor)*/;
                    txtWeb5.Text = web5.ToString();
                    txtCost5.Text = item.DiscountedPrice5.ToString();
                    txtMargin5.Text = qUtils.CalculateMargin(web5, (decimal)item.DiscountedPrice5).ToString();
                }
                else
                {
                    txtCol5Break.Text = "0";
                    txtUK5.Text = "0";
                    txtWeb5.Text = "0";
                    txtCost5.Text = "0";
                    txtMargin5.Text = "0";
                }
            }
        }

        private void ItemDetailFill_Row(CompleteItem item, DataGridViewRow row)
        {
            if (!String.IsNullOrEmpty(item.Shipping))
            {
                row.Cells[HS.Index].Style.BackColor = Color.Red;
                row.Cells[HS.Index].Value = item.Shipping;
            }
            else
            {
                row.Cells[HS.Index].Style.BackColor = Color.Empty;
                row.Cells[HS.Index].Value = "";
            }

            if (!String.IsNullOrEmpty(item.Lithium))
            {
                row.Cells[LI.Index].Style.BackColor = Color.DodgerBlue;
                row.Cells[LI.Index].Value = item.Lithium;
            }
            else
            {
                row.Cells[LI.Index].Style.BackColor = Color.Empty;
                row.Cells[LI.Index].Value = "";
            }

            if (!String.IsNullOrEmpty(item.Calibration_Ind) && item.Calibration_Ind != "N")
            {
                row.Cells[CL.Index].Style.BackColor = Color.SeaGreen;
            }
            else
            {
                row.Cells[CL.Index].Style.BackColor = Color.Empty;
            }

            if (!String.IsNullOrEmpty(item.LicenceType))
            {
                row.Cells[LC.Index].Style.BackColor = Color.SeaGreen;
            }
            else
            {
                row.Cells[LC.Index].Style.BackColor = Color.Empty;
            }

            row.Cells[dgSupplier.Index].Value = "RS UK";
            row.Cells[dgProductCode.Index].Value = item.Article_No;
            row.Cells[dgBrand.Index].Value = item.BrandName ?? "";
            row.Cells[dgMPN.Index].Value = item.MPN ?? "";
            row.Cells[dgDesc.Index].Value = item.Article_Desc ?? "";

            if (item.Col1Break != null)
            {
                decimal landingCost = qUtils.CalculateLandingCost((decimal)item.DiscountedPrice1, (decimal)item.Standard_Weight / 1000);
                row.Cells[dgLandingCost.Index].Value = landingCost.ToString("N2");
                row.Cells[dgUPIME.Index].Value = ((decimal)(item.Col1Price * _factor)).ToString("G29");
                row.Cells[dgMargin.Index].Value = qUtils.CalculateMargin(
                                                   Convert.ToDecimal(row.Cells[dgUPIME.Index].Value),
                                                   landingCost);
            }

            row.Cells[dgUKPrice.Index].Value = item.Col1Price?.ToString();
            row.Cells[dgCost.Index].Value = item.DiscountedPrice1?.ToString() ?? "";
            row.Cells[dgQty.Index].Value = "0";

            //row.Cells[dgStock.Index].Value =
            row.Cells[dgUOM.Index].Value = (!String.IsNullOrEmpty(item.Unit_Measure)) ? item.Unit_Measure : "EACH";
            row.Cells[dgSSM.Index].Value = item.Pack_Quantity?.ToString() ?? "1";
            row.Cells[dgUC.Index].Value = item.Unit_Content?.ToString() ?? "1";
            row.Cells[dgUCUPCurr.Index].Value = row.Cells[dgUPIME.Index].Value?.ToString();
            row.Cells[dgTotal.Index].Value = "0";

            if (!String.IsNullOrEmpty(item.Hazardous_Ind) || item.Hazardous_Ind != "N")
            {
                row.Cells[dgHZ.Index].Style.BackColor = Color.Red;
                row.Cells[dgHZ.Index].Value = item.Hazardous_Ind;
            }
            else
            {
                row.Cells[LI.Index].Style.BackColor = Color.Empty;
                row.Cells[LI.Index].Value = "";
            }

            row.Cells[dgUnitWeigt.Index].Value = ((decimal)(item.Standard_Weight / (decimal)1000)).ToString("G29");
            row.Cells[dgTotalWeight.Index].Value = "0";

            row.Cells[dgCOO.Index].Value = item.CofO ?? "";
            row.Cells[dgCCCNO.Index].Value = item.CCCN_No?.ToString() ?? "";
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabItemDetails)
            {
                if (!(dgAddedItems.CurrentRow == null) && !dgAddedItems.CurrentRow.IsNewRow)
                {
                    string articleNo = dgAddedItems.CurrentRow.Cells[dgProductCode.Index].Value.ToString();
                    CompleteItem item = ItemList.Where(x => x.Article_No == articleNo).FirstOrDefault();
                    ItemDetailFill_Tab(item);
                }
            }
        }

        private string BringBreakPointPrices(decimal adet)
        {
            if (Convert.ToDecimal(txtCol1Break.Text) <= adet && (adet < Convert.ToDecimal(txtCol2Break.Text) || Convert.ToDecimal(txtCol2Break.Text) == 0))
            {
                return String.Format("{0:0.0000}", Decimal.Parse(txtWeb1.Text)).ToString();
            }
            else if (Convert.ToDecimal(txtCol2Break.Text) <= adet && (adet < Convert.ToDecimal(txtCol3Break.Text) || Convert.ToDecimal(txtCol3Break.Text) == 0))
            {
                return String.Format("{0:0.0000}", Decimal.Parse(txtWeb2.Text)).ToString();
            }
            else if (Convert.ToDecimal(txtCol3Break.Text) <= adet && (adet < Convert.ToDecimal(txtCol4Break.Text) || Convert.ToDecimal(txtCol4Break.Text) == 0))
            {
                return String.Format("{0:0.0000}", Decimal.Parse(txtWeb3.Text)).ToString();
            }
            else if (Convert.ToDecimal(txtCol4Break.Text) <= adet && (adet < Convert.ToDecimal(txtCol5Break.Text) || Convert.ToDecimal(txtCol5Break.Text) == 0))
            {
                return String.Format("{0:0.0000}", Decimal.Parse(txtWeb4.Text)).ToString();
            }
            else if (Convert.ToDecimal(txtCol5Break.Text) <= adet)
            {
                return String.Format("{0:0.0000}", Decimal.Parse(txtWeb5.Text)).ToString();
            }
            else
            {
                return "NoPrice";
            }
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal _subtotal = Decimal.Parse(txtSubtotal.Text);
            decimal _discountAmount = Decimal.Parse(txtTotalDiscAmount.Text);

            if (txtTotalDiscAmount.Text != "0")
            {
                lblTotal.Text = _subtotal.ToString();
            }
            else
            {
                _discountAmount = Decimal.Parse(txtTotalDiscAmount.Text);
                lblTotal.Text = (_subtotal - _discountAmount).ToString();
            }
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            decimal _total = Decimal.Parse(lblTotal.Text);

            if(!String.IsNullOrEmpty(txtExtraCharges.Text))
            {
                decimal _extraCharges = Decimal.Parse(txtExtraCharges.Text);
                lblTotalExtra.Text = (_total + _extraCharges).ToString();
            }
            else
            {
                lblTotalExtra.Text = _total.ToString();
            }
        }

        private void lblTotalExtra_TextChanged(object sender, EventArgs e)
        {
            decimal _totalExtra = Decimal.Parse(lblTotalExtra.Text);
            decimal _VatAmount = (_totalExtra * (decimal)Utils.getManagement().VAT) / 100;

            lblVatTotal.Text = _VatAmount.ToString();

            if (chkVat.Checked == true)
            {
                lblGrossTotal.Text = (_totalExtra + _VatAmount).ToString();
            }
            else
            {
                lblGrossTotal.Text = _totalExtra.ToString();
            }
        }

        private void lblVatTotal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
