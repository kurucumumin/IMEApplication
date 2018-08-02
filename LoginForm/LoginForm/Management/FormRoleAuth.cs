using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.ManagementModule
{
    public partial class FormRoleAuths : Form
    {
        List<RoleValue> roleList = new List<RoleValue>();
        List<AuthorizationValue> authList = new List<AuthorizationValue>();
        List<AuthorizationValue> newAuthList = new List<AuthorizationValue>();

        List<RoleValue> tempRoleList = new List<RoleValue>();
        List<AuthorizationValue> tempAuthList = new List<AuthorizationValue>();
        List<AuthorizationValue> tempNewAuthList = new List<AuthorizationValue>();


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
            roleList = AuthorizationService.getRoles();
            tempRoleList = roleList.ToList();
            cbRole.DataSource = roleList;
            cbRole.DisplayMember = "roleName";
            lbRoleList.DataSource = tempRoleList;
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
            if (lbRoleList.SelectedItem != null)
            {
                authList.Clear();
                authList.AddRange(((RoleValue)lbRoleList.SelectedItem).AuthorizationValues);

                clbAuthorizationList.DataSource = null;
                clbAuthorizationList.DataSource = authList;
                clbAuthorizationList.DisplayMember = "AuthorizationValue1";

                matchAuthorities();
            }
        }
        

        private void clbAuthorizationList_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchUserAuthority.Text = String.Empty;
            tempNewAuthList.Clear();

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
            RefreshNewAuthList(newAuthList);
        }

        private void clbNewAuthorizations_MouseClick(object sender, MouseEventArgs e)
        {
            int index = clbNewAuthorizations.SelectedIndex;
            if (index >= 0)
            {
                newAuthList.Remove((AuthorizationValue)clbNewAuthorizations.Items[index]);
                tempNewAuthList.Remove((AuthorizationValue)clbNewAuthorizations.Items[index]);

                if (newAuthList.SequenceEqual((List<AuthorizationValue>)clbNewAuthorizations.DataSource))
                {
                    RefreshNewAuthList(newAuthList);
                }
                else
                {
                    RefreshNewAuthList(tempNewAuthList);
                }
                clbNewAuthorizations.ClearSelected();
                matchAuthorities();
            }
        }

        private void RefreshNewAuthList(List<AuthorizationValue> list)
        {
            clbNewAuthorizations.DataSource = null;
            clbNewAuthorizations.DataSource = list;
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
                for (int j = 0; j <= newAuthList.Count; j++)
                {
                    if(j == newAuthList.Count)
                    {
                        clbAuthorizationList.SetItemChecked(i, false);
                    } else if (newAuthList[j].AuthorizationID == ((AuthorizationValue)clbAuthorizationList.Items[i]).AuthorizationID)
                    {
                        clbAuthorizationList.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RefreshNewAuthList(newAuthList);

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
                    if (AuthorizationService.AddRoleWithAuths(role, newAuthList))
                    {
                        MessageBox.Show("New role '" + txtNewRoleName.Text + "' is successfully added!", "Success");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("An error occured while saving a new role '" + txtNewRoleName.Text + "', Try again later.", "Error");
                    }
                }
            }
            else
            {
                if (AuthorizationService.EditRole((RoleValue)cbRole.SelectedItem, newAuthList))
                {
                    MessageBox.Show("Selected role '" + ((RoleValue)cbRole.SelectedItem).roleName + "' is successfully edited!", "Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occured while saving changes on role'" + ((RoleValue)cbRole.SelectedItem).roleName + "', Try again later.", "Error");
                }
            }
        }

        private bool checkNulls()
        {
            if (txtNewRoleName.Text.Length > 0 && newAuthList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void txtSearchRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tempRoleList = roleList.Where(r => r.roleName.IndexOf(txtSearchRole.Text, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();
                lbRoleList.DataSource = null;
                lbRoleList.DataSource = tempRoleList;
                lbRoleList.DisplayMember = "roleName";
            }
        }

        private void txtSearchAuthority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tempAuthList = authList.Where(r => r.AuthorizationValue1.IndexOf(txtSearchAuthority.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                clbAuthorizationList.DataSource = null;
                clbAuthorizationList.DataSource = tempAuthList;
                clbAuthorizationList.DisplayMember = "AuthorizationValue1";

                matchAuthorities();
            }
        }

        private void txtSearchUserAuthority_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tempNewAuthList = newAuthList.Where(r => r.AuthorizationValue1.IndexOf(txtSearchUserAuthority.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                clbNewAuthorizations.DataSource = null;
                clbNewAuthorizations.DataSource = tempNewAuthList;
                clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

                CheckAllItemsListBox(clbNewAuthorizations);
                matchAuthorities();
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
