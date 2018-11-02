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
using LoginForm.Services;
using LoginForm.DataSet;
namespace LoginForm
{
    public partial class FormBillTo : DevExpress.XtraEditors.XtraForm
    {
        public int BillTo;
        SqlDataAdapter adapter;
        DataTable dt;
        public FormBillTo()
        {
            SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void FormBillTo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ImeSettings.ConnectionStringIME;
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                adapter = new SqlDataAdapter("Select Name, Code From BillTo", con);
                dt = new DataTable();
                adapter.Fill(dt);
                gridControl1.DataSource = dt;
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Code") != null && gridView1.GetFocusedRowCellValue("Code").ToString() != "")
            {
                BillTo = Int32.Parse(gridView1.GetFocusedRowCellValue("Code").ToString());
                this.Close();
            }
        }
    }
}