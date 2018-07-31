using LoginForm.clsClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class clsInvoice
    {
        public static void FaturaAraFisiEkleme(string ficheNo, DateTime date, string irsaliyeNo, int cariID, double rate, List<clsInvoiceLine> satirlar)
        {
            KomutArgumanlari_[] arguman = new KomutArgumanlari_[8];
            KomutArgumanlari_ i_1 = new KomutArgumanlari_
            {
                Parametre = ficheNo,
                ParametreAdi = "@FICHENO"
            };
            arguman[0] = i_1;
            KomutArgumanlari_ i_2 = new KomutArgumanlari_
            {
                Parametre = date,
                ParametreAdi = "@DATE_"
            };
            arguman[1] = i_2;
            KomutArgumanlari_ i_3 = new KomutArgumanlari_
            {
                Parametre = irsaliyeNo,
                ParametreAdi = "@PURCHASENO"
            };
            arguman[2] = i_3;
            KomutArgumanlari_ i_4 = new KomutArgumanlari_
            {
                Parametre = cariID,
                ParametreAdi = "@CARDID"
            };
            arguman[3] = i_4;
            KomutArgumanlari_ i_5 = new KomutArgumanlari_
            {
                Parametre = rate,
                ParametreAdi = "@RATE"
            };
            arguman[4] = i_5;
            KomutArgumanlari_ i_6 = new KomutArgumanlari_
            {
                Parametre = Utils.FrmNo,
                ParametreAdi = "@FRMNO"
            };
            arguman[5] = i_6;
            KomutArgumanlari_ i_7 = new KomutArgumanlari_
            {
                Parametre = DateTime.Now,
                ParametreAdi = "@ADDDATE"
            };
            arguman[6] = i_7;
            KomutArgumanlari_ i_8 = new KomutArgumanlari_
            {
                Parametre = Utils.getCurrentUser().WorkerID,
                ParametreAdi = "@ADDUSR"
            };
            arguman[7] = i_8;
            int num = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, "INSERT INTO RBS_FATURA_B(FICHENO,DATE_,PURCHASENO,CARDID,RATE,LOGO,FRMNO,RATENAME, ADDDATE, ADDUSR) VALUES (@FICHENO,@DATE_,@PURCHASENO,@CARDID,@RATE,0,@FRMNO,'GBP', @ADDDATE, @ADDUSR); SELECT SCOPE_IDENTITY()", CommandType.Text, 60, arguman);
            foreach (clsInvoiceLine line in satirlar)
            {
                KomutArgumanlari_[] i_Array2 = new KomutArgumanlari_[10];
                KomutArgumanlari_ i_9 = new KomutArgumanlari_
                {
                    Parametre = num,
                    ParametreAdi = "@BID"
                };
                i_Array2[0] = i_9;
                KomutArgumanlari_ i_10 = new KomutArgumanlari_
                {
                    Parametre = line.OrderNumber,
                    ParametreAdi = "@ORDERNUMBER"
                };
                i_Array2[1] = i_10;
                KomutArgumanlari_ i_11 = new KomutArgumanlari_
                {
                    Parametre = line.ProductCode,
                    ParametreAdi = "@PRODUCTCODE"
                };
                i_Array2[2] = i_11;
                KomutArgumanlari_ i_12 = new KomutArgumanlari_
                {
                    Parametre = line.Quantity,
                    ParametreAdi = "@QTY"
                };
                i_Array2[3] = i_12;
                KomutArgumanlari_ i_13 = new KomutArgumanlari_
                {
                    Parametre = line.UnitPrice,
                    ParametreAdi = "@UNITPRC"
                };
                i_Array2[4] = i_13;
                KomutArgumanlari_ i_14 = new KomutArgumanlari_
                {
                    Parametre = line.birimID,
                    ParametreAdi = "@BRMID"
                };
                i_Array2[5] = i_14;
                KomutArgumanlari_ i_15 = new KomutArgumanlari_
                {
                    Parametre = line.birimsetID,
                    ParametreAdi = "@BRMSETID"
                };
                i_Array2[6] = i_15;
                KomutArgumanlari_ i_16 = new KomutArgumanlari_
                {
                    Parametre = line.urunID,
                    ParametreAdi = "@URUNID"
                };
                i_Array2[7] = i_16;
                KomutArgumanlari_ i_17 = new KomutArgumanlari_
                {
                    Parametre = line.SATIR_REF,
                    ParametreAdi = "@SATIR_REF"
                };
                i_Array2[8] = i_17;
                KomutArgumanlari_ i_18 = new KomutArgumanlari_
                {
                    Parametre = line.PaketNo,
                    ParametreAdi = "@PaketNo"
                };
                i_Array2[9] = i_18;
                MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, "INSERT INTO RBS_FATURA_S(BID, ORDERNUMBER, PRODUCTCODE, QTY, UNITPRC, BRMID, BRMSETID, URUNID, SATIR_REF, PaketNo) VALUES (@BID, @ORDERNUMBER, @PRODUCTCODE, @QTY, @UNITPRC, @BRMID, @BRMSETID, @URUNID, @SATIR_REF, @PaketNo)", CommandType.Text, 60, i_Array2);
            }
        }

        public static void FaturaFisiEkleme(string ficheNo, DateTime date, string irsaliyeNo, int cariID, int araID, double rate, List<clsInvoiceLine> satirlar)
        {
            KomutArgumanlari_[] arguman = new KomutArgumanlari_[6];
            KomutArgumanlari_ i_1 = new KomutArgumanlari_
            {
                Parametre = ficheNo,
                ParametreAdi = "@faturaNo"
            };
            arguman[0] = i_1;
            KomutArgumanlari_ i_2 = new KomutArgumanlari_
            {
                Parametre = date,
                ParametreAdi = "@tarih"
            };
            arguman[1] = i_2;
            KomutArgumanlari_ i_3 = new KomutArgumanlari_
            {
                Parametre = cariID,
                ParametreAdi = "@CariHK"
            };
            arguman[2] = i_3;
            KomutArgumanlari_ i_4 = new KomutArgumanlari_
            {
                Parametre = rate,
                ParametreAdi = "@Rate"
            };
            arguman[3] = i_4;
            KomutArgumanlari_ i_5 = new KomutArgumanlari_
            {
                //Parametre = satirlar.Sum<clsInvoiceLine>(cIME.<> 9__1_0 ?? (cIME.<> 9__1_0 = new Func<clsInvoiceLine, double>(cIME.<> 9, (IntPtr)this.< FaturaFisiEkleme > b__1_0))),
                ParametreAdi = "@Toplam"
            };
            arguman[4] = i_5;
            KomutArgumanlari_ i_6 = new KomutArgumanlari_
            {
                //Parametre = satirlar.Sum<clsInvoiceLine>(cIME.<> 9__1_1 ?? (cIME.<> 9__1_1 = new Func<clsInvoiceLine, double>(cIME.<> 9, (IntPtr)this.< FaturaFisiEkleme > b__1_1))),
                ParametreAdi = "@Net"
            };
            arguman[5] = i_6;
            int num = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_INVOICE (GRPCODE, TRCODE, FICHENO, DATE_, TIME_, DOCODE, SPECODE, CYPHCODE, CLIENTREF, RECVREF, CENTERREF, ACCOUNTREF, SOURCEINDEX, SOURCECOSTGRP, CANCELLED, ACCOUNTED, PAIDINCASH, FROMKASA, ENTEGSET, VAT, ADDDISCOUNTS, TOTALDISCOUNTS, TOTALDISCOUNTED, ADDEXPENSES, TOTALEXPENSES, DISTEXPENSE, TOTALDEPOZITO, TOTALPROMOTIONS, VATINCGROSS, TOTALVAT, GROSSTOTAL, NETTOTAL, GENEXP1, GENEXP2, GENEXP3, GENEXP4, INTERESTAPP, TRCURR, TRRATE, TRNET, REPORTRATE, REPORTNET, ONLYONEPAYLINE, KASTRANSREF, PAYDEFREF, PRINTCNT, GVATINC, BRANCH, DEPARTMENT, ACCFICHEREF, ADDEXPACCREF, ADDEXPCENTREF, DECPRDIFF, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, SALESMANREF, CANCELLEDACC, SHPTYPCOD, SHPAGNCOD, TRACKNR, GENEXCTYP, LINEEXCTYP, TRADINGGRP, TEXTINC, SITEID, RECSTATUS, ORGLOGICREF, FACTORYNR, WFSTATUS, SHIPINFOREF, DISTORDERREF, SENDCNT, DLVCLIENT, COSTOFSALEFCREF, OPSTAT, DOCTRACKINGNR, TOTALADDTAX, PAYMENTTYPE, INFIDX, ACCOUNTEDCNT, ORGLOGOID, FROMEXIM, FRGTYPCOD, EXIMFCTYPE, FROMORDWITHPAY, PROJECTREF, WFLOWCRDREF, STATUS, DEDUCTIONPART1, DEDUCTIONPART2, TOTALEXADDTAX, EXACCOUNTED, FROMBANK, BNTRANSREF, AFFECTCOLLATRL, GRPFIRMTRANS, AFFECTRISK, CONTROLINFO, POSTRANSFERINFO, TAXFREECHX, PASSPORTNO, CREDITCARDNO, INEFFECTIVECOST, REFLECTED, REFLACCFICHEREF, CANCELLEDREFLACC, CREDITCARDNUM, APPROVE, APPROVEDATE, CANTCREDEDUCT, ENTRUST, DOCDATE, EINVOICE, PROFILEID, GUID, ESTATUS, ESTARTDATE, EENDDATE, EDESCRIPTION, EDURATION, EDURATIONTYPE, DEVIR, DISTADJPRICEUFRS, COSFCREFUFRS, GLOBALID, TOTALSERVICES, FROMLEASING, CANCELEXP, UNDOEXP, VATEXCEPTREASON, CAMPAIGNCODE, CANCELDESPSINV, FROMEXCHDIFF, EXIMVAT, SERIALCODE, APPCLDEDUCTLIM, EINVOICETYP, VATEXCEPTCODE, OFFERREF) VALUES (1, 1, @faturaNo, @tarih, 0, '', 'RS', 'RBS', @CariHK, 0, 0, 4326, 0, 0, 0, 0, 0, 0, 247, 0, 0, 0, @Toplam, 0, 0, 0, 0, 0, 0, 0, @Toplam, @Toplam, '', '', '', '', 0, 17, @Rate, @Net, 1, @Toplam, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 1, GETDATE(), DATEPART(hh, GETDATE()), DATEPART(MI, GETDATE()), DATEPART(S, GETDATE()), 0, NULL, 0, 0, 0, 0, 0, '', '', '', 2, 2, '', 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 0, '', 0, 0, 0, 0, 0, 2, 3, 0, 0, 0 ,0, 0, 0, 1, 0, 0, 0, '', '', 0, 0, 0, 0, '', 0, NULL, 0, 0, @tarih, 0, 0, NEWID(), 0, NULL, NULL, '', 0, 0, 0, 0, 0, '', 0, 0, '', '', '', '', 0, 0, 0, '', 0, 0, '', 0); SELECT SCOPE_IDENTITY() AS SCOPE_ID_COLUMN", Utils.FrmNo, Utils.DnmNo), CommandType.Text, 30, arguman);
            if (num != 0)
            {
                KomutArgumanlari_[] i_Array2 = new KomutArgumanlari_[8];
                KomutArgumanlari_ i_7 = new KomutArgumanlari_
                {
                    Parametre = ficheNo,
                    ParametreAdi = "@irsaliyeNo"
                };
                i_Array2[0] = i_7;
                KomutArgumanlari_ i_8 = new KomutArgumanlari_
                {
                    Parametre = date,
                    ParametreAdi = "@tarih"
                };
                i_Array2[1] = i_8;
                KomutArgumanlari_ i_9 = new KomutArgumanlari_
                {
                    Parametre = ficheNo,
                    ParametreAdi = "@faturaNo"
                };
                i_Array2[2] = i_9;
                KomutArgumanlari_ i_10 = new KomutArgumanlari_
                {
                    Parametre = num,
                    ParametreAdi = "@faturaID"
                };
                i_Array2[3] = i_10;
                KomutArgumanlari_ i_11 = new KomutArgumanlari_
                {
                    Parametre = cariID,
                    ParametreAdi = "@cariID"
                };
                i_Array2[4] = i_11;
                KomutArgumanlari_ i_12 = new KomutArgumanlari_
                {
                    //Parametre = satirlar.Sum<clsInvoiceLine>(cIME.<> 9__1_2 ?? (cIME.<> 9__1_2 = new Func<clsInvoiceLine, double>(cIME.<> 9, (IntPtr)this.< FaturaFisiEkleme > b__1_2))),
                    ParametreAdi = "@toplam"
                };
                i_Array2[5] = i_12;
                KomutArgumanlari_ i_13 = new KomutArgumanlari_
                {
                    Parametre = rate,
                    ParametreAdi = "@Rate"
                };
                i_Array2[6] = i_13;
                KomutArgumanlari_ i_14 = new KomutArgumanlari_
                {
                    //Parametre = satirlar.Sum<clsInvoiceLine>(cIME.<> 9__1_3 ?? (cIME.<> 9__1_3 = new Func<clsInvoiceLine, double>(cIME.<> 9, (IntPtr)this.< FaturaFisiEkleme > b__1_3))),
                    //ParametreAdi = "@Net"
                };
                i_Array2[7] = i_14;
                int num2 = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_STFICHE (GRPCODE, TRCODE, IOCODE, FICHENO, DATE_, FTIME, DOCODE, INVNO, SPECODE, CYPHCODE, INVOICEREF, CLIENTREF, RECVREF, ACCOUNTREF, CENTERREF, PRODORDERREF, PORDERFICHENO, SOURCETYPE, SOURCEINDEX, SOURCEWSREF, SOURCEPOLNREF, SOURCECOSTGRP, DESTTYPE, DESTINDEX, DESTWSREF, DESTPOLNREF, DESTCOSTGRP, FACTORYNR, BRANCH, DEPARTMENT, COMPBRANCH, COMPDEPARTMENT, COMPFACTORY, PRODSTAT, DEVIR, CANCELLED, BILLED, ACCOUNTED, UPDCURR, INUSE, INVKIND, ADDDISCOUNTS, TOTALDISCOUNTS, TOTALDISCOUNTED, ADDEXPENSES, TOTALEXPENSES, TOTALDEPOZITO, TOTALPROMOTIONS, TOTALVAT, GROSSTOTAL, NETTOTAL, GENEXP1, GENEXP2, GENEXP3, GENEXP4, REPORTRATE, REPORTNET, EXTENREF, PAYDEFREF, PRINTCNT, FICHECNT, ACCFICHEREF, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, SALESMANREF, CANCELLEDACC, SHPTYPCOD, SHPAGNCOD, TRACKNR, GENEXCTYP, LINEEXCTYP, TRADINGGRP, TEXTINC, SITEID, RECSTATUS, ORGLOGICREF, WFSTATUS, SHIPINFOREF, DISTORDERREF, SENDCNT, DLVCLIENT, DOCTRACKINGNR, ADDTAXCALC, TOTALADDTAX, UGIRTRACKINGNO, QPRODFCREF, VAACCREF, VACENTERREF, ORGLOGOID, FROMEXIM, FRGTYPCOD, TRCURR, TRRATE, TRNET, EXIMWHFCREF, EXIMFCTYPE, MAINSTFCREF, FROMORDWITHPAY, PROJECTREF, WFLOWCRDREF, STATUS, UPDTRCURR, TOTALEXADDTAX, AFFECTCOLLATRL, DEDUCTIONPART1, DEDUCTIONPART2, GRPFIRMTRANS, AFFECTRISK, DISPSTATUS, APPROVE, APPROVEDATE, CANTCREDEDUCT, SHIPDATE, SHIPTIME, ENTRUSTDEVIR, RELTRANSFCREF, FROMTRANSFER, GUID, GLOBALID, COMPSTFCREF, COMPINVREF, TOTALSERVICES, CAMPAIGNCODE, OFFERREF) VALUES (1, 1, 1, @irsaliyeNo, @tarih, 0, '', @faturaNo, 'RS', 'RBS', @faturaID, @cariID, 0, 0, 0, 0, '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, @toplam, 0, 0, 0, 0, 0, @toplam, @toplam, '', '', '', '', 1, @toplam, 0, 0, 0, 1, 0, 1, GETDATE(),  DATEPART(hh, GETDATE()), DATEPART(MI, GETDATE()), DATEPART(S, GETDATE()), 0, NULL, 0, 0, 0, 0, 0, '', '', '', 2, 2, '', 0, 0, 1, 0, 0, 0, 0, 0, 0, '', 0, 0, '', 0, 0, 0,'', 0, '', 17, @Rate, @Net, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 0, 1, 1, 0, NULL, 0, NULL, 0, 0, 0, 0, NEWID(), '', 0, 0, 0, '', 0); SELECT SCOPE_IDENTITY() AS SCOPE_ID_COLUMN", Utils.FrmNo, Utils.DnmNo), CommandType.Text, 60, i_Array2);
                int num3 = 1;
                foreach (clsInvoiceLine line in satirlar)
                {
                    int num4 = 0;
                    int num5 = 0;
                    foreach (DataRow row in MyConnect.Ornekle.ExecuteReader(Utils.ConnectionStringLogo, string.Format("SELECT FB.LOGICALREF, FL.LOGICALREF FROM LG_{0}_{1}_ORFICHE AS FB LEFT OUTER JOIN LG_{0}_{1}_ORFLINE AS FL ON FB.LOGICALREF = FL.ORDFICHEREF WHERE FB.FICHENO= '{2}' AND FL.STOCKREF = {3}", new object[] { Utils.FrmNo, Utils.DnmNo, line.OrderNumber, line.urunID }), CommandType.Text, 30, new KomutArgumanlari_[0]).Rows)
                    {
                        num4 = Convert.ToInt32(row[0]);
                        num5 = Convert.ToInt32(row[1]);
                    }
                    //clsWorkToBeDone.urunBirimCarpanlari carpanlari = clsWorkToBeDone.clsAdditionalMth.urunCarpanlari(line.urunID, line.birimID);
                    KomutArgumanlari_[] i_Array3 = new KomutArgumanlari_[0x12];
                    KomutArgumanlari_ i_15 = new KomutArgumanlari_
                    {
                        Parametre = line.urunID,
                        ParametreAdi = "@stokKodu"
                    };
                    i_Array3[0] = i_15;
                    KomutArgumanlari_ i_16 = new KomutArgumanlari_
                    {
                        Parametre = Convert.ToDateTime(date.ToShortDateString()),
                        ParametreAdi = "@tarih"
                    };
                    i_Array3[1] = i_16;
                    KomutArgumanlari_ i_17 = new KomutArgumanlari_
                    {
                        Parametre = num2,
                        ParametreAdi = "@irsaliyeID"
                    };
                    i_Array3[2] = i_17;
                    KomutArgumanlari_ i_18 = new KomutArgumanlari_
                    {
                        Parametre = num3,
                        ParametreAdi = "@siraNo"
                    };
                    i_Array3[3] = i_18;
                    KomutArgumanlari_ i_19 = new KomutArgumanlari_
                    {
                        Parametre = num,
                        ParametreAdi = "@faturaID"
                    };
                    i_Array3[4] = i_19;
                    KomutArgumanlari_ i_20 = new KomutArgumanlari_
                    {
                        Parametre = cariID,
                        ParametreAdi = "@cariID"
                    };
                    i_Array3[5] = i_20;
                    KomutArgumanlari_ i_21 = new KomutArgumanlari_
                    {
                        Parametre = num5,
                        ParametreAdi = "@satirX"
                    };
                    i_Array3[6] = i_21;
                    KomutArgumanlari_ i_22 = new KomutArgumanlari_
                    {
                        Parametre = num4,
                        ParametreAdi = "@baslikX"
                    };
                    i_Array3[7] = i_22;
                    KomutArgumanlari_ i_23 = new KomutArgumanlari_
                    {
                        Parametre = line.Quantity,
                        ParametreAdi = "@miktar"
                    };
                    i_Array3[8] = i_23;
                    KomutArgumanlari_ i_24 = new KomutArgumanlari_
                    {
                        Parametre = line.TlBirim,
                        ParametreAdi = "@birimTlF"
                    };
                    i_Array3[9] = i_24;
                    KomutArgumanlari_ i_25 = new KomutArgumanlari_
                    {
                        Parametre = line.TlToplam,
                        ParametreAdi = "@toplamTl"
                    };
                    i_Array3[10] = i_25;
                    KomutArgumanlari_ i_26 = new KomutArgumanlari_
                    {
                        Parametre = line.UnitPrice,
                        ParametreAdi = "@gbpBirimF"
                    };
                    i_Array3[11] = i_26;
                    KomutArgumanlari_ i_27 = new KomutArgumanlari_
                    {
                        Parametre = rate,
                        ParametreAdi = "@rate"
                    };
                    i_Array3[12] = i_27;
                    KomutArgumanlari_ i_28 = new KomutArgumanlari_
                    {
                        Parametre = line.OrderNumber,
                        ParametreAdi = "@SatirA"
                    };
                    i_Array3[13] = i_28;
                    KomutArgumanlari_ i_29 = new KomutArgumanlari_
                    {
                        Parametre = line.birimID,
                        ParametreAdi = "@birimID"
                    };
                    i_Array3[14] = i_29;
                    KomutArgumanlari_ i_30 = new KomutArgumanlari_
                    {
                        Parametre = line.birimsetID,
                        ParametreAdi = "@birimSetID"
                    };
                    i_Array3[15] = i_30;
                    KomutArgumanlari_ i_31 = new KomutArgumanlari_
                    {
                        //Parametre = carpanlari.UINFO1,
                        ParametreAdi = "@brm1"
                    };
                    i_Array3[0x10] = i_31;
                    KomutArgumanlari_ i_32 = new KomutArgumanlari_
                    {
                        //Parametre = carpanlari.UINFO2,
                        ParametreAdi = "@brm2"
                    };
                    i_Array3[0x11] = i_32;
                    int num6 = MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_STLINE (STOCKREF, LINETYPE, PREVLINEREF, PREVLINENO, DETLINE, TRCODE, DATE_, FTIME, GLOBTRANS, CALCTYPE, PRODORDERREF, SOURCETYPE, SOURCEINDEX, SOURCECOSTGRP, SOURCEWSREF, SOURCEPOLNREF, DESTTYPE, DESTINDEX, DESTCOSTGRP, DESTWSREF, DESTPOLNREF, FACTORYNR, IOCODE, STFICHEREF, STFICHELNNO, INVOICEREF, INVOICELNNO, CLIENTREF, ORDTRANSREF, ORDFICHEREF, CENTERREF, ACCOUNTREF, VATACCREF, VATCENTERREF, PRACCREF, PRCENTERREF, PRVATACCREF, PRVATCENREF, PROMREF, PAYDEFREF, SPECODE, DELVRYCODE, AMOUNT, PRICE, TOTAL, PRCURR, PRPRICE, TRCURR, TRRATE, REPORTRATE, DISTCOST, DISTDISC, DISTEXP, DISTPROM, DISCPER, LINEEXP, UOMREF, USREF, UINFO1, UINFO2, UINFO3, UINFO4, UINFO5, UINFO6, UINFO7, UINFO8, PLNAMOUNT, VATINC, VAT, VATAMNT, VATMATRAH, BILLEDITEM, BILLED, CPSTFLAG, RETCOSTTYPE, SOURCELINK, RETCOST, RETCOSTCURR, OUTCOST, OUTCOSTCURR, RETAMOUNT, FAREGREF, FAATTRIB, CANCELLED, LINENET, DISTADDEXP, FADACCREF, FADCENTERREF, FARACCREF, FARCENTERREF, DIFFPRICE, DIFFPRCOST, DECPRDIFF, LPRODSTAT, PRDEXPTOTAL, DIFFREPPRICE, DIFFPRCRCOST, SALESMANREF, FAPLACCREF, FAPLCENTERREF, OUTPUTIDCODE, DREF, COSTRATE, XPRICEUPD, XPRICE, XREPRATE, DISTCOEF, TRANSQCOK, SITEID, RECSTATUS, ORGLOGICREF, WFSTATUS, POLINEREF, PLNSTTRANSREF, NETDISCFLAG, NETDISCPERC, NETDISCAMNT, VATCALCDIFF, CONDITIONREF, DISTORDERREF, DISTORDLINEREF, CAMPAIGNREFS1, CAMPAIGNREFS2, CAMPAIGNREFS3, CAMPAIGNREFS4, CAMPAIGNREFS5, POINTCAMPREF, CAMPPOINT, PROMCLASITEMREF, CMPGLINEREF, PLNSTTRANSPERNR, PORDCLSPLNAMNT, VENDCOMM, PREVIOUSOUTCOST, COSTOFSALEACCREF, PURCHACCREF, COSTOFSALECNTREF, PURCHCENTREF, PREVOUTCOSTCURR, ABVATAMOUNT, ABVATSTATUS, PRRATE, ADDTAXRATE, ADDTAXCONVFACT, ADDTAXAMOUNT, ADDTAXPRCOST, ADDTAXRETCOST, ADDTAXRETCOSTCURR, GROSSUINFO1, GROSSUINFO2, ADDTAXPRCOSTCURR, ADDTAXACCREF, ADDTAXCENTERREF, ADDTAXAMNTISUPD, INFIDX, ADDTAXCOSACCREF, ADDTAXCOSCNTREF, PREVIOUSATAXPRCOST, PREVATAXPRCOSTCURR, PRDORDTOTCOEF, DEMPEGGEDAMNT, STDUNITCOST, STDRPUNITCOST, COSTDIFFACCREF, COSTDIFFCENREF, TEXTINC, ADDTAXDISCAMOUNT, ORGLOGOID, EXIMFICHENO, EXIMFCTYPE, TRANSEXPLINE, INSEXPLINE, EXIMWHFCREF, EXIMWHLNREF, EXIMFILEREF, EXIMPROCNR, EISRVDSTTYP, MAINSTLNREF, MADEOFSHRED, FROMORDWITHPAY, PROJECTREF, STATUS, DORESERVE, POINTCAMPREFS1, POINTCAMPREFS2, POINTCAMPREFS3, POINTCAMPREFS4, CAMPPOINTS1, CAMPPOINTS2, CAMPPOINTS3, CAMPPOINTS4, CMPGLINEREFS1, CMPGLINEREFS2, CMPGLINEREFS3, CMPGLINEREFS4, PRCLISTREF, PORDSYMOUTLN, MONTH_, YEAR_, EXADDTAXRATE, EXADDTAXCONVF, EXADDTAXAREF, EXADDTAXCREF, OTHRADDTAXAREF, OTHRADDTAXCREF, EXADDTAXAMNT, AFFECTCOLLATRL, ALTPROMFLAG, EIDISTFLNNR, EXIMTYPE, VARIANTREF, CANDEDUCT, OUTREMAMNT, OUTREMCOST, OUTREMCOSTCURR, REFLVATACCREF, REFLVATOTHACCREF, PARENTLNREF, AFFECTRISK, INEFFECTIVECOST, ADDTAXVATMATRAH, REFLACCREF, REFLOTHACCREF, CAMPPAYDEFREF, FAREGBINDDATE, RELTRANSLNREF, FROMTRANSFER, COSTDISTPRICE, COSTDISTREPPRICE, DIFFPRICEUFRS, DIFFREPPRICEUFRS, OUTCOSTUFRS, OUTCOSTCURRUFRS, DIFFPRCOSTUFRS, DIFFPRCRCOSTUFRS, RETCOSTUFRS, RETCOSTCURRUFRS, OUTREMCOSTUFRS, OUTREMCOSTCURRUFRS, INFIDXUFRS, ADJPRICEUFRS, ADJREPPRICEUFRS, ADJPRCOSTUFRS, ADJPRCRCOSTUFRS, COSTDISTPRICEUFRS, COSTDISTREPPRICEUFRS, PURCHACCREFUFRS, PURCHCENTREFUFRS, COSACCREFUFRS, COSCNTREFUFRS, PROUTCOSTUFRSDIFF, PROUTCOSTCRUFRSDIFF, UNDERDEDUCTLIMIT, GLOBALID, DEDUCTIONPART1, DEDUCTIONPART2, GUID, SPECODE2, OFFERREF, OFFTRANSREF, VATEXCEPTREASON, PLNDEFSERILOTNO, PLNUNRSRVAMOUNT, PORDCLSPLNUNRSRVAMNT, LPRODRSRVSTAT, FALINKTYPE, DEDUCTCODE, UPDTHISLINE, VATEXCEPTCODE) VALUES (@stokKodu, 0, 0, 0, 0, 1, @tarih, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, @irsaliyeID, @siraNo, @faturaID, @siraNo, @cariID, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', @miktar, @birimTlF, @toplamTl, 17, @gbpBirimF, 17, @rate, 1, 0, 0, 0, 0, 0, @SatirA, @birimID, @birimSetID, @brm1, @brm2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @toplamTl, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @toplamTl, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @rate, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, MONTH(GETDATE()), YEAR(GETDATE()), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', 0, 0, NEWID(), '', 0, 0, '', '', 0, 0, 0, 0, '', 0, ''); SELECT SCOPE_IDENTITY() AS SCOPE_ID_COLUMN", Utils.FrmNo, Utils.DnmNo), CommandType.Text, 60, i_Array3);
                    num3++;
                }
                if (cariID > 0)
                {
                    KomutArgumanlari_[] i_Array4 = new KomutArgumanlari_[7];
                    KomutArgumanlari_ i_33 = new KomutArgumanlari_
                    {
                        Parametre = cariID,
                        ParametreAdi = "@cariID"
                    };
                    i_Array4[0] = i_33;
                    KomutArgumanlari_ i_34 = new KomutArgumanlari_
                    {
                        Parametre = num,
                        ParametreAdi = "@FaturaID"
                    };
                    i_Array4[1] = i_34;
                    KomutArgumanlari_ i_35 = new KomutArgumanlari_
                    {
                        Parametre = Convert.ToDateTime(date.ToShortDateString()),
                        ParametreAdi = "@tarih"
                    };
                    i_Array4[2] = i_35;
                    KomutArgumanlari_ i_36 = new KomutArgumanlari_
                    {
                        Parametre = ficheNo,
                        ParametreAdi = "@faturaNo"
                    };
                    i_Array4[3] = i_36;
                    KomutArgumanlari_ i_37 = new KomutArgumanlari_
                    {
                        Parametre = rate,
                        ParametreAdi = "@rate"
                    };
                    i_Array4[4] = i_37;
                    KomutArgumanlari_ i_38 = new KomutArgumanlari_
                    {
                        //Parametre = satirlar.Sum(ficheNo.ToString()),
                        ParametreAdi = "@net"
                    };
                    i_Array4[5] = i_38;
                    KomutArgumanlari_ i_39 = new KomutArgumanlari_
                    {
                        //Parametre = satirlar.Sum<clsInvoiceLine>(cIME.b__1_5 ?? (cIME.b = new Func<clsInvoiceLine, double>(cIME.b, clsInvoiceLine))),
                        ParametreAdi = "@net1"
                    };
                    i_Array4[6] = i_39;
                    MyConnect.Ornekle.ExecuteScalar_Int(Utils.ConnectionStringLogo, string.Format("INSERT INTO LG_{0}_{1}_CLFLINE (CLIENTREF, CLACCREF, CLCENTERREF, CASHCENTERREF, CASHACCOUNTREF, VIRMANREF, SOURCEFREF, DATE_, DEPARTMENT, BRANCH, MODULENR, TRCODE, LINENR, SPECODE, CYPHCODE, TRANNO, DOCODE, LINEEXP, ACCOUNTED, SIGN, AMOUNT, TRCURR, TRRATE, TRNET, REPORTRATE, REPORTNET, EXTENREF, PAYDEFREF, ACCFICHEREF, PRINTCNT, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, CANCELLED, TRGFLAG, TRADINGGRP, LINEEXCTYP, ONLYONEPAYLINE, DISCFLAG, DISCRATE, VATRATE, CASHAMOUNT, DISCACCREF, DISCCENREF, VATRACCREF, VATRCENREF, PAYMENTREF, VATAMOUNT, SITEID, RECSTATUS, ORGLOGICREF, INFIDX, POSCOMMACCREF, POSCOMMCENREF, POINTCOMMACCREF, POINTCOMMCENREF, CHEQINFO, CREDITCNO, CLPRJREF, STATUS, EXIMFILEREF, EXIMPROCNR, MONTH_, YEAR_, FUNDSHARERAT, AFFECTCOLLATRL, GRPFIRMTRANS, REFLVATACCREF, REFLVATOTHACCREF, AFFECTRISK, BATCHNR, APPROVENR, BATCHNUM, APPROVENUM, EUVATSTATUS, ORGLOGOID, EXIMTYPE, EIDISTFLNNR, EISRVDSTTYP, EXIMDISTTYP, SALESMANREF, BANKACCREF, BNACCREF, BNCENTERREF, DEVIRPROCDATE, DOCDATE, INSTALREF, DEVIR, DEVIRMODULENR, FTIME, OFFERREF, RETCCFCREF, EMFLINEREF, FROMEXCHDIFF, CANDEDUCT, DEDUCTIONPART1, DEDUCTIONPART2, UNDERDEDUCTLIMIT, VATDEDUCTRATE, VATDEDUCTACCREF, VATDEDUCTOTHACCREF, VATDEDUCTCENREF, VATDEDUCTOTHCENREF, CANTCREDEDUCT, GUID, PAIDINCASH, BRUTAMOUNT, NETAMOUNT, BRUTAMOUNTTR, NETAMOUNTTR, BRUTAMOUNTREP, NETAMOUNTREP) VALUES (@cariID, 0, 0, 0, 0, 0, @FaturaID, @tarih, 0, 0, 4, 31, 0, 'RS', 'RBS', @faturaNo, '', '', 0, 1, @net, 17, @rate, @net1, 1, @net, 0, 0, 0, 0, 1, GETDATE(), DATEPART(hh, GETDATE()), DATEPART(MI, GETDATE()), DATEPART(S, GETDATE()), 0, NULL, 0, 0, 0, 0, 0, '', 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '', '', 0, 0, 0, 0, MONTH(GETDATE()), YEAR(GETDATE()), 0, 0, 0, 0, 0, 1, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, 0, 0, 0, 268838239, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NEWID(), 0, 0, 0, 0, 0, 0, 0)", Utils.FrmNo, Utils.DnmNo), CommandType.Text, 60, i_Array4);
                }
                MyConnect.Ornekle.ExecuteNonQuery(Utils.ConnectionStringLogo, string.Format("UPDATE RBS_FATURA_B SET LOGO = {0} WHERE ID = {1}", num, araID), CommandType.Text, 60, new KomutArgumanlari_[0]);
            }
        }

        public static List<clsInvoiceLine> faturaSatirlari(int ID, double KUR)
        {
            List<clsInvoiceLine> list = new List<clsInvoiceLine>();
            foreach (DataRow row in MyConnect.Ornekle.ExecuteReader(Utils.ConnectionStringLogo, "SELECT ORDERNUMBER,PRODUCTCODE,QTY,GBPTOPLAM,BRMID,BRMSETID,URUNID FROM RBS_FATURA_S WHERE BID = " + ID, CommandType.Text, 60, new KomutArgumanlari_[0]).Rows)
            {
                clsInvoiceLine item = new clsInvoiceLine
                {
                    OrderNumber = row[0].ToString(),
                    ProductCode = row[1].ToString(),
                    Quantity = row[2]._ToDoubleR(),
                    GBPTotal = row[3]._ToDoubleR(),
                    birimID = row[4]._ToIntegerR(),
                    birimsetID = row[5]._ToIntegerR(),
                    urunID = row[6]._ToIntegerR(),
                    GBPKur = KUR
                };
                list.Add(item);
            }
            return list;
        }

        private sealed class cIME
        {
            public static readonly clsInvoice.cIME b = new clsInvoice.cIME();
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_0;
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_1;
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_2;
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_3;
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_4;
            //public static Func<clsInvoice.clsInvoiceLine, double> b__1_5;

            internal double b__1_0(clsInvoice.clsInvoiceLine x)
            {
                return x.TlToplam;
            }

            internal double b__1_1(clsInvoice.clsInvoiceLine x)
            {
                return x.GBPTotal;
            }

            internal double b__1_2(clsInvoice.clsInvoiceLine x)
            {
                return x.TlToplam;
            }

            internal double b__1_3(clsInvoice.clsInvoiceLine x)
            {
                return x.GBPTotal;
            }

            internal double b__1_4(clsInvoice.clsInvoiceLine x)
            {
                return x.TlToplam;
            }

            internal double b__1_5(clsInvoice.clsInvoiceLine x)
            {
                return x.GBPTotal;
            }
        }

        public sealed class clsInvoiceLine
        {
            public int birimID { get; set; }

            public int birimsetID { get; set; }

            public string COO { get; set; }

            public double GBPKur { get; set; }

            public double GBPTotal { get; set; }

            public string Info { get; set; }

            public double Net
            {
                get
                {
                    return (this.TotalPrice - this.Tax);
                }
            }

            public string OrderNumber { get; set; }

            public string OrderNumber2 { get; set; }

            public string PaketNo { get; set; }

            public string ProductCode { get; set; }

            public double Quantity { get; set; }

            public string SalesUnit { get; set; }

            public int SATIR_REF { get; set; }

            public double Tax
            {
                get
                {
                    return ((this.TotalPrice * 18.0) / 100.0);
                }
            }

            public double TlBirim
            {
                get
                {
                    return (this.UnitPrice * this.GBPKur);
                }
            }

            public double TlToplam
            {
                get
                {
                    return (this.TlBirim * this.Quantity);
                }
            }

            public double TotalPrice { get; set; }

            public double UnitPrice
            {
                get
                {
                    return (this.GBPTotal / this.Quantity);
                }
            }

            public double UnitSpecialPrice { get; set; }

            public int urunID { get; set; }
        }

    }
}
