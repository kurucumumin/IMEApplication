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

namespace LoginForm.PurchaseOrder
{
    public partial class MailForm : Form
    {
        IMEEntities IME = new IMEEntities();

        public MailForm()
        {
            InitializeComponent();
        }

        private void MailForm_Load(object sender, EventArgs e)
        {   
            if ( radioDefault.Checked == true)
            {
                MailFill();
            }

        }

        private void MailFill()
        {
            IME = new IMEEntities();
            var adapter = (from m in IME.Mails
                           select new
                           {
                               m.FirstName,
                               m.MailAddress,
                               m.cc,
                               m.too
                           }).ToList();
            dgMail.DataSource = adapter;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
