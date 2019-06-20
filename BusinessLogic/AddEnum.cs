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
            Success,
            NullObject,
            InvalidOrganization,
            UnknowFail,
            SQLFail,
            ExistingRecord
        }
    }
}
