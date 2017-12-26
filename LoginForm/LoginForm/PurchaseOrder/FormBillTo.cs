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
using LoginForm.Services;

namespace LoginForm.PurchaseOrder
{
    public partial class FormBillTo : Form
    {
        IMEEntities IME = new IMEEntities();
        List<Mail> MailList = new List<Mail>();
        List<int> addedBillIndex = new List<int>();

        public FormBillTo()
        {
            InitializeComponent();
        }

        private void dgBillTo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex + 1 > MailList.Count)
            {
                addedBillIndex.Add(e.RowIndex - 1);
            }
        }
    }
}
