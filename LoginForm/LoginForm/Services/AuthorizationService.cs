using LoginForm.DataSet;
using System;
using System.Collections.Generic;
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
    }
}
