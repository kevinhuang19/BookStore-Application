using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;

namespace BookStoreLIB
{
    [TestClass]
    public class Checkout
    {
        public Checkout(int userid,int orderid, double usertotal, string paymentM, string deliveryM, string deliveryT)
        {
            this.userid = userid;
            this.orderid = orderid;
            this.usertotal = usertotal;
            this.paymentMethod = paymentM;
            this.deliveryMethod = deliveryM;
            this.deliveryTime = deliveryT;
            if (deliveryM.Contains("Overnight Shipping")) { deliveryfee = 12.5; }
            else if (deliveryM.Contains("Express")) { deliveryfee = 6.5; }
            else if (deliveryM.Contains("Mail")) { deliveryfee = 1.5; }
            else deliveryfee = 0.0;
        }
        public int userid { set; get; }
        public int orderid { set; get; }
        public double usertotal { set; get; }
        public double deliveryfee { set; get; }
        public string paymentMethod { set; get; }
        public string deliveryMethod { set; get; }
        public string deliveryTime { set; get; }

        

        public string payment()
        {
            var conn = new SqlConnection("Data Source = tfs.cspc1.uwindsor.ca; Initial Catalog = AgileDB21B1; Persist Security Info = True; User ID = AgileDB21B1; Password = AgileDB21B1#");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "";

                if (paymentMethod.Contains("Paypal"))
                    cmd.CommandText = "Select EmailAddress from PaypalMethods where " + " UserID = @uid";
                if (paymentMethod.Contains("Credit Card"))
                    cmd.CommandText = "Select CardNumber from CreditCardMethods where " + " UserID = @uid";
                cmd.Parameters.AddWithValue("@uid", userid);

                conn.Open();
                string result = (string)cmd.ExecuteScalar();

                return paymentMethod + " info:" + result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
        }




        

        
    }
}
