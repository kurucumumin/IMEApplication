namespace LoginForm
{
    partial class AddIMEWorker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.MaskedTextBox();
            this.btnSaveWorker = new System.Windows.Forms.Button();
            this.btnDeleteWorker = new System.Windows.Forms.Button();
            this.btnUpdateWorker = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAuthorizationPanel = new System.Windows.Forms.Button();
            this.lbWorkerList = new System.Windows.Forms.ListBox();
            this.btnNewWorker = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "E-Mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Phone";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(140, 60);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(132, 22);
            this.txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(140, 143);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(132, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Controls.Add(this.lblResult);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.btnSaveWorker);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(361, 409);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Worker Registration Form";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(140, 304);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(132, 22);
            this.txtPhone.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Black;
            this.lblResult.Location = new System.Drawing.Point(35, 366);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 17);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Label5";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 225);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 22);
            this.txtEmail.TabIndex = 3;
            // 
            // btnSaveWorker
            // 
            this.btnSaveWorker.Location = new System.Drawing.Point(252, 347);
            this.btnSaveWorker.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveWorker.Name = "btnSaveWorker";
            this.btnSaveWorker.Size = new System.Drawing.Size(101, 54);
            this.btnSaveWorker.TabIndex = 7;
            this.btnSaveWorker.Text = "Save Worker";
            this.btnSaveWorker.UseVisualStyleBackColor = true;
            this.btnSaveWorker.Click += new System.EventHandler(this.btnSaveWorker_Click);
            // 
            // btnDeleteWorker
            // 
            this.btnDeleteWorker.Location = new System.Drawing.Point(236, 336);
            this.btnDeleteWorker.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteWorker.Name = "btnDeleteWorker";
            this.btnDeleteWorker.Size = new System.Drawing.Size(101, 54);
            this.btnDeleteWorker.TabIndex = 6;
            this.btnDeleteWorker.Text = "Delete Worker";
            this.btnDeleteWorker.UseVisualStyleBackColor = true;
            this.btnDeleteWorker.Click += new System.EventHandler(this.btnDeleteWorker_Click);
            // 
            // btnUpdateWorker
            // 
            this.btnUpdateWorker.Location = new System.Drawing.Point(127, 336);
            this.btnUpdateWorker.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateWorker.Name = "btnUpdateWorker";
            this.btnUpdateWorker.Size = new System.Drawing.Size(101, 54);
            this.btnUpdateWorker.TabIndex = 5;
            this.btnUpdateWorker.Text = "Update Worker";
            this.btnUpdateWorker.UseVisualStyleBackColor = true;
            this.btnUpdateWorker.Click += new System.EventHandler(this.btnUpdateWorker_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNewWorker);
            this.groupBox2.Controls.Add(this.btnDeleteWorker);
            this.groupBox2.Controls.Add(this.btnUpdateWorker);
            this.groupBox2.Controls.Add(this.btnAuthorizationPanel);
            this.groupBox2.Controls.Add(this.lbWorkerList);
            this.groupBox2.Location = new System.Drawing.Point(429, 17);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(441, 409);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Worker List";
            // 
            // btnAuthorizationPanel
            // 
            this.btnAuthorizationPanel.Location = new System.Drawing.Point(332, 274);
            this.btnAuthorizationPanel.Margin = new System.Windows.Forms.Padding(4);
            this.btnAuthorizationPanel.Name = "btnAuthorizationPanel";
            this.btnAuthorizationPanel.Size = new System.Drawing.Size(101, 54);
            this.btnAuthorizationPanel.TabIndex = 8;
            this.btnAuthorizationPanel.Text = "Authorization Panel";
            this.btnAuthorizationPanel.UseVisualStyleBackColor = true;
            this.btnAuthorizationPanel.Click += new System.EventHandler(this.btnAuthorizationPanel_Click);
            // 
            // lbWorkerList
            // 
            this.lbWorkerList.FormattingEnabled = true;
            this.lbWorkerList.ItemHeight = 16;
            this.lbWorkerList.Location = new System.Drawing.Point(31, 20);
            this.lbWorkerList.Margin = new System.Windows.Forms.Padding(4);
            this.lbWorkerList.Name = "lbWorkerList";
            this.lbWorkerList.Size = new System.Drawing.Size(292, 308);
            this.lbWorkerList.TabIndex = 0;
            this.lbWorkerList.Click += new System.EventHandler(this.lbWorkerList_Click);
            // 
            // btnNewWorker
            // 
            this.btnNewWorker.Location = new System.Drawing.Point(22, 336);
            this.btnNewWorker.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewWorker.Name = "btnNewWorker";
            this.btnNewWorker.Size = new System.Drawing.Size(101, 54);
            this.btnNewWorker.TabIndex = 18;
            this.btnNewWorker.Text = "New Worker";
            this.btnNewWorker.UseVisualStyleBackColor = true;
            this.btnNewWorker.Click += new System.EventHandler(this.btnNewWorker_Click);
            // 
            // AddIMEWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 441);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddIMEWorker";
            this.Text = "New Worker";
            this.Load += new System.EventHandler(this.AddIMEWorker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveWorker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAuthorizationPanel;
        private System.Windows.Forms.ListBox lbWorkerList;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.MaskedTextBox txtEmail;
        private System.Windows.Forms.Button btnDeleteWorker;
        private System.Windows.Forms.Button btnUpdateWorker;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnNewWorker;
    }
}