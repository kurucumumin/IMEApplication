﻿using LoginForm.DataSet;
using System;
using System.Windows;

namespace LoginForm.Account.Services
{
    static class PartyBalanceSP
    {
        static public void PartyBalanceAdd(PartyBalance partybalanceinfo)
        {
            IMEEntities db = new IMEEntities();
            try
            {
                db.PartyBalances.Add(partybalanceinfo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
