using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.QuotationModule
{
    public partial class frmEx_Quotation : Form
    {
        IMEEntities IME = new IMEEntities();
        public frmEx_Quotation()
        {
            InitializeComponent();
        }

        private void dg_DoubleClick(object sender, EventArgs e)
        {
            ReturnFunc();
        }

        public void ReturnFunc()
        {
            FormQuotationAdd form = new FormQuotationAdd();
            classQuotationAdd.quotationNo = dg.CurrentRow.Cells[QuoNo.Index].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Do the Prices include quotation ", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                classQuotationAdd.IsWithItems = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                classQuotationAdd.IsWithItems = false;
            }
            this.Close();
        }

        private void dg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReturnFunc();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Quotation> QuoList = new List<Quotation>();

            string quotationNo = null;
            if (txtQuotationno.Text != "" && txtQuotationno.Text != null)
                quotationNo = txtCustomerName.Text;
            string customer = null;
            if (txtCustomerName.Text != "" && txtCustomerName.Text != null)
                customer = txtCustomerName.Text;
            if (rbCustomerName.Checked)
            {
                if(customer!=null)
                    { QuoList = IME.Quotations.Where(a => a.Customer.c_name.Contains(customer)).Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList(); }
                else
                {
                    QuoList = IME.Quotations.Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList();
                }
            }
            else
            {
                if (quotationNo!=null)
                {
                    QuoList = IME.Quotations.Where(a => a.QuotationNo.Contains(quotationNo)).Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList();
                }
                else
                {

                    QuoList = IME.Quotations.Where(a => a.StartDate >= btnStartDate.Value.Date).Where(a=> a.StartDate <= btnEndDate.Value.Date).ToList();
                }
                
            }
            dg.DataSource = null;
            foreach (Quotation item in QuoList)
            {
                DataGridViewRow row = (DataGridViewRow)dg.Rows[0].Clone();
                row.Cells[QuoNo.Index].Value = item.QuotationNo;
                row.Cells[SDCode.Index].Value = item.CustomerID;
                row.Cells[CustomerName.Index].Value = item.Customer.c_name;
                row.Cells[Date.Index].Value = item.StartDate;
                row.Cells[dgTotal.Index].Value = item.GrossTotal;
                dg.Rows.Add(row);

            }
        }

        private void frmEx_Quotation_Load(object sender, EventArgs e)
        {
            btnStartDate.Value = DateTime.Now.AddDays(-7);
            classQuotationAdd.quotationNo = null;
        }
    }
}
