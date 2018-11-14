namespace LoginForm
{
    partial class frmGetCost
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
            this.ArticleNoSearch = new System.Windows.Forms.TextBox();
            this.dgItemList = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupPrices = new System.Windows.Forms.GroupBox();
            this.txtMargin5 = new System.Windows.Forms.TextBox();
            this.txtMargin2 = new System.Windows.Forms.TextBox();
            this.txtMargin1 = new System.Windows.Forms.TextBox();
            this.txtMargin4 = new System.Windows.Forms.TextBox();
            this.txtMargin3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWeb5 = new System.Windows.Forms.TextBox();
            this.txtWeb2 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.txtWeb3 = new System.Windows.Forms.TextBox();
            this.txtWeb1 = new System.Windows.Forms.TextBox();
            this.txtWeb4 = new System.Windows.Forms.TextBox();
            this.txtCost1 = new System.Windows.Forms.TextBox();
            this.txtUnitCount5 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtUK5 = new System.Windows.Forms.TextBox();
            this.txtUK2 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCost5 = new System.Windows.Forms.TextBox();
            this.txtUnitCount2 = new System.Windows.Forms.TextBox();
            this.txtUK3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUnitCount1 = new System.Windows.Forms.TextBox();
            this.txtUK1 = new System.Windows.Forms.TextBox();
            this.txtCost3 = new System.Windows.Forms.TextBox();
            this.txtCost4 = new System.Windows.Forms.TextBox();
            this.txtUnitCount4 = new System.Windows.Forms.TextBox();
            this.txtCost2 = new System.Windows.Forms.TextBox();
            this.txtUK4 = new System.Windows.Forms.TextBox();
            this.txtUnitCount3 = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtRSStock = new System.Windows.Forms.TextBox();
            this.txtRSOnOrder = new System.Windows.Forms.TextBox();
            this.rbProductName = new System.Windows.Forms.RadioButton();
            this.rbProductCode = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rbMPNCode = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).BeginInit();
            this.groupPrices.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // ArticleNoSearch
            // 
            this.ArticleNoSearch.Location = new System.Drawing.Point(65, 2);
            this.ArticleNoSearch.Name = "ArticleNoSearch";
            this.ArticleNoSearch.Size = new System.Drawing.Size(274, 21);
            this.ArticleNoSearch.TabIndex = 1;
            this.ArticleNoSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArticleNoSearch_KeyDown);
            // 
            // dgItemList
            // 
            this.dgItemList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemList.Location = new System.Drawing.Point(6, 26);
            this.dgItemList.Margin = new System.Windows.Forms.Padding(0);
            this.dgItemList.Name = "dgItemList";
            this.dgItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItemList.Size = new System.Drawing.Size(818, 163);
            this.dgItemList.TabIndex = 275;
            this.dgItemList.Click += new System.EventHandler(this.dgItemList_Click);
            // 
            // groupPrices
            // 
            this.groupPrices.Controls.Add(this.txtMargin5);
            this.groupPrices.Controls.Add(this.txtMargin2);
            this.groupPrices.Controls.Add(this.txtMargin1);
            this.groupPrices.Controls.Add(this.txtMargin4);
            this.groupPrices.Controls.Add(this.txtMargin3);
            this.groupPrices.Controls.Add(this.label13);
            this.groupPrices.Controls.Add(this.txtWeb5);
            this.groupPrices.Controls.Add(this.txtWeb2);
            this.groupPrices.Controls.Add(this.label65);
            this.groupPrices.Controls.Add(this.txtWeb3);
            this.groupPrices.Controls.Add(this.txtWeb1);
            this.groupPrices.Controls.Add(this.txtWeb4);
            this.groupPrices.Controls.Add(this.txtCost1);
            this.groupPrices.Controls.Add(this.txtUnitCount5);
            this.groupPrices.Controls.Add(this.label44);
            this.groupPrices.Controls.Add(this.txtUK5);
            this.groupPrices.Controls.Add(this.txtUK2);
            this.groupPrices.Controls.Add(this.label38);
            this.groupPrices.Controls.Add(this.txtCost5);
            this.groupPrices.Controls.Add(this.txtUnitCount2);
            this.groupPrices.Controls.Add(this.txtUK3);
            this.groupPrices.Controls.Add(this.label14);
            this.groupPrices.Controls.Add(this.txtUnitCount1);
            this.groupPrices.Controls.Add(this.txtUK1);
            this.groupPrices.Controls.Add(this.txtCost3);
            this.groupPrices.Controls.Add(this.txtCost4);
            this.groupPrices.Controls.Add(this.txtUnitCount4);
            this.groupPrices.Controls.Add(this.txtCost2);
            this.groupPrices.Controls.Add(this.txtUK4);
            this.groupPrices.Controls.Add(this.txtUnitCount3);
            this.groupPrices.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupPrices.Location = new System.Drawing.Point(6, 192);
            this.groupPrices.Name = "groupPrices";
            this.groupPrices.Padding = new System.Windows.Forms.Padding(2);
            this.groupPrices.Size = new System.Drawing.Size(372, 247);
            this.groupPrices.TabIndex = 276;
            this.groupPrices.TabStop = false;
            this.groupPrices.Text = "Prices";
            // 
            // txtMargin5
            // 
            this.txtMargin5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMargin5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin5.Location = new System.Drawing.Point(285, 181);
            this.txtMargin5.Margin = new System.Windows.Forms.Padding(0);
            this.txtMargin5.Name = "txtMargin5";
            this.txtMargin5.ReadOnly = true;
            this.txtMargin5.Size = new System.Drawing.Size(55, 23);
            this.txtMargin5.TabIndex = 237;
            // 
            // txtMargin2
            // 
            this.txtMargin2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMargin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin2.Location = new System.Drawing.Point(285, 92);
            this.txtMargin2.Margin = new System.Windows.Forms.Padding(0);
            this.txtMargin2.Name = "txtMargin2";
            this.txtMargin2.ReadOnly = true;
            this.txtMargin2.Size = new System.Drawing.Size(55, 23);
            this.txtMargin2.TabIndex = 234;
            // 
            // txtMargin1
            // 
            this.txtMargin1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMargin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin1.Location = new System.Drawing.Point(285, 63);
            this.txtMargin1.Margin = new System.Windows.Forms.Padding(0);
            this.txtMargin1.Name = "txtMargin1";
            this.txtMargin1.ReadOnly = true;
            this.txtMargin1.Size = new System.Drawing.Size(55, 23);
            this.txtMargin1.TabIndex = 233;
            // 
            // txtMargin4
            // 
            this.txtMargin4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMargin4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin4.Location = new System.Drawing.Point(285, 151);
            this.txtMargin4.Margin = new System.Windows.Forms.Padding(0);
            this.txtMargin4.Name = "txtMargin4";
            this.txtMargin4.ReadOnly = true;
            this.txtMargin4.Size = new System.Drawing.Size(55, 23);
            this.txtMargin4.TabIndex = 236;
            // 
            // txtMargin3
            // 
            this.txtMargin3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMargin3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin3.Location = new System.Drawing.Point(285, 121);
            this.txtMargin3.Margin = new System.Windows.Forms.Padding(0);
            this.txtMargin3.Name = "txtMargin3";
            this.txtMargin3.ReadOnly = true;
            this.txtMargin3.Size = new System.Drawing.Size(55, 23);
            this.txtMargin3.TabIndex = 235;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(285, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 42);
            this.label13.TabIndex = 238;
            this.label13.Text = "Margin\r\n%";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWeb5
            // 
            this.txtWeb5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb5.Location = new System.Drawing.Point(81, 181);
            this.txtWeb5.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeb5.Name = "txtWeb5";
            this.txtWeb5.ReadOnly = true;
            this.txtWeb5.Size = new System.Drawing.Size(60, 23);
            this.txtWeb5.TabIndex = 61;
            // 
            // txtWeb2
            // 
            this.txtWeb2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb2.Location = new System.Drawing.Point(81, 92);
            this.txtWeb2.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeb2.Name = "txtWeb2";
            this.txtWeb2.ReadOnly = true;
            this.txtWeb2.Size = new System.Drawing.Size(60, 23);
            this.txtWeb2.TabIndex = 46;
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label65.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label65.Location = new System.Drawing.Point(81, 13);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(60, 42);
            this.label65.TabIndex = 232;
            this.label65.Text = "Web\r\n(X)";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWeb3
            // 
            this.txtWeb3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb3.Location = new System.Drawing.Point(81, 121);
            this.txtWeb3.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeb3.Name = "txtWeb3";
            this.txtWeb3.ReadOnly = true;
            this.txtWeb3.Size = new System.Drawing.Size(60, 23);
            this.txtWeb3.TabIndex = 51;
            // 
            // txtWeb1
            // 
            this.txtWeb1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb1.Location = new System.Drawing.Point(81, 63);
            this.txtWeb1.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeb1.Name = "txtWeb1";
            this.txtWeb1.ReadOnly = true;
            this.txtWeb1.Size = new System.Drawing.Size(60, 23);
            this.txtWeb1.TabIndex = 41;
            // 
            // txtWeb4
            // 
            this.txtWeb4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtWeb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb4.Location = new System.Drawing.Point(81, 151);
            this.txtWeb4.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeb4.Name = "txtWeb4";
            this.txtWeb4.ReadOnly = true;
            this.txtWeb4.Size = new System.Drawing.Size(60, 23);
            this.txtWeb4.TabIndex = 56;
            // 
            // txtCost1
            // 
            this.txtCost1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost1.Location = new System.Drawing.Point(217, 63);
            this.txtCost1.Margin = new System.Windows.Forms.Padding(0);
            this.txtCost1.Name = "txtCost1";
            this.txtCost1.ReadOnly = true;
            this.txtCost1.Size = new System.Drawing.Size(60, 23);
            this.txtCost1.TabIndex = 43;
            // 
            // txtUnitCount5
            // 
            this.txtUnitCount5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnitCount5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitCount5.Location = new System.Drawing.Point(28, 181);
            this.txtUnitCount5.Margin = new System.Windows.Forms.Padding(0);
            this.txtUnitCount5.Name = "txtUnitCount5";
            this.txtUnitCount5.ReadOnly = true;
            this.txtUnitCount5.Size = new System.Drawing.Size(44, 23);
            this.txtUnitCount5.TabIndex = 60;
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label44.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label44.Location = new System.Drawing.Point(217, 13);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(60, 42);
            this.label44.TabIndex = 154;
            this.label44.Text = "Cost\r\n(£)";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUK5
            // 
            this.txtUK5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUK5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK5.Location = new System.Drawing.Point(149, 181);
            this.txtUK5.Margin = new System.Windows.Forms.Padding(0);
            this.txtUK5.Name = "txtUK5";
            this.txtUK5.ReadOnly = true;
            this.txtUK5.Size = new System.Drawing.Size(60, 23);
            this.txtUK5.TabIndex = 62;
            // 
            // txtUK2
            // 
            this.txtUK2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK2.Location = new System.Drawing.Point(149, 92);
            this.txtUK2.Margin = new System.Windows.Forms.Padding(0);
            this.txtUK2.Name = "txtUK2";
            this.txtUK2.ReadOnly = true;
            this.txtUK2.Size = new System.Drawing.Size(60, 23);
            this.txtUK2.TabIndex = 47;
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label38.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label38.Location = new System.Drawing.Point(149, 13);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 42);
            this.label38.TabIndex = 158;
            this.label38.Text = "UK\r\n(£)";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCost5
            // 
            this.txtCost5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCost5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost5.Location = new System.Drawing.Point(217, 181);
            this.txtCost5.Margin = new System.Windows.Forms.Padding(0);
            this.txtCost5.Name = "txtCost5";
            this.txtCost5.ReadOnly = true;
            this.txtCost5.Size = new System.Drawing.Size(60, 23);
            this.txtCost5.TabIndex = 63;
            // 
            // txtUnitCount2
            // 
            this.txtUnitCount2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnitCount2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitCount2.Location = new System.Drawing.Point(28, 92);
            this.txtUnitCount2.Margin = new System.Windows.Forms.Padding(0);
            this.txtUnitCount2.Name = "txtUnitCount2";
            this.txtUnitCount2.ReadOnly = true;
            this.txtUnitCount2.Size = new System.Drawing.Size(44, 23);
            this.txtUnitCount2.TabIndex = 45;
            // 
            // txtUK3
            // 
            this.txtUK3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUK3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK3.Location = new System.Drawing.Point(149, 121);
            this.txtUK3.Margin = new System.Windows.Forms.Padding(0);
            this.txtUK3.Name = "txtUK3";
            this.txtUK3.ReadOnly = true;
            this.txtUK3.Size = new System.Drawing.Size(60, 23);
            this.txtUK3.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(28, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 42);
            this.label14.TabIndex = 224;
            this.label14.Text = "Col\r\nQty";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnitCount1
            // 
            this.txtUnitCount1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnitCount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitCount1.Location = new System.Drawing.Point(28, 63);
            this.txtUnitCount1.Margin = new System.Windows.Forms.Padding(0);
            this.txtUnitCount1.Name = "txtUnitCount1";
            this.txtUnitCount1.ReadOnly = true;
            this.txtUnitCount1.Size = new System.Drawing.Size(44, 23);
            this.txtUnitCount1.TabIndex = 40;
            // 
            // txtUK1
            // 
            this.txtUK1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK1.Location = new System.Drawing.Point(149, 63);
            this.txtUK1.Margin = new System.Windows.Forms.Padding(0);
            this.txtUK1.Name = "txtUK1";
            this.txtUK1.ReadOnly = true;
            this.txtUK1.Size = new System.Drawing.Size(60, 23);
            this.txtUK1.TabIndex = 42;
            // 
            // txtCost3
            // 
            this.txtCost3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCost3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost3.Location = new System.Drawing.Point(217, 121);
            this.txtCost3.Margin = new System.Windows.Forms.Padding(0);
            this.txtCost3.Name = "txtCost3";
            this.txtCost3.ReadOnly = true;
            this.txtCost3.Size = new System.Drawing.Size(60, 23);
            this.txtCost3.TabIndex = 53;
            // 
            // txtCost4
            // 
            this.txtCost4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCost4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost4.Location = new System.Drawing.Point(217, 151);
            this.txtCost4.Margin = new System.Windows.Forms.Padding(0);
            this.txtCost4.Name = "txtCost4";
            this.txtCost4.ReadOnly = true;
            this.txtCost4.Size = new System.Drawing.Size(60, 23);
            this.txtCost4.TabIndex = 58;
            // 
            // txtUnitCount4
            // 
            this.txtUnitCount4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnitCount4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitCount4.Location = new System.Drawing.Point(28, 151);
            this.txtUnitCount4.Margin = new System.Windows.Forms.Padding(0);
            this.txtUnitCount4.Name = "txtUnitCount4";
            this.txtUnitCount4.ReadOnly = true;
            this.txtUnitCount4.Size = new System.Drawing.Size(44, 23);
            this.txtUnitCount4.TabIndex = 55;
            // 
            // txtCost2
            // 
            this.txtCost2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost2.Location = new System.Drawing.Point(217, 92);
            this.txtCost2.Margin = new System.Windows.Forms.Padding(0);
            this.txtCost2.Name = "txtCost2";
            this.txtCost2.ReadOnly = true;
            this.txtCost2.Size = new System.Drawing.Size(60, 23);
            this.txtCost2.TabIndex = 48;
            // 
            // txtUK4
            // 
            this.txtUK4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUK4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK4.Location = new System.Drawing.Point(149, 151);
            this.txtUK4.Margin = new System.Windows.Forms.Padding(0);
            this.txtUK4.Name = "txtUK4";
            this.txtUK4.ReadOnly = true;
            this.txtUK4.Size = new System.Drawing.Size(60, 23);
            this.txtUK4.TabIndex = 57;
            // 
            // txtUnitCount3
            // 
            this.txtUnitCount3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUnitCount3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUnitCount3.Location = new System.Drawing.Point(28, 121);
            this.txtUnitCount3.Margin = new System.Windows.Forms.Padding(0);
            this.txtUnitCount3.Name = "txtUnitCount3";
            this.txtUnitCount3.ReadOnly = true;
            this.txtUnitCount3.Size = new System.Drawing.Size(44, 23);
            this.txtUnitCount3.TabIndex = 50;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.textBox2);
            this.groupBox9.Controls.Add(this.textBox14);
            this.groupBox9.Controls.Add(this.textBox13);
            this.groupBox9.Controls.Add(this.label59);
            this.groupBox9.Controls.Add(this.label56);
            this.groupBox9.Controls.Add(this.txtRSStock);
            this.groupBox9.Controls.Add(this.txtRSOnOrder);
            this.groupBox9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.groupBox9.Location = new System.Drawing.Point(384, 192);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(283, 144);
            this.groupBox9.TabIndex = 282;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "RS Stock Info";
            // 
            // textBox14
            // 
            this.textBox14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox14.Location = new System.Drawing.Point(181, 51);
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(97, 21);
            this.textBox14.TabIndex = 245;
            // 
            // textBox13
            // 
            this.textBox13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox13.Location = new System.Drawing.Point(181, 77);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(97, 23);
            this.textBox13.TabIndex = 244;
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label59.Location = new System.Drawing.Point(33, 55);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(45, 16);
            this.label59.TabIndex = 216;
            this.label59.Text = "GB 01";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label56.Location = new System.Drawing.Point(33, 81);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(66, 16);
            this.label56.TabIndex = 222;
            this.label56.Text = "On Order";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRSStock
            // 
            this.txtRSStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRSStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRSStock.Location = new System.Drawing.Point(104, 51);
            this.txtRSStock.Name = "txtRSStock";
            this.txtRSStock.ReadOnly = true;
            this.txtRSStock.Size = new System.Drawing.Size(62, 23);
            this.txtRSStock.TabIndex = 240;
            // 
            // txtRSOnOrder
            // 
            this.txtRSOnOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRSOnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRSOnOrder.Location = new System.Drawing.Point(104, 77);
            this.txtRSOnOrder.Name = "txtRSOnOrder";
            this.txtRSOnOrder.ReadOnly = true;
            this.txtRSOnOrder.Size = new System.Drawing.Size(62, 23);
            this.txtRSOnOrder.TabIndex = 243;
            // 
            // rbProductName
            // 
            this.rbProductName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbProductName.AutoSize = true;
            this.rbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProductName.Location = new System.Drawing.Point(473, 1);
            this.rbProductName.Name = "rbProductName";
            this.rbProductName.Size = new System.Drawing.Size(116, 21);
            this.rbProductName.TabIndex = 283;
            this.rbProductName.Text = "Product Name";
            this.rbProductName.UseVisualStyleBackColor = true;
            this.rbProductName.CheckedChanged += new System.EventHandler(this.rbProductName_CheckedChanged);
            // 
            // rbProductCode
            // 
            this.rbProductCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbProductCode.AutoSize = true;
            this.rbProductCode.Checked = true;
            this.rbProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbProductCode.Location = new System.Drawing.Point(355, 2);
            this.rbProductCode.Name = "rbProductCode";
            this.rbProductCode.Size = new System.Drawing.Size(112, 21);
            this.rbProductCode.TabIndex = 284;
            this.rbProductCode.TabStop = true;
            this.rbProductCode.Text = "Product Code";
            this.rbProductCode.UseVisualStyleBackColor = true;
            this.rbProductCode.CheckedChanged += new System.EventHandler(this.rbProductCode_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(181, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(97, 21);
            this.textBox1.TabIndex = 248;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(33, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 246;
            this.label2.Text = "IME DXB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(104, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 23);
            this.textBox2.TabIndex = 247;
            // 
            // rbMPNCode
            // 
            this.rbMPNCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbMPNCode.AutoSize = true;
            this.rbMPNCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMPNCode.Location = new System.Drawing.Point(595, 4);
            this.rbMPNCode.Name = "rbMPNCode";
            this.rbMPNCode.Size = new System.Drawing.Size(93, 21);
            this.rbMPNCode.TabIndex = 285;
            this.rbMPNCode.Text = "MPN Code";
            this.rbMPNCode.UseVisualStyleBackColor = true;
            this.rbMPNCode.CheckedChanged += new System.EventHandler(this.rbMPNCode_CheckedChanged);
            // 
            // frmGetCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 447);
            this.Controls.Add(this.rbMPNCode);
            this.Controls.Add(this.rbProductName);
            this.Controls.Add(this.rbProductCode);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupPrices);
            this.Controls.Add(this.dgItemList);
            this.Controls.Add(this.ArticleNoSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(853, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(853, 490);
            this.Name = "frmGetCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGetCost";
            ((System.ComponentModel.ISupportInitialize)(this.dgItemList)).EndInit();
            this.groupPrices.ResumeLayout(false);
            this.groupPrices.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ArticleNoSearch;
        private System.Windows.Forms.DataGridView dgItemList;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupPrices;
        private System.Windows.Forms.TextBox txtWeb5;
        private System.Windows.Forms.TextBox txtWeb2;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox txtWeb3;
        private System.Windows.Forms.TextBox txtWeb1;
        private System.Windows.Forms.TextBox txtWeb4;
        private System.Windows.Forms.TextBox txtCost1;
        private System.Windows.Forms.TextBox txtUnitCount5;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtUK5;
        private System.Windows.Forms.TextBox txtUK2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtCost5;
        private System.Windows.Forms.TextBox txtUnitCount2;
        private System.Windows.Forms.TextBox txtUK3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUnitCount1;
        private System.Windows.Forms.TextBox txtUK1;
        private System.Windows.Forms.TextBox txtCost3;
        private System.Windows.Forms.TextBox txtCost4;
        private System.Windows.Forms.TextBox txtUnitCount4;
        private System.Windows.Forms.TextBox txtCost2;
        private System.Windows.Forms.TextBox txtUK4;
        private System.Windows.Forms.TextBox txtUnitCount3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtRSStock;
        private System.Windows.Forms.TextBox txtRSOnOrder;
        private System.Windows.Forms.RadioButton rbProductName;
        private System.Windows.Forms.RadioButton rbProductCode;
        private System.Windows.Forms.TextBox txtMargin5;
        private System.Windows.Forms.TextBox txtMargin2;
        private System.Windows.Forms.TextBox txtMargin1;
        private System.Windows.Forms.TextBox txtMargin4;
        private System.Windows.Forms.TextBox txtMargin3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton rbMPNCode;
    }
}