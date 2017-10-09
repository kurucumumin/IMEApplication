using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            int roleID = ((RoleValue)clbRoles.SelectedValue).RoleID;
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
                foreach (RoleValue item in ((AuthorizationValue)clbAuthorities.Items[i]).RoleValues)
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
            if (checkNulls())
            {
                MessageBox.Show("You need to fill in the marked('*') fields", "New Worker" , MessageBoxButtons.OK);
            }
            else
            {
                using (IMEEntities IME = new IMEEntities())
                    try
                    {
                        Worker worker = new Worker();
                        worker.NameLastName = txtNameLastName.Text;
                        if (chcActive.Checked)
                        {
                            worker.isActive = 1;
                        }
                        else
                        {
                            worker.isActive = 0;
                        }
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

                        IME.Workers.Add(worker);
                        IME.SaveChanges();

                        if(clbAuthorities.CheckedItems.Count != 0)
                        {
                            worker = IME.Workers.Where(w => w.UserName == worker.UserName).FirstOrDefault();
                            //WorkerService.AddNewWorker(worker);
                            foreach (AuthorizationValue item in clbAuthorities.CheckedItems)
                            {
                                AuthorizationValue av = IME.AuthorizationValues.Where(auth => auth.AuthorizationID == item.AuthorizationID).FirstOrDefault();
                                worker.AuthorizationValues.Add(av);
                                IME.SaveChanges();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bir hata oluştu");
                        throw;
                    }
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

        private bool checkNulls()
        {
            if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtUserPass.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numeric1.Value <= 0 ||numeric2.Value <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }
}
