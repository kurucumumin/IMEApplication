namespace LoginForm
{
    partial class MainNavigationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerCard = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.lblSalesOrder = new System.Windows.Forms.Label();
            this.lblQuotation = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCustomerCard);
            this.groupBox1.Controls.Add(this.lblInvoice);
            this.groupBox1.Controls.Add(this.lblSalesOrder);
            this.groupBox1.Controls.Add(this.lblQuotation);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Page 1";
            // 
            // lblCustomerCard
            // 
            this.lblCustomerCard.AutoSize = true;
            this.lblCustomerCard.Location = new System.Drawing.Point(6, 133);
            this.lblCustomerCard.Name = "lblCustomerCard";
            this.lblCustomerCard.Size = new System.Drawing.Size(76, 13);
            this.lblCustomerCard.TabIndex = 3;
            this.lblCustomerCard.Text = "Customer Card";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(6, 98);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(42, 13);
            this.lblInvoice.TabIndex = 2;
            this.lblInvoice.Text = "Invoice";
            // 
            // lblSalesOrder
            // 
            this.lblSalesOrder.AutoSize = true;
            this.lblSalesOrder.Location = new System.Drawing.Point(6, 59);
            this.lblSalesOrder.Name = "lblSalesOrder";
            this.lblSalesOrder.Size = new System.Drawing.Size(62, 13);
            this.lblSalesOrder.TabIndex = 1;
            this.lblSalesOrder.Text = "Sales Order";
            // 
            // lblQuotation
            // 
            this.lblQuotation.AutoSize = true;
            this.lblQuotation.Location = new System.Drawing.Point(6, 28);
            this.lblQuotation.Name = "lblQuotation";
            this.lblQuotation.Size = new System.Drawing.Size(53, 13);
            this.lblQuotation.TabIndex = 0;
            this.lblQuotation.Text = "Quotation";
            this.lblQuotation.DoubleClick += new System.EventHandler(this.lblQuotation_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(235, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 289);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Page 2";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(447, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 289);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Page 3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(599, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kullanıcı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Worker Management";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainNavigationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainNavigationForm";
            this.Text = "MainNavigationForm";
            this.Load += new System.EventHandler(this.MainNavigationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblQuotation;
        private System.Windows.Forms.Label lblCustomerCard;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblSalesOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}