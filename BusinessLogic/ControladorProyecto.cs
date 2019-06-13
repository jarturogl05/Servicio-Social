using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ControladorProyecto
    {
        ProyectoDAO proyectoDAO = new ProyectoDAO();
        EncargadoDAO encargadoDAO = new EncargadoDAO();
        public AddResult AddProyecto(string nombreProyecto, int numAlumnos, string lugar, string horario,
            string actividades, string requisitos, string responsable )
        {
            Coordinador coordinador = new Coordinador("Juan");
            Encargado encargado = encargadoDAO.GetEncargadoByNombre(responsable);
            Proyecto proyecto = new Proyecto(nombreProyecto, numAlumnos, "Disponible", horario, lugar, actividades, requisitos, coordinador, encargado);
            return proyectoDAO.AddProyecto(proyecto);
        }

        public List<Proyecto> obtenerProyectos()
        {
            List<Proyecto> proyectos = proyectoDAO.GetProyectos();
            return proyectos;
        }
    }
}
