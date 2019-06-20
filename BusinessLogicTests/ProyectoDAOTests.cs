using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLogic.AddEnum;


namespace BusinessLogic.Tests
{
    [TestClass()]
    public class ProyectoDAOTests
    {
       
            [TestMethod()]
            public void AddProyectoTestAñadir()
            {
                Coordinador coordinador = new Coordinador(121231);
                Encargado encargado = new Encargado("10");
                Proyecto proyecto = new Proyecto("Desarrollo web", 1, "espera", "matutino", "xalapa", "desarollo", "ninguno", coordinador, encargado);
                ProyectoDAO proyectoDAO = new ProyectoDAO();
                Assert.AreEqual(AddResult.Success, proyectoDAO.AddProyecto(proyecto));
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