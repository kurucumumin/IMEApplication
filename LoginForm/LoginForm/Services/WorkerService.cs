using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginForm.Services
{
    
    class WorkerService
    {
        IMEEntities IMEDB = new IMEEntities();

        public void AddNewWorker(Worker NewWorker)
        {
            try
            {
                IMEDB.Workers.Add(NewWorker);
                IMEDB.SaveChanges();

            }
            catch (Exception e)
            {

                MessageBox.Show(e.InnerException.Message);
            }

        }
        public List<Worker> GetWorkers()
        {

            return IMEDB.Workers.AsNoTracking().Where(w => w.isActive == "A").ToList();
        }
        public Worker GetWorkersbyID(int WorkerID)
        {

            return IMEDB.Workers.Where(w=>w.WorkerID==WorkerID).FirstOrDefault();
        }
        public bool WarnDuplicateRecord(Worker CheckWorker)
        {
            //Mail üzerinden Unique Kontrolü
            var isDuplidate = IMEDB.Workers.Any(w=>w.EMail==CheckWorker.EMail);
            //isDuplicate Dolu ise Kayıt Zaten Mevcut.
            if (isDuplidate==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdateWorker(Worker UpdatedWorker)
        {
            using (SqlConnection connection = new SqlConnection("data source=.;initial catalog=IME;integrated security=True;multipleactiveresultsets=True"))
            {
                string kayit = "Update dbo.Worker set LastName=@lname,FirstName=@fname,EMail=@mail,Phone=@tphone,isActive=@status where WorkerID=@UpdateID";
                connection.Open();
                SqlCommand komut = new SqlCommand(kayit, connection);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@lname", UpdatedWorker.LastName);
                komut.Parameters.AddWithValue("@fname", UpdatedWorker.FirstName);
                komut.Parameters.AddWithValue("@mail", UpdatedWorker.EMail);
                komut.Parameters.AddWithValue("@tphone", UpdatedWorker.Phone);
                komut.Parameters.AddWithValue("@status", UpdatedWorker.isActive);
                komut.Parameters.AddWithValue("@UpdateID", UpdatedWorker.WorkerID);
                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                connection.Close();
            }
        }
    }
}
