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

namespace LoginForm
{
    public partial class frmCityAdd : MyForm
    {
        IMEEntities IME = new IMEEntities();
        int countryID;
        public frmCityAdd(int country)
        {
            this.BringToFront();
            this.TopMost = true;
            InitializeComponent();
            countryID = country;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IME.Cities.Where(title => title.City_name == txtCity.Text).FirstOrDefault() == null)
            {
                DataSet.City ct = new DataSet.City();
                ct.City_name = txtCity.Text;
                string Department = cbCountry.Items[cbCountry.SelectedIndex].ToString();
                ct.CountryID = (int)cbCountry.SelectedValue;
                IME.Cities.Add(ct);
                IME.SaveChanges();
                MessageBox.Show(this, ct.City_name + " added as a CityName");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "There is a Already CityName with the same name in this Country");
            }
        }

        private void frmCityAdd_Load(object sender, EventArgs e)
        {
            this.BringToFront();
            this.TopMost = true;
            //var departmenList = IME.CustomerCategories.Select(a=>a.categoryname).ToList();
            cbCountry.DataSource = IME.Countries.ToList();
            cbCountry.ValueMember = "ID";
            cbCountry.DisplayMember = "Country_name";
            cbCountry.SelectedValue = countryID;
        }
    }
}
