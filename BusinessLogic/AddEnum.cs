using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AddEnum
    {
        public enum AddResult
        {
            Success = 1,
            NullOrganization = 2,
            InvalidOrganization = 3,
            UnknownFail = 0,
            SQLFail = 4,
        }
    }
}
