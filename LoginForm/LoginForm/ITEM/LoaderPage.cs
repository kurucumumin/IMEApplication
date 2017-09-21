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

namespace LoginForm
{
    public partial class LoaderPage : Form
    {
        IMEEntities IME = new IMEEntities();
        public LoaderPage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemCardMainForm form = new ItemCardMainForm();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (txtReader.LoaderType)
            {
                #region LoaderPage
                case "SuperDisk":
                    txtReader.SuperDiskRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "SuperDiskP":
                    txtReader.SuperDiskPRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDiskPs.Take(10).ToList();

                    break;
                case "SlidingPrice":
                    txtReader.SlidingPriceRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SlidingPrices.Take(10).ToList();
                    break;
                case "OnSale":
                    txtReader.SuperDiskRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "DiscontinuedList":
                    txtReader.DiscontinuedListRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DailyDiscontinueds.Take(10).ToList();
                    break;
                case "DualUse":
                    txtReader.DualUsedRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DualUses.Take(10).ToList();
                    break;
                case "Hazardous":
                    txtReader.HazardousRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.Hazardous.Take(10).ToList();
                    break;
                case "ExtendedRange":
                    txtReader.EntendedRangeRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.ExtendedRanges.Take(10).ToList();
                    break;
                case "TSE":
                    //txtReader.SuperDiskRead();
                    //dataGridView1.DataSource = null;
                    //dataGridView1.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                case "RSPro":
                    txtReader.RSProRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                case "Stock":
                    
                    break;

            }
#endregion       
        }

        private void LoaderPage_Load(object sender, EventArgs e)
        {
            this.Text = txtReader.LoaderType;
        }
    }
}
