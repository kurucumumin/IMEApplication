using System;

namespace LoginForm.clsClasses
{
    public class clsLogClass
    {
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string <DONE_OPERATION>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <RECORD_ID>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <TABLE_ID>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private DateTime <TIME>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string <USER_NAME>k__BackingField;

        public string DONE_OPERATION { get; set; }

        public int RECORD_ID { get; set; }

        public int TABLE_ID { get; set; }

        public string TABLE_NAME
        {
            get
            {
                switch (this.TABLE_ID)
                {
                    case 0x3e8:
                        return "MAIN PAGE";

                    case 0x3e9:
                        return "LOGIN PAGE";

                    case 0x3ea:
                        return "SUPERDISK";

                    case 0x3eb:
                        return "LICANCED ARTICLES";

                    case 0x3ec:
                        return "DISCONTINUED LIST";

                    case 0x3ed:
                        return "HAZARDOUS ARTICLES FILE STRUCTURE";

                    case 0x3ee:
                        return "STOCK LEVEL REPORT";

                    case 0x3ef:
                        return "SLIDING PRICE LIST";

                    case 0x3f0:
                        return "ORDER ACKNOWLEDGEMENET";

                    case 0x3f1:
                        return "ORDER CHANGE";

                    case 0x3f2:
                        return "ASN KAYIT";

                    case 0x3f3:
                        return "QUOTATION";

                    case 0x3f4:
                        return "SHIPPING DETAILS";

                    case 0x3f5:
                        return "PURCHASE ORDER";

                    case 0x3f6:
                        return "CUSTOMERS";

                    case 0x3f7:
                        return "ITEMS";

                    case 0x3f8:
                        return "STOK SİPARİŞLERİ";

                    case 0x3f9:
                        return "BACK ORDERS";

                    case 0x3fa:
                        return "INVOICES";

                    case 0x3fb:
                        return "A\x00c7IK SİPARİŞLER";

                    case 0x3fc:
                        return "FATURALANACAKLAR";

                    case 0x3fd:
                        return "KARGO TAKİP";
                }
                return "Sayfa Kayıtlı Değil";
            }
        }

        public DateTime TIME { get; set; }

        public string USER_NAME { get; set; }
    }
}

