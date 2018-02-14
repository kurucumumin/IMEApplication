using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;
namespace LoginForm
{
    class ServiceMasterSP
    {
        public DataTable SalesInvoiceSalesAccountModeComboFill()
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            var AccountGroups = IME.AccountGroups.Where(a => a.groupUnder == IME.AccountGroups.Where(b => b.accountGroupName == "Sales Account").FirstOrDefault().accountGroupId).ToList();
            var adaptor = (from a in IME.AccountLedgers
                           from b in AccountGroups
                           where (a.accountGroupID== b.accountGroupId)

                           select new
                           {
                               ledgerName = a.ledgerName,
                               ledgerId = a.ledgerId
                               
                           }).ToList();

            dtbl.Columns.Add("ledgerName");
            dtbl.Columns.Add("ledgerId");

            foreach (var item in adaptor)
            {
                var row = dtbl.NewRow();
                row["ledgerName"] = item.ledgerName;
                row["ledgerId"] = item.ledgerId;
                dtbl.Rows.Add(row);
            }

            return dtbl;
        }

        public int ServiceMasterGetMax(decimal decVoucherTypeId)
        {
            IMEEntities IME = new IMEEntities();
            int max = 0;
            try
            {
                max = Convert.ToInt32(IME.ServiceVoucherMasterMax(decVoucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return max;
        }

        public bool ServiceVoucherCheckExistence(string strInvoiceNo, decimal voucherTypeId, decimal masterId)
        {
            IMEEntities IME = new IMEEntities();
            bool trueOrfalse = false;
            try
            {
                trueOrfalse = Convert.ToBoolean(IME.ServiceVoucherCheckExistence(strInvoiceNo, masterId, voucherTypeId));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return trueOrfalse;
        }

        public decimal ServiceMasterAddReturnWithIdentity(ServiceMaster ac)
        {
            IMEEntities IME = new IMEEntities();
            decimal decIdentity = 0;
            try
            {
                object obj = IME.ServiceMasterAddReturnWithIdentity(
                    ac.voucherNo,
                    ac.invoiceNo,
                    ac.suffixPrefixId,
                    ac.date,
                    ac.ledgerId,
                    ac.totalAmount,
                    ac.narration,
                    ac.creditPeriod,
                    ac.serviceAccount,
                    ac.exchangeRateId,
                    ac.employeeId,
                    ac.customer,
                    ac.discount,
                    ac.grandTotal,
                    ac.voucherTypeId,
                    ac.financialYearId);

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

        public void ServiceVoucherDelete(decimal decPartyBalanceId, decimal decVoucherTypeId, string strVoucherNo, decimal decServiceMasterId)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                IME.ServiceVoucherDelete(decPartyBalanceId, decVoucherTypeId, strVoucherNo, decServiceMasterId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable LedgerPostingIdByServiceMaasterId(decimal decServiceMasterId)
        {
            IMEEntities IME = new IMEEntities();
            DataTable dtbl = new DataTable();
            try
            {
                var adaptor = IME.LedgerPostingIdByServiceMaasterId(decServiceMasterId);

                dtbl.Columns.Add("ledgerPostingId");

                foreach (var item in adaptor)
                {
                    var row = dtbl.NewRow();

                    row["ledgerPostingId"] = item;

                    dtbl.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dtbl;
        }

        public void ServiceMasterEdit(ServiceMaster ac)
        {
            IMEEntities IME = new IMEEntities();
            try
            {
                object obj = IME.ServiceMasterEdit(
                     ac.serviceMasterId,
                     ac.suffixPrefixId,
                     ac.date,
                     ac.ledgerId,
                     ac.totalAmount,
                     ac.narration,
                     ac.creditPeriod,
                     ac.serviceAccount,
                     ac.exchangeRateId,
                     ac.employeeId,
                     ac.customer,
                     ac.discount,
                     ac.grandTotal,
                     ac.voucherTypeId,
                     ac.financialYearId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public ServiceMaster ServiceMasterView(decimal serviceMasterId)
        {
            IMEEntities IME = new IMEEntities();
            ServiceMaster servicemasterinfo = new ServiceMaster();
            try
            {
                var a = IME.ServiceMasterView(serviceMasterId).FirstOrDefault();

                servicemasterinfo.serviceMasterId = a.serviceMasterId;
                servicemasterinfo.voucherNo = a.voucherNo;
                servicemasterinfo.invoiceNo = a.invoiceNo;
                servicemasterinfo.suffixPrefixId = a.suffixPrefixId;
                servicemasterinfo.date = Convert.ToDateTime(a.date);
                servicemasterinfo.ledgerId = a.ledgerId;
                servicemasterinfo.totalAmount = a.totalAmount;
                servicemasterinfo.narration = a.narration;
                servicemasterinfo.creditPeriod = a.creditPeriod;
                servicemasterinfo.serviceAccount = a.serviceAccount;
                servicemasterinfo.exchangeRateId = a.exchangeRateId;
                servicemasterinfo.employeeId = a.employeeId;
                servicemasterinfo.customer = a.customer;
                servicemasterinfo.discount = a.discount;
                servicemasterinfo.grandTotal = a.grandTotal;
                servicemasterinfo.voucherTypeId = a.voucherTypeId;
                servicemasterinfo.financialYearId = a.financialYearId;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return servicemasterinfo;
        }

    }
}
