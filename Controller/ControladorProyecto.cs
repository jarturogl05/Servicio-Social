using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;
using BusinessLogic;

namespace Controller
{
    public class ControladorProyecto
    {

        public AddResult AddProyecto(string nombreProyecto, int numAlumnos, string lugar, string horario,
            string actividades, string requisitos, Object responsable, string IdCoordinador )
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            Coordinador coordinador = new Coordinador(int.Parse(IdCoordinador));
            Proyecto proyecto = new Proyecto(nombreProyecto, numAlumnos, "Disponible", horario, lugar, actividades, requisitos, coordinador, (Encargado)responsable);
            return proyectoDAO.AddProyecto(proyecto);
        }

        public List<Proyecto> ObtenerProyectos()
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            List<Proyecto> proyectos = proyectoDAO.GetProyectos();
            return proyectos;
        }
    }
}
