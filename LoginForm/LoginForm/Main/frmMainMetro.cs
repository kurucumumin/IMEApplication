#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using LoginForm.DataSet;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LoginForm.Main
{
    public partial class frmMainMetro : Syncfusion.Windows.Forms.MetroForm
    {
        List<Panel> panels = new List<Panel>();
        Panel ActivePanel;
        int PH;
        string animMode = "Extend";
        public frmMainMetro()
        {
            InitializeComponent();
            ActivePanel = pnlButton1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(pnlButton1.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                foreach (Control item in pnlButton1.Controls)
                {
                    h += item.Height + 6;
                }
                PH = h;
                ActivePanel = pnlButton1;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (pnlButton2.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                foreach (Control item in pnlButton2.Controls)
                {
                    h += item.Height + 6;
                }
                PH = h;
                ActivePanel = pnlButton2;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (pnlButton3.Height == 0)
            {
                ActivePanel.Height = 0;

                int h = 0;
                foreach (Control item in pnlButton3.Controls)
                {
                    h += item.Height + 6;
                }
                PH = h;
                ActivePanel = pnlButton3;
                animMode = "Extend";
                timer2.Start();
            }
            else
            {
                PH = 0;
                animMode = "Shrink";
                timer2.Start();
            }
        }

        private void frmMainMetro_Load(object sender, EventArgs e)
        {
            IMEEntities db = new IMEEntities();

            Worker currentUser = Utils.getCurrentUser();
            
            lblName.Text = currentUser.NameLastName?.ToString();
            lblEmail.Text = currentUser.Email?.ToString();
            lblPhone.Text = currentUser.Phone?.ToString();

            ExchangeRate gbp = db.Currencies.Where(x => x.currencyName == "Pound").
                FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();

            lblGBP.Text = ((decimal)gbp.rate).ToString("N4");

            ExchangeRate usd = db.Currencies.Where(x => x.currencyName == "Dollar").
                FirstOrDefault().ExchangeRates.OrderByDescending(x => x.date).FirstOrDefault();

            lblUSD.Text = ((decimal)usd.rate).ToString("N4");
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (animMode == "Extend")
            {
                ActivePanel.Height = ActivePanel.Height + 10;
                if (ActivePanel.Height >= PH)
                {
                    timer2.Stop();
                }
            }
            else
            {
                ActivePanel.Height = ActivePanel.Height - 10;
                if (ActivePanel.Height <= PH)
                {
                    timer2.Stop();
                }
            }
        }
    }
}
