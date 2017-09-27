using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginForm.DataSet;

namespace LoginForm
{
    class GetWorkerService
    {
        public List<Worker> GetWorker()
        {
            IMEEntities WorkerIME = new IMEEntities();
            return WorkerIME.Workers.ToList();
        }
    }
}