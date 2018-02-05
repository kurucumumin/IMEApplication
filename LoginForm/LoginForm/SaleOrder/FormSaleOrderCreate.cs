﻿using LoginForm.DataSet;
using LoginForm.nmSaleOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.nsSaleOrder
{
    public partial class FormSaleOrderCreate : Form
    {
        IMEEntities IME = new IMEEntities();

        List<Customer> customerList = new List<Customer>();
        List<Customer> tempCustomerList = new List<Customer>();

        List<QuotationDetail> itemList = new List<QuotationDetail>();

        public FormSaleOrderCreate()
        {
            InitializeComponent();
        }

        private void FormSaleOrderCustList_Load(object sender, EventArgs e)
        {
            customerList = IME.Customers.ToList();
            PopulateCustomerList(customerList);
        }

        private void PopulateCustomerList(List<Customer> list)
        {
            lbCustomerList.DataSource = list;
            lbCustomerList.ClearSelected();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            tempCustomerList = customerList.Where(c => c.c_name.IndexOf(txtSearchCustomer.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            PopulateCustomerList(tempCustomerList);
        }

        private void lbCustomerList_SelectedValueChanged(object sender, EventArgs e)
        {
            if(lbCustomerList.SelectedValue != null)
            {
                //var dgList = ((Customer)lbCustomerList.SelectedItem).Quotations;
                var dgList = IME.Quotations.Where(q => q.CustomerID == lbCustomerList.SelectedValue.ToString()).ToList();
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
                var quotNo = item.Cells["QuotationNo"].Value.ToString();
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
                    QuotationDetail qd = itemList.Where(x => x.ID == Convert.ToInt32(item.Cells["ID"].Value)).First();
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
                        quotationIDs += " , ";
                    }
                }
                this.Close();
                FormSaleOrderAdd form1 = new FormSaleOrderAdd((Customer)lbCustomerList.SelectedItem, list, quotationIDs);
                //TODO form tekrar açılıp kapatımış. Doğru olan yöntemi bul
                FormSalesOrderMain f = new FormSalesOrderMain();
                f.Close();
                form1.ShowDialog();

            }
            else
            {
                this.Close();
                FormSaleOrderAdd form1 = new FormSaleOrderAdd((Customer)lbCustomerList.SelectedItem);
                //TODO form tekrar açılıp kapatımış. Doğru olan yöntemi bul
                FormSalesOrderMain f = new FormSalesOrderMain();
                f.Close();
                form1.ShowDialog();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgItems.Rows.Count; i++)
            {
                dgItems.Rows[i].Cells[chk.Index].Value = true;
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgItems.Rows.Count; i++)
            {
                dgItems.Rows[i].Cells[chk.Index].Value = false;
            }
        }
    }
}
