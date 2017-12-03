using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.nmSaleOrder
{
    public partial class FormSaleItemSearch : Form
    {
        string searchItemCode = null;

        public object selectedItem = new object();

        public FormSaleItemSearch(string ItemCode = "")
        {
            InitializeComponent();
            searchItemCode = ItemCode;
        }

        private void SaleItemSearch_Load(object sender, EventArgs e)
        {
            if (searchItemCode != null && searchItemCode != String.Empty)
            {
                txtItemCode.Text = searchItemCode;
                dgItemSearch.DataSource = SearchForItems(searchItemCode);
            }
        }

        private dynamic SearchForItems(string ItemCode, bool isMPN = false)
        {
            IMEEntities IME = new IMEEntities();

            dynamic gridAdapterPC = new object();
            dynamic list2 = new object();
            dynamic list3 = new object();

            switch (isMPN)
            {
                case false:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.Article_No.Contains(ItemCode))
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         MPN = a.MPN,
                                         customerworker.Note.Note_name,
                                         //Supplier = a.Manufacturer,
                                         UniteCode = a.Unit_Content,
                                         StandardWeight = a.Standard_Weight,
                                         dependantTable = "sd"
                                         //HzrInd = a.Hazardous_Ind,
                                         //Calib = a.Calibration_Ind
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.Article_No.Contains(ItemCode))
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 MPN = a.MPN,
                                 customerworker.Note.Note_name,
                                 //Supplier = a.Manufacturer,
                                 UniteCode = a.Unit_Content,
                                 StandardWeight = a.Standard_Weight,
                                 dependantTable = "sdp"
                                 //HzrInd = a.Hazardous_Ind,
                                 //Calib = a.Calibration_Ind
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.ArticleNo.Contains(ItemCode))
                                 //join sup in IME.Suppliers on a.ManufacturerCode equals sup.ID
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()

                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 MPN = a.MPN,
                                 customerworker.Note.Note_name,
                                 //Supplier = sup.s_name,
                                 UniteCode = a.PackSize,
                                 StandardWeight = a.ExtendedRangeWeight,
                                 dependantTable = "ext"
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
                case true:
                    gridAdapterPC = (from a in IME.SuperDisks.Where(a => a.MPN == ItemCode)
                                     join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                                     let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                                     select new
                                     {
                                         ArticleNo = a.Article_No,
                                         ArticleDesc = a.Article_Desc,
                                         MPN = a.MPN,
                                         customerworker.Note.Note_name,
                                         dependantTable = "sd"
                                     }
                         ).ToList();
                    list2 = (from a in IME.SuperDiskPs.Where(a => a.MPN == ItemCode)
                             join customerworker in IME.ItemNotes on a.Article_No equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.Article_No,
                                 ArticleDesc = a.Article_Desc,
                                 MPN = a.MPN,
                                 customerworker.Note.Note_name,
                                 dependantTable = "sdp"
                                 //a.CofO,
                                 //a.Pack_Code
                             }
                ).ToList();
                    list3 = (from a in IME.ExtendedRanges.Where(a => a.MPN == ItemCode)
                             join customerworker in IME.ItemNotes on a.ArticleNo equals customerworker.ArticleNo into customerworkeres
                             let customerworker = customerworkeres.Select(customerworker1 => customerworker1).FirstOrDefault()
                             select new
                             {
                                 ArticleNo = a.ArticleNo,
                                 ArticleDesc = a.ArticleDescription,
                                 MPN = a.MPN,
                                 customerworker.Note.Note_name,
                                 dependantTable = "ext"
                             }
                                ).ToList();
                    gridAdapterPC.AddRange(list2);
                    gridAdapterPC.AddRange(list3);
                    break;
            }

            return gridAdapterPC;
        }

        private void dgItemSearch_DoubleClick(object sender, EventArgs e)
        {
            string ItemCode = dgItemSearch.CurrentRow.Cells[0].Value.ToString();
            string dependantTable = dgItemSearch.CurrentRow.Cells[6].Value.ToString();
            selectedItem = dgItemSearch.CurrentRow;

            this.Close();
        }
    }
}
