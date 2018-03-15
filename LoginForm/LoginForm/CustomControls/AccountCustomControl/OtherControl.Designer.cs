namespace LoginForm.CustomControls
{
    partial class OtherControl
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
            this.btnLedgerPopUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.btnLedgerPopUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 577);
            this.panel1.TabIndex = 0;
            // 
            // btnLedgerPopUp
            // 
            this.btnLedgerPopUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLedgerPopUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLedgerPopUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(249)))));
            this.btnLedgerPopUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLedgerPopUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(249)))));
            this.btnLedgerPopUp.FlatAppearance.BorderSize = 0;
            this.btnLedgerPopUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(155)))), ((int)(((byte)(229)))));
            this.btnLedgerPopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLedgerPopUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedgerPopUp.Location = new System.Drawing.Point(0, 0);
            this.btnLedgerPopUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnLedgerPopUp.Name = "btnLedgerPopUp";
            this.btnLedgerPopUp.Size = new System.Drawing.Size(301, 40);
            this.btnLedgerPopUp.TabIndex = 44;
            this.btnLedgerPopUp.Text = "LedgerPopup";
            this.btnLedgerPopUp.UseVisualStyleBackColor = false;
            // 
            // OtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OtherControl";
            this.Size = new System.Drawing.Size(301, 577);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLedgerPopUp;
    }
}
