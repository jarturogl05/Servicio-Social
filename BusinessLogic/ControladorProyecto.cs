using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;

namespace BusinessLogic
{
    public class ControladorProyecto
    {
        ProyectoDAO proyectoDAO = new ProyectoDAO();
        EncargadoDAO encargadoDAO = new EncargadoDAO();

        public AddResult AddProyecto(string nombreProyecto, int numAlumnos, string lugar, string horario,
            string actividades, string requisitos, Object responsable, Coordinador coordinador )
        {
           
           
            Proyecto proyecto = new Proyecto(nombreProyecto, numAlumnos, "Disponible", horario, lugar, actividades, requisitos, coordinador, (Encargado)responsable);
            return proyectoDAO.AddProyecto(proyecto);
        }

        public List<Proyecto> ObtenerProyectos()
        {
            List<Proyecto> proyectos = proyectoDAO.GetProyectos();
            return proyectos;
        }
    }
}
