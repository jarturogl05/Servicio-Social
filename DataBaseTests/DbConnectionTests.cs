using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataBase.Tests
{
    [TestClass()]
    public class DbConnectionTests
    {
        [TestMethod()]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void DbConnectionTest()
        {
            DbConnection dbConnection = new DbConnection();
        }
    }
}