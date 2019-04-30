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
    public class CoordinadorDAOTests
    {
        [TestMethod()]
        public void AddCoordinadorTest()
        {
            string NombreCoordinador = "Jose arturo";
            string Carrera = "Ing soft";
            int NumeroPersonal = 01;
            Coordinador coordinador = new Coordinador(NombreCoordinador, Carrera, NumeroPersonal);
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();

            Assert.AreEqual(true, coordinadorDAO.AddCoordinador(coordinador));
        }
    }
}