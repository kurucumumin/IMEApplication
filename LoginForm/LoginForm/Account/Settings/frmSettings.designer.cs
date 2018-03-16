namespace LoginForm.Account.Services
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.cbxPayroll = new System.Windows.Forms.CheckBox();
            this.cbxBudget = new System.Windows.Forms.CheckBox();
            this.cbxMultiCurrency = new System.Windows.Forms.CheckBox();
            this.cbxTax = new System.Windows.Forms.CheckBox();
            this.cbxTickPrintAfterSave = new System.Windows.Forms.CheckBox();
            this.cbxShowCurrencySymbol = new System.Windows.Forms.CheckBox();
            this.cbxAllowZeroValueEntry = new System.Windows.Forms.CheckBox();
            this.cbxBillByBill = new System.Windows.Forms.CheckBox();
            this.cbxAllowRack = new System.Windows.Forms.CheckBox();
            this.cbxAllowGodown = new System.Windows.Forms.CheckBox();
            this.cbxAllowModelNo = new System.Windows.Forms.CheckBox();
            this.cbxAllowSize = new System.Windows.Forms.CheckBox();
            this.cbxAllowBatch = new System.Windows.Forms.CheckBox();
            this.cbxBarcode = new System.Windows.Forms.CheckBox();
            this.cbxAutomaticProductCodeGeneration = new System.Windows.Forms.CheckBox();
            this.cbxShowDiscountPercentage = new System.Windows.Forms.CheckBox();
            this.cbxShowBrand = new System.Windows.Forms.CheckBox();
            this.cbxShowProductCode = new System.Windows.Forms.CheckBox();
            this.cbxShowDiscountAmount = new System.Windows.Forms.CheckBox();
            this.cbxShowModelNo = new System.Windows.Forms.CheckBox();
            this.cbxShowSize = new System.Windows.Forms.CheckBox();
            this.cbxShowUnit = new System.Windows.Forms.CheckBox();
            this.cbxShowMRP = new System.Windows.Forms.CheckBox();
            this.cbxShowSalesRate = new System.Windows.Forms.CheckBox();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.cbxDirectPrint = new System.Windows.Forms.CheckBox();
            this.cmbNegativeCashTransaction = new System.Windows.Forms.ComboBox();
            this.lblNegativeCashTransaction = new System.Windows.Forms.Label();
            this.cmbStockValueCalculationMethod = new System.Windows.Forms.ComboBox();
            this.lblStockValueCalculationMethod = new System.Windows.Forms.Label();
            this.cmbNegativeStockStatus = new System.Windows.Forms.ComboBox();
            this.lblNegativeStockStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxAddConfirmationFor = new System.Windows.Forms.CheckBox();
            this.cbxAdd = new System.Windows.Forms.CheckBox();
            this.cbxEdit = new System.Windows.Forms.CheckBox();
            this.cbxDelete = new System.Windows.Forms.CheckBox();
            this.cbxClose = new System.Windows.Forms.CheckBox();
            this.cbxShowPurchaseRate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbxPayroll
            // 
            this.cbxPayroll.AutoSize = true;
            this.cbxPayroll.ForeColor = System.Drawing.Color.White;
            this.cbxPayroll.Location = new System.Drawing.Point(24, 16);
            this.cbxPayroll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxPayroll.Name = "cbxPayroll";
            this.cbxPayroll.Size = new System.Drawing.Size(73, 21);
            this.cbxPayroll.TabIndex = 0;
            this.cbxPayroll.Text = "Payroll";
            this.cbxPayroll.UseVisualStyleBackColor = true;
            this.cbxPayroll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxPayroll_KeyDown);
            // 
            // cbxBudget
            // 
            this.cbxBudget.AutoSize = true;
            this.cbxBudget.ForeColor = System.Drawing.Color.White;
            this.cbxBudget.Location = new System.Drawing.Point(24, 47);
            this.cbxBudget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxBudget.Name = "cbxBudget";
            this.cbxBudget.Size = new System.Drawing.Size(75, 21);
            this.cbxBudget.TabIndex = 1;
            this.cbxBudget.Text = "Budget";
            this.cbxBudget.UseVisualStyleBackColor = true;
            this.cbxBudget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxBudget_KeyDown);
            // 
            // cbxMultiCurrency
            // 
            this.cbxMultiCurrency.AutoSize = true;
            this.cbxMultiCurrency.ForeColor = System.Drawing.Color.White;
            this.cbxMultiCurrency.Location = new System.Drawing.Point(24, 108);
            this.cbxMultiCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxMultiCurrency.Name = "cbxMultiCurrency";
            this.cbxMultiCurrency.Size = new System.Drawing.Size(120, 21);
            this.cbxMultiCurrency.TabIndex = 3;
            this.cbxMultiCurrency.Text = "Multi Currency";
            this.cbxMultiCurrency.UseVisualStyleBackColor = true;
            this.cbxMultiCurrency.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxMultiCurrency_KeyDown);
            // 
            // cbxTax
            // 
            this.cbxTax.AutoSize = true;
            this.cbxTax.ForeColor = System.Drawing.Color.White;
            this.cbxTax.Location = new System.Drawing.Point(24, 78);
            this.cbxTax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxTax.Name = "cbxTax";
            this.cbxTax.Size = new System.Drawing.Size(53, 21);
            this.cbxTax.TabIndex = 2;
            this.cbxTax.Text = "Tax";
            this.cbxTax.UseVisualStyleBackColor = true;
            this.cbxTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxTax_KeyDown);
            // 
            // cbxTickPrintAfterSave
            // 
            this.cbxTickPrintAfterSave.AutoSize = true;
            this.cbxTickPrintAfterSave.ForeColor = System.Drawing.Color.White;
            this.cbxTickPrintAfterSave.Location = new System.Drawing.Point(24, 231);
            this.cbxTickPrintAfterSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxTickPrintAfterSave.Name = "cbxTickPrintAfterSave";
            this.cbxTickPrintAfterSave.Size = new System.Drawing.Size(159, 21);
            this.cbxTickPrintAfterSave.TabIndex = 7;
            this.cbxTickPrintAfterSave.Text = "Tick Print After Save";
            this.cbxTickPrintAfterSave.UseVisualStyleBackColor = true;
            this.cbxTickPrintAfterSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxTickPrintAfterSave_KeyDown);
            // 
            // cbxShowCurrencySymbol
            // 
            this.cbxShowCurrencySymbol.AutoSize = true;
            this.cbxShowCurrencySymbol.ForeColor = System.Drawing.Color.White;
            this.cbxShowCurrencySymbol.Location = new System.Drawing.Point(24, 201);
            this.cbxShowCurrencySymbol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowCurrencySymbol.Name = "cbxShowCurrencySymbol";
            this.cbxShowCurrencySymbol.Size = new System.Drawing.Size(175, 21);
            this.cbxShowCurrencySymbol.TabIndex = 6;
            this.cbxShowCurrencySymbol.Text = "Show Currency Symbol";
            this.cbxShowCurrencySymbol.UseVisualStyleBackColor = true;
            this.cbxShowCurrencySymbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowCurrencySymbol_KeyDown);
            // 
            // cbxAllowZeroValueEntry
            // 
            this.cbxAllowZeroValueEntry.AutoSize = true;
            this.cbxAllowZeroValueEntry.ForeColor = System.Drawing.Color.White;
            this.cbxAllowZeroValueEntry.Location = new System.Drawing.Point(24, 170);
            this.cbxAllowZeroValueEntry.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowZeroValueEntry.Name = "cbxAllowZeroValueEntry";
            this.cbxAllowZeroValueEntry.Size = new System.Drawing.Size(173, 21);
            this.cbxAllowZeroValueEntry.TabIndex = 5;
            this.cbxAllowZeroValueEntry.Text = "Allow Zero Value Entry";
            this.cbxAllowZeroValueEntry.UseVisualStyleBackColor = true;
            this.cbxAllowZeroValueEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowZeroValueEntry_KeyDown);
            // 
            // cbxBillByBill
            // 
            this.cbxBillByBill.AutoSize = true;
            this.cbxBillByBill.ForeColor = System.Drawing.Color.White;
            this.cbxBillByBill.Location = new System.Drawing.Point(24, 139);
            this.cbxBillByBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxBillByBill.Name = "cbxBillByBill";
            this.cbxBillByBill.Size = new System.Drawing.Size(90, 21);
            this.cbxBillByBill.TabIndex = 4;
            this.cbxBillByBill.Text = "Bill By Bill";
            this.cbxBillByBill.UseVisualStyleBackColor = true;
            this.cbxBillByBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxBillByBill_KeyDown);
            // 
            // cbxAllowRack
            // 
            this.cbxAllowRack.AutoSize = true;
            this.cbxAllowRack.ForeColor = System.Drawing.Color.White;
            this.cbxAllowRack.Location = new System.Drawing.Point(341, 47);
            this.cbxAllowRack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowRack.Name = "cbxAllowRack";
            this.cbxAllowRack.Size = new System.Drawing.Size(98, 21);
            this.cbxAllowRack.TabIndex = 14;
            this.cbxAllowRack.Text = "Allow Rack";
            this.cbxAllowRack.UseVisualStyleBackColor = true;
            this.cbxAllowRack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowRack_KeyDown);
            // 
            // cbxAllowGodown
            // 
            this.cbxAllowGodown.AutoSize = true;
            this.cbxAllowGodown.ForeColor = System.Drawing.Color.White;
            this.cbxAllowGodown.Location = new System.Drawing.Point(341, 16);
            this.cbxAllowGodown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowGodown.Name = "cbxAllowGodown";
            this.cbxAllowGodown.Size = new System.Drawing.Size(118, 21);
            this.cbxAllowGodown.TabIndex = 13;
            this.cbxAllowGodown.Text = "Allow Godown";
            this.cbxAllowGodown.UseVisualStyleBackColor = true;
            this.cbxAllowGodown.CheckedChanged += new System.EventHandler(this.cbxAllowGodown_CheckedChanged);
            this.cbxAllowGodown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowGodown_KeyDown);
            // 
            // cbxAllowModelNo
            // 
            this.cbxAllowModelNo.AutoSize = true;
            this.cbxAllowModelNo.ForeColor = System.Drawing.Color.White;
            this.cbxAllowModelNo.Location = new System.Drawing.Point(24, 385);
            this.cbxAllowModelNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowModelNo.Name = "cbxAllowModelNo";
            this.cbxAllowModelNo.Size = new System.Drawing.Size(126, 21);
            this.cbxAllowModelNo.TabIndex = 12;
            this.cbxAllowModelNo.Text = "Allow Model No";
            this.cbxAllowModelNo.UseVisualStyleBackColor = true;
            this.cbxAllowModelNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowModelNo_KeyDown);
            // 
            // cbxAllowSize
            // 
            this.cbxAllowSize.AutoSize = true;
            this.cbxAllowSize.ForeColor = System.Drawing.Color.White;
            this.cbxAllowSize.Location = new System.Drawing.Point(24, 354);
            this.cbxAllowSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowSize.Name = "cbxAllowSize";
            this.cbxAllowSize.Size = new System.Drawing.Size(93, 21);
            this.cbxAllowSize.TabIndex = 11;
            this.cbxAllowSize.Text = "Allow Size";
            this.cbxAllowSize.UseVisualStyleBackColor = true;
            this.cbxAllowSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowSize_KeyDown);
            // 
            // cbxAllowBatch
            // 
            this.cbxAllowBatch.AutoSize = true;
            this.cbxAllowBatch.ForeColor = System.Drawing.Color.White;
            this.cbxAllowBatch.Location = new System.Drawing.Point(24, 324);
            this.cbxAllowBatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAllowBatch.Name = "cbxAllowBatch";
            this.cbxAllowBatch.Size = new System.Drawing.Size(102, 21);
            this.cbxAllowBatch.TabIndex = 10;
            this.cbxAllowBatch.Text = "Allow Batch";
            this.cbxAllowBatch.UseVisualStyleBackColor = true;
            this.cbxAllowBatch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAllowBatch_KeyDown);
            // 
            // cbxBarcode
            // 
            this.cbxBarcode.AutoSize = true;
            this.cbxBarcode.ForeColor = System.Drawing.Color.White;
            this.cbxBarcode.Location = new System.Drawing.Point(24, 293);
            this.cbxBarcode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxBarcode.Name = "cbxBarcode";
            this.cbxBarcode.Size = new System.Drawing.Size(83, 21);
            this.cbxBarcode.TabIndex = 9;
            this.cbxBarcode.Text = "Barcode";
            this.cbxBarcode.UseVisualStyleBackColor = true;
            this.cbxBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxBarcode_KeyDown);
            // 
            // cbxAutomaticProductCodeGeneration
            // 
            this.cbxAutomaticProductCodeGeneration.AutoSize = true;
            this.cbxAutomaticProductCodeGeneration.ForeColor = System.Drawing.Color.White;
            this.cbxAutomaticProductCodeGeneration.Location = new System.Drawing.Point(24, 262);
            this.cbxAutomaticProductCodeGeneration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAutomaticProductCodeGeneration.Name = "cbxAutomaticProductCodeGeneration";
            this.cbxAutomaticProductCodeGeneration.Size = new System.Drawing.Size(261, 21);
            this.cbxAutomaticProductCodeGeneration.TabIndex = 8;
            this.cbxAutomaticProductCodeGeneration.Text = "Automatic  Product Code Generation";
            this.cbxAutomaticProductCodeGeneration.UseVisualStyleBackColor = true;
            this.cbxAutomaticProductCodeGeneration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxAutomaticProductCodeGeneration_KeyDown);
            // 
            // cbxShowDiscountPercentage
            // 
            this.cbxShowDiscountPercentage.AutoSize = true;
            this.cbxShowDiscountPercentage.ForeColor = System.Drawing.Color.White;
            this.cbxShowDiscountPercentage.Location = new System.Drawing.Point(341, 351);
            this.cbxShowDiscountPercentage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowDiscountPercentage.Name = "cbxShowDiscountPercentage";
            this.cbxShowDiscountPercentage.Size = new System.Drawing.Size(200, 21);
            this.cbxShowDiscountPercentage.TabIndex = 23;
            this.cbxShowDiscountPercentage.Text = "Show Discount Percentage";
            this.cbxShowDiscountPercentage.UseVisualStyleBackColor = true;
            // 
            // cbxShowBrand
            // 
            this.cbxShowBrand.AutoSize = true;
            this.cbxShowBrand.ForeColor = System.Drawing.Color.White;
            this.cbxShowBrand.Location = new System.Drawing.Point(341, 320);
            this.cbxShowBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowBrand.Name = "cbxShowBrand";
            this.cbxShowBrand.Size = new System.Drawing.Size(106, 21);
            this.cbxShowBrand.TabIndex = 22;
            this.cbxShowBrand.Text = "Show Brand";
            this.cbxShowBrand.UseVisualStyleBackColor = true;
            this.cbxShowBrand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowBrand_KeyDown);
            // 
            // cbxShowProductCode
            // 
            this.cbxShowProductCode.AutoSize = true;
            this.cbxShowProductCode.ForeColor = System.Drawing.Color.White;
            this.cbxShowProductCode.Location = new System.Drawing.Point(341, 289);
            this.cbxShowProductCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowProductCode.Name = "cbxShowProductCode";
            this.cbxShowProductCode.Size = new System.Drawing.Size(154, 21);
            this.cbxShowProductCode.TabIndex = 21;
            this.cbxShowProductCode.Text = "Show Product Code";
            this.cbxShowProductCode.UseVisualStyleBackColor = true;
            this.cbxShowProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowProductCode_KeyDown);
            // 
            // cbxShowDiscountAmount
            // 
            this.cbxShowDiscountAmount.AutoSize = true;
            this.cbxShowDiscountAmount.ForeColor = System.Drawing.Color.White;
            this.cbxShowDiscountAmount.Location = new System.Drawing.Point(341, 258);
            this.cbxShowDiscountAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowDiscountAmount.Name = "cbxShowDiscountAmount";
            this.cbxShowDiscountAmount.Size = new System.Drawing.Size(175, 21);
            this.cbxShowDiscountAmount.TabIndex = 20;
            this.cbxShowDiscountAmount.Text = "Show Discount Amount";
            this.cbxShowDiscountAmount.UseVisualStyleBackColor = true;
            this.cbxShowDiscountAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowDiscountAmount_KeyDown);
            // 
            // cbxShowModelNo
            // 
            this.cbxShowModelNo.AutoSize = true;
            this.cbxShowModelNo.ForeColor = System.Drawing.Color.White;
            this.cbxShowModelNo.Location = new System.Drawing.Point(341, 228);
            this.cbxShowModelNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowModelNo.Name = "cbxShowModelNo";
            this.cbxShowModelNo.Size = new System.Drawing.Size(128, 21);
            this.cbxShowModelNo.TabIndex = 19;
            this.cbxShowModelNo.Text = "Show Model No";
            this.cbxShowModelNo.UseVisualStyleBackColor = true;
            this.cbxShowModelNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowModelNo_KeyDown);
            // 
            // cbxShowSize
            // 
            this.cbxShowSize.AutoSize = true;
            this.cbxShowSize.ForeColor = System.Drawing.Color.White;
            this.cbxShowSize.Location = new System.Drawing.Point(341, 197);
            this.cbxShowSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowSize.Name = "cbxShowSize";
            this.cbxShowSize.Size = new System.Drawing.Size(95, 21);
            this.cbxShowSize.TabIndex = 18;
            this.cbxShowSize.Text = "Show Size";
            this.cbxShowSize.UseVisualStyleBackColor = true;
            this.cbxShowSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowSize_KeyDown);
            // 
            // cbxShowUnit
            // 
            this.cbxShowUnit.AutoSize = true;
            this.cbxShowUnit.ForeColor = System.Drawing.Color.White;
            this.cbxShowUnit.Location = new System.Drawing.Point(341, 166);
            this.cbxShowUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowUnit.Name = "cbxShowUnit";
            this.cbxShowUnit.Size = new System.Drawing.Size(93, 21);
            this.cbxShowUnit.TabIndex = 17;
            this.cbxShowUnit.Text = "Show Unit";
            this.cbxShowUnit.UseVisualStyleBackColor = true;
            this.cbxShowUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowUnit_KeyDown);
            // 
            // cbxShowMRP
            // 
            this.cbxShowMRP.AutoSize = true;
            this.cbxShowMRP.ForeColor = System.Drawing.Color.White;
            this.cbxShowMRP.Location = new System.Drawing.Point(341, 108);
            this.cbxShowMRP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowMRP.Name = "cbxShowMRP";
            this.cbxShowMRP.Size = new System.Drawing.Size(98, 21);
            this.cbxShowMRP.TabIndex = 16;
            this.cbxShowMRP.Text = "Show MRP";
            this.cbxShowMRP.UseVisualStyleBackColor = true;
            this.cbxShowMRP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowMRP_KeyDown);
            // 
            // cbxShowSalesRate
            // 
            this.cbxShowSalesRate.AutoSize = true;
            this.cbxShowSalesRate.ForeColor = System.Drawing.Color.White;
            this.cbxShowSalesRate.Location = new System.Drawing.Point(341, 78);
            this.cbxShowSalesRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowSalesRate.Name = "cbxShowSalesRate";
            this.cbxShowSalesRate.Size = new System.Drawing.Size(137, 21);
            this.cbxShowSalesRate.TabIndex = 15;
            this.cbxShowSalesRate.Text = "Show Sales Rate";
            this.cbxShowSalesRate.UseVisualStyleBackColor = true;
            this.cbxShowSalesRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxShowCurrentRate_KeyDown);
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinter.Items.AddRange(new object[] {
            "Dot Matrix",
            "Other"});
            this.cmbPrinter.Location = new System.Drawing.Point(773, 231);
            this.cmbPrinter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(268, 24);
            this.cmbPrinter.TabIndex = 29;
            this.cmbPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbPrinter_SelectedIndexChanged);
            this.cmbPrinter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPrinter_KeyDown);
            // 
            // lblPrinter
            // 
            this.lblPrinter.ForeColor = System.Drawing.Color.White;
            this.lblPrinter.Location = new System.Drawing.Point(583, 235);
            this.lblPrinter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(133, 25);
            this.lblPrinter.TabIndex = 1228;
            this.lblPrinter.Text = "Printer";
            // 
            // cbxDirectPrint
            // 
            this.cbxDirectPrint.AutoSize = true;
            this.cbxDirectPrint.ForeColor = System.Drawing.Color.White;
            this.cbxDirectPrint.Location = new System.Drawing.Point(773, 267);
            this.cbxDirectPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxDirectPrint.Name = "cbxDirectPrint";
            this.cbxDirectPrint.Size = new System.Drawing.Size(100, 21);
            this.cbxDirectPrint.TabIndex = 30;
            this.cbxDirectPrint.Text = "Direct Print";
            this.cbxDirectPrint.UseVisualStyleBackColor = true;
            this.cbxDirectPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxDirectPrint_KeyDown);
            // 
            // cmbNegativeCashTransaction
            // 
            this.cmbNegativeCashTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNegativeCashTransaction.Items.AddRange(new object[] {
            "Warn",
            "Block",
            "Ignore"});
            this.cmbNegativeCashTransaction.Location = new System.Drawing.Point(835, 346);
            this.cmbNegativeCashTransaction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cmbNegativeCashTransaction.Name = "cmbNegativeCashTransaction";
            this.cmbNegativeCashTransaction.Size = new System.Drawing.Size(201, 24);
            this.cmbNegativeCashTransaction.TabIndex = 31;
            this.cmbNegativeCashTransaction.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNegativeCashTransaction_KeyDown);
            // 
            // lblNegativeCashTransaction
            // 
            this.lblNegativeCashTransaction.AutoSize = true;
            this.lblNegativeCashTransaction.ForeColor = System.Drawing.Color.White;
            this.lblNegativeCashTransaction.Location = new System.Drawing.Point(583, 356);
            this.lblNegativeCashTransaction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNegativeCashTransaction.Name = "lblNegativeCashTransaction";
            this.lblNegativeCashTransaction.Size = new System.Drawing.Size(179, 17);
            this.lblNegativeCashTransaction.TabIndex = 1233;
            this.lblNegativeCashTransaction.Text = "Negative Cash Transaction";
            // 
            // cmbStockValueCalculationMethod
            // 
            this.cmbStockValueCalculationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockValueCalculationMethod.Items.AddRange(new object[] {
            "Average Cost",
            "FIFO",
            "Low Cost",
            "High Cost",
            "Last Purchase Rate"});
            this.cmbStockValueCalculationMethod.Location = new System.Drawing.Point(835, 377);
            this.cmbStockValueCalculationMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cmbStockValueCalculationMethod.Name = "cmbStockValueCalculationMethod";
            this.cmbStockValueCalculationMethod.Size = new System.Drawing.Size(201, 24);
            this.cmbStockValueCalculationMethod.TabIndex = 32;
            this.cmbStockValueCalculationMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmblblStockValueCalculationMethod_KeyDown);
            // 
            // lblStockValueCalculationMethod
            // 
            this.lblStockValueCalculationMethod.AutoSize = true;
            this.lblStockValueCalculationMethod.ForeColor = System.Drawing.Color.White;
            this.lblStockValueCalculationMethod.Location = new System.Drawing.Point(583, 386);
            this.lblStockValueCalculationMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockValueCalculationMethod.Name = "lblStockValueCalculationMethod";
            this.lblStockValueCalculationMethod.Size = new System.Drawing.Size(207, 17);
            this.lblStockValueCalculationMethod.TabIndex = 1235;
            this.lblStockValueCalculationMethod.Text = "Stock Value Calculation Method";
            // 
            // cmbNegativeStockStatus
            // 
            this.cmbNegativeStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNegativeStockStatus.Items.AddRange(new object[] {
            "Warn",
            "Block",
            "Ignore"});
            this.cmbNegativeStockStatus.Location = new System.Drawing.Point(835, 407);
            this.cmbNegativeStockStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cmbNegativeStockStatus.Name = "cmbNegativeStockStatus";
            this.cmbNegativeStockStatus.Size = new System.Drawing.Size(201, 24);
            this.cmbNegativeStockStatus.TabIndex = 33;
            this.cmbNegativeStockStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNegativeStockStatus_KeyDown);
            // 
            // lblNegativeStockStatus
            // 
            this.lblNegativeStockStatus.AutoSize = true;
            this.lblNegativeStockStatus.ForeColor = System.Drawing.Color.White;
            this.lblNegativeStockStatus.Location = new System.Drawing.Point(583, 417);
            this.lblNegativeStockStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNegativeStockStatus.Name = "lblNegativeStockStatus";
            this.lblNegativeStockStatus.Size = new System.Drawing.Size(147, 17);
            this.lblNegativeStockStatus.TabIndex = 1237;
            this.lblNegativeStockStatus.Text = "Negative Stock Status";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(929, 442);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 33);
            this.btnClose.TabIndex = 36;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnClose_KeyDown);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(808, 442);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 33);
            this.btnReset.TabIndex = 35;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnReset_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(687, 442);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 33);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSave_KeyDown);
            // 
            // cbxAddConfirmationFor
            // 
            this.cbxAddConfirmationFor.AutoSize = true;
            this.cbxAddConfirmationFor.ForeColor = System.Drawing.Color.White;
            this.cbxAddConfirmationFor.Location = new System.Drawing.Point(771, 16);
            this.cbxAddConfirmationFor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAddConfirmationFor.Name = "cbxAddConfirmationFor";
            this.cbxAddConfirmationFor.Size = new System.Drawing.Size(163, 21);
            this.cbxAddConfirmationFor.TabIndex = 24;
            this.cbxAddConfirmationFor.Text = "Add Confirmation For";
            this.cbxAddConfirmationFor.UseVisualStyleBackColor = true;
            this.cbxAddConfirmationFor.CheckedChanged += new System.EventHandler(this.cbxAddConfirmationFor_CheckedChanged);
            // 
            // cbxAdd
            // 
            this.cbxAdd.AutoSize = true;
            this.cbxAdd.ForeColor = System.Drawing.Color.White;
            this.cbxAdd.Location = new System.Drawing.Point(835, 52);
            this.cbxAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxAdd.Name = "cbxAdd";
            this.cbxAdd.Size = new System.Drawing.Size(55, 21);
            this.cbxAdd.TabIndex = 25;
            this.cbxAdd.Text = "Add";
            this.cbxAdd.UseVisualStyleBackColor = true;
            this.cbxAdd.CheckedChanged += new System.EventHandler(this.cbxAdd_CheckedChanged);
            // 
            // cbxEdit
            // 
            this.cbxEdit.AutoSize = true;
            this.cbxEdit.ForeColor = System.Drawing.Color.White;
            this.cbxEdit.Location = new System.Drawing.Point(835, 82);
            this.cbxEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxEdit.Name = "cbxEdit";
            this.cbxEdit.Size = new System.Drawing.Size(54, 21);
            this.cbxEdit.TabIndex = 26;
            this.cbxEdit.Text = "Edit";
            this.cbxEdit.UseVisualStyleBackColor = true;
            this.cbxEdit.CheckedChanged += new System.EventHandler(this.cbxEdit_CheckedChanged);
            // 
            // cbxDelete
            // 
            this.cbxDelete.AutoSize = true;
            this.cbxDelete.ForeColor = System.Drawing.Color.White;
            this.cbxDelete.Location = new System.Drawing.Point(835, 113);
            this.cbxDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxDelete.Name = "cbxDelete";
            this.cbxDelete.Size = new System.Drawing.Size(71, 21);
            this.cbxDelete.TabIndex = 27;
            this.cbxDelete.Text = "Delete";
            this.cbxDelete.UseVisualStyleBackColor = true;
            this.cbxDelete.CheckedChanged += new System.EventHandler(this.cbxDelete_CheckedChanged);
            // 
            // cbxClose
            // 
            this.cbxClose.AutoSize = true;
            this.cbxClose.ForeColor = System.Drawing.Color.White;
            this.cbxClose.Location = new System.Drawing.Point(835, 144);
            this.cbxClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxClose.Name = "cbxClose";
            this.cbxClose.Size = new System.Drawing.Size(65, 21);
            this.cbxClose.TabIndex = 28;
            this.cbxClose.Text = "Close";
            this.cbxClose.UseVisualStyleBackColor = true;
            this.cbxClose.CheckedChanged += new System.EventHandler(this.cbxClose_CheckedChanged);
            // 
            // cbxShowPurchaseRate
            // 
            this.cbxShowPurchaseRate.AutoSize = true;
            this.cbxShowPurchaseRate.ForeColor = System.Drawing.Color.White;
            this.cbxShowPurchaseRate.Location = new System.Drawing.Point(341, 138);
            this.cbxShowPurchaseRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 6);
            this.cbxShowPurchaseRate.Name = "cbxShowPurchaseRate";
            this.cbxShowPurchaseRate.Size = new System.Drawing.Size(162, 21);
            this.cbxShowPurchaseRate.TabIndex = 1238;
            this.cbxShowPurchaseRate.Text = "Show Purchase Rate";
            this.cbxShowPurchaseRate.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(111)))), ((int)(((byte)(155)))));
            this.ClientSize = new System.Drawing.Size(1067, 491);
            this.Controls.Add(this.cbxShowPurchaseRate);
            this.Controls.Add(this.cbxClose);
            this.Controls.Add(this.cbxDelete);
            this.Controls.Add(this.cbxEdit);
            this.Controls.Add(this.cbxAdd);
            this.Controls.Add(this.cbxAddConfirmationFor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbNegativeStockStatus);
            this.Controls.Add(this.lblNegativeStockStatus);
            this.Controls.Add(this.cmbStockValueCalculationMethod);
            this.Controls.Add(this.lblStockValueCalculationMethod);
            this.Controls.Add(this.cmbNegativeCashTransaction);
            this.Controls.Add(this.lblNegativeCashTransaction);
            this.Controls.Add(this.cbxDirectPrint);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.lblPrinter);
            this.Controls.Add(this.cbxShowDiscountPercentage);
            this.Controls.Add(this.cbxShowBrand);
            this.Controls.Add(this.cbxShowProductCode);
            this.Controls.Add(this.cbxShowDiscountAmount);
            this.Controls.Add(this.cbxShowModelNo);
            this.Controls.Add(this.cbxShowSize);
            this.Controls.Add(this.cbxShowUnit);
            this.Controls.Add(this.cbxShowMRP);
            this.Controls.Add(this.cbxShowSalesRate);
            this.Controls.Add(this.cbxAllowRack);
            this.Controls.Add(this.cbxAllowGodown);
            this.Controls.Add(this.cbxAllowModelNo);
            this.Controls.Add(this.cbxAllowSize);
            this.Controls.Add(this.cbxAllowBatch);
            this.Controls.Add(this.cbxBarcode);
            this.Controls.Add(this.cbxAutomaticProductCodeGeneration);
            this.Controls.Add(this.cbxTickPrintAfterSave);
            this.Controls.Add(this.cbxShowCurrencySymbol);
            this.Controls.Add(this.cbxAllowZeroValueEntry);
            this.Controls.Add(this.cbxBillByBill);
            this.Controls.Add(this.cbxMultiCurrency);
            this.Controls.Add(this.cbxTax);
            this.Controls.Add(this.cbxBudget);
            this.Controls.Add(this.cbxPayroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxPayroll;
        private System.Windows.Forms.CheckBox cbxBudget;
        private System.Windows.Forms.CheckBox cbxMultiCurrency;
        private System.Windows.Forms.CheckBox cbxTax;
        private System.Windows.Forms.CheckBox cbxTickPrintAfterSave;
        private System.Windows.Forms.CheckBox cbxShowCurrencySymbol;
        private System.Windows.Forms.CheckBox cbxAllowZeroValueEntry;
        private System.Windows.Forms.CheckBox cbxBillByBill;
        private System.Windows.Forms.CheckBox cbxAllowRack;
        private System.Windows.Forms.CheckBox cbxAllowGodown;
        private System.Windows.Forms.CheckBox cbxAllowModelNo;
        private System.Windows.Forms.CheckBox cbxAllowSize;
        private System.Windows.Forms.CheckBox cbxAllowBatch;
        private System.Windows.Forms.CheckBox cbxBarcode;
        private System.Windows.Forms.CheckBox cbxAutomaticProductCodeGeneration;
        private System.Windows.Forms.CheckBox cbxShowDiscountPercentage;
        private System.Windows.Forms.CheckBox cbxShowBrand;
        private System.Windows.Forms.CheckBox cbxShowProductCode;
        private System.Windows.Forms.CheckBox cbxShowDiscountAmount;
        private System.Windows.Forms.CheckBox cbxShowModelNo;
        private System.Windows.Forms.CheckBox cbxShowSize;
        private System.Windows.Forms.CheckBox cbxShowUnit;
        private System.Windows.Forms.CheckBox cbxShowMRP;
        private System.Windows.Forms.CheckBox cbxShowSalesRate;
        private System.Windows.Forms.ComboBox cmbPrinter;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.CheckBox cbxDirectPrint;
        private System.Windows.Forms.ComboBox cmbNegativeCashTransaction;
        private System.Windows.Forms.Label lblNegativeCashTransaction;
        private System.Windows.Forms.ComboBox cmbStockValueCalculationMethod;
        private System.Windows.Forms.Label lblStockValueCalculationMethod;
        private System.Windows.Forms.ComboBox cmbNegativeStockStatus;
        private System.Windows.Forms.Label lblNegativeStockStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxAddConfirmationFor;
        private System.Windows.Forms.CheckBox cbxAdd;
        private System.Windows.Forms.CheckBox cbxEdit;
        private System.Windows.Forms.CheckBox cbxDelete;
        private System.Windows.Forms.CheckBox cbxClose;
        private System.Windows.Forms.CheckBox cbxShowPurchaseRate;
    }
}