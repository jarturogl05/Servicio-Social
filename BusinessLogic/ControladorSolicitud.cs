using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;


namespace BusinessLogic
{
    public class ControladorSolicitud
    {

        public AddResult AñadirSolicitud(List<Proyecto> proyectos, Alumno alumno)
        {
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            
            DateTime dateTime = DateTime.Now;
            Solicitud solicitud = new Solicitud(dateTime.ToString(), "En Espera", proyectos, alumno );
            return solicitudDAO.AddSolicitud(solicitud);
        }

        public bool BuscarSolicitud(Alumno alumno)
        {
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
