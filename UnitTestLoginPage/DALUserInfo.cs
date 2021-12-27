using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;

namespace BookStoreLIB
{
    internal class DALUserInfo
    {
        public int LogIn(string userName, string passWord) {
            var conn = new SqlConnection("Data Source = tfs.cspc1.uwindsor.ca; Initial Catalog = AgileDB21B1; Persist Security Info = True; User ID = AgileDB21B1; Password = AgileDB21B1#");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select UserID from UserData where " + " UserName = @UserName and Password = @Password";
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", passWord);
                conn.Open();
                int userId = (int)cmd.ExecuteScalar();
                if (userId > 0) return userId;
                else return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -1;
            }
            finally {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int addPaypalPaymentMethod(string EmailAddress, string PassWord)
        { //test the email and password

            /*We want the email to be formatted like "<username>@<email provider>" example: "vladroata@gmail.com"
             * The email provider should be a recognized north american or global provider such as yahoo, gmail, hotmail. The email should end in .com or .ca
             * Username should be at least 3 characters and should contain only numbers and letters
             *We want the password to be at least 8 characters long, and contain at least 1 lower-case character, 1 upper case character, 1 number, and 1 special character (such as @, !, #)
            */

            string[] splitEmail = Regex.Split(EmailAddress, @"@");
            string[] splitProvider;

            if (splitEmail.Length > 2)
            { //Length >2 if the regex character is found too many times
                return -2;
            }

            try { //attempt to split the email provider, will throw an exception if the email did not contain '@' because splitEmail will only have a length of 1
                splitProvider = Regex.Split(splitEmail[1], @"\.");
            }
            catch
            {
                return -1;
            }

            if (splitProvider.Length > 2)
            { //Length >2 if the regex character is found too many times
                return -2;
            }

            if (splitEmail.Length == 1 || splitProvider.Length == 1) { //Length = 1 if the regex character cannot be found in the string
                return -1;
            }

            if (!(splitProvider[0].ToLower() == "gmail" || splitProvider[0].ToLower() == "hotmail" || splitProvider[0].ToLower() == "yahoo")) {
                return -3;
            }
            if (!(splitProvider[1].ToLower() == "ca" || splitProvider[1].ToLower() == "com"))
            {
                return -3;
            }

            foreach (char ch in splitEmail[0].ToLower()) { //username contains non-numeric or non-alphabetical character
                if (!((ch >= 48 && ch <= 57) || (ch >= 97 && ch <= 122)) || splitEmail[0].Length < 3) {
                    return -4;
                }
            }

            //establish some counters to track how many lowercase, uppercase, etc characters we find in the password and make sure they are all >=1
            int lowercase = 0;
            int uppercase = 0;
            int number = 0;
            int special = 0;
            foreach (char ch in PassWord) {
                if (ch >= 48 && ch <= 57) {
                    number++;
                }
                if (ch >= 65 && ch <= 90) {
                    uppercase++;
                }
                if (ch>=97 && ch <= 122)
                {
                    lowercase++;
                }
                if ((ch >= 33 && ch <= 47) || (ch >= 58 && ch <= 64) || (ch >= 91 && ch <= 96) || (ch >= 123 && ch <= 126)) {
                    special++;
                }
            }
            if (lowercase == 0 || uppercase == 0 || number == 0 || special == 0 || PassWord.Length<8) {
                return -5;
            }

            return 1;
        }

        public int addCardPaymentMethod(string cardNum, string cvc, string expiry) {
            /*We want the card number to be a 16-digit number
             * We want the cvc to be a 3-digit number
             * We want the expiry to be a month and year combination formatted as MM/YYYY
            */

            int cvc_number = 0;
            foreach (char ch in cvc)
            {
                if (ch >= 48 && ch <= 57)
                {
                    cvc_number++;
                }
            }
            if (cvc_number != 3 || cvc.Length != 3) {
                return -1;
            }

            int card_number = 0;
            foreach (char ch in cardNum)
            {
                if (ch >= 48 && ch <= 57)
                {
                    card_number++;
                }
            }
            if (card_number != 16 || cardNum.Length != 16)
            {
                return -2;
            }

            //check for the expiry date not following the MM/YYYY format
            if (expiry.Length != 6)
            {
                return -3;
            }
            string month = expiry.Substring(0,2);
            string year = expiry.Substring(2,4);
            if (int.Parse(month) > 12 || int.Parse(month) < 1) {
                return -3;
            }

            //check for the card being expired
            var currentDate = DateTime.Now;
            var expiryDate = new DateTime(int.Parse(year), int.Parse(month), 1, 1, 1, 1);
            if (currentDate >= expiryDate) {
                return -4;
            }


            //TODO: if the date is valid, add database entry

            return 1;
        }
    }
}