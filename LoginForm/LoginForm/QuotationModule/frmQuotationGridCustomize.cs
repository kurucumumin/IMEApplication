using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm.QuotationModule
{
    public partial class frmQuotationGridCustomize : Form
    {
        List<bool> ischecked = new List<bool>();
        List<CheckBox> cboxList = new List<CheckBox>();
        DataGridView datagrid;

        public frmQuotationGridCustomize()
        {
            InitializeComponent();
        }

        public frmQuotationGridCustomize( DataGridView dg)
        {
            InitializeComponent();
            datagrid = dg;
           
            CheckBox box;
            //int previousLength = 0;
            //int y = 10;
            //for (int i = 0; i < datagrid.Columns.Count; i++)
            //{
            //    if (datagrid.Columns[i].Name != "dgHZ" && datagrid.Columns[i].Name != "dgCL" && datagrid.Columns[i].Name != "dgCR")
            //    {
            //        box = new CheckBox();
            //        box.Tag = i.ToString();
            //        box.Text = datagrid.Columns[i].Name;
            //        box.AutoSize = true;
            //        if (10 + previousLength >= this.Width)
            //        {
            //            y = y + 30;
            //            previousLength = 0;
            //        }
            //        box.Location = new Point(10 + previousLength, y);
            //        previousLength = previousLength + box.Width;
            //        cboxList.Add(box);
            //        this.Controls.Add(box);
            //        ischecked.Add(false);
            //    }
            //}
            //ExportButton.Location = new Point(this.Width / 2, y + 30);
            //btnSelectAll.Location = new Point(0, y + 30);
            //btnClearAll.Location = new Point(btnSelectAll.Width + 5, y + 30);
        }
        

        private void DoneButton_Click(object sender, EventArgs e)
        {
            QuotationDatagridCustomize.VisibleFalseNames.Clear();
            for (int i = 0; i < cboxList.Count; i++)
            {
                if (!cboxList[i].Checked)
                {
                    QuotationDatagridCustomize.VisibleFalseNames.Add(i);
                }
            }
            this.Close();
        }

        private void PlaceCheckBoxes()
        {
            CheckBox box;
            int previousLength = 0;
            int y = 10;
            for (int i = 0; i < datagrid.Columns.Count; i++)
            {
                box = new CheckBox
                {
                    Tag = i.ToString(),
                    Text = datagrid.Columns[i].HeaderText,
                    AutoSize = true
                };
                if (25 + previousLength >= this.Width)
                {
                    y = y + 25;
                    previousLength = 0;
                }
                box.Location = new Point(25 + previousLength, y);
                previousLength = previousLength + box.Width+15;
                cboxList.Add(box);
                this.Controls.Add(box);
                ischecked.Add(true);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (var item in cboxList)
            {
                item.Checked = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var item in cboxList)
            {
                item.Checked = false;
            }
        }

        private void frmQuotationGridCustomize_Load(object sender, EventArgs e)
        {
            PlaceCheckBoxes();
        }
    }
}
