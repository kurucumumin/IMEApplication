﻿namespace LoginForm.PurchaseOrder
{
    partial class PurchaseExportFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseExportFiles));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPicture = new System.Windows.Forms.Label();
            this.picturePurchase = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgMail = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgCc = new System.Windows.Forms.DataGridView();
            this.chkAddDate = new System.Windows.Forms.CheckBox();
            this.chkDefoult = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCreatePurchase = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupParameters = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePurchase)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMail)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCc)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPicture);
            this.groupBox1.Controls.Add(this.picturePurchase);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File List";
            // 
            // lblPicture
            // 
            this.lblPicture.Location = new System.Drawing.Point(6, 131);
            this.lblPicture.Name = "lblPicture";
            this.lblPicture.Size = new System.Drawing.Size(187, 87);
            this.lblPicture.TabIndex = 1;
            // 
            // picturePurchase
            // 
            this.picturePurchase.Image = ((System.Drawing.Image)(resources.GetObject("picturePurchase.Image")));
            this.picturePurchase.Location = new System.Drawing.Point(40, 16);
            this.picturePurchase.Name = "picturePurchase";
            this.picturePurchase.Size = new System.Drawing.Size(110, 101);
            this.picturePurchase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePurchase.TabIndex = 0;
            this.picturePurchase.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Location = new System.Drawing.Point(217, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 502);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(6, 16);
            this.txtMail.Multiline = true;
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(574, 480);
            this.txtMail.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgMail);
            this.groupBox3.Location = new System.Drawing.Point(809, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 246);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "E-Mail to";
            // 
            // dgMail
            // 
            this.dgMail.AllowUserToAddRows = false;
            this.dgMail.AllowUserToDeleteRows = false;
            this.dgMail.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMail.Location = new System.Drawing.Point(3, 16);
            this.dgMail.Name = "dgMail";
            this.dgMail.ReadOnly = true;
            this.dgMail.Size = new System.Drawing.Size(344, 227);
            this.dgMail.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgCc);
            this.groupBox4.Location = new System.Drawing.Point(812, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(347, 246);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "E-Mail cc";
            // 
            // dgCc
            // 
            this.dgCc.AllowUserToAddRows = false;
            this.dgCc.AllowUserToDeleteRows = false;
            this.dgCc.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgCc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCc.Location = new System.Drawing.Point(3, 16);
            this.dgCc.Name = "dgCc";
            this.dgCc.ReadOnly = true;
            this.dgCc.Size = new System.Drawing.Size(341, 227);
            this.dgCc.TabIndex = 1;
            // 
            // chkAddDate
            // 
            this.chkAddDate.AutoSize = true;
            this.chkAddDate.Location = new System.Drawing.Point(98, 22);
            this.chkAddDate.Name = "chkAddDate";
            this.chkAddDate.Size = new System.Drawing.Size(71, 17);
            this.chkAddDate.TabIndex = 5;
            this.chkAddDate.Text = "Add Date";
            this.chkAddDate.UseVisualStyleBackColor = true;
            // 
            // chkDefoult
            // 
            this.chkDefoult.AutoSize = true;
            this.chkDefoult.Checked = true;
            this.chkDefoult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefoult.Location = new System.Drawing.Point(217, 542);
            this.chkDefoult.Name = "chkDefoult";
            this.chkDefoult.Size = new System.Drawing.Size(92, 17);
            this.chkDefoult.TabIndex = 6;
            this.chkDefoult.Text = "Default E-Mail";
            this.chkDefoult.UseVisualStyleBackColor = true;
            this.chkDefoult.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::LoginForm.Properties.Resources.icons8_Plus_32;
            this.btnEdit.Location = new System.Drawing.Point(829, 517);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(52, 52);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCreatePurchase
            // 
            this.btnCreatePurchase.Image = global::LoginForm.Properties.Resources.if_floppy_285657;
            this.btnCreatePurchase.Location = new System.Drawing.Point(954, 517);
            this.btnCreatePurchase.Name = "btnCreatePurchase";
            this.btnCreatePurchase.Size = new System.Drawing.Size(52, 52);
            this.btnCreatePurchase.TabIndex = 8;
            this.btnCreatePurchase.UseVisualStyleBackColor = true;
            this.btnCreatePurchase.Click += new System.EventHandler(this.btnCreatePurchase_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnClose.Location = new System.Drawing.Point(1081, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 52);
            this.btnClose.TabIndex = 9;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(6, 19);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(67, 20);
            this.txtDate.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDate);
            this.groupBox5.Controls.Add(this.chkAddDate);
            this.groupBox5.Location = new System.Drawing.Point(9, 520);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 48);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Date";
            this.groupBox5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(822, 574);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Edit E-Mail List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(928, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Create P.O. and Send Files";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1094, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Close";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "E-MAIL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "PASS";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(57, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(137, 20);
            this.txtEmail.TabIndex = 19;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(57, 62);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(137, 20);
            this.txtPass.TabIndex = 20;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(57, 127);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(137, 20);
            this.txtPort.TabIndex = 24;
            this.txtPort.Text = "587";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(57, 93);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(137, 20);
            this.txtHost.TabIndex = 23;
            this.txtHost.Text = "smtp.gmail.com";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "PORT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "HOST";
            // 
            // groupParameters
            // 
            this.groupParameters.Controls.Add(this.txtPort);
            this.groupParameters.Controls.Add(this.label5);
            this.groupParameters.Controls.Add(this.label6);
            this.groupParameters.Controls.Add(this.txtHost);
            this.groupParameters.Controls.Add(this.txtEmail);
            this.groupParameters.Controls.Add(this.label7);
            this.groupParameters.Controls.Add(this.txtPass);
            this.groupParameters.Controls.Add(this.label8);
            this.groupParameters.Location = new System.Drawing.Point(11, 247);
            this.groupParameters.Name = "groupParameters";
            this.groupParameters.Size = new System.Drawing.Size(200, 162);
            this.groupParameters.TabIndex = 26;
            this.groupParameters.TabStop = false;
            this.groupParameters.Text = "Sending Parameters";
            // 
            // PurchaseExportFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(1165, 604);
            this.Controls.Add(this.groupParameters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreatePurchase);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.chkDefoult);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PurchaseExportFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PurchaseExportFiles";
            this.Load += new System.EventHandler(this.PurchaseExportFiles_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePurchase)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMail)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCc)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupParameters.ResumeLayout(false);
            this.groupParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAddDate;
        private System.Windows.Forms.CheckBox chkDefoult;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCreatePurchase;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.DataGridView dgMail;
        private System.Windows.Forms.DataGridView dgCc;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblPicture;
        private System.Windows.Forms.PictureBox picturePurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupParameters;
    }
}