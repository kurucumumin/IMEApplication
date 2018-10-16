using ImeLogoLibrary;
using LoginForm.MyClasses;
using LoginForm.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Management
{
    public partial class FormCurrencyValue : Form
    {
        LogoSQL logosql = new LogoSQL();
        private readonly string server = @"159.69.213.172";
        private readonly string logodatabase = "LOGO";
        private readonly string sqluser = "sa";
        private readonly string sqlpassword = "IME1453";

        static public string AddSuccessful = "Added successfully";
        static public string DeleteSuccessful = "Deleted successfully";

        string hata = "Error";
        DataTable currencyList = new DataTable();
        LogoLibrary logoLibrary = new LogoLibrary();
        public FormCurrencyValue()
        {
            InitializeComponent();

            dgCurrency.RowsDefaultCellStyle.SelectionBackColor = ImeSettings.DefaultGridSelectedRowColor;

            typeof(DataGridView).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty, null,
            dgCurrency, new object[] { true });
        }

        private void FormCurrencyValue_Load(object sender, EventArgs e)
        {

            currencyList = logoLibrary.getCurrency(hata, logosql.LogoSqlConnect(server, logodatabase, sqluser, sqlpassword));
            dgCurrency.DataSource = currencyList;
        }
    }
}
