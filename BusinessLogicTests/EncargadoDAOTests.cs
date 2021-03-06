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
    public class EncargadoDAOTests
    {


        [TestMethod()]
        public void AddEncargadoTestAñadir()
        {
            Organizacion organizacion = new Organizacion("IBM250101FM9");
            Encargado encargado = new Encargado("Juan escutia", "Jefe de diseño", "sd@uv.com", "8745896", organizacion);
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            Assert.AreEqual(AddResult.Success, encargadoDAO.AddEncargado(encargado));
        }

        [TestMethod()]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void AddEncargadoTestSinOrganización()
        {
            Encargado encargado = new Encargado();
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            encargadoDAO.AddEncargado(encargado);
        }

        [TestMethod()]
        public void GetEncargadoTestObtener()
        {
            EncargadoDAO encargadoDAO = new EncargadoDAO();
            List<Encargado> encargados = encargadoDAO.GetEncargado();
            Assert.AreEqual(true, encargados.Any());
        }

    }
}