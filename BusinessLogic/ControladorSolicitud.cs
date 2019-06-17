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

        public AddResult AñadirSolicitud(List<Proyecto> proyectos)
        {
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Alumno alumno = new Alumno("s17012985");
            DateTime dateTime = DateTime.Now;
            Solicitud solicitud = new Solicitud(dateTime.ToString(), "En Espera", proyectos, alumno );
            return solicitudDAO.AddSolicitud(solicitud);
        }

    }
}
