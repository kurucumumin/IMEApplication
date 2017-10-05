using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            clbAuthorities.DisplayMember = "AuthorizationValue1";
        }

        private void LoadRoles()
        {
            clbRoles.DataSource = AuthorizationService.getRoles();
            clbRoles.DisplayMember = "roleName";
        }

        private void clbRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int roleID = ((Role)clbRoles.SelectedValue).RoleID;
            if (e.NewValue == CheckState.Checked)
            {
                ChangeCheckStateOfAuths(roleID, true);
            }
            else
            {
                ChangeCheckStateOfAuths(roleID, false);
            }
        }

        private void ChangeCheckStateOfAuths(int roleID,bool state)
        {
            for (int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                foreach (Role item in ((AuthorizationValue)clbAuthorities.Items[i]).Roles)
                {
                    if(item.RoleID == roleID)
                    {
                        clbAuthorities.SetItemChecked(i, state);
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Worker worker = new Worker();
                worker.NameLastName = txtNameLastName.Text;
                worker.isActive = chcActive.Checked;
                worker.Email = txtMail.Text;
                worker.MinMarge = numeric1.Value;
                worker.MinRate = numeric2.Value;
                worker.Phone = txtPhone.Text;
                worker.UserName = txtUsername.Text;
                worker.UserPass = Utils.MD5Hash(txtUserPass.Text);
                int title = 0;
                if (rbSales.Checked)
                {
                    title = 1;
                }
                else if (rbSalesManager.Checked)
                {
                    title = 2;
                }
                else if (rbGeneralManager.Checked)
                {
                    title = 3;
                }
                worker.Title = title;

                WorkerService.AddNewWorker(worker);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu");
                throw;
            }
            

            
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
