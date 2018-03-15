namespace LoginForm
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tableLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbMainMenu = new System.Windows.Forms.GroupBox();
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnDevelopment = new System.Windows.Forms.Button();
            this.btnLoader = new System.Windows.Forms.Button();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.controlManagement = new LoginForm.CustomControls.ManagementControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.subControlMasters = new LoginForm.CustomControls.MastersControl();
            this.subControlFinancialStatement = new LoginForm.CustomControls.FinancialStatementsControl();
            this.subControlBudget = new LoginForm.CustomControls.BudgetControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.controlAccounting = new LoginForm.CustomControls.AccountingControl();
            this.controlLoader = new LoginForm.CustomControls.LoaderControl();
            this.controlDevelopment = new LoginForm.CustomControls.DevelopmentControl();
            this.tableLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbMainMenu.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLeftPanel
            // 
            this.tableLeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.tableLeftPanel.ColumnCount = 1;
            this.tableLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeftPanel.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLeftPanel.Controls.Add(this.gbMainMenu, 0, 1);
            this.tableLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLeftPanel.Location = new System.Drawing.Point(3, 2);
            this.tableLeftPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLeftPanel.Name = "tableLeftPanel";
            this.tableLeftPanel.RowCount = 2;
            this.tableLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLeftPanel.Size = new System.Drawing.Size(219, 629);
            this.tableLeftPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LoginForm.Properties.Resources.IME;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(213, 165);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // gbMainMenu
            // 
            this.gbMainMenu.AutoSize = true;
            this.gbMainMenu.Controls.Add(this.btnManagement);
            this.gbMainMenu.Controls.Add(this.btnAccounting);
            this.gbMainMenu.Controls.Add(this.btnDevelopment);
            this.gbMainMenu.Controls.Add(this.btnLoader);
            this.gbMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMainMenu.Location = new System.Drawing.Point(3, 171);
            this.gbMainMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMainMenu.Name = "gbMainMenu";
            this.gbMainMenu.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.gbMainMenu.Size = new System.Drawing.Size(213, 456);
            this.gbMainMenu.TabIndex = 32;
            this.gbMainMenu.TabStop = false;
            this.gbMainMenu.Text = "Menu";
            // 
            // btnManagement
            // 
            this.btnManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagement.Location = new System.Drawing.Point(0, 180);
            this.btnManagement.Margin = new System.Windows.Forms.Padding(0);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(213, 50);
            this.btnManagement.TabIndex = 33;
            this.btnManagement.Text = "Management";
            this.btnManagement.UseVisualStyleBackColor = false;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnAccounting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccounting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btnAccounting.FlatAppearance.BorderSize = 0;
            this.btnAccounting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccounting.Location = new System.Drawing.Point(0, 130);
            this.btnAccounting.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(213, 50);
            this.btnAccounting.TabIndex = 35;
            this.btnAccounting.Text = "Accounting";
            this.btnAccounting.UseVisualStyleBackColor = false;
            this.btnAccounting.Click += new System.EventHandler(this.btnAccounting_Click);
            // 
            // btnDevelopment
            // 
            this.btnDevelopment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnDevelopment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDevelopment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btnDevelopment.FlatAppearance.BorderSize = 0;
            this.btnDevelopment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevelopment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevelopment.Location = new System.Drawing.Point(0, 80);
            this.btnDevelopment.Margin = new System.Windows.Forms.Padding(0);
            this.btnDevelopment.Name = "btnDevelopment";
            this.btnDevelopment.Size = new System.Drawing.Size(213, 50);
            this.btnDevelopment.TabIndex = 34;
            this.btnDevelopment.Text = "Developments";
            this.btnDevelopment.UseVisualStyleBackColor = false;
            this.btnDevelopment.Click += new System.EventHandler(this.btnDevelopment_Click);
            // 
            // btnLoader
            // 
            this.btnLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(199)))), ((int)(((byte)(132)))));
            this.btnLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoader.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.btnLoader.FlatAppearance.BorderSize = 0;
            this.btnLoader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoader.Location = new System.Drawing.Point(0, 30);
            this.btnLoader.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoader.Name = "btnLoader";
            this.btnLoader.Size = new System.Drawing.Size(213, 50);
            this.btnLoader.TabIndex = 29;
            this.btnLoader.Text = "Loader";
            this.btnLoader.UseVisualStyleBackColor = false;
            this.btnLoader.Click += new System.EventHandler(this.btnLoader_Click);
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.tableLeftPanel, 0, 0);
            this.tableMain.Controls.Add(this.panel1, 1, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Size = new System.Drawing.Size(1562, 633);
            this.tableMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(225, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1337, 633);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1337, 633);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.controlManagement);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(671, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(663, 607);
            this.panel4.TabIndex = 6;
            // 
            // controlManagement
            // 
            this.controlManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlManagement.Location = new System.Drawing.Point(0, 0);
            this.controlManagement.Margin = new System.Windows.Forms.Padding(2);
            this.controlManagement.Name = "controlManagement";
            this.controlManagement.Size = new System.Drawing.Size(663, 607);
            this.controlManagement.TabIndex = 2;
            this.controlManagement.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.subControlMasters);
            this.panel3.Controls.Add(this.subControlFinancialStatement);
            this.panel3.Controls.Add(this.subControlBudget);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(334, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(334, 613);
            this.panel3.TabIndex = 4;
            // 
            // subControlMasters
            // 
            this.subControlMasters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.subControlMasters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subControlMasters.Location = new System.Drawing.Point(0, 0);
            this.subControlMasters.Margin = new System.Windows.Forms.Padding(0);
            this.subControlMasters.Name = "subControlMasters";
            this.subControlMasters.Size = new System.Drawing.Size(334, 613);
            this.subControlMasters.TabIndex = 7;
            this.subControlMasters.Visible = false;
            // 
            // subControlFinancialStatement
            // 
            this.subControlFinancialStatement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.subControlFinancialStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subControlFinancialStatement.Location = new System.Drawing.Point(0, 0);
            this.subControlFinancialStatement.Margin = new System.Windows.Forms.Padding(0);
            this.subControlFinancialStatement.Name = "subControlFinancialStatement";
            this.subControlFinancialStatement.Size = new System.Drawing.Size(334, 613);
            this.subControlFinancialStatement.TabIndex = 6;
            this.subControlFinancialStatement.Visible = false;
            // 
            // subControlBudget
            // 
            this.subControlBudget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.subControlBudget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subControlBudget.Location = new System.Drawing.Point(0, 0);
            this.subControlBudget.Margin = new System.Windows.Forms.Padding(0);
            this.subControlBudget.Name = "subControlBudget";
            this.subControlBudget.Size = new System.Drawing.Size(334, 613);
            this.subControlBudget.TabIndex = 5;
            this.subControlBudget.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.controlAccounting);
            this.panel2.Controls.Add(this.controlLoader);
            this.panel2.Controls.Add(this.controlDevelopment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 613);
            this.panel2.TabIndex = 2;
            // 
            // controlAccounting
            // 
            this.controlAccounting.AutoScroll = true;
            this.controlAccounting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.controlAccounting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlAccounting.Location = new System.Drawing.Point(0, 0);
            this.controlAccounting.Margin = new System.Windows.Forms.Padding(2);
            this.controlAccounting.Name = "controlAccounting";
            this.controlAccounting.Size = new System.Drawing.Size(334, 613);
            this.controlAccounting.TabIndex = 3;
            this.controlAccounting.Visible = false;
            // 
            // controlLoader
            // 
            this.controlLoader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.controlLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlLoader.Location = new System.Drawing.Point(0, 0);
            this.controlLoader.Margin = new System.Windows.Forms.Padding(2);
            this.controlLoader.Name = "controlLoader";
            this.controlLoader.Size = new System.Drawing.Size(334, 613);
            this.controlLoader.TabIndex = 0;
            this.controlLoader.Visible = false;
            // 
            // controlDevelopment
            // 
            this.controlDevelopment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(229)))), ((int)(((byte)(252)))));
            this.controlDevelopment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDevelopment.Location = new System.Drawing.Point(0, 0);
            this.controlDevelopment.Margin = new System.Windows.Forms.Padding(0);
            this.controlDevelopment.MinimumSize = new System.Drawing.Size(0, 544);
            this.controlDevelopment.Name = "controlDevelopment";
            this.controlDevelopment.Size = new System.Drawing.Size(334, 613);
            this.controlDevelopment.TabIndex = 1;
            this.controlDevelopment.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 633);
            this.Controls.Add(this.tableMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1011, 510);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IME General Components";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tableLeftPanel.ResumeLayout(false);
            this.tableLeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbMainMenu.ResumeLayout(false);
            this.tableMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLeftPanel;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private CustomControls.ManagementControl controlManagement;
        private CustomControls.DevelopmentControl controlDevelopment;
        private CustomControls.LoaderControl controlLoader;
        private System.Windows.Forms.GroupBox gbMainMenu;
        private System.Windows.Forms.Button btnDevelopment;
        private System.Windows.Forms.Button btnLoader;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Button btnAccounting;
        private CustomControls.AccountingControl controlAccounting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        public CustomControls.BudgetControl subControlBudget;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        public CustomControls.FinancialStatementsControl subControlFinancialStatement;
        public CustomControls.MastersControl subControlMasters;
    }
}