namespace PrintWorks
{
    using PrintWorks.Properties;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmPrintDesigner : Form
    {
        private Button btnAddForms;
        private Button btnClear;
        private Button btnClearDetails;
        private Button btnClearMaster;
        private Button btnDelete;
        private Button btnNew;
        private Button btnPrint;
        private Button btnSave;
        private Button btnSaveDefault;
        private Button btnSelectDefault;
        private CheckBox chkExtraField;
        private CheckBox chkLineNonRepeat;
        private CheckBox chkLineRepeat;
        private CheckBox chkTextWrap;
        private ToolStripMenuItem clearDetailsToolStripMenuItem;
        private ToolStripMenuItem clearMasterToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem1;
        private ComboBox cmbAlign;
        private ComboBox cmbFields;
        private ComboBox cmbForm;
        private ComboBox cmbTextType;
        private ComboBox cmbWrapLineCount;
        private ContextMenuStrip cmsTextBox;
        private IContainer components = null;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem dBConnectionToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private bool drag = false;
        public DataTable dtbl = new DataTable();
        private GroupBox gbxFooter;
        private GroupBox gbxHedder;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Panel groupBox7;
        private Panel groupBox8;
        private GroupBox groupBox9;
        public static int inBlankLineForFooter = 0;
        public static int inLineCountAfterPrint = 0;
        public static int inLineCountBetweenTwoPages = 0;
        public int inMasterId = 0;
        public static int inMaxLineCountinFirst = 0;
        public static int inMaxLineCountinOther = 0;
        public static int inPageSizeInFirst = 0;
        public static int inPageSizeInOther = 0;
        public int inTextId = 0;
        public static bool isDoubleLineNonRepeat = false;
        public static bool isDoubleLineRepeat = false;
        public static bool isHedderRepeat = false;
        public bool isLarge = false;
        private bool isResize = false;
        public bool isTake = false;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private ToolStripMenuItem newFormToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        public static frmPrintDesigner obj = new frmPrintDesigner();
        private Point offset;
        private Panel pnlDesignImage;
        private RadioButton rbtnAfterDetailsFooter;
        private RadioButton rbtnAllPageHedder;
        private RadioButton rbtnCondensedOff;
        private RadioButton rbtnCondensedOn;
        private RadioButton rbtnDetails;
        private RadioButton rbtnFooter;
        private RadioButton rbtnHedder;
        private RadioButton rbtnInAllPageFooter;
        private RadioButton rbtnOnlyInFirstPAgeHedder;
        private RadioButton rbtnOnlyInLastPageFooter;
        private RadioButton rbtnPageEndFooter;
        private RadioButton rbtnPitch10;
        private RadioButton rbtnPitch12;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private Point start_point = new Point(0, 0);
        private Size start_Size = new Size(0, 0);
        public static string strCondensed = "On";
        public static string strDefaultPass = "cybrotech";
        public static string strFooterLocation = "AfterDetails";
        public static string strPitch = "12";
        private ToolStripMenuItem takeToolStripMenuItem;
        private TextBox txtBlankLineCountAfterDetailsForFooter;
        private TextBox txtBlankLineCountBetweenTwoPages;
        private TextBox txtColumn;
        public TextBox txtCurrent = new TextBox();
        private TextBox txtDefaultPass;
        private TextBox txtExtraFieldName;
        private TextBox txtFieldsForExtra;
        private TextBox txtLineCountAfterPrint;
        private TextBox txtLineCountForFirstPage;
        private TextBox txtLineCountForOtherPage;
        private TextBox txtMaximumLineCountInFirst;
        private TextBox txtMaximumLineCountInOther;
        private TextBox txtRow;
        private TextBox txtWidth;

        public frmPrintDesigner()
        {
            this.InitializeComponent();
        }

        public void AssignToDtbl()
        {
            if ((this.txtCurrent != null) && (this.txtCurrent.Name != ""))
            {
                DataRow[] rowArray = this.dtbl.Select("name='" + this.txtCurrent.Name + "'");
                if (rowArray.Length > 0)
                {
                    rowArray[0]["name"] = this.txtCurrent.Name;
                    rowArray[0]["text"] = this.txtCurrent.Text;
                    rowArray[0]["row"] = int.Parse((this.txtRow.Text == "") ? "0" : this.txtRow.Text);
                    rowArray[0]["columns"] = int.Parse((this.txtColumn.Text == "") ? "0" : this.txtColumn.Text);
                    rowArray[0]["width"] = int.Parse((this.txtWidth.Text == "") ? "5" : this.txtWidth.Text);
                    rowArray[0]["DBF"] = this.cmbFields.SelectedValue.ToString();
                    rowArray[0]["fieldsForExtra"] = this.txtFieldsForExtra.Text;
                    rowArray[0]["extraFieldName"] = this.txtExtraFieldName.Text;
                    rowArray[0]["dOrH"] = this.cmbTextType.SelectedItem;
                    rowArray[0]["Repeat"] = this.rbtnDetails.Checked ? "true" : (this.rbtnFooter.Checked ? "Footer" : "false");
                    rowArray[0]["Align"] = this.cmbAlign.SelectedItem;
                    rowArray[0]["RepeatAllPage"] = this.rbtnAllPageHedder.Checked;
                    rowArray[0]["FooterRepeatAll"] = this.rbtnInAllPageFooter.Checked;
                    rowArray[0]["textWrap"] = this.chkTextWrap.Checked;
                    rowArray[0]["wrapLineCount"] = this.cmbWrapLineCount.SelectedItem.ToString();
                }
            }
        }

        private void btnAddForms_Click(object sender, EventArgs e)
        {
            try
            {
                this.NewForms();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnClearDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to clear this field details ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    this.ClearDetails();
                    if (this.txtCurrent != null)
                    {
                        this.txtCurrent.Text = this.txtCurrent.Name;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnClearMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to clear master details ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    this.Clear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Delete();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                this.New();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtblDetails = new DataTable();
                dtblDetails.Columns.Add("slno");
                dtblDetails.Columns.Add("name");
                dtblDetails.Columns.Add("rate", typeof(decimal));
                dtblDetails.Columns.Add("qty", typeof(int));
                dtblDetails.Columns.Add("total", typeof(decimal));
                for (int i = 1; i <= 10; i++)
                {
                    dtblDetails.Rows.Add(new object[0]);
                    dtblDetails.Rows[i - 1][0] = i;
                    dtblDetails.Rows[i - 1][1] = "Name " + i.ToString();
                    dtblDetails.Rows[i - 1][2] = Math.Sqrt((double) i) + (i * 2);
                    dtblDetails.Rows[i - 1][3] = i + 1;
                    dtblDetails.Rows[i - 1][4] = decimal.Parse(dtblDetails.Rows[i - 1][2].ToString()) * decimal.Parse(dtblDetails.Rows[i - 1][3].ToString());
                }
                DataTable dtblHedder = new DataTable();
                DataTable dtblFooter = new DataTable();
                dtblHedder.Columns.Add("Company");
                dtblHedder.Columns.Add("Date");
                dtblHedder.Columns.Add("Address");
                dtblHedder.Columns.Add("Phone");
                dtblHedder.Columns.Add("name");
                dtblHedder.Rows.Add(new object[0]);
                dtblHedder.Rows[0]["Company"] = "Cybrosys";
                dtblHedder.Rows[0]["Date"] = "16-Mar-2012";
                dtblHedder.Rows[0]["Address"] = "Neospace, Calicut Kinfra, Kakancheri, 673634 ";
                dtblHedder.Rows[0]["Phone"] = "0494-2564895";
                dtblHedder.Rows[0]["name"] = "0494-2564856";
                dtblFooter.Columns.Add("totalAmount");
                dtblFooter.Columns.Add("name");
                dtblFooter.Rows.Add(new object[0]);
                dtblFooter.Rows[0]["TotalAmount"] = Math.Round(decimal.Parse(dtblDetails.Compute("Sum(total)", "").ToString()), 2);
                dtblFooter.Rows[0]["name"] = "0494-2564856";
                DotMatrixPrint.PrintDesign(13, dtblHedder, dtblDetails, dtblFooter);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSaveDefault_Click(object sender, EventArgs e)
        {
            if (this.txtDefaultPass.Text == strDefaultPass)
            {
                this.SaveDefault();
            }
            else
            {
                MessageBox.Show("Invalid password", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnSelectDefault_Click(object sender, EventArgs e)
        {
            if (this.txtDefaultPass.Text == strDefaultPass)
            {
                this.pnlDesignImage.Controls.Clear();
                this.dtbl.Rows.Clear();
                this.txtCurrent = null;
                this.inTextId = 0;
                MasterSP rsp = new MasterSP();
                MasterInfo info = new MasterInfo();
                info = rsp.MasterCopyViewByFormName(int.Parse(this.cmbForm.SelectedValue.ToString()));
                if (info.MasterId != 0)
                {
                    this.txtBlankLineCountAfterDetailsForFooter.Text = info.BlankLneForFooter.ToString();
                    if (info.FooterLocation == "AfterDetails")
                    {
                        this.rbtnAfterDetailsFooter.Checked = true;
                    }
                    else
                    {
                        this.rbtnPageEndFooter.Checked = true;
                    }
                    this.cmbForm.SelectedItem = info.FormName;
                    this.chkLineRepeat.Checked = info.IsTwoLineForDetails;
                    this.chkLineNonRepeat.Checked = info.IsTwoLineForHedder;
                    this.txtBlankLineCountBetweenTwoPages.Text = info.LineCountBetweenTwo.ToString();
                    this.txtLineCountForFirstPage.Text = info.PageSize1.ToString();
                    this.txtLineCountForOtherPage.Text = info.PageSizeOther.ToString();
                    this.rbtnPitch10.Checked = info.Pitch == "10";
                    this.rbtnPitch12.Checked = info.Pitch != "10";
                    this.rbtnCondensedOn.Checked = info.Condensed == "On";
                    this.rbtnCondensedOff.Checked = info.Condensed != "On";
                    this.txtLineCountAfterPrint.Text = info.LineCountAfterPrint.ToString();
                    DetailsSP ssp = new DetailsSP();
                    DataTable table = new DataTable();
                    this.dtbl = ssp.DetailsCopyViewAll(this.inMasterId).Copy();
                    TextBox box = new TextBox();
                    foreach (DataRow row in this.dtbl.Rows)
                    {
                        this.txtCurrent = null;
                        this.ClearDetails();
                        frmPrintDesigner designer = new frmPrintDesigner();
                        TextBox box2 = new TextBox();
                        if (this.inTextId < int.Parse(row["name"].ToString()))
                        {
                            this.inTextId = int.Parse(row["name"].ToString());
                        }
                        box2.Name = row["name"].ToString();
                        box2.Multiline = true;
                        box2.Size = new Size((int.Parse(row["width"].ToString()) * 8) + 1, 0x11);
                        box2.Text = row["text"].ToString();
                        box2.Enter += new EventHandler(this.txtCurrent_Enter);
                        box2.ContextMenuStrip = this.cmsTextBox;
                        box2.TextChanged += new EventHandler(this.txtCurrent_TextChanged);
                        box2.MouseDown += new MouseEventHandler(this.textBox1_MouseDown);
                        box2.MouseUp += new MouseEventHandler(this.textBox1_MouseUp);
                        box2.DragOver += new DragEventHandler(this.textBox1_DragOver);
                        box2.MouseMove += new MouseEventHandler(this.textBox1_MouseMove);
                        box2.Font = new Font("Lucida Console", 10f);
                        this.pnlDesignImage.Controls.Add(box2);
                        box = box2;
                        foreach (Control control in this.pnlDesignImage.Controls)
                        {
                            control.BackColor = Color.AntiqueWhite;
                        }
                        box.BackColor = Color.Gainsboro;
                        this.txtRow.Text = row["row"].ToString();
                        this.txtColumn.Text = row["columns"].ToString();
                        this.txtWidth.Text = row["width"].ToString();
                        if (row["Repeat"].ToString() == "false")
                        {
                            this.rbtnHedder.Checked = true;
                        }
                        else if (row["Repeat"].ToString() == "true")
                        {
                            this.rbtnDetails.Checked = true;
                        }
                        else
                        {
                            this.rbtnFooter.Checked = true;
                        }
                        this.cmbAlign.SelectedItem = row["Align"].ToString();
                        this.cmbFields.SelectedValue = row["DBF"].ToString();
                        this.cmbTextType.SelectedItem = row["dOrH"].ToString();
                        this.rbtnAllPageHedder.Checked = bool.Parse(row["RepeatAllPage"].ToString());
                        this.rbtnOnlyInFirstPAgeHedder.Checked = !bool.Parse(row["RepeatAllPage"].ToString());
                        this.rbtnInAllPageFooter.Checked = bool.Parse(row["FooterRepeatAll"].ToString());
                        this.rbtnOnlyInLastPageFooter.Checked = !bool.Parse(row["FooterRepeatAll"].ToString());
                        this.chkTextWrap.Checked = bool.Parse(row["textWrap"].ToString());
                        this.cmbWrapLineCount.SelectedItem = row["wrapLineCount"].ToString();
                        this.txtExtraFieldName.Text = row["extraFieldName"].ToString();
                        if (this.txtExtraFieldName.Text.Trim() != "")
                        {
                            this.txtFieldsForExtra.Text = row["fieldsForExtra"].ToString();
                            this.chkExtraField.Checked = true;
                        }
                        else
                        {
                            this.txtFieldsForExtra.Text = "";
                            this.chkExtraField.Checked = false;
                        }
                        if (box != null)
                        {
                            if (this.cmbTextType.SelectedIndex == 0)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Regular);
                            }
                            else if (this.cmbTextType.SelectedIndex == 1)
                            {
                                box.Font = new Font("Lucida Console", 11f, FontStyle.Bold);
                            }
                            else if (this.cmbTextType.SelectedIndex == 2)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Bold);
                            }
                            else if (this.cmbTextType.SelectedIndex == 3)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Italic);
                            }
                        }
                        if ((box != null) && (box.Name != ""))
                        {
                            if (this.cmbFields.SelectedIndex == 0)
                            {
                                box.ReadOnly = false;
                            }
                            else
                            {
                                box.ReadOnly = true;
                                box.Text = this.cmbFields.SelectedValue.ToString();
                            }
                        }
                        if (box != null)
                        {
                            if (this.cmbAlign.SelectedIndex == 0)
                            {
                                box.TextAlign = HorizontalAlignment.Left;
                            }
                            else if (this.cmbAlign.SelectedIndex == 1)
                            {
                                box.TextAlign = HorizontalAlignment.Center;
                            }
                            else
                            {
                                box.TextAlign = HorizontalAlignment.Right;
                            }
                        }
                        if (box != null)
                        {
                            box.Location = new Point(int.Parse((this.txtColumn.Text == "") ? "0" : this.txtColumn.Text) * 8, int.Parse((this.txtRow.Text == "") ? "0" : this.txtRow.Text) * 0x10);
                            box.Size = new Size((int.Parse((this.txtWidth.Text == "") ? "5" : this.txtWidth.Text) * 8) + 1, box.Height);
                        }
                    }
                    this.txtCurrent = box;
                    this.txtDefaultPass.Text = "";
                }
                else
                {
                    this.inMasterId = 0;
                    this.Clear();
                    this.ClearDetails();
                }
            }
            else
            {
                MessageBox.Show("Invalid password", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkExtraField_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtExtraFieldName.Enabled = this.chkExtraField.Checked;
                this.txtFieldsForExtra.Enabled = this.chkExtraField.Checked;
                this.cmbFields.Enabled = !this.chkExtraField.Checked;
                if (!this.cmbFields.Enabled)
                {
                    this.cmbFields.SelectedValue = "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkLine_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkLineNonRepeat.Checked)
                {
                    isDoubleLineNonRepeat = true;
                }
                else
                {
                    isDoubleLineNonRepeat = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkLineRepeat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chkLineRepeat.Checked)
                {
                    isDoubleLineRepeat = true;
                }
                else
                {
                    isDoubleLineRepeat = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chkTextWrap_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.chkTextWrap.Checked)
                {
                    this.cmbWrapLineCount.Enabled = true;
                }
                else
                {
                    this.cmbWrapLineCount.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void Clear()
        {
            this.txtBlankLineCountAfterDetailsForFooter.Text = "";
            this.rbtnAfterDetailsFooter.Checked = true;
            this.cmbForm.SelectedItem = "";
            this.chkLineRepeat.Checked = false;
            this.chkLineNonRepeat.Checked = false;
            this.txtBlankLineCountBetweenTwoPages.Text = "";
            this.txtLineCountForFirstPage.Text = "";
            this.txtLineCountForOtherPage.Text = "";
            this.rbtnPitch12.Checked = true;
            this.rbtnCondensedOn.Checked = true;
            this.txtLineCountAfterPrint.Text = "";
        }

        public void ClearAll()
        {
            if (MessageBox.Show("Are you sure to delete all ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.txtDefaultPass.Text = "";
                this.Clear();
                this.ClearDetails();
                this.pnlDesignImage.Controls.Clear();
                this.dtbl.Rows.Clear();
                this.txtCurrent = null;
                this.inTextId = 0;
                MasterSP rsp = new MasterSP();
                new DetailsSP().DetailsDelete(this.inMasterId);
                rsp.MasterDelate(this.inMasterId);
            }
        }

        public void ClearDetails()
        {
            this.txtRow.Text = "";
            this.txtWidth.Text = "";
            this.txtColumn.Text = "";
            this.rbtnHedder.Checked = true;
            this.cmbFields.SelectedIndex = 0;
            this.txtFieldsForExtra.Text = "";
            this.txtExtraFieldName.Text = "";
            this.cmbTextType.SelectedIndex = 0;
            this.cmbAlign.SelectedIndex = 0;
            this.rbtnOnlyInLastPageFooter.Checked = true;
            this.rbtnOnlyInFirstPAgeHedder.Checked = true;
            this.rbtnHedder.Checked = true;
            this.chkTextWrap.Checked = false;
            this.cmbWrapLineCount.SelectedIndex = 0;
        }

        private void clearDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnClearDetails_Click(sender, e);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void clearMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnClearMaster_Click(sender, e);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearAll();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.txtCurrent != null)
                {
                    if (this.cmbAlign.SelectedIndex == 0)
                    {
                        this.txtCurrent.TextAlign = HorizontalAlignment.Left;
                    }
                    else if (this.cmbAlign.SelectedIndex == 1)
                    {
                        this.txtCurrent.TextAlign = HorizontalAlignment.Center;
                    }
                    else
                    {
                        this.txtCurrent.TextAlign = HorizontalAlignment.Right;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if ((this.txtCurrent != null) && (this.txtCurrent.Name != ""))
                {
                    if (this.cmbFields.SelectedIndex == 0)
                    {
                        this.txtCurrent.ReadOnly = false;
                    }
                    else
                    {
                        this.txtCurrent.ReadOnly = true;
                        this.txtCurrent.Text = this.cmbFields.SelectedValue.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbFieldsForExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.pnlDesignImage.Controls.Clear();
                this.dtbl.Rows.Clear();
                this.txtCurrent = null;
                this.inTextId = 0;
                MasterSP rsp = new MasterSP();
                MasterInfo info = new MasterInfo();
                this.cmbFields.ValueMember = "fieldName";
                this.cmbFields.DisplayMember = "fieldName";
                DataTable table = rsp.FieldsViewAll(int.Parse(this.cmbForm.SelectedValue.ToString()));
                DataRow row = table.NewRow();
                row["fieldName"] = "";
                table.Rows.InsertAt(row, 0);
                this.cmbFields.DataSource = table;
                info = rsp.MasterViewByFormName(int.Parse(this.cmbForm.SelectedValue.ToString()));
                if (info.MasterId != 0)
                {
                    this.inMasterId = info.MasterId;
                    this.txtBlankLineCountAfterDetailsForFooter.Text = info.BlankLneForFooter.ToString();
                    if (info.FooterLocation == "AfterDetails")
                    {
                        this.rbtnAfterDetailsFooter.Checked = true;
                    }
                    else
                    {
                        this.rbtnPageEndFooter.Checked = true;
                    }
                    this.cmbForm.SelectedItem = info.FormName;
                    this.chkLineRepeat.Checked = info.IsTwoLineForDetails;
                    this.chkLineNonRepeat.Checked = info.IsTwoLineForHedder;
                    this.txtBlankLineCountBetweenTwoPages.Text = info.LineCountBetweenTwo.ToString();
                    this.txtLineCountForFirstPage.Text = info.PageSize1.ToString();
                    this.txtLineCountForOtherPage.Text = info.PageSizeOther.ToString();
                    this.rbtnPitch10.Checked = info.Pitch == "10";
                    this.rbtnPitch12.Checked = info.Pitch != "10";
                    this.rbtnCondensedOn.Checked = info.Condensed == "On";
                    this.rbtnCondensedOff.Checked = info.Condensed != "On";
                    this.txtLineCountAfterPrint.Text = info.LineCountAfterPrint.ToString();
                    DetailsSP ssp = new DetailsSP();
                    DataTable table2 = new DataTable();
                    this.dtbl = ssp.DetailsViewAll(this.inMasterId).Copy();
                    TextBox box = new TextBox();
                    foreach (DataRow row2 in this.dtbl.Rows)
                    {
                        this.txtCurrent = null;
                        this.ClearDetails();
                        frmPrintDesigner designer = new frmPrintDesigner();
                        TextBox box2 = new TextBox();
                        if (this.inTextId < int.Parse(row2["name"].ToString()))
                        {
                            this.inTextId = int.Parse(row2["name"].ToString());
                        }
                        box2.Name = row2["name"].ToString();
                        box2.Multiline = true;
                        box2.Size = new Size((int.Parse(row2["width"].ToString()) * 8) + 1, 0x11);
                        box2.Text = row2["text"].ToString();
                        box2.Enter += new EventHandler(this.txtCurrent_Enter);
                        box2.ContextMenuStrip = this.cmsTextBox;
                        box2.TextChanged += new EventHandler(this.txtCurrent_TextChanged);
                        box2.MouseDown += new MouseEventHandler(this.textBox1_MouseDown);
                        box2.MouseUp += new MouseEventHandler(this.textBox1_MouseUp);
                        box2.DragOver += new DragEventHandler(this.textBox1_DragOver);
                        box2.MouseMove += new MouseEventHandler(this.textBox1_MouseMove);
                        box2.Font = new Font("Lucida Console", 10f);
                        this.pnlDesignImage.Controls.Add(box2);
                        box = box2;
                        foreach (Control control in this.pnlDesignImage.Controls)
                        {
                            control.BackColor = Color.AntiqueWhite;
                        }
                        box.BackColor = Color.Gainsboro;
                        this.txtRow.Text = row2["row"].ToString();
                        this.txtColumn.Text = row2["columns"].ToString();
                        this.txtWidth.Text = row2["width"].ToString();
                        if (row2["Repeat"].ToString() == "false")
                        {
                            this.rbtnHedder.Checked = true;
                        }
                        else if (row2["Repeat"].ToString() == "true")
                        {
                            this.rbtnDetails.Checked = true;
                        }
                        else
                        {
                            this.rbtnFooter.Checked = true;
                        }
                        this.cmbAlign.SelectedItem = row2["Align"].ToString();
                        this.cmbFields.SelectedValue = row2["DBF"].ToString();
                        this.cmbTextType.SelectedItem = row2["dOrH"].ToString();
                        this.rbtnAllPageHedder.Checked = bool.Parse(row2["RepeatAllPage"].ToString());
                        this.rbtnOnlyInFirstPAgeHedder.Checked = !bool.Parse(row2["RepeatAllPage"].ToString());
                        this.rbtnInAllPageFooter.Checked = bool.Parse(row2["FooterRepeatAll"].ToString());
                        this.rbtnOnlyInLastPageFooter.Checked = !bool.Parse(row2["FooterRepeatAll"].ToString());
                        this.chkTextWrap.Checked = bool.Parse(row2["textWrap"].ToString());
                        this.cmbWrapLineCount.SelectedItem = row2["wrapLineCount"].ToString();
                        this.txtExtraFieldName.Text = row2["extraFieldName"].ToString();
                        if (this.txtExtraFieldName.Text.Trim() != "")
                        {
                            this.txtFieldsForExtra.Text = row2["fieldsForExtra"].ToString();
                            this.chkExtraField.Checked = true;
                        }
                        else
                        {
                            this.txtFieldsForExtra.Text = "";
                            this.chkExtraField.Checked = false;
                        }
                        if (box != null)
                        {
                            if (this.cmbTextType.SelectedIndex == 0)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Regular);
                            }
                            else if (this.cmbTextType.SelectedIndex == 1)
                            {
                                box.Font = new Font("Lucida Console", 11f, FontStyle.Bold);
                            }
                            else if (this.cmbTextType.SelectedIndex == 2)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Bold);
                            }
                            else if (this.cmbTextType.SelectedIndex == 3)
                            {
                                box.Font = new Font("Lucida Console", 10f, FontStyle.Italic);
                            }
                        }
                        if ((box != null) && (box.Name != ""))
                        {
                            if (this.cmbFields.SelectedIndex == 0)
                            {
                                box.ReadOnly = false;
                            }
                            else
                            {
                                box.ReadOnly = true;
                                box.Text = this.cmbFields.SelectedValue.ToString();
                            }
                        }
                        if (box != null)
                        {
                            if (this.cmbAlign.SelectedIndex == 0)
                            {
                                box.TextAlign = HorizontalAlignment.Left;
                            }
                            else if (this.cmbAlign.SelectedIndex == 1)
                            {
                                box.TextAlign = HorizontalAlignment.Center;
                            }
                            else
                            {
                                box.TextAlign = HorizontalAlignment.Right;
                            }
                        }
                        if (box != null)
                        {
                            box.Location = new Point(int.Parse((this.txtColumn.Text == "") ? "0" : this.txtColumn.Text) * 8, int.Parse((this.txtRow.Text == "") ? "0" : this.txtRow.Text) * 0x10);
                            box.Size = new Size((int.Parse((this.txtWidth.Text == "") ? "5" : this.txtWidth.Text) * 8) + 1, box.Height);
                        }
                    }
                    this.txtCurrent = box;
                }
                else
                {
                    this.inMasterId = 0;
                    this.Clear();
                    this.ClearDetails();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbHedding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.txtCurrent != null)
                {
                    if (this.cmbTextType.SelectedIndex == 0)
                    {
                        this.txtCurrent.Font = new Font("Lucida Console", 10f, FontStyle.Regular);
                    }
                    else if (this.cmbTextType.SelectedIndex == 1)
                    {
                        this.txtCurrent.Font = new Font("Lucida Console", 11f, FontStyle.Bold);
                    }
                    else if (this.cmbTextType.SelectedIndex == 2)
                    {
                        this.txtCurrent.Font = new Font("Lucida Console", 10f, FontStyle.Bold);
                    }
                    else if (this.cmbTextType.SelectedIndex == 3)
                    {
                        this.txtCurrent.Font = new Font("Lucida Console", 10f, FontStyle.Italic);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbWrapLineCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void dBConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDBConnection connection = Application.OpenForms["frmDBConnection"] as frmDBConnection;
            if (connection == null)
            {
                new frmDBConnection().Show();
            }
            else
            {
                connection.Activate();
            }
        }

        public void Delete()
        {
            if ((MessageBox.Show("Are you sure to delete ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes") && (this.txtCurrent != null))
            {
                DataRow[] rowArray = this.dtbl.Select("name='" + this.txtCurrent.Name + "'");
                if (rowArray.Length > 0)
                {
                    this.dtbl.Rows.Remove(rowArray[0]);
                    this.pnlDesignImage.Controls.Remove(this.txtCurrent);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Delete();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FormFill()
        {
            MasterSP rsp = new MasterSP();
            this.cmbForm.DisplayMember = "formName";
            this.cmbForm.ValueMember = "formId";
            this.cmbForm.DataSource = rsp.FormViewAll();
        }

        private void frmPrintDesigner_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && (e.KeyCode == Keys.S))
                {
                    this.Save();
                }
                else if (e.Control && (e.KeyCode == Keys.N))
                {
                    this.New();
                }
                else if (e.Control && (e.KeyCode == Keys.D))
                {
                    this.Delete();
                }
                else if ((e.Control && e.Shift) && (e.KeyCode == Keys.C))
                {
                    this.ClearAll();
                }
                else if (e.Control && (e.KeyCode == Keys.F))
                {
                    this.NewForms();
                }
                else if (e.Alt && (e.KeyCode == Keys.M))
                {
                    if (MessageBox.Show("Are you sure to clear master details ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                    {
                        this.Clear();
                    }
                }
                else if ((e.Alt && (e.KeyCode == Keys.D)) && (MessageBox.Show("Are you sure to clear this field details ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes"))
                {
                    this.ClearDetails();
                    if (this.txtCurrent != null)
                    {
                        this.txtCurrent.Text = this.txtCurrent.Name;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void frmPrintDesigner_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtbl.Columns.Add("name");
                this.dtbl.Columns.Add("text");
                this.dtbl.Columns.Add("row", typeof(decimal));
                this.dtbl.Columns.Add("columns", typeof(decimal));
                this.dtbl.Columns.Add("width", typeof(decimal));
                this.dtbl.Columns.Add("DBF");
                this.dtbl.Columns.Add("dOrH");
                this.dtbl.Columns.Add("Repeat");
                this.dtbl.Columns.Add("Align");
                this.dtbl.Columns.Add("RepeatAllPage");
                this.dtbl.Columns.Add("FooterRepeatAll");
                this.dtbl.Columns.Add("textWrap");
                this.dtbl.Columns.Add("wrapLineCount");
                this.dtbl.Columns.Add("fieldsForExtra");
                this.dtbl.Columns.Add("extraFieldName");
                this.cmbWrapLineCount.SelectedIndex = 0;
                this.cmbTextType.SelectedIndex = 0;
                this.cmbAlign.SelectedIndex = 0;
                this.FormFill();
                obj = this;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmPrintDesigner));
            this.groupBox8 = new Panel();
            this.btnClearDetails = new Button();
            this.groupBox9 = new GroupBox();
            this.label16 = new Label();
            this.label15 = new Label();
            this.chkExtraField = new CheckBox();
            this.txtFieldsForExtra = new TextBox();
            this.txtExtraFieldName = new TextBox();
            this.txtRow = new TextBox();
            this.txtWidth = new TextBox();
            this.groupBox4 = new GroupBox();
            this.label14 = new Label();
            this.cmbWrapLineCount = new ComboBox();
            this.chkTextWrap = new CheckBox();
            this.label1 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            this.label2 = new Label();
            this.cmbTextType = new ComboBox();
            this.label3 = new Label();
            this.cmbFields = new ComboBox();
            this.txtColumn = new TextBox();
            this.label4 = new Label();
            this.cmbAlign = new ComboBox();
            this.gbxFooter = new GroupBox();
            this.rbtnOnlyInLastPageFooter = new RadioButton();
            this.rbtnInAllPageFooter = new RadioButton();
            this.groupBox2 = new GroupBox();
            this.rbtnHedder = new RadioButton();
            this.rbtnFooter = new RadioButton();
            this.rbtnDetails = new RadioButton();
            this.gbxHedder = new GroupBox();
            this.rbtnOnlyInFirstPAgeHedder = new RadioButton();
            this.rbtnAllPageHedder = new RadioButton();
            this.btnPrint = new Button();
            this.label7 = new Label();
            this.cmbForm = new ComboBox();
            this.chkLineRepeat = new CheckBox();
            this.chkLineNonRepeat = new CheckBox();
            this.txtLineCountForFirstPage = new TextBox();
            this.label8 = new Label();
            this.label9 = new Label();
            this.txtMaximumLineCountInFirst = new TextBox();
            this.label10 = new Label();
            this.txtLineCountForOtherPage = new TextBox();
            this.label11 = new Label();
            this.txtMaximumLineCountInOther = new TextBox();
            this.label12 = new Label();
            this.txtBlankLineCountBetweenTwoPages = new TextBox();
            this.groupBox3 = new GroupBox();
            this.rbtnPageEndFooter = new RadioButton();
            this.rbtnAfterDetailsFooter = new RadioButton();
            this.label13 = new Label();
            this.txtBlankLineCountAfterDetailsForFooter = new TextBox();
            this.groupBox6 = new GroupBox();
            this.rbtnPitch10 = new RadioButton();
            this.rbtnPitch12 = new RadioButton();
            this.groupBox5 = new GroupBox();
            this.rbtnCondensedOn = new RadioButton();
            this.rbtnCondensedOff = new RadioButton();
            this.groupBox1 = new GroupBox();
            this.label17 = new Label();
            this.txtLineCountAfterPrint = new TextBox();
            this.btnNew = new Button();
            this.btnDelete = new Button();
            this.btnSave = new Button();
            this.btnClear = new Button();
            this.groupBox7 = new Panel();
            this.btnClearMaster = new Button();
            this.btnAddForms = new Button();
            this.pnlDesignImage = new Panel();
            this.contextMenuStrip1 = new ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new ToolStripMenuItem();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.deleteToolStripMenuItem = new ToolStripMenuItem();
            this.clearToolStripMenuItem1 = new ToolStripMenuItem();
            this.clearMasterToolStripMenuItem = new ToolStripMenuItem();
            this.clearDetailsToolStripMenuItem = new ToolStripMenuItem();
            this.clearToolStripMenuItem = new ToolStripMenuItem();
            this.newFormToolStripMenuItem = new ToolStripMenuItem();
            this.dBConnectionToolStripMenuItem = new ToolStripMenuItem();
            this.cmsTextBox = new ContextMenuStrip(this.components);
            this.takeToolStripMenuItem = new ToolStripMenuItem();
            this.sizeToolStripMenuItem = new ToolStripMenuItem();
            this.btnSelectDefault = new Button();
            this.txtDefaultPass = new TextBox();
            this.btnSaveDefault = new Button();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbxFooter.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxHedder.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.cmsTextBox.SuspendLayout();
            base.SuspendLayout();
            this.groupBox8.BackColor = Color.FromArgb(0xc1, 0xe0, 0xf1);
            this.groupBox8.BorderStyle = BorderStyle.Fixed3D;
            this.groupBox8.Controls.Add(this.btnClearDetails);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Controls.Add(this.txtRow);
            this.groupBox8.Controls.Add(this.txtWidth);
            this.groupBox8.Controls.Add(this.groupBox4);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.cmbTextType);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.cmbFields);
            this.groupBox8.Controls.Add(this.txtColumn);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.cmbAlign);
            this.groupBox8.Controls.Add(this.gbxFooter);
            this.groupBox8.Controls.Add(this.groupBox2);
            this.groupBox8.Controls.Add(this.gbxHedder);
            this.groupBox8.Location = new Point(6, 570);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new Size(0x53f, 0x75);
            this.groupBox8.TabIndex = 2;
            this.btnClearDetails.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnClearDetails.FlatAppearance.BorderColor = Color.White;
            this.btnClearDetails.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClearDetails.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClearDetails.FlatStyle = FlatStyle.Flat;
            this.btnClearDetails.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnClearDetails.ForeColor = Color.White;
            this.btnClearDetails.Location = new Point(0x4c1, 0x58);
            this.btnClearDetails.Name = "btnClearDetails";
            this.btnClearDetails.Size = new Size(90, 0x16);
            this.btnClearDetails.TabIndex = 0x11;
            this.btnClearDetails.Text = "Clear Details";
            this.btnClearDetails.UseVisualStyleBackColor = false;
            this.btnClearDetails.Click += new EventHandler(this.btnClearDetails_Click);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.chkExtraField);
            this.groupBox9.Controls.Add(this.txtFieldsForExtra);
            this.groupBox9.Controls.Add(this.txtExtraFieldName);
            this.groupBox9.Location = new Point(0x403, 10);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new Size(0x127, 0x4b);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Extra Field";
            this.label16.AutoSize = true;
            this.label16.BackColor = Color.Transparent;
            this.label16.Location = new Point(60, 0x33);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x5f, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Master Field Name";
            this.label15.AutoSize = true;
            this.label15.BackColor = Color.Transparent;
            this.label15.Location = new Point(0x44, 30);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x57, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Extra Field Name";
            this.chkExtraField.AutoSize = true;
            this.chkExtraField.BackColor = Color.Transparent;
            this.chkExtraField.Location = new Point(11, 13);
            this.chkExtraField.Name = "chkExtraField";
            this.chkExtraField.Size = new Size(0x4b, 0x11);
            this.chkExtraField.TabIndex = 1;
            this.chkExtraField.Text = "Extra Field";
            this.chkExtraField.UseVisualStyleBackColor = false;
            this.chkExtraField.CheckedChanged += new EventHandler(this.chkExtraField_CheckedChanged);
            this.txtFieldsForExtra.Enabled = false;
            this.txtFieldsForExtra.Location = new Point(0xa1, 0x2d);
            this.txtFieldsForExtra.Name = "txtFieldsForExtra";
            this.txtFieldsForExtra.Size = new Size(0x79, 20);
            this.txtFieldsForExtra.TabIndex = 3;
            this.txtFieldsForExtra.TextChanged += new EventHandler(this.cmbFieldsForExtra_SelectedIndexChanged);
            this.txtExtraFieldName.Enabled = false;
            this.txtExtraFieldName.Location = new Point(0xa1, 0x17);
            this.txtExtraFieldName.Name = "txtExtraFieldName";
            this.txtExtraFieldName.Size = new Size(0x79, 20);
            this.txtExtraFieldName.TabIndex = 2;
            this.txtExtraFieldName.TextChanged += new EventHandler(this.txtExtraFieldName_TextChanged);
            this.txtRow.Location = new Point(0x38, 0x13);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new Size(0x2f, 20);
            this.txtRow.TabIndex = 0;
            this.txtRow.TextChanged += new EventHandler(this.txtLocationX_TextChanged);
            this.txtRow.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.txtWidth.Location = new Point(0x38, 0x41);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new Size(0x2f, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.TextChanged += new EventHandler(this.txtWidth_TextChanged);
            this.txtWidth.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cmbWrapLineCount);
            this.groupBox4.Controls.Add(this.chkTextWrap);
            this.groupBox4.Location = new Point(0x152, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xa2, 0x4b);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text Wrap";
            this.label14.AutoSize = true;
            this.label14.BackColor = Color.Transparent;
            this.label14.Location = new Point(12, 0x2e);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x57, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Wrap Line Count";
            this.cmbWrapLineCount.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWrapLineCount.Enabled = false;
            this.cmbWrapLineCount.FormattingEnabled = true;
            this.cmbWrapLineCount.Items.AddRange(new object[] { "1", "2" });
            this.cmbWrapLineCount.Location = new Point(0x67, 0x27);
            this.cmbWrapLineCount.Name = "cmbWrapLineCount";
            this.cmbWrapLineCount.Size = new Size(0x33, 0x15);
            this.cmbWrapLineCount.TabIndex = 1;
            this.cmbWrapLineCount.SelectedIndexChanged += new EventHandler(this.cmbWrapLineCount_SelectedIndexChanged);
            this.chkTextWrap.AutoSize = true;
            this.chkTextWrap.BackColor = Color.Transparent;
            this.chkTextWrap.Location = new Point(11, 20);
            this.chkTextWrap.Name = "chkTextWrap";
            this.chkTextWrap.Size = new Size(0x4f, 0x11);
            this.chkTextWrap.TabIndex = 0;
            this.chkTextWrap.Text = "Text Wrap ";
            this.chkTextWrap.UseVisualStyleBackColor = false;
            this.chkTextWrap.CheckedChanged += new EventHandler(this.chkTextWrap_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Location = new Point(0x13, 0x1a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Row";
            this.label6.AutoSize = true;
            this.label6.BackColor = Color.Transparent;
            this.label6.Location = new Point(0x90, 0x1a);
            this.label6.Name = "label6";
            this.label6.Size = new Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Align";
            this.label5.AutoSize = true;
            this.label5.BackColor = Color.Transparent;
            this.label5.Location = new Point(0x77, 0x48);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Data Field";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Location = new Point(6, 0x31);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x2a, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Column";
            this.cmbTextType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTextType.FormattingEnabled = true;
            this.cmbTextType.Items.AddRange(new object[] { "Normal", "Hedding", "Bold", "Italic" });
            this.cmbTextType.Location = new Point(0xb7, 0x29);
            this.cmbTextType.Name = "cmbTextType";
            this.cmbTextType.Size = new Size(0x79, 0x15);
            this.cmbTextType.TabIndex = 4;
            this.cmbTextType.SelectedIndexChanged += new EventHandler(this.cmbHedding_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.BackColor = Color.Transparent;
            this.label3.Location = new Point(13, 0x48);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x23, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Width";
            this.cmbFields.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbFields.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbFields.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFields.FormattingEnabled = true;
            this.cmbFields.Location = new Point(0xb7, 0x40);
            this.cmbFields.Name = "cmbFields";
            this.cmbFields.Size = new Size(0x79, 0x15);
            this.cmbFields.TabIndex = 5;
            this.cmbFields.SelectedIndexChanged += new EventHandler(this.cmbDataBase_SelectedIndexChanged);
            this.txtColumn.Location = new Point(0x38, 0x2a);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new Size(0x2f, 20);
            this.txtColumn.TabIndex = 1;
            this.txtColumn.TextChanged += new EventHandler(this.txtLocationX_TextChanged);
            this.txtColumn.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Location = new Point(0x77, 0x31);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Text Type";
            this.cmbAlign.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAlign.FormattingEnabled = true;
            this.cmbAlign.Items.AddRange(new object[] { "Left", "Center", "Right" });
            this.cmbAlign.Location = new Point(0xb7, 0x12);
            this.cmbAlign.Name = "cmbAlign";
            this.cmbAlign.Size = new Size(0x79, 0x15);
            this.cmbAlign.TabIndex = 3;
            this.cmbAlign.SelectedIndexChanged += new EventHandler(this.cmbAlign_SelectedIndexChanged);
            this.gbxFooter.Controls.Add(this.rbtnOnlyInLastPageFooter);
            this.gbxFooter.Controls.Add(this.rbtnInAllPageFooter);
            this.gbxFooter.Location = new Point(850, 10);
            this.gbxFooter.Name = "gbxFooter";
            this.gbxFooter.Size = new Size(0x92, 0x4b);
            this.gbxFooter.TabIndex = 9;
            this.gbxFooter.TabStop = false;
            this.gbxFooter.Text = "Footers";
            this.rbtnOnlyInLastPageFooter.AutoSize = true;
            this.rbtnOnlyInLastPageFooter.BackColor = Color.Transparent;
            this.rbtnOnlyInLastPageFooter.Checked = true;
            this.rbtnOnlyInLastPageFooter.Location = new Point(0x13, 0x18);
            this.rbtnOnlyInLastPageFooter.Name = "rbtnOnlyInLastPageFooter";
            this.rbtnOnlyInLastPageFooter.Size = new Size(0x6d, 0x11);
            this.rbtnOnlyInLastPageFooter.TabIndex = 0;
            this.rbtnOnlyInLastPageFooter.TabStop = true;
            this.rbtnOnlyInLastPageFooter.Text = "Only In Last Page";
            this.rbtnOnlyInLastPageFooter.UseVisualStyleBackColor = false;
            this.rbtnInAllPageFooter.AutoSize = true;
            this.rbtnInAllPageFooter.BackColor = Color.Transparent;
            this.rbtnInAllPageFooter.Location = new Point(0x13, 0x2d);
            this.rbtnInAllPageFooter.Name = "rbtnInAllPageFooter";
            this.rbtnInAllPageFooter.Size = new Size(0x4c, 0x11);
            this.rbtnInAllPageFooter.TabIndex = 1;
            this.rbtnInAllPageFooter.Text = "In All Page";
            this.rbtnInAllPageFooter.UseVisualStyleBackColor = false;
            this.rbtnInAllPageFooter.CheckedChanged += new EventHandler(this.rbtnFAllPage_CheckedChanged);
            this.groupBox2.Controls.Add(this.rbtnHedder);
            this.groupBox2.Controls.Add(this.rbtnFooter);
            this.groupBox2.Controls.Add(this.rbtnDetails);
            this.groupBox2.Location = new Point(0x214, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x79, 0x4b);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Repeat";
            this.rbtnHedder.AutoSize = true;
            this.rbtnHedder.BackColor = Color.Transparent;
            this.rbtnHedder.Checked = true;
            this.rbtnHedder.Location = new Point(0x20, 14);
            this.rbtnHedder.Name = "rbtnHedder";
            this.rbtnHedder.Size = new Size(60, 0x11);
            this.rbtnHedder.TabIndex = 0;
            this.rbtnHedder.TabStop = true;
            this.rbtnHedder.Text = "Hedder";
            this.rbtnHedder.UseVisualStyleBackColor = false;
            this.rbtnHedder.CheckedChanged += new EventHandler(this.rbtnNotRepeat_CheckedChanged);
            this.rbtnFooter.AutoSize = true;
            this.rbtnFooter.BackColor = Color.Transparent;
            this.rbtnFooter.Location = new Point(0x20, 0x31);
            this.rbtnFooter.Name = "rbtnFooter";
            this.rbtnFooter.Size = new Size(0x37, 0x11);
            this.rbtnFooter.TabIndex = 2;
            this.rbtnFooter.Text = "Footer";
            this.rbtnFooter.UseVisualStyleBackColor = false;
            this.rbtnDetails.AutoSize = true;
            this.rbtnDetails.BackColor = Color.Transparent;
            this.rbtnDetails.Location = new Point(0x20, 0x1f);
            this.rbtnDetails.Name = "rbtnDetails";
            this.rbtnDetails.Size = new Size(0x39, 0x11);
            this.rbtnDetails.TabIndex = 1;
            this.rbtnDetails.Text = "Details";
            this.rbtnDetails.UseVisualStyleBackColor = false;
            this.rbtnDetails.CheckedChanged += new EventHandler(this.rbtnRepeat_CheckedChanged);
            this.gbxHedder.Controls.Add(this.rbtnOnlyInFirstPAgeHedder);
            this.gbxHedder.Controls.Add(this.rbtnAllPageHedder);
            this.gbxHedder.Location = new Point(0x2ae, 10);
            this.gbxHedder.Name = "gbxHedder";
            this.gbxHedder.Size = new Size(0x86, 0x4b);
            this.gbxHedder.TabIndex = 8;
            this.gbxHedder.TabStop = false;
            this.gbxHedder.Text = "Hedders";
            this.rbtnOnlyInFirstPAgeHedder.AutoSize = true;
            this.rbtnOnlyInFirstPAgeHedder.BackColor = Color.Transparent;
            this.rbtnOnlyInFirstPAgeHedder.Checked = true;
            this.rbtnOnlyInFirstPAgeHedder.Location = new Point(0x13, 0x17);
            this.rbtnOnlyInFirstPAgeHedder.Name = "rbtnOnlyInFirstPAgeHedder";
            this.rbtnOnlyInFirstPAgeHedder.Size = new Size(0x6c, 0x11);
            this.rbtnOnlyInFirstPAgeHedder.TabIndex = 0;
            this.rbtnOnlyInFirstPAgeHedder.TabStop = true;
            this.rbtnOnlyInFirstPAgeHedder.Text = "Only In First Page";
            this.rbtnOnlyInFirstPAgeHedder.UseVisualStyleBackColor = false;
            this.rbtnOnlyInFirstPAgeHedder.CheckedChanged += new EventHandler(this.rbtnHedderFirst_CheckedChanged);
            this.rbtnAllPageHedder.AutoSize = true;
            this.rbtnAllPageHedder.BackColor = Color.Transparent;
            this.rbtnAllPageHedder.Location = new Point(0x13, 0x2b);
            this.rbtnAllPageHedder.Name = "rbtnAllPageHedder";
            this.rbtnAllPageHedder.Size = new Size(0x4c, 0x11);
            this.rbtnAllPageHedder.TabIndex = 1;
            this.rbtnAllPageHedder.Text = "In All Page";
            this.rbtnAllPageHedder.UseVisualStyleBackColor = false;
            this.btnPrint.Location = new Point(9, 690);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new Size(0x4b, 0x17);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new EventHandler(this.btnPrint_Click);
            this.label7.AutoSize = true;
            this.label7.BackColor = Color.Transparent;
            this.label7.Location = new Point(6, 0x2b);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3d, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Form Name";
            this.cmbForm.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbForm.FormattingEnabled = true;
            this.cmbForm.Location = new Point(0x48, 0x22);
            this.cmbForm.Name = "cmbForm";
            this.cmbForm.Size = new Size(0x98, 0x15);
            this.cmbForm.TabIndex = 0;
            this.cmbForm.SelectedIndexChanged += new EventHandler(this.cmbForm_SelectedIndexChanged);
            this.chkLineRepeat.AutoSize = true;
            this.chkLineRepeat.Location = new Point(0x6d, 0x185);
            this.chkLineRepeat.Name = "chkLineRepeat";
            this.chkLineRepeat.RightToLeft = RightToLeft.Yes;
            this.chkLineRepeat.Size = new Size(0x81, 0x11);
            this.chkLineRepeat.TabIndex = 9;
            this.chkLineRepeat.Text = "Text Wrap For Details";
            this.chkLineRepeat.UseVisualStyleBackColor = true;
            this.chkLineRepeat.Visible = false;
            this.chkLineRepeat.CheckedChanged += new EventHandler(this.chkLineRepeat_CheckedChanged);
            this.chkLineNonRepeat.AutoSize = true;
            this.chkLineNonRepeat.Location = new Point(0x26, 0x175);
            this.chkLineNonRepeat.Name = "chkLineNonRepeat";
            this.chkLineNonRepeat.RightToLeft = RightToLeft.Yes;
            this.chkLineNonRepeat.Size = new Size(0xae, 0x11);
            this.chkLineNonRepeat.TabIndex = 9;
            this.chkLineNonRepeat.Text = "Text Wrap For Hedder && Footer";
            this.chkLineNonRepeat.UseVisualStyleBackColor = true;
            this.chkLineNonRepeat.Visible = false;
            this.chkLineNonRepeat.CheckedChanged += new EventHandler(this.chkLine_CheckedChanged);
            this.txtLineCountForFirstPage.BackColor = Color.White;
            this.txtLineCountForFirstPage.Location = new Point(0xb9, 20);
            this.txtLineCountForFirstPage.Name = "txtLineCountForFirstPage";
            this.txtLineCountForFirstPage.Size = new Size(0x2c, 20);
            this.txtLineCountForFirstPage.TabIndex = 0;
            this.txtLineCountForFirstPage.TextChanged += new EventHandler(this.txtPageSize_TextChanged);
            this.txtLineCountForFirstPage.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.label8.AutoSize = true;
            this.label8.BackColor = Color.Transparent;
            this.label8.Location = new Point(7, 0x1b);
            this.label8.Name = "label8";
            this.label8.Size = new Size(170, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Line Count For First Page  (Details)";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x67, 0x175);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x8e, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Max Line cnt in First (Details)";
            this.label9.Visible = false;
            this.txtMaximumLineCountInFirst.Location = new Point(0x6a, 0x185);
            this.txtMaximumLineCountInFirst.Name = "txtMaximumLineCountInFirst";
            this.txtMaximumLineCountInFirst.Size = new Size(0x7e, 20);
            this.txtMaximumLineCountInFirst.TabIndex = 13;
            this.txtMaximumLineCountInFirst.Visible = false;
            this.txtMaximumLineCountInFirst.TextChanged += new EventHandler(this.txtMaximumLineCount_TextChanged);
            this.label10.AutoSize = true;
            this.label10.BackColor = Color.Transparent;
            this.label10.Location = new Point(3, 0x38);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0xae, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Line Count For Other Page (Details)";
            this.txtLineCountForOtherPage.Location = new Point(0xb9, 0x31);
            this.txtLineCountForOtherPage.Name = "txtLineCountForOtherPage";
            this.txtLineCountForOtherPage.Size = new Size(0x2c, 20);
            this.txtLineCountForOtherPage.TabIndex = 1;
            this.txtLineCountForOtherPage.TextChanged += new EventHandler(this.txtPageSizeinOther_TextChanged);
            this.txtLineCountForOtherPage.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.label11.AutoSize = true;
            this.label11.Location = new Point(8, 0x175);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x95, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Max Line cnt in Other (Details)";
            this.label11.Visible = false;
            this.txtMaximumLineCountInOther.Location = new Point(11, 0x185);
            this.txtMaximumLineCountInOther.Name = "txtMaximumLineCountInOther";
            this.txtMaximumLineCountInOther.Size = new Size(0x7e, 20);
            this.txtMaximumLineCountInOther.TabIndex = 13;
            this.txtMaximumLineCountInOther.Visible = false;
            this.txtMaximumLineCountInOther.TextChanged += new EventHandler(this.txtMaximumLineCountInOther_TextChanged);
            this.label12.AutoSize = true;
            this.label12.BackColor = Color.Transparent;
            this.label12.Location = new Point(2, 0x53);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0xaf, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Blank Line Count Between 2 Pages";
            this.txtBlankLineCountBetweenTwoPages.Location = new Point(0xb9, 0x4c);
            this.txtBlankLineCountBetweenTwoPages.Name = "txtBlankLineCountBetweenTwoPages";
            this.txtBlankLineCountBetweenTwoPages.Size = new Size(0x2c, 20);
            this.txtBlankLineCountBetweenTwoPages.TabIndex = 2;
            this.txtBlankLineCountBetweenTwoPages.TextChanged += new EventHandler(this.txtLinecountBetweenTwoPages_TextChanged);
            this.txtBlankLineCountBetweenTwoPages.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.groupBox3.Controls.Add(this.rbtnPageEndFooter);
            this.groupBox3.Controls.Add(this.rbtnAfterDetailsFooter);
            this.groupBox3.Location = new Point(4, 0xce);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0xee, 0x39);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Footer Position";
            this.rbtnPageEndFooter.AutoSize = true;
            this.rbtnPageEndFooter.BackColor = Color.Transparent;
            this.rbtnPageEndFooter.Location = new Point(140, 0x19);
            this.rbtnPageEndFooter.Name = "rbtnPageEndFooter";
            this.rbtnPageEndFooter.Size = new Size(0x48, 0x11);
            this.rbtnPageEndFooter.TabIndex = 0;
            this.rbtnPageEndFooter.Text = "Page End";
            this.rbtnPageEndFooter.UseVisualStyleBackColor = false;
            this.rbtnAfterDetailsFooter.AutoSize = true;
            this.rbtnAfterDetailsFooter.BackColor = Color.Transparent;
            this.rbtnAfterDetailsFooter.Checked = true;
            this.rbtnAfterDetailsFooter.Location = new Point(0x22, 0x19);
            this.rbtnAfterDetailsFooter.Name = "rbtnAfterDetailsFooter";
            this.rbtnAfterDetailsFooter.Size = new Size(0x52, 0x11);
            this.rbtnAfterDetailsFooter.TabIndex = 0;
            this.rbtnAfterDetailsFooter.TabStop = true;
            this.rbtnAfterDetailsFooter.Text = "After Details";
            this.rbtnAfterDetailsFooter.UseVisualStyleBackColor = false;
            this.rbtnAfterDetailsFooter.CheckedChanged += new EventHandler(this.rbtnAfterDetails_CheckedChanged);
            this.label13.AutoSize = true;
            this.label13.BackColor = Color.Transparent;
            this.label13.Location = new Point(20, 0x70);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x9d, 13);
            this.label13.TabIndex = 0x10;
            this.label13.Text = "Lines Between Footer &&  Details";
            this.txtBlankLineCountAfterDetailsForFooter.BackColor = Color.White;
            this.txtBlankLineCountAfterDetailsForFooter.Location = new Point(0xb9, 0x69);
            this.txtBlankLineCountAfterDetailsForFooter.Name = "txtBlankLineCountAfterDetailsForFooter";
            this.txtBlankLineCountAfterDetailsForFooter.Size = new Size(0x2c, 20);
            this.txtBlankLineCountAfterDetailsForFooter.TabIndex = 1;
            this.txtBlankLineCountAfterDetailsForFooter.TextChanged += new EventHandler(this.txtBlankLine_TextChanged);
            this.txtBlankLineCountAfterDetailsForFooter.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.groupBox6.Controls.Add(this.rbtnPitch10);
            this.groupBox6.Controls.Add(this.rbtnPitch12);
            this.groupBox6.Location = new Point(4, 0x111);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x71, 0x30);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Pitch";
            this.rbtnPitch10.AutoSize = true;
            this.rbtnPitch10.BackColor = Color.Transparent;
            this.rbtnPitch10.Location = new Point(14, 0x12);
            this.rbtnPitch10.Name = "rbtnPitch10";
            this.rbtnPitch10.Size = new Size(0x25, 0x11);
            this.rbtnPitch10.TabIndex = 0;
            this.rbtnPitch10.Text = "10";
            this.rbtnPitch10.UseVisualStyleBackColor = false;
            this.rbtnPitch12.AutoSize = true;
            this.rbtnPitch12.BackColor = Color.Transparent;
            this.rbtnPitch12.Checked = true;
            this.rbtnPitch12.Location = new Point(60, 0x12);
            this.rbtnPitch12.Name = "rbtnPitch12";
            this.rbtnPitch12.Size = new Size(0x25, 0x11);
            this.rbtnPitch12.TabIndex = 1;
            this.rbtnPitch12.TabStop = true;
            this.rbtnPitch12.Text = "12";
            this.rbtnPitch12.UseVisualStyleBackColor = false;
            this.rbtnPitch12.CheckedChanged += new EventHandler(this.rbtnPitch12_CheckedChanged);
            this.groupBox5.Controls.Add(this.rbtnCondensedOn);
            this.groupBox5.Controls.Add(this.rbtnCondensedOff);
            this.groupBox5.Location = new Point(0x85, 0x111);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x6d, 0x2f);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Condensed";
            this.rbtnCondensedOn.AutoSize = true;
            this.rbtnCondensedOn.BackColor = Color.Transparent;
            this.rbtnCondensedOn.Checked = true;
            this.rbtnCondensedOn.Location = new Point(10, 0x12);
            this.rbtnCondensedOn.Name = "rbtnCondensedOn";
            this.rbtnCondensedOn.Size = new Size(0x27, 0x11);
            this.rbtnCondensedOn.TabIndex = 0;
            this.rbtnCondensedOn.TabStop = true;
            this.rbtnCondensedOn.Text = "On";
            this.rbtnCondensedOn.UseVisualStyleBackColor = false;
            this.rbtnCondensedOn.CheckedChanged += new EventHandler(this.rbtnCondensedOn_CheckedChanged);
            this.rbtnCondensedOff.AutoSize = true;
            this.rbtnCondensedOff.BackColor = Color.Transparent;
            this.rbtnCondensedOff.Location = new Point(0x3e, 0x12);
            this.rbtnCondensedOff.Name = "rbtnCondensedOff";
            this.rbtnCondensedOff.Size = new Size(0x27, 0x11);
            this.rbtnCondensedOff.TabIndex = 1;
            this.rbtnCondensedOff.Text = "Off";
            this.rbtnCondensedOff.UseVisualStyleBackColor = false;
            this.rbtnCondensedOff.CheckedChanged += new EventHandler(this.rbtnAfterDetails_CheckedChanged);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtLineCountForFirstPage);
            this.groupBox1.Controls.Add(this.txtLineCountAfterPrint);
            this.groupBox1.Controls.Add(this.txtBlankLineCountAfterDetailsForFooter);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtLineCountForOtherPage);
            this.groupBox1.Controls.Add(this.txtBlankLineCountBetweenTwoPages);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new Point(5, 0x18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xeb, 0xac);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Line Counts";
            this.groupBox1.Enter += new EventHandler(this.groupBox1_Enter);
            this.label17.AutoSize = true;
            this.label17.BackColor = Color.Transparent;
            this.label17.Location = new Point(70, 0x8d);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x6b, 13);
            this.label17.TabIndex = 0x10;
            this.label17.Text = "Line Count After Print";
            this.txtLineCountAfterPrint.BackColor = Color.White;
            this.txtLineCountAfterPrint.Location = new Point(0xb9, 0x86);
            this.txtLineCountAfterPrint.Name = "txtLineCountAfterPrint";
            this.txtLineCountAfterPrint.Size = new Size(0x2c, 20);
            this.txtLineCountAfterPrint.TabIndex = 1;
            this.txtLineCountAfterPrint.TextChanged += new EventHandler(this.txtBlankLine_TextChanged);
            this.txtLineCountAfterPrint.KeyPress += new KeyPressEventHandler(this.txtBlankLine_KeyPress);
            this.btnNew.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnNew.FlatAppearance.BorderColor = Color.White;
            this.btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnNew.FlatStyle = FlatStyle.Flat;
            this.btnNew.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnNew.ForeColor = Color.White;
            this.btnNew.Location = new Point(0x89, 0x1b6);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new Size(0x73, 0x16);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new EventHandler(this.btnNew_Click);
            this.btnDelete.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnDelete.FlatAppearance.BorderColor = Color.White;
            this.btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(7, 0x1d0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x7c, 0x16);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnSave.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnSave.FlatAppearance.BorderColor = Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(7, 0x1b6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x7c, 0x16);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnClear.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnClear.FlatAppearance.BorderColor = Color.White;
            this.btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(0x89, 0x1d0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x73, 0x16);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Delete All";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.groupBox7.BackColor = Color.FromArgb(0xc1, 0xe0, 0xf1);
            this.groupBox7.BorderStyle = BorderStyle.Fixed3D;
            this.groupBox7.Controls.Add(this.btnClearMaster);
            this.groupBox7.Controls.Add(this.chkLineRepeat);
            this.groupBox7.Controls.Add(this.txtMaximumLineCountInOther);
            this.groupBox7.Controls.Add(this.groupBox1);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.chkLineNonRepeat);
            this.groupBox7.Controls.Add(this.groupBox5);
            this.groupBox7.Controls.Add(this.groupBox3);
            this.groupBox7.Controls.Add(this.txtMaximumLineCountInFirst);
            this.groupBox7.Controls.Add(this.groupBox6);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Location = new Point(6, 0x3e);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new Size(0xf6, 370);
            this.groupBox7.TabIndex = 1;
            this.btnClearMaster.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnClearMaster.FlatAppearance.BorderColor = Color.White;
            this.btnClearMaster.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClearMaster.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClearMaster.FlatStyle = FlatStyle.Flat;
            this.btnClearMaster.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnClearMaster.ForeColor = Color.White;
            this.btnClearMaster.Location = new Point(0x93, 0x146);
            this.btnClearMaster.Name = "btnClearMaster";
            this.btnClearMaster.Size = new Size(90, 0x16);
            this.btnClearMaster.TabIndex = 7;
            this.btnClearMaster.Text = "Clear Master";
            this.btnClearMaster.UseVisualStyleBackColor = false;
            this.btnClearMaster.Click += new EventHandler(this.btnClearMaster_Click);
            this.btnAddForms.BackgroundImage = Resources.AddNew1;
            this.btnAddForms.BackgroundImageLayout = ImageLayout.Stretch;
            this.btnAddForms.FlatAppearance.BorderSize = 0;
            this.btnAddForms.FlatStyle = FlatStyle.Flat;
            this.btnAddForms.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.btnAddForms.Location = new Point(0xe4, 0x22);
            this.btnAddForms.Name = "btnAddForms";
            this.btnAddForms.Size = new Size(0x17, 0x16);
            this.btnAddForms.TabIndex = 6;
            this.btnAddForms.TextAlign = ContentAlignment.TopCenter;
            this.btnAddForms.UseVisualStyleBackColor = true;
            this.btnAddForms.Click += new EventHandler(this.btnAddForms_Click);
            this.pnlDesignImage.AutoScroll = true;
            this.pnlDesignImage.BackgroundImage = Resources.PrintDesignImage;
            this.pnlDesignImage.BorderStyle = BorderStyle.Fixed3D;
            this.pnlDesignImage.Location = new Point(0x101, 0x17);
            this.pnlDesignImage.Name = "pnlDesignImage";
            this.pnlDesignImage.Size = new Size(0x444, 0x21d);
            this.pnlDesignImage.TabIndex = 0;
            this.pnlDesignImage.MouseClick += new MouseEventHandler(this.pnlDesignImage_MouseClick);
            this.contextMenuStrip1.Items.AddRange(new ToolStripItem[] { this.newToolStripMenuItem, this.saveToolStripMenuItem, this.deleteToolStripMenuItem, this.clearToolStripMenuItem1, this.newFormToolStripMenuItem, this.dBConnectionToolStripMenuItem });
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new Size(0xac, 0x88);
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            this.newToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            this.saveToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            this.deleteToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new EventHandler(this.deleteToolStripMenuItem_Click);
            this.clearToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { this.clearMasterToolStripMenuItem, this.clearDetailsToolStripMenuItem, this.clearToolStripMenuItem });
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new Size(0xab, 0x16);
            this.clearToolStripMenuItem1.Text = "Clear";
            this.clearMasterToolStripMenuItem.Name = "clearMasterToolStripMenuItem";
            this.clearMasterToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.M;
            this.clearMasterToolStripMenuItem.Size = new Size(0xc1, 0x16);
            this.clearMasterToolStripMenuItem.Text = "Clear Master";
            this.clearMasterToolStripMenuItem.Click += new EventHandler(this.clearMasterToolStripMenuItem_Click);
            this.clearDetailsToolStripMenuItem.Name = "clearDetailsToolStripMenuItem";
            this.clearDetailsToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D;
            this.clearDetailsToolStripMenuItem.Size = new Size(0xc1, 0x16);
            this.clearDetailsToolStripMenuItem.Text = "Clear Details";
            this.clearDetailsToolStripMenuItem.Click += new EventHandler(this.clearDetailsToolStripMenuItem_Click);
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.C;
            this.clearToolStripMenuItem.Size = new Size(0xc1, 0x16);
            this.clearToolStripMenuItem.Text = "Clear All";
            this.clearToolStripMenuItem.Click += new EventHandler(this.clearToolStripMenuItem_Click);
            this.newFormToolStripMenuItem.Name = "newFormToolStripMenuItem";
            this.newFormToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            this.newFormToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.newFormToolStripMenuItem.Text = "New Form";
            this.newFormToolStripMenuItem.Click += new EventHandler(this.newFormToolStripMenuItem_Click);
            this.dBConnectionToolStripMenuItem.Name = "dBConnectionToolStripMenuItem";
            this.dBConnectionToolStripMenuItem.Size = new Size(0xab, 0x16);
            this.dBConnectionToolStripMenuItem.Text = "DB Connection";
            this.dBConnectionToolStripMenuItem.Click += new EventHandler(this.dBConnectionToolStripMenuItem_Click);
            this.cmsTextBox.Items.AddRange(new ToolStripItem[] { this.takeToolStripMenuItem, this.sizeToolStripMenuItem });
            this.cmsTextBox.Name = "cmsTextBox";
            this.cmsTextBox.Size = new Size(0x76, 0x30);
            this.takeToolStripMenuItem.Name = "takeToolStripMenuItem";
            this.takeToolStripMenuItem.Size = new Size(0x75, 0x16);
            this.takeToolStripMenuItem.Text = "Take ";
            this.takeToolStripMenuItem.Click += new EventHandler(this.takeToolStripMenuItem_Click);
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new Size(0x75, 0x16);
            this.sizeToolStripMenuItem.Text = "Cancel";
            this.sizeToolStripMenuItem.Click += new EventHandler(this.sizeToolStripMenuItem_Click);
            this.btnSelectDefault.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnSelectDefault.FlatAppearance.BorderColor = Color.White;
            this.btnSelectDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSelectDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSelectDefault.FlatStyle = FlatStyle.Flat;
            this.btnSelectDefault.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnSelectDefault.ForeColor = Color.White;
            this.btnSelectDefault.Location = new Point(8, 540);
            this.btnSelectDefault.Name = "btnSelectDefault";
            this.btnSelectDefault.Size = new Size(0xf5, 0x16);
            this.btnSelectDefault.TabIndex = 0x19;
            this.btnSelectDefault.Text = "Select Default";
            this.btnSelectDefault.UseVisualStyleBackColor = false;
            this.btnSelectDefault.Click += new EventHandler(this.btnSelectDefault_Click);
            this.txtDefaultPass.Location = new Point(7, 0x1eb);
            this.txtDefaultPass.Name = "txtDefaultPass";
            this.txtDefaultPass.PasswordChar = '*';
            this.txtDefaultPass.Size = new Size(0xf6, 20);
            this.txtDefaultPass.TabIndex = 0x17;
            this.btnSaveDefault.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnSaveDefault.FlatAppearance.BorderColor = Color.White;
            this.btnSaveDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSaveDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSaveDefault.FlatStyle = FlatStyle.Flat;
            this.btnSaveDefault.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnSaveDefault.ForeColor = Color.White;
            this.btnSaveDefault.Location = new Point(8, 0x203);
            this.btnSaveDefault.Name = "btnSaveDefault";
            this.btnSaveDefault.Size = new Size(0xf5, 0x16);
            this.btnSaveDefault.TabIndex = 0x18;
            this.btnSaveDefault.Text = "Save As Default";
            this.btnSaveDefault.UseVisualStyleBackColor = false;
            this.btnSaveDefault.Click += new EventHandler(this.btnSaveDefault_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(90, 0xa9, 0xe2);
            base.ClientSize = new Size(0x554, 0x2c4);
            this.ContextMenuStrip = this.contextMenuStrip1;
            base.Controls.Add(this.btnSelectDefault);
            base.Controls.Add(this.txtDefaultPass);
            base.Controls.Add(this.btnSaveDefault);
            base.Controls.Add(this.btnAddForms);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.groupBox7);
            base.Controls.Add(this.cmbForm);
            base.Controls.Add(this.btnNew);
            base.Controls.Add(this.groupBox8);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.btnClear);
            base.Controls.Add(this.pnlDesignImage);
            base.Controls.Add(this.btnPrint);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.Name = "frmPrintDesigner";
            this.Text = "Print Designer";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmPrintDesigner_Load);
            base.KeyDown += new KeyEventHandler(this.frmPrintDesigner_KeyDown);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbxFooter.ResumeLayout(false);
            this.gbxFooter.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxHedder.ResumeLayout(false);
            this.gbxHedder.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.cmsTextBox.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void New()
        {
            this.txtCurrent = null;
            this.ClearDetails();
            frmPrintDesigner designer = new frmPrintDesigner();
            TextBox box = new TextBox();
            this.inTextId++;
            box.Name = this.inTextId.ToString();
            box.Multiline = true;
            box.Size = new Size(0x29, 0x11);
            box.Text = this.inTextId.ToString();
            box.ContextMenuStrip = this.cmsTextBox;
            box.Enter += new EventHandler(this.txtCurrent_Enter);
            box.TextChanged += new EventHandler(this.txtCurrent_TextChanged);
            box.MouseDown += new MouseEventHandler(this.textBox1_MouseDown);
            box.MouseUp += new MouseEventHandler(this.textBox1_MouseUp);
            box.DragOver += new DragEventHandler(this.textBox1_DragOver);
            box.MouseMove += new MouseEventHandler(this.textBox1_MouseMove);
            box.Font = new Font("Lucida Console", 10f);
            this.pnlDesignImage.Controls.Add(box);
            this.txtCurrent = box;
            foreach (Control control in this.pnlDesignImage.Controls)
            {
                control.BackColor = Color.AntiqueWhite;
            }
            this.txtCurrent.BackColor = Color.Gainsboro;
            this.dtbl.Rows.Add(new object[0]);
            int num = this.dtbl.Rows.Count - 1;
            this.dtbl.Rows[num]["name"] = box.Name;
            this.dtbl.Rows[num]["text"] = box.Text;
            this.dtbl.Rows[num]["row"] = 0;
            this.dtbl.Rows[num]["columns"] = 0;
            this.dtbl.Rows[num]["width"] = 5;
            this.dtbl.Rows[num]["DBF"] = this.cmbFields.SelectedValue.ToString();
            this.dtbl.Rows[num]["dOrH"] = this.cmbTextType.SelectedItem;
            this.dtbl.Rows[num]["Repeat"] = this.rbtnDetails.Checked ? "true" : (this.rbtnFooter.Checked ? "Footer" : "false");
            this.dtbl.Rows[num]["Align"] = this.cmbAlign.SelectedItem;
            this.dtbl.Rows[num]["RepeatAllPage"] = this.rbtnAllPageHedder.Checked;
            this.dtbl.Rows[num]["FooterRepeatAll"] = this.rbtnInAllPageFooter.Checked;
            this.dtbl.Rows[num]["textWrap"] = this.chkTextWrap.Checked;
            this.dtbl.Rows[num]["wrapLineCount"] = this.cmbWrapLineCount.SelectedItem;
            this.dtbl.Rows[num]["fieldsForExtra"] = this.txtFieldsForExtra.Text;
            this.dtbl.Rows[num]["extraFieldName"] = this.txtExtraFieldName.Text;
        }

        public void NewForms()
        {
            frmForms forms = Application.OpenForms["frmForms"] as frmForms;
            if (forms == null)
            {
                new frmForms().Show();
            }
            else
            {
                forms.Activate();
            }
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.NewForms();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.New();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pnlDesignImage_MouseClick(object sender, MouseEventArgs e)
        {
            if ((this.txtCurrent != null) && this.isTake)
            {
                Point location = e.Location;
                int x = location.X;
                int y = location.Y;
                x -= x % 8;
                y -= y % 0x10;
                location = new Point(x, y);
                int num3 = this.txtCurrent.Width / 8;
                this.txtWidth.Text = num3.ToString();
                num3 = x / 8;
                this.txtColumn.Text = num3.ToString();
                this.txtRow.Text = (y / 0x10).ToString();
                this.txtCurrent.BackColor = Color.AntiqueWhite;
                this.isTake = false;
                this.isResize = false;
            }
        }

        private void rbtnAfterDetails_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnAfterDetailsFooter.Checked)
                {
                    strFooterLocation = "AfterDetails";
                    this.txtBlankLineCountAfterDetailsForFooter.Enabled = true;
                }
                else
                {
                    strFooterLocation = "PageEnd";
                    this.txtBlankLineCountAfterDetailsForFooter.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnCondensedOn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnCondensedOn.Checked)
                {
                    strCondensed = "On";
                }
                else if (this.rbtnCondensedOff.Checked)
                {
                    strCondensed = "Off";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnFAllPage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnHedderFirst_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.rbtnOnlyInFirstPAgeHedder.Checked)
                {
                    isHedderRepeat = false;
                }
                else
                {
                    isHedderRepeat = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnNotRepeat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.rbtnHedder.Checked)
                {
                    this.gbxHedder.Enabled = true;
                    this.gbxFooter.Enabled = false;
                }
                else if (this.rbtnDetails.Checked)
                {
                    this.gbxHedder.Enabled = false;
                    this.gbxFooter.Enabled = false;
                }
                else if (this.rbtnFooter.Checked)
                {
                    this.gbxHedder.Enabled = false;
                    this.gbxFooter.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnPitch12_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rbtnPitch10.Checked)
                {
                    strPitch = "10";
                }
                else if (this.rbtnPitch12.Checked)
                {
                    strPitch = "12";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void rbtnRepeat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
                if (this.rbtnHedder.Checked)
                {
                    this.gbxHedder.Enabled = true;
                    this.gbxFooter.Enabled = false;
                }
                else if (this.rbtnDetails.Checked)
                {
                    this.gbxHedder.Enabled = false;
                    this.gbxFooter.Enabled = false;
                }
                else if (this.rbtnFooter.Checked)
                {
                    this.gbxHedder.Enabled = false;
                    this.gbxFooter.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void Save()
        {
            if (MessageBox.Show("Are you sure to submit ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                if (int.Parse((this.txtLineCountForFirstPage.Text == "") ? "0" : this.txtLineCountForFirstPage.Text) <= 0)
                {
                    MessageBox.Show("Line count for first page required", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (int.Parse((this.txtLineCountForOtherPage.Text == "") ? "0" : this.txtLineCountForOtherPage.Text) <= 0)
                {
                    MessageBox.Show("Line count for other page required", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MasterSP rsp = new MasterSP();
                    MasterInfo infoMaster = new MasterInfo();
                    DetailsSP ssp = new DetailsSP();
                    DetailsInfo infoDetails = new DetailsInfo();
                    infoMaster.BlankLneForFooter = int.Parse((this.txtBlankLineCountAfterDetailsForFooter.Text == "") ? "0" : this.txtBlankLineCountAfterDetailsForFooter.Text);
                    infoMaster.FooterLocation = this.rbtnAfterDetailsFooter.Checked ? "AfterDetails" : "PageEnd";
                    infoMaster.FormName = int.Parse(this.cmbForm.SelectedValue.ToString());
                    infoMaster.IsTwoLineForDetails = this.chkLineRepeat.Checked;
                    infoMaster.IsTwoLineForHedder = this.chkLineNonRepeat.Checked;
                    infoMaster.LineCountBetweenTwo = int.Parse((this.txtBlankLineCountBetweenTwoPages.Text == "") ? "0" : this.txtBlankLineCountBetweenTwoPages.Text);
                    infoMaster.PageSize1 = int.Parse((this.txtLineCountForFirstPage.Text == "") ? "0" : this.txtLineCountForFirstPage.Text);
                    infoMaster.PageSizeOther = int.Parse((this.txtLineCountForOtherPage.Text == "") ? "0" : this.txtLineCountForOtherPage.Text);
                    infoMaster.Condensed = this.rbtnCondensedOn.Checked ? "On" : "Off";
                    infoMaster.Pitch = this.rbtnPitch10.Checked ? "10" : "12";
                    infoMaster.LineCountAfterPrint = int.Parse((this.txtLineCountAfterPrint.Text == "") ? "0" : this.txtLineCountAfterPrint.Text);
                    if (this.inMasterId == 0)
                    {
                        this.inMasterId = rsp.MasterAdd(infoMaster);
                    }
                    else
                    {
                        infoMaster.MasterId = this.inMasterId;
                        rsp.MasterEdit(infoMaster);
                        ssp.DetailsDelete(this.inMasterId);
                    }
                    foreach (DataRow row in this.dtbl.Rows)
                    {
                        infoDetails.Name = row["name"].ToString();
                        infoDetails.Text = row["text"].ToString();
                        infoDetails.Row = int.Parse(row["row"].ToString());
                        infoDetails.Columns = int.Parse(row["columns"].ToString());
                        infoDetails.Width = int.Parse(row["width"].ToString());
                        infoDetails.DBF = row["DBF"].ToString();
                        infoDetails.DorH = row["dOrH"].ToString();
                        infoDetails.Repeat = row["Repeat"].ToString();
                        infoDetails.Align = row["Align"].ToString();
                        infoDetails.RepeatAll = row["RepeatAllPage"].ToString();
                        infoDetails.FooterRepeatAll = row["FooterRepeatAll"].ToString();
                        infoDetails.TextWrap = row["textWrap"].ToString();
                        infoDetails.WrapLineCount = int.Parse(row["wrapLineCount"].ToString());
                        infoDetails.FieldsForExtra = row["fieldsForExtra"].ToString();
                        infoDetails.ExtraFieldName = row["extraFieldName"].ToString();
                        infoDetails.MasterId = this.inMasterId;
                        ssp.DetailsAdd(infoDetails);
                    }
                }
            }
        }

        public void SaveDefault()
        {
            if (this.inMasterId != 0)
            {
                if (MessageBox.Show("Default save in process, are you sure to continue ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
                {
                    if (int.Parse((this.txtLineCountForFirstPage.Text == "") ? "0" : this.txtLineCountForFirstPage.Text) <= 0)
                    {
                        MessageBox.Show("Line count for first page required", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (int.Parse((this.txtLineCountForOtherPage.Text == "") ? "0" : this.txtLineCountForOtherPage.Text) <= 0)
                    {
                        MessageBox.Show("Line count for other page required", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MasterSP rsp = new MasterSP();
                        MasterInfo infoMaster = new MasterInfo();
                        DetailsSP ssp = new DetailsSP();
                        DetailsInfo infoDetails = new DetailsInfo();
                        infoMaster.BlankLneForFooter = int.Parse((this.txtBlankLineCountAfterDetailsForFooter.Text == "") ? "0" : this.txtBlankLineCountAfterDetailsForFooter.Text);
                        infoMaster.FooterLocation = this.rbtnAfterDetailsFooter.Checked ? "AfterDetails" : "PageEnd";
                        infoMaster.FormName = int.Parse(this.cmbForm.SelectedValue.ToString());
                        infoMaster.IsTwoLineForDetails = this.chkLineRepeat.Checked;
                        infoMaster.IsTwoLineForHedder = this.chkLineNonRepeat.Checked;
                        infoMaster.LineCountBetweenTwo = int.Parse((this.txtBlankLineCountBetweenTwoPages.Text == "") ? "0" : this.txtBlankLineCountBetweenTwoPages.Text);
                        infoMaster.PageSize1 = int.Parse((this.txtLineCountForFirstPage.Text == "") ? "0" : this.txtLineCountForFirstPage.Text);
                        infoMaster.PageSizeOther = int.Parse((this.txtLineCountForOtherPage.Text == "") ? "0" : this.txtLineCountForOtherPage.Text);
                        infoMaster.Condensed = this.rbtnCondensedOn.Checked ? "On" : "Off";
                        infoMaster.Pitch = this.rbtnPitch10.Checked ? "10" : "12";
                        infoMaster.LineCountAfterPrint = int.Parse((this.txtLineCountAfterPrint.Text == "") ? "0" : this.txtLineCountAfterPrint.Text);
                        infoMaster.MasterId = this.inMasterId;
                        if (rsp.MasterCopyExistCheck(this.inMasterId))
                        {
                            rsp.MasterCopyEdit(infoMaster);
                            ssp.DetailsCopyDelete(this.inMasterId);
                        }
                        else
                        {
                            rsp.MasterCopyAdd(infoMaster);
                        }
                        foreach (DataRow row in this.dtbl.Rows)
                        {
                            infoDetails.Name = row["name"].ToString();
                            infoDetails.Text = row["text"].ToString();
                            infoDetails.Row = int.Parse(row["row"].ToString());
                            infoDetails.Columns = int.Parse(row["columns"].ToString());
                            infoDetails.Width = int.Parse(row["width"].ToString());
                            infoDetails.DBF = row["DBF"].ToString();
                            infoDetails.DorH = row["dOrH"].ToString();
                            infoDetails.Repeat = row["Repeat"].ToString();
                            infoDetails.Align = row["Align"].ToString();
                            infoDetails.RepeatAll = row["RepeatAllPage"].ToString();
                            infoDetails.FooterRepeatAll = row["FooterRepeatAll"].ToString();
                            infoDetails.TextWrap = row["textWrap"].ToString();
                            infoDetails.WrapLineCount = int.Parse(row["wrapLineCount"].ToString());
                            infoDetails.FieldsForExtra = row["fieldsForExtra"].ToString();
                            infoDetails.ExtraFieldName = row["extraFieldName"].ToString();
                            infoDetails.MasterId = this.inMasterId;
                            ssp.DetailsCopyAdd(infoDetails);
                        }
                    }
                }
                this.txtDefaultPass.Text = "";
            }
            else
            {
                MessageBox.Show("Default not accessible in save.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtCurrent.BackColor = Color.AntiqueWhite;
            this.isTake = false;
            this.isResize = false;
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    foreach (Control control in this.pnlDesignImage.Controls)
                    {
                        if (control.BackColor == Color.Yellow)
                        {
                            control.BackColor = Color.AntiqueWhite;
                        }
                    }
                    this.txtCurrent = owner.SourceControl as TextBox;
                    this.txtCurrent.BackColor = Color.Yellow;
                    this.isLarge = false;
                    this.isTake = true;
                    if (this.txtCurrent == null)
                    {
                        this.takeToolStripMenuItem_Click(sender, e);
                    }
                }
            }
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            TextBox box = sender as TextBox;
            this.start_point = new Point(box.Location.X, box.Location.Y);
            this.start_Size = box.Size;
            if ((e.X < box.Width) && (e.X > (box.Width - 8)))
            {
                box.Cursor = Cursors.SizeWE;
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox box = sender as TextBox;
            this.offset = e.Location;
            this.start_point = new Point(box.Location.X, box.Location.Y);
            this.start_Size = box.Size;
            if ((e.X < box.Width) && (e.X > (box.Width - 8)))
            {
                box.Cursor = Cursors.SizeWE;
                this.isResize = true;
            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isResize)
            {
                Point point = base.PointToScreen(e.Location);
                this.txtCurrent = null;
                TextBox box = sender as TextBox;
                int num = point.X - this.pnlDesignImage.Location.X;
                int num2 = point.Y - this.pnlDesignImage.Location.Y;
                box.Width = point.X;
                if ((box.Width / 8) < 1)
                {
                    this.txtWidth.Text = "1";
                }
                else
                {
                    this.txtWidth.Text = (box.Width / 8).ToString();
                }
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (this.isResize)
            {
                this.txtCurrent = box;
                this.AssignToDtbl();
                EventArgs args = new EventArgs();
                this.txtWidth_TextChanged(sender, args);
            }
            this.isResize = false;
            box.Cursor = Cursors.Default;
        }

        private void txtBlankLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == '\b'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtBlankLine_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inBlankLineForFooter = int.Parse((this.txtBlankLineCountAfterDetailsForFooter.Text == "") ? "0" : this.txtBlankLineCountAfterDetailsForFooter.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtCurrent_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtCurrent = sender as TextBox;
                DataRow[] rowArray = this.dtbl.Select("name='" + this.txtCurrent.Name + "'");
                this.txtCurrent = null;
                foreach (Control control in this.pnlDesignImage.Controls)
                {
                    control.BackColor = Color.AntiqueWhite;
                }
                this.txtRow.Text = rowArray[0]["row"].ToString();
                this.txtColumn.Text = rowArray[0]["columns"].ToString();
                this.txtWidth.Text = rowArray[0]["width"].ToString();
                if (rowArray[0]["Repeat"].ToString() == "false")
                {
                    this.rbtnHedder.Checked = true;
                }
                else if (rowArray[0]["Repeat"].ToString() == "true")
                {
                    this.rbtnDetails.Checked = true;
                }
                else
                {
                    this.rbtnFooter.Checked = true;
                }
                this.cmbAlign.SelectedItem = rowArray[0]["Align"].ToString();
                this.cmbFields.SelectedValue = rowArray[0]["DBF"].ToString();
                this.cmbTextType.SelectedItem = rowArray[0]["dOrH"].ToString();
                this.rbtnAllPageHedder.Checked = bool.Parse(rowArray[0]["RepeatAllPage"].ToString());
                this.rbtnOnlyInFirstPAgeHedder.Checked = !bool.Parse(rowArray[0]["RepeatAllPage"].ToString());
                this.rbtnInAllPageFooter.Checked = bool.Parse(rowArray[0]["FooterRepeatAll"].ToString());
                this.rbtnOnlyInLastPageFooter.Checked = !bool.Parse(rowArray[0]["FooterRepeatAll"].ToString());
                this.chkTextWrap.Checked = bool.Parse(rowArray[0]["textWrap"].ToString());
                this.cmbWrapLineCount.SelectedItem = rowArray[0]["wrapLineCount"].ToString();
                this.txtExtraFieldName.Text = rowArray[0]["extraFieldName"].ToString();
                if (this.txtExtraFieldName.Text.Trim() != "")
                {
                    this.txtFieldsForExtra.Text = rowArray[0]["fieldsForExtra"].ToString();
                    this.chkExtraField.Checked = true;
                }
                else
                {
                    this.txtFieldsForExtra.Text = "";
                    this.chkExtraField.Checked = false;
                }
                this.txtCurrent = sender as TextBox;
                this.txtCurrent.BackColor = Color.Gainsboro;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtCurrent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow[] rowArray = this.dtbl.Select("name='" + this.txtCurrent.Name + "'");
                this.txtRow.Text = rowArray[0]["row"].ToString();
                this.txtColumn.Text = rowArray[0]["columns"].ToString();
                this.txtWidth.Text = rowArray[0]["width"].ToString();
                this.AssignToDtbl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtExtraFieldName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.AssignToDtbl();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtLinecountBetweenTwoPages_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inLineCountBetweenTwoPages = int.Parse((this.txtBlankLineCountBetweenTwoPages.Text == "") ? "0" : this.txtBlankLineCountBetweenTwoPages.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtLocationX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCurrent != null)
                {
                    this.txtCurrent.Location = new Point(int.Parse((this.txtColumn.Text == "") ? "0" : this.txtColumn.Text) * 8, int.Parse((this.txtRow.Text == "") ? "0" : this.txtRow.Text) * 0x10);
                    this.txtCurrent.Size = new Size((int.Parse((this.txtWidth.Text == "") ? "5" : this.txtWidth.Text) * 8) + 1, this.txtCurrent.Height);
                    this.AssignToDtbl();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMaximumLineCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inMaxLineCountinFirst = int.Parse(this.txtMaximumLineCountInFirst.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtMaximumLineCountInOther_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inMaxLineCountinOther = int.Parse(this.txtMaximumLineCountInOther.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtPageSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inPageSizeInFirst = int.Parse((this.txtLineCountForFirstPage.Text == "") ? "0" : this.txtLineCountForFirstPage.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtPageSizeinOther_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inPageSizeInOther = int.Parse((this.txtLineCountForOtherPage.Text == "") ? "0" : this.txtLineCountForOtherPage.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCurrent != null)
                {
                    this.txtCurrent.Location = new Point(int.Parse((this.txtColumn.Text == "") ? "0" : this.txtColumn.Text) * 8, int.Parse((this.txtRow.Text == "") ? "0" : this.txtRow.Text) * 0x10);
                    this.txtCurrent.Size = new Size((int.Parse((this.txtWidth.Text == "") ? "5" : this.txtWidth.Text) * 8) + 1, this.txtCurrent.Height);
                    this.AssignToDtbl();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}

