using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;
using LoginForm.DataSet;

namespace LoginForm.CustomerManager
{
    public partial class AddressBook : Form
    {
        AddressService AdresService = new AddressService();
        CustomerService CustomerService = new CustomerService();
        public AddressBook()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddressBook_Load(object sender, EventArgs e)
        {
            //cbAddressType.DataSource = AdresService.GetAddressType();
            cbAddressType.DisplayMember = "TypeName";
            cbAddressType.ValueMember = "AddressTypeID";

            cbCustomer.DataSource = CustomerService.GetCustomers();
            cbCustomer.DisplayMember = "c_name";
            cbCustomer.ValueMember = "ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //AddressType Type = new AddressType();
            //Customer CustomerAddress = new Customer();
            //Type = cbAddressType.SelectedItem as AddressType;
            //CustomerAddress = cbCustomer.SelectedItem as Customer;
            //int CustomerID = CustomerAddress.ID;
            //int TypeID = Type.AddressTypeID;
            //string AddressValue = richTextBox1.Text;
            //AdresService.AddNewAddressBook(TypeID, CustomerID, AddressValue);
        }
    }
}
