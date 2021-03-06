﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Alumno alumno = new Alumno("S17012959", "1", "zS17012959@estudiantes.uv.mx", "5", "David Bárcenas Duran", "Ingeniería de Software", "No Asignado", "Visible");
            if (alumnoDAO.GetAlumnoByMatricula(alumno.Matricula) != null)
            {
                alumnoDAO.DeleteAlumnoByMatricula(alumno.Matricula);
            }
            Assert.AreEqual(AddResult.Success, alumnoDAO.AddAlumno(alumno));
        }

        [TestMethod()]
        public void AddAlumnoSQLExceptionTest()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            Alumno alumno = new Alumno("S17012959", "1", "zS17012959@estudiantes.uv.mx", "5", "David Bárcenas Duran", "Ingeniería de Software", "No Asignado", "Visible");
            Assert.AreEqual(AddResult.SQLFail, alumnoDAO.AddAlumno(alumno));
        }

        [TestMethod()]
        public void AddAlumnoTestNull()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            Alumno alumno = new Alumno();
            Assert.AreEqual(AddResult.NullObject, alumnoDAO.AddAlumno(alumno));
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void AddAlumnoTestEmpty()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            Alumno alumno = new Alumno("", "1", "zS17012959@estudiantes.uv.mx", "5", "David Bárcenas Duran", "Ingeniería de Software", "No Asignado", "Visible");
            alumnoDAO.AddAlumno(alumno);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void AddAlumnoTestWrongFormat()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            Alumno alumno = new Alumno("BADD990524I55", "1", "zS17012959@estudiantes.uv.mx", "5", "David Bárcenas Duran", "Ingeniería de Software", "No Asignado", "Visible");
            Assert.AreEqual(AddResult.SQLFail, alumnoDAO.AddAlumno(alumno));
        }

        [TestMethod()]
        public void GetAlumnoTest()
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            List<Alumno> alumnoList= alumnoDAO.GetAlumno();
            Assert.AreEqual(true, alumnoList.Any());
        }
    }
}