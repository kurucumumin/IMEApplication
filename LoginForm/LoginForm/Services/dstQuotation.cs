namespace ROMSIS_CRM.dtsRBS
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("dstQuotation"), HelpKeyword("vs.data.DataSet")]
    public class dstQuotation : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private dtFiyatlarDataTable tabledtFiyatlar;
        private dtQuotationDataTable tabledtQuotation;
        private UrunVarisSDataTable tableUrunVarisS;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public dstQuotation()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected dstQuotation(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["dtQuotation"] != null)
                    {
                        base.Tables.Add(new dtQuotationDataTable(dataSet.Tables["dtQuotation"]));
                    }
                    if (dataSet.Tables["dtFiyatlar"] != null)
                    {
                        base.Tables.Add(new dtFiyatlarDataTable(dataSet.Tables["dtFiyatlar"]));
                    }
                    if (dataSet.Tables["UrunVarisS"] != null)
                    {
                        base.Tables.Add(new UrunVarisSDataTable(dataSet.Tables["UrunVarisS"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override DataSet Clone()
        {
            dstQuotation quotation = (dstQuotation) base.Clone();
            quotation.InitVars();
            quotation.SchemaSerializationMode = this.SchemaSerializationMode;
            return quotation;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            dstQuotation quotation = new dstQuotation();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny {
                Namespace = quotation.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = quotation.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitClass()
        {
            base.DataSetName = "dstQuotation";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/dstQuotation.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tabledtQuotation = new dtQuotationDataTable();
            base.Tables.Add(this.tabledtQuotation);
            this.tabledtFiyatlar = new dtFiyatlarDataTable();
            base.Tables.Add(this.tabledtFiyatlar);
            this.tableUrunVarisS = new UrunVarisSDataTable();
            base.Tables.Add(this.tableUrunVarisS);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars(bool initTable)
        {
            this.tabledtQuotation = (dtQuotationDataTable) base.Tables["dtQuotation"];
            if (initTable && (this.tabledtQuotation != null))
            {
                this.tabledtQuotation.InitVars();
            }
            this.tabledtFiyatlar = (dtFiyatlarDataTable) base.Tables["dtFiyatlar"];
            if (initTable && (this.tabledtFiyatlar != null))
            {
                this.tabledtFiyatlar.InitVars();
            }
            this.tableUrunVarisS = (UrunVarisSDataTable) base.Tables["UrunVarisS"];
            if (initTable && (this.tableUrunVarisS != null))
            {
                this.tableUrunVarisS.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["dtQuotation"] != null)
                {
                    base.Tables.Add(new dtQuotationDataTable(dataSet.Tables["dtQuotation"]));
                }
                if (dataSet.Tables["dtFiyatlar"] != null)
                {
                    base.Tables.Add(new dtFiyatlarDataTable(dataSet.Tables["dtFiyatlar"]));
                }
                if (dataSet.Tables["UrunVarisS"] != null)
                {
                    base.Tables.Add(new UrunVarisSDataTable(dataSet.Tables["UrunVarisS"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializedtFiyatlar()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializedtQuotation()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeUrunVarisS()
        {
            return false;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public dtFiyatlarDataTable dtFiyatlar
        {
            get
            {
                return this.tabledtFiyatlar;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public dtQuotationDataTable dtQuotation
        {
            get
            {
                return this.tabledtQuotation;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UrunVarisSDataTable UrunVarisS
        {
            get
            {
                return this.tableUrunVarisS;
            }
        }

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class dtFiyatlarDataTable : TypedTableBase<dstQuotation.dtFiyatlarRow>
        {
            private DataColumn columnACTIVE;
            private DataColumn columnBEGDATE;
            private DataColumn columnBEGTIME;
            private DataColumn columnBRANCH;
            private DataColumn columnCAPIBLOCK_CREADEDDATE;
            private DataColumn columnCAPIBLOCK_CREATEDBY;
            private DataColumn columnCAPIBLOCK_CREATEDHOUR;
            private DataColumn columnCAPIBLOCK_CREATEDMIN;
            private DataColumn columnCAPIBLOCK_CREATEDSEC;
            private DataColumn columnCAPIBLOCK_MODIFIEDBY;
            private DataColumn columnCAPIBLOCK_MODIFIEDDATE;
            private DataColumn columnCAPIBLOCK_MODIFIEDHOUR;
            private DataColumn columnCAPIBLOCK_MODIFIEDMIN;
            private DataColumn columnCAPIBLOCK_MODIFIEDSEC;
            private DataColumn columnCARDREF;
            private DataColumn columnCLCYPHCODE;
            private DataColumn columnCLIENTCODE;
            private DataColumn columnCLSPECODE;
            private DataColumn columnCLSPECODE2;
            private DataColumn columnCLSPECODE3;
            private DataColumn columnCLSPECODE4;
            private DataColumn columnCLSPECODE5;
            private DataColumn columnCLTRADINGGRP;
            private DataColumn columnCODE;
            private DataColumn columnCONDITION;
            private DataColumn columnCOSTVAL;
            private DataColumn columnCURRENCY;
            private DataColumn columnCYPHCODE;
            private DataColumn columnDEFINITION_;
            private DataColumn columnENDDATE;
            private DataColumn columnENDTIME;
            private DataColumn columnEXTACCESSFLAGS;
            private DataColumn columnGENIUSPAYTYPE;
            private DataColumn columnGENIUSSHPNR;
            private DataColumn columnGLOBALID;
            private DataColumn columnGRPCODE;
            private DataColumn columnINCVAT;
            private DataColumn columnLEADTIME;
            private DataColumn columnMTRLTYPE;
            private DataColumn columnORDERNR;
            private DataColumn columnORGLOGICREF;
            private DataColumn columnORGLOGOID;
            private DataColumn columnPAYPLANREF;
            private DataColumn columnPRCALTERLMT1;
            private DataColumn columnPRCALTERLMT2;
            private DataColumn columnPRCALTERLMT3;
            private DataColumn columnPRCALTERTYP1;
            private DataColumn columnPRCALTERTYP2;
            private DataColumn columnPRCALTERTYP3;
            private DataColumn columnPRICE;
            private DataColumn columnPRIORITY;
            private DataColumn columnPTYPE;
            private DataColumn columnPURCHCONTREF;
            private DataColumn columnRECSTATUS;
            private DataColumn columnSHIPTYP;
            private DataColumn columnSITEID;
            private DataColumn columnSPECIALIZED;
            private DataColumn columnTRADINGGRP;
            private DataColumn columnUNITCONVERT;
            private DataColumn columnUOMREF;
            private DataColumn columnVARIANTCODE;
            private DataColumn columnWFSTATUS;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtFiyatlarRowChangeEventHandler dtFiyatlarRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtFiyatlarRowChangeEventHandler dtFiyatlarRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtFiyatlarRowChangeEventHandler dtFiyatlarRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtFiyatlarRowChangeEventHandler dtFiyatlarRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtFiyatlarDataTable()
            {
                base.TableName = "dtFiyatlar";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtFiyatlarDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected dtFiyatlarDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtFiyatlarRow(dstQuotation.dtFiyatlarRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtFiyatlarRow AdddtFiyatlarRow(int CARDREF, string CLIENTCODE, string CLSPECODE, int PAYPLANREF, double PRICE, int UOMREF, int INCVAT, int CURRENCY, int PRIORITY, int PTYPE, int MTRLTYPE, int LEADTIME, DateTime BEGDATE, DateTime ENDDATE, string CONDITION, string SHIPTYP, int SPECIALIZED, int CAPIBLOCK_CREATEDBY, DateTime CAPIBLOCK_CREADEDDATE, int CAPIBLOCK_CREATEDHOUR, int CAPIBLOCK_CREATEDMIN, int CAPIBLOCK_CREATEDSEC, int CAPIBLOCK_MODIFIEDBY, DateTime CAPIBLOCK_MODIFIEDDATE, int CAPIBLOCK_MODIFIEDHOUR, int CAPIBLOCK_MODIFIEDMIN, int CAPIBLOCK_MODIFIEDSEC, int SITEID, int RECSTATUS, int ORGLOGICREF, int WFSTATUS, int UNITCONVERT, int EXTACCESSFLAGS, string CYPHCODE, string ORGLOGOID, string TRADINGGRP, int BEGTIME, int ENDTIME, string DEFINITION_, string CODE, string GRPCODE, int ORDERNR, string GENIUSPAYTYPE, int GENIUSSHPNR, int PRCALTERTYP1, double PRCALTERLMT1, int PRCALTERTYP2, double PRCALTERLMT2, int PRCALTERTYP3, double PRCALTERLMT3, int ACTIVE, int PURCHCONTREF, int BRANCH, double COSTVAL, string CLTRADINGGRP, string CLCYPHCODE, string CLSPECODE2, string CLSPECODE3, string CLSPECODE4, string CLSPECODE5, string GLOBALID, string VARIANTCODE)
            {
                dstQuotation.dtFiyatlarRow row = (dstQuotation.dtFiyatlarRow) base.NewRow();
                object[] objArray = new object[] { 
                    CARDREF, CLIENTCODE, CLSPECODE, PAYPLANREF, PRICE, UOMREF, INCVAT, CURRENCY, PRIORITY, PTYPE, MTRLTYPE, LEADTIME, BEGDATE, ENDDATE, CONDITION, SHIPTYP,
                    SPECIALIZED, CAPIBLOCK_CREATEDBY, CAPIBLOCK_CREADEDDATE, CAPIBLOCK_CREATEDHOUR, CAPIBLOCK_CREATEDMIN, CAPIBLOCK_CREATEDSEC, CAPIBLOCK_MODIFIEDBY, CAPIBLOCK_MODIFIEDDATE, CAPIBLOCK_MODIFIEDHOUR, CAPIBLOCK_MODIFIEDMIN, CAPIBLOCK_MODIFIEDSEC, SITEID, RECSTATUS, ORGLOGICREF, WFSTATUS, UNITCONVERT,
                    EXTACCESSFLAGS, CYPHCODE, ORGLOGOID, TRADINGGRP, BEGTIME, ENDTIME, DEFINITION_, CODE, GRPCODE, ORDERNR, GENIUSPAYTYPE, GENIUSSHPNR, PRCALTERTYP1, PRCALTERLMT1, PRCALTERTYP2, PRCALTERLMT2,
                    PRCALTERTYP3, PRCALTERLMT3, ACTIVE, PURCHCONTREF, BRANCH, COSTVAL, CLTRADINGGRP, CLCYPHCODE, CLSPECODE2, CLSPECODE3, CLSPECODE4, CLSPECODE5, GLOBALID, VARIANTCODE
                };
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dstQuotation.dtFiyatlarDataTable table = (dstQuotation.dtFiyatlarDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dstQuotation.dtFiyatlarDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dstQuotation.dtFiyatlarRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dstQuotation quotation = new dstQuotation();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = quotation.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "dtFiyatlarDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = quotation.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnCARDREF = new DataColumn("CARDREF", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCARDREF);
                this.columnCLIENTCODE = new DataColumn("CLIENTCODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLIENTCODE);
                this.columnCLSPECODE = new DataColumn("CLSPECODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLSPECODE);
                this.columnPAYPLANREF = new DataColumn("PAYPLANREF", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPAYPLANREF);
                this.columnPRICE = new DataColumn("PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnPRICE);
                this.columnUOMREF = new DataColumn("UOMREF", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnUOMREF);
                this.columnINCVAT = new DataColumn("INCVAT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnINCVAT);
                this.columnCURRENCY = new DataColumn("CURRENCY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCURRENCY);
                this.columnPRIORITY = new DataColumn("PRIORITY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPRIORITY);
                this.columnPTYPE = new DataColumn("PTYPE", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPTYPE);
                this.columnMTRLTYPE = new DataColumn("MTRLTYPE", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnMTRLTYPE);
                this.columnLEADTIME = new DataColumn("LEADTIME", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnLEADTIME);
                this.columnBEGDATE = new DataColumn("BEGDATE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnBEGDATE);
                this.columnENDDATE = new DataColumn("ENDDATE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnENDDATE);
                this.columnCONDITION = new DataColumn("CONDITION", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCONDITION);
                this.columnSHIPTYP = new DataColumn("SHIPTYP", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSHIPTYP);
                this.columnSPECIALIZED = new DataColumn("SPECIALIZED", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSPECIALIZED);
                this.columnCAPIBLOCK_CREATEDBY = new DataColumn("CAPIBLOCK_CREATEDBY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_CREATEDBY);
                this.columnCAPIBLOCK_CREADEDDATE = new DataColumn("CAPIBLOCK_CREADEDDATE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_CREADEDDATE);
                this.columnCAPIBLOCK_CREATEDHOUR = new DataColumn("CAPIBLOCK_CREATEDHOUR", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_CREATEDHOUR);
                this.columnCAPIBLOCK_CREATEDMIN = new DataColumn("CAPIBLOCK_CREATEDMIN", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_CREATEDMIN);
                this.columnCAPIBLOCK_CREATEDSEC = new DataColumn("CAPIBLOCK_CREATEDSEC", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_CREATEDSEC);
                this.columnCAPIBLOCK_MODIFIEDBY = new DataColumn("CAPIBLOCK_MODIFIEDBY", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_MODIFIEDBY);
                this.columnCAPIBLOCK_MODIFIEDDATE = new DataColumn("CAPIBLOCK_MODIFIEDDATE", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_MODIFIEDDATE);
                this.columnCAPIBLOCK_MODIFIEDHOUR = new DataColumn("CAPIBLOCK_MODIFIEDHOUR", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_MODIFIEDHOUR);
                this.columnCAPIBLOCK_MODIFIEDMIN = new DataColumn("CAPIBLOCK_MODIFIEDMIN", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_MODIFIEDMIN);
                this.columnCAPIBLOCK_MODIFIEDSEC = new DataColumn("CAPIBLOCK_MODIFIEDSEC", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCAPIBLOCK_MODIFIEDSEC);
                this.columnSITEID = new DataColumn("SITEID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSITEID);
                this.columnRECSTATUS = new DataColumn("RECSTATUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnRECSTATUS);
                this.columnORGLOGICREF = new DataColumn("ORGLOGICREF", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnORGLOGICREF);
                this.columnWFSTATUS = new DataColumn("WFSTATUS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnWFSTATUS);
                this.columnUNITCONVERT = new DataColumn("UNITCONVERT", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnUNITCONVERT);
                this.columnEXTACCESSFLAGS = new DataColumn("EXTACCESSFLAGS", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnEXTACCESSFLAGS);
                this.columnCYPHCODE = new DataColumn("CYPHCODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCYPHCODE);
                this.columnORGLOGOID = new DataColumn("ORGLOGOID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnORGLOGOID);
                this.columnTRADINGGRP = new DataColumn("TRADINGGRP", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTRADINGGRP);
                this.columnBEGTIME = new DataColumn("BEGTIME", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBEGTIME);
                this.columnENDTIME = new DataColumn("ENDTIME", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnENDTIME);
                this.columnDEFINITION_ = new DataColumn("DEFINITION_", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDEFINITION_);
                this.columnCODE = new DataColumn("CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCODE);
                this.columnGRPCODE = new DataColumn("GRPCODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGRPCODE);
                this.columnORDERNR = new DataColumn("ORDERNR", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnORDERNR);
                this.columnGENIUSPAYTYPE = new DataColumn("GENIUSPAYTYPE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGENIUSPAYTYPE);
                this.columnGENIUSSHPNR = new DataColumn("GENIUSSHPNR", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnGENIUSSHPNR);
                this.columnPRCALTERTYP1 = new DataColumn("PRCALTERTYP1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERTYP1);
                this.columnPRCALTERLMT1 = new DataColumn("PRCALTERLMT1", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERLMT1);
                this.columnPRCALTERTYP2 = new DataColumn("PRCALTERTYP2", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERTYP2);
                this.columnPRCALTERLMT2 = new DataColumn("PRCALTERLMT2", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERLMT2);
                this.columnPRCALTERTYP3 = new DataColumn("PRCALTERTYP3", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERTYP3);
                this.columnPRCALTERLMT3 = new DataColumn("PRCALTERLMT3", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnPRCALTERLMT3);
                this.columnACTIVE = new DataColumn("ACTIVE", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnACTIVE);
                this.columnPURCHCONTREF = new DataColumn("PURCHCONTREF", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPURCHCONTREF);
                this.columnBRANCH = new DataColumn("BRANCH", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnBRANCH);
                this.columnCOSTVAL = new DataColumn("COSTVAL", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnCOSTVAL);
                this.columnCLTRADINGGRP = new DataColumn("CLTRADINGGRP", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLTRADINGGRP);
                this.columnCLCYPHCODE = new DataColumn("CLCYPHCODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLCYPHCODE);
                this.columnCLSPECODE2 = new DataColumn("CLSPECODE2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLSPECODE2);
                this.columnCLSPECODE3 = new DataColumn("CLSPECODE3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLSPECODE3);
                this.columnCLSPECODE4 = new DataColumn("CLSPECODE4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLSPECODE4);
                this.columnCLSPECODE5 = new DataColumn("CLSPECODE5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCLSPECODE5);
                this.columnGLOBALID = new DataColumn("GLOBALID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGLOBALID);
                this.columnVARIANTCODE = new DataColumn("VARIANTCODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVARIANTCODE);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnCARDREF = base.Columns["CARDREF"];
                this.columnCLIENTCODE = base.Columns["CLIENTCODE"];
                this.columnCLSPECODE = base.Columns["CLSPECODE"];
                this.columnPAYPLANREF = base.Columns["PAYPLANREF"];
                this.columnPRICE = base.Columns["PRICE"];
                this.columnUOMREF = base.Columns["UOMREF"];
                this.columnINCVAT = base.Columns["INCVAT"];
                this.columnCURRENCY = base.Columns["CURRENCY"];
                this.columnPRIORITY = base.Columns["PRIORITY"];
                this.columnPTYPE = base.Columns["PTYPE"];
                this.columnMTRLTYPE = base.Columns["MTRLTYPE"];
                this.columnLEADTIME = base.Columns["LEADTIME"];
                this.columnBEGDATE = base.Columns["BEGDATE"];
                this.columnENDDATE = base.Columns["ENDDATE"];
                this.columnCONDITION = base.Columns["CONDITION"];
                this.columnSHIPTYP = base.Columns["SHIPTYP"];
                this.columnSPECIALIZED = base.Columns["SPECIALIZED"];
                this.columnCAPIBLOCK_CREATEDBY = base.Columns["CAPIBLOCK_CREATEDBY"];
                this.columnCAPIBLOCK_CREADEDDATE = base.Columns["CAPIBLOCK_CREADEDDATE"];
                this.columnCAPIBLOCK_CREATEDHOUR = base.Columns["CAPIBLOCK_CREATEDHOUR"];
                this.columnCAPIBLOCK_CREATEDMIN = base.Columns["CAPIBLOCK_CREATEDMIN"];
                this.columnCAPIBLOCK_CREATEDSEC = base.Columns["CAPIBLOCK_CREATEDSEC"];
                this.columnCAPIBLOCK_MODIFIEDBY = base.Columns["CAPIBLOCK_MODIFIEDBY"];
                this.columnCAPIBLOCK_MODIFIEDDATE = base.Columns["CAPIBLOCK_MODIFIEDDATE"];
                this.columnCAPIBLOCK_MODIFIEDHOUR = base.Columns["CAPIBLOCK_MODIFIEDHOUR"];
                this.columnCAPIBLOCK_MODIFIEDMIN = base.Columns["CAPIBLOCK_MODIFIEDMIN"];
                this.columnCAPIBLOCK_MODIFIEDSEC = base.Columns["CAPIBLOCK_MODIFIEDSEC"];
                this.columnSITEID = base.Columns["SITEID"];
                this.columnRECSTATUS = base.Columns["RECSTATUS"];
                this.columnORGLOGICREF = base.Columns["ORGLOGICREF"];
                this.columnWFSTATUS = base.Columns["WFSTATUS"];
                this.columnUNITCONVERT = base.Columns["UNITCONVERT"];
                this.columnEXTACCESSFLAGS = base.Columns["EXTACCESSFLAGS"];
                this.columnCYPHCODE = base.Columns["CYPHCODE"];
                this.columnORGLOGOID = base.Columns["ORGLOGOID"];
                this.columnTRADINGGRP = base.Columns["TRADINGGRP"];
                this.columnBEGTIME = base.Columns["BEGTIME"];
                this.columnENDTIME = base.Columns["ENDTIME"];
                this.columnDEFINITION_ = base.Columns["DEFINITION_"];
                this.columnCODE = base.Columns["CODE"];
                this.columnGRPCODE = base.Columns["GRPCODE"];
                this.columnORDERNR = base.Columns["ORDERNR"];
                this.columnGENIUSPAYTYPE = base.Columns["GENIUSPAYTYPE"];
                this.columnGENIUSSHPNR = base.Columns["GENIUSSHPNR"];
                this.columnPRCALTERTYP1 = base.Columns["PRCALTERTYP1"];
                this.columnPRCALTERLMT1 = base.Columns["PRCALTERLMT1"];
                this.columnPRCALTERTYP2 = base.Columns["PRCALTERTYP2"];
                this.columnPRCALTERLMT2 = base.Columns["PRCALTERLMT2"];
                this.columnPRCALTERTYP3 = base.Columns["PRCALTERTYP3"];
                this.columnPRCALTERLMT3 = base.Columns["PRCALTERLMT3"];
                this.columnACTIVE = base.Columns["ACTIVE"];
                this.columnPURCHCONTREF = base.Columns["PURCHCONTREF"];
                this.columnBRANCH = base.Columns["BRANCH"];
                this.columnCOSTVAL = base.Columns["COSTVAL"];
                this.columnCLTRADINGGRP = base.Columns["CLTRADINGGRP"];
                this.columnCLCYPHCODE = base.Columns["CLCYPHCODE"];
                this.columnCLSPECODE2 = base.Columns["CLSPECODE2"];
                this.columnCLSPECODE3 = base.Columns["CLSPECODE3"];
                this.columnCLSPECODE4 = base.Columns["CLSPECODE4"];
                this.columnCLSPECODE5 = base.Columns["CLSPECODE5"];
                this.columnGLOBALID = base.Columns["GLOBALID"];
                this.columnVARIANTCODE = base.Columns["VARIANTCODE"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtFiyatlarRow NewdtFiyatlarRow()
            {
                return (dstQuotation.dtFiyatlarRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dstQuotation.dtFiyatlarRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtFiyatlarRowChanged != null)
                {
                    this.dtFiyatlarRowChanged(this, new dstQuotation.dtFiyatlarRowChangeEvent((dstQuotation.dtFiyatlarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtFiyatlarRowChanging != null)
                {
                    this.dtFiyatlarRowChanging(this, new dstQuotation.dtFiyatlarRowChangeEvent((dstQuotation.dtFiyatlarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtFiyatlarRowDeleted != null)
                {
                    this.dtFiyatlarRowDeleted(this, new dstQuotation.dtFiyatlarRowChangeEvent((dstQuotation.dtFiyatlarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtFiyatlarRowDeleting != null)
                {
                    this.dtFiyatlarRowDeleting(this, new dstQuotation.dtFiyatlarRowChangeEvent((dstQuotation.dtFiyatlarRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtFiyatlarRow(dstQuotation.dtFiyatlarRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ACTIVEColumn
            {
                get
                {
                    return this.columnACTIVE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BEGDATEColumn
            {
                get
                {
                    return this.columnBEGDATE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BEGTIMEColumn
            {
                get
                {
                    return this.columnBEGTIME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BRANCHColumn
            {
                get
                {
                    return this.columnBRANCH;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_CREADEDDATEColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_CREADEDDATE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_CREATEDBYColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_CREATEDBY;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_CREATEDHOURColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_CREATEDHOUR;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_CREATEDMINColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_CREATEDMIN;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_CREATEDSECColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_CREATEDSEC;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_MODIFIEDBYColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_MODIFIEDBY;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_MODIFIEDDATEColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_MODIFIEDDATE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_MODIFIEDHOURColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_MODIFIEDHOUR;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_MODIFIEDMINColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_MODIFIEDMIN;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CAPIBLOCK_MODIFIEDSECColumn
            {
                get
                {
                    return this.columnCAPIBLOCK_MODIFIEDSEC;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CARDREFColumn
            {
                get
                {
                    return this.columnCARDREF;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLCYPHCODEColumn
            {
                get
                {
                    return this.columnCLCYPHCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLIENTCODEColumn
            {
                get
                {
                    return this.columnCLIENTCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLSPECODE2Column
            {
                get
                {
                    return this.columnCLSPECODE2;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLSPECODE3Column
            {
                get
                {
                    return this.columnCLSPECODE3;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLSPECODE4Column
            {
                get
                {
                    return this.columnCLSPECODE4;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLSPECODE5Column
            {
                get
                {
                    return this.columnCLSPECODE5;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLSPECODEColumn
            {
                get
                {
                    return this.columnCLSPECODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CLTRADINGGRPColumn
            {
                get
                {
                    return this.columnCLTRADINGGRP;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CODEColumn
            {
                get
                {
                    return this.columnCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CONDITIONColumn
            {
                get
                {
                    return this.columnCONDITION;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn COSTVALColumn
            {
                get
                {
                    return this.columnCOSTVAL;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CURRENCYColumn
            {
                get
                {
                    return this.columnCURRENCY;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CYPHCODEColumn
            {
                get
                {
                    return this.columnCYPHCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DEFINITION_Column
            {
                get
                {
                    return this.columnDEFINITION_;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ENDDATEColumn
            {
                get
                {
                    return this.columnENDDATE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ENDTIMEColumn
            {
                get
                {
                    return this.columnENDTIME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn EXTACCESSFLAGSColumn
            {
                get
                {
                    return this.columnEXTACCESSFLAGS;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GENIUSPAYTYPEColumn
            {
                get
                {
                    return this.columnGENIUSPAYTYPE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GENIUSSHPNRColumn
            {
                get
                {
                    return this.columnGENIUSSHPNR;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GLOBALIDColumn
            {
                get
                {
                    return this.columnGLOBALID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn GRPCODEColumn
            {
                get
                {
                    return this.columnGRPCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn INCVATColumn
            {
                get
                {
                    return this.columnINCVAT;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtFiyatlarRow this[int index]
            {
                get
                {
                    return (dstQuotation.dtFiyatlarRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn LEADTIMEColumn
            {
                get
                {
                    return this.columnLEADTIME;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn MTRLTYPEColumn
            {
                get
                {
                    return this.columnMTRLTYPE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ORDERNRColumn
            {
                get
                {
                    return this.columnORDERNR;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ORGLOGICREFColumn
            {
                get
                {
                    return this.columnORGLOGICREF;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ORGLOGOIDColumn
            {
                get
                {
                    return this.columnORGLOGOID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PAYPLANREFColumn
            {
                get
                {
                    return this.columnPAYPLANREF;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERLMT1Column
            {
                get
                {
                    return this.columnPRCALTERLMT1;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERLMT2Column
            {
                get
                {
                    return this.columnPRCALTERLMT2;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERLMT3Column
            {
                get
                {
                    return this.columnPRCALTERLMT3;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERTYP1Column
            {
                get
                {
                    return this.columnPRCALTERTYP1;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERTYP2Column
            {
                get
                {
                    return this.columnPRCALTERTYP2;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRCALTERTYP3Column
            {
                get
                {
                    return this.columnPRCALTERTYP3;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRICEColumn
            {
                get
                {
                    return this.columnPRICE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PRIORITYColumn
            {
                get
                {
                    return this.columnPRIORITY;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PTYPEColumn
            {
                get
                {
                    return this.columnPTYPE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PURCHCONTREFColumn
            {
                get
                {
                    return this.columnPURCHCONTREF;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RECSTATUSColumn
            {
                get
                {
                    return this.columnRECSTATUS;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SHIPTYPColumn
            {
                get
                {
                    return this.columnSHIPTYP;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SITEIDColumn
            {
                get
                {
                    return this.columnSITEID;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SPECIALIZEDColumn
            {
                get
                {
                    return this.columnSPECIALIZED;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TRADINGGRPColumn
            {
                get
                {
                    return this.columnTRADINGGRP;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNITCONVERTColumn
            {
                get
                {
                    return this.columnUNITCONVERT;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UOMREFColumn
            {
                get
                {
                    return this.columnUOMREF;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VARIANTCODEColumn
            {
                get
                {
                    return this.columnVARIANTCODE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn WFSTATUSColumn
            {
                get
                {
                    return this.columnWFSTATUS;
                }
            }
        }

        public class dtFiyatlarRow : DataRow
        {
            private dstQuotation.dtFiyatlarDataTable tabledtFiyatlar;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtFiyatlarRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtFiyatlar = (dstQuotation.dtFiyatlarDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsACTIVENull()
            {
                return base.IsNull(this.tabledtFiyatlar.ACTIVEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBEGDATENull()
            {
                return base.IsNull(this.tabledtFiyatlar.BEGDATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBEGTIMENull()
            {
                return base.IsNull(this.tabledtFiyatlar.BEGTIMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBRANCHNull()
            {
                return base.IsNull(this.tabledtFiyatlar.BRANCHColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_CREADEDDATENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_CREADEDDATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_CREATEDBYNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_CREATEDBYColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_CREATEDHOURNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_CREATEDHOURColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_CREATEDMINNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_CREATEDMINColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_CREATEDSECNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_CREATEDSECColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_MODIFIEDBYNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDBYColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_MODIFIEDDATENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDDATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_MODIFIEDHOURNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDHOURColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_MODIFIEDMINNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDMINColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCAPIBLOCK_MODIFIEDSECNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDSECColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCARDREFNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CARDREFColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLCYPHCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CLCYPHCODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLIENTCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CLIENTCODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLSPECODE2Null()
            {
                return base.IsNull(this.tabledtFiyatlar.CLSPECODE2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLSPECODE3Null()
            {
                return base.IsNull(this.tabledtFiyatlar.CLSPECODE3Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLSPECODE4Null()
            {
                return base.IsNull(this.tabledtFiyatlar.CLSPECODE4Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLSPECODE5Null()
            {
                return base.IsNull(this.tabledtFiyatlar.CLSPECODE5Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLSPECODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CLSPECODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCLTRADINGGRPNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CLTRADINGGRPColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCONDITIONNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CONDITIONColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCOSTVALNull()
            {
                return base.IsNull(this.tabledtFiyatlar.COSTVALColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCURRENCYNull()
            {
                return base.IsNull(this.tabledtFiyatlar.CURRENCYColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCYPHCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.CYPHCODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDEFINITION_Null()
            {
                return base.IsNull(this.tabledtFiyatlar.DEFINITION_Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsENDDATENull()
            {
                return base.IsNull(this.tabledtFiyatlar.ENDDATEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsENDTIMENull()
            {
                return base.IsNull(this.tabledtFiyatlar.ENDTIMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsEXTACCESSFLAGSNull()
            {
                return base.IsNull(this.tabledtFiyatlar.EXTACCESSFLAGSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGENIUSPAYTYPENull()
            {
                return base.IsNull(this.tabledtFiyatlar.GENIUSPAYTYPEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGENIUSSHPNRNull()
            {
                return base.IsNull(this.tabledtFiyatlar.GENIUSSHPNRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGLOBALIDNull()
            {
                return base.IsNull(this.tabledtFiyatlar.GLOBALIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGRPCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.GRPCODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsINCVATNull()
            {
                return base.IsNull(this.tabledtFiyatlar.INCVATColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsLEADTIMENull()
            {
                return base.IsNull(this.tabledtFiyatlar.LEADTIMEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMTRLTYPENull()
            {
                return base.IsNull(this.tabledtFiyatlar.MTRLTYPEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsORDERNRNull()
            {
                return base.IsNull(this.tabledtFiyatlar.ORDERNRColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsORGLOGICREFNull()
            {
                return base.IsNull(this.tabledtFiyatlar.ORGLOGICREFColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsORGLOGOIDNull()
            {
                return base.IsNull(this.tabledtFiyatlar.ORGLOGOIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPAYPLANREFNull()
            {
                return base.IsNull(this.tabledtFiyatlar.PAYPLANREFColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERLMT1Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERLMT1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERLMT2Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERLMT2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERLMT3Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERLMT3Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERTYP1Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERTYP1Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERTYP2Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERTYP2Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRCALTERTYP3Null()
            {
                return base.IsNull(this.tabledtFiyatlar.PRCALTERTYP3Column);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRICENull()
            {
                return base.IsNull(this.tabledtFiyatlar.PRICEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPRIORITYNull()
            {
                return base.IsNull(this.tabledtFiyatlar.PRIORITYColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPTYPENull()
            {
                return base.IsNull(this.tabledtFiyatlar.PTYPEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPURCHCONTREFNull()
            {
                return base.IsNull(this.tabledtFiyatlar.PURCHCONTREFColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRECSTATUSNull()
            {
                return base.IsNull(this.tabledtFiyatlar.RECSTATUSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSHIPTYPNull()
            {
                return base.IsNull(this.tabledtFiyatlar.SHIPTYPColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSITEIDNull()
            {
                return base.IsNull(this.tabledtFiyatlar.SITEIDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSPECIALIZEDNull()
            {
                return base.IsNull(this.tabledtFiyatlar.SPECIALIZEDColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTRADINGGRPNull()
            {
                return base.IsNull(this.tabledtFiyatlar.TRADINGGRPColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNITCONVERTNull()
            {
                return base.IsNull(this.tabledtFiyatlar.UNITCONVERTColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUOMREFNull()
            {
                return base.IsNull(this.tabledtFiyatlar.UOMREFColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVARIANTCODENull()
            {
                return base.IsNull(this.tabledtFiyatlar.VARIANTCODEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsWFSTATUSNull()
            {
                return base.IsNull(this.tabledtFiyatlar.WFSTATUSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetACTIVENull()
            {
                base[this.tabledtFiyatlar.ACTIVEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBEGDATENull()
            {
                base[this.tabledtFiyatlar.BEGDATEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBEGTIMENull()
            {
                base[this.tabledtFiyatlar.BEGTIMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBRANCHNull()
            {
                base[this.tabledtFiyatlar.BRANCHColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_CREADEDDATENull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_CREADEDDATEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_CREATEDBYNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDBYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_CREATEDHOURNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDHOURColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_CREATEDMINNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDMINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_CREATEDSECNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDSECColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_MODIFIEDBYNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDBYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_MODIFIEDDATENull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDDATEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_MODIFIEDHOURNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDHOURColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_MODIFIEDMINNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDMINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCAPIBLOCK_MODIFIEDSECNull()
            {
                base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDSECColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCARDREFNull()
            {
                base[this.tabledtFiyatlar.CARDREFColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLCYPHCODENull()
            {
                base[this.tabledtFiyatlar.CLCYPHCODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLIENTCODENull()
            {
                base[this.tabledtFiyatlar.CLIENTCODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLSPECODE2Null()
            {
                base[this.tabledtFiyatlar.CLSPECODE2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLSPECODE3Null()
            {
                base[this.tabledtFiyatlar.CLSPECODE3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLSPECODE4Null()
            {
                base[this.tabledtFiyatlar.CLSPECODE4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLSPECODE5Null()
            {
                base[this.tabledtFiyatlar.CLSPECODE5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLSPECODENull()
            {
                base[this.tabledtFiyatlar.CLSPECODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCLTRADINGGRPNull()
            {
                base[this.tabledtFiyatlar.CLTRADINGGRPColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCODENull()
            {
                base[this.tabledtFiyatlar.CODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCONDITIONNull()
            {
                base[this.tabledtFiyatlar.CONDITIONColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCOSTVALNull()
            {
                base[this.tabledtFiyatlar.COSTVALColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCURRENCYNull()
            {
                base[this.tabledtFiyatlar.CURRENCYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCYPHCODENull()
            {
                base[this.tabledtFiyatlar.CYPHCODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDEFINITION_Null()
            {
                base[this.tabledtFiyatlar.DEFINITION_Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetENDDATENull()
            {
                base[this.tabledtFiyatlar.ENDDATEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetENDTIMENull()
            {
                base[this.tabledtFiyatlar.ENDTIMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetEXTACCESSFLAGSNull()
            {
                base[this.tabledtFiyatlar.EXTACCESSFLAGSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGENIUSPAYTYPENull()
            {
                base[this.tabledtFiyatlar.GENIUSPAYTYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGENIUSSHPNRNull()
            {
                base[this.tabledtFiyatlar.GENIUSSHPNRColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGLOBALIDNull()
            {
                base[this.tabledtFiyatlar.GLOBALIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGRPCODENull()
            {
                base[this.tabledtFiyatlar.GRPCODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetINCVATNull()
            {
                base[this.tabledtFiyatlar.INCVATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetLEADTIMENull()
            {
                base[this.tabledtFiyatlar.LEADTIMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMTRLTYPENull()
            {
                base[this.tabledtFiyatlar.MTRLTYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetORDERNRNull()
            {
                base[this.tabledtFiyatlar.ORDERNRColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetORGLOGICREFNull()
            {
                base[this.tabledtFiyatlar.ORGLOGICREFColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetORGLOGOIDNull()
            {
                base[this.tabledtFiyatlar.ORGLOGOIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPAYPLANREFNull()
            {
                base[this.tabledtFiyatlar.PAYPLANREFColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERLMT1Null()
            {
                base[this.tabledtFiyatlar.PRCALTERLMT1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERLMT2Null()
            {
                base[this.tabledtFiyatlar.PRCALTERLMT2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERLMT3Null()
            {
                base[this.tabledtFiyatlar.PRCALTERLMT3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERTYP1Null()
            {
                base[this.tabledtFiyatlar.PRCALTERTYP1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERTYP2Null()
            {
                base[this.tabledtFiyatlar.PRCALTERTYP2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRCALTERTYP3Null()
            {
                base[this.tabledtFiyatlar.PRCALTERTYP3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRICENull()
            {
                base[this.tabledtFiyatlar.PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPRIORITYNull()
            {
                base[this.tabledtFiyatlar.PRIORITYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPTYPENull()
            {
                base[this.tabledtFiyatlar.PTYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPURCHCONTREFNull()
            {
                base[this.tabledtFiyatlar.PURCHCONTREFColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRECSTATUSNull()
            {
                base[this.tabledtFiyatlar.RECSTATUSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSHIPTYPNull()
            {
                base[this.tabledtFiyatlar.SHIPTYPColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSITEIDNull()
            {
                base[this.tabledtFiyatlar.SITEIDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSPECIALIZEDNull()
            {
                base[this.tabledtFiyatlar.SPECIALIZEDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTRADINGGRPNull()
            {
                base[this.tabledtFiyatlar.TRADINGGRPColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNITCONVERTNull()
            {
                base[this.tabledtFiyatlar.UNITCONVERTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUOMREFNull()
            {
                base[this.tabledtFiyatlar.UOMREFColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVARIANTCODENull()
            {
                base[this.tabledtFiyatlar.VARIANTCODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetWFSTATUSNull()
            {
                base[this.tabledtFiyatlar.WFSTATUSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ACTIVE
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.ACTIVEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ACTIVE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.ACTIVEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime BEGDATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tabledtFiyatlar.BEGDATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BEGDATE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tabledtFiyatlar.BEGDATEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int BEGTIME
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.BEGTIMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BEGTIME' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.BEGTIMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int BRANCH
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.BRANCHColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BRANCH' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.BRANCHColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime CAPIBLOCK_CREADEDDATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tabledtFiyatlar.CAPIBLOCK_CREADEDDATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_CREADEDDATE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_CREADEDDATEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_CREATEDBY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDBYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_CREATEDBY' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDBYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_CREATEDHOUR
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDHOURColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_CREATEDHOUR' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDHOURColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_CREATEDMIN
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDMINColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_CREATEDMIN' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDMINColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_CREATEDSEC
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDSECColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_CREATEDSEC' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_CREATEDSECColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_MODIFIEDBY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDBYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_MODIFIEDBY' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDBYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime CAPIBLOCK_MODIFIEDDATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDDATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_MODIFIEDDATE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDDATEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_MODIFIEDHOUR
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDHOURColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_MODIFIEDHOUR' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDHOURColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_MODIFIEDMIN
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDMINColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_MODIFIEDMIN' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDMINColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CAPIBLOCK_MODIFIEDSEC
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDSECColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CAPIBLOCK_MODIFIEDSEC' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CAPIBLOCK_MODIFIEDSECColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CARDREF
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CARDREFColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CARDREF' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CARDREFColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLCYPHCODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLCYPHCODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLCYPHCODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLCYPHCODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLIENTCODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLIENTCODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLIENTCODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLIENTCODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLSPECODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLSPECODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLSPECODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLSPECODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLSPECODE2
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLSPECODE2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLSPECODE2' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLSPECODE2Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLSPECODE3
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLSPECODE3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLSPECODE3' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLSPECODE3Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLSPECODE4
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLSPECODE4Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLSPECODE4' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLSPECODE4Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLSPECODE5
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLSPECODE5Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLSPECODE5' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLSPECODE5Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CLTRADINGGRP
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CLTRADINGGRPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CLTRADINGGRP' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CLTRADINGGRPColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CONDITION
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CONDITIONColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CONDITION' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CONDITIONColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double COSTVAL
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtFiyatlar.COSTVALColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'COSTVAL' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.COSTVALColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CURRENCY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.CURRENCYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CURRENCY' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.CURRENCYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CYPHCODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.CYPHCODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'CYPHCODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.CYPHCODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string DEFINITION_
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.DEFINITION_Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'DEFINITION_' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.DEFINITION_Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime ENDDATE
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime) base[this.tabledtFiyatlar.ENDDATEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ENDDATE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return time;
                }
                set
                {
                    base[this.tabledtFiyatlar.ENDDATEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ENDTIME
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.ENDTIMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ENDTIME' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.ENDTIMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int EXTACCESSFLAGS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.EXTACCESSFLAGSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'EXTACCESSFLAGS' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.EXTACCESSFLAGSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GENIUSPAYTYPE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.GENIUSPAYTYPEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GENIUSPAYTYPE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.GENIUSPAYTYPEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int GENIUSSHPNR
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.GENIUSSHPNRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GENIUSSHPNR' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.GENIUSSHPNRColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GLOBALID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.GLOBALIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GLOBALID' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.GLOBALIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string GRPCODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.GRPCODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'GRPCODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.GRPCODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int INCVAT
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.INCVATColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'INCVAT' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.INCVATColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int LEADTIME
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.LEADTIMEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'LEADTIME' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.LEADTIMEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int MTRLTYPE
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.MTRLTYPEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'MTRLTYPE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.MTRLTYPEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ORDERNR
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.ORDERNRColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ORDERNR' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.ORDERNRColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ORGLOGICREF
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.ORGLOGICREFColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ORGLOGICREF' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.ORGLOGICREFColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ORGLOGOID
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.ORGLOGOIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ORGLOGOID' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.ORGLOGOIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PAYPLANREF
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PAYPLANREFColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PAYPLANREF' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PAYPLANREFColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double PRCALTERLMT1
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtFiyatlar.PRCALTERLMT1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERLMT1' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERLMT1Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double PRCALTERLMT2
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtFiyatlar.PRCALTERLMT2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERLMT2' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERLMT2Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double PRCALTERLMT3
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtFiyatlar.PRCALTERLMT3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERLMT3' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERLMT3Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PRCALTERTYP1
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PRCALTERTYP1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERTYP1' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERTYP1Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PRCALTERTYP2
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PRCALTERTYP2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERTYP2' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERTYP2Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PRCALTERTYP3
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PRCALTERTYP3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRCALTERTYP3' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRCALTERTYP3Column] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double PRICE
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtFiyatlar.PRICEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRICE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PRIORITY
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PRIORITYColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PRIORITY' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PRIORITYColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PTYPE
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PTYPEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PTYPE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PTYPEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PURCHCONTREF
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.PURCHCONTREFColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PURCHCONTREF' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.PURCHCONTREFColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int RECSTATUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.RECSTATUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RECSTATUS' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.RECSTATUSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SHIPTYP
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.SHIPTYPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SHIPTYP' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.SHIPTYPColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SITEID
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.SITEIDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SITEID' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.SITEIDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SPECIALIZED
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.SPECIALIZEDColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SPECIALIZED' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.SPECIALIZEDColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TRADINGGRP
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.TRADINGGRPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'TRADINGGRP' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.TRADINGGRPColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int UNITCONVERT
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.UNITCONVERTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UNITCONVERT' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.UNITCONVERTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int UOMREF
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.UOMREFColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UOMREF' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.UOMREFColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VARIANTCODE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtFiyatlar.VARIANTCODEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'VARIANTCODE' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtFiyatlar.VARIANTCODEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int WFSTATUS
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtFiyatlar.WFSTATUSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'WFSTATUS' in table 'dtFiyatlar' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtFiyatlar.WFSTATUSColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtFiyatlarRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dstQuotation.dtFiyatlarRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtFiyatlarRowChangeEvent(dstQuotation.dtFiyatlarRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtFiyatlarRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtFiyatlarRowChangeEventHandler(object sender, dstQuotation.dtFiyatlarRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class dtQuotationDataTable : TypedTableBase<dstQuotation.dtQuotationRow>
        {
            private DataColumn columnBirimAdetFiyati;
            private DataColumn columnBirimPaketFiyati;
            private DataColumn columnIE;
            private DataColumn columnIND_PRC;
            private DataColumn columnIND_TPL;
            private DataColumn columnINDHESAP;
            private DataColumn columnINDORAN;
            private DataColumn columnKDVSIZT;
            private DataColumn columnMusteriStokKodu;
            private DataColumn columnNo;
            private DataColumn columnPaketSayisi;
            private DataColumn columnPakettekiUrunMiktari;
            private DataColumn columnRsCodu;
            private DataColumn columnSatirAgirligi;
            private DataColumn columnSINGS;
            private DataColumn columnTeslimatIsGunu;
            private DataColumn columnToplamFiyat;
            private DataColumn columnToplamUrunMiktari;
            private DataColumn columnUnit;
            private DataColumn columnUreticiAdi;
            private DataColumn columnUreticiKodu;
            private DataColumn columnUrunAciklamasi;
            private DataColumn columnVAT;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtQuotationRowChangeEventHandler dtQuotationRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtQuotationRowChangeEventHandler dtQuotationRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtQuotationRowChangeEventHandler dtQuotationRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.dtQuotationRowChangeEventHandler dtQuotationRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtQuotationDataTable()
            {
                base.TableName = "dtQuotation";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtQuotationDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected dtQuotationDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtQuotationRow(dstQuotation.dtQuotationRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtQuotationRow AdddtQuotationRow(int No, string RsCodu, string UrunAciklamasi, string MusteriStokKodu, decimal SatirAgirligi, string UreticiKodu, string UreticiAdi, int PakettekiUrunMiktari, int PaketSayisi, int ToplamUrunMiktari, decimal BirimPaketFiyati, decimal BirimAdetFiyati, decimal ToplamFiyat, string TeslimatIsGunu, string SINGS, string Unit, double VAT, double KDVSIZT, string IE, double INDORAN, double INDHESAP, double IND_PRC, double IND_TPL)
            {
                dstQuotation.dtQuotationRow row = (dstQuotation.dtQuotationRow) base.NewRow();
                object[] objArray = new object[] { 
                    No, RsCodu, UrunAciklamasi, MusteriStokKodu, SatirAgirligi, UreticiKodu, UreticiAdi, PakettekiUrunMiktari, PaketSayisi, ToplamUrunMiktari, BirimPaketFiyati, BirimAdetFiyati, ToplamFiyat, TeslimatIsGunu, SINGS, Unit,
                    VAT, KDVSIZT, IE, INDORAN, INDHESAP, IND_PRC, IND_TPL
                };
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dstQuotation.dtQuotationDataTable table = (dstQuotation.dtQuotationDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dstQuotation.dtQuotationDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dstQuotation.dtQuotationRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dstQuotation quotation = new dstQuotation();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = quotation.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "dtQuotationDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = quotation.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnNo = new DataColumn("No", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnNo);
                this.columnRsCodu = new DataColumn("RsCodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRsCodu);
                this.columnUrunAciklamasi = new DataColumn("UrunAciklamasi", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUrunAciklamasi);
                this.columnMusteriStokKodu = new DataColumn("MusteriStokKodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMusteriStokKodu);
                this.columnSatirAgirligi = new DataColumn("SatirAgirligi", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnSatirAgirligi);
                this.columnUreticiKodu = new DataColumn("UreticiKodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUreticiKodu);
                this.columnUreticiAdi = new DataColumn("UreticiAdi", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUreticiAdi);
                this.columnPakettekiUrunMiktari = new DataColumn("PakettekiUrunMiktari", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPakettekiUrunMiktari);
                this.columnPaketSayisi = new DataColumn("PaketSayisi", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnPaketSayisi);
                this.columnToplamUrunMiktari = new DataColumn("ToplamUrunMiktari", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnToplamUrunMiktari);
                this.columnBirimPaketFiyati = new DataColumn("BirimPaketFiyati", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnBirimPaketFiyati);
                this.columnBirimAdetFiyati = new DataColumn("BirimAdetFiyati", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnBirimAdetFiyati);
                this.columnToplamFiyat = new DataColumn("ToplamFiyat", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnToplamFiyat);
                this.columnTeslimatIsGunu = new DataColumn("TeslimatIsGunu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTeslimatIsGunu);
                this.columnSINGS = new DataColumn("SINGS", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSINGS);
                this.columnUnit = new DataColumn("Unit", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUnit);
                this.columnVAT = new DataColumn("VAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnVAT);
                this.columnKDVSIZT = new DataColumn("KDVSIZT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnKDVSIZT);
                this.columnIE = new DataColumn("IE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnIE);
                this.columnINDORAN = new DataColumn("INDORAN", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnINDORAN);
                this.columnINDHESAP = new DataColumn("INDHESAP", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnINDHESAP);
                this.columnIND_PRC = new DataColumn("IND_PRC", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnIND_PRC);
                this.columnIND_TPL = new DataColumn("IND_TPL", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnIND_TPL);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnNo = base.Columns["No"];
                this.columnRsCodu = base.Columns["RsCodu"];
                this.columnUrunAciklamasi = base.Columns["UrunAciklamasi"];
                this.columnMusteriStokKodu = base.Columns["MusteriStokKodu"];
                this.columnSatirAgirligi = base.Columns["SatirAgirligi"];
                this.columnUreticiKodu = base.Columns["UreticiKodu"];
                this.columnUreticiAdi = base.Columns["UreticiAdi"];
                this.columnPakettekiUrunMiktari = base.Columns["PakettekiUrunMiktari"];
                this.columnPaketSayisi = base.Columns["PaketSayisi"];
                this.columnToplamUrunMiktari = base.Columns["ToplamUrunMiktari"];
                this.columnBirimPaketFiyati = base.Columns["BirimPaketFiyati"];
                this.columnBirimAdetFiyati = base.Columns["BirimAdetFiyati"];
                this.columnToplamFiyat = base.Columns["ToplamFiyat"];
                this.columnTeslimatIsGunu = base.Columns["TeslimatIsGunu"];
                this.columnSINGS = base.Columns["SINGS"];
                this.columnUnit = base.Columns["Unit"];
                this.columnVAT = base.Columns["VAT"];
                this.columnKDVSIZT = base.Columns["KDVSIZT"];
                this.columnIE = base.Columns["IE"];
                this.columnINDORAN = base.Columns["INDORAN"];
                this.columnINDHESAP = base.Columns["INDHESAP"];
                this.columnIND_PRC = base.Columns["IND_PRC"];
                this.columnIND_TPL = base.Columns["IND_TPL"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtQuotationRow NewdtQuotationRow()
            {
                return (dstQuotation.dtQuotationRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dstQuotation.dtQuotationRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtQuotationRowChanged != null)
                {
                    this.dtQuotationRowChanged(this, new dstQuotation.dtQuotationRowChangeEvent((dstQuotation.dtQuotationRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtQuotationRowChanging != null)
                {
                    this.dtQuotationRowChanging(this, new dstQuotation.dtQuotationRowChangeEvent((dstQuotation.dtQuotationRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtQuotationRowDeleted != null)
                {
                    this.dtQuotationRowDeleted(this, new dstQuotation.dtQuotationRowChangeEvent((dstQuotation.dtQuotationRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtQuotationRowDeleting != null)
                {
                    this.dtQuotationRowDeleting(this, new dstQuotation.dtQuotationRowChangeEvent((dstQuotation.dtQuotationRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtQuotationRow(dstQuotation.dtQuotationRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BirimAdetFiyatiColumn
            {
                get
                {
                    return this.columnBirimAdetFiyati;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BirimPaketFiyatiColumn
            {
                get
                {
                    return this.columnBirimPaketFiyati;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn IEColumn
            {
                get
                {
                    return this.columnIE;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn IND_PRCColumn
            {
                get
                {
                    return this.columnIND_PRC;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn IND_TPLColumn
            {
                get
                {
                    return this.columnIND_TPL;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn INDHESAPColumn
            {
                get
                {
                    return this.columnINDHESAP;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn INDORANColumn
            {
                get
                {
                    return this.columnINDORAN;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtQuotationRow this[int index]
            {
                get
                {
                    return (dstQuotation.dtQuotationRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn KDVSIZTColumn
            {
                get
                {
                    return this.columnKDVSIZT;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn MusteriStokKoduColumn
            {
                get
                {
                    return this.columnMusteriStokKodu;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn NoColumn
            {
                get
                {
                    return this.columnNo;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PaketSayisiColumn
            {
                get
                {
                    return this.columnPaketSayisi;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PakettekiUrunMiktariColumn
            {
                get
                {
                    return this.columnPakettekiUrunMiktari;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RsCoduColumn
            {
                get
                {
                    return this.columnRsCodu;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SatirAgirligiColumn
            {
                get
                {
                    return this.columnSatirAgirligi;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SINGSColumn
            {
                get
                {
                    return this.columnSINGS;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TeslimatIsGunuColumn
            {
                get
                {
                    return this.columnTeslimatIsGunu;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ToplamFiyatColumn
            {
                get
                {
                    return this.columnToplamFiyat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ToplamUrunMiktariColumn
            {
                get
                {
                    return this.columnToplamUrunMiktari;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UnitColumn
            {
                get
                {
                    return this.columnUnit;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UreticiAdiColumn
            {
                get
                {
                    return this.columnUreticiAdi;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UreticiKoduColumn
            {
                get
                {
                    return this.columnUreticiKodu;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UrunAciklamasiColumn
            {
                get
                {
                    return this.columnUrunAciklamasi;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VATColumn
            {
                get
                {
                    return this.columnVAT;
                }
            }
        }

        public class dtQuotationRow : DataRow
        {
            private dstQuotation.dtQuotationDataTable tabledtQuotation;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtQuotationRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtQuotation = (dstQuotation.dtQuotationDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBirimAdetFiyatiNull()
            {
                return base.IsNull(this.tabledtQuotation.BirimAdetFiyatiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBirimPaketFiyatiNull()
            {
                return base.IsNull(this.tabledtQuotation.BirimPaketFiyatiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsIENull()
            {
                return base.IsNull(this.tabledtQuotation.IEColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsIND_PRCNull()
            {
                return base.IsNull(this.tabledtQuotation.IND_PRCColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsIND_TPLNull()
            {
                return base.IsNull(this.tabledtQuotation.IND_TPLColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsINDHESAPNull()
            {
                return base.IsNull(this.tabledtQuotation.INDHESAPColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsINDORANNull()
            {
                return base.IsNull(this.tabledtQuotation.INDORANColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsKDVSIZTNull()
            {
                return base.IsNull(this.tabledtQuotation.KDVSIZTColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsMusteriStokKoduNull()
            {
                return base.IsNull(this.tabledtQuotation.MusteriStokKoduColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNoNull()
            {
                return base.IsNull(this.tabledtQuotation.NoColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPaketSayisiNull()
            {
                return base.IsNull(this.tabledtQuotation.PaketSayisiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPakettekiUrunMiktariNull()
            {
                return base.IsNull(this.tabledtQuotation.PakettekiUrunMiktariColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRsCoduNull()
            {
                return base.IsNull(this.tabledtQuotation.RsCoduColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSatirAgirligiNull()
            {
                return base.IsNull(this.tabledtQuotation.SatirAgirligiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSINGSNull()
            {
                return base.IsNull(this.tabledtQuotation.SINGSColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTeslimatIsGunuNull()
            {
                return base.IsNull(this.tabledtQuotation.TeslimatIsGunuColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsToplamFiyatNull()
            {
                return base.IsNull(this.tabledtQuotation.ToplamFiyatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsToplamUrunMiktariNull()
            {
                return base.IsNull(this.tabledtQuotation.ToplamUrunMiktariColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUnitNull()
            {
                return base.IsNull(this.tabledtQuotation.UnitColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUreticiAdiNull()
            {
                return base.IsNull(this.tabledtQuotation.UreticiAdiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUreticiKoduNull()
            {
                return base.IsNull(this.tabledtQuotation.UreticiKoduColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUrunAciklamasiNull()
            {
                return base.IsNull(this.tabledtQuotation.UrunAciklamasiColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVATNull()
            {
                return base.IsNull(this.tabledtQuotation.VATColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBirimAdetFiyatiNull()
            {
                base[this.tabledtQuotation.BirimAdetFiyatiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBirimPaketFiyatiNull()
            {
                base[this.tabledtQuotation.BirimPaketFiyatiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetIENull()
            {
                base[this.tabledtQuotation.IEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetIND_PRCNull()
            {
                base[this.tabledtQuotation.IND_PRCColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetIND_TPLNull()
            {
                base[this.tabledtQuotation.IND_TPLColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetINDHESAPNull()
            {
                base[this.tabledtQuotation.INDHESAPColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetINDORANNull()
            {
                base[this.tabledtQuotation.INDORANColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetKDVSIZTNull()
            {
                base[this.tabledtQuotation.KDVSIZTColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetMusteriStokKoduNull()
            {
                base[this.tabledtQuotation.MusteriStokKoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNoNull()
            {
                base[this.tabledtQuotation.NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPaketSayisiNull()
            {
                base[this.tabledtQuotation.PaketSayisiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPakettekiUrunMiktariNull()
            {
                base[this.tabledtQuotation.PakettekiUrunMiktariColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRsCoduNull()
            {
                base[this.tabledtQuotation.RsCoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSatirAgirligiNull()
            {
                base[this.tabledtQuotation.SatirAgirligiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSINGSNull()
            {
                base[this.tabledtQuotation.SINGSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTeslimatIsGunuNull()
            {
                base[this.tabledtQuotation.TeslimatIsGunuColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetToplamFiyatNull()
            {
                base[this.tabledtQuotation.ToplamFiyatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetToplamUrunMiktariNull()
            {
                base[this.tabledtQuotation.ToplamUrunMiktariColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUnitNull()
            {
                base[this.tabledtQuotation.UnitColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUreticiAdiNull()
            {
                base[this.tabledtQuotation.UreticiAdiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUreticiKoduNull()
            {
                base[this.tabledtQuotation.UreticiKoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUrunAciklamasiNull()
            {
                base[this.tabledtQuotation.UrunAciklamasiColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVATNull()
            {
                base[this.tabledtQuotation.VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal BirimAdetFiyati
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tabledtQuotation.BirimAdetFiyatiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BirimAdetFiyati' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.BirimAdetFiyatiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal BirimPaketFiyati
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tabledtQuotation.BirimPaketFiyatiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BirimPaketFiyati' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.BirimPaketFiyatiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string IE
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.IEColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IE' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.IEColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double IND_PRC
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.IND_PRCColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IND_PRC' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.IND_PRCColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double IND_TPL
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.IND_TPLColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'IND_TPL' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.IND_TPLColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double INDHESAP
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.INDHESAPColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'INDHESAP' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.INDHESAPColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double INDORAN
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.INDORANColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'INDORAN' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.INDORANColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double KDVSIZT
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.KDVSIZTColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'KDVSIZT' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.KDVSIZTColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string MusteriStokKodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.MusteriStokKoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'MusteriStokKodu' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.MusteriStokKoduColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int No
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtQuotation.NoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'No' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.NoColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PaketSayisi
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtQuotation.PaketSayisiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PaketSayisi' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.PaketSayisiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int PakettekiUrunMiktari
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtQuotation.PakettekiUrunMiktariColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'PakettekiUrunMiktari' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.PakettekiUrunMiktariColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string RsCodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.RsCoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RsCodu' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.RsCoduColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal SatirAgirligi
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tabledtQuotation.SatirAgirligiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SatirAgirligi' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.SatirAgirligiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SINGS
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.SINGSColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SINGS' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.SINGSColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TeslimatIsGunu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.TeslimatIsGunuColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'TeslimatIsGunu' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.TeslimatIsGunuColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal ToplamFiyat
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal) base[this.tabledtQuotation.ToplamFiyatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ToplamFiyat' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.ToplamFiyatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ToplamUrunMiktari
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tabledtQuotation.ToplamUrunMiktariColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ToplamUrunMiktari' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.ToplamUrunMiktariColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Unit
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.UnitColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Unit' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.UnitColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string UreticiAdi
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.UreticiAdiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UreticiAdi' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.UreticiAdiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string UreticiKodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.UreticiKoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UreticiKodu' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.UreticiKoduColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string UrunAciklamasi
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tabledtQuotation.UrunAciklamasiColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'UrunAciklamasi' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tabledtQuotation.UrunAciklamasiColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double VAT
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tabledtQuotation.VATColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'VAT' in table 'dtQuotation' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tabledtQuotation.VATColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtQuotationRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dstQuotation.dtQuotationRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtQuotationRowChangeEvent(dstQuotation.dtQuotationRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.dtQuotationRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtQuotationRowChangeEventHandler(object sender, dstQuotation.dtQuotationRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class UrunVarisSDataTable : TypedTableBase<dstQuotation.UrunVarisSRow>
        {
            private DataColumn columnAciklama;
            private DataColumn columnAdet;
            private DataColumn columnBirim;
            private DataColumn columnBirimFiyat;
            private DataColumn columnRsKodu;
            private DataColumn columnSatirNo;
            private DataColumn columnSing;
            private DataColumn columnToplam;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.UrunVarisSRowChangeEventHandler UrunVarisSRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.UrunVarisSRowChangeEventHandler UrunVarisSRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.UrunVarisSRowChangeEventHandler UrunVarisSRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event dstQuotation.UrunVarisSRowChangeEventHandler UrunVarisSRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public UrunVarisSDataTable()
            {
                base.TableName = "UrunVarisS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal UrunVarisSDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected UrunVarisSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddUrunVarisSRow(dstQuotation.UrunVarisSRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.UrunVarisSRow AddUrunVarisSRow(int SatirNo, string RsKodu, int Adet, double BirimFiyat, double Toplam, string Sing, string Aciklama, string Birim)
            {
                dstQuotation.UrunVarisSRow row = (dstQuotation.UrunVarisSRow) base.NewRow();
                object[] objArray = new object[] { SatirNo, RsKodu, Adet, BirimFiyat, Toplam, Sing, Aciklama, Birim };
                row.ItemArray = objArray;
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                dstQuotation.UrunVarisSDataTable table = (dstQuotation.UrunVarisSDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new dstQuotation.UrunVarisSDataTable();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(dstQuotation.UrunVarisSRow);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                dstQuotation quotation = new dstQuotation();
                XmlSchemaAny item = new XmlSchemaAny {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute {
                    Name = "namespace",
                    FixedValue = quotation.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute {
                    Name = "tableTypeName",
                    FixedValue = "UrunVarisSDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = quotation.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while ((stream.Position != stream.Length) && (stream.ReadByte() == stream2.ReadByte()))
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnSatirNo = new DataColumn("SatirNo", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSatirNo);
                this.columnRsKodu = new DataColumn("RsKodu", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRsKodu);
                this.columnAdet = new DataColumn("Adet", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnAdet);
                this.columnBirimFiyat = new DataColumn("BirimFiyat", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnBirimFiyat);
                this.columnToplam = new DataColumn("Toplam", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnToplam);
                this.columnSing = new DataColumn("Sing", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSing);
                this.columnAciklama = new DataColumn("Aciklama", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAciklama);
                this.columnBirim = new DataColumn("Birim", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBirim);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSatirNo = base.Columns["SatirNo"];
                this.columnRsKodu = base.Columns["RsKodu"];
                this.columnAdet = base.Columns["Adet"];
                this.columnBirimFiyat = base.Columns["BirimFiyat"];
                this.columnToplam = base.Columns["Toplam"];
                this.columnSing = base.Columns["Sing"];
                this.columnAciklama = base.Columns["Aciklama"];
                this.columnBirim = base.Columns["Birim"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new dstQuotation.UrunVarisSRow(builder);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.UrunVarisSRow NewUrunVarisSRow()
            {
                return (dstQuotation.UrunVarisSRow) base.NewRow();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.UrunVarisSRowChanged != null)
                {
                    this.UrunVarisSRowChanged(this, new dstQuotation.UrunVarisSRowChangeEvent((dstQuotation.UrunVarisSRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.UrunVarisSRowChanging != null)
                {
                    this.UrunVarisSRowChanging(this, new dstQuotation.UrunVarisSRowChangeEvent((dstQuotation.UrunVarisSRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.UrunVarisSRowDeleted != null)
                {
                    this.UrunVarisSRowDeleted(this, new dstQuotation.UrunVarisSRowChangeEvent((dstQuotation.UrunVarisSRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.UrunVarisSRowDeleting != null)
                {
                    this.UrunVarisSRowDeleting(this, new dstQuotation.UrunVarisSRowChangeEvent((dstQuotation.UrunVarisSRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveUrunVarisSRow(dstQuotation.UrunVarisSRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AciklamaColumn
            {
                get
                {
                    return this.columnAciklama;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn AdetColumn
            {
                get
                {
                    return this.columnAdet;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BirimColumn
            {
                get
                {
                    return this.columnBirim;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BirimFiyatColumn
            {
                get
                {
                    return this.columnBirimFiyat;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.UrunVarisSRow this[int index]
            {
                get
                {
                    return (dstQuotation.UrunVarisSRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RsKoduColumn
            {
                get
                {
                    return this.columnRsKodu;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SatirNoColumn
            {
                get
                {
                    return this.columnSatirNo;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SingColumn
            {
                get
                {
                    return this.columnSing;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ToplamColumn
            {
                get
                {
                    return this.columnToplam;
                }
            }
        }

        public class UrunVarisSRow : DataRow
        {
            private dstQuotation.UrunVarisSDataTable tableUrunVarisS;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal UrunVarisSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableUrunVarisS = (dstQuotation.UrunVarisSDataTable) base.Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAciklamaNull()
            {
                return base.IsNull(this.tableUrunVarisS.AciklamaColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAdetNull()
            {
                return base.IsNull(this.tableUrunVarisS.AdetColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBirimFiyatNull()
            {
                return base.IsNull(this.tableUrunVarisS.BirimFiyatColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBirimNull()
            {
                return base.IsNull(this.tableUrunVarisS.BirimColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRsKoduNull()
            {
                return base.IsNull(this.tableUrunVarisS.RsKoduColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSatirNoNull()
            {
                return base.IsNull(this.tableUrunVarisS.SatirNoColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSingNull()
            {
                return base.IsNull(this.tableUrunVarisS.SingColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsToplamNull()
            {
                return base.IsNull(this.tableUrunVarisS.ToplamColumn);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAciklamaNull()
            {
                base[this.tableUrunVarisS.AciklamaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAdetNull()
            {
                base[this.tableUrunVarisS.AdetColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBirimFiyatNull()
            {
                base[this.tableUrunVarisS.BirimFiyatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBirimNull()
            {
                base[this.tableUrunVarisS.BirimColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRsKoduNull()
            {
                base[this.tableUrunVarisS.RsKoduColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSatirNoNull()
            {
                base[this.tableUrunVarisS.SatirNoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSingNull()
            {
                base[this.tableUrunVarisS.SingColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetToplamNull()
            {
                base[this.tableUrunVarisS.ToplamColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Aciklama
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUrunVarisS.AciklamaColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Aciklama' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUrunVarisS.AciklamaColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Adet
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableUrunVarisS.AdetColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Adet' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUrunVarisS.AdetColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Birim
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUrunVarisS.BirimColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Birim' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUrunVarisS.BirimColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double BirimFiyat
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableUrunVarisS.BirimFiyatColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'BirimFiyat' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUrunVarisS.BirimFiyatColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string RsKodu
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUrunVarisS.RsKoduColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'RsKodu' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUrunVarisS.RsKoduColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SatirNo
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableUrunVarisS.SatirNoColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'SatirNo' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUrunVarisS.SatirNoColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sing
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableUrunVarisS.SingColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Sing' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableUrunVarisS.SingColumn] = value;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Toplam
            {
                get
                {
                    double num;
                    try
                    {
                        num = (double) base[this.tableUrunVarisS.ToplamColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Toplam' in table 'UrunVarisS' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableUrunVarisS.ToplamColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class UrunVarisSRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private dstQuotation.UrunVarisSRow eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public UrunVarisSRowChangeEvent(dstQuotation.UrunVarisSRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dstQuotation.UrunVarisSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void UrunVarisSRowChangeEventHandler(object sender, dstQuotation.UrunVarisSRowChangeEvent e);
    }
}

