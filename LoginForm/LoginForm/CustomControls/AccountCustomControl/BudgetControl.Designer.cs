namespace LoginForm.CustomControls
{
    partial class BudgetControl
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
            this.btnBudgetVariance = new System.Windows.Forms.Button();
            this.btnBudget = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnBudgetVariance);
            this.panel1.Controls.Add(this.btnBudget);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 577);
            this.panel1.TabIndex = 0;
            // 
            // btnBudgetVariance
            // 
            this.btnBudgetVariance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBudgetVariance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBudgetVariance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(155)))), ((int)(((byte)(229)))));
            this.btnBudgetVariance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBudgetVariance.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(250)))));
            this.btnBudgetVariance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudgetVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudgetVariance.Location = new System.Drawing.Point(16, 82);
            this.btnBudgetVariance.Margin = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.btnBudgetVariance.Name = "btnBudgetVariance";
            this.btnBudgetVariance.Size = new System.Drawing.Size(269, 50);
            this.btnBudgetVariance.TabIndex = 45;
            this.btnBudgetVariance.Text = "Budget Variance";
            this.btnBudgetVariance.UseVisualStyleBackColor = false;
            // 
            // btnBudget
            // 
            this.btnBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBudget.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBudget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(155)))), ((int)(((byte)(229)))));
            this.btnBudget.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBudget.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(250)))));
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudget.Location = new System.Drawing.Point(16, 16);
            this.btnBudget.Margin = new System.Windows.Forms.Padding(16, 16, 16, 8);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(269, 50);
            this.btnBudget.TabIndex = 44;
            this.btnBudget.Text = "Budget";
            this.btnBudget.UseVisualStyleBackColor = false;
            // 
            // BudgetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BudgetControl";
            this.Size = new System.Drawing.Size(301, 577);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.Button btnBudgetVariance;
    }
}
