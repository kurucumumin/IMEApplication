using LoginForm.DataSet;
using LoginForm.Main;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Management
{
    public partial class FormLogKayit : Form
    {
        IMEEntities IME = new IMEEntities();
        frmMainMetro mainForm;
        DateTime dateNow;
        public FormLogKayit()
        {
            InitializeComponent();

            dateNow = Utils.GetCurrentDateTime();
            dtpFromDate.Value = DateTime.Now.AddDays(-1);
            dtpToDate.Value = dateNow;
        }

        public FormLogKayit(frmMainMetro mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close ?", "Log Records Close", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void FormLogKayit_Load(object sender, EventArgs e)
        {
            LoadPerson();
        }

        private void LoadPerson()
        {
           var list= IME.Workers.ToList();

            dgPerson.Rows.Clear();
            dgPerson.Refresh();

            foreach (dynamic item in list)
            {
                int rowIndex = dgPerson.Rows.Add();
                DataGridViewRow row = dgPerson.Rows[rowIndex];


                row.Cells[WorkerID.Index].Value = item.WorkerID;
                row.Cells[NameLastName.Index].Value = item.NameLastName;
                

            }
        }

        private void LoadLog(DateTime fromDate, DateTime toDate)
        {
            int workerID = Convert.ToInt32(dgPerson.CurrentRow.Cells["WorkerID"].Value.ToString());
            var list = IME.LogRecords.Where(x => x.USER_ID == workerID && x.TIME >= fromDate && x.TIME < toDate).ToList();

            dgLog.Rows.Clear();
            dgLog.Refresh();

            foreach (dynamic item in list)
            {
                int rowIndex = dgLog.Rows.Add();
                DataGridViewRow row = dgLog.Rows[rowIndex];

                row.Cells[ID.Index].Value = item.ID;
                row.Cells[TABLE_NAME.Index].Value = item.TABLE_NAME;
                row.Cells[TIME.Index].Value = item.TIME;
                row.Cells[USER_ID.Index].Value = item.USER_ID;
                row.Cells[DONE_OPERATION.Index].Value = item.DONE_OPERATION;

            }
        }

        private void dgPerson_MouseClick(object sender, MouseEventArgs e)
        {
            LoadLog(DateTime.Now.AddDays(-1), DateTime.Now);
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadLog(dtpFromDate.Value,dtpToDate.Value);
        }
    }
}
