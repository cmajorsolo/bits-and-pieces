using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Invitation;

namespace InvitationTest
{
    [TestClass]
    public class TestingWithMock
    {
        [TestMethod]
        public void TestingEmptyPath()
        {
            List<Customer> list = null;
            var filegetter = new Mock<IRetreiveFile>();
            filegetter.Setup(x => x.GetCustomersFromJsonFile("")).Returns(list);

            var test = new GetCustomersCloseToIntercom();
            var result = test.RetrieveCustomers(filegetter.Object,"");
            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void TestingSameLocationDistance()
        {
            double distance = 0.0;
            var calc = new Mock<ICalculate>();
            calc.Setup(x => x.Calculate(0.0, 0.0, 0.0, 0.0)).Returns(distance);

            var test = new GetCustomersCloseToIntercom();
            Customer c = new Customer("testCust",000,53.3381985,-6.2592576);
            List<Customer> cList = new List<Customer>{c};
            List<Customer> emptyList = new List<Customer>();
            var result = test.GetRequiredCustomers(calc.Object, cList);
            Assert.AreEqual(result, emptyList);
        }
    }
}
