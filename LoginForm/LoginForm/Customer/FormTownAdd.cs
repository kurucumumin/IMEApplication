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
        public FormTownAdd()
        {
            InitializeComponent();
            this.BringToFront();
            cbCountry.DataSource = IME.Countries.ToList();
            cbCountry.DisplayMember = "Country_name";
            //cbCountry.ValueMember = "ID";
        }

        private void cbCountry_SelectedValueChanged(object sender, EventArgs e)
        {

            int cityID1 = (cbCountry.SelectedValue as Country).ID;
            cbCity.DataSource = null;
            if (IME.Cities.Where(a => a.CountryID == cityID1).ToList() != null)
            {
                cbCity.DataSource = IME.Cities.Where(a => a.CountryID == cityID1).ToList();
                cbCity.DisplayMember = "City_name";
                //cbCity.ValueMember = "ID";
                cbCity.Enabled = true;
            }
            else { MessageBox.Show("There is no such a country"); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTown.Text!=null&& txtTown.Text != string.Empty)
            {
                Town newTown = new Town();
                int CityID = (cbCity.SelectedValue as City).ID;
                newTown.CityID = CityID;
                newTown.Town_name = txtTown.Text;
                IME.Towns.Add(newTown);
                IME.SaveChanges();
                this.Close();
            }
        }
    }
}
