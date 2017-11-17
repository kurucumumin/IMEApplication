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

namespace LoginForm.Customer
{
    public partial class FormTownAdd : Form
    {
        IMEEntities IME = new IMEEntities();
        public FormTownAdd()
        {
            InitializeComponent();
            cbCountry.DataSource = IME.Countries.ToList();
            cbCountry.DisplayMember = "Country_name";
            cbCountry.ValueMember = "ID";
        }

        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            cbCountry.DataSource = IME.Cities.Where(a=>a.CountryID==(cbCountry.SelectedValue as Country).ID).ToList();
            if (cbCountry.DataSource != null)
            {
                cbCountry.DisplayMember = "City_name";
                cbCountry.ValueMember = "ID";
                cbCity.Enabled = true;
            }
            else { MessageBox.Show("There is no such a country"); }

        }
    }
}
