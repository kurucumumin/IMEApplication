using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Account.Services
{
    class CompanyPathSP
    {
        /// <summary>
        /// Function to insert values to CompanyPath Table
        /// </summary>
        /// <param name="companyPath"></param>
        public void CompanyPathAdd(CompanyPath companyPath)
        {
            try
            {
                new IMEEntities().CompanyPathAdd(companyPath.companyName, companyPath.companyPath1, companyPath.isDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Function to Update values in CompanyPath Table
        /// </summary>
        /// <param name="companypathinfo"></param>
        public void CompanyPathEdit(CompanyPath companypathinfo)
        {
            try
            {
                new IMEEntities().CompanyPathEdit(
                    companypathinfo.companyId,
                    companypathinfo.companyName,
                    companypathinfo.companyPath1,
                    companypathinfo.isDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Function to get particular values from CompanyPath Table based on the parameter
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public CompanyPath CompanyPathView(decimal companyId)
        {
            IMEEntities db = new IMEEntities();
            CompanyPath companypathinfo = new CompanyPath();
            try
            {
                var cp = db.CompanyPathView(companyId).FirstOrDefault();
                companypathinfo.companyId = cp.companyId;
                companypathinfo.companyName = cp.companyName;
                companypathinfo.companyPath1 = cp.companyPath;
                companypathinfo.isDefault = cp.isDefault;

                    //= new IMEEntities().CompanyPaths.Where(x => x.companyId == companyId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return companypathinfo;
        }
    }
}
