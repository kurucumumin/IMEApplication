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
        List<Mail> addedMails = new List<Mail>();

        public MailForm()
        {
            InitializeComponent();
        }

        private void MailForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'iMEDataSet.Mail' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.mailTableAdapter.Fill(this.iMEDataSet.Mail);
            dgMail.DataSource = IME.Mails.ToList();

            if ( radioDefault.Checked == true)
            {
                dgMail.Enabled = false;
            }
        }

        //private void MailFill()
        //{
        //    IME = new IMEEntities();
        //    var adapter = (from m in IME.Mails
        //                   select new
        //                   {
        //                       m.id,
        //                       m.FirstName,
        //                       m.MailAddress,
        //                       m.cc,
        //                       m.too
        //                   }).ToList();
        //    dgMail.DataSource = adapter;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(Mail mail in addedMails)
            {
                try
                {
                    IME.Mails.Add(mail);
                    IME.SaveChanges();
                }
                catch (Exception )
                {
                    throw;
                }
            }


            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    mailBindingSource.EndEdit();
            //    mailTableAdapter.Update(this.iMEDataSet.Mail);
            //    MessageBox.Show("You have been successfully saved.","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            //Cursor.Current = Cursors.Default;
        }


        private void dgMail_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete)
            {
              if (MessageBox.Show("Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                mailBindingSource.RemoveCurrent();
            }

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
            Mail mail = new Mail();
            mail.FirstName = (string)e.Row.Cells["FirstName"].Value;
            mail.MailAddress = (string)e.Row.Cells["MailAddress"].Value;
            mail.too = (bool)e.Row.Cells["too"].Value;
            mail.cc = (bool)e.Row.Cells["cc"].Value;

            addedMails.Add(mail);
        }
    }
}
