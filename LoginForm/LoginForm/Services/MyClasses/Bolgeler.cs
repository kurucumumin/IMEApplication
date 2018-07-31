using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Data;
using LoginForm.Services;

namespace LoginForm.clsClasses
{
    internal class Bolgeler
    {
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string <BolgeAdi>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private string <SehirAdi>k__BackingField;
        //[CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        //private int <SehirKodu>k__BackingField;

        public static List<string> _Bolgeler()
        {
            return new List<string> {
                "AKDENİZ B\x00d6LGESİ",
                "DOĞU ANADOLU B\x00d6LGESİ",
                "EGE B\x00d6LGESİ",
                "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ",
                "İ\x00c7 ANADOLU B\x00d6LGESİ",
                "KARADENİZ B\x00d6LGESİ",
                "MARMARA B\x00d6LGESİ"
            };
        }

        public static List<Bolgeler> BolgeGetir()
        {
            List<Bolgeler> list = new List<Bolgeler>();
            Bolgeler item = new Bolgeler
            {
                SehirKodu = 1,
                SehirAdi = "ADANA",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(item);
            Bolgeler bolgeler2 = new Bolgeler
            {
                SehirKodu = 7,
                SehirAdi = "ANTALYA",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler2);
            Bolgeler bolgeler3 = new Bolgeler
            {
                SehirKodu = 15,
                SehirAdi = "BURDUR",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler3);
            Bolgeler bolgeler4 = new Bolgeler
            {
                SehirKodu = 0x1f,
                SehirAdi = "HATAY",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler4);
            Bolgeler bolgeler5 = new Bolgeler
            {
                SehirKodu = 0x20,
                SehirAdi = "ISPARTA",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler5);
            Bolgeler bolgeler6 = new Bolgeler
            {
                SehirKodu = 0x21,
                SehirAdi = "MERSİN",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler6);
            Bolgeler bolgeler7 = new Bolgeler
            {
                SehirKodu = 0x2e,
                SehirAdi = "KAHRAMANMARAŞ",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler7);
            Bolgeler bolgeler8 = new Bolgeler
            {
                SehirKodu = 80,
                SehirAdi = "OSMANİYE",
                BolgeAdi = "AKDENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler8);
            Bolgeler bolgeler9 = new Bolgeler
            {
                SehirKodu = 4,
                SehirAdi = "AĞRI",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler9);
            Bolgeler bolgeler10 = new Bolgeler
            {
                SehirKodu = 12,
                SehirAdi = "BİNG\x00d6L",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler10);
            Bolgeler bolgeler11 = new Bolgeler
            {
                SehirKodu = 13,
                SehirAdi = "BİTLİS",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler11);
            Bolgeler bolgeler12 = new Bolgeler
            {
                SehirKodu = 0x17,
                SehirAdi = "ELAZIĞ",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler12);
            Bolgeler bolgeler13 = new Bolgeler
            {
                SehirKodu = 0x18,
                SehirAdi = "ERZİNCAN",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler13);
            Bolgeler bolgeler14 = new Bolgeler
            {
                SehirKodu = 0x19,
                SehirAdi = "ERZURUM",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler14);
            Bolgeler bolgeler15 = new Bolgeler
            {
                SehirKodu = 30,
                SehirAdi = "HAKKARİ",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler15);
            Bolgeler bolgeler16 = new Bolgeler
            {
                SehirKodu = 0x24,
                SehirAdi = "KARS",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler16);
            Bolgeler bolgeler17 = new Bolgeler
            {
                SehirKodu = 0x2c,
                SehirAdi = "MALATYA",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler17);
            Bolgeler bolgeler18 = new Bolgeler
            {
                SehirKodu = 0x31,
                SehirAdi = "MUŞ",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler18);
            Bolgeler bolgeler19 = new Bolgeler
            {
                SehirKodu = 0x3e,
                SehirAdi = "TUNCELİ",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler19);
            Bolgeler bolgeler20 = new Bolgeler
            {
                SehirKodu = 0x41,
                SehirAdi = "VAN",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler20);
            Bolgeler bolgeler21 = new Bolgeler
            {
                SehirKodu = 0x4b,
                SehirAdi = "ARDAHAN",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler21);
            Bolgeler bolgeler22 = new Bolgeler
            {
                SehirKodu = 0x4c,
                SehirAdi = "IĞDIR",
                BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler22);
            Bolgeler bolgeler23 = new Bolgeler
            {
                SehirKodu = 3,
                SehirAdi = "AFYONKARAHİSAR",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler23);
            Bolgeler bolgeler24 = new Bolgeler
            {
                SehirKodu = 9,
                SehirAdi = "AYDIN",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler24);
            Bolgeler bolgeler25 = new Bolgeler
            {
                SehirKodu = 20,
                SehirAdi = "DENİZLİ",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler25);
            Bolgeler bolgeler26 = new Bolgeler
            {
                SehirKodu = 0x23,
                SehirAdi = "İZMİR",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler26);
            Bolgeler bolgeler27 = new Bolgeler
            {
                SehirKodu = 0x2b,
                SehirAdi = "K\x00dcTAHYA",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler27);
            Bolgeler bolgeler28 = new Bolgeler
            {
                SehirKodu = 0x2d,
                SehirAdi = "MANİSA",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler28);
            Bolgeler bolgeler29 = new Bolgeler
            {
                SehirKodu = 0x30,
                SehirAdi = "MUĞLA",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler29);
            Bolgeler bolgeler30 = new Bolgeler
            {
                SehirKodu = 0x40,
                SehirAdi = "UŞAK",
                BolgeAdi = "EGE B\x00d6LGESİ"
            };
            list.Add(bolgeler30);
            Bolgeler bolgeler31 = new Bolgeler
            {
                SehirKodu = 2,
                SehirAdi = "ADIYAMAN",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler31);
            Bolgeler bolgeler32 = new Bolgeler
            {
                SehirKodu = 0x15,
                SehirAdi = "DİYARBAKIR",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler32);
            Bolgeler bolgeler33 = new Bolgeler
            {
                SehirKodu = 0x1b,
                SehirAdi = "GAZİANTEP",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler33);
            Bolgeler bolgeler34 = new Bolgeler
            {
                SehirKodu = 0x2f,
                SehirAdi = "MARDİN",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler34);
            Bolgeler bolgeler35 = new Bolgeler
            {
                SehirKodu = 0x38,
                SehirAdi = "SİİRT",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler35);
            Bolgeler bolgeler36 = new Bolgeler
            {
                SehirKodu = 0x3f,
                SehirAdi = "ŞANLIURFA",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler36);
            Bolgeler bolgeler37 = new Bolgeler
            {
                SehirKodu = 0x48,
                SehirAdi = "BATMAN",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler37);
            Bolgeler bolgeler38 = new Bolgeler
            {
                SehirKodu = 0x49,
                SehirAdi = "ŞIRNAK",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler38);
            Bolgeler bolgeler39 = new Bolgeler
            {
                SehirKodu = 0x4f,
                SehirAdi = "KİLİS",
                BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler39);
            Bolgeler bolgeler40 = new Bolgeler
            {
                SehirKodu = 6,
                SehirAdi = "ANKARA",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler40);
            Bolgeler bolgeler41 = new Bolgeler
            {
                SehirKodu = 0x12,
                SehirAdi = "\x00c7ANKIRI",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler41);
            Bolgeler bolgeler42 = new Bolgeler
            {
                SehirKodu = 0x1a,
                SehirAdi = "ESKİŞEHİR",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler42);
            Bolgeler bolgeler43 = new Bolgeler
            {
                SehirKodu = 0x26,
                SehirAdi = "KAYSERİ",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler43);
            Bolgeler bolgeler44 = new Bolgeler
            {
                SehirKodu = 40,
                SehirAdi = "KIRŞEHİR",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler44);
            Bolgeler bolgeler45 = new Bolgeler
            {
                SehirKodu = 0x2a,
                SehirAdi = "KONYA",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler45);
            Bolgeler bolgeler46 = new Bolgeler
            {
                SehirKodu = 50,
                SehirAdi = "NEVŞEHİR",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler46);
            Bolgeler bolgeler47 = new Bolgeler
            {
                SehirKodu = 0x33,
                SehirAdi = "NİĞDE",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler47);
            Bolgeler bolgeler48 = new Bolgeler
            {
                SehirKodu = 0x3a,
                SehirAdi = "SİVAS",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler48);
            Bolgeler bolgeler49 = new Bolgeler
            {
                SehirKodu = 0x42,
                SehirAdi = "YOZGAT",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler49);
            Bolgeler bolgeler50 = new Bolgeler
            {
                SehirKodu = 0x44,
                SehirAdi = "AKSARAY",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler50);
            Bolgeler bolgeler51 = new Bolgeler
            {
                SehirKodu = 70,
                SehirAdi = "KARAMAN",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler51);
            Bolgeler bolgeler52 = new Bolgeler
            {
                SehirKodu = 0x47,
                SehirAdi = "KIRIKKALE",
                BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
            };
            list.Add(bolgeler52);
            Bolgeler bolgeler53 = new Bolgeler
            {
                SehirKodu = 5,
                SehirAdi = "AMASYA",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler53);
            Bolgeler bolgeler54 = new Bolgeler
            {
                SehirKodu = 8,
                SehirAdi = "ARTVİN",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler54);
            Bolgeler bolgeler55 = new Bolgeler
            {
                SehirKodu = 14,
                SehirAdi = "BOLU",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler55);
            Bolgeler bolgeler56 = new Bolgeler
            {
                SehirKodu = 0x13,
                SehirAdi = "\x00c7ORUM",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler56);
            Bolgeler bolgeler57 = new Bolgeler
            {
                SehirKodu = 0x1c,
                SehirAdi = "GİRESUN",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler57);
            Bolgeler bolgeler58 = new Bolgeler
            {
                SehirKodu = 0x1d,
                SehirAdi = "G\x00dcM\x00dcŞHANE",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler58);
            Bolgeler bolgeler59 = new Bolgeler
            {
                SehirKodu = 0x25,
                SehirAdi = "KASTAMONU",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler59);
            Bolgeler bolgeler60 = new Bolgeler
            {
                SehirKodu = 0x34,
                SehirAdi = "ORDU",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler60);
            Bolgeler bolgeler61 = new Bolgeler
            {
                SehirKodu = 0x35,
                SehirAdi = "RİZE",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler61);
            Bolgeler bolgeler62 = new Bolgeler
            {
                SehirKodu = 0x37,
                SehirAdi = "SAMSUN",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler62);
            Bolgeler bolgeler63 = new Bolgeler
            {
                SehirKodu = 0x39,
                SehirAdi = "SİNOP",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler63);
            Bolgeler bolgeler64 = new Bolgeler
            {
                SehirKodu = 60,
                SehirAdi = "TOKAT",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler64);
            Bolgeler bolgeler65 = new Bolgeler
            {
                SehirKodu = 0x3d,
                SehirAdi = "TRABZON",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler65);
            Bolgeler bolgeler66 = new Bolgeler
            {
                SehirKodu = 0x43,
                SehirAdi = "ZONGULDAK",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler66);
            Bolgeler bolgeler67 = new Bolgeler
            {
                SehirKodu = 0x45,
                SehirAdi = "BAYBURT",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler67);
            Bolgeler bolgeler68 = new Bolgeler
            {
                SehirKodu = 0x4a,
                SehirAdi = "BARTIN",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler68);
            Bolgeler bolgeler69 = new Bolgeler
            {
                SehirKodu = 0x4e,
                SehirAdi = "KARAB\x00dcK",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler69);
            Bolgeler bolgeler70 = new Bolgeler
            {
                SehirKodu = 0x51,
                SehirAdi = "D\x00dcZCE",
                BolgeAdi = "KARADENİZ B\x00d6LGESİ"
            };
            list.Add(bolgeler70);
            Bolgeler bolgeler71 = new Bolgeler
            {
                SehirKodu = 10,
                SehirAdi = "BALIKESİR",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler71);
            Bolgeler bolgeler72 = new Bolgeler
            {
                SehirKodu = 11,
                SehirAdi = "BİLECİK",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler72);
            Bolgeler bolgeler73 = new Bolgeler
            {
                SehirKodu = 0x10,
                SehirAdi = "BURSA",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler73);
            Bolgeler bolgeler74 = new Bolgeler
            {
                SehirKodu = 0x11,
                SehirAdi = "\x00c7ANAKKALE",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler74);
            Bolgeler bolgeler75 = new Bolgeler
            {
                SehirKodu = 0x16,
                SehirAdi = "EDİRNE",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler75);
            Bolgeler bolgeler76 = new Bolgeler
            {
                SehirKodu = 0x22,
                SehirAdi = "İSTANBUL",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler76);
            Bolgeler bolgeler77 = new Bolgeler
            {
                SehirKodu = 0x27,
                SehirAdi = "KIRKLARELİ",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler77);
            Bolgeler bolgeler78 = new Bolgeler
            {
                SehirKodu = 0x29,
                SehirAdi = "KOCAELİ",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler78);
            Bolgeler bolgeler79 = new Bolgeler
            {
                SehirKodu = 0x36,
                SehirAdi = "SAKARYA",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler79);
            Bolgeler bolgeler80 = new Bolgeler
            {
                SehirKodu = 0x3b,
                SehirAdi = "TEKİRDAĞ",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler80);
            Bolgeler bolgeler81 = new Bolgeler
            {
                SehirKodu = 0x4d,
                SehirAdi = "YALOVA",
                BolgeAdi = "MARMARA B\x00d6LGESİ"
            };
            list.Add(bolgeler81);
            return list;
        }

        //public static string BolgeGetir(string sehir)
        //{
        //   // cIME__DisplayClass13_0 class_;
        //    List<Bolgeler> source = new List<Bolgeler>();
        //    Bolgeler item = new Bolgeler
        //    {
        //        SehirKodu = 1,
        //        SehirAdi = "ADANA",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(item);
        //    Bolgeler bolgeler2 = new Bolgeler
        //    {
        //        SehirKodu = 7,
        //        SehirAdi = "ANTALYA",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler2);
        //    Bolgeler bolgeler3 = new Bolgeler
        //    {
        //        SehirKodu = 15,
        //        SehirAdi = "BURDUR",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler3);
        //    Bolgeler bolgeler4 = new Bolgeler
        //    {
        //        SehirKodu = 0x1f,
        //        SehirAdi = "HATAY",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler4);
        //    Bolgeler bolgeler5 = new Bolgeler
        //    {
        //        SehirKodu = 0x20,
        //        SehirAdi = "ISPARTA",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler5);
        //    Bolgeler bolgeler6 = new Bolgeler
        //    {
        //        SehirKodu = 0x21,
        //        SehirAdi = "MERSİN",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler6);
        //    Bolgeler bolgeler7 = new Bolgeler
        //    {
        //        SehirKodu = 0x2e,
        //        SehirAdi = "KAHRAMANMARAŞ",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler7);
        //    Bolgeler bolgeler8 = new Bolgeler
        //    {
        //        SehirKodu = 80,
        //        SehirAdi = "OSMANİYE",
        //        BolgeAdi = "AKDENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler8);
        //    Bolgeler bolgeler9 = new Bolgeler
        //    {
        //        SehirKodu = 4,
        //        SehirAdi = "AĞRI",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler9);
        //    Bolgeler bolgeler10 = new Bolgeler
        //    {
        //        SehirKodu = 12,
        //        SehirAdi = "BİNG\x00d6L",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler10);
        //    Bolgeler bolgeler11 = new Bolgeler
        //    {
        //        SehirKodu = 13,
        //        SehirAdi = "BİTLİS",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler11);
        //    Bolgeler bolgeler12 = new Bolgeler
        //    {
        //        SehirKodu = 0x17,
        //        SehirAdi = "ELAZIĞ",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler12);
        //    Bolgeler bolgeler13 = new Bolgeler
        //    {
        //        SehirKodu = 0x18,
        //        SehirAdi = "ERZİNCAN",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler13);
        //    Bolgeler bolgeler14 = new Bolgeler
        //    {
        //        SehirKodu = 0x19,
        //        SehirAdi = "ERZURUM",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler14);
        //    Bolgeler bolgeler15 = new Bolgeler
        //    {
        //        SehirKodu = 30,
        //        SehirAdi = "HAKKARİ",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler15);
        //    Bolgeler bolgeler16 = new Bolgeler
        //    {
        //        SehirKodu = 0x24,
        //        SehirAdi = "KARS",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler16);
        //    Bolgeler bolgeler17 = new Bolgeler
        //    {
        //        SehirKodu = 0x2c,
        //        SehirAdi = "MALATYA",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler17);
        //    Bolgeler bolgeler18 = new Bolgeler
        //    {
        //        SehirKodu = 0x31,
        //        SehirAdi = "MUŞ",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler18);
        //    Bolgeler bolgeler19 = new Bolgeler
        //    {
        //        SehirKodu = 0x3e,
        //        SehirAdi = "TUNCELİ",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler19);
        //    Bolgeler bolgeler20 = new Bolgeler
        //    {
        //        SehirKodu = 0x41,
        //        SehirAdi = "VAN",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler20);
        //    Bolgeler bolgeler21 = new Bolgeler
        //    {
        //        SehirKodu = 0x4b,
        //        SehirAdi = "ARDAHAN",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler21);
        //    Bolgeler bolgeler22 = new Bolgeler
        //    {
        //        SehirKodu = 0x4c,
        //        SehirAdi = "IĞDIR",
        //        BolgeAdi = "DOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler22);
        //    Bolgeler bolgeler23 = new Bolgeler
        //    {
        //        SehirKodu = 3,
        //        SehirAdi = "AFYONKARAHİSAR",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler23);
        //    Bolgeler bolgeler24 = new Bolgeler
        //    {
        //        SehirKodu = 9,
        //        SehirAdi = "AYDIN",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler24);
        //    Bolgeler bolgeler25 = new Bolgeler
        //    {
        //        SehirKodu = 20,
        //        SehirAdi = "DENİZLİ",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler25);
        //    Bolgeler bolgeler26 = new Bolgeler
        //    {
        //        SehirKodu = 0x23,
        //        SehirAdi = "İZMİR",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler26);
        //    Bolgeler bolgeler27 = new Bolgeler
        //    {
        //        SehirKodu = 0x2b,
        //        SehirAdi = "K\x00dcTAHYA",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler27);
        //    Bolgeler bolgeler28 = new Bolgeler
        //    {
        //        SehirKodu = 0x2d,
        //        SehirAdi = "MANİSA",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler28);
        //    Bolgeler bolgeler29 = new Bolgeler
        //    {
        //        SehirKodu = 0x30,
        //        SehirAdi = "MUĞLA",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler29);
        //    Bolgeler bolgeler30 = new Bolgeler
        //    {
        //        SehirKodu = 0x40,
        //        SehirAdi = "UŞAK",
        //        BolgeAdi = "EGE B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler30);
        //    Bolgeler bolgeler31 = new Bolgeler
        //    {
        //        SehirKodu = 2,
        //        SehirAdi = "ADIYAMAN",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler31);
        //    Bolgeler bolgeler32 = new Bolgeler
        //    {
        //        SehirKodu = 0x15,
        //        SehirAdi = "DİYARBAKIR",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler32);
        //    Bolgeler bolgeler33 = new Bolgeler
        //    {
        //        SehirKodu = 0x1b,
        //        SehirAdi = "GAZİANTEP",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler33);
        //    Bolgeler bolgeler34 = new Bolgeler
        //    {
        //        SehirKodu = 0x2f,
        //        SehirAdi = "MARDİN",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler34);
        //    Bolgeler bolgeler35 = new Bolgeler
        //    {
        //        SehirKodu = 0x38,
        //        SehirAdi = "SİİRT",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler35);
        //    Bolgeler bolgeler36 = new Bolgeler
        //    {
        //        SehirKodu = 0x3f,
        //        SehirAdi = "ŞANLIURFA",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler36);
        //    Bolgeler bolgeler37 = new Bolgeler
        //    {
        //        SehirKodu = 0x48,
        //        SehirAdi = "BATMAN",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler37);
        //    Bolgeler bolgeler38 = new Bolgeler
        //    {
        //        SehirKodu = 0x49,
        //        SehirAdi = "ŞIRNAK",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler38);
        //    Bolgeler bolgeler39 = new Bolgeler
        //    {
        //        SehirKodu = 0x4f,
        //        SehirAdi = "KİLİS",
        //        BolgeAdi = "G\x00dcNEYDOĞU ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler39);
        //    Bolgeler bolgeler40 = new Bolgeler
        //    {
        //        SehirKodu = 6,
        //        SehirAdi = "ANKARA",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler40);
        //    Bolgeler bolgeler41 = new Bolgeler
        //    {
        //        SehirKodu = 0x12,
        //        SehirAdi = "\x00c7ANKIRI",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler41);
        //    Bolgeler bolgeler42 = new Bolgeler
        //    {
        //        SehirKodu = 0x1a,
        //        SehirAdi = "ESKİŞEHİR",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler42);
        //    Bolgeler bolgeler43 = new Bolgeler
        //    {
        //        SehirKodu = 0x26,
        //        SehirAdi = "KAYSERİ",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler43);
        //    Bolgeler bolgeler44 = new Bolgeler
        //    {
        //        SehirKodu = 40,
        //        SehirAdi = "KIRŞEHİR",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler44);
        //    Bolgeler bolgeler45 = new Bolgeler
        //    {
        //        SehirKodu = 0x2a,
        //        SehirAdi = "KONYA",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler45);
        //    Bolgeler bolgeler46 = new Bolgeler
        //    {
        //        SehirKodu = 50,
        //        SehirAdi = "NEVŞEHİR",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler46);
        //    Bolgeler bolgeler47 = new Bolgeler
        //    {
        //        SehirKodu = 0x33,
        //        SehirAdi = "NİĞDE",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler47);
        //    Bolgeler bolgeler48 = new Bolgeler
        //    {
        //        SehirKodu = 0x3a,
        //        SehirAdi = "SİVAS",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler48);
        //    Bolgeler bolgeler49 = new Bolgeler
        //    {
        //        SehirKodu = 0x42,
        //        SehirAdi = "YOZGAT",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler49);
        //    Bolgeler bolgeler50 = new Bolgeler
        //    {
        //        SehirKodu = 0x44,
        //        SehirAdi = "AKSARAY",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler50);
        //    Bolgeler bolgeler51 = new Bolgeler
        //    {
        //        SehirKodu = 70,
        //        SehirAdi = "KARAMAN",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler51);
        //    Bolgeler bolgeler52 = new Bolgeler
        //    {
        //        SehirKodu = 0x47,
        //        SehirAdi = "KIRIKKALE",
        //        BolgeAdi = "İ\x00c7 ANADOLU B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler52);
        //    Bolgeler bolgeler53 = new Bolgeler
        //    {
        //        SehirKodu = 5,
        //        SehirAdi = "AMASYA",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler53);
        //    Bolgeler bolgeler54 = new Bolgeler
        //    {
        //        SehirKodu = 8,
        //        SehirAdi = "ARTVİN",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler54);
        //    Bolgeler bolgeler55 = new Bolgeler
        //    {
        //        SehirKodu = 14,
        //        SehirAdi = "BOLU",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler55);
        //    Bolgeler bolgeler56 = new Bolgeler
        //    {
        //        SehirKodu = 0x13,
        //        SehirAdi = "\x00c7ORUM",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler56);
        //    Bolgeler bolgeler57 = new Bolgeler
        //    {
        //        SehirKodu = 0x1c,
        //        SehirAdi = "GİRESUN",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler57);
        //    Bolgeler bolgeler58 = new Bolgeler
        //    {
        //        SehirKodu = 0x1d,
        //        SehirAdi = "G\x00dcM\x00dcŞHANE",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler58);
        //    Bolgeler bolgeler59 = new Bolgeler
        //    {
        //        SehirKodu = 0x25,
        //        SehirAdi = "KASTAMONU",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler59);
        //    Bolgeler bolgeler60 = new Bolgeler
        //    {
        //        SehirKodu = 0x34,
        //        SehirAdi = "ORDU",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler60);
        //    Bolgeler bolgeler61 = new Bolgeler
        //    {
        //        SehirKodu = 0x35,
        //        SehirAdi = "RİZE",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler61);
        //    Bolgeler bolgeler62 = new Bolgeler
        //    {
        //        SehirKodu = 0x37,
        //        SehirAdi = "SAMSUN",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler62);
        //    Bolgeler bolgeler63 = new Bolgeler
        //    {
        //        SehirKodu = 0x39,
        //        SehirAdi = "SİNOP",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler63);
        //    Bolgeler bolgeler64 = new Bolgeler
        //    {
        //        SehirKodu = 60,
        //        SehirAdi = "TOKAT",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler64);
        //    Bolgeler bolgeler65 = new Bolgeler
        //    {
        //        SehirKodu = 0x3d,
        //        SehirAdi = "TRABZON",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler65);
        //    Bolgeler bolgeler66 = new Bolgeler
        //    {
        //        SehirKodu = 0x43,
        //        SehirAdi = "ZONGULDAK",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler66);
        //    Bolgeler bolgeler67 = new Bolgeler
        //    {
        //        SehirKodu = 0x45,
        //        SehirAdi = "BAYBURT",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler67);
        //    Bolgeler bolgeler68 = new Bolgeler
        //    {
        //        SehirKodu = 0x4a,
        //        SehirAdi = "BARTIN",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler68);
        //    Bolgeler bolgeler69 = new Bolgeler
        //    {
        //        SehirKodu = 0x4e,
        //        SehirAdi = "KARAB\x00dcK",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler69);
        //    Bolgeler bolgeler70 = new Bolgeler
        //    {
        //        SehirKodu = 0x51,
        //        SehirAdi = "D\x00dcZCE",
        //        BolgeAdi = "KARADENİZ B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler70);
        //    Bolgeler bolgeler71 = new Bolgeler
        //    {
        //        SehirKodu = 10,
        //        SehirAdi = "BALIKESİR",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler71);
        //    Bolgeler bolgeler72 = new Bolgeler
        //    {
        //        SehirKodu = 11,
        //        SehirAdi = "BİLECİK",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler72);
        //    Bolgeler bolgeler73 = new Bolgeler
        //    {
        //        SehirKodu = 0x10,
        //        SehirAdi = "BURSA",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler73);
        //    Bolgeler bolgeler74 = new Bolgeler
        //    {
        //        SehirKodu = 0x11,
        //        SehirAdi = "\x00c7ANAKKALE",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler74);
        //    Bolgeler bolgeler75 = new Bolgeler
        //    {
        //        SehirKodu = 0x16,
        //        SehirAdi = "EDİRNE",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler75);
        //    Bolgeler bolgeler76 = new Bolgeler
        //    {
        //        SehirKodu = 0x22,
        //        SehirAdi = "İSTANBUL",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler76);
        //    Bolgeler bolgeler77 = new Bolgeler
        //    {
        //        SehirKodu = 0x27,
        //        SehirAdi = "KIRKLARELİ",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler77);
        //    Bolgeler bolgeler78 = new Bolgeler
        //    {
        //        SehirKodu = 0x29,
        //        SehirAdi = "KOCAELİ",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler78);
        //    Bolgeler bolgeler79 = new Bolgeler
        //    {
        //        SehirKodu = 0x36,
        //        SehirAdi = "SAKARYA",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler79);
        //    Bolgeler bolgeler80 = new Bolgeler
        //    {
        //        SehirKodu = 0x3b,
        //        SehirAdi = "TEKİRDAĞ",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler80);
        //    Bolgeler bolgeler81 = new Bolgeler
        //    {
        //        SehirKodu = 0x4d,
        //        SehirAdi = "YALOVA",
        //        BolgeAdi = "MARMARA B\x00d6LGESİ"
        //    };
        //    source.Add(bolgeler81);
        //    //return source.Where<Bolgeler>(new Func<Bolgeler, bool>(class_, Bolgeler.BolgeGetir)).Select<Bolgeler, string>((cIME.a__13_1 ?? (cIME.a__13_1 = new Func<Bolgeler, string>(cIME.a, Bolgeler.BolgeGetir)))).FirstOrDefault<string>();
        //}

        public static bool GroupGuncelle(string cariKodu, int AnaID, int AltID, int SermayeID)
        {
            if (MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("SELECT COUNT(CARI_KOD) FROM RBS_CARI_GRUP WHERE CARI_KOD = '{0}'", cariKodu), CommandType.Text, 60, new KomutArgumanlari_[0]) > 0)
            {
                MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("UPDATE RBS_CARI_GRUP SET ANA_KATEGORI_ID = {0}, ALT_KATEGORY_ID = {1}, SERMAYE_ID = {2} WHERE CARI_KOD = '{3}'", new object[] { AnaID, AltID, SermayeID, cariKodu }), CommandType.Text, 60, new KomutArgumanlari_[0]);
            }
            else
            {
                MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("INSERT INTO RBS_CARI_GRUP (CARI_KOD, ANA_KATEGORI_ID, ALT_KATEGORY_ID, SERMAYE_ID) VALUES ('{0}', {1}, {2}, {3})", new object[] { cariKodu, AnaID, AltID, SermayeID }), CommandType.Text, 60, new KomutArgumanlari_[0]);
            }
            return true;
        }

        public string BolgeAdi { get; set; }

        public string SehirAdi { get; set; }

        public int SehirKodu { get; set; }

        [Serializable, CompilerGenerated]
        private sealed class cIME
        {
            public static readonly Bolgeler.cIME a = new Bolgeler.cIME();
            public static Func<Bolgeler, string> a__13_1;

            internal string BolgeGetir(Bolgeler x)
            {
                return x.BolgeAdi;
            }
        }
    }
}
