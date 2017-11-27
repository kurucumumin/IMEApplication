using LoginForm.DataSet;
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
    public partial class PurchaseExportFiles : Form
    {
        IMEEntities IME = new IMEEntities();

        public PurchaseExportFiles()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MailForm form = new MailForm();
            form.ShowDialog();
        }

        private void ToFill()
        {
            IME = new IMEEntities();
            var adapter = (from m in IME.Mails.Where(m=> m.too!=null && m.too==true)
                           select new
                           {
                               m.FirstName,
                               m.MailAddress
                           }).ToList();
            dgMail.DataSource = adapter;
        }

        private void CCFill()
        {
            IME = new IMEEntities();
            var adapter = (from m in IME.Mails.Where(m => m.cc != null && m.cc == true)
                           select new
                           {
                               m.FirstName,
                               m.MailAddress
                           }).ToList();
            dgCc.DataSource = adapter;
        }

        private void PurchaseExportFiles_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'iMEDataSet2.Mail' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mailTableAdapter.Fill(this.iMEDataSet2.Mail);
            #region Filler
            ToFill();
            CCFill();
            txtDate.Text = DateTime.Now.ToString();
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            NewPurchaseOrder f = new NewPurchaseOrder();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
