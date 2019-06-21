using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;


namespace Controller
{
    /// <summary>Clase para comunicar la capa de UI con la de BusinessLogic</summary>
    public class ControladorSolicitud
    {

        /// <summary>Comunica la lista de proyectos y el alumno con el DAO add proyectos</summary>
        /// <param name="proyectos"> proyectos.</param>
        /// <param name="idalumno">idalumno.</param>
        /// <returns>Resultado de la operación</returns>
        public AddResult AñadirSolicitud(List<Proyecto> proyectos, string idalumno)
        {
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Alumno alumno = new Alumno(idalumno);
            DateTime dateTime = DateTime.Now;
            Solicitud solicitud = new Solicitud(dateTime.ToString(), "En Espera", proyectos, alumno );
            return solicitudDAO.AddSolicitud(solicitud);
        }

        /// <summary>verifica la existencia de una solicitud en la base de datos</summary>
        /// <param name="IdAlumno">  identifier alumno.</param>
        /// <returns>Falso o verdadero dependiendo el resultado del DAO</returns>
        public bool BuscarSolicitud(string IdAlumno)
        {
            Alumno alumno = new Alumno(IdAlumno);
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Solicitud solicitud = solicitudDAO.GetSolicitudByAlumno(alumno);
            if (solicitud.Alumno.Matricula != alumno.Matricula)
            {
                return true;
            }
            return false;
        }

    }
}
