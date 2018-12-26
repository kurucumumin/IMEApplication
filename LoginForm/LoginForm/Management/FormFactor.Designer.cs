namespace LoginForm
{
    partial class FormFactor
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtHSFactor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLIFactor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCustomer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnSave.Location = new System.Drawing.Point(157, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 41);
            this.btnSave.TabIndex = 80;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(165, 175);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(32, 13);
            this.label67.TabIndex = 79;
            this.label67.Text = "Save";
            // 
            // txtFactor
            // 
            this.txtFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFactor.Location = new System.Drawing.Point(113, 11);
            this.txtFactor.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(153, 20);
            this.txtFactor.TabIndex = 82;
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(21, 14);
            this.lblVAT.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(63, 13);
            this.lblVAT.TabIndex = 81;
            this.lblVAT.Text = "Main Factor";
            // 
            // txtHSFactor
            // 
            this.txtHSFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHSFactor.Location = new System.Drawing.Point(113, 49);
            this.txtHSFactor.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtHSFactor.Name = "txtHSFactor";
            this.txtHSFactor.Size = new System.Drawing.Size(153, 20);
            this.txtHSFactor.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "HS Factor";
            // 
            // txtLIFactor
            // 
            this.txtLIFactor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLIFactor.Location = new System.Drawing.Point(113, 90);
            this.txtLIFactor.Margin = new System.Windows.Forms.Padding(2, 2, 12, 2);
            this.txtLIFactor.Name = "txtLIFactor";
            this.txtLIFactor.Size = new System.Drawing.Size(153, 20);
            this.txtLIFactor.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "LI Factor";
            // 
            // chkCustomer
            // 
            this.chkCustomer.AutoSize = true;
            this.chkCustomer.Location = new System.Drawing.Point(281, 12);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Size = new System.Drawing.Size(129, 17);
            this.chkCustomer.TabIndex = 87;
            this.chkCustomer.Text = "Apply to all Customers";
            this.chkCustomer.UseVisualStyleBackColor = true;
            // 
            // FormFactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(438, 250);
            this.Controls.Add(this.chkCustomer);
            this.Controls.Add(this.txtLIFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHSFactor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFactor);
            this.Controls.Add(this.lblVAT);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label67);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(454, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(454, 289);
            this.Name = "FormFactor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factor";
            this.Load += new System.EventHandler(this.FormFactor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.TextBox txtHSFactor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLIFactor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCustomer;
    }
}