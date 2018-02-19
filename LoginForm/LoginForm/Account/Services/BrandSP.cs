using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using LoginForm.DataSet;

namespace LoginForm.Account.Services
{
    class BrandSP
    {
        /// <summary>
        /// Function to get particular values from brand table based on the parameter
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public Brand BrandView(decimal brandId)
        {
            Brand brand = new Brand();
            try
            {
                var b = new IMEEntities().BrandView(brandId).FirstOrDefault();

                brand.brandId = b.brandId;
                brand.brandName = b.brandName;
                brand.narration = b.narration;
                brand.manufacturer = b.manufacturer;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return brand;
        }
    }
}
