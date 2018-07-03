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

        public ExperimentQuotationAdd()
        {
            InitializeComponent();
            DataGridViewComboBoxColumn deliveryColumn = (DataGridViewComboBoxColumn)dgAddedItems.Columns[dgDelivery.Index];
            deliveryColumn.DataSource = new IMEEntities().QuotationDeliveries.ToList();
            deliveryColumn.DisplayMember = "DeliveryName";
            deliveryColumn.ValueMember = "ID";


        }

        private void SetCustomer()
        {
            txtCustomerCode.Text = _customer.ID;
            txtCustomerName.Text = _customer.c_name;

            dtpDate.Value = DateTime.Now;

            if(_customer.CustomerWorkers.Count != 0)
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

            if(_customer.paymentmethodID != null)
            {
                cbPaymentMethod.SelectedValue = _customer.paymentmethodID;
            }

            if(_customer.factor != null)
            {
                _factor = Convert.ToDecimal(_customer.factor);
                txtFactor.Text = _factor.ToString();
            }

            if(_customer.customerNoteID != null)
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

        private void CalculateLandingCost(string CustomerName)
        {
            throw new NotImplementedException();
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

        private decimal CalculateTotalMargin()
        {
            throw new NotImplementedException();
        }

        private void CalculateSubTotal()
        {
            throw new NotImplementedException();
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

        private string CreateNewQuotationNumber()
        {
            throw new NotImplementedException();
        }

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

                if(customerList.Count == 1)
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
            if(cbWorkers.SelectedItem != null)
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
            DataGridViewCell cell = dgAddedItems.Rows[e.RowIndex-1].Cells[dgDelivery.Index];
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


                        List<CompleteItem> itemList = db.CompleteItems.Where(x => x.Article_No.Contains(_itemCode)).ToList();
                        switch (itemList.Count)
                        {
                            case 0:
                                MessageBox.Show("There is no item that contains article no '" + _itemCode + "'");
                                row.Cells[e.ColumnIndex].Value = String.Empty;

                                break;
                            case 1:
                                CompleteItem item = itemList.FirstOrDefault();
                                List<CompleteItem> MPN_Items = db.CompleteItems.Where(x => x.MPN == item.MPN).ToList();

                                if (MPN_Items.Count == 1)
                                {
                                    FillItemDetails(item, e.RowIndex);
                                }
                                else
                                {
                                    MessageBox.Show("There are " + MPN_Items.Count + " items with MPN:" + item.MPN, "MPN List");
                                    //Send MPN items to a list to choose among
                                }
                                break;
                            default:
                                MessageBox.Show(itemList.Count.ToString());
                                break;
                        }

                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void FillItemDetails(CompleteItem item, int RowIndex)
        {
            //ItemDetailFill_Row(item,RowIndex);
            ItemDetailFill_Tab(item);
        }

        private void ItemDetailFill_Tab(CompleteItem item)
        {
            txtManufacturer.Text = item.Manufacturer ?? "";
            txtBrand.Text = item.BrandName ?? "";
            txtSupersectionName.Text = item.SupersectionName ?? "";
            //txtSection.Text = item.Section ?? "";
        }

        private enum GridColumns
        {
            ItemCode = 7,
            Quantity = 14,
            Price = 21
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
    }
}
