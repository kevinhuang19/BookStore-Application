/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BookStoreLIB
{
    class DALOrder
    {
        SqlConnection conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
        DataSet dsOrder;
        DataSet dsOrderItem;
        public int Proceed2Order(string xmlOrder)
        {
            SqlConnection cn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "down_PlaceOrder";
                Debug.WriteLine(cmd);
                SqlParameter inParameter = new SqlParameter();
                inParameter.ParameterName = "@xmlOrder";
                inParameter.Value = xmlOrder;
                inParameter.DbType = DbType.String;
                inParameter.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(inParameter);
                SqlParameter ReturnParameter = new SqlParameter();
                ReturnParameter.ParameterName = "@OrderID";
                ReturnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(ReturnParameter);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return (int)cmd.Parameters["@OrderID"].Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }
        public DataSet GetOrderInfo(int mUserID)
        {
            try
            {
                conn.Open();
                String strSQL = "Select o.OrderID, o.OrderDate, o.Status, sub.Total from Orders o INNER JOIN " +
                    " (select oi.OrderID, sum(bd.Price*oi.Quantity) as Total  from OrderItem oi LEFT JOIN BookData bd ON " +
                    " bd.ISBN = oi.ISBN GROUP BY oi.OrderID ) sub ON sub.OrderID = o.OrderID WHERE o.UserID=@UserID ORDER BY o.OrderDate desc";
                SqlCommand cmdSelOrder = new SqlCommand(strSQL, conn);
                cmdSelOrder.Parameters.AddWithValue("@UserID", mUserID);
                cmdSelOrder.ExecuteScalar();
                SqlDataAdapter daOrder = new SqlDataAdapter(cmdSelOrder);
                dsOrder = new DataSet("Order");
                daOrder.Fill(dsOrder, "Order");            //Get orders info
                conn.Close();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsOrder;
        }

        public DataSet GetOrderInfo(int mUserID, DateTime fromDate, DateTime toDate)
        {
            try
            {
                conn.Open();
                String strSQL = "Select o.OrderID, o.OrderDate, o.Status, sub.Total from Orders o INNER JOIN " +
                    " (select oi.OrderID, sum(bd.Price*oi.Quantity) as Total  from OrderItem oi LEFT JOIN BookData bd ON " +
                    " bd.ISBN = oi.ISBN GROUP BY oi.OrderID ) sub ON sub.OrderID = o.OrderID WHERE o.UserID=@UserID AND o.OrderDate>=@FromDate AND o.OrderDate<=@ToDate  ORDER BY o.OrderDate desc";
                SqlCommand cmdSelOrder = new SqlCommand(strSQL, conn);
                cmdSelOrder.Parameters.AddWithValue("@UserID", mUserID);
                cmdSelOrder.Parameters.AddWithValue("@FromDate", fromDate);
                cmdSelOrder.Parameters.AddWithValue("@ToDate", toDate);
                cmdSelOrder.ExecuteScalar();
                SqlDataAdapter daOrder = new SqlDataAdapter(cmdSelOrder);
                dsOrder = new DataSet("Order");
                daOrder.Fill(dsOrder, "Order");            //Get orders info
                conn.Close();

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsOrder;
        }

        public DataTable GetOrderInfoByID(int mOrderID)
        {
            DataTable dtOrder = new DataTable();
            try
            {
                conn.Open();
                String strSQL2 = "select o.*, u.FullName from Orders o INNER JOIN UserData u ON o.UserID = u.UserID WHERE o.OrderID=@OrderID";
                SqlCommand cmdSelOrderItem = new SqlCommand(strSQL2, conn);
                cmdSelOrderItem.Parameters.AddWithValue("@OrderID", mOrderID);
                cmdSelOrderItem.ExecuteScalar();
                SqlDataAdapter daOrderItem = new SqlDataAdapter(cmdSelOrderItem);
                daOrderItem.Fill(dtOrder);
                conn.Close();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dtOrder;
        }

        public DataSet GetOrderItemInfo(int mOrderID)
        {
            try
            {
                conn.Open();
                String strSQL2 = "select oi.ISBN as BookID, bd.Title as BookTitle, oi.Quantity, bd.Price, (bd.Price*oi.Quantity) as Subtotal " +
                    " from OrderItem oi LEFT JOIN BookData bd ON bd.ISBN = oi.ISBN WHERE OrderID=@OrderID";
                SqlCommand cmdSelOrderItem = new SqlCommand(strSQL2, conn);
                cmdSelOrderItem.Parameters.AddWithValue("@OrderID", mOrderID);
                cmdSelOrderItem.ExecuteScalar();
                SqlDataAdapter daOrderItem = new SqlDataAdapter(cmdSelOrderItem);
                dsOrderItem = new DataSet("OrderItem");
                daOrderItem.Fill(dsOrderItem, "OrderItem");                  //Get order item info
                conn.Close();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return dsOrderItem;
        }
    }
}
