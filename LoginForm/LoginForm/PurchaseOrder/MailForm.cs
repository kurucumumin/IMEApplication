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
        List<Mail> MailList = new List<Mail>();
        List<int> addedMailIndex = new List<int>();

        public MailForm()
        {
            InitializeComponent();
            MailList = IME.Mails.ToList();
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            FillMain();
            dgMail.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Mail> MailList = new List<Mail>();
            IME = new IMEEntities();

            foreach (int rowIndex in addedMailIndex)
            {
                Mail m = new Mail();
                
                m.FirstName = dgMail.Rows[rowIndex].Cells[1].Value.ToString();
                m.MailAddress = dgMail.Rows[rowIndex].Cells[2].Value.ToString();
                m.cc = (dgMail.Rows[rowIndex].Cells[3].Value != null) ? (bool)dgMail.Rows[rowIndex].Cells[3].Value : false ;
                m.too = (dgMail.Rows[rowIndex].Cells[4].Value != null) ? (bool)dgMail.Rows[rowIndex].Cells[4].Value : false ;

                MailList.Add(m);
            }

            IME.Mails.AddRange(MailList);
            IME.SaveChanges();
            MessageBox.Show("Mail is successfully added", "Success");
        }

        private void radioSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSpecial.Checked == true)
            {
                dgMail.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseExportFiles f = new PurchaseExportFiles();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        private void dgMail_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            FillMain();
        }

        private void FillMain()
        {
            foreach (Mail mail in MailList)
            {
                int rowIndex = dgMail.Rows.Add();
                dgMail.Rows[rowIndex].Cells["id"].Value = mail.id;
                dgMail.Rows[rowIndex].Cells["FirstName"].Value = mail.FirstName;
                dgMail.Rows[rowIndex].Cells["MailAddress"].Value = mail.MailAddress;
                dgMail.Rows[rowIndex].Cells["cc"].Value = mail.cc;
                dgMail.Rows[rowIndex].Cells["too"].Value = mail.too;
            }
        }

        private void dgMail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex + 1 > MailList.Count)
            {
                addedMailIndex.Add(e.RowIndex - 1);
            }
        }
    }
}
