namespace LoginForm.CustomControls
{
    partial class SalesOrderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEmptySalesOrder = new System.Windows.Forms.Button();
            this.btnFromQuotation = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.btnEmptySalesOrder);
            this.panel1.Controls.Add(this.btnFromQuotation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 416);
            this.panel1.TabIndex = 0;
            // 
            // btnEmptySalesOrder
            // 
            this.btnEmptySalesOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEmptySalesOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnEmptySalesOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmptySalesOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmptySalesOrder.Enabled = false;
            this.btnEmptySalesOrder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(139)))), ((int)(((byte)(203)))));
            this.btnEmptySalesOrder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(155)))), ((int)(((byte)(229)))));
            this.btnEmptySalesOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmptySalesOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmptySalesOrder.Location = new System.Drawing.Point(0, 40);
            this.btnEmptySalesOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnEmptySalesOrder.Name = "btnEmptySalesOrder";
            this.btnEmptySalesOrder.Size = new System.Drawing.Size(301, 40);
            this.btnEmptySalesOrder.TabIndex = 45;
            this.btnEmptySalesOrder.Text = "Empty Sales Order";
            this.btnEmptySalesOrder.UseVisualStyleBackColor = false;
            this.btnEmptySalesOrder.Click += new System.EventHandler(this.btnEmptySalesOrder_Click);
            // 
            // btnFromQuotation
            // 
            this.btnFromQuotation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFromQuotation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(210)))), ((int)(((byte)(250)))));
            this.btnFromQuotation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFromQuotation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFromQuotation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(139)))), ((int)(((byte)(203)))));
            this.btnFromQuotation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(155)))), ((int)(((byte)(229)))));
            this.btnFromQuotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromQuotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromQuotation.Location = new System.Drawing.Point(0, 0);
            this.btnFromQuotation.Margin = new System.Windows.Forms.Padding(0);
            this.btnFromQuotation.Name = "btnFromQuotation";
            this.btnFromQuotation.Size = new System.Drawing.Size(301, 40);
            this.btnFromQuotation.TabIndex = 44;
            this.btnFromQuotation.Text = "From Quotation";
            this.btnFromQuotation.UseVisualStyleBackColor = false;
            this.btnFromQuotation.Click += new System.EventHandler(this.btnFromQuotation_Click);
            // 
            // SalesOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SalesOrderControl";
            this.Size = new System.Drawing.Size(301, 416);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFromQuotation;
        private System.Windows.Forms.Button btnEmptySalesOrder;
    }
}
