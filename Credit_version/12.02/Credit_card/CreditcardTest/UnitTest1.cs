using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Credit_card;
using System.Collections.Generic;

namespace CreditcardTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Valodi_TestMethod()
        {
            Generate Gen = new Generate();
            string bemenet = "1234567890123452";
            bool actual = Gen.Valódi(bemenet);
            bool exented = true;
            Assert.AreEqual(exented, actual);
        }
        [TestMethod]
        public void Card_TestMethod()
        {
            string number = Generate.GenerateCardNumber(Generate.MASTERCARD_PREFIX_LIST, 16);
            int hossz = number.Length;
            int exented = 16;
            Assert.AreEqual(exented,hossz);
        }
        [TestMethod]
        public void cvv()
        {
            Generate Gen = new Generate();
            string bemenet = "0005998501325027";
            string actual = Gen.CVV(bemenet);
            string exented = "182";
            Assert.AreEqual(exented,actual);
        }
    }
}
