using BusinessLogic;
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
        public OperationResult AddOrganizacion(String RFC, String Nombre, String Direccion, String Sector, String Telefono, String Correo)
        {
            OperationResult operation = OperationResult.UnknowFail;
            Organizacion organizacion = new Organizacion();
            organizacion.CorreoOrganizacion = Correo;
            organizacion.CorreoOrganizacion = Direccion;
            organizacion.NombreOrganizacion = Nombre;
            organizacion.rfc = RFC;
            organizacion.Sector = Sector;
            organizacion.TelefonoOrganizacion = Telefono;
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            operation = (OperationResult)organizacionDAO.AddOrganizacion(organizacion);
            return operation;

        }
        public List<Organizacion> GetOrganizacion()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> list = organizacionDAO.GetOrganizacion();
            return list;
        }

        public Organizacion GetOrganizacionByRFC(String RFC)
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            return organizacionDAO.GetOrganizacionByRFC(RFC);
        }
        public OperationResult DeleteOrganizacion(String RFC)
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            return (OperationResult)organizacionDAO.DeleteOrganizacionByRFC(RFC);
        }
        //public OperationResult EditOrganizacion()
        //{

        //}
    }
}
