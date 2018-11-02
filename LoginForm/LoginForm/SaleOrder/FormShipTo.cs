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

namespace LoginForm
{
    public partial class FormShipTo : DevExpress.XtraEditors.XtraForm
    {
        public int ShipTo;
        public FormShipTo()
        {
            SkinManager.EnableFormSkins();
            InitializeComponent();
           
        }

        private void FormShipTo_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Code",Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("ShipTo", Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;

            gridView1.Columns[0].ColumnEdit = this.customercode;
            
        }

        public void customernametiklandi(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormSaleOrderCustomerSearch frm = new FormSaleOrderCustomerSearch();
            frm.ShowDialog();
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"], frm.gridView1.GetFocusedRowCellValue("ID"));
            gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"], frm.gridView1.GetFocusedRowCellValue("c_name"));
            frm.Dispose();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("ShipTo") != null && gridView1.GetFocusedRowCellValue("ShipTo").ToString() != "")
            {
                ShipTo = Int32.Parse(gridView1.GetFocusedRowCellValue("ShipTo").ToString());
                this.Close();
            }
        }
    }
}