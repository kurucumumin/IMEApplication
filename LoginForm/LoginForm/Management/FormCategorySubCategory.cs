using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.ManagementModule
{
    public partial class FormCategorySubCategory : MyForm
    {
        IMEEntities db = new IMEEntities();


        public FormCategorySubCategory()
        {
            InitializeComponent();

            //txtSubCategory.Enabled = false;
            //btnSubCategoryAdd.Enabled = false;
        }
        //public FormCategorySubCategory(CustomerCategory category)
        //{
        //    InitializeComponent();

        //    txtMainCategory.Text = category.categoryname;
        //    txtMainCategory.Enabled = false;
        //    btnMainCategoryAdd.Enabled = false;
        //}

        private void btnMainCategoryAdd_Click(object sender, EventArgs e)
        {
            if (txtMainCategory.Text != null && txtMainCategory.Text != String.Empty)
            {
                CustomerCategory ccat = db.CustomerCategories.Where(c => c.categoryname.Equals(txtMainCategory.Text, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (ccat != null)
                {
                    MessageBox.Show("'" + txtMainCategory.Text + "'" + "named category already exists!", "Fail");
                }
                else
                {
                    try
                    {
                        CustomerCategory cc = new CustomerCategory();
                        cc.categoryname = txtMainCategory.Text;
                        db.CustomerCategories.Add(cc);
                        db.SaveChanges();

                        MessageBox.Show("'" + txtMainCategory.Text + "'" + "named category successfully added.", "Success");
                        lbCategory.DataSource = db.CustomerCategories.ToList();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty category name is not allowed!", "Attention!");
            }
        }

        private void FormCategorySubCategory_Load(object sender, EventArgs e)
        {
            lbCategory.DataSource = db.CustomerCategories.ToList();
        }

        private void lbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbCategory.SelectedItem != null)
            {
                lbSubCategory.DataSource = ((CustomerCategory)lbCategory.SelectedItem).CustomerSubCategories.ToList();
            }
        }

        private void btnSubCategoryAdd_Click(object sender, EventArgs e)
        {
            if (txtSubCategory.Text != null && txtSubCategory.Text != String.Empty)
            {
                DataSet.CustomerSubCategory ccat = db.CustomerSubCategories.Where(c => c.subcategoryname.Equals(txtSubCategory.Text, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                if (ccat != null)
                {
                    MessageBox.Show("'" + txtSubCategory.Text + "'" + "named subcategory already exists!", "Fail");
                }
                else
                {
                    try
                    {
                        DataSet.CustomerSubCategory sub = new DataSet.CustomerSubCategory();
                        sub.subcategoryname = txtSubCategory.Text;
                        sub.categoryID = (int)lbCategory.SelectedValue;
                        db.CustomerSubCategories.Add(sub);
                        db.SaveChanges();

                        MessageBox.Show("'" + txtSubCategory.Text + "'" + "named subcategory successfully added.", "Success");
                        lbSubCategory.DataSource = ((CustomerCategory)lbCategory.SelectedItem).CustomerSubCategories.ToList();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty category name is not allowed!", "Attention!");
            }            
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if(lbCategory.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Deleting category '" + ((CustomerCategory)lbCategory.SelectedItem).categoryname + "' and its subcategories. Do you confirm?", "Delete Category", MessageBoxButtons.OKCancel);

                if(result == DialogResult.OK)
                {
                    try
                    {
                        db.CustomerSubCategories.RemoveRange(((CustomerCategory)lbCategory.SelectedItem).CustomerSubCategories);
                        db.SaveChanges();

                        db.CustomerCategories.Remove((CustomerCategory)lbCategory.SelectedItem);
                        db.SaveChanges();

                        lbCategory.DataSource = db.CustomerCategories.ToList();


                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private void btnDeleteSubcategory_Click(object sender, EventArgs e)
        {
            if (lbSubCategory.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Deleting subcategory '" + lbSubCategory.SelectedValue + "'. Do you confirm?", "Delete Subcategory", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        db.CustomerSubCategories.Remove((DataSet.CustomerSubCategory)lbSubCategory.SelectedItem);
                        db.SaveChanges();

                        lbSubCategory.DataSource = ((CustomerCategory)lbCategory.SelectedItem).CustomerSubCategories.ToList();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
