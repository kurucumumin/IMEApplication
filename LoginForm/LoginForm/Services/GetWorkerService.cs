using LoginForm.DataSet;
using System.Collections.Generic;
using System.Linq;

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