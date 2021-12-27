using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BookStoreLIB
{
    public class UserData
    {
        public int UserId { set; get; }

        public string LoginName { set; get; }

        public string Password { set; get; }

        public Boolean LogIn(string loginName, string passWord) {
            var dbUser = new DALUserInfo();
            UserId = dbUser.LogIn(loginName, passWord);
            if (UserId > 0)
            {
                LoginName = loginName;
                Password = passWord;
                return true;
            }
            else
                return false;
        }

        public int addPaypalPaymentMethod(string EmailAddress, string PassWord)
        {
            var dbPayment = new DALUserInfo();
            int successState = dbPayment.addPaypalPaymentMethod(EmailAddress, PassWord);
            if (successState == 1) { //if entry is valid, add it to the database
                var conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO PaypalMethods (UserId, EmailAddress, Passwrd) VALUES (@userid, @email, @pass)";
                    cmd.Parameters.AddWithValue("@userid", UserId);
                    cmd.Parameters.AddWithValue("@email", EmailAddress);
                    cmd.Parameters.AddWithValue("@pass", PassWord);
                    conn.Open();
                    cmd.ExecuteScalar();
                    return successState;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    return -10;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return successState;
        }

        public int addCardPaymentMethod(string cardNum, string cvc, string expiry)
        {
            var dbPayment = new DALUserInfo();
            int successState = dbPayment.addCardPaymentMethod(cardNum, cvc, expiry);
            if (successState == 1) {
                var conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO CreditCardMethods (UserId, CardNumber, CVC, ExpiryDate) VALUES (@userid, @cardNum, @cvc, @expiry)";
                    cmd.Parameters.AddWithValue("@userid", UserId);
                    cmd.Parameters.AddWithValue("@cardNum", cardNum);
                    cmd.Parameters.AddWithValue("@cvc", cvc);
                    cmd.Parameters.AddWithValue("@expiry", expiry);
                    conn.Open();
                    cmd.ExecuteScalar();
                    return successState;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    return -10; //return -10 in case of database-error
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return successState;
        }

        public Boolean isAdmin(int x) {
            var conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT COUNT(*) FROM UserData WHERE UserId = @userid AND Administrator = 1";
                cmd.Parameters.AddWithValue("@userid", x);
                conn.Open();
                x = (int)cmd.ExecuteScalar();

                if (x == 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}