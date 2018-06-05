namespace PrintWorks
{
    using System;

    internal class FieldInfo
    {
        private int _fieldId;
        private string _fieldName;
        private int _formId;

        public int FieldId
        {
            get
            {
                return this._fieldId;
            }
            set
            {
                this._fieldId = value;
            }
        }

        public string FieldName
        {
            get
            {
                return this._fieldName;
            }
            set
            {
                this._fieldName = value;
            }
        }

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
    }
}

