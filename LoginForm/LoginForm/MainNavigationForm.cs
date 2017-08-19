using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Quotation;
using LoginForm.DataSet;

namespace LoginForm
{
    public partial class MainNavigationForm : Form
    {
        public MainNavigationForm()
        {
            InitializeComponent();
        }

        private void lblQuotation_DoubleClick(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        private void MainNavigationForm_Load(object sender, EventArgs e)
        {
            //Login olan kullanıcının ID'si üzerinden Kullanıcı Bilgileri ve yetkileri çekilecek burada
            label1.Text = WorkerApp.ID.ToString();
        }
    }
}
