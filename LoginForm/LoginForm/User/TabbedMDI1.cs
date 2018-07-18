#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginForm.User
{
    public partial class TabbedMDI1 : Form
    {
        public TabbedMDI1()
        {
            InitializeComponent();
            Form frm = new Form();
            frm.Text = "Form1";
            frm.MdiParent = this;
            frm.Show();
            Form frm1 = new Form();
            frm1.MdiParent = this;
            frm1.Text = "Form2";
            frm1.Show();
        }

        private void TabbedMDI1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iMEDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.iMEDataSet.Customer);

        }
    }
}
