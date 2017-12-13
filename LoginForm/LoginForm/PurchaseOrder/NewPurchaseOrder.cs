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
        string purchasecode = "";


        public NewPurchaseOrder()
        {
            InitializeComponent();
        }

        public NewPurchaseOrder(string item_code)
        {
            InitializeComponent();
            PurchaseOrder(item_code);
        }

        public NewPurchaseOrder(string ficheNo, int sayac)
        {
            InitializeComponent();
            if (sayac==1)
                ViewPurchaseOrdersDetail(ficheNo);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowList = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dgPurchase.Rows)
            {
                if (row.Cells[0].Value!=null && (bool)row.Cells[0].Value == true)
                {
                    rowList.Add(row);
                }
            }

            PurchaseExportFiles form = new PurchaseExportFiles(rowList, (Int32.Parse(purchasecode)+1).ToString());
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
                pod.Hazardous = sod.Hazardous??false;
                pod.Calibration = sod.Calibration ?? false;

                purchaseList.Add(pod);
            }

            dgPurchase.DataSource = purchaseList;
        }

        public void PurchaseOrder(string item_code)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.;Initial Catalog=IME;Integrated Security=True");
            StringBuilder history = new StringBuilder();
            history.Append("Select a.c_name,b.QuotationNos, b.SaleOrderNo, c.ItemCode, c.ItemDescription, c.UnitOfMeasure, c.Quantity, c.Hazardous, ");
            history.Append("c.Calibration, b.SaleOrderNature, d.AddressType, d.AdressTitle, c.UPIME ");
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

            #region GridColumnAyarı
            dgPurchase.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[1].HeaderText = "Customer Name";
            dgPurchase.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPurchase.Columns[2].HeaderText = "Quotation";
            dgPurchase.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPurchase.Columns[3].HeaderText = "Sale Orders";
            dgPurchase.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgPurchase.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgPurchase.Columns[5].HeaderText = "Description";
            dgPurchase.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[6].HeaderText = "Unit Of";
            dgPurchase.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[7].HeaderText = "Qty";
            dgPurchase.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[8].HeaderText = "HZ";
            dgPurchase.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[9].HeaderText = "CAL";
            dgPurchase.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[10].HeaderText = "Nature";
            dgPurchase.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[11].HeaderText = "Bill To";
            dgPurchase.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[12].HeaderText = "Ship To";
            dgPurchase.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[13].HeaderText = "Unit";
            #endregion
        }

        private void NewPurchaseOrder_Load(object sender, EventArgs e)
        {
            IMEEntities IME = new IMEEntities();
            purchasecode = IME.PurchaseOrders.OrderByDescending(q => q.FicheNo).FirstOrDefault().FicheNo;
            txtOrderNumber.Text = (Int32.Parse(purchasecode) + 1).ToString();
        }

        public void ViewPurchaseOrdersDetail(string ficheNo)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-51RN2GB\LOCAL;Initial Catalog=IME;Integrated Security=True");
            StringBuilder history = new StringBuilder();
            history.Append("Select ID, QuotationNo, SaleOrderNo, ItemCode, SendQty, SaleOrderNature, FrtType, ");
            history.Append("FicheNo, ItemDescription, Hazardous, Calibration, UnitPrice, Unit ");
            history.Append("from PurchaseOrderDetail ");
            history.Append("where FicheNo=");
            history.Append("'");
            history.Append(ficheNo);
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

            #region GridColumnAyarı
            dgPurchase.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgPurchase.Columns[2].HeaderText = "Quotation";
            dgPurchase.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgPurchase.Columns[3].HeaderText = "Sale Orders";
            dgPurchase.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgPurchase.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[5].HeaderText = "Qty";
            dgPurchase.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[6].HeaderText = "Nature";
            dgPurchase.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPurchase.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgPurchase.Columns[9].HeaderText = "Description";
            dgPurchase.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[10].HeaderText = "HZ";
            dgPurchase.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgPurchase.Columns[11].HeaderText = "CAL";
            dgPurchase.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPurchase.Columns[12].HeaderText = "Unit Price";
            dgPurchase.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgPurchase.Columns[13].HeaderText = "Unit";
            #endregion

            dgPurchase.ReadOnly = true;
            btnCreate.Enabled = false;
            txtOrderNumber.Enabled = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string PurchaseNo = dgPurchase.CurrentRow.Cells[1].Value.ToString();
            ExcelPurchaseOrder.Export(dgPurchase, PurchaseNo);
        }
    }
}
