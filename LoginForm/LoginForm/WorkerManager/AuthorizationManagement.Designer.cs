namespace LoginForm.WorkerManager
{
    partial class AuthorizationManagement
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
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.lstAddAuthorization = new System.Windows.Forms.ListBox();
            this.dgAuthorizations = new System.Windows.Forms.DataGridView();
            this.btnAddAuthorization = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorizations)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(78, 20);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(121, 21);
            this.cbUser.TabIndex = 0;
            this.cbUser.SelectedIndexChanged += new System.EventHandler(this.cbUser_SelectedIndexChanged);
            this.cbUser.Click += new System.EventHandler(this.cbUser_Click);
            // 
            // lstAddAuthorization
            // 
            this.lstAddAuthorization.FormattingEnabled = true;
            this.lstAddAuthorization.Location = new System.Drawing.Point(61, 79);
            this.lstAddAuthorization.Name = "lstAddAuthorization";
            this.lstAddAuthorization.Size = new System.Drawing.Size(148, 225);
            this.lstAddAuthorization.TabIndex = 1;
            // 
            // dgAuthorizations
            // 
            this.dgAuthorizations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAuthorizations.Location = new System.Drawing.Point(311, 79);
            this.dgAuthorizations.Name = "dgAuthorizations";
            this.dgAuthorizations.Size = new System.Drawing.Size(378, 225);
            this.dgAuthorizations.TabIndex = 2;
            // 
            // btnAddAuthorization
            // 
            this.btnAddAuthorization.Location = new System.Drawing.Point(216, 174);
            this.btnAddAuthorization.Name = "btnAddAuthorization";
            this.btnAddAuthorization.Size = new System.Drawing.Size(89, 51);
            this.btnAddAuthorization.TabIndex = 3;
            this.btnAddAuthorization.Text = ">>";
            this.btnAddAuthorization.UseVisualStyleBackColor = true;
            this.btnAddAuthorization.Click += new System.EventHandler(this.btnAddAuthorization_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // AuthorizationManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 347);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddAuthorization);
            this.Controls.Add(this.dgAuthorizations);
            this.Controls.Add(this.lstAddAuthorization);
            this.Controls.Add(this.cbUser);
            this.Name = "AuthorizationManagement";
            this.Text = "AuthorizationManagement";
            this.Load += new System.EventHandler(this.AuthorizationManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAuthorizations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.ListBox lstAddAuthorization;
        private System.Windows.Forms.DataGridView dgAuthorizations;
        private System.Windows.Forms.Button btnAddAuthorization;
        private System.Windows.Forms.Label label1;
    }
}