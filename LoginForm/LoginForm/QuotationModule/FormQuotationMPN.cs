using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
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
            dgItems.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;
            _parent = parent;
            this.ItemList = List;
        }

        private void FormQuotationMPN_Load(object sender, EventArgs e)
        {
            dgItems.DataSource = ItemList;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgItems.Rows.Count; i++)
            //{
            //    dgItems.Rows[i].Cells[chk.Index].Value = true;
            //}
        }

        private void SelectedMpn()
        {
            QuotationUtils.ItemCode = dgItems.CurrentRow.Cells[0].Value.ToString();

            switch (_parent.GetType().Name)
            {
                case "FormQuotationItemSearch":
                    ((FormQuotationItemSearch)_parent).ItemCode = dgItems.CurrentRow.Cells[0].Value.ToString();
                    break;

                case "ExperimentQuotationAdd":
                    ItemCode = dgItems.CurrentRow.Cells[0].Value.ToString();
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgItems.Rows.Count; i++)
            //{
            //    dgItems.Rows[i].Cells[chk.Index].Value = false;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedMpn();
        }
    }
}
