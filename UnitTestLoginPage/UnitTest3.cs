using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest3
    {
        InvalidCharsTest invalidCharTest = new InvalidCharsTest();
        string inputName, inputPassword;

        [TestMethod]
        public void TestMethod1()
        {
            inputName = "wwu";
            inputPassword = "ab123#4";
            Boolean expectedReturn = true;
            Boolean actualReturn = invalidCharTest.hasInvalidChars(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            inputName = "wwu";
            inputPassword = "ww12345";
            Boolean expectedReturn = false;
            Boolean actualReturn = invalidCharTest.hasInvalidChars(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod3()
        {
            inputName = "ww#u";
            inputPassword = "ab12345";
            Boolean expectedReturn = false;
            Boolean actualReturn = invalidCharTest.hasInvalidChars(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
