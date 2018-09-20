using LoginForm.DataSet;
using LoginForm.Main;
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

namespace LoginForm.Management
{
    public partial class FormLogKayit : Form
    {
        IMEEntities IME = new IMEEntities();
        frmMainMetro mainForm;

        public FormLogKayit()
        {
            InitializeComponent();
        }

        public FormLogKayit(frmMainMetro mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close ?", "Log Records Close", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void FormLogKayit_Load(object sender, EventArgs e)
        {
            listPerson.DataSource = IME.Workers.ToList();
            listPerson.DisplayMember = "NameLastName";
        }
    }
}
