using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class UnitTest1
    {
        UserData userData = new UserData();
        string inputName, inputPassword;
        int actualUserId;

        [TestMethod]
        public void TestMethod1()
        {
            //specify the value of test inputs
            inputName = "dclark";
            inputPassword = "dc";
            //specify the value of expected outputs
            Boolean expectedReturn = true;
            int expectedUserId = 1;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void TestMethod2()
        {
            inputName = "";
            inputPassword = "dc12345";
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
    }
}
