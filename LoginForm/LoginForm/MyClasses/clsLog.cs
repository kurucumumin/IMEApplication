using System.Data;
using LoginForm.MyClasses;
using LoginForm.Services;
using ImeLogoLibrary;

namespace LoginForm.clsClasses
{

    public static class clsLog
    {
        public static void LogKayit(clsLogClass cls)
        {
            KomutArgumanlari_[] arguman = new KomutArgumanlari_[5];
            KomutArgumanlari_ i_1 = new KomutArgumanlari_ {
                Parametre = cls.TABLE_ID,
                ParametreAdi = "@TABLE_ID"
            };
            arguman[0] = i_1;
            KomutArgumanlari_ i_2 = new KomutArgumanlari_ {
                Parametre = cls.RECORD_ID,
                ParametreAdi = "@RECORD_ID"
            };
            arguman[1] = i_2;
            KomutArgumanlari_ i_3 = new KomutArgumanlari_ {
                Parametre = cls.TIME,
                ParametreAdi = "@TIME"
            };
            arguman[2] = i_3;
            KomutArgumanlari_ i_4 = new KomutArgumanlari_ {
                Parametre = Utils.getCurrentUser().WorkerID,
                ParametreAdi = "@USER_ID"
            };
            arguman[3] = i_4;
            KomutArgumanlari_ i_5 = new KomutArgumanlari_ {
                Parametre = cls.DONE_OPERATION,
                ParametreAdi = "@DONE_OPERATION"
            };
            arguman[4] = i_5;
            MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringIME, "INSERT INTO dbo.LogRecords (TABLE_ID, RECORD_ID, TIME, USER_ID, DONE_OPERATION) VALUES (@TABLE_ID, @RECORD_ID, @TIME, @USER_ID, @DONE_OPERATION)", CommandType.Text, 60, arguman);
        }
    }
}

