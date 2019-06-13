using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoginAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAuth.Tests
{
    [TestClass()]
    public class LoginAuthenticationTests
    {
        [TestMethod()]
        public void CredentialsAuthenticationTest()
        {
            LoginAuthentication login = new LoginAuthentication();
            Assert.AreEqual(login.CredentialsAuthentication("eldavis", "del2al5"), LoginAuthentication.validationResult.Success);
        }
    }
}