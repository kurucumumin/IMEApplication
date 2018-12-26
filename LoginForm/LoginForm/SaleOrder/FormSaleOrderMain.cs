using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LoginForm.DataSet;
using System.Linq;
using System.Drawing;
using LoginForm.PurchaseOrder;
using LoginForm.QuotationModule;
using LoginForm.Services;
using System.Data;
using LoginForm.clsClasses;
using static LoginForm.Services.MyClasses.MyAuthority;
using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services.SP;

namespace LoginForm
{
    public partial class FormSalesOrderMain : MyForm
    {
        //List<SalesOrder> list = new List<SalesOrder>
        ContextMenu PurchaseOrderMenu = new ContextMenu();
        LogoLibrary logoLibrary = new LogoLibrary();
        public FormSalesOrderMain()
        {
            InitializeComponent();
            dgSales.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor ;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgSales, new object[] { true });
        }


        private void ControlAutorization()
        {
            if (!Utils.AuthorityCheck(IMEAuthority.AddSaleOrderModule))
            {
                btnNew.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.EditSaleOrderModule))
            {
                btnModify.Visible = false;
            }
            if (!Utils.AuthorityCheck(IMEAuthority.DeleteSaleOrderModule))
            {
                btnDelete.Visible = false;
            }
        }


        private void FormSalesOrderMain_Load(object sender, EventArgs e)
        {
            ControlAutorization();
            datetimeEnd.MaxDate = DateTime.Today.Date;
            datetimeEnd.Value = DateTime.Today.Date;
            datetimeStart.Value = DateTime.Today.AddMonths(-3);
            BringSalesList(DateTime.Now, datetimeStart.Value);
        }

        private void BringSalesList()
        {
            BringSalesList(DateTime.Today, DateTime.Today.AddDays(-7));
        }

        private void BringSalesList(DateTime endDate, DateTime startDate)
        {
            dgSales.Rows.Clear();
            dgSales.Refresh();

            IMEEntities IME = new IMEEntities();
            endDate = endDate.AddDays(1);
            var list = (from so in IME.SaleOrders
                        join c in IME.Customers on so.CustomerID equals c.ID
                        join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                        join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                        join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                        join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                        from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                        where so.SaleDate <= endDate && so.SaleDate >= startDate
                       select new
                       {
                           Date = so.SaleDate,
                           SaleOrderNO = so.SaleOrderNo,
                           CustomerName = c.c_name,
                           Total= so.SubTotal,
                           Contact = cw.cw_name,
                           DeliveryContact = cwd.cw_name,
                           Address = cai.AdressTitle,
                           DeliveryAddress = cad.AdressTitle,
                           SaleID = so.SaleOrderID,
                           Status = so.Status,
                           QuotationNo = so.QuotationNos,
                           PurchaseID = so.PurchaseOrderID,
                           PurchaseDate = po.PurchaseOrderDate,
                           Currency = so.CurrName
                       }).OrderByDescending(s=> s.SaleOrderNO);
            populateGrid(list.ToList());
        }

        private void populateGrid<T>(List<T> queryable)
        {
            dgSales.Rows.Clear();
            dgSales.Refresh();


            foreach (dynamic item in queryable)
            {
                int rowIndex = dgSales.Rows.Add();
                DataGridViewRow row = dgSales.Rows[rowIndex];


                row.Cells[Date.Index].Value = item.Date;
                row.Cells[SaleOrderNO.Index].Value = item.SaleOrderNO;
                row.Cells[CustomerName.Index].Value = item.CustomerName;
                row.Cells[Total.Index].Value = item.Total;
                row.Cells[Contact.Index].Value = item.Contact;
                row.Cells[DeliveryContact.Index].Value = item.DeliveryContact;
                row.Cells[Address.Index].Value = item.Address;
                row.Cells[DeliveryAddress.Index].Value = item.DeliveryAddress;
                row.Cells[SaleID.Index].Value = item.SaleID;
                row.Cells[Status.Index].Value = item.Status;
                row.Cells[QuotationNo.Index].Value = item.QuotationNo;
                row.Cells[PurchaseID.Index].Value = item.PurchaseID;
                row.Cells[PurchaseDate.Index].Value = item.PurchaseDate;
                row.Cells[Currency.Index].Value = item.Currency;
            }

            foreach (DataGridViewRow row in dgSales.Rows)
            {
                if (row.Cells[Status.Index].Value != null && row.Cells[Status.Index].Value.ToString() == "Sent to LOGO")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 0);
                }
                else if (row.Cells[Status.Index].Value != null && row.Cells[Status.Index].Value.ToString() == "Sent to RS")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(204, 237, 220);
                }
                else if (row.Cells[Status.Index].Value != null && row.Cells[Status.Index].Value.ToString() == "Sent to RS")
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                }
                //if (row.Cells[PurchaseID.Index].Value != null)
                //{
                //    row.DefaultCellStyle.BackColor = ImeSettings.GridPurchaseOrderCreatedRowColor ;
                //}
                //else if (row.Cells[PurchaseID.Index].Value == null && row.Cells[PurchaseID.Index].Value.ToString() == "")
                //{
                //    row.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
                //}

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormSaleOrderCreate form = new FormSaleOrderCreate();
            Utils.LogKayit("Sale Order", "Sale Order create screen has been entered");
            form.Show();
            BringSalesList();
        }
        private void dgSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {

                if (dgSales.CurrentRow != null)
                {
                    IMEEntities IME = new IMEEntities();

                    //string SaleOrderNo = dgSales.CurrentRow.Cells[1].Value.ToString();
                    //TODO gridde saleID'de olmalı.
                    decimal SaleID = (decimal)dgSales.CurrentRow.Cells[1].Value;

                    SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderID == SaleID).FirstOrDefault();

                   // NewPurchaseOrder form = new NewPurchaseOrder(so);
                   // form.ShowDialog();
                }
            }
        }

        private void dgSales_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgSales.CurrentRow != null)
            {
                IMEEntities IME = new IMEEntities();

                //string SaleOrderNo = dgSales.CurrentRow.Cells[1].Value.ToString();
                //TODO gridde saleID'de olmalı.
                decimal SaleID = (decimal)dgSales.CurrentRow.Cells[1].Value;

                SaleOrder so = IME.SaleOrders.Where(x => x.SaleOrderID == SaleID).FirstOrDefault();

               // NewPurchaseOrder form = new NewPurchaseOrder(so);
              //  form.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgSales.CurrentRow != null)
            {
                List<int> SoNOsToDelete = new List<int>();
                foreach (DataGridViewRow item in dgSales.SelectedRows)
                {
                    SoNOsToDelete.Add(Convert.ToInt32(item.Cells[SaleOrderNO.Index].Value.ToString()));
                }
                DialogResult result = MessageBox.Show("Selected SaleOrder(s) will be deleted! Do you confirm?", "Delete SaleOrder", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    try
                    {
                        IMEEntities IME = new IMEEntities();

                        foreach (int row in SoNOsToDelete)
                        {
                            string SaleOrderNo = row.ToString();

                            SaleOrder s = IME.SaleOrders.Where(x => x.SaleOrderNo.ToString() == SaleOrderNo).FirstOrDefault();

                            s.Status = "Deleted";

                            IME.SaveChanges();
                        }
                        BringSalesList(datetimeEnd.Value.Date, datetimeStart.Value.Date);

                        MessageBox.Show("Sale Order is successfully deleted.", "Success!");
                        Utils.LogKayit("Sale Order", "Sale Order deleted");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("An error was encountered", "Error!");
                        throw;
                    }
                }
            }
            else
            {
                MessageBox.Show("You did not chose any Sale Order.", "Warning!");
            }



            //IMEEntities db = new IMEEntities();
            //foreach (DataGridViewRow row in dgSales.SelectedRows)
            //{
            //    //string SaleID = row.Cells[1].Value.ToString();
            //    //TODO gridde saleID'de olmalı.
            //    decimal SaleID = (decimal)dgSales.CurrentRow.Cells[1].Value;
            //    SaleOrder s = db.SaleOrders.Where(x => x.SaleOrderID == SaleID).FirstOrDefault();
            //    if(s != null)
            //    {
            //        if (s.SaleOrderDetails != null)
            //        {
            //            db.SaleOrderDetails.RemoveRange(s.SaleOrderDetails);
            //        }
            //        db.SaleOrders.Remove(s);
            //        db.SaveChanges();
            //    }
            //}
            //BringSalesList();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            BringSalesList(datetimeEnd.Value.Date, datetimeStart.Value.Date);
        }

        private void sentToPurchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal item_code = 0;
            IMEEntities IME = new IMEEntities();
            
            if (dgSales.CurrentRow.Cells[SaleOrderNO.Index].Value != null)
            {
                DataSet.PurchaseOrderDetail po = new DataSet.PurchaseOrderDetail();
                item_code = Convert.ToDecimal(dgSales.CurrentRow.Cells[SaleID.Index].Value.ToString());
                po = IME.PurchaseOrderDetails.Where(x => x.SaleOrderID == item_code).FirstOrDefault();

                if (item_code != 0 && po == null)
                {
                    this.Close();
                    NewPurchaseOrder f = new NewPurchaseOrder(item_code);
                    Utils.LogKayit("Sale Order", "Sale Order send to purchase order");
                    f.Show();
                }
                else
                {
                    MessageBox.Show("SaleOrder is locked to Purchase Order Number: " + po.PurchaseOrder.PurchaseNo,"Warning",MessageBoxButtons.OKCancel);
                }

            }
        }

        private void sentToLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMEEntities db = new IMEEntities();
            int SoNO = Convert.ToInt32(dgSales.CurrentRow.Cells["SaleOrderNO"].Value);
            string resultMessage = logoLibrary.SendToLogo_SaleOrder(SoNO);

            SaleOrder so = db.SaleOrders.Where(x => x.SaleOrderNo == SoNO).FirstOrDefault();

            if (so.Status == "LOGO")
            {
                MessageBox.Show("Sent To Logo Successfully");
            }
            else
            {
                if (resultMessage == LogoLibrary.AddSuccessful)
                {

                    so.Status = "LOGO";
                    db.SaveChanges();

                    BringSalesList(datetimeEnd.Value.Date, datetimeStart.Value.Date);
                    MessageBox.Show("Sent To Logo Successfully");
                    Utils.LogKayit("Sale Order", "Sale Order send to logo");
                }
                else
                {
                    MessageBox.Show("Operation Failed" + "\n\nError Message: " + resultMessage);
                }
            }

        }

        private void dgSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ViewSaleOrder();
        }

        private void ViewSaleOrder()
        {
            if (dgSales.CurrentRow != null)
            {
                decimal QuotationNo = Convert.ToDecimal(dgSales.CurrentRow.Cells[SaleOrderNO.Index].Value);
                SaleOrder saleOrder;

                IMEEntities IME = new IMEEntities();
                try
                {
                    saleOrder = IME.SaleOrders.Where(s => s.SaleOrderNo == QuotationNo).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }
                if (saleOrder != null)
                {
                    FormSaleOrderAdd newForm = new FormSaleOrderAdd(saleOrder.Customer, saleOrder.SaleOrderDetails.ToList(), Convert.ToInt32(QuotationNo), saleOrder);
                    //XtraFormSaleOrder newForm = new XtraFormSaleOrder(saleOrder, this, "View");
                    newForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
        }

        private void txtSearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && cbSearch.SelectedItem != null)
            {
                if (chcAllSales.Checked == true)
                {
                    IMEEntities IME = new IMEEntities();
                    switch (cbSearch.SelectedItem.ToString())
                    {
                        case "QUOT NUMBER":
                            var list1 = (from so in IME.SaleOrders
                                         join c in IME.Customers on so.CustomerID equals c.ID
                                         join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                         join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                         join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                         join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                         from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                         select new
                                         {
                                             Date = so.SaleDate,
                                             SaleOrderNO = so.SaleOrderNo,
                                             CustomerName = c.c_name,
                                             Total = so.SubTotal,
                                             Contact = cw.cw_name,
                                             DeliveryContact = cwd.cw_name,
                                             Address = cai.AdressTitle,
                                             DeliveryAddress = cad.AdressTitle,
                                             SaleID = so.SaleOrderID,
                                             Status = so.Status,
                                             QuotationNo = so.QuotationNos,
                                             PurchaseID = so.PurchaseOrderID,
                                             PurchaseDate = po.PurchaseOrderDate,
                                             Currency = so.CurrName
                                         }).ToList().Where(x => x.SaleOrderNO.ToString().Contains(txtSearchText.Text));
                            //DataTable list1 = new DataTable();
                            //list1 = new Sp_SaleOrder().SearchSaleOrdersWithSaleNo(txtSearchText.Text);
                            dgSales.DataSource = list1;
                            populateGrid(list1.ToList());
                            break;

                        case "CUSTOMER CODE":
                            string customerCode = txtSearchText.Text.ToUpperInvariant();
                            var list2 = from so in IME.SaleOrders
                                        join c in IME.Customers on so.CustomerID equals c.ID
                                        join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                        join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                        join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                        join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                        from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                        where c.ID.Contains(customerCode)
                                        select new
                                        {
                                            Date = so.SaleDate,
                                            SaleOrderNO = so.SaleOrderNo,
                                            CustomerName = c.c_name,
                                            Total = so.SubTotal,
                                            Contact = cw.cw_name,
                                            DeliveryContact = cwd.cw_name,
                                            Address = cai.AdressTitle,
                                            DeliveryAddress = cad.AdressTitle,
                                            SaleID = so.SaleOrderID,
                                            Status = so.Status,
                                            QuotationNo = so.QuotationNos,
                                            PurchaseID = so.PurchaseOrderID,
                                            PurchaseDate = po.PurchaseOrderDate,
                                            Currency = so.CurrName
                                        };

                            populateGrid(list2.ToList());
                            break;

                        case "CUSTOMER NAME":
                            string customerName = txtSearchText.Text.ToUpperInvariant();
                            var list3 = from so in IME.SaleOrders
                                        join c in IME.Customers on so.CustomerID equals c.ID
                                        join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                        join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                        join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                        join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                        from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                        where c.c_name.Contains(customerName)
                                        select new
                                        {
                                            Date = so.SaleDate,
                                            SaleOrderNO = so.SaleOrderNo,
                                            CustomerName = c.c_name,
                                            Total = so.SubTotal,
                                            Contact = cw.cw_name,
                                            DeliveryContact = cwd.cw_name,
                                            Address = cai.AdressTitle,
                                            DeliveryAddress = cad.AdressTitle,
                                            SaleID = so.SaleOrderID,
                                            Status = so.Status,
                                            QuotationNo = so.QuotationNos,
                                            PurchaseID = so.PurchaseOrderID,
                                            PurchaseDate = po.PurchaseOrderDate,
                                            Currency = so.CurrName
                                        };

                            populateGrid(list3.ToList());
                            break;

                        case "BY TOTAL AMOUNT":
                            decimal amountDecimal;
                            string searchTxt = txtSearchText.Text.Replace(",", ".");
                            if (Decimal.TryParse(searchTxt, out amountDecimal))
                            {
                                int amount = Decimal.ToInt32(amountDecimal);
                                var list4 = from so in IME.SaleOrders
                                            join c in IME.Customers on so.CustomerID equals c.ID
                                            join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                            join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                            join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                            join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                            from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                            where amount <= (so.TotalPrice + so.ExtraCharges + so.Vat) && (so.TotalPrice + so.ExtraCharges + so.Vat) < (amount + 1)
                                            select new
                                            {
                                                Date = so.SaleDate,
                                                SaleOrderNO = so.SaleOrderNo,
                                                CustomerName = c.c_name,
                                                Total = so.SubTotal,
                                                Contact = cw.cw_name,
                                                DeliveryContact = cwd.cw_name,
                                                Address = cai.AdressTitle,
                                                DeliveryAddress = cad.AdressTitle,
                                                SaleID = so.SaleOrderID,
                                                Status = so.Status,
                                                QuotationNo = so.QuotationNos,
                                                PurchaseID = so.PurchaseOrderID,
                                                PurchaseDate = po.PurchaseOrderDate,
                                                Currency = so.CurrName
                                            };

                                populateGrid(list4.ToList());
                            }

                            break;

                        case "BY LPONO":
                            string lpono = txtSearchText.Text.ToUpperInvariant();
                            var list5 = from so in IME.SaleOrders
                                        join c in IME.Customers on so.CustomerID equals c.ID
                                        join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                        join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                        join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                        join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                        from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                        where so.LPONO.Contains(lpono)
                                        select new
                                        {
                                            Date = so.SaleDate,
                                            SaleOrderNO = so.SaleOrderNo,
                                            CustomerName = c.c_name,
                                            Total = so.SubTotal,
                                            Contact = cw.cw_name,
                                            DeliveryContact = cwd.cw_name,
                                            Address = cai.AdressTitle,
                                            DeliveryAddress = cad.AdressTitle,
                                            SaleID = so.SaleOrderID,
                                            Status = so.Status,
                                            QuotationNo = so.QuotationNos,
                                            PurchaseID = so.PurchaseOrderID,
                                            PurchaseDate = po.PurchaseOrderDate,
                                            Currency = so.CurrName
                                        };

                            populateGrid(list5.ToList());
                            break;

                        case "BY MPN":
                            //string mpn = txtSearchText.Text.ToUpperInvariant();
                            //var list6 = from q in IME.Quotations
                            //            join qd in IME.QuotationDetails on q.QuotationNo equals qd.QuotationNo
                            //            join c in IME.Customers on q.CustomerID equals c.ID
                            //            where qd.MPN.Contains(mpn)
                            //            select new
                            //            {
                            //                Date = (DateTime)q.StartDate,
                            //                QuotationNo = q.QuotationNo,
                            //                RFQ = q.RFQNo,
                            //                CustomerCode = c.ID,
                            //                CustomerName = c.c_name
                            //            };

                            //populateGrid(list6.ToList());
                            MessageBox.Show("MPN filter is not implemented into the software", "Error");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    IMEEntities IME = new IMEEntities();
                    switch (cbSearch.SelectedItem.ToString())
                    {
                        case "QUOT NUMBER":
                            var list1 = (from so in IME.SaleOrders
                                         join c in IME.Customers on so.CustomerID equals c.ID
                                         join cai in IME.CustomerAddresses on so.InvoiceAddressID equals cai.ID
                                         join cad in IME.CustomerAddresses on so.DeliveryAddressID equals cad.ID
                                         join cw in IME.CustomerWorkers on so.ContactID equals cw.ID
                                         join cwd in IME.CustomerWorkers on so.DeliveryContactID equals cwd.ID
                                         from po in IME.PurchaseOrders.Where(x => x.purchaseOrderId == so.PurchaseOrderID).DefaultIfEmpty()
                                         where so.SaleDate >= datetimeStart.Value && so.SaleDate < datetimeEnd.Value
                                         select new
                                         {
                                             Date = so.SaleDate,
                                             SaleOrderNO = so.SaleOrderNo,
                                             CustomerName = c.c_name,
                                             Total = so.SubTotal,
                                             Contact = cw.cw_name,
                                             DeliveryContact = cwd.cw_name,
                                             Address = cai.AdressTitle,
                                             DeliveryAddress = cad.AdressTitle,
                                             SaleID = so.SaleOrderID,
                                             Status = so.Status,
                                             QuotationNo = so.QuotationNos,
                                             PurchaseID = so.PurchaseOrderID,
                                             PurchaseDate = po.PurchaseOrderDate,
                                             Currency = so.CurrName
                                         }).ToList().Where(x => x.SaleOrderNO.ToString().Contains(txtSearchText.Text));

                            populateGrid(list1.ToList());
                            break;

                        //        case "CUSTOMER CODE":
                        //            string customerCode = txtSearchText.Text.ToUpperInvariant();
                        //            var list2 = from q in IME.Quotations
                        //                        join c in IME.Customers on q.CustomerID equals c.ID
                        //                        where (c.ID.Contains(customerCode)
                        //                        && q.StartDate >= dtpFromDate.Value && q.StartDate < dtpToDate.Value)
                        //                        select new
                        //                        {
                        //                            Date = q.StartDate,
                        //                            QuotationNo = q.QuotationNo,
                        //                            RFQ = q.RFQNo,
                        //                            CustomerCode = c.ID,
                        //                            CustomerName = c.c_name,
                        //                            Total = q.GrossTotal,
                        //                            Currency = q.CurrName,
                        //                            Notes = q.Note.Note_name,
                        //                            Representative = q.Worker.NameLastName,
                        //                            Status = q.status
                        //                        };

                        //            populateGrid(list2.ToList());
                        //            break;

                        //        case "CUSTOMER NAME":
                        //            string customerName = txtSearchText.Text.ToUpperInvariant();
                        //            var list3 = from q in IME.Quotations
                        //                        join c in IME.Customers on q.CustomerID equals c.ID
                        //                        where (c.c_name.Contains(customerName)
                        //                        && q.StartDate >= dtpFromDate.Value && q.StartDate < dtpToDate.Value)
                        //                        select new
                        //                        {
                        //                            Date = q.StartDate,
                        //                            QuotationNo = q.QuotationNo,
                        //                            RFQ = q.RFQNo,
                        //                            CustomerCode = c.ID,
                        //                            CustomerName = c.c_name,
                        //                            Total = q.GrossTotal,
                        //                            Currency = q.CurrName,
                        //                            Notes = q.Note.Note_name,
                        //                            Representative = q.Worker.NameLastName,
                        //                            Status = q.status
                        //                        };

                        //            populateGrid(list3.ToList());
                        //            break;

                        //        case "BY TOTAL AMOUNT":
                        //            decimal amountDecimal;
                        //            string searchTxt = txtSearchText.Text.Replace(",", ".");
                        //            if (Decimal.TryParse(searchTxt, out amountDecimal))
                        //            {
                        //                int amount = Decimal.ToInt32(amountDecimal);
                        //                var list4 = from q in IME.Quotations
                        //                            join c in IME.Customers on q.CustomerID equals c.ID
                        //                            where (amount <= q.GrossTotal && q.GrossTotal < (amount + 1)
                        //                            && q.StartDate >= dtpFromDate.Value && q.StartDate < dtpToDate.Value)
                        //                            select new
                        //                            {
                        //                                Date = q.StartDate,
                        //                                QuotationNo = q.QuotationNo,
                        //                                RFQ = q.RFQNo,
                        //                                CustomerCode = c.ID,
                        //                                CustomerName = c.c_name,
                        //                                Total = q.GrossTotal,
                        //                                Currency = q.CurrName,
                        //                                Notes = q.Note.Note_name,
                        //                                Representative = q.Worker.NameLastName,
                        //                                Status = q.status
                        //                            };

                        //                populateGrid(list4.ToList());
                        //            }

                        //            break;

                        //        case "BY RFQ":
                        //            string rfq = txtSearchText.Text.ToUpperInvariant();
                        //            var list5 = from q in IME.Quotations
                        //                        join c in IME.Customers on q.CustomerID equals c.ID
                        //                        where (q.RFQNo.Contains(rfq)
                        //                        && q.StartDate >= dtpFromDate.Value && q.StartDate < dtpToDate.Value)
                        //                        select new
                        //                        {
                        //                            Date = q.StartDate,
                        //                            QuotationNo = q.QuotationNo,
                        //                            RFQ = q.RFQNo,
                        //                            CustomerCode = c.ID,
                        //                            CustomerName = c.c_name,
                        //                            Total = q.GrossTotal,
                        //                            Currency = q.CurrName,
                        //                            Notes = q.Note.Note_name,
                        //                            Representative = q.Worker.NameLastName,
                        //                            Status = q.status
                        //                        };

                        //            populateGrid(list5.ToList());
                        //            break;

                        //        case "BY MPN":
                        //            //string mpn = txtSearchText.Text.ToUpperInvariant();
                        //            //var list6 = from q in IME.Quotations
                        //            //            join qd in IME.QuotationDetails on q.QuotationNo equals qd.QuotationNo
                        //            //            join c in IME.Customers on q.CustomerID equals c.ID
                        //            //            where qd.MPN.Contains(mpn)
                        //            //            select new
                        //            //            {
                        //            //                Date = (DateTime)q.StartDate,
                        //            //                QuotationNo = q.QuotationNo,
                        //            //                RFQ = q.RFQNo,
                        //            //                CustomerCode = c.ID,
                        //            //                CustomerName = c.c_name
                        //            //            };

                        //            //populateGrid(list6.ToList());
                        //MessageBox.Show("MPN filter is not implemented into the software", "Error");
                        //break;
                        default:
                            break;
                    }
                }
            }
         }

        private void backFromLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SoNO = Convert.ToInt32(dgSales.CurrentRow.Cells["SaleOrderNO"].Value);
            string resultMessage = logoLibrary.BackFromLogo_SaleOrder(SoNO);

            if (resultMessage == LogoLibrary.DeleteSuccessful)
            {
                IMEEntities db = new IMEEntities();

                SaleOrder so = db.SaleOrders.Where(x=>x.SaleOrderNo == SoNO).FirstOrDefault();
                so.Status = "";
                db.SaveChanges();

                BringSalesList(datetimeEnd.Value.Date, datetimeStart.Value.Date);
                MessageBox.Show("Deleted From Logo Successfully");
                Utils.LogKayit("Sale Order", "Sale Order delete from logo");
            }
            else
            {
                MessageBox.Show("Operation Failed" + "\n\nError Message: " + resultMessage);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            Utils.LogKayit("Sale Order", "Sale Order excel");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Utils.LogKayit("Sale Order", "Sale Order print");
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgSales.CurrentRow != null)
            {
                decimal SaleOrderNO = Convert.ToDecimal(dgSales.CurrentRow.Cells["SaleOrderNO"].Value.ToString());
                string CustomerName = dgSales.CurrentRow.Cells["CustomerName"].Value.ToString();
                SaleOrder so;
                Customer co;
                IMEEntities IME = new IMEEntities();
                try
                {
                    so = IME.SaleOrders.Where(q => q.SaleOrderNo == SaleOrderNO).FirstOrDefault();
                    co = IME.Customers.Where(c => c.c_name == CustomerName).FirstOrDefault();
                }
                catch (Exception)
                {

                    throw;
                }

                if (so.ViewSale != false)
                {
                    so.ViewSale = false;
                    IME.SaveChanges();

                    FormSaleOrderAdd newForm = new FormSaleOrderAdd(so, this, "Update", co);
                    //XtraFormSaleOrder newForm = new XtraFormSaleOrder(so, this, "Update");
                    Utils.LogKayit("SaleOrder", "SaleOrder update screen has been entered");
                    newForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(Utils.getCurrentUser().UserName + "is working on this Sale Order");
                }

            }
            else
            {
                MessageBox.Show("You did not chose any quotation.", "Warning!");
            }
        }
    }
}
