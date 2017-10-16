using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
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
            cbRole.Enabled = !cbRole.Enabled;

            if (chcNewRole.Checked)
            {
                newAuthList.Clear();
                clbNewAuthorizations.DataSource = null;
                clbNewAuthorizations.DisplayMember = "AuthorizationValue1";
            }
            else
            {
                newAuthList.AddRange(((RoleValue)cbRole.SelectedItem).AuthorizationValues);
                clbNewAuthorizations.DataSource = newAuthList;
                clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

                for (int i = 0; i < clbNewAuthorizations.Items.Count; i++)
                {
                    clbNewAuthorizations.SetItemChecked(i, true);
                }
            }
        }
        

        //private void chcNewRole_CheckStateChanged(object sender, EventArgs e)
        //{
        //    if (chcNewRole.Checked)
        //    {
        //        newAuthList.Clear();
        //        clbNewAuthorizations.DataSource = newAuthList;
        //        clbNewAuthorizations.DisplayMember = "AuthorizationValue1";
        //    }
        //    else
        //    {
        //        newAuthList.AddRange(((RoleValue)cbRole.SelectedItem).AuthorizationValues);
        //        clbNewAuthorizations.DataSource = newAuthList;
        //    }
        //}

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            newAuthList.Clear();
            newAuthList.AddRange(((RoleValue)cbRole.SelectedItem).AuthorizationValues);

            clbNewAuthorizations.DataSource = null;
            clbNewAuthorizations.DataSource = newAuthList;
            clbNewAuthorizations.DisplayMember = "AuthorizationValue1";

            for (int i = 0; i < clbNewAuthorizations.Items.Count; i++)
            {
                clbNewAuthorizations.SetItemChecked(i, true);
            }
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
                RefreshNewAuthList();
            }
            else if (state)
            {
                for (int i = 0; i < clbNewAuthorizations.Items.Count; i++)
                {
                    if (((AuthorizationValue)clbAuthorizationList.Items[index]).AuthorizationID == ((AuthorizationValue)clbNewAuthorizations.Items[i]).AuthorizationID)
                    {
                        newAuthList.Remove((AuthorizationValue)clbNewAuthorizations.Items[i]);
                        RefreshNewAuthList();
                    }
                }
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
            for (int i = 0; i < clbNewAuthorizations.Items.Count; i++)
            {
                for (int j = 0; j < clbAuthorizationList.Items.Count; j++)
                {
                    if (((AuthorizationValue)clbNewAuthorizations.Items[i]).AuthorizationID == ((AuthorizationValue)clbAuthorizationList.Items[j]).AuthorizationID)
                    {
                        clbAuthorizationList.SetItemChecked(j, true);
                    }
                    else
                    {
                        clbAuthorizationList.SetItemChecked(j, false);
                    }
                }
            }
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
    }
}
