using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class frmQuotOrders : DevExpress.XtraEditors.XtraForm
    {
        IMEEntities IME = new IMEEntities();

        public frmQuotOrders()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgItemList, new object[] { true });

            #region Combobox

            cmbCustomer.DataSource = IME.Customers.ToList();
            cmbCustomer.DisplayMember = "c_name";
            cmbCustomer.ValueMember = "ID";

            cmbCity.DataSource = IME.Cities.ToList();
            cmbCity.DisplayMember = "City_name";
            cmbCity.ValueMember = "ID";

            #endregion
        }

        private void ItemSelect()
        {
            int year = Convert.ToInt32(cmbYear.GetItemText((cmbYear.SelectedItem)));
            int month = cmbMonth.SelectedIndex + 1;
            #region List Birleştirme
            
            var gridAdapterPC = (from a in IME.Quotation_Month(month, year)
                                 select new
                                 {
                                     Year = cmbYear.GetItemText((cmbYear.SelectedItem)),
                                     Month = cmbMonth.GetItemText((cmbMonth.SelectedItem)),
                                     QuotationTotal = a.SumTotal,
                                     QuotationQty = a.SumQty
                                 }
                         ).ToList();

            #endregion
            dgItemList.DataSource = gridAdapterPC;
            for (int i = 0; i < dgItemList.ColumnCount; i++)
            {
                dgItemList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ItemSelect();
        }
    }
}