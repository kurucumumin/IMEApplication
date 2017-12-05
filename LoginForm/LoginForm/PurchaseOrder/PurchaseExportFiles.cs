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
        List<DataGridViewRow> rowList = new List<DataGridViewRow>();
        string fiche = "";
        public PurchaseExportFiles()
        {
            InitializeComponent();
        }

        public PurchaseExportFiles(List<DataGridViewRow> List)
        {
            InitializeComponent();
            rowList = List;
        }

        public PurchaseExportFiles(string ficheNo)
        {
            InitializeComponent();
            fiche = ficheNo;

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

        private void btnCreatePurchase_Click(object sender, EventArgs e)
        {
            List<PurchaseOrderDetail> podList = new List<PurchaseOrderDetail>();

            foreach (DataGridViewRow row in rowList)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();

                pod.QuotationNo = row.Cells[2].Value.ToString();
                pod.SaleOrderNo = row.Cells[3].Value.ToString();
                pod.ItemCode = row.Cells[4].Value.ToString();
                pod.ItemDescription = row.Cells[5].Value.ToString();
                pod.Unit = row.Cells[6].Value.ToString();
                pod.SendQty = (int)row.Cells[7].Value;
                pod.Hazardous = (bool)row.Cells[8].Value;
                pod.Calibration = (bool)row.Cells[9].Value;
                pod.SaleOrderNature = row.Cells[10].Value.ToString();

                podList.Add(pod);
            }

            IME.PurchaseOrderDetails.AddRange(podList);
            IME.SaveChanges();


            DataSet.PurchaseOrder po = new DataSet.PurchaseOrder();
            po.FicheNo = fiche;
            string s = rowList[0].Cells[3].Value.ToString();
            po.CustomerID = IME.SaleOrders.Where(a => a.SaleOrderNo == s).FirstOrDefault().CustomerID;
            po.PurchaseOrderDate = DateTime.Today.Date;
            po.CameDate= IME.SaleOrders.Where(a => a.SaleOrderNo ==s).FirstOrDefault().SaleDate;
            //po.Reason
            IME.PurchaseOrders.Add(po);
            IME.SaveChanges();


            foreach (PurchaseOrderDetail item in podList)
            {
                po.PurchaseOrderDetails.Add(item);
            }

            IME.SaveChanges();

        }
    }
}
