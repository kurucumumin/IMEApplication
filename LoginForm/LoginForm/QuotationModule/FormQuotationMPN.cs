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

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationMPN : Form
    {
        object ItemList;

        object choosenItem;

        public FormQuotationMPN(dynamic List)
        {
            InitializeComponent();
            this.ItemList = List;
        }

        private void FormQuotationMPN_Load(object sender, EventArgs e)
        {
            dgItemList.DataSource = ItemList;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            classQuotationAdd.ItemCode = dgItemList.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void dgItemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dgItemList.SelectedRows != null)
            {
                btnSelect.PerformClick();
            }
        }

        private void dgItemList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgItemList.SelectedRows != null)
            {
                btnSelect.PerformClick();
            }
        }
    }
}
