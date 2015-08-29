using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Invitation;

namespace InvitationTest
{
    [TestClass]
    public class GetTheCustomerListTest
    {   
        [TestMethod]
        public void ReadInJsonWithEmpthyPath()
        {
            GetJsonText g = new GetJsonText();
            string path = "";
            Assert.IsTrue(g.GetCustomersFromJsonFile(path) == null);
        }

        [TestMethod]
        public void ReadInJsonWithNullPath()
        {
            GetJsonText g = new GetJsonText();
            string path = null;
            Assert.IsTrue(g.GetCustomersFromJsonFile(path) == null);
        }

        [TestMethod]
        public void ReadInJsonWithNonExistsPath()
        {
            GetJsonText g = new GetJsonText();
            string path = "C\nonExists";
            Assert.IsTrue(g.GetCustomersFromJsonFile(path) == null);
        }
    }
}
