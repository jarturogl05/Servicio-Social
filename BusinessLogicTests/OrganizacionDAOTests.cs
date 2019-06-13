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
        public void GetOrganizacionTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> organizacionList = organizacionDAO.GetOrganizacion();
            Assert.AreEqual(false, organizacionList.Any());
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void GetOrganizacionSQLExceptionTest()
        {
            OrganizacionDAO organizacionDAO = new OrganizacionDAO();
            List<Organizacion> organizacionList = organizacionDAO.GetOrganizacion();
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void GetOrganizacionByNameSQLExceptionTest()
        {
            OrganizacionDAO organizacion = new OrganizacionDAO();
            organizacion.GetOrganizacionByName("BADD990525I55");
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