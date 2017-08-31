using LoginForm.DataSet;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.Services
{
    class AuthorizationService
    {
        IMEEntities IMEDB = new IMEEntities();
        public List<AuthorizationValue> GetAvailAuthorization(Worker Worker)
        {


            return IMEDB.AuthorizationValues.Where(a => !a.Workers.Any(w => w.WorkerID == Worker.WorkerID)).ToList();

        }
        public List<AuthorizationValue> GetUserAuthorization(Worker Worker)
        {

            return IMEDB.AuthorizationValues.Where(a => a.Workers.Any(w => w.WorkerID == Worker.WorkerID)).ToList();

        }
        public List<AuthorizationValue> Authorizations()
        {

            return IMEDB.AuthorizationValues.ToList();

        }
        public void AddNewAuthorization(AuthorizationValue NewAuthorization)
        {

            IMEDB.AuthorizationValues.Add(NewAuthorization);
            
            IMEDB.SaveChanges();
        }
        public void Add(int AutID, int WorkerID)
        {
            using (SqlConnection connection = new SqlConnection("data source=.;initial catalog=IME;integrated security=True;multipleactiveresultsets=True"))
            {
                String query = "INSERT INTO dbo.UserAuthorization (WorkerID,AuthorizationID) VALUES (@WorkerID,@AutID)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AutID", AutID);
                    command.Parameters.AddWithValue("@WorkerID", WorkerID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    // Check Error

                }
            }
        }
        public void Delete(int AutID, int WorkerID)
        {
            using (SqlConnection connection = new SqlConnection("data source=.;initial catalog=IME;integrated security=True;multipleactiveresultsets=True"))
            {
                String query = "DELETE FROM dbo.UserAuthorization WHERE WorkerID = @worker AND AuthorizationID = @authorization";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@authorization", AutID);
                    command.Parameters.AddWithValue("@worker", WorkerID);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
                    // Check Error

                }
            }
        }
    }
}
