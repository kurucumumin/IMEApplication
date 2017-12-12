namespace LoginForm
{
    partial class frmPurchaseInvoiceLoader
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
            this.button1 = new System.Windows.Forms.Button();
            this.PurchaseInvoiceList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PurchaseInvoiceItemList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFinalDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PurchaseInvoiceList
            // 
            this.PurchaseInvoiceList.FormattingEnabled = true;
            this.PurchaseInvoiceList.Location = new System.Drawing.Point(28, 94);
            this.PurchaseInvoiceList.Name = "PurchaseInvoiceList";
            this.PurchaseInvoiceList.Size = new System.Drawing.Size(215, 290);
            this.PurchaseInvoiceList.TabIndex = 1;
            this.PurchaseInvoiceList.SelectedIndexChanged += new System.EventHandler(this.PurchaseInvoiceList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Purchase Invoice";
            // 
            // PurchaseInvoiceItemList
            // 
            this.PurchaseInvoiceItemList.FormattingEnabled = true;
            this.PurchaseInvoiceItemList.Location = new System.Drawing.Point(296, 94);
            this.PurchaseInvoiceItemList.Name = "PurchaseInvoiceItemList";
            this.PurchaseInvoiceItemList.Size = new System.Drawing.Size(215, 290);
            this.PurchaseInvoiceItemList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Purchase Invoice Items";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(156, 26);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(108, 20);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Date";
            // 
            // dtpFinalDate
            // 
            this.dtpFinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinalDate.Location = new System.Drawing.Point(296, 26);
            this.dtpFinalDate.Name = "dtpFinalDate";
            this.dtpFinalDate.Size = new System.Drawing.Size(108, 20);
            this.dtpFinalDate.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Final Date";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "Change Date";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPurchaseInvoiceLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 456);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFinalDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PurchaseInvoiceItemList);
            this.Controls.Add(this.PurchaseInvoiceList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmPurchaseInvoiceLoader";
            this.Text = "frmPurchaseInvoiceLoader";
            this.Load += new System.EventHandler(this.frmPurchaseInvoiceLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox PurchaseInvoiceList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PurchaseInvoiceItemList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFinalDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}