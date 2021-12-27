using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class TestCasesForLogin
    {
        
        UserData userData = new UserData();
        string inputName, inputPassword;
        int actualUserId;

        [TestMethod]
        public void TestMethod1()  // valid username, password combination
        {
            //specify the value of test inputs
            inputName = "";
            inputPassword = "Test123";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod2()  // valid username, password combination
        {
            //specify the value of test inputs
            inputName = "username";
            inputPassword = "";
            //specify the value of expected outputs
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
        [TestMethod]
        public void TestMethod3()  // valid username, password combination
        {
            //specify the value of test inputs
            inputName = "username";
            inputPassword = "Test123";
            //specify the value of expected outputs
            Boolean expectedReturn = true;
            int expectedUserId = 12;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void TestMethod4() // invalid username, valid password
        {
            inputName = "nonexist";
            inputPassword = "Test123";
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void TestMethod5() // valid username, invalid password
        {
            inputName = "dclark";
            inputPassword = "";
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }

        [TestMethod]
        public void TestMethod6() // valid username, valid password but wrong combination
        {
            inputName = "dclark";
            inputPassword = "Test123";
            Boolean expectedReturn = false;
            int expectedUserId = -1;
            Boolean actualReturn = userData.LogIn(inputName, inputPassword);
            actualUserId = userData.UserId;
            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedUserId, actualUserId);
        }
    }
}
