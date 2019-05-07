﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class CoordinadorDAOTests
    {


        [TestMethod()]
        public void AddCoordinadorTestAñadir()
        {
            string NombreCoordinador = "Jose arturo";
            string Carrera = "Ing soft";
            int NumeroPersonal = 01;
            Coordinador coordinador = new Coordinador(NombreCoordinador, Carrera, NumeroPersonal);
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();

            Assert.AreEqual(AddEnum.AddResult.Success, coordinadorDAO.AddCoordinador(coordinador));
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void AddCoordinadorTestSQLException()
        {   
            Coordinador coordinador = new Coordinador();
            CoordinadorDAO coordinadorDAO = new CoordinadorDAO();
            coordinadorDAO.AddCoordinador(coordinador);
        }
    }
}