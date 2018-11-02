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
using DevExpress.Skins;
using System.Data.SqlClient;
using LoginForm.MyClasses;
using ImeLogoLibrary;
using LoginForm.Services;

namespace LoginForm
{
    public partial class FormSaleOrderCustomerSearch : DevExpress.XtraEditors.XtraForm
    {
        ImeSQL imesql = new ImeSQL();

        public FormSaleOrderCustomerSearch()
        {
            SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void FormSaleOrderCustomerSearch_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ImeSettings.ConnectionStringIME;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select ID, c_name From Customer", con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridControl1.DataSource = dt;
                con.Close();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}