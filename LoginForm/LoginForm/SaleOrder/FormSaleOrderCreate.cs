using LoginForm.DataSet;
using LoginForm.QuotationModule;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.nsSaleOrder
{
    public partial class FormSaleOrderCreate : MyForm
    {
        private static string QuoStatusActive = "Active";
        private static string QuoStatusPassive = "Passive";

        IMEEntities IME = new IMEEntities();

        List<Customer> customerList = new List<Customer>();
        List<Customer> tempCustomerList = new List<Customer>();

        List<QuotationDetail> itemList = new List<QuotationDetail>();

        public FormSaleOrderCreate()
        {
            InitializeComponent();
            dgQuotations.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            dgItems.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
        }

        private void FormSaleOrderCustList_Load(object sender, EventArgs e)
        {
            List<Quotation> QuoList = IME.Quotations.Where(x=>x.status == "Active").ToList();

            foreach (Quotation q in QuoList)
            {
                if(customerList.Where(x=>x.ID == q.Customer.ID).Count() == 0)
                {
                    customerList.Add(q.Customer);
                }
            }
            if(customerList.Count <= 0)
            {
                btnCreate.Enabled = false;
            }

            tempCustomerList = customerList.ToList();
            //lbCustomerList.DataSource = customerList;
            //lbCustomerList.DisplayMember = "c_name";
            lbCustomerList.DataSource = tempCustomerList;
            lbCustomerList.DisplayMember = "c_name";
            //  PopulateCustomerList(customerList);
        }

        private void PopulateCustomerList(List<Customer> list)
        {
            lbCustomerList.DataSource = list;
            lbCustomerList.ClearSelected();
        }

        private void lbCustomerList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(lbCustomerList.SelectedValue != null)
            {
                var dgList = IME.Quotations.Where(q => q.CustomerID == lbCustomerList.SelectedValue.ToString() && q.status == "Active").OrderByDescending(s => s.StartDate).ToList();
                dgQuotations.DataSource = dgList;
                dgQuotations.ClearSelection();
            }
            else
            {
                dgQuotations.DataSource = null;
                dgQuotations.ClearSelection();
            }
        }

        private void dgQuotations_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection quotList = dgQuotations.SelectedRows;
            List<QuotationDetail> tempItemList = new List<QuotationDetail>();

            foreach (DataGridViewRow item in quotList)
            {
                var quotNo = item.Cells[dgQuotationNo.Index].Value.ToString();
                Quotation quot = IME.Quotations.Where(q => q.QuotationNo == quotNo).FirstOrDefault();
                tempItemList.AddRange(quot.QuotationDetails);
            }

            dgItems.DataSource = tempItemList;
            itemList = tempItemList.ToList();
            dgItems.ClearSelection();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<QuotationDetail> list = new List<QuotationDetail>();

            foreach (DataGridViewRow item in dgItems.Rows)
            {
                if(item.Cells[0].Value != null && (bool)item.Cells[0].Value == true)
                {
                    QuotationDetail qd = itemList.Where(x => x.ID == Convert.ToInt32(item.Cells[dgID.Index].Value)).First();
                    list.Add(qd);
                }
            }

            if (list.Count > 0)
            {
                
                List<string> quotationNos = new List<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (quotationNos.Where(x=>x == list[i].QuotationNo).FirstOrDefault() == null)
                    {
                        quotationNos.Add(list[i].QuotationNo);
                    }
                }

                string quotationIDs = String.Empty;
                for (int i = 0; i < quotationNos.Count; i++)
                {
                    quotationIDs += quotationNos[i].ToString();
                    if (i != quotationNos.Count - 1)
                    {
                        quotationIDs += ",";
                    }
                }
                FormSaleOrderAdd form1 = new FormSaleOrderAdd((Customer)lbCustomerList.SelectedItem, list, quotationIDs,1);
                form1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to choose at leaset one item", "Warning", MessageBoxButtons.OK);
            }
        }

        private void txtSearchCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            //int i = 0;
            if (e.KeyCode == Keys.Enter)
            {
                tempCustomerList = customerList.ToList().Where(c => c.c_name.IndexOf(txtSearchCustomer.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                //i++;
                lbCustomerList.DataSource = null;
                lbCustomerList.DataSource = tempCustomerList;
                lbCustomerList.DisplayMember = "c_name";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgItems.Rows.Count; i++)
            {
                dgItems.Rows[i].Cells[chk.Index].Value = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgItems.Rows.Count; i++)
            {
                dgItems.Rows[i].Cells[chk.Index].Value = false;
            }
        }
    }
}
