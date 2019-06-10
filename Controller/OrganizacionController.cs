using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class OrganizacionController
    {
        public enum OperationResult
        {
            Success = 1,
            NullOrganization = 2,
            InvalidOrganization = 3,
            UnknowFail = 0,
            SQLFail = 4,
        }
        //public OperationResult AddOrganizacion()
        //{

        //}
        //public OperationResult GetOrganizacion()
        //{

        //}
        //public OperationResult EditOrganizacion()
        //{

        //}
    }
}
