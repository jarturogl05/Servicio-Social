using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class ProyectoDAOTests
    {
        [TestMethod()]
        public void AddProyectoTestAñadir()
        {
            Coordinador coordinador = new Coordinador();
            coordinador.NombreCoordinador = "Arturo";
            Encargado encargado = new Encargado();
            encargado.NombreEncargado = "José";

            Proyecto proyecto = new Proyecto(01, "hola", 1, "espera", "matutino", "xalapa", "desarollo", "ninguno", coordinador, encargado);
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            Assert.AreEqual(AddEnum.AddResult.Success, proyectoDAO.AddProyecto(proyecto));
        }

        [TestMethod()]
        [ExpectedException(typeof(System.NullReferenceException))]

        public void AddProyectoTest1SinObjetos()
        {
            Proyecto proyecto = new Proyecto();
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            proyectoDAO.AddProyecto(proyecto);
        }

        [TestMethod()]
        public void GetProyectosTestObtener()
        {
            ProyectoDAO proyectoDAO = new ProyectoDAO();
            List<Proyecto> proyectos = proyectoDAO.GetProyectos();
            Assert.AreEqual(true, proyectos.Any());
        }
    }
}