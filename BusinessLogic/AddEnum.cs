using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    /// <summary>Clase con una enumeracion para los posibles resultados de una operacion</summary>
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
