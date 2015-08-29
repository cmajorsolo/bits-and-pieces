using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Invitation;
using System.Collections.Generic;

namespace InvitationTest
{
    [TestClass]
    public class GetTheCustomerAroundTest
    {
        [TestMethod]
        public void TestCalculateDistanceMethodWithSameTwoLocations()
        {
            CalculateDistance c = new CalculateDistance();
            Assert.IsTrue(c.Calculate(53.3381985, -6.2592576, 53.3381985, -6.2592576) == 0);
        }

        [TestMethod]
        public void TestCalculateDistanceMethodWithExpectation()
        {
            CalculateDistance c = new CalculateDistance();
            Assert.IsTrue(Math.Abs(c.Calculate(52.986375, -6.043701, 53.3381985, -6.2592576) - 41.62) < 0.5);
        }
    }
}
