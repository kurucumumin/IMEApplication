using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm.DataSet;

namespace LoginForm.PurchaseOrder
{
    public partial class StockDevelopment : MyForm
    {
        #region Definitions
        IMEEntities IME = new IMEEntities();
        int stockcode;
        string itemcode;
        #endregion

        public StockDevelopment()
        {
            InitializeComponent();
        }
    }
}
