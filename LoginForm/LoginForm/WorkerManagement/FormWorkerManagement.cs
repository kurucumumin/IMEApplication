using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.WorkerManagement
{
    public partial class FormWorkerManagement : Form
    {
        public FormWorkerManagement()
        {
            InitializeComponent();
        }

        private void FormWorkerManagement_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadAuthorities();
        }

        private void LoadAuthorities()
        {
            clbAuthorities.DataSource = AuthorizationService.getAuths();
            clbAuthorities.DisplayMember = "AuthorizationValue";
        }

        private void LoadRoles()
        {
            clbRoles.DataSource = AuthorizationService.getRoles();
            clbRoles.DisplayMember = "roleName";
        }

        private void clbRoles_Click(object sender, EventArgs e)
        {

        }

        //private void dgRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 0)
        //    {
        //        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgRoles.Rows[e.RowIndex].Cells[0];
        //        if (chk.Value == chk.TrueValue)
        //        {
        //            chk.Value = chk.FalseValue;
        //        }
        //        else
        //        {
        //            chk.Value = chk.TrueValue;
        //        }
        //    }
        //}
    }
}
