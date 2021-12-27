using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest4
    {
        FirstCharTest firstCharTest = new FirstCharTest();
        string inputName, inputPassword;

        [TestMethod]
        public void TestMethod1()
        {
            inputName = "wwu";
            inputPassword = "ab1234";
            Boolean expectedReturn = false;
            Boolean actualReturn = firstCharTest.checkFirstChar(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod2()
        {
            inputName = "roata";
            inputPassword = "1abd234";
            Boolean expectedReturn = false;
            Boolean actualReturn = firstCharTest.checkFirstChar(inputName, inputPassword);
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
