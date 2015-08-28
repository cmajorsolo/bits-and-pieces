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
            string path = "";
            Assert.IsTrue(Program.GetTheCustomerList(path)==null);
        }

        [TestMethod]
        public void ReadInJsonWithNullPath()
        {
            string path = null;
            Assert.IsTrue(Program.GetTheCustomerList(path) == null);
        }

        [TestMethod]
        public void ReadInJsonWithNonExistsPath()
        {
            string path = "C\nonExists";
            Assert.IsTrue(Program.GetTheCustomerList(path) == null);
        }
    }
}
