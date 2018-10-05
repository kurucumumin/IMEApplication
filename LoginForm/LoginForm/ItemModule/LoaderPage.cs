using LoginForm.DataSet;
using LoginForm.MyClasses;
using LoginForm.Services;
using LoginForm.Services.SP;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginForm.ItemModule
{
    public partial class LoaderPage : MyForm
    {
        IMEEntities IME = new IMEEntities();
        public LoaderPage()
        {
            InitializeComponent();
            dgvFileLog.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgvFileLog, new object[] { true });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            #region LoaderPage
            switch (txtReader.LoaderType)
            {
                case "SuperDisk":
                    SuperDiskHelper SuperDiskHelper = new SuperDiskHelper();
                    bool NoError = SuperDiskHelper.ErrorCheck();
                    if (NoError)
                    {
                        if (SuperDiskHelper.LoadSuperDiskItems())
                        {
                            RsFileHistory h = new RsFileHistory();
                            h.FileType = txtReader.LoaderType;
                            h.FileName = SuperDiskHelper.FileName;
                            h.Date = Utils.GetCurrentDateTime();
                            h.UserID = Utils.getCurrentUser().WorkerID;
                            IME.RsFileHistories.Add(h);
                            IME.SaveChanges();
                        }
                    }


                    //string[] result1 = txtReader.SuperDiskRead();
                    //if (result1[(int)LoaderResultColumns.Result] == "1")
                    ////if (txtReader.SuperDiskTxtSave() == 1)
                    //{
                    //    RsFileHistory h = new RsFileHistory();
                    //    h.FileType = txtReader.LoaderType;
                    //    h.FileName = result1[(int)LoaderResultColumns.FileName];
                    //    h.Date = IME.CurrentDate().FirstOrDefault().Value;
                    //    h.UserID = Utils.getCurrentUser().WorkerID;
                    //    IME.RsFileHistories.Add(h);
                    //    IME.SaveChanges();
                    //}


                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "SuperDiskP":
                    if (txtReader.SuperDiskPRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.SuperDiskPs.Take(10).ToList();

                    break;
                case "SlidingPrice":
                    if (txtReader.SlidingPriceRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.SlidingPrices.Take(10).ToList();
                    break;
                case "OnSale":
                    if (txtReader.OnSaleRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    txtReader.OnSaleRead();
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.SuperDisks.Take(10).ToList();
                    break;
                case "DiscontinuedList":
                    if (txtReader.DiscontinuedListRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.DailyDiscontinueds.Take(10).ToList();
                    break;
                case "DualUse":
                    if (txtReader.DualUsedRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.DualUses.Take(10).ToList();
                    break;
                case "Hazardous":
                    if (txtReader.HazardousRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.Hazardous.Take(10).ToList();
                    break;
                case "ExtendedRange":
                    if (txtReader.EntendedRangeRead() == 1)
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.ExtendedRanges.Take(10).ToList();
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
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.RSProes.Take(10).ToList();
                    break;
                //case "RSInvoice":
                //    txtReader.RSInvoiceReader();
                //    {
                //        RsFileHistory h = new RsFileHistory();
                //        h.FileType = txtReader.LoaderType;
                //        h.FileName = "";
                //        h.Date = IME.CurrentDate().FirstOrDefault().Value;
                //        h.UserID = Utils.getCurrentUser().WorkerID;
                //        IME.RsFileHistories.Add(h);
                //        IME.SaveChanges();
                //    }
                //    dataGridView1.DataSource = null;
                //    dataGridView1.DataSource = IME.RS_Invoice.Take(10).ToList();
                //    break;

                case "OrderAcknowledgementtxtReader":
                    txtReader.OrderAcknowledgementtxtReader();
                    {
                        RsFileHistory h = new RsFileHistory();
                        h.FileType = txtReader.LoaderType;
                        h.FileName = "";
                        h.Date = Utils.GetCurrentDateTime();
                        h.UserID = Utils.getCurrentUser().WorkerID;
                        IME.RsFileHistories.Add(h);
                        IME.SaveChanges();
                    }
                    //dgvFileLog.DataSource = null;
                    //dgvFileLog.DataSource = IME.OrderAcknowledgements.Take(10).ToList();
                    break;

                    //case "Stock":

                    //    break;

            }
            #endregion  
        }

        private void LoaderPage_Load(object sender, EventArgs e)
        {
            this.Text = txtReader.LoaderType;
            SetDataGridRsFileHistory(new Sp_RsFileHistory().GetRsFileHistoryWithFileType(this.Text));
        }

        private void SetDataGridRsFileHistory(DataTable table)
        {
            foreach (DataRow item in table.Rows)
            {
                DataGridViewRow row = dgvFileLog.Rows[dgvFileLog.Rows.Add()];

                row.Cells[dgUser.Index].Value = item["USER"];
                row.Cells[dgFileType.Index].Value = item["FILETYPE"];
                row.Cells[dgFileName.Index].Value = item["FILENAME"];
                row.Cells[dgDate.Index].Value = item["DATE"];
            }
        }
    }
}
