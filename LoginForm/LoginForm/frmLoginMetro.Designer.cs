#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Bunifu.Framework.UI;

namespace LoginForm
{
    partial class frmLoginMetro
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginMetro));
            this.txtID = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.txtPassWord = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnLogin = new AltoControls.AltoButton();
            this.btnExit = new AltoControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtID.BeforeTouchSize = new System.Drawing.Size(217, 32);
            this.txtID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtID.Location = new System.Drawing.Point(69, 250);
            this.txtID.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(217, 32);
            this.txtID.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtID.TabIndex = 1;
            this.txtID.Text = "admin";
            // 
            // txtPassWord
            // 
            this.txtPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPassWord.BeforeTouchSize = new System.Drawing.Size(217, 32);
            this.txtPassWord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassWord.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Bold);
            this.txtPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.txtPassWord.Location = new System.Drawing.Point(69, 315);
            this.txtPassWord.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(217, 32);
            this.txtPassWord.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.txtPassWord.TabIndex = 2;
            this.txtPassWord.Text = "admin";
            this.txtPassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWord_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(39, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(29, 32);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LoginForm.Properties.Resources.if_user_173122;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(37, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(29, 32);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LoginForm.Properties.Resources.if_icon_24_key_314756;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::LoginForm.Properties.Resources.logo;
            this.pictureBox3.Location = new System.Drawing.Point(80, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(169, 171);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 30;
            this.bunifuElipse2.TargetControl = this.pictureBox3;
            // 
            // btnLogin
            // 
            this.btnLogin.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(220)))), ((int)(((byte)(176)))));
            this.btnLogin.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Font = new System.Drawing.Font("Sitka Text", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnLogin.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(255)))), ((int)(((byte)(173)))));
            this.btnLogin.Location = new System.Drawing.Point(87, 394);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Radius = 5;
            this.btnLogin.Size = new System.Drawing.Size(162, 50);
            this.btnLogin.Stroke = true;
            this.btnLogin.StrokeColor = System.Drawing.Color.DarkGray;
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Login";
            this.btnLogin.Transparency = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Active1 = System.Drawing.Color.AliceBlue;
            this.btnExit.Active2 = System.Drawing.Color.AliceBlue;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExit.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.DimGray;
            this.btnExit.Inactive1 = System.Drawing.Color.AliceBlue;
            this.btnExit.Inactive2 = System.Drawing.Color.AliceBlue;
            this.btnExit.Location = new System.Drawing.Point(301, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Radius = 5;
            this.btnExit.Size = new System.Drawing.Size(36, 33);
            this.btnExit.Stroke = false;
            this.btnExit.StrokeColor = System.Drawing.Color.Gray;
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "X";
            this.btnExit.Transparency = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmLoginMetro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(339, 477);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPassWord);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginMetro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IME CRM";
            this.Load += new System.EventHandler(this.Metrofrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtID;
        private Syncfusion.Windows.Forms.Tools.TextBoxExt txtPassWord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AltoControls.AltoButton btnLogin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private BunifuElipse bunifuElipse2;
        private AltoControls.AltoButton btnExit;
    }
}