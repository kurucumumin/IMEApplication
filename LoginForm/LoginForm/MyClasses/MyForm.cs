using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
   public class MyForm : Form
    {
        protected override CreateParams CreateParams//Form titremesini önler...
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // MyForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "MyForm";
        //    this.ResumeLayout(false);

        //}
    }
}
