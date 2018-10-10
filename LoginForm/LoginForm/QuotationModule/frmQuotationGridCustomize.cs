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
        object result;
        public frmQuotationGridCustomize()
        {
            InitializeComponent();
        }

        public frmQuotationGridCustomize(DataGridView dg)
        {
            InitializeComponent();
            datagrid = dg;
            if (QuotationDatagridCustomize.VisibleTrueNames.Count != 0)
            {
                TempCheckBoxes();
            }
            else
            {
                PlaceCheckBoxes();
            }
        }
        

        private void DoneButton_Click(object sender, EventArgs e)
        {
            QuotationDatagridCustomize.VisibleFalseNames.Clear();
            QuotationDatagridCustomize.VisibleTrueNames.Clear();
            if (datagrid.ColumnCount<cboxList.Count)
            {
                cboxList.Clear();
            }
            

            for (int i = 0; i < cboxList.Count; i++)
            {
                if (!cboxList[i].Checked)
                {   
                    QuotationDatagridCustomize.VisibleFalseNames.Add(i);
                }
                if (cboxList[i].Checked)
                {
                    QuotationDatagridCustomize.VisibleTrueNames.Add(i);
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
            foreach (var item in cboxList)
            {
                item.Checked = true;
            }
            
        }

        private void TempCheckBoxes()
        {
            
            CheckBox box;
            int previousLength = 0;
            int y = 10;
            for (int i = 0; i < QuotationDatagridCustomize.VisibleTrueNames.Count; i++)
            {
                box = new CheckBox
                {
                    Tag = i.ToString(),
                    Text = QuotationDatagridCustomize.VisibleTrueNames[i].ToString(),
                    AutoSize = true
                };
                if (25 + previousLength >= this.Width)
                {
                    y = y + 25;
                    previousLength = 0;
                }
                box.Location = new Point(25 + previousLength, y);
                previousLength = previousLength + box.Width + 15;
                cboxList.Add(box);
                this.Controls.Add(box);
                ischecked.Add(true);
            }
            foreach (var item in cboxList)
            {
                item.Checked = true;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //foreach (var item in cboxList)
            //{
            //    item.Checked = true;
            //}
            PlaceCheckBoxes();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (var item in cboxList)
            {
                item.Checked = false;
            }
        }
        
    }
}
