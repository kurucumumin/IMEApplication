using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;

namespace LoginForm.Services
{
    class classCurrent
    {
        public static List<Current> CurrentSearch(string CurrentSearchName,string CurrentSearchID)
        {   
            IMEEntities IME = new IMEEntities();
            List<Current> c = new List<Current>();
            if (CurrentSearchName == "")
            {
                c = IME.Currents.Where(a => a.CurrentID.ToString().Contains(CurrentSearchID)).ToList().Where(a => !String.IsNullOrEmpty(a.Name)).ToList();
            }
            else
            {
                c = IME.Currents.Where(a => a.Name.Contains(CurrentSearchName)).ToList();
            }
            return c;
        }

    }
}
