using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BookStoreLIB
{
    [TestClass]
    public class AddCardPaymentTest
    {
        UserData userData = new UserData();

        [TestMethod]
        public void TestMethod1() //test for correct entry
        {
            //specify the value of test inputs
            string cardNum = "9384567092834723";
            string cvc = "123";
            string expiry = "072022";
            //specify the value of expected outputs
            int expectedReturn = 1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addCardPaymentMethod(cardNum, cvc, expiry);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod2() //test for cvc not 3 characters
        {
            //specify the value of test inputs
            string cardNum = "9384567092834723";
            string cvc = "1234";
            string expiry = "072022";
            //specify the value of expected outputs
            int expectedReturn = -1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addCardPaymentMethod(cardNum, cvc, expiry);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod3() //test for expiry too many characters
        {
            //specify the value of test inputs
            string cardNum = "9384567092834723";
            string cvc = "123";
            string expiry = "0720222";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addCardPaymentMethod(cardNum, cvc, expiry);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod4() //test for card number too long
        {
            //specify the value of test inputs
            string cardNum = "9384567092834723222222";
            string cvc = "123";
            string expiry = "072022";
            //specify the value of expected outputs
            int expectedReturn = -2;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addCardPaymentMethod(cardNum, cvc, expiry);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod5() //test for expiry too few characters
        {
            //specify the value of test inputs
            string cardNum = "9384567092834723";
            string cvc = "123";
            string expiry = "0720";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = userData.addCardPaymentMethod(cardNum, cvc, expiry);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
