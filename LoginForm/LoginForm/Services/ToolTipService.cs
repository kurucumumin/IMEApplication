using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class ToolTipService
    {
        public static void message_toolTip(string tooltitle, Control objeto, string message)
        {
            ToolTip tool = new ToolTip();
            tool.ToolTipTitle = tooltitle;
            tool.UseFading = true;
            tool.UseAnimation = true;
            tool.IsBalloon = true;
            tool.ShowAlways = true;
            tool.AutoPopDelay = 5000;
            tool.InitialDelay = 1000;
            tool.ReshowDelay = 500;
            tool.IsBalloon = true;
            tool.SetToolTip(objeto,message);
        }
    }
}
