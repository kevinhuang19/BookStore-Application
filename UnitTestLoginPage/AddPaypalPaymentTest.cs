using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BookStoreLIB
{
    [TestClass]
    public class AddPaypalPaymentTest
    {
        UserData userData = new UserData();
        [TestMethod]

        public void TestMethod1() //test for correct entry
        {
            //specify the value of test inputs
            string email = "vlad@gmail.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = 1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod2() //test for no @ character
        {
            //specify the value of test inputs
            string email = "vladgmail.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod3() //test for more than 1 @ character
        {
            //specify the value of test inputs
            string email = "vlad@gmail@.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -2;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod4() //test for more than 1 . character
        {
            //specify the value of test inputs
            string email = "vlad@gmai.l.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -2;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod5() //test for unrecognized email provider
        {
            //specify the value of test inputs
            string email = "vlad@yandex.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod6() //test for unrecognized country
        {
            //specify the value of test inputs
            string email = "vlad@gmail.ru";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod7() //test for email username including special characters
        {
            //specify the value of test inputs
            string email = "vlad#@gmail.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -4;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod8() //test for email username too short
        {
            //specify the value of test inputs
            string email = "v@gmail.com";
            string password = "Aasdasd1!";
            //specify the value of expected outputs
            int expectedReturn = -4;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod9() //test for password too short
        {
            //specify the value of test inputs
            string email = "vladroata@gmail.com";
            string password = "asdasd";
            //specify the value of expected outputs
            int expectedReturn = -5;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod10() //test for password not containing special character
        {
            //specify the value of test inputs
            string email = "vladroata@gmail.com";
            string password = "Asdasdasd1";
            //specify the value of expected outputs
            int expectedReturn = -5;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod11() //test for password not containing capitals
        {
            //specify the value of test inputs 
            string email = "vladroata@gmail.com";
            string password = "asdasdasd#1";
            //specify the value of expected outputs
            int expectedReturn = -5;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addPaypalPaymentMethod(email, password);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
