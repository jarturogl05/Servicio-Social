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
    public class ValidarCamposTests
    {
        [TestMethod()]
        public void ValidarMatriculaTest()
        {
            ValidarCampos validarCampos = new ValidarCampos();
            Assert.AreEqual(validarCampos.ValidarMatricula("S17012959"), ValidarCampos.ResultadosValidación.MatriculaVálida);
        }
    }
}