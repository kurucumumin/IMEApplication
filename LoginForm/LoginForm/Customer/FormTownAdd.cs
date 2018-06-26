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
    public partial class FormTownAdd : Form
    {
        IMEEntities IME = new IMEEntities();
        int cityID;
        int countryID;

        public FormTownAdd(int country, int city)
        {
            InitializeComponent();
            this.BringToFront();
            countryID = country;
            cityID = city;
        }

        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {

            //int cityID1 = (cbCountry.SelectedValue as Country).ID;
            cbCity.DataSource = null;
            if (IME.Cities.Where(a => a.CountryID == countryID).ToList() != null)
            {
                cbCity.DataSource = IME.Cities.Where(a => a.CountryID == countryID).ToList();
                cbCity.DisplayMember = "City_name";
                cbCity.ValueMember = "ID";
                cbCity.SelectedValue = cityID;
                cbCity.Enabled = true;
            }
            else { MessageBox.Show("There is no such a country"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTown.Text!=null&& txtTown.Text != string.Empty)
            {
                Town newTown = new Town();
               // int CityID = (cbCity.SelectedValue as City).ID;
                newTown.CityID = cityID;
                newTown.Town_name = txtTown.Text;
                IME.Towns.Add(newTown);
                IME.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FormTownAdd_Load(object sender, EventArgs e)
        {
            cbCountry.DataSource = IME.Countries.ToList();
            cbCountry.DisplayMember = "Country_name";
            cbCountry.ValueMember = "ID";
            cbCountry.SelectedValue = countryID;
        }
    }
}
