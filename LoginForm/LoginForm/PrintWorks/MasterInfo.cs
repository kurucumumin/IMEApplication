namespace PrintWorks
{
    using System;

    internal class MasterInfo
    {
        private int _blankLneForFooter;
        private string _condensed;
        private string _footerLocation;
        private int _formName;
        private bool _isTwoLineForDetails;
        private bool _isTwoLineForHedder;
        private int _lineCountAfterPrint;
        private int _lineCountBetweenTwo;
        private int _masterId;
        private int _pageSize1;
        private int _pageSizeOther;
        private string _pitch;

        public int BlankLneForFooter
        {
            get
            {
                return this._blankLneForFooter;
            }
            set
            {
                this._blankLneForFooter = value;
            }
        }

        public string Condensed
        {
            get
            {
                return this._condensed;
            }
            set
            {
                this._condensed = value;
            }
        }

        public string FooterLocation
        {
            get
            {
                return this._footerLocation;
            }
            set
            {
                this._footerLocation = value;
            }
        }

        public int FormName
        {
            get
            {
                return this._formName;
            }
            set
            {
                this._formName = value;
            }
        }

        public bool IsTwoLineForDetails
        {
            get
            {
                return this._isTwoLineForDetails;
            }
            set
            {
                this._isTwoLineForDetails = value;
            }
        }

        public bool IsTwoLineForHedder
        {
            get
            {
                return this._isTwoLineForHedder;
            }
            set
            {
                this._isTwoLineForHedder = value;
            }
        }

        public int LineCountAfterPrint
        {
            get
            {
                return this._lineCountAfterPrint;
            }
            set
            {
                this._lineCountAfterPrint = value;
            }
        }

        public int LineCountBetweenTwo
        {
            get
            {
                return this._lineCountBetweenTwo;
            }
            set
            {
                this._lineCountBetweenTwo = value;
            }
        }

        public int MasterId
        {
            get
            {
                return this._masterId;
            }
            set
            {
                this._masterId = value;
            }
        }

        public int PageSize1
        {
            get
            {
                return this._pageSize1;
            }
            set
            {
                this._pageSize1 = value;
            }
        }

        public int PageSizeOther
        {
            get
            {
                return this._pageSizeOther;
            }
            set
            {
                this._pageSizeOther = value;
            }
        }

        public string Pitch
        {
            get
            {
                return this._pitch;
            }
            set
            {
                this._pitch = value;
            }
        }
    }
}

