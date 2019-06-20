using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;


namespace Controller
{
    public class ControladorSolicitud
    {

        public AddResult AñadirSolicitud(List<Proyecto> proyectos, string idalumno)
        {
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Alumno alumno = new Alumno(idalumno);
            DateTime dateTime = DateTime.Now;
            Solicitud solicitud = new Solicitud(dateTime.ToString(), "En Espera", proyectos, alumno );
            return solicitudDAO.AddSolicitud(solicitud);
        }

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
