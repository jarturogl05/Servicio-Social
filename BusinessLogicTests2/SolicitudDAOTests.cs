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
    public class SolicitudDAOTests
    {
        [TestMethod()]
        public void AddSolicitudTestAñadir()
        {

            Proyecto proyecto1 = new Proyecto();
            proyecto1.NombreProyecto = "Web";
            Proyecto proyecto2 = new Proyecto();
            proyecto2.NombreProyecto = "Diseño";
            Proyecto proyecto3 = new Proyecto();
            proyecto3.NombreProyecto = "Programación";
            Alumno alumno = new Alumno();
            alumno.NombreAlumno = "Arturo pendragon";
            List<Proyecto> proyectos = new List<Proyecto>();
            proyectos.Add(proyecto1);
            proyectos.Add(proyecto2);
            proyectos.Add(proyecto3);


            Solicitud solicitud = new Solicitud("Mayo", "En espera", proyectos, alumno);
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Assert.AreEqual(AddEnum.AddResult.Success, solicitudDAO.AddSolicitud(solicitud));
        }

        [TestMethod()]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void AddSolicitudTest1NoProyectos()
        {
            Solicitud solicitud = new Solicitud();
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            solicitudDAO.AddSolicitud(solicitud);
        }
    }
}