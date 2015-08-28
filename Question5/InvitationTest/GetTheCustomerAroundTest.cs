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
            Assert.IsTrue(Program.CalculateTheDistanceBetweenCustomerAndIntercom(53.3381985, -6.2592576) == 0);
        }

        [TestMethod]
        public void TestCalculateDistanceMethodWithExpectation()
        {
            Assert.IsTrue(Math.Abs(Program.CalculateTheDistanceBetweenCustomerAndIntercom(52.986375, -6.043701)-41.62) < 0.5 );
        }

    }
}
