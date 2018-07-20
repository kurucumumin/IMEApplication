#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace LoginForm.Main
{
    partial class Office2010Form1
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
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.navigationDrawer1 = new Syncfusion.Windows.Forms.Tools.NavigationDrawer();
            this.drawerMenuItem1 = new Syncfusion.Windows.Forms.Tools.DrawerMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.navigationDrawer1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(281, 609);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.ThemesEnabled = true;
            // 
            // navigationDrawer1
            // 
            this.navigationDrawer1.BackColor = System.Drawing.Color.White;
            this.navigationDrawer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationDrawer1.Items.Add(this.drawerMenuItem1);
            this.navigationDrawer1.Location = new System.Drawing.Point(0, 0);
            this.navigationDrawer1.Margin = new System.Windows.Forms.Padding(8);
            this.navigationDrawer1.Name = "navigationDrawer1";
            this.navigationDrawer1.Size = new System.Drawing.Size(279, 607);
            this.navigationDrawer1.Style = Syncfusion.Windows.Forms.Tools.NavigationDrawerStyle.Default;
            this.navigationDrawer1.TabIndex = 0;
            this.navigationDrawer1.Text = "navigationDrawer1";
            // 
            // drawerMenuItem1
            // 
            this.drawerMenuItem1.BackColor = System.Drawing.Color.White;
            this.drawerMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawerMenuItem1.Location = new System.Drawing.Point(2, 0);
            this.drawerMenuItem1.Margin = new System.Windows.Forms.Padding(0);
            this.drawerMenuItem1.Name = "drawerMenuItem1";
            this.drawerMenuItem1.Size = new System.Drawing.Size(100, 50);
            this.drawerMenuItem1.TabIndex = 0;
            this.drawerMenuItem1.Text = "Development";
            // 
            // Office2010Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 609);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "Office2010Form1";
            this.Text = "Office2010Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.NavigationDrawer navigationDrawer1;
        private Syncfusion.Windows.Forms.Tools.DrawerMenuItem drawerMenuItem1;
    }
}