#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Forms;

namespace LoginForm.Main
{
    public partial class frmMainMetro : Syncfusion.Windows.Forms.MetroForm
    {
        public frmMainMetro()
        {
            InitializeComponent();
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            int h = 0;
            foreach (Control item in pnlButton1.Controls)
            {
                h += item.Height + 6;
            }
            pnlButton1.Height = h;
        }
    }
}
