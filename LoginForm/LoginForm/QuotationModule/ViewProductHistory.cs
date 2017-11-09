using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class ViewProductHistory : Form
    {
        SqlDataAdapter da;
        System.Data.DataSet ds=new System.Data.DataSet();

        public ViewProductHistory()
        {
            InitializeComponent();
        }

        private void ViewProductHistory_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        public ViewProductHistory(string item_code)
        {
            InitializeComponent();
            ProductHistory(item_code);
        }

        public void ProductHistory(string item_code)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-51RN2GB\LOCAL;Initial Catalog=IME;Integrated Security=True");
            StringBuilder history = new StringBuilder();
            history.Append("Select c.ItemCode,a.ID,a.c_name, b.StartDate, b.QuotationNo, c.Qty, b.CurrName, c.Disc ");
            history.Append("from Customer a, Quotation b, QuotationDetail c where b.CustomerID=a.ID and b.QuotationNo=c.QuotationNo ");
            history.Append("and c.ItemCode=");
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
                    MessageBox.Show("Kayıt bulunamadı");
                    return;//kayıt olmadığı için return ile bloğun dışına çıkıyoruz
                }
                else//kayıt varsa
                {
                    dgProductHistory.DataSource = ds.Tables["History"];//sqlCmd sorgusu ile çektiğimiz kayıtlar datagridview1 üzerinde gösteriliyor    
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Hata : " + ex); //Veritabanına bağlantı sırasında alınan bir hata varsa burada gösteriliyor
            }

            connection.Close();//Açık olan Sql bağlantısı sonlandırılıyor      
            da.Dispose(); //SqlDataApter nesnesi dispose ediliyor
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FormQuotationAdd frm = new FormQuotationAdd();
            this.Hide();
            frm.Show();
        }
    }
}
