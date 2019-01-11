namespace LoginForm
{
    partial class frmCostAnalyst
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
            this.dgCost = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).BeginInit();
            this.SuspendLayout();
            // 
            // dgCost
            // 
            this.dgCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCost.Location = new System.Drawing.Point(0, 0);
            this.dgCost.Name = "dgCost";
            this.dgCost.Size = new System.Drawing.Size(1068, 511);
            this.dgCost.TabIndex = 0;
            // 
            // frmCostAnalyst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 511);
            this.Controls.Add(this.dgCost);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1084, 550);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1084, 550);
            this.Name = "frmCostAnalyst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cost Analyst";
            this.Load += new System.EventHandler(this.frmCostAnalyst_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgCost;
    }
}