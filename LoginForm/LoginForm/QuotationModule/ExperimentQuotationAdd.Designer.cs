using System.Linq;

namespace LoginForm.QuotationModule
{
    partial class ExperimentQuotationAdd
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgAddedItems = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgDeletedItems = new System.Windows.Forms.DataGridView();
            this.No1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDesc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQty1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUOM1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSSM1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUPIME1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDisc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUCUPCurr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTotal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTargetUP1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCompetitor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDelivery1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgUnitWeigt1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustomerStokCode1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustDescription1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label65 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.btnExQuotation = new System.Windows.Forms.Button();
            this.btnImportFromXML = new System.Windows.Forms.Button();
            this.btnCustomizeGrid = new System.Windows.Forms.Button();
            this.btnProductHistory = new System.Windows.Forms.Button();
            this.txtSubtotal = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.txtTotalMarginGrid = new System.Windows.Forms.MaskedTextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCustomerDetails = new System.Windows.Forms.TabPage();
            this.txtAccountingNote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.lblExcRate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnViewMore = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.cbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbRepresentative = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRFQNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.txtValidity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuotationNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddAttention = new System.Windows.Forms.Button();
            this.cbWorkers = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactNote = new System.Windows.Forms.TextBox();
            this.txtCustomerNote = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabItemDetails = new System.Windows.Forms.TabPage();
            this.gbCost = new System.Windows.Forms.GroupBox();
            this.txtCost1 = new System.Windows.Forms.TextBox();
            this.txtMargin5 = new System.Windows.Forms.TextBox();
            this.txtUK5 = new System.Windows.Forms.TextBox();
            this.txtUK2 = new System.Windows.Forms.TextBox();
            this.txtCost5 = new System.Windows.Forms.TextBox();
            this.txtMargin1 = new System.Windows.Forms.TextBox();
            this.txtMargin2 = new System.Windows.Forms.TextBox();
            this.txtUK3 = new System.Windows.Forms.TextBox();
            this.txtUK1 = new System.Windows.Forms.TextBox();
            this.txtCost3 = new System.Windows.Forms.TextBox();
            this.txtMargin4 = new System.Windows.Forms.TextBox();
            this.txtCost4 = new System.Windows.Forms.TextBox();
            this.txtCost2 = new System.Windows.Forms.TextBox();
            this.txtMargin3 = new System.Windows.Forms.TextBox();
            this.txtUK4 = new System.Windows.Forms.TextBox();
            this.lblMargin = new System.Windows.Forms.Label();
            this.txtWeb5 = new System.Windows.Forms.TextBox();
            this.txtWeb2 = new System.Windows.Forms.TextBox();
            this.txtWeb3 = new System.Windows.Forms.TextBox();
            this.txtWeb1 = new System.Windows.Forms.TextBox();
            this.txtWeb4 = new System.Windows.Forms.TextBox();
            this.txtCol5Break = new System.Windows.Forms.TextBox();
            this.txtCol2Break = new System.Windows.Forms.TextBox();
            this.txtCol1Break = new System.Windows.Forms.TextBox();
            this.txtCol4Break = new System.Windows.Forms.TextBox();
            this.txtCol3Break = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.lblWeb = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.txtSupersectionName = new System.Windows.Forms.TextBox();
            this.txtCofO = new System.Windows.Forms.TextBox();
            this.txtItemNote = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtCCCN = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtMHCodeLevel1 = new System.Windows.Forms.TextBox();
            this.txtIME04 = new System.Windows.Forms.TextBox();
            this.txtIME03 = new System.Windows.Forms.TextBox();
            this.txtIME02 = new System.Windows.Forms.TextBox();
            this.txtIME01 = new System.Windows.Forms.TextBox();
            this.txtOnOrder = new System.Windows.Forms.TextBox();
            this.txtExpiringPro = new System.Windows.Forms.TextBox();
            this.txtHazardousInd = new System.Windows.Forms.TextBox();
            this.txtDiscChange = new System.Windows.Forms.TextBox();
            this.txtEnvironment = new System.Windows.Forms.TextBox();
            this.txtLithium = new System.Windows.Forms.TextBox();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.txtLicenceType = new System.Windows.Forms.TextBox();
            this.txtCalibrationInd = new System.Windows.Forms.TextBox();
            this.txtGB01_b = new System.Windows.Forms.TextBox();
            this.txtOnOrder_b = new System.Windows.Forms.TextBox();
            this.txtGB01_a = new System.Windows.Forms.TextBox();
            this.txtOnOrder_a = new System.Windows.Forms.TextBox();
            this.txtDiscontinuationDate = new System.Windows.Forms.TextBox();
            this.txtUKDiscDate = new System.Windows.Forms.TextBox();
            this.txtSubstitutedBy = new System.Windows.Forms.TextBox();
            this.txtRunOn = new System.Windows.Forms.TextBox();
            this.txtPP = new System.Windows.Forms.TextBox();
            this.txtReferral = new System.Windows.Forms.TextBox();
            this.txtStandardWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtGrossWeight = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.LandingCost = new System.Windows.Forms.GroupBox();
            this.ckCustomsDuties = new System.Windows.Forms.CheckBox();
            this.ckWeightCost = new System.Windows.Forms.CheckBox();
            this.ckItemCost = new System.Windows.Forms.CheckBox();
            this.btnCreateRev = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.cbDeliverDiscount = new System.Windows.Forms.CheckBox();
            this.lblTotalExtra = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txtExtraChanges = new System.Windows.Forms.TextBox();
            this.lblVatTotal = new System.Windows.Forms.Label();
            this.txtTotalMarginGeneral = new System.Windows.Forms.TextBox();
            this.txtTotalDiscAmount = new System.Windows.Forms.TextBox();
            this.chkVat = new System.Windows.Forms.CheckBox();
            this.txtTotalDiscPercent = new System.Windows.Forms.TextBox();
            this.lblGrossTotal = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkbForFinance = new System.Windows.Forms.CheckBox();
            this.txtNoteForUs = new System.Windows.Forms.TextBox();
            this.gbShipment = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSMethod = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNoteForCustomer = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMPN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUKPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgLandingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMargin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSSM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUPIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUCUPCurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTargetUP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCompetitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgHZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDelivery = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgUnitWeigt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustStkCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCustDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCOO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCCCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDependantTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddedItems)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeletedItems)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCustomerDetails.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.tabItemDetails.SuspendLayout();
            this.gbCost.SuspendLayout();
            this.panel1.SuspendLayout();
            this.LandingCost.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbShipment.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1657, 902);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(8, 229);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgAddedItems);
            this.splitContainer1.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Panel1MinSize = 80;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2MinSize = 130;
            this.splitContainer1.Size = new System.Drawing.Size(1641, 496);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 57;
            // 
            // dgAddedItems
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgAddedItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAddedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgNo,
            this.HS,
            this.LI,
            this.CL,
            this.LC,
            this.LM,
            this.dgSupplier,
            this.dgProductCode,
            this.dgBrand,
            this.dgMPN,
            this.dgDesc,
            this.dgUKPrice,
            this.dgCost,
            this.dgLandingCost,
            this.dgMargin,
            this.dgQty,
            this.dgStock,
            this.dgUOM,
            this.dgSSM,
            this.dgUC,
            this.dgUPIME,
            this.dgDisc,
            this.dgUCUPCurr,
            this.dgTotal,
            this.dgTargetUP,
            this.dgCompetitor,
            this.dgHZ,
            this.dgCL,
            this.dgCR,
            this.dgDelivery,
            this.dgUnitWeigt,
            this.dgTotalWeight,
            this.dgCustStkCode,
            this.dgCustDescription,
            this.dgCOO,
            this.dgCCCNO,
            this.dgDependantTable});
            this.dgAddedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAddedItems.Location = new System.Drawing.Point(0, 0);
            this.dgAddedItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgAddedItems.Name = "dgAddedItems";
            this.dgAddedItems.Size = new System.Drawing.Size(1637, 346);
            this.dgAddedItems.TabIndex = 9;
            this.dgAddedItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAddedItems_CellEndEdit);
            this.dgAddedItems.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAddedItems_RowEnter);
            this.dgAddedItems.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgAddedItems_RowsAdded);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgDeletedItems, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1637, 136);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgDeletedItems
            // 
            this.dgDeletedItems.AllowUserToAddRows = false;
            this.dgDeletedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeletedItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dgProductCode1,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dgDesc1,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dgQty1,
            this.dataGridViewTextBoxColumn17,
            this.dgUOM1,
            this.dgSSM1,
            this.dgUC1,
            this.dgUPIME1,
            this.dgDisc1,
            this.dgUCUPCurr1,
            this.dgTotal1,
            this.dgTargetUP1,
            this.dgCompetitor1,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dgDelivery1,
            this.dgUnitWeigt1,
            this.dataGridViewTextBoxColumn32,
            this.dgCustomerStokCode1,
            this.dgCustDescription1,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36});
            this.dgDeletedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDeletedItems.Location = new System.Drawing.Point(4, 64);
            this.dgDeletedItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgDeletedItems.Name = "dgDeletedItems";
            this.dgDeletedItems.ReadOnly = true;
            this.dgDeletedItems.Size = new System.Drawing.Size(1629, 68);
            this.dgDeletedItems.TabIndex = 10;
            // 
            // No1
            // 
            this.No1.Frozen = true;
            this.No1.HeaderText = "No";
            this.No1.Name = "No1";
            this.No1.ReadOnly = true;
            this.No1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.No1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "HS";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 32;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "LI";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 32;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "CL";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 32;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "LC";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 32;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "LM";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 32;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "Supplier";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dgProductCode1
            // 
            this.dgProductCode1.Frozen = true;
            this.dgProductCode1.HeaderText = "Item Code";
            this.dgProductCode1.Name = "dgProductCode1";
            this.dgProductCode1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "MPN";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dgDesc1
            // 
            this.dgDesc1.Frozen = true;
            this.dgDesc1.HeaderText = "Description";
            this.dgDesc1.Name = "dgDesc1";
            this.dgDesc1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Cost (£)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Landing Cost (£)";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Margin (%)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dgQty1
            // 
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dgQty1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgQty1.HeaderText = "Qty";
            this.dgQty1.Name = "dgQty1";
            this.dgQty1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Stock";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dgUOM1
            // 
            this.dgUOM1.HeaderText = "UOM";
            this.dgUOM1.Name = "dgUOM1";
            this.dgUOM1.ReadOnly = true;
            // 
            // dgSSM1
            // 
            this.dgSSM1.HeaderText = "SSM";
            this.dgSSM1.Name = "dgSSM1";
            this.dgSSM1.ReadOnly = true;
            // 
            // dgUC1
            // 
            this.dgUC1.HeaderText = "U/C";
            this.dgUC1.Name = "dgUC1";
            this.dgUC1.ReadOnly = true;
            // 
            // dgUPIME1
            // 
            this.dgUPIME1.HeaderText = "U/P IME L/P ";
            this.dgUPIME1.Name = "dgUPIME1";
            this.dgUPIME1.ReadOnly = true;
            // 
            // dgDisc1
            // 
            this.dgDisc1.HeaderText = "Disc. (%)";
            this.dgDisc1.Name = "dgDisc1";
            this.dgDisc1.ReadOnly = true;
            // 
            // dgUCUPCurr1
            // 
            this.dgUCUPCurr1.HeaderText = "U/C U/P (Curr.)";
            this.dgUCUPCurr1.Name = "dgUCUPCurr1";
            this.dgUCUPCurr1.ReadOnly = true;
            // 
            // dgTotal1
            // 
            this.dgTotal1.HeaderText = "TOTAL";
            this.dgTotal1.Name = "dgTotal1";
            this.dgTotal1.ReadOnly = true;
            // 
            // dgTargetUP1
            // 
            this.dgTargetUP1.HeaderText = "Target U/P";
            this.dgTargetUP1.Name = "dgTargetUP1";
            this.dgTargetUP1.ReadOnly = true;
            // 
            // dgCompetitor1
            // 
            this.dgCompetitor1.HeaderText = "Competitor";
            this.dgCompetitor1.Name = "dgCompetitor1";
            this.dgCompetitor1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "HZ";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "CL";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "CR";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            // 
            // dgDelivery1
            // 
            this.dgDelivery1.HeaderText = "Delivery";
            this.dgDelivery1.Name = "dgDelivery1";
            this.dgDelivery1.ReadOnly = true;
            this.dgDelivery1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDelivery1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgUnitWeigt1
            // 
            this.dgUnitWeigt1.HeaderText = "Unit Weigt (Kg)";
            this.dgUnitWeigt1.Name = "dgUnitWeigt1";
            this.dgUnitWeigt1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "Total Weight (Kg)";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dgCustomerStokCode1
            // 
            this.dgCustomerStokCode1.HeaderText = "Cust Stk Code";
            this.dgCustomerStokCode1.Name = "dgCustomerStokCode1";
            this.dgCustomerStokCode1.ReadOnly = true;
            // 
            // dgCustDescription1
            // 
            this.dgCustDescription1.HeaderText = "Cust. Description";
            this.dgCustDescription1.Name = "dgCustDescription1";
            this.dgCustDescription1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "COO";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "CCCNO";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label65);
            this.panel2.Controls.Add(this.label61);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.btnExQuotation);
            this.panel2.Controls.Add(this.btnImportFromXML);
            this.panel2.Controls.Add(this.btnCustomizeGrid);
            this.panel2.Controls.Add(this.btnProductHistory);
            this.panel2.Controls.Add(this.txtSubtotal);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.btnExcelExport);
            this.panel2.Controls.Add(this.txtTotalMarginGrid);
            this.panel2.Controls.Add(this.txtTotalCost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1631, 56);
            this.panel2.TabIndex = 0;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(1121, 18);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(20, 17);
            this.label65.TabIndex = 13;
            this.label65.Text = "%";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(1189, 18);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 17);
            this.label61.TabIndex = 12;
            this.label61.Text = "Total Cost";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(907, 18);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(87, 17);
            this.label45.TabIndex = 12;
            this.label45.Text = "Total Margin";
            // 
            // btnExQuotation
            // 
            this.btnExQuotation.Location = new System.Drawing.Point(417, 12);
            this.btnExQuotation.Margin = new System.Windows.Forms.Padding(4);
            this.btnExQuotation.Name = "btnExQuotation";
            this.btnExQuotation.Size = new System.Drawing.Size(181, 28);
            this.btnExQuotation.TabIndex = 11;
            this.btnExQuotation.Text = "Take From Ex-Quotation";
            this.btnExQuotation.UseVisualStyleBackColor = true;
            // 
            // btnImportFromXML
            // 
            this.btnImportFromXML.Enabled = false;
            this.btnImportFromXML.Location = new System.Drawing.Point(283, 12);
            this.btnImportFromXML.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportFromXML.Name = "btnImportFromXML";
            this.btnImportFromXML.Size = new System.Drawing.Size(127, 28);
            this.btnImportFromXML.TabIndex = 11;
            this.btnImportFromXML.Text = "Import From Xml";
            this.btnImportFromXML.UseVisualStyleBackColor = true;
            this.btnImportFromXML.Visible = false;
            // 
            // btnCustomizeGrid
            // 
            this.btnCustomizeGrid.Location = new System.Drawing.Point(769, 13);
            this.btnCustomizeGrid.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomizeGrid.Name = "btnCustomizeGrid";
            this.btnCustomizeGrid.Size = new System.Drawing.Size(115, 26);
            this.btnCustomizeGrid.TabIndex = 10;
            this.btnCustomizeGrid.Text = "Customize Grid";
            this.btnCustomizeGrid.UseVisualStyleBackColor = true;
            // 
            // btnProductHistory
            // 
            this.btnProductHistory.Location = new System.Drawing.Point(637, 13);
            this.btnProductHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductHistory.Name = "btnProductHistory";
            this.btnProductHistory.Size = new System.Drawing.Size(124, 26);
            this.btnProductHistory.TabIndex = 10;
            this.btnProductHistory.Text = "Product History";
            this.btnProductHistory.UseVisualStyleBackColor = true;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.AutoSize = true;
            this.txtSubtotal.Location = new System.Drawing.Point(1567, 18);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(36, 17);
            this.txtSubtotal.TabIndex = 8;
            this.txtSubtotal.Text = "0,00";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(11, 12);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(136, 28);
            this.button7.TabIndex = 3;
            this.button7.Text = "Import From Excel";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(1469, 18);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(60, 17);
            this.label35.TabIndex = 7;
            this.label35.Text = "Subtotal";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(155, 12);
            this.btnExcelExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(120, 28);
            this.btnExcelExport.TabIndex = 3;
            this.btnExcelExport.Text = "Export To Excel";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            // 
            // txtTotalMarginGrid
            // 
            this.txtTotalMarginGrid.Location = new System.Drawing.Point(995, 15);
            this.txtTotalMarginGrid.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalMarginGrid.Mask = "99.99";
            this.txtTotalMarginGrid.Name = "txtTotalMarginGrid";
            this.txtTotalMarginGrid.ReadOnly = true;
            this.txtTotalMarginGrid.Size = new System.Drawing.Size(125, 22);
            this.txtTotalMarginGrid.TabIndex = 4;
            this.txtTotalMarginGrid.Text = "0";
            this.txtTotalMarginGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Location = new System.Drawing.Point(1265, 15);
            this.txtTotalCost.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.ReadOnly = true;
            this.txtTotalCost.Size = new System.Drawing.Size(103, 22);
            this.txtTotalCost.TabIndex = 5;
            this.txtTotalCost.Text = "0,00";
            this.txtTotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCustomerDetails);
            this.tabControl1.Controls.Add(this.tabItemDetails);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1651, 218);
            this.tabControl1.TabIndex = 51;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabCustomerDetails
            // 
            this.tabCustomerDetails.Controls.Add(this.txtAccountingNote);
            this.tabCustomerDetails.Controls.Add(this.label9);
            this.tabCustomerDetails.Controls.Add(this.gbCustomer);
            this.tabCustomerDetails.Controls.Add(this.txtContactNote);
            this.tabCustomerDetails.Controls.Add(this.txtCustomerNote);
            this.tabCustomerDetails.Controls.Add(this.label16);
            this.tabCustomerDetails.Controls.Add(this.label15);
            this.tabCustomerDetails.Location = new System.Drawing.Point(4, 25);
            this.tabCustomerDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCustomerDetails.Name = "tabCustomerDetails";
            this.tabCustomerDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCustomerDetails.Size = new System.Drawing.Size(1643, 189);
            this.tabCustomerDetails.TabIndex = 0;
            this.tabCustomerDetails.Text = "Customer Details";
            this.tabCustomerDetails.UseVisualStyleBackColor = true;
            // 
            // txtAccountingNote
            // 
            this.txtAccountingNote.Location = new System.Drawing.Point(1300, 21);
            this.txtAccountingNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountingNote.Multiline = true;
            this.txtAccountingNote.Name = "txtAccountingNote";
            this.txtAccountingNote.ReadOnly = true;
            this.txtAccountingNote.Size = new System.Drawing.Size(337, 54);
            this.txtAccountingNote.TabIndex = 77;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1192, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 37);
            this.label9.TabIndex = 76;
            this.label9.Text = "Accounting Note";
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.lblExcRate);
            this.gbCustomer.Controls.Add(this.dtpDate);
            this.gbCustomer.Controls.Add(this.btnViewMore);
            this.gbCustomer.Controls.Add(this.txtCustomerName);
            this.gbCustomer.Controls.Add(this.txtCustomerCode);
            this.gbCustomer.Controls.Add(this.cbPaymentMethod);
            this.gbCustomer.Controls.Add(this.label21);
            this.gbCustomer.Controls.Add(this.cbRepresentative);
            this.gbCustomer.Controls.Add(this.label6);
            this.gbCustomer.Controls.Add(this.txtRFQNo);
            this.gbCustomer.Controls.Add(this.label3);
            this.gbCustomer.Controls.Add(this.txtFactor);
            this.gbCustomer.Controls.Add(this.txtValidity);
            this.gbCustomer.Controls.Add(this.label5);
            this.gbCustomer.Controls.Add(this.txtQuotationNo);
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Controls.Add(this.label1);
            this.gbCustomer.Controls.Add(this.label30);
            this.gbCustomer.Controls.Add(this.cbCurrency);
            this.gbCustomer.Controls.Add(this.label8);
            this.gbCustomer.Controls.Add(this.btnAddAttention);
            this.gbCustomer.Controls.Add(this.cbWorkers);
            this.gbCustomer.Controls.Add(this.label17);
            this.gbCustomer.Controls.Add(this.label10);
            this.gbCustomer.Location = new System.Drawing.Point(16, 7);
            this.gbCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Padding = new System.Windows.Forms.Padding(4);
            this.gbCustomer.Size = new System.Drawing.Size(748, 161);
            this.gbCustomer.TabIndex = 1;
            this.gbCustomer.TabStop = false;
            // 
            // lblExcRate
            // 
            this.lblExcRate.AutoSize = true;
            this.lblExcRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblExcRate.Location = new System.Drawing.Point(643, 135);
            this.lblExcRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcRate.Name = "lblExcRate";
            this.lblExcRate.Size = new System.Drawing.Size(80, 17);
            this.lblExcRate.TabIndex = 78;
            this.lblExcRate.Text = "CurrValue";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(365, 71);
            this.dtpDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(148, 22);
            this.dtpDate.TabIndex = 77;
            // 
            // btnViewMore
            // 
            this.btnViewMore.Location = new System.Drawing.Point(640, 11);
            this.btnViewMore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewMore.Name = "btnViewMore";
            this.btnViewMore.Size = new System.Drawing.Size(101, 57);
            this.btnViewMore.TabIndex = 76;
            this.btnViewMore.Text = "Details";
            this.btnViewMore.UseVisualStyleBackColor = true;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(248, 11);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(5);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(385, 22);
            this.txtCustomerName.TabIndex = 75;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(88, 12);
            this.txtCustomerCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(115, 22);
            this.txtCustomerCode.TabIndex = 75;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            this.txtCustomerCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCustomerCode_MouseDoubleClick);
            // 
            // cbPaymentMethod
            // 
            this.cbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPaymentMethod.FormattingEnabled = true;
            this.cbPaymentMethod.Location = new System.Drawing.Point(365, 100);
            this.cbPaymentMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbPaymentMethod.Name = "cbPaymentMethod";
            this.cbPaymentMethod.Size = new System.Drawing.Size(268, 24);
            this.cbPaymentMethod.TabIndex = 74;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(291, 100);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 17);
            this.label21.TabIndex = 73;
            this.label21.Text = "Payment";
            // 
            // cbRepresentative
            // 
            this.cbRepresentative.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRepresentative.FormattingEnabled = true;
            this.cbRepresentative.Location = new System.Drawing.Point(88, 130);
            this.cbRepresentative.Margin = new System.Windows.Forms.Padding(4);
            this.cbRepresentative.Name = "cbRepresentative";
            this.cbRepresentative.Size = new System.Drawing.Size(183, 24);
            this.cbRepresentative.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Rep.";
            // 
            // txtRFQNo
            // 
            this.txtRFQNo.Location = new System.Drawing.Point(88, 102);
            this.txtRFQNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRFQNo.Name = "txtRFQNo";
            this.txtRFQNo.Size = new System.Drawing.Size(183, 22);
            this.txtRFQNo.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 68;
            this.label3.Text = "RFQ No";
            // 
            // txtFactor
            // 
            this.txtFactor.Location = new System.Drawing.Point(579, 132);
            this.txtFactor.Margin = new System.Windows.Forms.Padding(4);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(55, 22);
            this.txtFactor.TabIndex = 67;
            this.txtFactor.Text = "1";
            // 
            // txtValidity
            // 
            this.txtValidity.Location = new System.Drawing.Point(579, 73);
            this.txtValidity.Margin = new System.Windows.Forms.Padding(4);
            this.txtValidity.Name = "txtValidity";
            this.txtValidity.Size = new System.Drawing.Size(55, 22);
            this.txtValidity.TabIndex = 67;
            this.txtValidity.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(523, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 66;
            this.label5.Text = "Validity";
            // 
            // txtQuotationNo
            // 
            this.txtQuotationNo.Location = new System.Drawing.Point(88, 74);
            this.txtQuotationNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuotationNo.Name = "txtQuotationNo";
            this.txtQuotationNo.ReadOnly = true;
            this.txtQuotationNo.Size = new System.Drawing.Size(115, 22);
            this.txtQuotationNo.TabIndex = 64;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 63;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 62;
            this.label1.Text = "Quote No";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(521, 132);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 17);
            this.label30.TabIndex = 60;
            this.label30.Text = "Factor";
            // 
            // cbCurrency
            // 
            this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrency.FormattingEnabled = true;
            this.cbCurrency.Location = new System.Drawing.Point(365, 132);
            this.cbCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(147, 24);
            this.cbCurrency.TabIndex = 58;
            this.cbCurrency.SelectedIndexChanged += new System.EventHandler(this.cbCurrency_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 132);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 57;
            this.label8.Text = "Curr";
            // 
            // btnAddAttention
            // 
            this.btnAddAttention.Location = new System.Drawing.Point(88, 39);
            this.btnAddAttention.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddAttention.Name = "btnAddAttention";
            this.btnAddAttention.Size = new System.Drawing.Size(115, 28);
            this.btnAddAttention.TabIndex = 15;
            this.btnAddAttention.Text = "Add Attention";
            this.btnAddAttention.UseVisualStyleBackColor = true;
            // 
            // cbWorkers
            // 
            this.cbWorkers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWorkers.FormattingEnabled = true;
            this.cbWorkers.Location = new System.Drawing.Point(248, 42);
            this.cbWorkers.Margin = new System.Windows.Forms.Padding(4);
            this.cbWorkers.Name = "cbWorkers";
            this.cbWorkers.Size = new System.Drawing.Size(385, 24);
            this.cbWorkers.TabIndex = 17;
            this.cbWorkers.SelectedValueChanged += new System.EventHandler(this.cbWorkers_SelectedValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 39);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 17);
            this.label17.TabIndex = 10;
            this.label17.Text = "Attention";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Customer";
            // 
            // txtContactNote
            // 
            this.txtContactNote.Location = new System.Drawing.Point(847, 119);
            this.txtContactNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactNote.Multiline = true;
            this.txtContactNote.Name = "txtContactNote";
            this.txtContactNote.ReadOnly = true;
            this.txtContactNote.Size = new System.Drawing.Size(337, 54);
            this.txtContactNote.TabIndex = 75;
            // 
            // txtCustomerNote
            // 
            this.txtCustomerNote.Location = new System.Drawing.Point(847, 22);
            this.txtCustomerNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtCustomerNote.Multiline = true;
            this.txtCustomerNote.Name = "txtCustomerNote";
            this.txtCustomerNote.ReadOnly = true;
            this.txtCustomerNote.Size = new System.Drawing.Size(337, 54);
            this.txtCustomerNote.TabIndex = 75;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(771, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 37);
            this.label16.TabIndex = 45;
            this.label16.Text = "Contact Note";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(771, 27);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 37);
            this.label15.TabIndex = 45;
            this.label15.Text = "Customer Note";
            // 
            // tabItemDetails
            // 
            this.tabItemDetails.Controls.Add(this.gbCost);
            this.tabItemDetails.Controls.Add(this.txtSection);
            this.tabItemDetails.Controls.Add(this.txtSupersectionName);
            this.tabItemDetails.Controls.Add(this.txtCofO);
            this.tabItemDetails.Controls.Add(this.txtItemNote);
            this.tabItemDetails.Controls.Add(this.txtManufacturer);
            this.tabItemDetails.Controls.Add(this.txtCCCN);
            this.tabItemDetails.Controls.Add(this.txtBrand);
            this.tabItemDetails.Controls.Add(this.txtMHCodeLevel1);
            this.tabItemDetails.Controls.Add(this.txtIME04);
            this.tabItemDetails.Controls.Add(this.txtIME03);
            this.tabItemDetails.Controls.Add(this.txtIME02);
            this.tabItemDetails.Controls.Add(this.txtIME01);
            this.tabItemDetails.Controls.Add(this.txtOnOrder);
            this.tabItemDetails.Controls.Add(this.txtExpiringPro);
            this.tabItemDetails.Controls.Add(this.txtHazardousInd);
            this.tabItemDetails.Controls.Add(this.txtDiscChange);
            this.tabItemDetails.Controls.Add(this.txtEnvironment);
            this.tabItemDetails.Controls.Add(this.txtLithium);
            this.tabItemDetails.Controls.Add(this.txtShipping);
            this.tabItemDetails.Controls.Add(this.txtLicenceType);
            this.tabItemDetails.Controls.Add(this.txtCalibrationInd);
            this.tabItemDetails.Controls.Add(this.txtGB01_b);
            this.tabItemDetails.Controls.Add(this.txtOnOrder_b);
            this.tabItemDetails.Controls.Add(this.txtGB01_a);
            this.tabItemDetails.Controls.Add(this.txtOnOrder_a);
            this.tabItemDetails.Controls.Add(this.txtDiscontinuationDate);
            this.tabItemDetails.Controls.Add(this.txtUKDiscDate);
            this.tabItemDetails.Controls.Add(this.txtSubstitutedBy);
            this.tabItemDetails.Controls.Add(this.txtRunOn);
            this.tabItemDetails.Controls.Add(this.txtPP);
            this.tabItemDetails.Controls.Add(this.txtReferral);
            this.tabItemDetails.Controls.Add(this.txtStandardWeight);
            this.tabItemDetails.Controls.Add(this.txtHeight);
            this.tabItemDetails.Controls.Add(this.txtWidth);
            this.tabItemDetails.Controls.Add(this.txtGrossWeight);
            this.tabItemDetails.Controls.Add(this.txtLength);
            this.tabItemDetails.Controls.Add(this.label51);
            this.tabItemDetails.Controls.Add(this.label24);
            this.tabItemDetails.Controls.Add(this.label11);
            this.tabItemDetails.Controls.Add(this.label12);
            this.tabItemDetails.Controls.Add(this.label37);
            this.tabItemDetails.Controls.Add(this.label13);
            this.tabItemDetails.Controls.Add(this.label20);
            this.tabItemDetails.Controls.Add(this.label33);
            this.tabItemDetails.Controls.Add(this.label14);
            this.tabItemDetails.Controls.Add(this.label23);
            this.tabItemDetails.Controls.Add(this.label41);
            this.tabItemDetails.Controls.Add(this.label18);
            this.tabItemDetails.Controls.Add(this.label19);
            this.tabItemDetails.Controls.Add(this.label53);
            this.tabItemDetails.Controls.Add(this.label64);
            this.tabItemDetails.Controls.Add(this.label63);
            this.tabItemDetails.Controls.Add(this.label22);
            this.tabItemDetails.Controls.Add(this.label28);
            this.tabItemDetails.Controls.Add(this.label55);
            this.tabItemDetails.Controls.Add(this.label25);
            this.tabItemDetails.Controls.Add(this.label26);
            this.tabItemDetails.Controls.Add(this.label59);
            this.tabItemDetails.Controls.Add(this.label56);
            this.tabItemDetails.Controls.Add(this.label27);
            this.tabItemDetails.Controls.Add(this.label60);
            this.tabItemDetails.Controls.Add(this.label54);
            this.tabItemDetails.Controls.Add(this.label66);
            this.tabItemDetails.Controls.Add(this.label58);
            this.tabItemDetails.Controls.Add(this.label62);
            this.tabItemDetails.Controls.Add(this.label29);
            this.tabItemDetails.Controls.Add(this.label31);
            this.tabItemDetails.Controls.Add(this.label32);
            this.tabItemDetails.Controls.Add(this.label38);
            this.tabItemDetails.Controls.Add(this.label43);
            this.tabItemDetails.Controls.Add(this.label44);
            this.tabItemDetails.Controls.Add(this.label46);
            this.tabItemDetails.Controls.Add(this.label47);
            this.tabItemDetails.Controls.Add(this.label48);
            this.tabItemDetails.Controls.Add(this.label49);
            this.tabItemDetails.Location = new System.Drawing.Point(4, 25);
            this.tabItemDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabItemDetails.Name = "tabItemDetails";
            this.tabItemDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabItemDetails.Size = new System.Drawing.Size(1643, 189);
            this.tabItemDetails.TabIndex = 1;
            this.tabItemDetails.Text = "Item Details";
            this.tabItemDetails.UseVisualStyleBackColor = true;
            // 
            // gbCost
            // 
            this.gbCost.Controls.Add(this.txtCost1);
            this.gbCost.Controls.Add(this.txtMargin5);
            this.gbCost.Controls.Add(this.txtUK5);
            this.gbCost.Controls.Add(this.txtUK2);
            this.gbCost.Controls.Add(this.txtCost5);
            this.gbCost.Controls.Add(this.txtMargin1);
            this.gbCost.Controls.Add(this.txtMargin2);
            this.gbCost.Controls.Add(this.txtUK3);
            this.gbCost.Controls.Add(this.txtUK1);
            this.gbCost.Controls.Add(this.txtCost3);
            this.gbCost.Controls.Add(this.txtMargin4);
            this.gbCost.Controls.Add(this.txtCost4);
            this.gbCost.Controls.Add(this.txtCost2);
            this.gbCost.Controls.Add(this.txtMargin3);
            this.gbCost.Controls.Add(this.txtUK4);
            this.gbCost.Controls.Add(this.lblMargin);
            this.gbCost.Controls.Add(this.txtWeb5);
            this.gbCost.Controls.Add(this.txtWeb2);
            this.gbCost.Controls.Add(this.txtWeb3);
            this.gbCost.Controls.Add(this.txtWeb1);
            this.gbCost.Controls.Add(this.txtWeb4);
            this.gbCost.Controls.Add(this.txtCol5Break);
            this.gbCost.Controls.Add(this.txtCol2Break);
            this.gbCost.Controls.Add(this.txtCol1Break);
            this.gbCost.Controls.Add(this.txtCol4Break);
            this.gbCost.Controls.Add(this.txtCol3Break);
            this.gbCost.Controls.Add(this.label36);
            this.gbCost.Controls.Add(this.label50);
            this.gbCost.Controls.Add(this.lblWeb);
            this.gbCost.Controls.Add(this.label57);
            this.gbCost.Location = new System.Drawing.Point(1253, -2);
            this.gbCost.Margin = new System.Windows.Forms.Padding(4);
            this.gbCost.Name = "gbCost";
            this.gbCost.Padding = new System.Windows.Forms.Padding(4);
            this.gbCost.Size = new System.Drawing.Size(391, 212);
            this.gbCost.TabIndex = 510;
            this.gbCost.TabStop = false;
            // 
            // txtCost1
            // 
            this.txtCost1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost1.Location = new System.Drawing.Point(246, 31);
            this.txtCost1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost1.Name = "txtCost1";
            this.txtCost1.ReadOnly = true;
            this.txtCost1.Size = new System.Drawing.Size(79, 23);
            this.txtCost1.TabIndex = 427;
            // 
            // txtMargin5
            // 
            this.txtMargin5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin5.Location = new System.Drawing.Point(333, 156);
            this.txtMargin5.Margin = new System.Windows.Forms.Padding(4);
            this.txtMargin5.Name = "txtMargin5";
            this.txtMargin5.ReadOnly = true;
            this.txtMargin5.Size = new System.Drawing.Size(41, 23);
            this.txtMargin5.TabIndex = 415;
            // 
            // txtUK5
            // 
            this.txtUK5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK5.Location = new System.Drawing.Point(158, 156);
            this.txtUK5.Margin = new System.Windows.Forms.Padding(4);
            this.txtUK5.Name = "txtUK5";
            this.txtUK5.ReadOnly = true;
            this.txtUK5.Size = new System.Drawing.Size(79, 23);
            this.txtUK5.TabIndex = 416;
            // 
            // txtUK2
            // 
            this.txtUK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK2.Location = new System.Drawing.Point(158, 62);
            this.txtUK2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUK2.Name = "txtUK2";
            this.txtUK2.ReadOnly = true;
            this.txtUK2.Size = new System.Drawing.Size(79, 23);
            this.txtUK2.TabIndex = 426;
            // 
            // txtCost5
            // 
            this.txtCost5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost5.Location = new System.Drawing.Point(246, 156);
            this.txtCost5.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost5.Name = "txtCost5";
            this.txtCost5.ReadOnly = true;
            this.txtCost5.Size = new System.Drawing.Size(79, 23);
            this.txtCost5.TabIndex = 417;
            // 
            // txtMargin1
            // 
            this.txtMargin1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin1.Location = new System.Drawing.Point(333, 31);
            this.txtMargin1.Margin = new System.Windows.Forms.Padding(4);
            this.txtMargin1.Name = "txtMargin1";
            this.txtMargin1.ReadOnly = true;
            this.txtMargin1.Size = new System.Drawing.Size(41, 23);
            this.txtMargin1.TabIndex = 421;
            // 
            // txtMargin2
            // 
            this.txtMargin2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin2.Location = new System.Drawing.Point(333, 62);
            this.txtMargin2.Margin = new System.Windows.Forms.Padding(4);
            this.txtMargin2.Name = "txtMargin2";
            this.txtMargin2.ReadOnly = true;
            this.txtMargin2.Size = new System.Drawing.Size(41, 23);
            this.txtMargin2.TabIndex = 421;
            // 
            // txtUK3
            // 
            this.txtUK3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK3.Location = new System.Drawing.Point(158, 94);
            this.txtUK3.Margin = new System.Windows.Forms.Padding(4);
            this.txtUK3.Name = "txtUK3";
            this.txtUK3.ReadOnly = true;
            this.txtUK3.Size = new System.Drawing.Size(79, 23);
            this.txtUK3.TabIndex = 425;
            // 
            // txtUK1
            // 
            this.txtUK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK1.Location = new System.Drawing.Point(158, 31);
            this.txtUK1.Margin = new System.Windows.Forms.Padding(4);
            this.txtUK1.Name = "txtUK1";
            this.txtUK1.ReadOnly = true;
            this.txtUK1.Size = new System.Drawing.Size(79, 23);
            this.txtUK1.TabIndex = 429;
            // 
            // txtCost3
            // 
            this.txtCost3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost3.Location = new System.Drawing.Point(246, 94);
            this.txtCost3.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost3.Name = "txtCost3";
            this.txtCost3.ReadOnly = true;
            this.txtCost3.Size = new System.Drawing.Size(79, 23);
            this.txtCost3.TabIndex = 423;
            // 
            // txtMargin4
            // 
            this.txtMargin4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin4.Location = new System.Drawing.Point(333, 126);
            this.txtMargin4.Margin = new System.Windows.Forms.Padding(4);
            this.txtMargin4.Name = "txtMargin4";
            this.txtMargin4.ReadOnly = true;
            this.txtMargin4.Size = new System.Drawing.Size(41, 23);
            this.txtMargin4.TabIndex = 422;
            // 
            // txtCost4
            // 
            this.txtCost4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost4.Location = new System.Drawing.Point(246, 126);
            this.txtCost4.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost4.Name = "txtCost4";
            this.txtCost4.ReadOnly = true;
            this.txtCost4.Size = new System.Drawing.Size(79, 23);
            this.txtCost4.TabIndex = 428;
            // 
            // txtCost2
            // 
            this.txtCost2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCost2.Location = new System.Drawing.Point(246, 62);
            this.txtCost2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCost2.Name = "txtCost2";
            this.txtCost2.ReadOnly = true;
            this.txtCost2.Size = new System.Drawing.Size(79, 23);
            this.txtCost2.TabIndex = 430;
            // 
            // txtMargin3
            // 
            this.txtMargin3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMargin3.Location = new System.Drawing.Point(333, 94);
            this.txtMargin3.Margin = new System.Windows.Forms.Padding(4);
            this.txtMargin3.Name = "txtMargin3";
            this.txtMargin3.ReadOnly = true;
            this.txtMargin3.Size = new System.Drawing.Size(41, 23);
            this.txtMargin3.TabIndex = 420;
            // 
            // txtUK4
            // 
            this.txtUK4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUK4.Location = new System.Drawing.Point(158, 126);
            this.txtUK4.Margin = new System.Windows.Forms.Padding(4);
            this.txtUK4.Name = "txtUK4";
            this.txtUK4.ReadOnly = true;
            this.txtUK4.Size = new System.Drawing.Size(79, 23);
            this.txtUK4.TabIndex = 424;
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.Location = new System.Drawing.Point(328, 9);
            this.lblMargin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(51, 17);
            this.lblMargin.TabIndex = 437;
            this.lblMargin.Text = "Margin";
            // 
            // txtWeb5
            // 
            this.txtWeb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb5.Location = new System.Drawing.Point(71, 156);
            this.txtWeb5.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb5.Name = "txtWeb5";
            this.txtWeb5.ReadOnly = true;
            this.txtWeb5.Size = new System.Drawing.Size(79, 23);
            this.txtWeb5.TabIndex = 431;
            // 
            // txtWeb2
            // 
            this.txtWeb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb2.Location = new System.Drawing.Point(71, 62);
            this.txtWeb2.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb2.Name = "txtWeb2";
            this.txtWeb2.ReadOnly = true;
            this.txtWeb2.Size = new System.Drawing.Size(79, 23);
            this.txtWeb2.TabIndex = 435;
            // 
            // txtWeb3
            // 
            this.txtWeb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb3.Location = new System.Drawing.Point(71, 94);
            this.txtWeb3.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb3.Name = "txtWeb3";
            this.txtWeb3.ReadOnly = true;
            this.txtWeb3.Size = new System.Drawing.Size(79, 23);
            this.txtWeb3.TabIndex = 434;
            // 
            // txtWeb1
            // 
            this.txtWeb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb1.Location = new System.Drawing.Point(71, 31);
            this.txtWeb1.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb1.Name = "txtWeb1";
            this.txtWeb1.ReadOnly = true;
            this.txtWeb1.Size = new System.Drawing.Size(79, 23);
            this.txtWeb1.TabIndex = 436;
            // 
            // txtWeb4
            // 
            this.txtWeb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWeb4.Location = new System.Drawing.Point(71, 126);
            this.txtWeb4.Margin = new System.Windows.Forms.Padding(4);
            this.txtWeb4.Name = "txtWeb4";
            this.txtWeb4.ReadOnly = true;
            this.txtWeb4.Size = new System.Drawing.Size(79, 23);
            this.txtWeb4.TabIndex = 433;
            // 
            // txtCol5Break
            // 
            this.txtCol5Break.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol5Break.Location = new System.Drawing.Point(6, 156);
            this.txtCol5Break.Margin = new System.Windows.Forms.Padding(4);
            this.txtCol5Break.Name = "txtCol5Break";
            this.txtCol5Break.ReadOnly = true;
            this.txtCol5Break.Size = new System.Drawing.Size(57, 23);
            this.txtCol5Break.TabIndex = 409;
            // 
            // txtCol2Break
            // 
            this.txtCol2Break.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol2Break.Location = new System.Drawing.Point(6, 62);
            this.txtCol2Break.Margin = new System.Windows.Forms.Padding(4);
            this.txtCol2Break.Name = "txtCol2Break";
            this.txtCol2Break.ReadOnly = true;
            this.txtCol2Break.Size = new System.Drawing.Size(57, 23);
            this.txtCol2Break.TabIndex = 411;
            // 
            // txtCol1Break
            // 
            this.txtCol1Break.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol1Break.Location = new System.Drawing.Point(6, 31);
            this.txtCol1Break.Margin = new System.Windows.Forms.Padding(4);
            this.txtCol1Break.Name = "txtCol1Break";
            this.txtCol1Break.ReadOnly = true;
            this.txtCol1Break.Size = new System.Drawing.Size(57, 23);
            this.txtCol1Break.TabIndex = 413;
            // 
            // txtCol4Break
            // 
            this.txtCol4Break.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol4Break.Location = new System.Drawing.Point(6, 126);
            this.txtCol4Break.Margin = new System.Windows.Forms.Padding(4);
            this.txtCol4Break.Name = "txtCol4Break";
            this.txtCol4Break.ReadOnly = true;
            this.txtCol4Break.Size = new System.Drawing.Size(57, 23);
            this.txtCol4Break.TabIndex = 412;
            // 
            // txtCol3Break
            // 
            this.txtCol3Break.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol3Break.Location = new System.Drawing.Point(6, 94);
            this.txtCol3Break.Margin = new System.Windows.Forms.Padding(4);
            this.txtCol3Break.Name = "txtCol3Break";
            this.txtCol3Break.ReadOnly = true;
            this.txtCol3Break.Size = new System.Drawing.Size(57, 23);
            this.txtCol3Break.TabIndex = 410;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(256, 10);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(58, 17);
            this.label36.TabIndex = 418;
            this.label36.Text = "Cost (£)";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(173, 10);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(49, 17);
            this.label50.TabIndex = 419;
            this.label50.Text = "UK (£)";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWeb
            // 
            this.lblWeb.AutoSize = true;
            this.lblWeb.Location = new System.Drawing.Point(81, 11);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(59, 17);
            this.lblWeb.TabIndex = 432;
            this.lblWeb.Text = "Web (£)";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label57.Location = new System.Drawing.Point(7, 11);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(54, 17);
            this.label57.TabIndex = 414;
            this.label57.Text = "Col Qty";
            this.label57.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSection
            // 
            this.txtSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSection.Location = new System.Drawing.Point(91, 94);
            this.txtSection.Margin = new System.Windows.Forms.Padding(4);
            this.txtSection.Name = "txtSection";
            this.txtSection.ReadOnly = true;
            this.txtSection.Size = new System.Drawing.Size(227, 23);
            this.txtSection.TabIndex = 508;
            // 
            // txtSupersectionName
            // 
            this.txtSupersectionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSupersectionName.Location = new System.Drawing.Point(91, 64);
            this.txtSupersectionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSupersectionName.Name = "txtSupersectionName";
            this.txtSupersectionName.ReadOnly = true;
            this.txtSupersectionName.Size = new System.Drawing.Size(227, 23);
            this.txtSupersectionName.TabIndex = 509;
            // 
            // txtCofO
            // 
            this.txtCofO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCofO.Location = new System.Drawing.Point(91, 157);
            this.txtCofO.Margin = new System.Windows.Forms.Padding(4);
            this.txtCofO.Name = "txtCofO";
            this.txtCofO.ReadOnly = true;
            this.txtCofO.Size = new System.Drawing.Size(47, 23);
            this.txtCofO.TabIndex = 503;
            // 
            // txtItemNote
            // 
            this.txtItemNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtItemNote.Location = new System.Drawing.Point(433, 5);
            this.txtItemNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemNote.Name = "txtItemNote";
            this.txtItemNote.ReadOnly = true;
            this.txtItemNote.Size = new System.Drawing.Size(411, 23);
            this.txtItemNote.TabIndex = 504;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtManufacturer.Location = new System.Drawing.Point(91, 5);
            this.txtManufacturer.Margin = new System.Windows.Forms.Padding(4);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.ReadOnly = true;
            this.txtManufacturer.Size = new System.Drawing.Size(227, 23);
            this.txtManufacturer.TabIndex = 504;
            // 
            // txtCCCN
            // 
            this.txtCCCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCCCN.Location = new System.Drawing.Point(200, 157);
            this.txtCCCN.Margin = new System.Windows.Forms.Padding(4);
            this.txtCCCN.Name = "txtCCCN";
            this.txtCCCN.ReadOnly = true;
            this.txtCCCN.Size = new System.Drawing.Size(117, 23);
            this.txtCCCN.TabIndex = 501;
            // 
            // txtBrand
            // 
            this.txtBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBrand.Location = new System.Drawing.Point(91, 34);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(4);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.ReadOnly = true;
            this.txtBrand.Size = new System.Drawing.Size(227, 23);
            this.txtBrand.TabIndex = 505;
            // 
            // txtMHCodeLevel1
            // 
            this.txtMHCodeLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMHCodeLevel1.Location = new System.Drawing.Point(91, 126);
            this.txtMHCodeLevel1.Margin = new System.Windows.Forms.Padding(4);
            this.txtMHCodeLevel1.Name = "txtMHCodeLevel1";
            this.txtMHCodeLevel1.ReadOnly = true;
            this.txtMHCodeLevel1.Size = new System.Drawing.Size(227, 23);
            this.txtMHCodeLevel1.TabIndex = 502;
            // 
            // txtIME04
            // 
            this.txtIME04.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIME04.Location = new System.Drawing.Point(433, 126);
            this.txtIME04.Margin = new System.Windows.Forms.Padding(4);
            this.txtIME04.Name = "txtIME04";
            this.txtIME04.ReadOnly = true;
            this.txtIME04.Size = new System.Drawing.Size(84, 23);
            this.txtIME04.TabIndex = 494;
            // 
            // txtIME03
            // 
            this.txtIME03.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIME03.Location = new System.Drawing.Point(433, 94);
            this.txtIME03.Margin = new System.Windows.Forms.Padding(4);
            this.txtIME03.Name = "txtIME03";
            this.txtIME03.ReadOnly = true;
            this.txtIME03.Size = new System.Drawing.Size(84, 23);
            this.txtIME03.TabIndex = 495;
            // 
            // txtIME02
            // 
            this.txtIME02.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIME02.Location = new System.Drawing.Point(433, 64);
            this.txtIME02.Margin = new System.Windows.Forms.Padding(4);
            this.txtIME02.Name = "txtIME02";
            this.txtIME02.ReadOnly = true;
            this.txtIME02.Size = new System.Drawing.Size(84, 23);
            this.txtIME02.TabIndex = 489;
            // 
            // txtIME01
            // 
            this.txtIME01.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtIME01.Location = new System.Drawing.Point(433, 34);
            this.txtIME01.Margin = new System.Windows.Forms.Padding(4);
            this.txtIME01.Name = "txtIME01";
            this.txtIME01.ReadOnly = true;
            this.txtIME01.Size = new System.Drawing.Size(84, 23);
            this.txtIME01.TabIndex = 490;
            // 
            // txtOnOrder
            // 
            this.txtOnOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOnOrder.Location = new System.Drawing.Point(433, 157);
            this.txtOnOrder.Margin = new System.Windows.Forms.Padding(4);
            this.txtOnOrder.Name = "txtOnOrder";
            this.txtOnOrder.ReadOnly = true;
            this.txtOnOrder.Size = new System.Drawing.Size(84, 23);
            this.txtOnOrder.TabIndex = 491;
            // 
            // txtExpiringPro
            // 
            this.txtExpiringPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtExpiringPro.Location = new System.Drawing.Point(802, 146);
            this.txtExpiringPro.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpiringPro.Name = "txtExpiringPro";
            this.txtExpiringPro.ReadOnly = true;
            this.txtExpiringPro.Size = new System.Drawing.Size(27, 23);
            this.txtExpiringPro.TabIndex = 484;
            this.toolTip1.SetToolTip(this.txtExpiringPro, "Expiring Pro");
            // 
            // txtHazardousInd
            // 
            this.txtHazardousInd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHazardousInd.Location = new System.Drawing.Point(593, 102);
            this.txtHazardousInd.Margin = new System.Windows.Forms.Padding(4);
            this.txtHazardousInd.Name = "txtHazardousInd";
            this.txtHazardousInd.ReadOnly = true;
            this.txtHazardousInd.Size = new System.Drawing.Size(27, 23);
            this.txtHazardousInd.TabIndex = 475;
            // 
            // txtDiscChange
            // 
            this.txtDiscChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDiscChange.Location = new System.Drawing.Point(730, 146);
            this.txtDiscChange.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscChange.Name = "txtDiscChange";
            this.txtDiscChange.ReadOnly = true;
            this.txtDiscChange.Size = new System.Drawing.Size(27, 23);
            this.txtDiscChange.TabIndex = 485;
            // 
            // txtEnvironment
            // 
            this.txtEnvironment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtEnvironment.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtEnvironment.Location = new System.Drawing.Point(661, 102);
            this.txtEnvironment.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnvironment.Name = "txtEnvironment";
            this.txtEnvironment.ReadOnly = true;
            this.txtEnvironment.Size = new System.Drawing.Size(27, 23);
            this.txtEnvironment.TabIndex = 481;
            // 
            // txtLithium
            // 
            this.txtLithium.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLithium.Location = new System.Drawing.Point(802, 102);
            this.txtLithium.Margin = new System.Windows.Forms.Padding(4);
            this.txtLithium.Name = "txtLithium";
            this.txtLithium.ReadOnly = true;
            this.txtLithium.Size = new System.Drawing.Size(27, 23);
            this.txtLithium.TabIndex = 477;
            // 
            // txtShipping
            // 
            this.txtShipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtShipping.Location = new System.Drawing.Point(730, 102);
            this.txtShipping.Margin = new System.Windows.Forms.Padding(4);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.ReadOnly = true;
            this.txtShipping.Size = new System.Drawing.Size(27, 23);
            this.txtShipping.TabIndex = 476;
            // 
            // txtLicenceType
            // 
            this.txtLicenceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLicenceType.Location = new System.Drawing.Point(661, 146);
            this.txtLicenceType.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicenceType.Name = "txtLicenceType";
            this.txtLicenceType.ReadOnly = true;
            this.txtLicenceType.Size = new System.Drawing.Size(27, 23);
            this.txtLicenceType.TabIndex = 479;
            // 
            // txtCalibrationInd
            // 
            this.txtCalibrationInd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCalibrationInd.Location = new System.Drawing.Point(593, 146);
            this.txtCalibrationInd.Margin = new System.Windows.Forms.Padding(4);
            this.txtCalibrationInd.Name = "txtCalibrationInd";
            this.txtCalibrationInd.ReadOnly = true;
            this.txtCalibrationInd.Size = new System.Drawing.Size(27, 23);
            this.txtCalibrationInd.TabIndex = 472;
            // 
            // txtGB01_b
            // 
            this.txtGB01_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGB01_b.Location = new System.Drawing.Point(700, 34);
            this.txtGB01_b.Margin = new System.Windows.Forms.Padding(4);
            this.txtGB01_b.Name = "txtGB01_b";
            this.txtGB01_b.ReadOnly = true;
            this.txtGB01_b.Size = new System.Drawing.Size(87, 23);
            this.txtGB01_b.TabIndex = 469;
            // 
            // txtOnOrder_b
            // 
            this.txtOnOrder_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOnOrder_b.Location = new System.Drawing.Point(703, 64);
            this.txtOnOrder_b.Margin = new System.Windows.Forms.Padding(4);
            this.txtOnOrder_b.Name = "txtOnOrder_b";
            this.txtOnOrder_b.ReadOnly = true;
            this.txtOnOrder_b.Size = new System.Drawing.Size(84, 23);
            this.txtOnOrder_b.TabIndex = 468;
            // 
            // txtGB01_a
            // 
            this.txtGB01_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGB01_a.Location = new System.Drawing.Point(608, 34);
            this.txtGB01_a.Margin = new System.Windows.Forms.Padding(4);
            this.txtGB01_a.Name = "txtGB01_a";
            this.txtGB01_a.ReadOnly = true;
            this.txtGB01_a.Size = new System.Drawing.Size(84, 23);
            this.txtGB01_a.TabIndex = 466;
            // 
            // txtOnOrder_a
            // 
            this.txtOnOrder_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOnOrder_a.Location = new System.Drawing.Point(608, 64);
            this.txtOnOrder_a.Margin = new System.Windows.Forms.Padding(4);
            this.txtOnOrder_a.Name = "txtOnOrder_a";
            this.txtOnOrder_a.ReadOnly = true;
            this.txtOnOrder_a.Size = new System.Drawing.Size(87, 23);
            this.txtOnOrder_a.TabIndex = 467;
            // 
            // txtDiscontinuationDate
            // 
            this.txtDiscontinuationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDiscontinuationDate.Location = new System.Drawing.Point(944, 34);
            this.txtDiscontinuationDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscontinuationDate.Name = "txtDiscontinuationDate";
            this.txtDiscontinuationDate.ReadOnly = true;
            this.txtDiscontinuationDate.Size = new System.Drawing.Size(96, 23);
            this.txtDiscontinuationDate.TabIndex = 463;
            // 
            // txtUKDiscDate
            // 
            this.txtUKDiscDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUKDiscDate.Location = new System.Drawing.Point(944, 5);
            this.txtUKDiscDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtUKDiscDate.Name = "txtUKDiscDate";
            this.txtUKDiscDate.ReadOnly = true;
            this.txtUKDiscDate.Size = new System.Drawing.Size(96, 23);
            this.txtUKDiscDate.TabIndex = 461;
            this.txtUKDiscDate.Text = "27/19/2017";
            // 
            // txtSubstitutedBy
            // 
            this.txtSubstitutedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSubstitutedBy.Location = new System.Drawing.Point(944, 64);
            this.txtSubstitutedBy.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubstitutedBy.Name = "txtSubstitutedBy";
            this.txtSubstitutedBy.ReadOnly = true;
            this.txtSubstitutedBy.Size = new System.Drawing.Size(96, 23);
            this.txtSubstitutedBy.TabIndex = 457;
            // 
            // txtRunOn
            // 
            this.txtRunOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRunOn.Location = new System.Drawing.Point(944, 94);
            this.txtRunOn.Margin = new System.Windows.Forms.Padding(4);
            this.txtRunOn.Name = "txtRunOn";
            this.txtRunOn.ReadOnly = true;
            this.txtRunOn.Size = new System.Drawing.Size(96, 23);
            this.txtRunOn.TabIndex = 456;
            // 
            // txtPP
            // 
            this.txtPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPP.Location = new System.Drawing.Point(944, 157);
            this.txtPP.Margin = new System.Windows.Forms.Padding(4);
            this.txtPP.Name = "txtPP";
            this.txtPP.ReadOnly = true;
            this.txtPP.Size = new System.Drawing.Size(96, 23);
            this.txtPP.TabIndex = 458;
            // 
            // txtReferral
            // 
            this.txtReferral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReferral.Location = new System.Drawing.Point(944, 126);
            this.txtReferral.Margin = new System.Windows.Forms.Padding(4);
            this.txtReferral.Name = "txtReferral";
            this.txtReferral.ReadOnly = true;
            this.txtReferral.Size = new System.Drawing.Size(96, 23);
            this.txtReferral.TabIndex = 459;
            // 
            // txtStandardWeight
            // 
            this.txtStandardWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtStandardWeight.Location = new System.Drawing.Point(1122, 126);
            this.txtStandardWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtStandardWeight.Name = "txtStandardWeight";
            this.txtStandardWeight.ReadOnly = true;
            this.txtStandardWeight.Size = new System.Drawing.Size(79, 23);
            this.txtStandardWeight.TabIndex = 441;
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHeight.Location = new System.Drawing.Point(1122, 31);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ReadOnly = true;
            this.txtHeight.Size = new System.Drawing.Size(79, 23);
            this.txtHeight.TabIndex = 443;
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWidth.Location = new System.Drawing.Point(1122, 63);
            this.txtWidth.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ReadOnly = true;
            this.txtWidth.Size = new System.Drawing.Size(79, 23);
            this.txtWidth.TabIndex = 442;
            // 
            // txtGrossWeight
            // 
            this.txtGrossWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGrossWeight.Location = new System.Drawing.Point(1122, 156);
            this.txtGrossWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtGrossWeight.Name = "txtGrossWeight";
            this.txtGrossWeight.ReadOnly = true;
            this.txtGrossWeight.Size = new System.Drawing.Size(79, 23);
            this.txtGrossWeight.TabIndex = 446;
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLength.Location = new System.Drawing.Point(1122, 94);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtLength.Name = "txtLength";
            this.txtLength.ReadOnly = true;
            this.txtLength.Size = new System.Drawing.Size(79, 23);
            this.txtLength.TabIndex = 444;
            // 
            // label51
            // 
            this.label51.AutoEllipsis = true;
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(21, 67);
            this.label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(68, 17);
            this.label51.TabIndex = 506;
            this.label51.Text = "S Section";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label51, "Super Section");
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 8);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 17);
            this.label24.TabIndex = 497;
            this.label24.Text = "Mfr";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label24, "Manufacturer");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 160);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 496;
            this.label11.Text = "CCCN";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label11, "CCCN");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 129);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 499;
            this.label12.Text = "MH";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label12, "Category");
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(21, 37);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(46, 17);
            this.label37.TabIndex = 498;
            this.label37.Text = "Brand";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 507;
            this.label13.Text = "Section";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(21, 160);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 17);
            this.label20.TabIndex = 500;
            this.label20.Text = "CoO";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label20, "Country Of Origin");
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label33.Location = new System.Drawing.Point(351, 129);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(51, 17);
            this.label33.TabIndex = 492;
            this.label33.Text = "IME 04";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label14.Location = new System.Drawing.Point(351, 97);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 17);
            this.label14.TabIndex = 493;
            this.label14.Text = "IME 03";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label23.Location = new System.Drawing.Point(351, 67);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 17);
            this.label23.TabIndex = 486;
            this.label23.Text = "IME 02";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label41.Location = new System.Drawing.Point(351, 8);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(68, 17);
            this.label41.TabIndex = 487;
            this.label41.Text = "Item Note";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label18.Location = new System.Drawing.Point(351, 37);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 17);
            this.label18.TabIndex = 487;
            this.label18.Text = "IME 01";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label19.Location = new System.Drawing.Point(353, 160);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 17);
            this.label19.TabIndex = 488;
            this.label19.Text = "On Order";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(629, 105);
            this.label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(27, 17);
            this.label53.TabIndex = 480;
            this.label53.Text = "HE";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label53, "Hazardous For Environment");
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(770, 105);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(19, 17);
            this.label64.TabIndex = 474;
            this.label64.Text = "Li";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label64, "Lithium");
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(698, 105);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(27, 17);
            this.label63.TabIndex = 473;
            this.label63.Text = "HS";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label63, "Hazardous for Shipping");
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(557, 149);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 17);
            this.label22.TabIndex = 471;
            this.label22.Text = "CL";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label22, "Calibration Indicator");
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(770, 149);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 17);
            this.label28.TabIndex = 483;
            this.label28.Text = "E/C";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label28, "Expiring Product Change");
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(629, 149);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(25, 17);
            this.label55.TabIndex = 478;
            this.label55.Text = "LC";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label55, "Licence Type");
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(557, 105);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(27, 17);
            this.label25.TabIndex = 470;
            this.label25.Text = "HZ";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label25, "Hazardous Indicator");
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(698, 149);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(31, 17);
            this.label26.TabIndex = 482;
            this.label26.Text = "D/C";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label26, "Discontinued Item");
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(527, 34);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(75, 23);
            this.label59.TabIndex = 464;
            this.label59.Text = "GB 01";
            this.label59.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(527, 65);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(76, 20);
            this.label56.TabIndex = 465;
            this.label56.Text = "On Order";
            this.label56.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(870, 8);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 17);
            this.label27.TabIndex = 460;
            this.label27.Text = "Intro. (SD)";
            this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label27, "Introduction Date");
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(870, 67);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(46, 17);
            this.label60.TabIndex = 452;
            this.label60.Text = "SS By";
            this.label60.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label60, "Substituted By");
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(870, 97);
            this.label54.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(54, 17);
            this.label54.TabIndex = 455;
            this.label54.Text = "Run on";
            this.label54.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(870, 160);
            this.label66.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(30, 17);
            this.label66.TabIndex = 453;
            this.label66.Text = "P P";
            this.label66.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(870, 130);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(59, 17);
            this.label58.TabIndex = 454;
            this.label58.Text = "Referral";
            this.label58.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(870, 37);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(73, 17);
            this.label62.TabIndex = 462;
            this.label62.Text = "Disc. (OS)";
            this.label62.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label62, "Discontinuation Date");
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(1055, 34);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 16);
            this.label29.TabIndex = 440;
            this.label29.Text = "Height";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(1055, 125);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(60, 25);
            this.label31.TabIndex = 437;
            this.label31.Text = "Std. Wt.";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label31, "Standard Weight");
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label32.Location = new System.Drawing.Point(1207, 125);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(37, 25);
            this.label32.TabIndex = 447;
            this.label32.Text = "kg";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label38.Location = new System.Drawing.Point(1207, 155);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(27, 25);
            this.label38.TabIndex = 448;
            this.label38.Text = "kg";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label43.Location = new System.Drawing.Point(1207, 93);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(35, 25);
            this.label43.TabIndex = 449;
            this.label43.Text = "cm";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(1055, 66);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 16);
            this.label44.TabIndex = 438;
            this.label44.Text = "Width";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label46.Location = new System.Drawing.Point(1207, 62);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(35, 25);
            this.label46.TabIndex = 450;
            this.label46.Text = "cm";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(1055, 155);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 25);
            this.label47.TabIndex = 445;
            this.label47.Text = "Gross Wt";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label48.Location = new System.Drawing.Point(1207, 30);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(33, 25);
            this.label48.TabIndex = 451;
            this.label48.Text = "cm";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(1055, 97);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(55, 16);
            this.label49.TabIndex = 439;
            this.label49.Text = "Length";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.LandingCost);
            this.panel1.Controls.Add(this.btnCreateRev);
            this.panel1.Controls.Add(this.groupBox11);
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Controls.Add(this.gbShipment);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 734);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1651, 166);
            this.panel1.TabIndex = 58;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.Location = new System.Drawing.Point(1516, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 39);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Location = new System.Drawing.Point(1516, 114);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 39);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // LandingCost
            // 
            this.LandingCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LandingCost.Controls.Add(this.ckCustomsDuties);
            this.LandingCost.Controls.Add(this.ckWeightCost);
            this.LandingCost.Controls.Add(this.ckItemCost);
            this.LandingCost.Enabled = false;
            this.LandingCost.Location = new System.Drawing.Point(888, 9);
            this.LandingCost.Margin = new System.Windows.Forms.Padding(4);
            this.LandingCost.Name = "LandingCost";
            this.LandingCost.Padding = new System.Windows.Forms.Padding(4);
            this.LandingCost.Size = new System.Drawing.Size(175, 148);
            this.LandingCost.TabIndex = 50;
            this.LandingCost.TabStop = false;
            this.LandingCost.Text = "Landing Cost";
            // 
            // ckCustomsDuties
            // 
            this.ckCustomsDuties.AutoSize = true;
            this.ckCustomsDuties.Checked = true;
            this.ckCustomsDuties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckCustomsDuties.Location = new System.Drawing.Point(8, 113);
            this.ckCustomsDuties.Margin = new System.Windows.Forms.Padding(4);
            this.ckCustomsDuties.Name = "ckCustomsDuties";
            this.ckCustomsDuties.Size = new System.Drawing.Size(128, 21);
            this.ckCustomsDuties.TabIndex = 12;
            this.ckCustomsDuties.Text = "Customs Duties";
            this.ckCustomsDuties.UseVisualStyleBackColor = true;
            // 
            // ckWeightCost
            // 
            this.ckWeightCost.AutoSize = true;
            this.ckWeightCost.Checked = true;
            this.ckWeightCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckWeightCost.Location = new System.Drawing.Point(8, 69);
            this.ckWeightCost.Margin = new System.Windows.Forms.Padding(4);
            this.ckWeightCost.Name = "ckWeightCost";
            this.ckWeightCost.Size = new System.Drawing.Size(106, 21);
            this.ckWeightCost.TabIndex = 11;
            this.ckWeightCost.Text = "Weight Cost";
            this.ckWeightCost.UseVisualStyleBackColor = true;
            // 
            // ckItemCost
            // 
            this.ckItemCost.AutoSize = true;
            this.ckItemCost.Checked = true;
            this.ckItemCost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckItemCost.Location = new System.Drawing.Point(8, 25);
            this.ckItemCost.Margin = new System.Windows.Forms.Padding(4);
            this.ckItemCost.Name = "ckItemCost";
            this.ckItemCost.Size = new System.Drawing.Size(88, 21);
            this.ckItemCost.TabIndex = 10;
            this.ckItemCost.Text = "Item Cost";
            this.ckItemCost.UseVisualStyleBackColor = true;
            // 
            // btnCreateRev
            // 
            this.btnCreateRev.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateRev.Location = new System.Drawing.Point(1516, 62);
            this.btnCreateRev.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateRev.Name = "btnCreateRev";
            this.btnCreateRev.Size = new System.Drawing.Size(123, 39);
            this.btnCreateRev.TabIndex = 48;
            this.btnCreateRev.Text = "Create Rev.";
            this.btnCreateRev.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Controls.Add(this.cbDeliverDiscount);
            this.groupBox11.Controls.Add(this.lblTotalExtra);
            this.groupBox11.Controls.Add(this.lblVat);
            this.groupBox11.Controls.Add(this.label40);
            this.groupBox11.Controls.Add(this.lbltotal);
            this.groupBox11.Controls.Add(this.label52);
            this.groupBox11.Controls.Add(this.label4);
            this.groupBox11.Controls.Add(this.textBox7);
            this.groupBox11.Controls.Add(this.txtExtraChanges);
            this.groupBox11.Controls.Add(this.lblVatTotal);
            this.groupBox11.Controls.Add(this.txtTotalMarginGeneral);
            this.groupBox11.Controls.Add(this.txtTotalDiscAmount);
            this.groupBox11.Controls.Add(this.chkVat);
            this.groupBox11.Controls.Add(this.txtTotalDiscPercent);
            this.groupBox11.Controls.Add(this.lblGrossTotal);
            this.groupBox11.Controls.Add(this.label39);
            this.groupBox11.Controls.Add(this.label34);
            this.groupBox11.ForeColor = System.Drawing.Color.Black;
            this.groupBox11.Location = new System.Drawing.Point(1071, 9);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(431, 148);
            this.groupBox11.TabIndex = 49;
            this.groupBox11.TabStop = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(324, 21);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(87, 17);
            this.label42.TabIndex = 59;
            this.label42.Text = "Total Margin";
            // 
            // cbDeliverDiscount
            // 
            this.cbDeliverDiscount.Location = new System.Drawing.Point(328, 73);
            this.cbDeliverDiscount.Margin = new System.Windows.Forms.Padding(4);
            this.cbDeliverDiscount.Name = "cbDeliverDiscount";
            this.cbDeliverDiscount.Size = new System.Drawing.Size(93, 39);
            this.cbDeliverDiscount.TabIndex = 58;
            this.cbDeliverDiscount.Text = "Distribute Discount";
            this.cbDeliverDiscount.UseVisualStyleBackColor = true;
            this.cbDeliverDiscount.Visible = false;
            // 
            // lblTotalExtra
            // 
            this.lblTotalExtra.AutoSize = true;
            this.lblTotalExtra.Location = new System.Drawing.Point(237, 68);
            this.lblTotalExtra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalExtra.Name = "lblTotalExtra";
            this.lblTotalExtra.Size = new System.Drawing.Size(36, 17);
            this.lblTotalExtra.TabIndex = 57;
            this.lblTotalExtra.Text = "0,00";
            // 
            // lblVat
            // 
            this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblVat.Location = new System.Drawing.Point(85, 95);
            this.lblVat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(64, 20);
            this.lblVat.TabIndex = 55;
            this.lblVat.Text = "0";
            this.lblVat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label40.Location = new System.Drawing.Point(152, 95);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 20);
            this.label40.TabIndex = 54;
            this.label40.Text = "%";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(237, 43);
            this.lbltotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(36, 17);
            this.lbltotal.TabIndex = 53;
            this.lbltotal.Text = "0,00";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(8, 43);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(40, 17);
            this.label52.TabIndex = 52;
            this.label52.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(197, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "%";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(8, 65);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(101, 22);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "Extra Charges";
            // 
            // txtExtraChanges
            // 
            this.txtExtraChanges.Location = new System.Drawing.Point(128, 65);
            this.txtExtraChanges.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtraChanges.Name = "txtExtraChanges";
            this.txtExtraChanges.Size = new System.Drawing.Size(65, 22);
            this.txtExtraChanges.TabIndex = 20;
            this.txtExtraChanges.Text = "0";
            this.txtExtraChanges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVatTotal
            // 
            this.lblVatTotal.AutoSize = true;
            this.lblVatTotal.Location = new System.Drawing.Point(237, 97);
            this.lblVatTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVatTotal.Name = "lblVatTotal";
            this.lblVatTotal.Size = new System.Drawing.Size(36, 17);
            this.lblVatTotal.TabIndex = 18;
            this.lblVatTotal.Text = "0,00";
            // 
            // txtTotalMarginGeneral
            // 
            this.txtTotalMarginGeneral.Enabled = false;
            this.txtTotalMarginGeneral.Location = new System.Drawing.Point(327, 42);
            this.txtTotalMarginGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalMarginGeneral.Name = "txtTotalMarginGeneral";
            this.txtTotalMarginGeneral.Size = new System.Drawing.Size(84, 22);
            this.txtTotalMarginGeneral.TabIndex = 15;
            this.txtTotalMarginGeneral.Text = "0";
            this.txtTotalMarginGeneral.Visible = false;
            // 
            // txtTotalDiscAmount
            // 
            this.txtTotalDiscAmount.Location = new System.Drawing.Point(237, 19);
            this.txtTotalDiscAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalDiscAmount.Name = "txtTotalDiscAmount";
            this.txtTotalDiscAmount.Size = new System.Drawing.Size(71, 22);
            this.txtTotalDiscAmount.TabIndex = 15;
            this.txtTotalDiscAmount.Text = "0";
            // 
            // chkVat
            // 
            this.chkVat.AutoSize = true;
            this.chkVat.Checked = true;
            this.chkVat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVat.Location = new System.Drawing.Point(8, 95);
            this.chkVat.Margin = new System.Windows.Forms.Padding(4);
            this.chkVat.Name = "chkVat";
            this.chkVat.Size = new System.Drawing.Size(57, 21);
            this.chkVat.TabIndex = 17;
            this.chkVat.Text = "VAT";
            this.chkVat.UseVisualStyleBackColor = true;
            // 
            // txtTotalDiscPercent
            // 
            this.txtTotalDiscPercent.Location = new System.Drawing.Point(128, 19);
            this.txtTotalDiscPercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalDiscPercent.Name = "txtTotalDiscPercent";
            this.txtTotalDiscPercent.Size = new System.Drawing.Size(65, 22);
            this.txtTotalDiscPercent.TabIndex = 13;
            this.txtTotalDiscPercent.Text = "0";
            // 
            // lblGrossTotal
            // 
            this.lblGrossTotal.AutoSize = true;
            this.lblGrossTotal.Location = new System.Drawing.Point(237, 121);
            this.lblGrossTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrossTotal.Name = "lblGrossTotal";
            this.lblGrossTotal.Size = new System.Drawing.Size(36, 17);
            this.lblGrossTotal.TabIndex = 12;
            this.lblGrossTotal.Text = "0,00";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(8, 121);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(82, 17);
            this.label39.TabIndex = 5;
            this.label39.Text = "Gross Total";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(8, 22);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(111, 17);
            this.label34.TabIndex = 0;
            this.label34.Text = "Disc on Subtotal";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox7.Controls.Add(this.chkbForFinance);
            this.groupBox7.Controls.Add(this.txtNoteForUs);
            this.groupBox7.Location = new System.Drawing.Point(20, 1);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(667, 84);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Quot Notes For Us";
            // 
            // chkbForFinance
            // 
            this.chkbForFinance.AutoSize = true;
            this.chkbForFinance.Location = new System.Drawing.Point(555, 34);
            this.chkbForFinance.Margin = new System.Windows.Forms.Padding(4);
            this.chkbForFinance.Name = "chkbForFinance";
            this.chkbForFinance.Size = new System.Drawing.Size(105, 21);
            this.chkbForFinance.TabIndex = 1;
            this.chkbForFinance.Text = "For Finance";
            this.chkbForFinance.UseVisualStyleBackColor = true;
            // 
            // txtNoteForUs
            // 
            this.txtNoteForUs.Location = new System.Drawing.Point(8, 23);
            this.txtNoteForUs.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoteForUs.Multiline = true;
            this.txtNoteForUs.Name = "txtNoteForUs";
            this.txtNoteForUs.Size = new System.Drawing.Size(537, 43);
            this.txtNoteForUs.TabIndex = 0;
            // 
            // gbShipment
            // 
            this.gbShipment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gbShipment.Controls.Add(this.label7);
            this.gbShipment.Controls.Add(this.cbSMethod);
            this.gbShipment.Location = new System.Drawing.Point(695, 9);
            this.gbShipment.Margin = new System.Windows.Forms.Padding(4);
            this.gbShipment.Name = "gbShipment";
            this.gbShipment.Padding = new System.Windows.Forms.Padding(4);
            this.gbShipment.Size = new System.Drawing.Size(175, 148);
            this.gbShipment.TabIndex = 46;
            this.gbShipment.TabStop = false;
            this.gbShipment.Text = "Shipping Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 9;
            // 
            // cbSMethod
            // 
            this.cbSMethod.FormattingEnabled = true;
            this.cbSMethod.Items.AddRange(new object[] {
            "Air Freight",
            "Express",
            "Truck",
            "Sea Freight"});
            this.cbSMethod.Location = new System.Drawing.Point(8, 31);
            this.cbSMethod.Margin = new System.Windows.Forms.Padding(4);
            this.cbSMethod.Name = "cbSMethod";
            this.cbSMethod.Size = new System.Drawing.Size(160, 24);
            this.cbSMethod.TabIndex = 8;
            this.cbSMethod.Text = "Air Freight";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox3.Controls.Add(this.txtNoteForCustomer);
            this.groupBox3.Location = new System.Drawing.Point(20, 85);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(667, 74);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Quot Notes For Customer";
            // 
            // txtNoteForCustomer
            // 
            this.txtNoteForCustomer.Location = new System.Drawing.Point(8, 23);
            this.txtNoteForCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoteForCustomer.Multiline = true;
            this.txtNoteForCustomer.Name = "txtNoteForCustomer";
            this.txtNoteForCustomer.Size = new System.Drawing.Size(537, 43);
            this.txtNoteForCustomer.TabIndex = 0;
            // 
            // dgNo
            // 
            this.dgNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.dgNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgNo.Frozen = true;
            this.dgNo.HeaderText = "No";
            this.dgNo.Name = "dgNo";
            this.dgNo.Width = 30;
            // 
            // HS
            // 
            this.HS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.HS.Frozen = true;
            this.HS.HeaderText = "HS";
            this.HS.Name = "HS";
            this.HS.ReadOnly = true;
            this.HS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HS.Width = 25;
            // 
            // LI
            // 
            this.LI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LI.Frozen = true;
            this.LI.HeaderText = "LI";
            this.LI.Name = "LI";
            this.LI.ReadOnly = true;
            this.LI.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LI.Width = 25;
            // 
            // CL
            // 
            this.CL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CL.Frozen = true;
            this.CL.HeaderText = "CL";
            this.CL.Name = "CL";
            this.CL.ReadOnly = true;
            this.CL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CL.Width = 25;
            // 
            // LC
            // 
            this.LC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LC.Frozen = true;
            this.LC.HeaderText = "LC";
            this.LC.Name = "LC";
            this.LC.ReadOnly = true;
            this.LC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LC.Width = 25;
            // 
            // LM
            // 
            this.LM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LM.Frozen = true;
            this.LM.HeaderText = "LM";
            this.LM.Name = "LM";
            this.LM.ReadOnly = true;
            this.LM.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LM.Width = 25;
            // 
            // dgSupplier
            // 
            this.dgSupplier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgSupplier.Frozen = true;
            this.dgSupplier.HeaderText = "Supplier";
            this.dgSupplier.Name = "dgSupplier";
            this.dgSupplier.ReadOnly = true;
            this.dgSupplier.Width = 89;
            // 
            // dgProductCode
            // 
            this.dgProductCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgProductCode.Frozen = true;
            this.dgProductCode.HeaderText = "Item Code";
            this.dgProductCode.Name = "dgProductCode";
            // 
            // dgBrand
            // 
            this.dgBrand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgBrand.Frozen = true;
            this.dgBrand.HeaderText = "Brand";
            this.dgBrand.Name = "dgBrand";
            this.dgBrand.ReadOnly = true;
            this.dgBrand.Width = 75;
            // 
            // dgMPN
            // 
            this.dgMPN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgMPN.Frozen = true;
            this.dgMPN.HeaderText = "MPN";
            this.dgMPN.Name = "dgMPN";
            this.dgMPN.ReadOnly = true;
            this.dgMPN.Width = 67;
            // 
            // dgDesc
            // 
            this.dgDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgDesc.Frozen = true;
            this.dgDesc.HeaderText = "Description";
            this.dgDesc.Name = "dgDesc";
            this.dgDesc.ReadOnly = true;
            this.dgDesc.Width = 108;
            // 
            // dgUKPrice
            // 
            this.dgUKPrice.HeaderText = "UK (£)";
            this.dgUKPrice.Name = "dgUKPrice";
            this.dgUKPrice.ReadOnly = true;
            // 
            // dgCost
            // 
            this.dgCost.HeaderText = "Cost (£)";
            this.dgCost.Name = "dgCost";
            this.dgCost.ReadOnly = true;
            // 
            // dgLandingCost
            // 
            this.dgLandingCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Format = "C3";
            dataGridViewCellStyle3.NullValue = null;
            this.dgLandingCost.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgLandingCost.HeaderText = "Landing Cost (£)";
            this.dgLandingCost.Name = "dgLandingCost";
            this.dgLandingCost.ReadOnly = true;
            this.dgLandingCost.Width = 114;
            // 
            // dgMargin
            // 
            this.dgMargin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgMargin.HeaderText = "Margin (%)";
            this.dgMargin.Name = "dgMargin";
            this.dgMargin.ReadOnly = true;
            this.dgMargin.Width = 98;
            // 
            // dgQty
            // 
            this.dgQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgQty.DataPropertyName = "Qty";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "0";
            this.dgQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgQty.HeaderText = "Qty";
            this.dgQty.Name = "dgQty";
            this.dgQty.ReadOnly = true;
            this.dgQty.Width = 59;
            // 
            // dgStock
            // 
            this.dgStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgStock.HeaderText = "Stock";
            this.dgStock.Name = "dgStock";
            this.dgStock.ReadOnly = true;
            this.dgStock.Width = 72;
            // 
            // dgUOM
            // 
            this.dgUOM.HeaderText = "UOM";
            this.dgUOM.Name = "dgUOM";
            this.dgUOM.ReadOnly = true;
            this.dgUOM.Width = 57;
            // 
            // dgSSM
            // 
            this.dgSSM.HeaderText = "SSM";
            this.dgSSM.Name = "dgSSM";
            this.dgSSM.ReadOnly = true;
            // 
            // dgUC
            // 
            this.dgUC.HeaderText = "U/C";
            this.dgUC.Name = "dgUC";
            this.dgUC.ReadOnly = true;
            // 
            // dgUPIME
            // 
            this.dgUPIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgUPIME.HeaderText = "U/P IME L/P ";
            this.dgUPIME.Name = "dgUPIME";
            this.dgUPIME.ReadOnly = true;
            this.dgUPIME.Width = 107;
            // 
            // dgDisc
            // 
            this.dgDisc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgDisc.HeaderText = "Disc. (%)";
            this.dgDisc.Name = "dgDisc";
            this.dgDisc.ReadOnly = true;
            this.dgDisc.Width = 87;
            // 
            // dgUCUPCurr
            // 
            this.dgUCUPCurr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgUCUPCurr.HeaderText = "U/C U/P (Curr.)";
            this.dgUCUPCurr.Name = "dgUCUPCurr";
            this.dgUCUPCurr.ReadOnly = true;
            this.dgUCUPCurr.Width = 121;
            // 
            // dgTotal
            // 
            this.dgTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgTotal.HeaderText = "TOTAL";
            this.dgTotal.Name = "dgTotal";
            this.dgTotal.ReadOnly = true;
            this.dgTotal.Width = 83;
            // 
            // dgTargetUP
            // 
            this.dgTargetUP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgTargetUP.HeaderText = "Target U/P";
            this.dgTargetUP.Name = "dgTargetUP";
            this.dgTargetUP.ReadOnly = true;
            this.dgTargetUP.Width = 98;
            // 
            // dgCompetitor
            // 
            this.dgCompetitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCompetitor.HeaderText = "Competitor";
            this.dgCompetitor.Name = "dgCompetitor";
            this.dgCompetitor.ReadOnly = true;
            this.dgCompetitor.Width = 105;
            // 
            // dgHZ
            // 
            this.dgHZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgHZ.HeaderText = "HZ";
            this.dgHZ.Name = "dgHZ";
            this.dgHZ.ReadOnly = true;
            this.dgHZ.Visible = false;
            this.dgHZ.Width = 56;
            // 
            // dgCL
            // 
            this.dgCL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCL.HeaderText = "CL";
            this.dgCL.Name = "dgCL";
            this.dgCL.ReadOnly = true;
            this.dgCL.Visible = false;
            this.dgCL.Width = 54;
            // 
            // dgCR
            // 
            this.dgCR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCR.HeaderText = "CR";
            this.dgCR.Name = "dgCR";
            this.dgCR.ReadOnly = true;
            this.dgCR.Visible = false;
            this.dgCR.Width = 56;
            // 
            // dgDelivery
            // 
            this.dgDelivery.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgDelivery.HeaderText = "Delivery";
            this.dgDelivery.Name = "dgDelivery";
            this.dgDelivery.ReadOnly = true;
            this.dgDelivery.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDelivery.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgDelivery.Width = 88;
            // 
            // dgUnitWeigt
            // 
            this.dgUnitWeigt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgUnitWeigt.HeaderText = "Unit Weigt (Kg)";
            this.dgUnitWeigt.Name = "dgUnitWeigt";
            this.dgUnitWeigt.ReadOnly = true;
            this.dgUnitWeigt.Width = 122;
            // 
            // dgTotalWeight
            // 
            this.dgTotalWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgTotalWeight.HeaderText = "Total Weight (Kg)";
            this.dgTotalWeight.Name = "dgTotalWeight";
            this.dgTotalWeight.ReadOnly = true;
            this.dgTotalWeight.Width = 136;
            // 
            // dgCustStkCode
            // 
            this.dgCustStkCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCustStkCode.HeaderText = "Cust Stk Code";
            this.dgCustStkCode.Name = "dgCustStkCode";
            this.dgCustStkCode.ReadOnly = true;
            this.dgCustStkCode.Width = 116;
            // 
            // dgCustDescription
            // 
            this.dgCustDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCustDescription.HeaderText = "Cust. Description";
            this.dgCustDescription.Name = "dgCustDescription";
            this.dgCustDescription.ReadOnly = true;
            this.dgCustDescription.Width = 132;
            // 
            // dgCOO
            // 
            this.dgCOO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCOO.HeaderText = "COO";
            this.dgCOO.Name = "dgCOO";
            this.dgCOO.ReadOnly = true;
            this.dgCOO.Width = 68;
            // 
            // dgCCCNO
            // 
            this.dgCCCNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgCCCNO.HeaderText = "CCCNO";
            this.dgCCCNO.Name = "dgCCCNO";
            this.dgCCCNO.ReadOnly = true;
            this.dgCCCNO.Width = 85;
            // 
            // dgDependantTable
            // 
            this.dgDependantTable.HeaderText = "dgDependantTable";
            this.dgDependantTable.Name = "dgDependantTable";
            this.dgDependantTable.Visible = false;
            // 
            // ExperimentQuotationAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 902);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1362, 713);
            this.Name = "ExperimentQuotationAdd";
            this.Text = "Add Quotation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExperimentQuotationAdd_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAddedItems)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeletedItems)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabCustomerDetails.ResumeLayout(false);
            this.tabCustomerDetails.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.tabItemDetails.ResumeLayout(false);
            this.tabItemDetails.PerformLayout();
            this.gbCost.ResumeLayout(false);
            this.gbCost.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.LandingCost.ResumeLayout(false);
            this.LandingCost.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gbShipment.ResumeLayout(false);
            this.gbShipment.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgAddedItems;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgDeletedItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtSubtotal;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.MaskedTextBox txtTotalMarginGrid;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCustomerDetails;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnViewMore;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.ComboBox cbPaymentMethod;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbRepresentative;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRFQNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.TextBox txtValidity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuotationNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddAttention;
        private System.Windows.Forms.ComboBox cbWorkers;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtContactNote;
        private System.Windows.Forms.TextBox txtCustomerNote;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabItemDetails;
        private System.Windows.Forms.TextBox txtSection;
        private System.Windows.Forms.TextBox txtSupersectionName;
        private System.Windows.Forms.TextBox txtCofO;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtCCCN;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtMHCodeLevel1;
        private System.Windows.Forms.TextBox txtIME04;
        private System.Windows.Forms.TextBox txtIME03;
        private System.Windows.Forms.TextBox txtIME02;
        private System.Windows.Forms.TextBox txtIME01;
        private System.Windows.Forms.TextBox txtOnOrder;
        private System.Windows.Forms.TextBox txtExpiringPro;
        private System.Windows.Forms.TextBox txtHazardousInd;
        private System.Windows.Forms.TextBox txtDiscChange;
        private System.Windows.Forms.TextBox txtEnvironment;
        private System.Windows.Forms.TextBox txtLithium;
        private System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.TextBox txtLicenceType;
        private System.Windows.Forms.TextBox txtCalibrationInd;
        private System.Windows.Forms.TextBox txtGB01_b;
        private System.Windows.Forms.TextBox txtOnOrder_b;
        private System.Windows.Forms.TextBox txtGB01_a;
        private System.Windows.Forms.TextBox txtOnOrder_a;
        private System.Windows.Forms.TextBox txtDiscontinuationDate;
        private System.Windows.Forms.TextBox txtUKDiscDate;
        private System.Windows.Forms.TextBox txtSubstitutedBy;
        private System.Windows.Forms.TextBox txtRunOn;
        private System.Windows.Forms.TextBox txtPP;
        private System.Windows.Forms.TextBox txtReferral;
        private System.Windows.Forms.TextBox txtStandardWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtGrossWeight;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtWeb5;
        private System.Windows.Forms.TextBox txtWeb2;
        private System.Windows.Forms.TextBox txtWeb3;
        private System.Windows.Forms.TextBox txtWeb1;
        private System.Windows.Forms.TextBox txtWeb4;
        private System.Windows.Forms.TextBox txtCost1;
        private System.Windows.Forms.TextBox txtMargin5;
        private System.Windows.Forms.TextBox txtUK5;
        private System.Windows.Forms.TextBox txtUK2;
        private System.Windows.Forms.TextBox txtCost5;
        private System.Windows.Forms.TextBox txtMargin1;
        private System.Windows.Forms.TextBox txtMargin2;
        private System.Windows.Forms.TextBox txtUK3;
        private System.Windows.Forms.TextBox txtUK1;
        private System.Windows.Forms.TextBox txtCost3;
        private System.Windows.Forms.TextBox txtMargin4;
        private System.Windows.Forms.TextBox txtCost4;
        private System.Windows.Forms.TextBox txtCost2;
        private System.Windows.Forms.TextBox txtMargin3;
        private System.Windows.Forms.TextBox txtUK4;
        private System.Windows.Forms.TextBox txtCol5Break;
        private System.Windows.Forms.TextBox txtCol2Break;
        private System.Windows.Forms.TextBox txtCol1Break;
        private System.Windows.Forms.TextBox txtCol4Break;
        private System.Windows.Forms.TextBox txtCol3Break;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox LandingCost;
        private System.Windows.Forms.CheckBox ckCustomsDuties;
        private System.Windows.Forms.CheckBox ckWeightCost;
        private System.Windows.Forms.CheckBox ckItemCost;
        private System.Windows.Forms.Button btnCreateRev;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lblTotalExtra;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox txtExtraChanges;
        private System.Windows.Forms.Label lblVatTotal;
        private System.Windows.Forms.TextBox txtTotalDiscAmount;
        private System.Windows.Forms.CheckBox chkVat;
        private System.Windows.Forms.TextBox txtTotalDiscPercent;
        private System.Windows.Forms.Label lblGrossTotal;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkbForFinance;
        private System.Windows.Forms.TextBox txtNoteForUs;
        private System.Windows.Forms.GroupBox gbShipment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSMethod;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNoteForCustomer;
        private System.Windows.Forms.TextBox txtAccountingNote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtItemNote;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnProductHistory;
        private System.Windows.Forms.Label lblExcRate;
        private System.Windows.Forms.TextBox txtTotalMarginGeneral;
        private System.Windows.Forms.CheckBox cbDeliverDiscount;
        private System.Windows.Forms.Button btnImportFromXML;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnCustomizeGrid;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.GroupBox gbCost;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Button btnExQuotation;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn No1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDesc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQty1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUOM1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSSM1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUPIME1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDisc1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUCUPCurr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTotal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTargetUP1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCompetitor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgDelivery1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitWeigt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustomerStokCode1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustDescription1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HS;
        private System.Windows.Forms.DataGridViewTextBoxColumn LI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CL;
        private System.Windows.Forms.DataGridViewTextBoxColumn LC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMPN;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUKPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgLandingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMargin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSSM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUPIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDisc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUCUPCurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTargetUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCompetitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgHZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCL;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCR;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUnitWeigt;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustStkCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCustDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCOO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCCCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDependantTable;
    }
}