using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest2
    {
        EmptyInputTest emptyTest = new EmptyInputTest();
        string inputName, inputPassword;

        [TestMethod]
        public void TestMethod1()
        {
            inputName = "";
            inputPassword = "";
            Boolean expectedReturn = true;
            Boolean actualReturn = emptyTest.isEmpty(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2()
        {
            inputName = "wwu";
            inputPassword = "ww12345";
            Boolean expectedReturn = false;
            Boolean actualReturn = emptyTest.isEmpty(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod3()
        {
            inputName = "wwu";
            inputPassword = "";
            Boolean expectedReturn = true;
            Boolean actualReturn = emptyTest.isEmpty(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod4()
        {
            inputName = "";
            inputPassword = "ww12345";
            Boolean expectedReturn = true;
            Boolean actualReturn = emptyTest.isEmpty(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
