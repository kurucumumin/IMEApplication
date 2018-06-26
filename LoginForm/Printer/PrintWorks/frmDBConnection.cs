namespace PrintWorks
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmDBConnection : Form
    {
        private IContainer components = null;
        public static string connectionString = @"Data Source=DESKTOP-51RN2GB\LOCAL;Initial Catalog=IME;Integrated Security=True;";
        private Label label1;
        private TextBox txtPassword;

        public frmDBConnection()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmDBConnection));
            this.label1 = new Label();
            this.txtPassword = new TextBox();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            this.txtPassword.Location = new Point(0x47, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(0x85, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(90, 0xa9, 0xe2);
            base.ClientSize = new Size(0xdb, 0x2b);
            base.Controls.Add(this.txtPassword);
            base.Controls.Add(this.label1);
            base.Name = "frmDBConnection";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "DB Connection";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.txtPassword.Text == frmPrintDesigner.strDefaultPass)
                {
                    MessageBox.Show(connectionString, "Connection String", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Invalid password", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
    }
}

