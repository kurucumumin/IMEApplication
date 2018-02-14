using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
namespace LoginForm.Account.Services
{
    class ServiceDetailsSP
    {

        public decimal ServiceDetailsAddReturnWithIdentity(ServiceDetail ac)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = 0;
            try
            {
                object obj = IME.ServiceDetailsAddReturnWithIdentity(
                    ac.serviceMasterId,
                    ac.serviceId,
                    ac.measure,
                    ac.amount);

                if (obj != null)
                {
                    decIdentity = decimal.Parse(obj.ToString());
                }
                else
                {
                    decIdentity = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return decIdentity;
        }

        public void ServiceDetailsDelete(decimal ServiceDetailsId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.ServiceDetailsDelete(ServiceDetailsId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ServiceDetailsEdit(ServiceDetail ac)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.ServiceDetailsEdit(
                    ac.serviceDetailsId,
                    ac.serviceMasterId,
                    ac.serviceId,
                    ac.measure,
                    ac.amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable ServiceDetailsViewWithMasterId(decimal decServiceMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("Slno", typeof(decimal));
            dtbl.Columns["Slno"].AutoIncrement = true;
            dtbl.Columns["Slno"].AutoIncrementSeed = 1;
            dtbl.Columns["Slno"].AutoIncrementStep = 1;
            
            try
            {
                var adaptor= IME.ServiceDetailsViewWithMasterId(decServiceMasterId);

                dtbl.Columns.Add("serviceDetailsId");
                dtbl.Columns.Add("serviceMasterId");
                dtbl.Columns.Add("serviceId");
                dtbl.Columns.Add("measure");
                dtbl.Columns.Add("amount");

                foreach (var item in adaptor)
                {
                    DataRow row = dtbl.NewRow();

                    row["serviceDetailsId"] = item.serviceDetailsId;
                    row["serviceMasterId"] = item.serviceMasterId;
                    row["serviceId"] = item.serviceId;
                    row["measure"] = item.measure;
                    row["amount"] = item.amount;


                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dtbl;
        }
    }
}
