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
    class VoucherTypeSP
    {
        public bool CheckMethodOfVoucherNumbering(decimal voucherTypeId)
        {
            VoucherType infoVoucherType = new VoucherType();
            bool isAutomatic = false;
            try
            {
                infoVoucherType.methodOfVoucherNumbering = new IMEEntities().VoucherTypes.Where(x => x.voucherTypeId == voucherTypeId).FirstOrDefault().methodOfVoucherNumbering;
                if (infoVoucherType.methodOfVoucherNumbering == "Automatic")
                {
                    isAutomatic = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isAutomatic;
        }

        public void voucherTypeComboFill(ComboBox cmbVoucherType, bool isAll)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
                var adaptor = (from vt in IME.VoucherTypes.Where(x => x.voucherTypeName != "Opening Balance" && x.voucherTypeName != "Opening Balance")
                               select new { vt.voucherTypeName,vt.voucherTypeId }).ToList();

                dtbl.Columns.Add("voucherTypeName");
            dtbl.Columns.Add("voucherTypeId");
            foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();
                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    dtbl.Rows.Add(row);
                }
                cmbVoucherType.DataSource = dtbl;
                cmbVoucherType.ValueMember = "voucherTypeId";
                cmbVoucherType.DisplayMember = "voucherTypeName";
                cmbVoucherType.SelectedIndex = 0;
            }

        public string TypeOfVoucherView(string strvoucherTypeName)
        {
            IMEEntities IME = new IMEEntities();
            string StrTypeOfVoucher = string.Empty;
            try
            {
                StrTypeOfVoucher= IME.VoucherTypes.Where(x => x.voucherTypeName == strvoucherTypeName).FirstOrDefault().typeOfVoucher;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return StrTypeOfVoucher;
        }

        public DataTable VoucherSearchFill(DateTime fromDate, DateTime toDate, decimal decVoucherTypeId, string strVoucherNo, decimal decLedgerId, decimal decEmployeeId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Sl No");
            dtbl.Columns["Sl No"].AutoIncrement = true;
            dtbl.Columns["Sl No"].AutoIncrementSeed = 1;
            dtbl.Columns["Sl No"].AutoIncrementStep = 1;
            
            //TODO 1 : Algoritma / İşlem eksik, tamamlanacak
            return dtbl;
        }

        public DataTable DeclarationAndHeadingGetByVoucherTypeId(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = (from v in db.VoucherTypes
                               where v.voucherTypeId==decVoucherTypeId
                               select new
                               {
                                   v.declaration,
                                   v.heading1,
                                   v.heading2,
                                   v.heading3,
                                   v.heading4,
                                   v.masterId
                               }).ToList();

                dtbl.Columns.Add("declaration");
                dtbl.Columns.Add("heading1");
                dtbl.Columns.Add("heading2");
                dtbl.Columns.Add("heading3");
                dtbl.Columns.Add("heading4");
                dtbl.Columns.Add("masterId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["declaration"] = item.declaration;
                    row["heading1"] = item.heading1;
                    row["heading2"] = item.heading2;
                    row["heading3"] = item.heading3;
                    row["heading4"] = item.heading4;
                    row["masterId"] = item.masterId;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public int FormIdGetForPrinterSettings(int inMasterId)
        {
            IMEEntities IME = new IMEEntities();
            int frmId = 0;
            try
            {
                frmId = (from m in IME.Masters
                         where m.masterId == inMasterId
                         select new { m.formName }).Count();
            }
            catch (Exception)
            {
                throw;
            }
            return frmId;
        }

        public DataTable VoucherTypeSelectionComboFill(string strVoucherType)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("SlNo", typeof(decimal));
            dtbl.Columns["SlNo"].AutoIncrement = true;
            dtbl.Columns["SlNo"].AutoIncrementSeed = 1;
            dtbl.Columns["SlNo"].AutoIncrementStep = 1;

            try
            {
                var adaptor = (from x in db.VoucherTypes
                               where x.typeOfVoucher == strVoucherType && x.isActive == true
                               select new { x.voucherTypeId, x.voucherTypeName }).ToList();


                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public DataTable VoucherTypeViewAll()
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = (from cm in db.VoucherTypes
                               select new
                               {
                                   cm.voucherTypeId,
                                   cm.voucherTypeName,
                                   cm.typeOfVoucher,
                                   cm.methodOfVoucherNumbering,
                                   cm.isTaxApplicable,
                                   cm.narration,
                                   cm.isActive,
                                   cm.masterId,
                                   cm.declaration,
                                   cm.heading1,
                                   cm.heading2,
                                   cm.heading3,
                                   cm.heading4
                               }).ToList();

                dtbl.Columns.Add("voucherTypeId");
                dtbl.Columns.Add("voucherTypeName");
                dtbl.Columns.Add("typeOfVoucher");
                dtbl.Columns.Add("methodOfVoucherNumbering");
                dtbl.Columns.Add("isTaxApplicable");
                dtbl.Columns.Add("narration");
                dtbl.Columns.Add("isActive");
                dtbl.Columns.Add("masterId");
                dtbl.Columns.Add("declaration");
                dtbl.Columns.Add("heading1");
                dtbl.Columns.Add("heading2");
                dtbl.Columns.Add("heading3");
                dtbl.Columns.Add("heading4");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["typeOfVoucher"] = item.typeOfVoucher;
                    row["methodOfVoucherNumbering"] = item.methodOfVoucherNumbering;
                    row["isTaxApplicable"] = item.isTaxApplicable;
                    row["narration"] = item.narration;
                    row["isActive"] = item.isActive;
                    row["masterId"] = item.masterId;
                    row["declaration"] = item.declaration;
                    row["heading1"] = item.heading1;
                    row["heading2"] = item.heading2;
                    row["heading3"] = item.heading3;
                    row["heading4"] = item.heading4;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public VoucherType VoucherTypeView(decimal voucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            VoucherType vouchertypeinfo = new VoucherType();
            try
            {
                var adaptor = db.VoucherTypeView(voucherTypeId).FirstOrDefault();

                vouchertypeinfo.voucherTypeId = adaptor.voucherTypeId;
                vouchertypeinfo.voucherTypeName = adaptor.voucherTypeName;
                vouchertypeinfo.typeOfVoucher = adaptor.typeOfVoucher;
                vouchertypeinfo.methodOfVoucherNumbering = adaptor.methodOfVoucherNumbering;
                vouchertypeinfo.isTaxApplicable = adaptor.isTaxApplicable;
                vouchertypeinfo.narration = adaptor.narration;
                vouchertypeinfo.isActive = Convert.ToBoolean(adaptor.isActive);
                vouchertypeinfo.masterId = adaptor.masterId;
                vouchertypeinfo.declaration = adaptor.declaration;
                vouchertypeinfo.heading1 = adaptor.heading1;
                vouchertypeinfo.heading2 = adaptor.heading2;
                vouchertypeinfo.heading3 = adaptor.heading3;
                vouchertypeinfo.heading4 = adaptor.heading4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return vouchertypeinfo;
        }

        public DataTable VoucherTypeSearch(string strVoucherName, string strTypeOfvoucher)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtblSearch = new DataTable();
            try
            {
                dtblSearch.Columns.Add("SlNo", typeof(decimal));
                dtblSearch.Columns["SlNo"].AutoIncrement = true;
                dtblSearch.Columns["SlNo"].AutoIncrementSeed = 1;
                dtblSearch.Columns["SlNo"].AutoIncrementStep = 1;

                var adaptor = db.VoucherTypeSearch(strVoucherName,strTypeOfvoucher).ToList();

                dtblSearch.Columns.Add("voucherTypeId");
                dtblSearch.Columns.Add("voucherTypeName");
                dtblSearch.Columns.Add("typeOfVoucher");

                foreach (var item in adaptor)
                {
                    DataRow row = dtblSearch.NewRow();

                    row["voucherTypeId"] = item.voucherTypeId;
                    row["voucherTypeName"] = item.voucherTypeName;
                    row["typeOfVoucher"] = item.typeOfVoucher;

                    dtblSearch.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtblSearch;
        }
        /// <summary>
        /// Function to get tax id for tax selection based on parameter
        /// </summary>
        /// <param name="decVoucherTypeId"></param>
        /// <returns></returns>
        public DataTable GetTaxIdForTaxSelection(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = db.GetTaxIdForTaxSelection(decVoucherTypeId).ToList();

                dtbl.Columns.Add("taxId");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["taxId"] = item.Value;

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
        /// Function to  Check For Default VoucherType based on parameter
        /// </summary>
        /// <param name="decVoucherTypeId"></param>
        /// <returns></returns>
        public bool CheckForDefaultVoucherType(decimal decVoucherTypeId)
        {
            IMEEntities db = new IMEEntities();
            bool isDefault = true;
            try
            {
                object obj = db.CheckForDefaultVoucherType(decVoucherTypeId);
                if (obj != null)
                {
                    if (obj.ToString() == "1")
                    {
                        isDefault = true;
                    }
                    else
                    {
                        isDefault = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return isDefault;
        }
    }
}
