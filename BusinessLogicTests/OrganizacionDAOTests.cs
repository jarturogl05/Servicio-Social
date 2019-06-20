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
    public class OrganizacionDAOTests
    {
        [TestMethod()]
        public void AddOrganizacionAddTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion("BADD990524I55", "David", "Facultad de Economia", "2288455625", "Educativo", "davisbd100@gmail.com");
            if (organizacionDAO.GetOrganizacionByRFC(organizacion.rfc) != null)
            {
                organizacionDAO.DeleteOrganizacionByRFC(organizacion.rfc);
            }
            Assert.AreEqual(AddResult.Success, organizacionDAO.AddOrganizacion(organizacion));
        }

        [TestMethod()]
        public void AddOrganizacionSQLExceptionTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion("BADD990524I55", "David", "Facultad de Economia", "2288455625", "Educativo", "davisbd100@gmail.com");
            Assert.AreEqual(organizacionDAO.AddOrganizacion(organizacion), AddResult.SQLFail);
        }

        [TestMethod()]
        public void AddOrganizacionTestNull()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion();
            Assert.AreEqual(organizacionDAO.AddOrganizacion(organizacion), AddResult.NullObject);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void AddOrganizacionTestEmpty()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion("", "David", "Facultad de Economia", "2288455625", "Educativo", "davisbd100@gmail.com");
            organizacionDAO.AddOrganizacion(organizacion);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void AddOrganizacionTestWrongFormat()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion("S17012959", "David", "Facultad de Economia", "2288455625", "Educativo", "davisbd100@gmail.com");
            organizacionDAO.AddOrganizacion(organizacion);
        }

        [TestMethod()]
        public void GetOrganizacionTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> organizacionList = organizacionDAO.GetOrganizacion();
            Assert.AreEqual(true, organizacionList.Any());
        }


        [TestMethod()]
        public void GetOrganizacionByNameTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion("BADD990524I55", "David", "Facultad de Economia", "2288455625", "Educativo", "davisbd100@gmail.com");
            Assert.AreEqual(organizacion.Sector, organizacionDAO.GetOrganizacionByName("David").Sector);
        }

        [TestMethod()]
        public void GetOrganizacionByNameDontFoundTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            Organizacion organizacion = new Organizacion();
            Assert.AreEqual(null, organizacionDAO.GetOrganizacionByName("Hector").Sector);
        }

    }
}