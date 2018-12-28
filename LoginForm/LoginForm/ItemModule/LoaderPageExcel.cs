using LoginForm.DataSet;
using LoginForm.MyClasses;
using LoginForm.Services;
using LoginForm.Services.SP;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginForm.ItemModule;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LoginForm
{
    public partial class LoaderPageExcel : Form
    {
        IMEEntities IME = new IMEEntities();
        private Stopwatch _Timer;

        public LoaderPageExcel()
        {
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgItem, new object[] { true });
            _Timer = new Stopwatch();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            #region LoaderPage
            switch (txtReader.LoaderType)
            {
                case "OnSale":
                    OnSaleHelper OnSaleHelper = new OnSaleHelper();

                    if (txtReader.OnSaleRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = OnSaleHelper.FileName;
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    break;

                case "DiscontinuedList":
                    if (txtReader.DiscontinuedListRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "DualUse":
                    if (txtReader.DualUsedRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "Hazardous":

                    #region New Hazardouse 

                    OpenFileDialog OFD = new OpenFileDialog();

                    OFD.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
                    OFD.Title = "Excel Dosyası Seçiniz..";
                    OFD.RestoreDirectory = true;

                    try
                    {
                        if (OFD.ShowDialog() == DialogResult.OK)
                        // perncere açıldığında dosya seçildi ise yapılacak. Bunu yazmazsak dosya seçmeden 
                        // kapandığında program kırılacaktır.
                        {
                            string DosyaYolu = OFD.FileName;// dosya yolu
                            string DosyaAdi = OFD.SafeFileName; // dosya adı

                            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DosyaYolu + "; Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'");
                            // excel dosyasına access db gibi bağlanıyoruz.
                            baglanti.Open();
                            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [Sayfa2$]", baglanti);
                            // burada FROM dan sonra sayfa1$ kısmı önemlidir.sayfa adı faklı ise örn
                            // sheet ise program hata verecektir.
                            // NOT: Excel dosyanızın ilk satır başlık olsun. Yani sistem öyle algıladığından 
                            // ilk satırdaki bilgileri başlık olarak tanımlayıp almıyor. Ne yazarsanız yazın
                            // sorun teşkil etmiyor. Tabi db için özel olan karakterleri kullanmayın.
                            DataTable DTexcel = new DataTable();
                            da.Fill(DTexcel);
                            // select sorgusu ile okunan verileri datatable'ye aktarıyoruz.

                            dgItem.DataSource = DTexcel;
                            // datatable'ı da gridcontrol'ün datasource'una atıyoruz.
                            baglanti.Close();
                            // bağlantıyı kapatıyoruz.

                            RsFileHistory h = new RsFileHistory();
                            h.FileType = txtReader.LoaderType;
                            h.FileName = DosyaAdi;
                            h.Date = Utils.GetCurrentDateTime();
                            h.UserID = Utils.getCurrentUser().WorkerID;
                            IME.RsFileHistories.Add(h);
                            IME.SaveChanges();

                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    #endregion
                    break;
                case "ExtendedRange":
                    if (txtReader.EntendedRangeRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "TSE":
                    
                    break;
                case "RSPro":
                    if (txtReader.RSProRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "OrderAcknowledgementtxtReader":
                    txtReader.OrderAcknowledgementtxtReader();
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    
                    break;
            }
            #endregion  
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            #region LoaderPage
            switch (txtReader.LoaderType)
            {
                case "OnSale":
                    OnSaleHelper OnSaleHelper = new OnSaleHelper();

                    if (txtReader.OnSaleRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = OnSaleHelper.FileName;
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    break;

                case "DiscontinuedList":
                    if (txtReader.DiscontinuedListRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "DualUse":
                    if (txtReader.DualUsedRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "Hazardous":

                    #region New Hazardouse 
                    SqlCommand cmd;
                    SqlConnection ImeSqlConn = new Utils().ImeSqlConnection();
                    SqlTransaction ImeSqlTransaction = ImeSqlConn.BeginTransaction();
                    int ItemCount = 0;
                    try
                    {
                        for (int i = 0; i < dgItem.RowCount-1; i++)
                        {
                            _Timer.Start();

                            cmd = new SqlCommand
                            {
                                Connection = ImeSqlConn,
                                CommandType = CommandType.StoredProcedure,
                                Transaction = ImeSqlTransaction,
                                CommandText = @"[HazardouseAdd]"
                            };
                            cmd.Parameters.AddWithValue("@ArticleNo", dgItem.Rows[i].Cells["ArticleNo"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Occurrences", dgItem.Rows[i].Cells["Occurrences"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Environment", dgItem.Rows[i].Cells["Environment"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Shipping", dgItem.Rows[i].Cells["Shipping"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Lithium", dgItem.Rows[i].Cells["Lithium"].Value.ToString());

                            cmd.ExecuteNonQuery();
                            ItemCount++;
                        }
                        _Timer.Stop();
                        MessageBox.Show(ItemCount + " item is added! " + "\n\n" + "Passed Time: " + _Timer.Elapsed.ToString(@"hh\:mm\:ss") + " sn", "Success");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    #endregion
                    break;
                case "ExtendedRange":
                    if (txtReader.EntendedRangeRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
                case "TSE":
                    
                    break;
                case "RSPro":
                    if (txtReader.RSProRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }

                    break;
               
                case "OrderAcknowledgementtxtReader":
                    txtReader.OrderAcknowledgementtxtReader();
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    
                    break;
                    
            }
            #endregion  
        }
    }
}
