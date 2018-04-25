using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.IMEAccount
{
    public partial class frmAccount : Form
    {
        int AccountID;
        IMEEntities IME = new IMEEntities();
        public frmAccount()
        {
            InitializeComponent();
            AccountID = -1;
        }

        public frmAccount(string fromName)
        {
            InitializeComponent();
            //LoadCurriencies();
            AccountID = -1;
        }

        public frmAccount(int ID)
        {
            InitializeComponent();
            //LoadCurriencies();
            DataSet.Account account = IME.Accounts.Where(a => a.ID == ID).FirstOrDefault();
            cbCurrency.SelectedValue = account.CurrencyID;
            txtDesctription.Text = account.Description;
            txtName.Text = account.Name;
            txtNumber.Text = account.Number;
            AccountID = ID;
        }

        #region Functions
        private void LoadCurriencies()
        {
            cbCurrency.DataSource = IME.Currencies.ToList();
            cbCurrency.DisplayMember = "currencyName";
            cbCurrency.ValueMember = "currencyID";
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Save
            if (AccountID == -1)
            {
                //For New Account
                DataSet.Account account = new DataSet.Account();
                account.CurrencyID = Decimal.Parse(cbCurrency.SelectedValue.ToString());
                account.Description = txtDesctription.Text;
                account.IsActive = chkIsActive.Checked;
                account.Name = txtName.Text;
                account.Number = txtNumber.Text;
                IME.Accounts.Add(account);
                IME.SaveChanges();
                MessageBox.Show("Account Created Successfully");
            }
            else
            {
                //For Update Account
                DataSet.Account account = IME.Accounts.Where(a => a.ID == AccountID).FirstOrDefault();
                account.CurrencyID = Decimal.Parse(cbCurrency.SelectedValue.ToString());
                account.Description = txtDesctription.Text;
                account.IsActive = chkIsActive.Checked;
                account.Name = txtName.Text;
                account.Number = txtNumber.Text;
                IME.SaveChanges();
                MessageBox.Show("Account Updated Successfully");
            }
            #endregion
            this.Close();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            LoadCurriencies();
        }
    }
}
