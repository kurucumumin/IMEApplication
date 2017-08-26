using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;
using System.Windows.Forms;

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
            
            return IMEDB.Workers.ToList();
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
            if (isDuplidate!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
