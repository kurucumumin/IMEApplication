using LoginForm.DataSet;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Item
{
    public partial class LoaderPage : Form
    {
        IMEEntities IME = new IMEEntities();
        public LoaderPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //FormMain form = new FormMain();
            //form.Show();
            //this.Hide();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            switch (txtReader.LoaderType)
            {
                #region LoaderPage
                case "SuperDisk":
                    if (txtReader.SuperDiskRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.SD_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "SuperDiskP":
                    if (txtReader.SuperDiskPRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.SDP_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDiskPs.Take(10).ToList();

                    break;
                case "SlidingPrice":
                    if (txtReader.SlidingPriceRead() == 1)
                    {
                        //LoaderDate ld = new LoaderDate();
                        //ld = DTPLoaderDate.Value;
                        //IME.LoaderDates.Add(ld);
                        //IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SlidingPrices.Take(10).ToList();
                    break;
                case "OnSale":
                    if (txtReader.SuperDiskRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.SDP_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    txtReader.SuperDiskRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "DiscontinuedList":
                    if (txtReader.DiscontinuedListRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.DiscontinuedList_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DailyDiscontinueds.Take(10).ToList();
                    break;
                case "DualUse":
                    if (txtReader.DualUsedRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.DualUsed_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DualUses.Take(10).ToList();
                    break;
                case "Hazardous":
                    if (txtReader.HazardousRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.Hazardous_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.Hazardous.Take(10).ToList();
                    break;
                case "ExtendedRange":
                    if (txtReader.EntendedRangeRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.ER_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.ExtendedRanges.Take(10).ToList();
                    break;
                case "TSE":
                    //txtReader.SuperDiskRead();
                    //dataGridView1.DataSource = null;
                    //dataGridView1.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                case "RSPro":
                    if (txtReader.RSProRead() == 1)
                    {
                        LoaderDate ld = new LoaderDate();
                        ld.RSPro_Date = DTPLoaderDate.Value;
                        IME.LoaderDates.Add(ld);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                case "RSInvoice":
                    txtReader.RSInvoiceReader();
                    {
                        //LoaderDate ld = new LoaderDate();
                        //ld.RSPro_Date = DTPLoaderDate.Value;
                        //IME.LoaderDates.Add(ld);
                        //IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.RS_Invoice.Take(10).ToList();
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

        private void DTPLoaderDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
