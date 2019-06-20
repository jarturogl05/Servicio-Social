using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static BusinessLogic.AddEnum;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class CoordinadorDAOTests
    {
        [TestMethod()]
        public void AddCoordinadorTestAñadirRepetido()
        {
            string NombreCoordinador = "José arturo";
            string Carrera = "Tecnologías Computacionales";
            int NumeroPersonal = 10211;
            Coordinador coordinador = new Coordinador(NombreCoordinador, Carrera, NumeroPersonal);
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();

            Assert.AreEqual(AddResult.UnknowFail, coordinadorDAO.AddCoordinador(coordinador));
        }

        [TestMethod()]
        public void AddCoordinadorTestNombreLargo()
        {
            string NombreCoordinador = "José arturoooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";
            string Carrera = "Tecnologías Computacionales";
            int NumeroPersonal = 10223;
            Coordinador coordinador = new Coordinador(NombreCoordinador, Carrera, NumeroPersonal);
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
            Assert.AreEqual(AddResult.UnknowFail, coordinadorDAO.AddCoordinador(coordinador));

        }

    }
}