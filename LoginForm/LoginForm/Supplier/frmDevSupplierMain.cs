using LoginForm.Services;
using LoginForm.Services.SP;
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
    public partial class frmDevSupplierMain : Form
    {
        const string bgwWorkerComboBox = "cmbWorker";
        string bgwMode = String.Empty;
        DataTable tempDataTable = new DataTable();

        public frmDevSupplierMain()
        {
            InitializeComponent();
            dgSupplier.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
        }

        private void frmDevSupplierMain_Load(object sender, EventArgs e)
        {
            bgwMode = bgwWorkerComboBox;
            bgw_Worker.RunWorkerAsync();
        }

        private void bgw_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            switch (bgwMode)
            {
                #region RepresentativeComboBox
                case bgwWorkerComboBox:
                    tempDataTable = new Sp_Worker().GetWorkersAllForComboBox();
                    break;
                    #endregion
            }
        }

        private void bgw_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (bgwMode)
            {
                case bgwWorkerComboBox:
                    cmbRepresentative.ValueMember = "WorkerID";
                    cmbRepresentative.DisplayMember = "NameLastName";
                    cmbRepresentative.DataSource = tempDataTable;
                    break;
            }
        }
    }
}
