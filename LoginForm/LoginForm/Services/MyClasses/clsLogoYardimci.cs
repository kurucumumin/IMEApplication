using LoginForm.Services;
using System.Data;

namespace LoginForm.clsClasses
{

    public class clsLogoYardimci
    {
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <DonemID>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <FirmaID>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <OrderID>k__BackingField;

        public static clsLogoYardimci kayitLogoBilgisi(int TeklifNo)
        {
            clsLogoYardimci yardimci = new clsLogoYardimci();
            foreach (DataRow row in MyConnect.Ornekle.ExecuteReader(Utils.ConnectionStringLogo, string.Format("SELECT FRMNO, DNMNO FROM RBS_OFFERS WHERE ID = {0}", TeklifNo), CommandType.Text, 60, new KomutArgumanlari_[0]).Rows)
            {
                yardimci.OrderID = TeklifNo;
                yardimci.FirmaID = row[0]._ToIntegerR();
                yardimci.DonemID = row[1]._ToIntegerR();
            }
            return yardimci;
        }

        public string DnmNo
        {
            get
            {
                return this.DonemID.ToString().PadLeft(2, '0');
            }
        }

        public int DonemID { get; set; }

        public int FirmaID { get; set; }

        public string FrmNo
        {
            get
            {
                return this.FirmaID.ToString().PadLeft(3, '0');
            }
        }

        public int OrderID { get; set; }
    }
}

