using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class TaxSP
    {
        public DataTable TaxViewAllByVoucherTypeId(decimal decVoucherTypeId)
        {
            DataTable dtbl = new DataTable();
            IMEEntities IME = new IMEEntities();
            var Taxes = (from a in IME.Taxes
                         from b in IME.VoucherTypeTaxes
                         from c in IME.AccountLedgers
                         where (a.TaxID == b.taxId) && (a.taxName == c.ledgerName) && (b.voucherTypeId == decVoucherTypeId) && (a.isActive == true)
                         select new
                         {
                             a.TaxID,
                             c.ledgerId,
                             a.taxName,
                             a.ApplicationOn,
                             a.CalculatingMode,
                             a.Rate
                         }).ToList();

            dtbl.Columns.Add("taxId");
            dtbl.Columns.Add("ledgerId");
            dtbl.Columns.Add("taxName");
            dtbl.Columns.Add("applicableOn");
            dtbl.Columns.Add("calculatingMode");
            dtbl.Columns.Add("rate");
            foreach (var item in Taxes)
            {
                var row = dtbl.NewRow();
                row["taxId"] = item.TaxID;
                row["ledgerId"] = item.ledgerId;
                row["taxName"] = item.taxName;
                row["applicableOn"] = item.ApplicationOn;
                row["calculatingMode"] = item.CalculatingMode;
                row["rate"] = item.Rate;
                dtbl.Rows.Add(row);
            }
            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeIdApplicaleForProduct(decimal decVoucherTypeId)
        {
            DataTable dtbl = new DataTable();

            IMEEntities IME = new IMEEntities();

            var adaptor = (from TX in IME.Taxes
                           from VTX in IME.VoucherTypeTaxes
                           where (TX.TaxID == VTX.taxId) && (VTX.voucherTypeId == decVoucherTypeId) && (TX.ApplicationOn == "Product")
                           && (TX.isActive == true)
                           select new
                           {
                               TX.TaxID,
                               TX.taxName
                           }).ToList();

            dtbl.Columns.Add("TaxID");
            dtbl.Columns.Add("taxName");
            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["TaxID"] = item.TaxID;
                row["taxName"] = item.taxName;
                dtbl.Rows.Add(row);
            }

            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeIdForPurchaseInvoice(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.TaxViewAllByVoucherTypeIdForPurchaseInvoice(decVoucherTypeId);

                dtbl.Columns.Add("purchaseBillTaxId");
                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("calculatingMode");
                dtbl.Columns.Add("rate");
                dtbl.Columns.Add("taxAmount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["purchaseBillTaxId"] = item.purchaseBillTaxId;
                    row["taxId"] = item.taxId;
                    row["ledgerId"] = item.ledgerId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["calculatingMode"] = item.calculatingMode;
                    row["rate"] = item.rate;
                    row["taxAmount"] = item.taxAmount;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Tax TaxView(int taxId)
        {
            Tax taxinfo = new Tax();
            try
            {
                taxinfo = new IMEEntities().Taxes.Where(x => x.TaxID == taxId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return taxinfo;
        }

        public DataTable TotalBillTaxCalculationBtapplicableOn()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.Taxes.Where(x => x.ApplicationOn == "Bill" && x.CalculatingMode == "Bill Amount").ToList();

                dtbl.Columns.Add("TaxID");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("Rate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["TaxID"] = item.TaxID;
                    row["taxName"] = item.taxName;
                    row["Rate"] = item.Rate;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable TaxViewAllForProduct()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (IME.TaxViewAllForProduct()).ToList();

                dtbl.Columns.Add("TaxID");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("Rate");
                dtbl.Columns.Add("CalculatingMode");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("isActive");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["TaxID"] = item.taxId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["Rate"] = item.rate;
                    row["CalculatingMode"] = item.calculatingMode;
                    row["narration"] = item.narration;
                    row["isActive"] = item.isActive;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable TaxViewAll()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from t in IME.Taxes
                               select new
                               {
                                   t.TaxID,
                                   t.taxName,
                                   t.ApplicationOn,
                                   t.Rate,
                                   t.CalculatingMode,
                                   t.narration,
                                   t.isActive
                               }).ToList();

                dtbl.Columns.Add("TaxID");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("Rate");
                dtbl.Columns.Add("CalculatingMode");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("isActive");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["TaxID"] = item.TaxID;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["Rate"] = item.Rate;
                    row["CalculatingMode"] = item.CalculatingMode;
                    row["narration"] = item.narration;
                    row["isActive"] = item.isActive;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeId1(decimal decVoucherTypeId, string strTaxApplicable)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from tx in IME.Taxes
                               from vtx in IME.VoucherTypeTaxes.Where(x => x.taxId == tx.TaxID)
                               from al in IME.AccountLedgers.Where(x => x.ledgerName == tx.taxName)
                               where vtx.voucherTypeId == decVoucherTypeId && tx.isActive == true
                               select new
                               {
                                   tx.TaxID,
                                   al.ledgerId,
                                   tx.taxName,
                                   tx.ApplicationOn,
                                   tx.CalculatingMode,
                                   tx.Rate
                               }).ToList();


                dtbl.Columns.Add("TaxID");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("CalculatingMode");
                dtbl.Columns.Add("Rate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["TaxID"] = item.TaxID;
                    row["ledgerId"] = item.ledgerId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["CalculatingMode"] = item.CalculatingMode;
                    row["Rate"] = item.Rate;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable TaxViewAllByVoucherTypeIdWithCess(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {

                var adaptor = (from tx in IME.Taxes
                               from vtx in IME.VoucherTypeTaxes.Where(x => x.taxId == tx.TaxID)
                               from al in IME.AccountLedgers.Where(x => x.ledgerName == tx.taxName)
                               where vtx.voucherTypeId == decVoucherTypeId && tx.isActive == true
                               select new
                               {
                                   tx.TaxID,
                                   al.ledgerId,
                                   tx.taxName,
                                   tx.ApplicationOn,
                                   tx.CalculatingMode,
                                   tx.Rate
                               }).ToList();


                dtbl.Columns.Add("TaxID");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("CalculatingMode");
                dtbl.Columns.Add("Rate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["TaxID"] = item.TaxID;
                    row["ledgerId"] = item.ledgerId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["CalculatingMode"] = item.CalculatingMode;
                    row["Rate"] = item.Rate;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable TaxIdCorrespondingToCessTaxId(decimal decTaxId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (IME.TaxDetails.Where(x => x.taxID == decTaxId)).ToList();


                dtbl.Columns.Add("taxDetailsID");
                dtbl.Columns.Add("taxID");
                dtbl.Columns.Add("SelectedtaxID");
                dtbl.Columns.Add("taxDate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["taxDetailsID"] = item.taxDetailsID;
                    row["taxID"] = item.taxID;
                    row["SelectedtaxID"] = item.SelectedtaxID;
                    row["taxDate"] = item.taxDate;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        /// <summary>
        /// Function to view Tax for Selection
        /// </summary>
        /// <returns></returns>
        public DataTable TaxViewAllForTaxSelection()
        {
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = new IMEEntities().TaxViewAllForTaxSelection().ToList();

                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxName");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["taxId"] = item.taxId;
                    row["taxName"] = item.taxName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Tax TaxViewByProductId(string strProductCode)
        {
            Tax taxInfo = new Tax();
            //TODO Ürün bazında vergilendirme
            //SqlDataReader sdrreader = null;
            //try
            //{
            //    if (sqlcon.State == ConnectionState.Closed)
            //    {
            //        sqlcon.Open();
            //    }
            //    SqlCommand sccmd = new SqlCommand("TaxViewByProductId", sqlcon);
            //    sccmd.CommandType = CommandType.StoredProcedure;
            //    SqlParameter sprmparam = new SqlParameter();
            //    sprmparam = sccmd.Parameters.Add("@productId", SqlDbType.VarChar);
            //    sprmparam.Value = strProductCode;
            //    sdrreader = sccmd.ExecuteReader();
            //    while (sdrreader.Read())
            //    {
            //        taxInfo.TaxId = Convert.ToDecimal(sdrreader["taxId"].ToString());
            //        taxInfo.TaxName = sdrreader["taxName"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    sdrreader.Close();
            //    sqlcon.Close();
            //}
            return taxInfo;

        }

        public DataTable TaxViewAllForVoucherType()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                dtbl.Columns.Add("SlNo", typeof(decimal));
                dtbl.Columns["SlNo"].AutoIncrement = true;
                dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
                dtbl.Columns["SlNo"].AutoIncrementStep = 1;

                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("applicableOn");

                var adaptor = db.TaxViewAllForVoucherType();

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["taxId"] = item.taxId;
                    row["taxName"] = item.taxName;
                    row["applicableOn"] = item.applicableOn;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        /// <summary>
        /// Function for tax search based on parameter
        /// </summary>
        /// <param name="strTaxName"></param>
        /// <param name="strApplicableOn"></param>
        /// <param name="strCalculatingMode"></param>
        /// <param name="strActive"></param>
        /// <returns></returns>
        public DataTable TaxSearch(String strTaxName, String strApplicableOn, String c, string strActive)
        {
            DataTable dtblTaxSearch = new DataTable();
            dtblTaxSearch.Columns.Add("Sl No", typeof(decimal));
            dtblTaxSearch.Columns["Sl No"].AutoIncrement = true;
            dtblTaxSearch.Columns["Sl No"].AutoIncrementSeed = 1;
            dtblTaxSearch.Columns["Sl No"].AutoIncrementStep = 1;

            dtblTaxSearch.Columns.Add("taxId");
            dtblTaxSearch.Columns.Add("taxName");
            dtblTaxSearch.Columns.Add("applicableOn");
            dtblTaxSearch.Columns.Add("calculatingMode");
            dtblTaxSearch.Columns.Add("isActive");

            try
            {
                var adaptor = new IMEEntities().TaxSearch(strTaxName, strApplicableOn, c, strActive).ToList();

                foreach (var item in adaptor)
                {
                    DataRow row = dtblTaxSearch.NewRow();

                    row["taxId"] = item.taxId;
                    row["taxName"] = item.taxName;
                    row["applicableOn"] = item.applicableOn;
                    row["calculatingMode"] = item.calculatingMode;
                    row["isActive"] = item.isActive;

                    dtblTaxSearch.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblTaxSearch;
        }

        /// <summary>
        /// Function to view TaxId For Tax Selection Update based on parameter
        /// </summary>
        /// <param name="decTaxId"></param>
        /// <returns></returns>
        public DataTable TaxIdForTaxSelectionUpdate(decimal decTaxId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.TaxIdForTaxSelectionUpdate(decTaxId).ToList();

                dtbl.Columns.Add("selectedtaxId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["selectedtaxId"] = item.Value;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        //public DataTable TaxViewAllByVoucherTypeIdApplicaleForProduct(decimal decVoucherTypeId)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    DataTable dtbl = new DataTable();
        //    try
        //    {
        //        var adaptor = IME.TaxViewAllByVoucherTypeIdApplicaleForProduct(decVoucherTypeId);

        //        dtbl.Columns.Add("taxId");
        //        dtbl.Columns.Add("taxName");

        //        foreach (var item in adaptor)
        //        {
        //            var row = dtbl.NewRow();

        //            row["taxId"] = item.taxId;
        //            row["taxName"] = item.taxName;


        //            dtbl.Rows.Add(row);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return dtbl;
        //}

        //public DataTable TaxViewAllByVoucherTypeId(decimal decVoucherTypeId)
        //{
        //    IMEEntities IME = new IMEEntities();
        //    DataTable dtbl = new DataTable();
        //    try
        //    {
        //        var adaptor = IME.TaxViewAllByVoucherTypeId(decVoucherTypeId);

        //        dtbl.Columns.Add("taxId");
        //        dtbl.Columns.Add("ledgerId");
        //        dtbl.Columns.Add("taxName");
        //        dtbl.Columns.Add("ApplicationOn");
        //        dtbl.Columns.Add("calculatingMode");
        //        dtbl.Columns.Add("rate");

        //        foreach (var item in adaptor)
        //        {
        //            var row = dtbl.NewRow();

        //            row["taxId"] = item.taxId;
        //            row["ledgerId"] = item.ledgerId;
        //            row["taxName"] = item.taxName;
        //            row["ApplicationOn"] = item.ApplicationOn;
        //            row["calculatingMode"] = item.calculatingMode;
        //            row["rate"] = item.rate;


        //            dtbl.Rows.Add(row);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    return dtbl;
        //}
    }
}
