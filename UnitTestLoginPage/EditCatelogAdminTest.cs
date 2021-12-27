using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStoreLIB
{
    [TestClass]
    public class EditCatelogAdminTest
    {
        AddBookEditCatelogTestCase editCat = new AddBookEditCatelogTestCase();

        [TestMethod]
        public void TestMethod1() //test for correct entry
        {
            //Empty the value of test inputs
            string isbn = "";
            string title = "";
            string author = "";
            string year = "";
            string ed = "";
            string pb = "";
            string pr = "";
            string cat = "";

            //specify the value of expected outputs
            Boolean expectedReturn = true;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = editCat.checkForEmptyChar(isbn, title, author, year, ed, pb, pr, cat);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod2() //test for isbn not 13 characters
        {
            //specify the value of test inputs
            string isbn = "9384567092834723";

            //specify the value of expected outputs
            Boolean expectedReturn = true;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = editCat.testIsbnLength(isbn);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod3() //test for isbn too feww characters
        {
            //specify the value of test inputs
            string isbn = "93845670922";

            //specify the value of expected outputs
            Boolean expectedReturn = false;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = editCat.testIsbnLength(isbn);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod4() //test for isbn number too long
        {
            //specify the value of test inputs
            string isbn = "9384567092834723222222";

            //specify the value of expected outputs
            Boolean expectedReturn = true;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = editCat.testIsbnLength(isbn);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod5() //test for year  too many characters
        {
            //specify the value of test inputs
            string year = "9384567092834723";

            //specify the value of expected outputs
            Boolean expectedReturn = true;
            //obtain the actual outputs by calling the method under testing
            Boolean actualReturn = editCat.testYear(year);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);

        }
    }
 }
