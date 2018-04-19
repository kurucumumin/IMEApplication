namespace LoginForm.Billing
{
    partial class frmFaturalanacaklar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgFaturalanacak = new System.Windows.Forms.DataGridView();
            this.SiparisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeklifNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrunKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiparisAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OncedenKesMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KalanMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrunFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doviz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturaAdresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriTeklifNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VergiDairesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VergiNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Yetkili = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KesimTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SonGirisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SatirNotu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ekleyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnFiltre = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btncikis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaturalanacak)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFaturalanacak
            // 
            this.dgFaturalanacak.AllowUserToAddRows = false;
            this.dgFaturalanacak.AllowUserToDeleteRows = false;
            this.dgFaturalanacak.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFaturalanacak.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SiparisTarihi,
            this.TeklifNo,
            this.MusteriAdi,
            this.UrunKodu,
            this.SiparisAdet,
            this.OncedenKesMiktar,
            this.KalanMiktar,
            this.StockMiktar,
            this.UrunFiyat,
            this.Doviz,
            this.FaturaAdresi,
            this.QuotationNotes,
            this.MusteriTeklifNo,
            this.VergiDairesi,
            this.VergiNo,
            this.CompanyNotes,
            this.Yetkili,
            this.KesimTarihi,
            this.SonGirisTarihi,
            this.SatirNotu,
            this.Ekleyen});
            this.dgFaturalanacak.Location = new System.Drawing.Point(12, 93);
            this.dgFaturalanacak.Name = "dgFaturalanacak";
            this.dgFaturalanacak.ReadOnly = true;
            this.dgFaturalanacak.Size = new System.Drawing.Size(1137, 432);
            this.dgFaturalanacak.TabIndex = 0;
            // 
            // SiparisTarihi
            // 
            this.SiparisTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SiparisTarihi.HeaderText = "SiparisTarihi";
            this.SiparisTarihi.Name = "SiparisTarihi";
            this.SiparisTarihi.ReadOnly = true;
            this.SiparisTarihi.Width = 89;
            // 
            // TeklifNo
            // 
            this.TeklifNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TeklifNo.HeaderText = "TeklifNo";
            this.TeklifNo.Name = "TeklifNo";
            this.TeklifNo.ReadOnly = true;
            this.TeklifNo.Width = 72;
            // 
            // MusteriAdi
            // 
            this.MusteriAdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MusteriAdi.HeaderText = "MusteriAdi";
            this.MusteriAdi.Name = "MusteriAdi";
            this.MusteriAdi.ReadOnly = true;
            this.MusteriAdi.Width = 81;
            // 
            // UrunKodu
            // 
            this.UrunKodu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UrunKodu.HeaderText = "UrunKodu";
            this.UrunKodu.Name = "UrunKodu";
            this.UrunKodu.ReadOnly = true;
            this.UrunKodu.Width = 80;
            // 
            // SiparisAdet
            // 
            this.SiparisAdet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SiparisAdet.HeaderText = "SiparisAdet";
            this.SiparisAdet.Name = "SiparisAdet";
            this.SiparisAdet.ReadOnly = true;
            this.SiparisAdet.Width = 85;
            // 
            // OncedenKesMiktar
            // 
            this.OncedenKesMiktar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OncedenKesMiktar.HeaderText = "OncedenKesMiktar";
            this.OncedenKesMiktar.Name = "OncedenKesMiktar";
            this.OncedenKesMiktar.ReadOnly = true;
            this.OncedenKesMiktar.Width = 123;
            // 
            // KalanMiktar
            // 
            this.KalanMiktar.HeaderText = "KalanMiktar";
            this.KalanMiktar.Name = "KalanMiktar";
            this.KalanMiktar.ReadOnly = true;
            // 
            // StockMiktar
            // 
            this.StockMiktar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StockMiktar.HeaderText = "StockMiktar";
            this.StockMiktar.Name = "StockMiktar";
            this.StockMiktar.ReadOnly = true;
            this.StockMiktar.Width = 89;
            // 
            // UrunFiyat
            // 
            this.UrunFiyat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UrunFiyat.HeaderText = "UrunFiyat";
            this.UrunFiyat.Name = "UrunFiyat";
            this.UrunFiyat.ReadOnly = true;
            this.UrunFiyat.Width = 77;
            // 
            // Doviz
            // 
            this.Doviz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Doviz.HeaderText = "Doviz";
            this.Doviz.Name = "Doviz";
            this.Doviz.ReadOnly = true;
            this.Doviz.Width = 59;
            // 
            // FaturaAdresi
            // 
            this.FaturaAdresi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FaturaAdresi.HeaderText = "FaturaAdresi";
            this.FaturaAdresi.Name = "FaturaAdresi";
            this.FaturaAdresi.ReadOnly = true;
            this.FaturaAdresi.Width = 91;
            // 
            // QuotationNotes
            // 
            this.QuotationNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QuotationNotes.HeaderText = "QuotationNotes";
            this.QuotationNotes.Name = "QuotationNotes";
            this.QuotationNotes.ReadOnly = true;
            this.QuotationNotes.Width = 106;
            // 
            // MusteriTeklifNo
            // 
            this.MusteriTeklifNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MusteriTeklifNo.HeaderText = "MusteriTeklifNo";
            this.MusteriTeklifNo.Name = "MusteriTeklifNo";
            this.MusteriTeklifNo.ReadOnly = true;
            this.MusteriTeklifNo.Width = 106;
            // 
            // VergiDairesi
            // 
            this.VergiDairesi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VergiDairesi.HeaderText = "VergiDairesi";
            this.VergiDairesi.Name = "VergiDairesi";
            this.VergiDairesi.ReadOnly = true;
            this.VergiDairesi.Width = 88;
            // 
            // VergiNo
            // 
            this.VergiNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VergiNo.HeaderText = "VergiNo";
            this.VergiNo.Name = "VergiNo";
            this.VergiNo.ReadOnly = true;
            this.VergiNo.Width = 70;
            // 
            // CompanyNotes
            // 
            this.CompanyNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyNotes.HeaderText = "CompanyNotes";
            this.CompanyNotes.Name = "CompanyNotes";
            this.CompanyNotes.ReadOnly = true;
            this.CompanyNotes.Width = 104;
            // 
            // Yetkili
            // 
            this.Yetkili.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Yetkili.HeaderText = "Yetkili";
            this.Yetkili.Name = "Yetkili";
            this.Yetkili.ReadOnly = true;
            this.Yetkili.Width = 60;
            // 
            // KesimTarihi
            // 
            this.KesimTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KesimTarihi.HeaderText = "KesimTarihi";
            this.KesimTarihi.Name = "KesimTarihi";
            this.KesimTarihi.ReadOnly = true;
            this.KesimTarihi.Width = 86;
            // 
            // SonGirisTarihi
            // 
            this.SonGirisTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SonGirisTarihi.HeaderText = "SonGirisTarihi";
            this.SonGirisTarihi.Name = "SonGirisTarihi";
            this.SonGirisTarihi.ReadOnly = true;
            this.SonGirisTarihi.Width = 97;
            // 
            // SatirNotu
            // 
            this.SatirNotu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SatirNotu.HeaderText = "SatirNotu";
            this.SatirNotu.Name = "SatirNotu";
            this.SatirNotu.ReadOnly = true;
            this.SatirNotu.Width = 76;
            // 
            // Ekleyen
            // 
            this.Ekleyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ekleyen.HeaderText = "Ekleyen";
            this.Ekleyen.Name = "Ekleyen";
            this.Ekleyen.ReadOnly = true;
            this.Ekleyen.Width = 70;
            // 
            // btnNot
            // 
            this.btnNot.Location = new System.Drawing.Point(188, 12);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(82, 75);
            this.btnNot.TabIndex = 1;
            this.btnNot.Text = "Add Note";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(12, 12);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(82, 75);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.Text = "Refresh";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnFiltre
            // 
            this.btnFiltre.Location = new System.Drawing.Point(100, 12);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(82, 75);
            this.btnFiltre.TabIndex = 3;
            this.btnFiltre.Text = "Filter";
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(276, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(82, 75);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btncikis
            // 
            this.btncikis.Location = new System.Drawing.Point(364, 12);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(82, 75);
            this.btncikis.TabIndex = 5;
            this.btncikis.Text = "Exit";
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // frmFaturalanacaklar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 537);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnFiltre);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnNot);
            this.Controls.Add(this.dgFaturalanacak);
            this.Name = "frmFaturalanacaklar";
            this.Text = "Faturalanacaklar";
            this.Load += new System.EventHandler(this.frmFaturalanacaklar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgFaturalanacak)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFaturalanacak;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeklifNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrunKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn OncedenKesMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn KalanMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrunFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doviz;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturaAdresi;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriTeklifNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn VergiDairesi;
        private System.Windows.Forms.DataGridViewTextBoxColumn VergiNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Yetkili;
        private System.Windows.Forms.DataGridViewTextBoxColumn KesimTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SonGirisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SatirNotu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ekleyen;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnFiltre;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btncikis;
    }
}