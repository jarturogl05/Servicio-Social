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
    public class ControladorProyecto
    {

        /// <summary>  Comunica los datos obtenidos en la interfaz gráfica con el DAO de añadir proyecto</summary>
        /// <param name="nombreProyecto">nombre proyecto.</param>
        /// <param name="numAlumnos">number alumnos.</param>
        /// <param name="lugar">lugar.</param>
        /// <param name="horario">horario.</param>
        /// <param name="actividades"> actividades.</param>
        /// <param name="requisitos">requisitos.</param>
        /// <param name="responsable">responsable.</param>
        /// <param name="IdCoordinador">identifier coordinador.</param>
        /// <returns>El resultado de la operación</returns>
        public AddResult AddProyecto(string nombreProyecto, int numAlumnos, string lugar, string horario,
            string actividades, string requisitos, Object responsable, string IdCoordinador )
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            Coordinador coordinador = new Coordinador(int.Parse(IdCoordinador));
            Proyecto proyecto = new Proyecto(nombreProyecto, numAlumnos, "Disponible", horario, lugar, actividades, requisitos, coordinador, (Encargado)responsable);
            return proyectoDAO.AddProyecto(proyecto);
        }

        /// <summary>  Obtiene una lista de proyectos para la interfaz de usuario</summary>
        /// <returns>una lista de proyectos</returns>
        public List<Proyecto> ObtenerProyectos()
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            List<Proyecto> proyectos = proyectoDAO.GetProyectos();
            return proyectos;
        }
    }
}
