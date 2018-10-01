using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using LoginForm.Services;
using static LoginForm.Services.MyClasses.MyAuthority;


namespace LoginForm
{
    public partial class FormSupplierMain : Form
    {
        DateTime dateNow;
        Worker currentUser = Utils.getCurrentUser();

        public FormSupplierMain()
        {
            IMEEntities IME = new IMEEntities();
            InitializeComponent();

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
           System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
           dgSupplier, new object[] { true });

            dateNow = Convert.ToDateTime(new IMEEntities().CurrentDate().First());
        }

        private void FormSupplierMain_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
         dgSupplier, new object[] { true });

            checkAuthorities();

            BringQuotationList();
        }

        public void checkAuthorities()
        {
            List<DataSet.AuthorizationValue> authList = Utils.getCurrentUser().AuthorizationValues.ToList();

            if (!Utils.AuthorityCheck(IMEAuthority.CanAddSupplier) && !Utils.AuthorityCheck(IMEAuthority.CanEditSupplier))
            {
                btnNew.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        private void BringQuotationList()
        {
            dgSupplier.Rows.Clear();
            dgSupplier.Refresh();

            IMEEntities IME = new IMEEntities();
            var list = (from s in IME.Suppliers
                        select new
                        {
                            SupplierNo = s.ID,
                            SupplierName = s.s_name,
                            WebAddress = s.webadress,
                            TaxNumber = s.taxnumber,
                            TaxOffice = s.taxoffice,
                            Representative = s.SupplierWorker.sw_name,
                            Category = s.SupplierCategory.categoryname,
                            SupplierNote = s.Note.Note_name
                        }).OrderByDescending(x => x.SupplierNo).Take(100);

            populateGrid(list.ToList());

        }

        private void populateGrid<T>(List<T> queryable)
        {

            dgSupplier.Rows.Clear();
            dgSupplier.Refresh();

            foreach (dynamic item in queryable)
            {
                int rowIndex = dgSupplier.Rows.Add();
                DataGridViewRow row = dgSupplier.Rows[rowIndex];


                row.Cells[SupplierNo.Index].Value = item.SupplierNo;
                row.Cells[SupplierName.Index].Value = item.SupplierName;
                row.Cells[WebAddress.Index].Value = item.WebAddress;
                row.Cells[TaxNumber.Index].Value = item.TaxNumber;
                row.Cells[TaxOffice.Index].Value = item.TaxOffice;
                row.Cells[Representative.Index].Value = item.Representative;
                row.Cells[Category.Index].Value = item.Category;
                row.Cells[SupplierNote.Index].Value = item.SupplierNote;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Utils.LogKayit("Supplier", "Supplier excel");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SupplierSearch();
        }

        private void SupplierSearch()
        {
            dgSupplier.Rows.Clear();
            dgSupplier.Refresh();

            IMEEntities IME = new IMEEntities();

            if (!String.IsNullOrEmpty(txtSearchText.Text))
            {
                var list = (from s in IME.Suppliers
                            where s.s_name.Contains(txtSearchText.Text)
                            select new
                            {
                                SupplierNo = s.ID,
                                SupplierName = s.s_name,
                                WebAddress = s.webadress,
                                TaxNumber = s.taxnumber,
                                TaxOffice = s.taxoffice,
                                Representative = s.SupplierWorker.sw_name,
                                Category = s.SupplierCategory.categoryname,
                                SupplierNote = s.Note.Note_name
                            });

                populateGrid(list.ToList());
            }
            else
            {
                MessageBox.Show("You should enter a customer name", "Attention!");
            }
        }

        private void dgSupplier_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SupplierOpen("View");
        }

        private void SupplierOpen(string mod)
        {
            if (dgSupplier.CurrentRow != null)
            {
                string SupplierNo = dgSupplier.CurrentRow.Cells["SupplierNo"].Value.ToString();
                Supplier s;

                IMEEntities IME = new IMEEntities();
                try
                {
                    s = IME.Suppliers.Where(q => q.ID == SupplierNo).FirstOrDefault();

                    if (s != null)
                    {
                        if (mod == "View")
                        {
                            FormSupplierAdd newForm = new FormSupplierAdd(s, mod);
                            newForm.ShowDialog();
                        }
                        else
                        {
                            FormSupplierAdd newForm = new FormSupplierAdd(s, mod);
                            newForm.ShowDialog();
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            else
            {
                MessageBox.Show("You did not chose any supplier.", "Warning!");
            }
        }

        private void qUOTATIONINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierOpen("View");
        }

        private void qUOTATIONPRINTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierOpen("Modify");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SupplierOpen("Modify");
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            BringQuotationList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormSupplierAdd SupplierForm = new FormSupplierAdd(this);
            Utils.LogKayit("Supplier", "Supplier new screen has been entered");
            SupplierForm.Show();
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SupplierSearch();
            }
        }
    }
}
