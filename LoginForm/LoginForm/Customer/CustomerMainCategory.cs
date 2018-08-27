using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CustomerMainCategory : MyForm
    {
        IMEEntities IME = new IMEEntities();
        public CustomerMainCategory()
        {
            this.BringToFront();
            this.TopMost = true;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = IME.CustomerCategories.Where(department => department.categoryname == DepartmentName.Text).ToList();
            if (result.Count == 0)
            {
                DataSet.CustomerCategory cd = new DataSet.CustomerCategory();
                cd.categoryname = DepartmentName.Text;
                IME.CustomerCategories.Add(cd);
                IME.SaveChanges();
                MessageBox.Show(DepartmentName.Text + " is added as a Category");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("There is already a Category name with " + DepartmentName.Text);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
