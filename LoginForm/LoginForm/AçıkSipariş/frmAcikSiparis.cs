using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;

namespace LoginForm.AçıkSipariş
{
    public partial class frmAcikSiparis : Form
    {
        IMEEntities IME = new IMEEntities();

        public frmAcikSiparis()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void DataFill()
        {
            IME = new IMEEntities();
            dgAcikSiparis.Rows.Clear();
            #region BillingFill
            var adapter = (from sd in IME.SaleOrderDetails
                           from st in IME.Stocks.Where(a => a.ProductID == sd.ItemCode).DefaultIfEmpty()
                           where sd.SentItemQuantity > 0
                           select new
                           {
                               sd.SaleOrder.SaleOrderNo,
                               sd.SaleOrder.LPONO, //Müşteri Sipariş No 
                               //TODO: Ürün Supplier ilişkisinden sonra düzeltilecek.
                               Supplier = (sd.SaleOrderID != null) ? "RS" : "RS", //supplier name
                               sd.QuotationDetail.QuotationNo,
                               sd.SaleOrder.Customer.c_name, //Cari Unvanı
                               sd.SaleOrder.Worker.NameLastName, //Hazırlayan. RepresentativeID
                               sd.SaleOrder.Customer.Worker.UserName,//Firma Yetkilisi
                               st.ProductID,
                               HZ = (sd.Hazardous != null) ? sd.Hazardous : false,
                               CAL= (sd.Calibration != null) ? sd.Calibration : false,
                               sd.Quantity,
                               sd.UnitOfMeasure,
                               KalanMiktar = (sd.SentItemQuantity != null) ? sd.Quantity - sd.SentItemQuantity : sd.Quantity,
                              UKfaturalananAdet= sd.SaleOrder.PurchaseOrderDetails.Where(x=>x.ItemCode==sd.ItemCode).FirstOrDefault().PurchaseOrder.RS_InvoiceDetails.Where(y=> y.ProductNumber==sd.ItemCode).FirstOrDefault().Quantity,
                               StockMiktari=sd.SaleOrder.StockReserves.Where(x=> x.ProductID==sd.ItemCode).FirstOrDefault().Qty,//faturalanmayı bekleyen adet. O müşteri için stock miktarı
                               MusteriyeFaturalanmisBekleyenAdet=sd.SalesDetails.Sum(x=> x.qty).Value, //müşteriye faturalanmış bekleyen adet
                               sd.SaleOrder.SaleDate,
                               sd.SaleOrder.RequestedDeliveryDate,//temsil edilecek tarih
                               //ıme varış tarihi. (Imenin Stoğuna giriş tarihi)
                               sd.SaleOrder.SaleOrderNature,//sipariş turu
                               st.MPN,
                               sd.ItemCode,
                               FaturaTarihi=  sd.SaleOrder.PurchaseOrderDetails.Where(x => x.ItemCode == sd.ItemCode).FirstOrDefault().PurchaseOrder.RS_InvoiceDetails.Where(y => y.ProductNumber == sd.ItemCode).FirstOrDefault().RS_Invoice.BillingDocumentDate,
                               //gumruk durumu
                               sd.UPIME,
                               sd.SaleOrder.Customer.CustomerWorker.cw_name
                               //Bi tane daha alan ekleme onada bizim fatura tarihimiz. bunu ekle sonra doldur. goto logo derkenki
                               //BackOrder tarihi ve backOrder adeti ni ekle
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgAcikSiparis.Rows.Add();
                DataGridViewRow row = dgAcikSiparis.Rows[rowIndex];


                row.Cells[SiparisNo.Index].Value = item.SaleOrderNo;
                row.Cells[MusteriSiparisNo.Index].Value = item.LPONO;
                row.Cells[Tedarikci.Index].Value = item.Supplier;
                row.Cells[TeklifNo.Index].Value = item.QuotationNo;
                row.Cells[CariUnvani.Index].Value = item.c_name;
                row.Cells[Hazırlayan.Index].Value = item.NameLastName;
                row.Cells[FirmaYetkilisi.Index].Value = item.UserName;
                row.Cells[RSkodu.Index].Value = item.ProductID;
                row.Cells[HZ.Index].Value = item.HZ;
                row.Cells[CAL.Index].Value = item.CAL;
                row.Cells[Adet.Index].Value = item.Quantity;
                row.Cells[Birim.Index].Value = item.UnitOfMeasure;
                row.Cells[MusteriyeGonderilmisAdet.Index].Value = item.KalanMiktar;
                row.Cells[UKfaturalananAdet.Index].Value = item.UKfaturalananAdet;
                row.Cells[FaturalanmayiBekleyenAdet.Index].Value = item.StockMiktari;
                row.Cells[MusteriyeFaturalanmisAdet.Index].Value = item.MusteriyeFaturalanmisBekleyenAdet;
                row.Cells[SiparisTarihi.Index].Value = item.SaleDate;
                row.Cells[TeslimEdilecekTarih.Index].Value = item.RequestedDeliveryDate;
                //ıme varış tarihi
                row.Cells[SiparisTuru.Index].Value = item.SaleOrderNature;
                row.Cells[MPN.Index].Value = item.MPN;
                row.Cells[StockKodu.Index].Value = item.ItemCode;
                row.Cells[FaturaTarihi.Index].Value = item.FaturaTarihi;
                //gumruk durumu
                row.Cells[BirimFiyat.Index].Value = item.UPIME;
                row.Cells[FirmaYetkilisi.Index].Value = item.cw_name;
                //delivery date
            }
            #endregion
        }

        private void frmAcikSiparis_Load(object sender, EventArgs e)
        {
            DataFill();
        }

        private void btnAnaliz_Click(object sender, EventArgs e)
        {
            DataFill();
        }
    }
}
