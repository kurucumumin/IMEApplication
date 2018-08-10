using LoginForm.ManagementModule;
using LoginForm.User;
using System;
using System.Windows.Forms;

namespace LoginForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUserCustomerUpdate());
        }
    }
}
