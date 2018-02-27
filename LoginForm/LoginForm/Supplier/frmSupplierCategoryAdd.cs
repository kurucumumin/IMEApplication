using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class frmSupplierCategoryAdd : Form
    {

        public frmSupplierCategoryAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                var duplicateCategory = db.SupplierCategories.ToList().Where(x => x.categoryname.IndexOf(txtCategory.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                if (duplicateCategory.Count == 0)
                {
                    //CommitDenemefromDemir
                    SupplierCategory sc = new SupplierCategory();
                    sc.categoryname = txtCategory.Text;
                    db.SupplierCategories.Add(sc);
                    db.SaveChanges();
                    MessageBox.Show(txtCategory.Text + " is added!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There is already a category named " + txtCategory.Text, "Failure");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SCA1: Category could not been added!", "Error");
                this.Close();
            }
            
        }
    }
}
