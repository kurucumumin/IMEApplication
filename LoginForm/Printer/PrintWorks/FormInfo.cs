namespace PrintWorks
{
    using System;

    internal class FormInfo
    {
        private int _formId;
        private string _formName;

        public int FormId
        {
            get
            {
                return this._formId;
            }
            set
            {
                this._formId = value;
            }
        }

        public string FormName
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
    }
}

