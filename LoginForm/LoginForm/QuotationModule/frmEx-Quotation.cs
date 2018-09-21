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
        public Quotation quo;
        IMEEntities IME = new IMEEntities();
        public frmEx_Quotation()
        {
            InitializeComponent();
        }

        public void ReturnFunc()
        {
            if (dg.CurrentRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to import prices", "", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    string QuotationNo = dg.CurrentRow.Cells[QuoNo.Index].Value.ToString();

                    IMEEntities IME = new IMEEntities();
                    try
                    {
                        quo = IME.Quotations.Where(q => q.QuotationNo == QuotationNo).FirstOrDefault();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    if (quo != null)
                    {
                        this.Close();
                        //FormQuotationAdd newForm =  new FormQuotationAdd(quo, "a");
                        //newForm.Show();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
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
            search();
        }

        private void search()
        {
            List<Quotation> QuoList = new List<Quotation>();
            dg.Rows.Clear();
            dg.Refresh();


            string quotationNo = null;
            if (txtQuotationno.Text != "" && txtQuotationno.Text != null)
                quotationNo = txtQuotationno.Text;
            string customer = null;
            if (txtCustomerName.Text != "" && txtCustomerName.Text != null)
                customer = txtCustomerName.Text;
            if (rbCustomerName.Checked)
            {
                if (customer != null)
                { QuoList = IME.Quotations.Where(a => a.Customer.c_name.Contains(customer)).Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList(); }
                else
                {
                    QuoList = IME.Quotations.Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList();
                }
            }
            else
            {
                if (quotationNo != null)
                {
                    QuoList = IME.Quotations.Where(a => a.StartDate >= btnStartDate.Value && a.StartDate <= btnEndDate.Value).ToList();
                    QuoList = QuoList.Where(a => a.QuotationNo.Substring(a.QuotationNo.LastIndexOf('/')).Contains(quotationNo)).ToList();
                }
                else
                {

                    QuoList = IME.Quotations.Where(a => a.StartDate >= btnStartDate.Value.Date).Where(a => a.StartDate <= btnEndDate.Value.Date).ToList();
                }

            }
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
            QuotationUtils.quotationNo = null;
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }

        private void txtQuotationno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }

        private void dg_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReturnFunc();
        }
    }
}
