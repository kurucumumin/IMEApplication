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

        public Tax TaxView(decimal taxId)
        {
            IMEEntities IME = new IMEEntities();
            Tax taxinfo = new Tax();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from t in IME.Taxes
                           where t.TaxID == taxId
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

                taxinfo= IME.Taxes.Where(x => x.TaxID == taxId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return taxinfo;
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
                var adaptor = (IME.TaxDetails.Where(x=> x.taxID==decTaxId)).ToList();


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

              

          public TaxInfo TaxViewByProductId(string strProductCode)
          {
              TaxInfo taxInfo = new TaxInfo();
              //TODO TaxViewByProductId
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

        public DataTable TaxViewAllByVoucherTypeIdApplicaleForProduct(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.TaxViewAllByVoucherTypeIdApplicaleForProduct(decVoucherTypeId);

                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("taxName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

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

        public DataTable TaxViewAllByVoucherTypeId(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.TaxViewAllByVoucherTypeId(decVoucherTypeId);

                dtbl.Columns.Add("taxId");
                dtbl.Columns.Add("ledgerId");
                dtbl.Columns.Add("taxName");
                dtbl.Columns.Add("ApplicationOn");
                dtbl.Columns.Add("calculatingMode");
                dtbl.Columns.Add("rate");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["taxId"] = item.taxId;
                    row["ledgerId"] = item.ledgerId;
                    row["taxName"] = item.taxName;
                    row["ApplicationOn"] = item.ApplicationOn;
                    row["calculatingMode"] = item.calculatingMode;
                    row["rate"] = item.rate;


                    dtbl.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        //public TaxInfo TaxView(decimal taxId)
        //{
        //    TaxInfo taxinfo = new TaxInfo();
        //    IMEEntities IME = new IMEEntities();
        //    var tax = IME.Taxes.Where(a => a.TaxID == taxId).FirstOrDefault();
        //    taxinfo.TaxId = tax.TaxID;
        //    taxinfo.TaxName = tax.taxName;
        //    taxinfo.ApplicableOn = tax.ApplicationOn;
        //    taxinfo.Rate = (decimal)tax.Rate;
        //    taxinfo.CalculatingMode = tax.CalculatingMode;
        //    taxinfo.Narration = tax.narration;
        //    taxinfo.IsActive = (bool)tax.isActive;
        //    return taxinfo;
        //}


    }
}
