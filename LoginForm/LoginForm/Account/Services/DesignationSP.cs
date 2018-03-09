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
    class DesignationSP
    {
        public bool DesignationEdit(Designation ac)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                var adaptor=IME.DesignationEdit(
                    ac.designationId,
                    ac.designationName,
                    ac.leaveDays,
                    ac.advanceAmount.ToString(),
                    ac.narration).ToString();

                if (adaptor=="" && adaptor==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public decimal DesignationAddWithReturnIdentity(Designation designationinfo)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = 0;
            try
            {

                object obj = IME.DesignationAddWithReturnIdentity(designationinfo.designationName,
                    designationinfo.leaveDays,
                    designationinfo.advanceAmount.ToString(),
                    designationinfo.narration).ToList();
                if (obj != null)
                {
                    decIdentity = Convert.ToDecimal(obj.ToString());
                }
                return decIdentity;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public bool DesignationCheckExistanceOfName(string strDesignation, decimal decDesignationId)
        {
            IMEEntities IME = new IMEEntities();
            decimal decCount = 0;
            try
            {
                var obj = IME.DesignationCheckExistanceOfName(strDesignation, decDesignationId).ToList();


                if (obj != null)
                {
                    decCount = decimal.Parse(obj.ToString());
                }
                if (decCount > 0)
                {
                    return true;
                }
                else
                {
                    return false; ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public DataTable DesignationViewForGridFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("slNo", typeof(int));
            dtbl.Columns["slNo"].AutoIncrement = true;
            dtbl.Columns["slNo"].AutoIncrementSeed = 1;
            dtbl.Columns["slNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.DesignationGridFill().ToList();

                dtbl.Columns.Add("designationId");
                dtbl.Columns.Add("designationName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["designationId"] = item.designationId;
                    row["designationName"] = item.designationName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public Designation DesignationView(decimal designationId)
        {
            IMEEntities IME = new IMEEntities();
            Designation designationinfo = new Designation();
            
            try
            {
                var a = IME.DesignationView(designationId).FirstOrDefault();

                designationinfo.designationId = a.designationId;
                designationinfo.designationName = a.designationName;
                designationinfo.leaveDays = a.leaveDays;
                designationinfo.advanceAmount = a.advanceAmount;
                designationinfo.narration = a.narration;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return designationinfo;
        }

        public bool DesignationDelete(decimal DesignationId)
        {
            IMEEntities IME = new IMEEntities();
            int sayi = 0;
            try
            {
                sayi = IME.DesignationDelete(DesignationId).Count();


                if (sayi > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public DataTable DesignationSearch(string strDesignation)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("slNo", typeof(int));
            dtbl.Columns["slNo"].AutoIncrement = true;
            dtbl.Columns["slNo"].AutoIncrementSeed = 1;
            dtbl.Columns["slNo"].AutoIncrementStep = 1;
            try
            {
                var adaptor = IME.DesignationSearch(strDesignation).ToList();

                dtbl.Columns.Add("designationId");
                dtbl.Columns.Add("designationName");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["designationId"] = item.designationId;
                    row["designationName"] = item.designationName;

                    dtbl.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }
    }
}
