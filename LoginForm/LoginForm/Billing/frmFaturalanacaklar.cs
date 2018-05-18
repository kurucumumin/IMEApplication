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

namespace LoginForm.Billing
{
    public partial class frmFaturalanacaklar : Form
    {
        IMEEntities IME = new IMEEntities();

        public frmFaturalanacaklar()
        {
            InitializeComponent();
        }

        private void frmFaturalanacaklar_Load(object sender, EventArgs e)
        {
            BillingFill();
        }

        private void BillingFill()
        {
            IME = new IMEEntities();
            dgFaturalanacak.Rows.Clear();
            #region BillingFill
            var adapter = (from sd in IME.SaleOrderDetails
                           from st in IME.Stocks.Where(a => a.ProductID == sd.ItemCode).DefaultIfEmpty()
                           where sd.SentItemQuantity>0
                           select new
                           {
                           sd.SaleOrder.SaleDate,
                           sd.SaleOrder.SaleOrderNo,
                           sd.SaleOrder.Customer.c_name,
                           sd.ItemCode,
                           sd.Quantity,
                           sd.SentItemQuantity,
                           KalanMiktar = (sd.SentItemQuantity != null) ? sd.Quantity - sd.SentItemQuantity : sd.Quantity,
                           Qty = (st != null) ? st.Qty : 0,
                           sd.UPIME,
                           sd.SaleOrder.ExchangeRate.Currency.currencyName,
                           sd.SaleOrder.CustomerAddress1.AdressDetails,
                           sd.SaleOrder.QuotationNos,
                           sd.SaleOrder.LPONO,
                           sd.SaleOrder.Customer.taxoffice,
                           sd.SaleOrder.Customer.taxnumber,
                           sd.SaleOrder.Customer.Note.Note_name,
                           sd.SaleOrder.Customer.CustomerWorker.cw_name,
                           SatirNotu=""/*sd.SaleOrder.NoteForUs*/,
                           KesimTarihi= ""/*sd.SaleOrder.SaleDate*/,
                           SonGirisTarihi= ""/*sd.SaleOrder.Worker.joiningDate*/,
                           sd.SaleOrder.Worker.NameLastName
                           }).ToList();

            foreach (var item in adapter)
            {
                int rowIndex = dgFaturalanacak.Rows.Add();
                DataGridViewRow row = dgFaturalanacak.Rows[rowIndex];


                row.Cells[SiparisTarihi.Index].Value = item.SaleDate;
                row.Cells[TeklifNo.Index].Value = item.SaleOrderNo;
                row.Cells[MusteriAdi.Index].Value = item.c_name;
                row.Cells[UrunKodu.Index].Value = item.ItemCode;
                row.Cells[SiparisAdet.Index].Value = item.Quantity;
                row.Cells[OncedenKesMiktar.Index].Value = item.SentItemQuantity;
                row.Cells[KalanMiktar.Index].Value = item.KalanMiktar;
                row.Cells[StockMiktar.Index].Value = item.Qty;
                row.Cells[UrunFiyat.Index].Value = item.UPIME;
                row.Cells[Doviz.Index].Value = item.currencyName;
                row.Cells[FaturaAdresi.Index].Value = item.AdressDetails;
                row.Cells[QuotationNotes.Index].Value = item.QuotationNos;
                row.Cells[MusteriTeklifNo.Index].Value = item.LPONO;
                row.Cells[VergiDairesi.Index].Value = item.taxoffice;
                row.Cells[VergiNo.Index].Value = item.taxnumber;
                row.Cells[CompanyNotes.Index].Value = item.Note_name;
                row.Cells[Yetkili.Index].Value = item.cw_name;
                row.Cells[KesimTarihi.Index].Value = item.KesimTarihi;
                row.Cells[SonGirisTarihi.Index].Value = item.SonGirisTarihi;
                row.Cells[SatirNotu.Index].Value = item.SatirNotu;
                row.Cells[Ekleyen.Index].Value = item.NameLastName;
            }
            #endregion
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            //   sd.SentItemQuantity == 0 olan satırı sil.
            BillingFill();

        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            //   Emrah abiye sor.
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnNot_Click(object sender, EventArgs e)
        {
            // Gridde satır notunun readonly si false ken bu butona basınca true oluyo ve not yazıı aktifleşiyor.
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Program ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
