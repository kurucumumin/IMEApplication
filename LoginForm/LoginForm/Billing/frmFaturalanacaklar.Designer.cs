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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgFaturalanacak)).BeginInit();
            this.SuspendLayout();
            // 
            // dgFaturalanacak
            // 
            this.dgFaturalanacak.AllowUserToAddRows = false;
            this.dgFaturalanacak.AllowUserToDeleteRows = false;
            this.dgFaturalanacak.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
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
            this.btnNot.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnNot.Location = new System.Drawing.Point(183, 12);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(48, 43);
            this.btnNot.TabIndex = 1;
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Image = global::LoginForm.Properties.Resources.icons8_Refresh_32;
            this.btnYenile.Location = new System.Drawing.Point(21, 12);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(53, 43);
            this.btnYenile.TabIndex = 2;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnFiltre
            // 
            this.btnFiltre.Image = global::LoginForm.Properties.Resources.if_filter_173013;
            this.btnFiltre.Location = new System.Drawing.Point(99, 12);
            this.btnFiltre.Name = "btnFiltre";
            this.btnFiltre.Size = new System.Drawing.Size(48, 43);
            this.btnFiltre.TabIndex = 3;
            this.btnFiltre.UseVisualStyleBackColor = true;
            this.btnFiltre.Click += new System.EventHandler(this.btnFiltre_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::LoginForm.Properties.Resources.if_Document_file_export_sending_exit_send_1886950;
            this.btnExcel.Location = new System.Drawing.Point(275, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(48, 43);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btncikis
            // 
            this.btncikis.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btncikis.Location = new System.Drawing.Point(361, 12);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(48, 43);
            this.btncikis.TabIndex = 5;
            this.btncikis.UseVisualStyleBackColor = true;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Refresh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Add Note";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Excel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Exit";
            // 
            // frmFaturalanacaklar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1161, 537);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}