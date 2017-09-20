using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;

namespace LoginForm.Services
{
    class AddressService
    {
        public void AddNewAddressBook(int AddressType,int CustomerID,string AddressValue)
        {
            using (SqlConnection connection = new SqlConnection("data source=.;initial catalog=IME;integrated security=True;multipleactiveresultsets=True"))
            {
                String query = "INSERT INTO dbo.AddressPool (AddressValue,CustomerID,AddressTypeID) VALUES (@Addressvalue,@Customer,@TypeID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Addressvalue",AddressValue);
                    command.Parameters.AddWithValue("@Customer", CustomerID);
                    command.Parameters.AddWithValue("@TypeID", AddressType);
                    
               
                    int result = command.ExecuteNonQuery();
                    MessageBox.Show(result.ToString());
                    connection.Close();
                    // Check Error

                }
            }

        }

        //public List<AddressType> GetAddressType()
        //{
        //    IMEEntities AddressIME = new IMEEntities();

        //    return AddressIME.AddressTypes.ToList();

        //}
    }
}
