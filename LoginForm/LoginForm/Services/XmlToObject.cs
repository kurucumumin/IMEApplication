using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class XmlToObject
    {
        public void XmlToSaleOrder()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml";
            DialogResult result1 = openFileDialog1.ShowDialog();
        }
    }
}
