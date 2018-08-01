namespace LoginForm.AçıkSipariş
{
    partial class frmAcikSiparis
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
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnAnaliz = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnTemizli = new System.Windows.Forms.Button();
            this.dgAcikSiparis = new System.Windows.Forms.DataGridView();
            this.SiparisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriSiparisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tedarikci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeklifNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CariUnvani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hazırlayan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturaTemsilcisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RSkodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Birim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriyeGonderilmisAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UKfaturalananAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturalanmayiBekleyenAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MusteriyeFaturalanmisAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiparisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeslimEdilecekTarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMEvarisTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiparisTuru = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockKodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaturaTarihi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GumrukDurumu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirimFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirmaYetkilisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackOrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackOrderAdet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgAcikSiparis)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(100, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(82, 75);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnAnaliz
            // 
            this.btnAnaliz.Location = new System.Drawing.Point(12, 12);
            this.btnAnaliz.Name = "btnAnaliz";
            this.btnAnaliz.Size = new System.Drawing.Size(82, 75);
            this.btnAnaliz.TabIndex = 6;
            this.btnAnaliz.Text = "Analysis";
            this.btnAnaliz.UseVisualStyleBackColor = true;
            this.btnAnaliz.Click += new System.EventHandler(this.btnAnaliz_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(188, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 75);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 93);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(482, 20);
            this.txtSearch.TabIndex = 9;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(504, 93);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(121, 20);
            this.btnAra.TabIndex = 11;
            this.btnAra.Text = "Search";
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // btnTemizli
            // 
            this.btnTemizli.Location = new System.Drawing.Point(631, 93);
            this.btnTemizli.Name = "btnTemizli";
            this.btnTemizli.Size = new System.Drawing.Size(121, 20);
            this.btnTemizli.TabIndex = 10;
            this.btnTemizli.Text = "Clean";
            this.btnTemizli.UseVisualStyleBackColor = true;
            // 
            // dgAcikSiparis
            // 
            this.dgAcikSiparis.AllowUserToAddRows = false;
            this.dgAcikSiparis.AllowUserToDeleteRows = false;
            this.dgAcikSiparis.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgAcikSiparis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAcikSiparis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SiparisNo,
            this.MusteriSiparisNo,
            this.Tedarikci,
            this.TeklifNo,
            this.CariUnvani,
            this.Hazırlayan,
            this.FaturaTemsilcisi,
            this.RSkodu,
            this.HZ,
            this.CAL,
            this.Adet,
            this.Birim,
            this.MusteriyeGonderilmisAdet,
            this.UKfaturalananAdet,
            this.FaturalanmayiBekleyenAdet,
            this.MusteriyeFaturalanmisAdet,
            this.SiparisTarihi,
            this.TeslimEdilecekTarih,
            this.IMEvarisTarihi,
            this.SiparisTuru,
            this.MPN,
            this.StockKodu,
            this.FaturaTarihi,
            this.GumrukDurumu,
            this.BirimFiyat,
            this.FirmaYetkilisi,
            this.RequestDeliveryDate,
            this.BackOrderDate,
            this.BackOrderAdet});
            this.dgAcikSiparis.Location = new System.Drawing.Point(12, 119);
            this.dgAcikSiparis.Name = "dgAcikSiparis";
            this.dgAcikSiparis.ReadOnly = true;
            this.dgAcikSiparis.Size = new System.Drawing.Size(1137, 432);
            this.dgAcikSiparis.TabIndex = 12;
            // 
            // SiparisNo
            // 
            this.SiparisNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SiparisNo.HeaderText = "SiparisNo";
            this.SiparisNo.Name = "SiparisNo";
            this.SiparisNo.ReadOnly = true;
            this.SiparisNo.Width = 77;
            // 
            // MusteriSiparisNo
            // 
            this.MusteriSiparisNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MusteriSiparisNo.HeaderText = "MusteriSiparisNo";
            this.MusteriSiparisNo.Name = "MusteriSiparisNo";
            this.MusteriSiparisNo.ReadOnly = true;
            this.MusteriSiparisNo.Width = 111;
            // 
            // Tedarikci
            // 
            this.Tedarikci.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tedarikci.HeaderText = "Tedarikci";
            this.Tedarikci.Name = "Tedarikci";
            this.Tedarikci.ReadOnly = true;
            this.Tedarikci.Width = 76;
            // 
            // TeklifNo
            // 
            this.TeklifNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TeklifNo.HeaderText = "TeklifNo";
            this.TeklifNo.Name = "TeklifNo";
            this.TeklifNo.ReadOnly = true;
            this.TeklifNo.Width = 72;
            // 
            // CariUnvani
            // 
            this.CariUnvani.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CariUnvani.HeaderText = "CariUnvani";
            this.CariUnvani.Name = "CariUnvani";
            this.CariUnvani.ReadOnly = true;
            this.CariUnvani.Width = 84;
            // 
            // Hazırlayan
            // 
            this.Hazırlayan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Hazırlayan.HeaderText = "Hazırlayan";
            this.Hazırlayan.Name = "Hazırlayan";
            this.Hazırlayan.ReadOnly = true;
            this.Hazırlayan.Width = 81;
            // 
            // FaturaTemsilcisi
            // 
            this.FaturaTemsilcisi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FaturaTemsilcisi.HeaderText = "FaturaTemsilcisi";
            this.FaturaTemsilcisi.Name = "FaturaTemsilcisi";
            this.FaturaTemsilcisi.ReadOnly = true;
            this.FaturaTemsilcisi.Width = 107;
            // 
            // RSkodu
            // 
            this.RSkodu.HeaderText = "RSkodu";
            this.RSkodu.Name = "RSkodu";
            this.RSkodu.ReadOnly = true;
            // 
            // HZ
            // 
            this.HZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HZ.HeaderText = "HZ";
            this.HZ.Name = "HZ";
            this.HZ.ReadOnly = true;
            this.HZ.Width = 47;
            // 
            // CAL
            // 
            this.CAL.HeaderText = "CAL";
            this.CAL.Name = "CAL";
            this.CAL.ReadOnly = true;
            // 
            // Adet
            // 
            this.Adet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Adet.HeaderText = "Adet";
            this.Adet.Name = "Adet";
            this.Adet.ReadOnly = true;
            this.Adet.Width = 54;
            // 
            // Birim
            // 
            this.Birim.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Birim.HeaderText = "Birim";
            this.Birim.Name = "Birim";
            this.Birim.ReadOnly = true;
            this.Birim.Width = 54;
            // 
            // MusteriyeGonderilmisAdet
            // 
            this.MusteriyeGonderilmisAdet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MusteriyeGonderilmisAdet.HeaderText = "MusteriyeGonderilmisAdet";
            this.MusteriyeGonderilmisAdet.Name = "MusteriyeGonderilmisAdet";
            this.MusteriyeGonderilmisAdet.ReadOnly = true;
            this.MusteriyeGonderilmisAdet.Width = 153;
            // 
            // UKfaturalananAdet
            // 
            this.UKfaturalananAdet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UKfaturalananAdet.HeaderText = "UKfaturalananAdet";
            this.UKfaturalananAdet.Name = "UKfaturalananAdet";
            this.UKfaturalananAdet.ReadOnly = true;
            this.UKfaturalananAdet.Width = 122;
            // 
            // FaturalanmayiBekleyenAdet
            // 
            this.FaturalanmayiBekleyenAdet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FaturalanmayiBekleyenAdet.HeaderText = "FaturalanmayiBekleyenAdet";
            this.FaturalanmayiBekleyenAdet.Name = "FaturalanmayiBekleyenAdet";
            this.FaturalanmayiBekleyenAdet.ReadOnly = true;
            this.FaturalanmayiBekleyenAdet.Width = 163;
            // 
            // MusteriyeFaturalanmisAdet
            // 
            this.MusteriyeFaturalanmisAdet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MusteriyeFaturalanmisAdet.HeaderText = "MusteriyeFaturalanmisAdet";
            this.MusteriyeFaturalanmisAdet.Name = "MusteriyeFaturalanmisAdet";
            this.MusteriyeFaturalanmisAdet.ReadOnly = true;
            this.MusteriyeFaturalanmisAdet.Width = 158;
            // 
            // SiparisTarihi
            // 
            this.SiparisTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SiparisTarihi.HeaderText = "SiparisTarihi";
            this.SiparisTarihi.Name = "SiparisTarihi";
            this.SiparisTarihi.ReadOnly = true;
            this.SiparisTarihi.Width = 89;
            // 
            // TeslimEdilecekTarih
            // 
            this.TeslimEdilecekTarih.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TeslimEdilecekTarih.HeaderText = "TeslimEdilecekTarih";
            this.TeslimEdilecekTarih.Name = "TeslimEdilecekTarih";
            this.TeslimEdilecekTarih.ReadOnly = true;
            this.TeslimEdilecekTarih.Width = 127;
            // 
            // IMEvarisTarihi
            // 
            this.IMEvarisTarihi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IMEvarisTarihi.HeaderText = "IMEvarisTarihi";
            this.IMEvarisTarihi.Name = "IMEvarisTarihi";
            this.IMEvarisTarihi.ReadOnly = true;
            this.IMEvarisTarihi.Width = 99;
            // 
            // SiparisTuru
            // 
            this.SiparisTuru.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SiparisTuru.HeaderText = "SiparisTuru";
            this.SiparisTuru.Name = "SiparisTuru";
            this.SiparisTuru.ReadOnly = true;
            this.SiparisTuru.Width = 85;
            // 
            // MPN
            // 
            this.MPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MPN.HeaderText = "MPN";
            this.MPN.Name = "MPN";
            this.MPN.ReadOnly = true;
            this.MPN.Width = 56;
            // 
            // StockKodu
            // 
            this.StockKodu.HeaderText = "StockKodu";
            this.StockKodu.Name = "StockKodu";
            this.StockKodu.ReadOnly = true;
            // 
            // FaturaTarihi
            // 
            this.FaturaTarihi.HeaderText = "FaturaTarihi";
            this.FaturaTarihi.Name = "FaturaTarihi";
            this.FaturaTarihi.ReadOnly = true;
            // 
            // GumrukDurumu
            // 
            this.GumrukDurumu.HeaderText = "GumrukDurumu";
            this.GumrukDurumu.Name = "GumrukDurumu";
            this.GumrukDurumu.ReadOnly = true;
            // 
            // BirimFiyat
            // 
            this.BirimFiyat.HeaderText = "BirimFiyat";
            this.BirimFiyat.Name = "BirimFiyat";
            this.BirimFiyat.ReadOnly = true;
            // 
            // FirmaYetkilisi
            // 
            this.FirmaYetkilisi.HeaderText = "FirmaYetkilisi";
            this.FirmaYetkilisi.Name = "FirmaYetkilisi";
            this.FirmaYetkilisi.ReadOnly = true;
            // 
            // RequestDeliveryDate
            // 
            this.RequestDeliveryDate.HeaderText = "RequestDeliveryDate";
            this.RequestDeliveryDate.Name = "RequestDeliveryDate";
            this.RequestDeliveryDate.ReadOnly = true;
            // 
            // BackOrderDate
            // 
            this.BackOrderDate.HeaderText = "BackOrderDate";
            this.BackOrderDate.Name = "BackOrderDate";
            this.BackOrderDate.ReadOnly = true;
            // 
            // BackOrderAdet
            // 
            this.BackOrderAdet.HeaderText = "BackOrderAdet";
            this.BackOrderAdet.Name = "BackOrderAdet";
            this.BackOrderAdet.ReadOnly = true;
            // 
            // frmAcikSiparis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1028, 562);
            this.Controls.Add(this.dgAcikSiparis);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.btnTemizli);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnAnaliz);
            this.Controls.Add(this.btnExit);
            this.Name = "frmAcikSiparis";
            this.Text = "Açık Sipariş";
            this.Load += new System.EventHandler(this.frmAcikSiparis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAcikSiparis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnAnaliz;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.Button btnTemizli;
        private System.Windows.Forms.DataGridView dgAcikSiparis;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriSiparisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tedarikci;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeklifNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CariUnvani;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hazırlayan;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturaTemsilcisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RSkodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Birim;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriyeGonderilmisAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn UKfaturalananAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturalanmayiBekleyenAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MusteriyeFaturalanmisAdet;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TeslimEdilecekTarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMEvarisTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiparisTuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn MPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockKodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaturaTarihi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GumrukDurumu;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirimFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirmaYetkilisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackOrderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackOrderAdet;
    }
}