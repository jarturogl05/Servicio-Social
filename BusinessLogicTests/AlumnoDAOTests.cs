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
    public class AlumnoDAOTests
    {
        [TestMethod()]
        public void AddAlumnoTest()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            Alumno alumno = new Alumno("S17012959", "2", "zS17012959@estudiantes.uv.mx", "4", "David Bárcenas Duran", "Licenciatura en Ingenieria de Software", "No asignado", "Visible");
            Assert.AreEqual(AddResult.Success, alumnoDAO.AddAlumno(alumno));
        }

        [TestMethod()]
        public void GetAlumnoTest()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            List<Alumno> alumnoList= alumnoDAO.GetAlumno();
            Assert.AreEqual(false, alumnoList.Any());
        }
    }
}