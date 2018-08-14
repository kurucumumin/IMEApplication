using LoginForm.DataSet;
using LoginForm.Main;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.User
{
    public partial class FormWorkerManagement : Form
    {
        bool isEditMode = false;
        Worker worker;
        FormUserMain upperForm;
        frmMainMetro formMain;
        List<AuthorizationValue> authList;

        public FormWorkerManagement(FormUserMain form)
        {
            InitializeComponent();
            authList = new List<AuthorizationValue>();
            chcChangePassword.Visible = false;
            LoadRoles();
            this.upperForm = form;
        }
        public FormWorkerManagement(frmMainMetro formMain ,Worker worker, FormUserMain form)
        {

            InitializeComponent();
            this.worker = worker;
            this.formMain = formMain;
            this.authList = worker.AuthorizationValues.ToList();
            this.upperForm = form;

            chcChangePassword.Visible = true;
            isEditMode = true;

            loadEditWorker();
            LoadRoles();
            numericDiscountRate.Value = (100 - (((decimal)worker.MinRate * 100) / Utils.getManagement().Factor));
        }

        private void LoadRoles()
        {
            lbRoles.DataSource = AuthorizationService.getRoles();
            lbRoles.DisplayMember = "roleName";
        }

        private void clbRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int roleID = ((RoleValue)lbRoles.SelectedValue).RoleID;
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
                        if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numericMinMargin.Value <= 0 || numericFactor.Value <= 0)
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
                    if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numericMinMargin.Value <= 0 || numericFactor.Value <= 0)
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
                if (txtNameLastName.Text.Length == 0 || txtUsername.Text.Length == 0 || txtUserPass.Text.Length == 0 || txtMail.Text.Length == 0 || txtPhone.Text.Length == 0 || (rbSales.Checked == false && rbSalesManager.Checked == false && rbGeneralManager.Checked == false) == true || numericMinMargin.Value <= 0 || numericFactor.Value <= 0)
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


            numericMinMargin.Value = (decimal)worker.MinMarge;
            numericFactor.Value = (decimal)worker.MinRate;


            clbUserAuthorityList.DataSource = authList;
            clbUserAuthorityList.DisplayMember = "AuthorizationValue1";


            CheckAllItemsListBox(clbUserAuthorityList, true);
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

        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbAuthorities.DataSource = ((RoleValue)lbRoles.SelectedItem).AuthorizationValues.ToList();
            clbAuthorities.DisplayMember = "AuthorizationValue1";

            for (int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                clbAuthorities.SetItemChecked(i, false);
            }

            matchAuthorities();
            chcAllAuth.Checked = false;
        }

        private void matchAuthorities()
        {
            for(int i = 0; i < clbAuthorities.Items.Count; i++)
            {
                for (int j = 0; j <= clbUserAuthorityList.Items.Count; j++)
                {
                    if (j == clbUserAuthorityList.Items.Count)
                    {
                        clbAuthorities.SetItemChecked(i, false);
                    }else if (((AuthorizationValue)clbUserAuthorityList.Items[j]).AuthorizationID == ((AuthorizationValue)clbAuthorities.Items[i]).AuthorizationID)
                    {
                        clbAuthorities.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void RefreshUserAuthList()
        {
            clbUserAuthorityList.DataSource = null;
            clbUserAuthorityList.DataSource = authList;
            clbUserAuthorityList.DisplayMember = "AuthorizationValue1";

            CheckAllItemsListBox(clbUserAuthorityList, true);
        }

        private void CheckAllItemsListBox(CheckedListBox listBox, bool state)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, state);
            }
        }

        private void clbAuthorities_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbAuthorities.SelectedIndex;
            bool state = clbAuthorities.GetItemChecked(index);
            

            if (!state)
            {
                authList.Add((AuthorizationValue)clbAuthorities.Items[index]);
                RefreshUserAuthList();
            }
            else if (state)
            {
                for (int i = 0; i < clbUserAuthorityList.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorities.Items[index]).AuthorizationID == ((AuthorizationValue)clbUserAuthorityList.Items[i]).AuthorizationID)
                    {
                        authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[i]);
                        RefreshUserAuthList();
                    }
                }
            }
        }

        private void clbUserAuthorityList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbUserAuthorityList.SelectedIndex;
            if (index >=0)
            {
                authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[index]);

                RefreshUserAuthList();
                matchAuthorities();
                clbUserAuthorityList.ClearSelected();
            }
        }

        private void numericFactor_ValueChanged(object sender, EventArgs e)
        {
            if(numericFactor.Focused)
            {
                decimal factor = numericFactor.Value;

                numericDiscountRate.Value = (100 - ((factor * 100) / Utils.getManagement().Factor));
            }
        }

        private void numericDiscountRate_ValueChanged(object sender, EventArgs e)
        {
            if (numericDiscountRate.Focused)
            {
                decimal discountRate = numericDiscountRate.Value;

                numericFactor.Value = (Utils.getManagement().Factor - ((discountRate * Utils.getManagement().Factor) / 100));
            }
        }

        private void chcAllAuth_Click(object sender, EventArgs e)
        {
            if (chcAllAuth.Checked == true)
            {
                //tüm otoriteleri işaretle
                SelectAllChangeState(clbAuthorities, true);
            }
            else
            {
                //tüm otoriteleri kaldır
                SelectAllChangeState(clbAuthorities, false);
            }
        }

        void SelectAllChangeState(CheckedListBox listBox, bool state)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, state);
                X(listBox, i);
            }
        }

        void X(CheckedListBox listBox,int index)
        {
            bool state = clbAuthorities.GetItemChecked(index);
            
            if (state)
            {
                if (!authList.Exists(x=>x.AuthorizationID == ((AuthorizationValue)(clbAuthorities.Items[index])).AuthorizationID))
                {
                    authList.Add((AuthorizationValue)clbAuthorities.Items[index]);
                    RefreshUserAuthList();
                }
            }
            else if (!state)
            {
                for (int i = 0; i < clbUserAuthorityList.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorities.Items[index]).AuthorizationID == ((AuthorizationValue)clbUserAuthorityList.Items[i]).AuthorizationID)
                    {
                        authList.Remove((AuthorizationValue)clbUserAuthorityList.Items[i]);
                        RefreshUserAuthList();
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
                    MessageBox.Show("You need to fill in the marked('*') fields", "New Worker");
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

                        wrkr.MinMarge = numericMinMargin.Value;
                        wrkr.MinRate = numericFactor.Value;

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

                        if (clbUserAuthorityList.CheckedItems.Count != 0)
                        {
                            foreach (AuthorizationValue item in clbUserAuthorityList.CheckedItems)
                            {
                                AuthorizationValue av = IME.AuthorizationValues.Where(auth => auth.AuthorizationID == item.AuthorizationID).FirstOrDefault();
                                wrkr.AuthorizationValues.Add(av);
                            }
                            IME.SaveChanges();
                        }

                        if (wrkr.WorkerID == Utils.getCurrentUser().WorkerID)
                        {
                            Utils.setCurrentUser(wrkr);
                            formMain.checkAuthorities();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu, Tekrar Deneyin");
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
                        if (txtNote.Text.Length != 0)
                        {
                            Note note = new Note();
                            note.Note_name = txtNote.Text;
                            IME.SaveChanges();
                            worker.Note = note;
                        }
                        worker.Email = txtMail.Text;
                        worker.MinMarge = numericMinMargin.Value;
                        worker.MinRate = numericFactor.Value;
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

                        if (clbUserAuthorityList.CheckedItems.Count != 0)
                        {
                            worker = IME.Workers.Where(w => w.UserName == worker.UserName).FirstOrDefault();
                            foreach (AuthorizationValue item in clbUserAuthorityList.CheckedItems)
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
    }
}
