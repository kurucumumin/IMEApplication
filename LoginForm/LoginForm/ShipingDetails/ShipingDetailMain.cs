﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.ShipingDetails
{
    public partial class ShipingDetailMain : Form
    {
        public ShipingDetailMain()
        {
            InitializeComponent();
        }

        private void ShipingDetailMain_Load(object sender, EventArgs e)
        {
            SetMyButtonIcon();
        }

        private void SetMyButtonIcon()
        {
            //// Assign an image to the button.
        
            //// Align the image and text on the button.
            //button1.ImageAlign = ContentAlignment.MiddleRight;
            //button1.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit Programme ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void dgShipping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}