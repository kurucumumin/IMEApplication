using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.ItemModule
{
    public partial class LoaderPage : MyForm
    {
        IMEEntities IME = new IMEEntities();
        public LoaderPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            switch (txtReader.LoaderType)
            {
                #region LoaderPage
                case "SuperDisk":
                    //if (txtReader.SuperDiskRead() == 1)
                    if (txtReader.SuperDiskTxtSave() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "SuperDiskP":
                    if (txtReader.SuperDiskPRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDiskPs.Take(10).ToList();

                    break;
                case "SlidingPrice":
                    if (txtReader.SlidingPriceRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SlidingPrices.Take(10).ToList();
                    break;
                case "OnSale":
                    if (txtReader.OnSaleRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    txtReader.OnSaleRead();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "DiscontinuedList":
                    if (txtReader.DiscontinuedListRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DailyDiscontinueds.Take(10).ToList();
                    break;
                case "DualUse":
                    if (txtReader.DualUsedRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.DualUses.Take(10).ToList();
                    break;
                case "Hazardous":
                    if (txtReader.HazardousRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.Hazardous.Take(10).ToList();
                    break;
                case "ExtendedRange":
                    if (txtReader.EntendedRangeRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
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
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                case "RSInvoice":
                    txtReader.RSInvoiceReader();
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.RS_Invoice.Take(10).ToList();
                    break;

                case "OrderAcknowledgementtxtReader":
                    txtReader.OrderAcknowledgementtxtReader();
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = IME.OrderAcknowledgements.Take(10).ToList();
                    break;

                //case "Stock":
                    
                //    break;

            }
#endregion       
        }

        private void LoaderPage_Load(object sender, EventArgs e)
        {
            this.Text = txtReader.LoaderType;
        }
    }
}
