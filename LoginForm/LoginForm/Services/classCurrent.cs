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
        public static string CurrentSearchID;
        public static string CurrentSearchName;
        public static string currentID;
        public static string currentname;
        public static List<Current> CurrentSearch()
        {
            IMEEntities IME = new IMEEntities();
            List<Current> c = new List<Current>();
            if (CurrentSearchName == "")
            {
                c = IME.Currents.Where(a => a.CurrentID.ToString().Contains(CurrentSearchID)).ToList().Where(a => String.IsNullOrEmpty(a.Name)).ToList();
            }
            else
            {
                c = IME.Currents.Where(a => a.CurrentID.ToString().Contains(CurrentSearchName)).ToList().Where(a => a.Name != null).Where(b => b.Name != string.Empty).ToList();
            }
            return c;
        }

    }
}
