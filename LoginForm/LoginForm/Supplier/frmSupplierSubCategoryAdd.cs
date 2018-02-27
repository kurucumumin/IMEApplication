using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmSupplierSubCategoryAdd : Form
    {
        private IMEEntities db = new IMEEntities();
        private string categoryName;

        public frmSupplierSubCategoryAdd(string categoryname)
        {
            InitializeComponent();
            this.categoryName = categoryname;
        }

        private void frmSupplierPositionAdd_Load(object sender, EventArgs e)
        {
            cmbCategory.DisplayMember = "categoryname";
            cmbCategory.Items.AddRange(db.SupplierCategories.ToArray());
            cmbCategory.SelectedIndex = cmbCategory.FindStringExact(categoryName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryID = ((SupplierCategory)cmbCategory.SelectedItem).ID;
                var duplicateSubCategory = db.SupplierSubCategories.Where(x=>x.ID == categoryID).ToList().Where(x => x.subcategoryname.IndexOf(txtSubCategoryName.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if(duplicateSubCategory.Count == 0)
                {
                    SupplierSubCategory ssc = new SupplierSubCategory();
                    ssc.subcategoryname = txtSubCategoryName.Text;
                    string Department = cmbCategory.Items[cmbCategory.SelectedIndex].ToString();
                    ssc.categoryID = categoryID;
                    db.SupplierSubCategories.Add(ssc);
                    db.SaveChanges();
                    MessageBox.Show(ssc.subcategoryname + " added!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is already a subcategory named " + txtSubCategoryName.Text + " in this category", "Failure");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SSCA1: Subcategory could not been added!", "Error");
                this.Close();
            }
        }
    }
}
