using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Controller
{
    /// <summary>Clase para comunicar la capa de UI con la de BusinessLogic</summary>
    public class ControladorOrganización
    {
        /// <summary>obtiene la lista de organizaciones para la interfaz gráfica</summary>
        /// <returns>una lista de organizaciones</returns>
        public List<Organizacion> ObtenerOrganizaciones()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> organizacions = organizacionDAO.GetOrganizacion();
            return organizacions;
        }

        /// <summary> Obtiene una organización con el id de un encargado para enviarlo a la interfaz de usuario</summary>
        /// <param name="IDEncargado">Id encargado</param>
        /// <returns>Una organización</returns>
        public String GetOrganizacionByEmpleado(string IDEncargado)
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = organizacionDAO.GetOrganizacionByEncargado(IDEncargado);
            return organizacion.NombreOrganizacion;
        }

    }
}
