using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class SuffixPrefixSP
    {
        public SuffixPrefix GetSuffixPrefixDetails(decimal vouchertypeId, DateTime date)
        {
            IMEEntities db = new IMEEntities();
            SuffixPrefix suffixprefixinfo = new SuffixPrefix();
            try
            {
                suffixprefixinfo = db.SuffixPrefixes.Where(x => x.voucherTypeId == vouchertypeId && (x.fromDate < date && x.toDate > date)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return suffixprefixinfo;
        }
    }
}
