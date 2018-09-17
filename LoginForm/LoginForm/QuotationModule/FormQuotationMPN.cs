using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginForm.QuotationModule
{
    public partial class FormQuotationMPN : MyForm
    {
        object ItemList;
        public string ItemCode;
        object choosenItem;
        object _parent;

        public FormQuotationMPN(object parent, dynamic List)
        {
            InitializeComponent();
            dgItemList.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 185, 194);
            _parent = parent;
            this.ItemList = List;
        }

        private void FormQuotationMPN_Load(object sender, EventArgs e)
        {
            dgItemList.DataSource = ItemList;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            QuotationUtils.ItemCode = dgItemList.CurrentRow.Cells[0].Value.ToString();

            switch (_parent.GetType().Name)
            {
                case "FormQuotationItemSearch":
                    ((FormQuotationItemSearch)_parent).ItemCode = dgItemList.CurrentRow.Cells[0].Value.ToString();
                    break;
                case "ExperimentQuotationAdd":
                    ItemCode = dgItemList.CurrentRow.Cells[0].Value.ToString();
                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}
