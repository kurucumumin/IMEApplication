namespace PrintWorks
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmForms : Form
    {
        private Button btnClear;
        private Button btnDelete;
        private Button btnSave;
        private IContainer components = null;
        private DataGridView dgvFields;
        private DataGridView dgvForms;
        private DataGridViewTextBoxColumn fieldId1;
        private DataGridViewTextBoxColumn fieldName;
        private DataGridViewTextBoxColumn formId;
        private DataGridViewTextBoxColumn formId1;
        private DataGridViewTextBoxColumn formName;
        public int informId = 0;
        private Label label1;
        private DataGridViewTextBoxColumn slNo;
        private TextBox txtFormName;

        public frmForms()
        {
            this.InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        public void Clear()
        {
            this.txtFormName.Text = "";
            DataTable table = new DataTable();
            table.Columns.Add("fieldName");
            table.Columns.Add("fieldId");
            table.Columns.Add("formId");
            this.dgvFields.DataSource = table;
            this.informId = 0;
            this.btnDelete.Enabled = false;
        }

        public void Delete()
        {
            if (MessageBox.Show("Are you sure to delete ?", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                FormSP msp = new FormSP();
                FieldSP dsp = new FieldSP();
                if (msp.FormDelete(this.informId))
                {
                    dsp.FieldsDelete(this.informId);
                    this.Clear();
                    this.FillGrid();
                    frmPrintDesigner.obj.FormFill();
                    MessageBox.Show("Deleted successfully", "Forms", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Reference exist in print design", "Forms", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void dgvForms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvForms.Rows.Count > 0)
                {
                    this.informId = int.Parse(this.dgvForms.CurrentRow.Cells["formId"].Value.ToString());
                    FormSP msp = new FormSP();
                    FormInfo info = new FormInfo();
                    FieldSP dsp = new FieldSP();
                    info = msp.FormView(this.informId);
                    this.txtFormName.Text = info.FormName;
                    this.dgvFields.DataSource = dsp.FieldsViewAll(this.informId);
                    this.btnDelete.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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

        public void FillGrid()
        {
            FormSP msp = new FormSP();
            DataTable table = new DataTable();
            table = msp.FormViewAll();
            this.dgvForms.DataSource = table;
        }

        private void frmForms_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && (e.KeyCode == Keys.S))
                {
                    this.Save();
                }
                else if ((!e.Control || (e.KeyCode != Keys.N)) && (e.Control && (e.KeyCode == Keys.D)))
                {
                    this.Delete();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Print", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void frmForms_Load(object sender, EventArgs e)
        {
            this.FillGrid();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(frmForms));
            this.txtFormName = new TextBox();
            this.label1 = new Label();
            this.dgvFields = new DataGridView();
            this.fieldName = new DataGridViewTextBoxColumn();
            this.formId1 = new DataGridViewTextBoxColumn();
            this.fieldId1 = new DataGridViewTextBoxColumn();
            this.dgvForms = new DataGridView();
            this.formId = new DataGridViewTextBoxColumn();
            this.slNo = new DataGridViewTextBoxColumn();
            this.formName = new DataGridViewTextBoxColumn();
            this.btnSave = new Button();
            this.btnDelete = new Button();
            this.btnClear = new Button();
            ((ISupportInitialize) this.dgvFields).BeginInit();
            ((ISupportInitialize) this.dgvForms).BeginInit();
            base.SuspendLayout();
            this.txtFormName.Location = new Point(0x56, 0x23);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new Size(0xa4, 20);
            this.txtFormName.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 0x2a);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x3d, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Form Name";
            this.dgvFields.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFields.BackgroundColor = Color.White;
            this.dgvFields.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new DataGridViewColumn[] { this.fieldName, this.formId1, this.fieldId1 });
            this.dgvFields.Location = new Point(10, 0x47);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.Size = new Size(240, 0xa7);
            this.dgvFields.TabIndex = 2;
            this.fieldName.DataPropertyName = "fieldName";
            this.fieldName.HeaderText = "Field Name";
            this.fieldName.Name = "fieldName";
            this.formId1.DataPropertyName = "formId";
            this.formId1.HeaderText = "formId";
            this.formId1.Name = "formId1";
            this.formId1.ReadOnly = true;
            this.formId1.Visible = false;
            this.fieldId1.DataPropertyName = "fieldId";
            this.fieldId1.HeaderText = "fieldId1";
            this.fieldId1.Name = "fieldId1";
            this.fieldId1.ReadOnly = true;
            this.fieldId1.Visible = false;
            this.dgvForms.AllowUserToAddRows = false;
            this.dgvForms.AllowUserToDeleteRows = false;
            this.dgvForms.AllowUserToOrderColumns = true;
            this.dgvForms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvForms.BackgroundColor = Color.White;
            this.dgvForms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvForms.Columns.AddRange(new DataGridViewColumn[] { this.formId, this.slNo, this.formName });
            this.dgvForms.Location = new Point(0x10b, 0x23);
            this.dgvForms.Name = "dgvForms";
            this.dgvForms.RowHeadersVisible = false;
            this.dgvForms.Size = new Size(0x114, 0xcb);
            this.dgvForms.TabIndex = 2;
            this.dgvForms.CellClick += new DataGridViewCellEventHandler(this.dgvForms_CellClick);
            this.formId.DataPropertyName = "formId";
            this.formId.HeaderText = "formId";
            this.formId.Name = "formId";
            this.formId.ReadOnly = true;
            this.formId.Visible = false;
            this.slNo.DataPropertyName = "slNo";
            this.slNo.HeaderText = "Sl No";
            this.slNo.Name = "slNo";
            this.slNo.ReadOnly = true;
            this.formName.DataPropertyName = "formName";
            this.formName.HeaderText = "Form Name";
            this.formName.Name = "formName";
            this.formName.ReadOnly = true;
            this.btnSave.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnSave.FlatAppearance.BorderColor = Color.White;
            this.btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(0x132, 250);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(0x4b, 0x17);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnDelete.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatAppearance.BorderColor = Color.White;
            this.btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Location = new Point(0x183, 250);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(0x4b, 0x17);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnClear.BackColor = Color.FromArgb(0xb3, 0x30, 0x3e);
            this.btnClear.FlatAppearance.BorderColor = Color.White;
            this.btnClear.FlatAppearance.MouseDownBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(0x6b, 0xb2, 50);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(0x1d4, 250);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(0x4b, 0x17);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(90, 0xa9, 0xe2);
            base.ClientSize = new Size(0x22d, 0x11f);
            base.Controls.Add(this.btnClear);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnSave);
            base.Controls.Add(this.dgvForms);
            base.Controls.Add(this.dgvFields);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.txtFormName);
//            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.KeyPreview = true;
            this.MaximumSize = new Size(0x235, 0x141);
            base.Name = "frmForms";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Forms";
            base.Load += new EventHandler(this.frmForms_Load);
            base.KeyDown += new KeyEventHandler(this.frmForms_KeyDown);
            ((ISupportInitialize) this.dgvFields).EndInit();
            ((ISupportInitialize) this.dgvForms).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void Save()
        {
            int num2;
            int num3;
            FormInfo infoForm = new FormInfo();
            FormSP msp = new FormSP();
            FieldInfo infoField = new FieldInfo();
            FieldSP dsp = new FieldSP();
            int formId = 0;
            infoForm.FormName = this.txtFormName.Text;
            if (this.informId == 0)
            {
                formId = msp.FormAdd(infoForm);
                if (formId > -1)
                {
                    infoField.FormId = formId;
                    num2 = this.dgvFields.Rows.Count - 1;
                    for (num3 = 0; num3 < num2; num3++)
                    {
                        infoField.FieldName = this.dgvFields.Rows[num3].Cells["fieldName"].Value.ToString();
                        dsp.FieldsAdd(infoField);
                    }
                    this.Clear();
                    MessageBox.Show("Saved successfully", "Forms", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Form name alredy exist", "Forms", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                formId = this.informId;
                infoForm.FormId = formId;
                bool flag = msp.FormEdit(infoForm);
                if (!flag && (MessageBox.Show("Reference exist in print design, do you want to continue ?", "Forms", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    flag = true;
                    msp.FormEditFull(infoForm);
                }
                if (flag)
                {
                    infoField.FormId = formId;
                    dsp.FieldsDelete(formId);
                    num2 = this.dgvFields.Rows.Count - 1;
                    for (num3 = 0; num3 < num2; num3++)
                    {
                        infoField.FieldName = this.dgvFields.Rows[num3].Cells["fieldName"].Value.ToString();
                        dsp.FieldsAdd(infoField);
                    }
                    this.Clear();
                    MessageBox.Show("Updated successfully", "Forms", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            frmPrintDesigner.obj.FormFill();
            this.FillGrid();
        }
    }
}

