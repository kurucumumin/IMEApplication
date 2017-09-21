using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class ItemCardMainForm : Form
    {
        public ItemCardMainForm()
        {
            
            InitializeComponent();
        }

        private void BtnSuperDisk_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SuperDisk";
            GoToLoaderPage();

        }

        private void btnItemCard_Click(object sender, EventArgs e)
        {
            ItemCard form = new ItemCard();
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SuperDiskP";
            GoToLoaderPage();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "SlidingPrice";
            GoToLoaderPage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "OnSale";
            GoToLoaderPage();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "DiscontinuedList";
            GoToLoaderPage();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "DualUse";
            GoToLoaderPage();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "Hazardous";
            GoToLoaderPage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "ExtendedRange";
            GoToLoaderPage();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "TSE";
            GoToLoaderPage();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "RSPro";
            GoToLoaderPage();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtReader.LoaderType = "";
            txtReader.LoaderType = "Stock";
            GoToLoaderPage();
        }

        private void GoToLoaderPage()
        {
            LoaderPage form = new LoaderPage();
            form.Show();
            this.Hide();
        }

        
    }
}
