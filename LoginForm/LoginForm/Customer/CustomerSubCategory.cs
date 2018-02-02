using LoginForm.DataSet;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class CustomerSubCategory : Form
    {
        IMEEntities IME = new IMEEntities();
        public CustomerSubCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                var dep = IME.CustomerCategories.Where(a => a.categoryname == comboBox1.Text).FirstOrDefault();
                if (dep != null)
                {
                    var result = IME.CustomerSubCategories.Where(title => title.subcategoryname == TitleName.Text).FirstOrDefault();

                    if (result == null || (result != null))
                    {
                    DataSet.CustomerSubCategory ct = new DataSet.CustomerSubCategory();
                        ct.subcategoryname = TitleName.Text;
                        string Department = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                        IME.CustomerSubCategories.Add(ct);
                    MessageBox.Show(this,ct.subcategoryname + " added as a SubCategory");
                    }
                    else
                    {
                        MessageBox.Show(this, "There is a Already CustomerSubCategories with the same name in this Category");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Please choose a Category name properly");
                }
            
           
        }

        private void TitleAdd_Load(object sender, EventArgs e)
        {
            var departmenList = IME.CustomerCategories.Select(a=>a.categoryname).ToList();
            comboBox1.DataSource = departmenList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
