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
using LoginForm.Services;
using System.Data.SqlClient;


namespace LoginForm.PurchaseOrder
{
    public partial class NewPurchaseOrder : Form
    {
        IMEEntities IME = new IMEEntities();
        List<SaleOrderDetail> saleItemList = new List<SaleOrderDetail>();

        SqlDataAdapter da;
        System.Data.DataSet ds = new System.Data.DataSet();

        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        public NewPurchaseOrder(string item_code)
        {
            InitializeComponent();
            PurchaseOrder(item_code);
        }

        //public NewPurchaseOrder(SaleOrder so)
        //{
        //    InitializeComponent();

        //    foreach (SaleOrderDetail item in so.SaleOrderDetails)
        //    {
        //        saleItemList.Add(item);
        //    }
        //}

        //public NewPurchaseOrder(List<SaleOrder> SaleOrderList)
        //{
        //    InitializeComponent();

        //    foreach (SaleOrder sale in SaleOrderList)
        //    { 
        //        saleItemList.AddRange(sale.SaleOrderDetails);
        //    }
        //}

        private void btnCreate_Click(object sender, EventArgs e)
        {

            //List<PurchaseOrderDetail> list = new List<PurchaseOrderDetail>();
            List<DataGridViewRow> rowList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgPurchase.Rows)
            {
                if (row.Cells[0].Value!=null && (bool)row.Cells[0].Value == true)
                {
                    rowList.Add(row);
                }
            }
            //this.Hide();
            PurchaseExportFiles form = new PurchaseExportFiles(rowList);
            form.ShowDialog();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PurchaseOrderMain f = new PurchaseOrderMain();
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                f.ShowDialog();
                this.Close();
            }
        }

        //private void NewPurchaseOrder_Load(object sender, EventArgs e)
        //{
        //    PurchaseOrderFill();
        //}

        private void PurchaseOrderFill()
        {
            List<PurchaseOrderDetail> purchaseList = new List<PurchaseOrderDetail>();

            foreach (SaleOrderDetail sod in saleItemList)
            {
                PurchaseOrderDetail pod = new PurchaseOrderDetail();
                pod.ItemCode = sod.ItemCode;
                pod.SaleOrderNature = sod.SaleOrder.SaleOrderNature;
                pod.QuotationNo = sod.SaleOrder.QuotationNos;
                pod.SaleOrderNo = sod.SaleOrderNo;
                pod.ItemDescription = sod.ItemDescription;
                pod.Unit = sod.UnitOfMeasure;
                pod.Hazardous = sod.Hazardous;
                pod.Calibration = sod.Calibration;
                pod.UnitPrice = sod.UnitPrice;

                purchaseList.Add(pod);
            }

            dgPurchase.DataSource = purchaseList;
        }

        public void PurchaseOrder(string item_code)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-51RN2GB\LOCAL;Initial Catalog=IME;Integrated Security=True");
            StringBuilder history = new StringBuilder();
            history.Append("Select a.c_name,b.QuotationNos, b.SaleOrderNo, c.ItemCode, c.ItemDescription, c.UnitOfMeasure, c.Quantity, c.Hazardous, ");
            history.Append("c.Calibration, b.SaleOrderNature, d.AddressType, d.AdressTitle, c.UnitPrice ");
            history.Append("from  Customer a, SaleOrder b, SaleOrderDetail c, CustomerAddress d ");
        history.Append("where b.CustomerID=a.ID and c.SaleOrderNo =b.SaleOrderNo and b.DeliveryAddressID=d.ID and b.InvoiceAddressID=d.ID ");
            history.Append("and c.SaleOrderNo=");
            history.Append("'");
            history.Append(item_code);
            history.Append("'");

            try
            {
                connection.Open();
                da = new SqlDataAdapter(history.ToString(), connection);//dataapter nesnesini oluşturup sqlCmd sorgu cümlesini ve sqlCon veritabanı bağlantımızı yazıyoruz

                da.Fill(ds, "History");

                if (ds.Tables[0].Rows.Count == 0)//History tablosunda herhangi bir veri yoksa (boşsa) aşağıdaki blok çalışacak     
                {
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("No Records Found", "", MessageBoxButtons.OK);
                    if (dialog == DialogResult.OK)
                    {
                        this.Close();
                        return;//kayıt olmadığı için return ile bloğun dışına çıkıyoruz
                    }
                }
                else//kayıt varsa
                {
                    dgPurchase.DataSource = ds.Tables["History"];//sqlCmd sorgusu ile çektiğimiz kayıtlar datagridview1 üzerinde gösteriliyor    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Hata : " + ex); //Veritabanına bağlantı sırasında alınan bir hata varsa burada gösteriliyor
            }

            connection.Close();//Açık olan Sql bağlantısı sonlandırılıyor      
            da.Dispose(); //SqlDataApter nesnesi dispose ediliyor
        }

        private void NewPurchaseOrder_Load(object sender, EventArgs e)
        {
            
             NewFicheNo();
        }


        private string NewFicheNo()
        {
            IMEEntities IME = new IMEEntities();
            string purchasecode = "";
            if (IME.PurchaseOrders.ToList().Count != 0) purchasecode = IME.PurchaseOrders.OrderByDescending(q => q.FicheNo).FirstOrDefault().FicheNo;
            string custmrnumbers = string.Empty;
            string newpurchasecodenumbers = "";
            string newpurchasecodezeros = "";
            string newpurchasecodechars = "";
            for (int i = 0; i < purchasecode.Length; i++)
            {
                if (Char.IsDigit(purchasecode[i]))
                {
                    if (purchasecode[i] == '0') { newpurchasecodezeros += purchasecode[i]; } else { newpurchasecodenumbers += purchasecode[i]; }
                }
                else
                {
                    newpurchasecodechars += purchasecode[i];
                }
            }
            //Aynı FicheNo ile PurchaseOrder oluşturmasını önleyen kısım
            while (IME.PurchaseOrders.Where(a => a.FicheNo == purchasecode).Count() > 0)
            {
                newpurchasecodenumbers = (Int32.Parse(newpurchasecodenumbers) + 1).ToString();
                purchasecode = newpurchasecodechars + newpurchasecodezeros + newpurchasecodenumbers;
            }
            txtOrderNumber.Text = purchasecode;
            PurchaseExportFiles f = new PurchaseExportFiles(txtOrderNumber.Text);
            return purchasecode;
        }
    }
}
