namespace LoginForm.User
{
    partial class FormUserCustomerUpdate
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
            this.cmbCustomerUpdate = new System.Windows.Forms.ComboBox();
            this.cmbCustomerAdd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clbCustomerUpdate = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.clbCustomerAdd = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Representative";
            // 
            // cmbCustomerUpdate
            // 
            this.cmbCustomerUpdate.FormattingEnabled = true;
            this.cmbCustomerUpdate.Location = new System.Drawing.Point(139, 9);
            this.cmbCustomerUpdate.Name = "cmbCustomerUpdate";
            this.cmbCustomerUpdate.Size = new System.Drawing.Size(210, 21);
            this.cmbCustomerUpdate.TabIndex = 1;
            this.cmbCustomerUpdate.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerUpdate_SelectedIndexChanged);
            // 
            // cmbCustomerAdd
            // 
            this.cmbCustomerAdd.FormattingEnabled = true;
            this.cmbCustomerAdd.Location = new System.Drawing.Point(586, 9);
            this.cmbCustomerAdd.Name = "cmbCustomerAdd";
            this.cmbCustomerAdd.Size = new System.Drawing.Size(210, 21);
            this.cmbCustomerAdd.TabIndex = 3;
            this.cmbCustomerAdd.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerAdd_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Representative";
            // 
            // clbCustomerUpdate
            // 
            this.clbCustomerUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCustomerUpdate.CheckOnClick = true;
            this.clbCustomerUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbCustomerUpdate.FormattingEnabled = true;
            this.clbCustomerUpdate.Location = new System.Drawing.Point(15, 37);
            this.clbCustomerUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.clbCustomerUpdate.Name = "clbCustomerUpdate";
            this.clbCustomerUpdate.Size = new System.Drawing.Size(334, 382);
            this.clbCustomerUpdate.TabIndex = 11;
            this.clbCustomerUpdate.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCustomerUpdate_ItemCheck);
            this.clbCustomerUpdate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbCustomerUpdate_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Image = global::LoginForm.Properties.Resources.icons8_Edit_Property_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(381, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 52);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Image = global::LoginForm.Properties.Resources.icons8_Cancel_32;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(381, 241);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 52);
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Clear All";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 483);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Select All";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::LoginForm.Properties.Resources.if_Line_ui_icons_Svg_03_1465842;
            this.btnClear.Location = new System.Drawing.Point(95, 426);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(52, 52);
            this.btnClear.TabIndex = 59;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::LoginForm.Properties.Resources.if_Select_46755;
            this.btnSelect.Location = new System.Drawing.Point(15, 426);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(52, 52);
            this.btnSelect.TabIndex = 58;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // clbCustomerAdd
            // 
            this.clbCustomerAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCustomerAdd.CheckOnClick = true;
            this.clbCustomerAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbCustomerAdd.FormattingEnabled = true;
            this.clbCustomerAdd.Location = new System.Drawing.Point(462, 37);
            this.clbCustomerAdd.Margin = new System.Windows.Forms.Padding(4);
            this.clbCustomerAdd.Name = "clbCustomerAdd";
            this.clbCustomerAdd.Size = new System.Drawing.Size(334, 382);
            this.clbCustomerAdd.TabIndex = 62;
            // 
            // FormUserCustomerUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(237)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.clbCustomerAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.clbCustomerUpdate);
            this.Controls.Add(this.cmbCustomerAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomerUpdate);
            this.Controls.Add(this.label1);
            this.Name = "FormUserCustomerUpdate";
            this.Text = "FormUserCustomerUpdate";
            this.Load += new System.EventHandler(this.FormUserCustomerUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomerUpdate;
        private System.Windows.Forms.ComboBox cmbCustomerAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbCustomerUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckedListBox clbCustomerAdd;
    }
}