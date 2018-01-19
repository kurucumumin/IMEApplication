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
        public BrandInfo BrandView(decimal brandId)
        {
            IMEEntities IME = new IMEEntities();
            BrandInfo brandinfo = new BrandInfo();

            //TO DO: Yapılacaklar !!!!!

            return brandinfo;
        }
    }
}
