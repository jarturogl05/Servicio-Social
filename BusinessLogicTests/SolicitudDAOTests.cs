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
    public class SolicitudDAOTests
    {
        [TestMethod()]
        public void AddSolicitudTestAñadir()
        {

            Proyecto proyecto1 = new Proyecto(2);
            Proyecto proyecto2 = new Proyecto(3);
            Proyecto proyecto3 = new Proyecto(4);
            Alumno alumno = new Alumno("s17012912");
            List<Proyecto> proyectos = new List<Proyecto>
            {
                proyecto1,
                proyecto2,
                proyecto3
            };
            DateTime dateTime = DateTime.Now;


            Solicitud solicitud = new Solicitud(dateTime.ToString(), "En espera", proyectos, alumno);
            SolicitudDAO solicitudDAO = new SolicitudDAO();
            Assert.AreEqual(AddResult.Success, solicitudDAO.AddSolicitud(solicitud));
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