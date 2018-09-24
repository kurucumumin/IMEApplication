﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class ImeSettings
    {
        #region For Developers
        public static Color DefaultGridSelectedRowColor = Color.FromArgb(90, 185, 194); 
        public static Color GridDeletedRowColor = Color.FromArgb(252, 97, 97); 
        public static Color GridSentToLogoRowColor = Color.FromArgb(159, 255, 154);
        public static Color DefaultGridRowColor = Color.Empty;
        public static Color GridPurchaseOrderCreatedRowColor = Color.FromArgb(114, 155, 185);

        public static string dbDataSource = "195.201.76.136";
        public static string dbPassword = "ime1453..";
        public static string dbUserID = "sa";
        public static string dbInitialCatalogLOGO = "LOGO";
        public static string dbInitialCatalogIME = "IME";
        public static string dbFrmNo = "001";
        public static string dbDnmNo = "01";
        #endregion

        #region For Management
        public static string ConnectionStringLogo = new System.Data.SqlClient.SqlConnectionStringBuilder { DataSource = dbDataSource, Password = dbPassword, UserID = dbUserID, InitialCatalog = dbInitialCatalogLOGO/*, IntegratedSecurity = true */}.ConnectionString;
        public static string ConnectionStringIME = new System.Data.SqlClient.SqlConnectionStringBuilder { DataSource = dbDataSource, Password = dbPassword, UserID = dbUserID, InitialCatalog = dbInitialCatalogIME/*, IntegratedSecurity = true */}.ConnectionString;
        public static string FrmNo = dbFrmNo;
        public static string DnmNo = dbDnmNo;
        #endregion
    }
}
