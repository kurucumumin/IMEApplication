using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.WorkerManagement
{
    public partial class FormRoleAuths : Form
    {
        List<AuthorizationValue> newAuthList = new List<AuthorizationValue>();
        List<AuthorizationValue> authList = new List<AuthorizationValue>();

        List<RoleValue> roleList = new List<RoleValue>();
        
        public FormRoleAuths()
        {
            InitializeComponent();
        }

        private void FormRoleAuths_Load(object sender, EventArgs e)
        {
            loadRoles();
            txtNewRoleName.Enabled = false;
            lblNewRoleName.Enabled = false;

        }

        private void loadRoles()
        {
            cbRole.DataSource = AuthorizationService.getRoles();
            cbRole.DisplayMember = "roleName";
            lbRoleList.DataSource = AuthorizationService.getRoles();
            lbRoleList.DisplayMember = "roleName";
        }

        private void chcNewRole_CheckedChanged(object sender, EventArgs e)
        {
            txtNewRoleName.Enabled = !txtNewRoleName.Enabled;
            lblNewRoleName.Enabled = !lblNewRoleName.Enabled;
            cbRole.Enabled = !cbRole.Enabled;
            lblRoletobeEdited.Enabled = !lblRoletobeEdited.Enabled;
            btnDelete.Enabled = !btnDelete.Enabled;

            if (chcNewRole.Checked)
            {
                newAuthList.Clear();
                clbNewAuthorizations.DataSource = null;
                lbRoleList.SetSelected(0,true);
            }
            else
            {
                newAuthList.AddRange(((RoleValue)cbRole.SelectedItem).AuthorizationValues);
                clbNewAuthorizations.DataSource = newAuthList;
                clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

                CheckAllItemsListBox(clbNewAuthorizations);
            }
        }
        
        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            newAuthList.Clear();
            newAuthList.AddRange(((RoleValue)cbRole.SelectedItem).AuthorizationValues);

            clbNewAuthorizations.DataSource = null;
            clbNewAuthorizations.DataSource = newAuthList;
            clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

            CheckAllItemsListBox(clbNewAuthorizations);
            matchAuthorities();
        }
        
        private void lbRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            authList.Clear();
            authList.AddRange(((RoleValue)lbRoleList.SelectedItem).AuthorizationValues);

            clbAuthorizationList.DataSource = null;
            clbAuthorizationList.DataSource = authList;
            clbAuthorizationList.DisplayMember = "AuthorizationValue1";

            matchAuthorities();
        }




        private void clbAuthorizationList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbAuthorizationList.SelectedIndex;
            bool state = clbAuthorizationList.GetItemChecked(index);
            

            if (!state)
            {
                newAuthList.Add((AuthorizationValue)clbAuthorizationList.Items[index]);
            }
            else if (state)
            {
                for (int i = 0; i < clbNewAuthorizations.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorizationList.Items[index]).AuthorizationID == ((AuthorizationValue)clbNewAuthorizations.Items[i]).AuthorizationID)
                    {
                        newAuthList.Remove((AuthorizationValue)clbNewAuthorizations.Items[i]);
                    }
                }
            }
            RefreshNewAuthList();
        }

        private void clbNewAuthorizations_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbNewAuthorizations.SelectedIndex;
            if (index >= 0)
            {
                newAuthList.Remove((AuthorizationValue)clbNewAuthorizations.Items[index]);

                RefreshNewAuthList();
                clbNewAuthorizations.ClearSelected();
                matchAuthorities();
            }
        }

        private void RefreshNewAuthList()
        {
            clbNewAuthorizations.DataSource = null;
            clbNewAuthorizations.DataSource = newAuthList;
            clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

            CheckAllItemsListBox(clbNewAuthorizations);
        }

        private void CheckAllItemsListBox(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, true);
            }
        }

        private void matchAuthorities()
        {
            for (int i = 0; i < clbAuthorizationList.Items.Count; i++)
            {
                for (int j = 0; j <= clbNewAuthorizations.Items.Count; j++)
                {
                    if(j == clbNewAuthorizations.Items.Count)
                    {
                        clbAuthorizationList.SetItemChecked(i, false);
                    } else if (((AuthorizationValue)clbNewAuthorizations.Items[j]).AuthorizationID == ((AuthorizationValue)clbAuthorizationList.Items[i]).AuthorizationID)
                    {
                        clbAuthorizationList.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chcNewRole.Checked)
            {
                if (checkNulls())
                {
                    MessageBox.Show("You have to fill * marked areas");
                }
                else
                {
                    RoleValue role = new RoleValue();
                    role.roleName = txtNewRoleName.Text;
                    if(AuthorizationService.AddRoleWithAuths(role, newAuthList))
                    {
                        MessageBox.Show("New role is successfully added!", "Success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while saving a new role, Try again later.", "Error");
                    }
                }
            }
            else
            {
                if (AuthorizationService.EditRole((RoleValue)cbRole.SelectedItem, newAuthList))
                {
                    MessageBox.Show("Selected role is successfully edited!", "Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occured while saving a changes, Try again later.", "Error");
                }
            }
        }

        private bool checkNulls()
        {
            if (txtNewRoleName.Text.Length > 0 && clbNewAuthorizations.Items.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Selected role will be deleted! Do you confirm?", "Delete Role", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                try
                {
                    IMEEntities IME = new IMEEntities();
                    RoleValue role = IME.RoleValues.Where(r => r.RoleID == ((RoleValue)cbRole.SelectedItem).RoleID).FirstOrDefault();
                    role.AuthorizationValues.Clear();
                    IME.SaveChanges();
                    IME.RoleValues.Remove(role);
                    IME.SaveChanges();

                    MessageBox.Show("Selected role is deleted.", "Success");
                    this.Close();
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }


            

            
        }
    }
}
