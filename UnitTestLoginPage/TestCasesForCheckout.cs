using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class TestCasesForCheckout
    {
        
        [TestMethod]
        public void TestMethod1() //test case for paymentMethod 1, deliveryMethod 1, deliveryTime 1
        {
            Checkout ck = new Checkout(1, 1033, 41.22, "Paypal", "Overnight Shipping", "Weekend");
            string expectedReturn1 = "Paypal info:vladroata@gmail.com";
            string actualReturn1 = ck.payment();
            string expectedReturn2 = "Overnight Shipping";
            string actualReturn2 = ck.deliveryMethod;
            string expectedReturn3 = "Weekend";
            string actualReturn3 = ck.deliveryTime;
            int expectedReturn4 = 1;
            int actualReturn4 = ck.userid;
            int expectedReturn5 = 1033;
            int actualReturn5 = ck.orderid;
            double expectedReturn6 = 41.22;
            double actualReturn6 = ck.usertotal;
            double expectedReturn7 = 12.5;
            double actualReturn7 = ck.deliveryfee;

            Assert.AreEqual(expectedReturn1, actualReturn1);
            Assert.AreEqual(expectedReturn2, actualReturn2);
            Assert.AreEqual(expectedReturn3, actualReturn3);
            Assert.AreEqual(expectedReturn4, actualReturn4);
            Assert.AreEqual(expectedReturn5, actualReturn5);
            Assert.AreEqual(expectedReturn6, actualReturn6);
            Assert.AreEqual(expectedReturn7, actualReturn7);
        }

        [TestMethod]
        public void TestMethod2() //test case for paymentMethod 2, deliveryMethod 2, deliveryTime 2
        {
            Checkout ck = new Checkout(1, 1033, 41.22, "Credit Card", "Express", "Weekday");
            string expectedReturn1 = "Credit Card info:1234123412341234";
            string actualReturn1 = ck.payment();
            string expectedReturn2 = "Express";
            string actualReturn2 = ck.deliveryMethod;
            string expectedReturn3 = "Weekday";
            string actualReturn3 = ck.deliveryTime;
            int expectedReturn4 = 1;
            int actualReturn4 = ck.userid;
            int expectedReturn5 = 1033;
            int actualReturn5 = ck.orderid;
            double expectedReturn6 = 41.22;
            double actualReturn6 = ck.usertotal;
            double expectedReturn7 = 6.5;
            double actualReturn7 = ck.deliveryfee;

            Assert.AreEqual(expectedReturn1, actualReturn1);
            Assert.AreEqual(expectedReturn2, actualReturn2);
            Assert.AreEqual(expectedReturn3, actualReturn3);
            Assert.AreEqual(expectedReturn4, actualReturn4);
            Assert.AreEqual(expectedReturn5, actualReturn5);
            Assert.AreEqual(expectedReturn6, actualReturn6);
            Assert.AreEqual(expectedReturn7, actualReturn7);
        }

        [TestMethod]
        public void TestMethod3() //test case for paymentMethod 2, deliveryMethod 3, deliveryTime 3
        {
            Checkout ck = new Checkout(1, 1033, 41.22, "Credit Card", "Mail", "Either");
            string expectedReturn1 = "Credit Card info:1234123412341234";
            string actualReturn1 = ck.payment();
            string expectedReturn2 = "Mail";
            string actualReturn2 = ck.deliveryMethod;
            string expectedReturn3 = "Either";
            string actualReturn3 = ck.deliveryTime;
            int expectedReturn4 = 1;
            int actualReturn4 = ck.userid;
            int expectedReturn5 = 1033;
            int actualReturn5 = ck.orderid;
            double expectedReturn6 = 41.22;
            double actualReturn6 = ck.usertotal;
            double expectedReturn7 = 1.5;
            double actualReturn7 = ck.deliveryfee;

            Assert.AreEqual(expectedReturn1, actualReturn1);
            Assert.AreEqual(expectedReturn2, actualReturn2);
            Assert.AreEqual(expectedReturn3, actualReturn3);
            Assert.AreEqual(expectedReturn4, actualReturn4);
            Assert.AreEqual(expectedReturn5, actualReturn5);
            Assert.AreEqual(expectedReturn6, actualReturn6);
            Assert.AreEqual(expectedReturn7, actualReturn7);
        }
        [TestMethod]
        public void TestMethod4() //test case for paymentMethod 2, deliveryMethod null, deliveryTime 3
        {
            Checkout ck = new Checkout(1, 1033, 41.22, "Paypal", "", "Weekday");
            string expectedReturn1 = "Paypal info:vladroata@gmail.com";
            string actualReturn1 = ck.payment();
            string expectedReturn2 = "";
            string actualReturn2 = ck.deliveryMethod;
            string expectedReturn3 = "Weekday";
            string actualReturn3 = ck.deliveryTime;
            int expectedReturn4 = 1;
            int actualReturn4 = ck.userid;
            int expectedReturn5 = 1033;
            int actualReturn5 = ck.orderid;
            double expectedReturn6 = 41.22;
            double actualReturn6 = ck.usertotal;
            double expectedReturn7 = 0;
            double actualReturn7 = ck.deliveryfee;

            Assert.AreEqual(expectedReturn1, actualReturn1);
            Assert.AreEqual(expectedReturn2, actualReturn2);
            Assert.AreEqual(expectedReturn3, actualReturn3);
            Assert.AreEqual(expectedReturn4, actualReturn4);
            Assert.AreEqual(expectedReturn5, actualReturn5);
            Assert.AreEqual(expectedReturn6, actualReturn6);
            Assert.AreEqual(expectedReturn7, actualReturn7);
        }
    }
}
