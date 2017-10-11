using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Windows.Forms;
using System.Linq;
using LoginForm.RolesAndAuths;

namespace LoginForm.WorkerManagement
{
    public partial class FormWorkerManagement : Form
    {
        bool isEditMode = false;
        Worker worker;
        FormRoles upperForm;

        public FormWorkerManagement()
        {
            InitializeComponent();
            chcChangePassword.Visible = false;
            LoadRoles();
            LoadAuthorities();
        }
        public FormWorkerManagement(Worker worker, FormRoles form)
        {
            InitializeComponent();
            this.worker = worker;
            this.upperForm = form;
            chcChangePassword.Visible = true;
            LoadRoles();
            LoadAuthorities();

            isEditMode = true;
            loadEditWorker();
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

        private void ChangeCheckStateOfAuths(int roleID, bool state)
        {
            for (int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                foreach (RoleValue item in ((AuthorizationValue)clbAuthorities.Items[i]).RoleValues)
                {
                    if (item.RoleID == roleID)
                    {
                        clbAuthorities.SetItemChecked(i, state);
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                IMEEntities IME = new IMEEntities();
                if (nullExist())
                {
                    MessageBox.Show("You need to fill in the marked('*') fields", "New Worker", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        Worker wrkr = IME.Workers.Where(w => w.WorkerID == worker.WorkerID).FirstOrDefault();

                        wrkr.NameLastName = txtNameLastName.Text;
                        wrkr.UserName = txtUsername.Text;
                        wrkr.Email = txtMail.Text;
                        wrkr.Phone = txtPhone.Text;

                        if (wrkr.Note != null)
                        {
                            Note n = IME.Notes.Remove(wrkr.Note);

                            Note note = new Note();
                            note.Note_name = txtNote.Text;

                            wrkr.Note = note;
                            IME.SaveChanges();
                        }
                        if (chcChangePassword.Checked)
                        {
                            wrkr.UserPass = Utils.MD5Hash(txtUserPass.Text);
                        }
                        if (rbSales.Checked)
                        {
                            wrkr.Title = 1;
                        }
                        else if (rbSalesManager.Checked)
                        {
                            wrkr.Title = 2;
                        }
                        else if (rbGeneralManager.Checked)
                        {
                            wrkr.Title = 3;
                        }

                        wrkr.MinMarge = numeric1.Value;
                        wrkr.MinRate = numeric2.Value;

                        if (chcActive.Checked)
                        {
                            wrkr.isActive = 1;
                        }
                        else
                        {
                            wrkr.isActive = 0;
                        }

                        wrkr.AuthorizationValues.Clear();
                        IME.SaveChanges();

                        if (clbAuthorities.CheckedItems.Count != 0)
                        {
                            foreach (AuthorizationValue item in clbAuthorities.CheckedItems)
                            {
                                AuthorizationValue av = IME.AuthorizationValues.Where(auth => auth.AuthorizationID == item.AuthorizationID).FirstOrDefault();
                                wrkr.AuthorizationValues.Add(av);
                            }
                            IME.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bir hata oluştu");
                        throw;
                    }
                    upperForm.LoadWorkerList();
                    this.Close();
                }
            }
            else
            {
                IMEEntities IME = new IMEEntities();
                if (nullExist())
                {
                    MessageBox.Show("You need to fill in the marked('*') fields", "New Worker", MessageBoxButtons.OK);
                }
                else
                {
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
                        if(txtNote.Text.Length != 0)
                        {
                            Note note = new Note();
                            note.Note_name = txtNote.Text;
                            IME.SaveChanges();
                            worker.Note = note;
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

                        if (clbAuthorities.CheckedItems.Count != 0)
                        {
                            worker = IME.Workers.Where(w => w.UserName == worker.UserName).FirstOrDefault();
                            foreach (AuthorizationValue item in clbAuthorities.CheckedItems)
                            {
                                AuthorizationValue av = IME.AuthorizationValues.Where(auth => auth.AuthorizationID == item.AuthorizationID).FirstOrDefault();
                                worker.AuthorizationValues.Add(av);
                            }
                            IME.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Bir hata oluştu");
                        throw;
                    }
                    upperForm.LoadWorkerList();
                    this.Close();
                }

            }
        }

        private bool nullExist()
        {
            if (isEditMode)
            {
                if (chcChangePassword.Checked)
                {
                    if (txtUserPass.Text.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numeric1.Value <= 0 || numeric2.Value <= 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numeric1.Value <= 0 || numeric2.Value <= 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtUserPass.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numeric1.Value <= 0 || numeric2.Value <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void loadEditWorker()
        {
            txtNameLastName.Text = worker.NameLastName;
            txtUsername.Text = worker.UserName;
            txtUserPass.Enabled = false;
            chcChangePassword.Checked = false;
            txtMail.Text = worker.Email;
            txtPhone.Text = worker.Phone;
            if(worker.Note != null)
            {
                txtNote.Text = worker.Note.Note_name;
            }
            switch (worker.Title)
            {
                case 1:
                    rbSales.Checked = true;
                    break;
                case 2:
                    rbSalesManager.Checked = true;
                    break;
                case 3:
                    rbGeneralManager.Checked = true;
                    break;
            }

            if (worker.isActive == 1)
            {
                chcActive.Checked = true;
            }
            else
            {
                chcActive.Checked = false;
            }

            numeric1.Value = (decimal)worker.MinMarge;
            numeric2.Value = (decimal)worker.MinRate;

            for (int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                foreach (var wAuth in worker.AuthorizationValues)
                {
                    if (wAuth.AuthorizationID == ((AuthorizationValue)clbAuthorities.Items[i]).AuthorizationID)
                    {
                        clbAuthorities.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void chcChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chcChangePassword.Checked)
            {
                txtUserPass.Enabled = true;
            }
            else
            {
                txtUserPass.Enabled = false;
            }
        }
    }
}
