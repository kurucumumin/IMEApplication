using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.Services;

namespace LoginForm.Account.Services
{
    class SuffixPrefixSP
    {


        public SuffixPrefix GetSuffixPrefixDetails(decimal vouchertypeId, DateTime date)
        {
            IMEEntities db = new IMEEntities();
            SuffixPrefix suffixprefixinfo = new SuffixPrefix();
            if (date==null)
            {
                date = Convert.ToDateTime(Utils.getManagement().FinancialYear.fromDate);
            }
            try
            {
                var a = db.GetSuffixPrefixDetails(vouchertypeId, date).FirstOrDefault();

                suffixprefixinfo.suffixprefixId = a.suffixprefixId;
                suffixprefixinfo.voucherTypeId = a.voucherTypeId;
                suffixprefixinfo.fromDate = a.fromDate;
                suffixprefixinfo.toDate = a.toDate;
                suffixprefixinfo.startIndex = a.startIndex;
                suffixprefixinfo.prefix = a.prefix;
                suffixprefixinfo.suffix = a.suffix;
                suffixprefixinfo.widthOfNumericalPart = a.widthOfNumericalPart;
                suffixprefixinfo.prefillWithZero = a.prefillWithZero;
                suffixprefixinfo.narration = a.narration;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return suffixprefixinfo;
        }
    }
}
