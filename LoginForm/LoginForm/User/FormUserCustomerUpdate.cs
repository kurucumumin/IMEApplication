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

namespace LoginForm.User
{
    public partial class FormUserCustomerUpdate : Form
    {
        IMEEntities IME = new IMEEntities();

        List<Customer> updCustomer = new List<Customer>();
        List<Customer> addCustomer = new List<Customer>();
     
        List<Customer> tempUpdCustomer = new List<Customer>();
        List<Customer> tempAddCustomer = new List<Customer>();

        public FormUserCustomerUpdate()
        {
            InitializeComponent();
        }

        private void FormUserCustomerUpdate_Load(object sender, EventArgs e)
        {
            cmbCustomerAdd.DisplayMember = "NameLastName";
            cmbCustomerAdd.ValueMember = "WorkerID";
            cmbCustomerAdd.DataSource = IME.Workers.ToList();
            cmbCustomerUpdate.DisplayMember = "NameLastName";
            cmbCustomerUpdate.ValueMember = "WorkerID";
            cmbCustomerUpdate.DataSource = IME.Workers.ToList();
        }

        private void cmbCustomerUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomerUpdateList();
        }

        private void CustomerUpdateList()
        {
            updCustomer.Clear();
            updCustomer.AddRange(((Worker)cmbCustomerUpdate.SelectedItem).Customers1);

            clbCustomerUpdate.DataSource = null;
            clbCustomerUpdate.DataSource = updCustomer;
            clbCustomerUpdate.ValueMember = "ID";
            clbCustomerUpdate.DisplayMember = "c_name";
        }

        private void CustomerAddList()
        {
            addCustomer.Clear();
            addCustomer.AddRange(((Worker)cmbCustomerAdd.SelectedItem).Customers1);
            clbCustomerAdd.DataSource = null;

            clbCustomerAdd.DataSource = addCustomer;
            clbCustomerAdd.ValueMember = "ID";
            clbCustomerAdd.DisplayMember = "c_name";
        }
        private void CheckAllItemsListBox(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, true);
            }
        }

        private void RemoveAllItemsListBox(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, false);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            CheckAllItemsListBox(clbCustomerUpdate);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RemoveAllItemsListBox(clbCustomerUpdate);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int addItem = (int)cmbCustomerAdd.SelectedValue;
            int updItem = (int)cmbCustomerUpdate.SelectedValue;

            if (addItem != updItem)
            {
                for (int i = 0; i < clbCustomerAdd.CheckedItems.Count; i++)
                {
                    IME.CustomerRepresentativeUpdate((int)cmbCustomerAdd.SelectedValue, ((Customer)clbCustomerAdd.Items[i]).c_name);
                    IME = new IMEEntities();
                }
                MessageBox.Show("Save Changes", "Succesfully");
                clbCustomerAdd.DataSource = IME.CustomerRepresentativeSelect(addItem);
                clbCustomerUpdate.DataSource = IME.CustomerRepresentativeSelect(updItem);
            }
            else
            {
                MessageBox.Show("You selected the same user");
            }
        }

        private void cmbCustomerAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            addCustomer.Clear();
            addCustomer.AddRange(((Worker)cmbCustomerAdd.SelectedItem).Customers1);
            clbCustomerAdd.DataSource = null;

            clbCustomerAdd.DataSource = addCustomer;
            clbCustomerAdd.ValueMember = "ID";
            clbCustomerAdd.DisplayMember = "c_name";
        }

        private void clbCustomerUpdate_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void RefreshNewAddCustomer(List<Customer> list)
        {
            clbCustomerAdd.DataSource = null;
            clbCustomerAdd.DataSource = list;
            clbCustomerAdd.DisplayMember = "c_name";

            CheckAllItemsListBox(clbCustomerAdd);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Program ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void clbCustomerUpdate_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            tempAddCustomer.Clear();
            int index = clbCustomerUpdate.SelectedIndex;
            bool state = clbCustomerUpdate.GetItemChecked(index);

            if (index != 0)
            {
                if (!state)
                {
                    addCustomer.Add((Customer)clbCustomerUpdate.Items[index]);
                    //sayac++;
                }
                else if (state)
                {
                    for (int i = 0; i < clbCustomerAdd.Items.Count; i++)
                    {
                        if (((Customer)clbCustomerUpdate.Items[index]).ID == ((Customer)clbCustomerAdd.Items[i]).ID)
                        {
                            addCustomer.Remove((Customer)clbCustomerAdd.Items[i]);
                        }
                    }
                }
                RefreshNewAddCustomer(addCustomer);
            }
        }
    }
}
