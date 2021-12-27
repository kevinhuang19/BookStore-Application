using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace BookStoreLIB
{
    [TestClass]
    public class TestCasesForRegister
    {
        string inputName, inputPass, inputConf;

        [TestMethod]
        public void TestMethod1()  //test case for empty username
        {
            //specify the value of test inputs
            inputName = "";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName,inputPass,inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod2() //test case for empty password
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }
        [TestMethod]
        public void TestMethod3()  //test case for empty confirmation password
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "a123456";
            inputConf = "";
            //specify the value of expected outputs
            int expectedReturn = -1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod4()  //test case for conflicting password/confirmation password
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "a123456";
            inputConf = "1";
            //specify the value of expected outputs
            int expectedReturn = -2;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod5() //test case for password with non-letter non-number character(ascii<48)
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "$123456";
            inputConf = "$123456";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod6() //test case for password with non-letter non-number character(57<ascii<65)
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "?123456";
            inputConf = "?123456";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod7()  //test case for password with non-letter non-number character(90<ascii<97)
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "_123456";
            inputConf = "_123456";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod8()  //test case for password with non-letter non-number character(ascii>122)
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "{123456";
            inputConf = "{123456";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod9()  //test case for password less than 6 characters
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "a123";
            inputConf = "a123";
            //specify the value of expected outputs
            int expectedReturn = -3;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod10()  //test case for username less than 6 characters
        {
            //specify the value of test inputs
            inputName = "jsm";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -4;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod11()  //test case for username more than 32 characters
        {
            //specify the value of test inputs
            inputName = "jsmith1234567123456712345671234567";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -4;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod12()  //test case for username with non-letter non-number character
        {
            //specify the value of test inputs
            inputName = "j@smith";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -5;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod13()  //test case for a username that is already in the database
        {
            //specify the value of test inputs
            inputName = "jsmith";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = -6;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void TestMethod14()  //test case for combination of username ,password ,confirmation that is acceptable
        {
            //specify the value of test inputs
            inputName = "Ksmith";
            inputPass = "a123456";
            inputConf = "a123456";
            //specify the value of expected outputs
            int expectedReturn = 1;
            //obtain the actual outputs by calling the method under testing
            int actualReturn = checkRegister(inputName, inputPass, inputConf);
            //verify the result:
            Assert.AreEqual(expectedReturn, actualReturn);
        }


        //checkRegister function the same structure as it is in RegisterDialog.xaml.cs
        public int checkRegister(string usern, string pass, string conf) //check the first character of the password to ensure that it starts with a letter
        {
            if (usern == "" || pass == "" || conf == "")
            {
                return -1;
            }
            else if (pass != conf)//checking if both fields are valid
            {
                return -2;
            }
            //password with requirements
            else if (!pass.All(c => c >= 65 && c <= 90 || c >= 97 && c <= 122 || c >= 48 && c <= 57) || !pass.Any(c => c >= 48 && c <= 57) ||
           pass.Length < 6 || !((int)pass[0] >= 65 && (int)pass[0] <= 90 || (int)pass[0] >= 97 && (int)pass[0] <= 122))
            {
                return -3;
            }
            /*
             * Username Requirements Length: 6-32
             */
            else if (usern.Length > 32 || usern.Length < 6)
            {
                return -4;
            }
            // Only allow alphanumeric username with underscores
            else if (!new Regex(@"^([A-Za-z]|[0-9]|_)+$").IsMatch(usern))
            {
                return -5;
            }
            else
            {
                using (var con = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#"))//connect to the database
                {
                    con.Open();
                    bool exists = false;
                    //first check if the username is existing
                    using (var cmd = new SqlCommand("select count(*) from UserData where UserName = @UserName", con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", usern);
                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                    if (exists)
                    {
                        return -6;
                    }

                    else
                    {
                        //insert the new username and password
                        return 1;
                    }
                }
            }
        }

        
    }
}
