using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for AccountDialog.xaml
    /// </summary>

    

    public partial class AccountDialog : Window
    {
        UserData userData;
        DataSet dsOrders;
        DataSet dsOrdersItem;
        BookOrder bookOrder;

        public AccountDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userData = MainWindow.userData;
            bookOrder = new BookOrder();
            dsOrders = bookOrder.GetOrderInfo(userData.UserId);
            this.orderDataGrid.ItemsSource = dsOrders.Tables["Order"].DefaultView;
            var conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
            try
            {
                //fill payment tables with data pulled from DB
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select EmailAddress, Passwrd FROM PaypalMethods WHERE UserId = "+userData.UserId;
                cmd.ExecuteScalar();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("PaypalMethods");
                dataAdapter.Fill(dt);
                PaypalMethodsGrid.ItemsSource = dt.DefaultView;
                dataAdapter.Update(dt);

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "Select CardNumber, CVC, ExpiryDate FROM CreditCardMethods WHERE UserId = " + userData.UserId;
                cmd2.ExecuteScalar();
                SqlDataAdapter dataAdapter2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable("CreditCardMethods");
                dataAdapter2.Fill(dt2);
                CardMethodsGrid.ItemsSource = dt2.DefaultView;
                dataAdapter2.Update(dt2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void addPayment_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentDialog AP_dlg = new AddPaymentDialog();
            AP_dlg.Owner = this;
            AP_dlg.ShowDialog();
            

        }

        private void removePayment_Click(object sender, RoutedEventArgs e)
        {
            var conn = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
            try
            {
                //check if something is selected and if it is not an empty row
                if (PaypalMethodsGrid.SelectedItems.Count > 0 && ((DataRowView)(PaypalMethodsGrid.SelectedItem)) != null)
                {
                    try
                    {
                        //get unique value from paypal database
                        string strarr = ((DataRowView)(PaypalMethodsGrid.SelectedItem)).Row.ItemArray.First().ToString();
                        Debug.WriteLine(strarr);
                        conn.Open();

                        //delete record from database
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "DELETE FROM PaypalMethods WHERE EmailAddress = @str AND UserId = @userid";
                        cmd.Parameters.AddWithValue("@str", strarr);
                        cmd.Parameters.AddWithValue("@userid", userData.UserId);
                        cmd.ExecuteScalar();

                        //delete record from the datagrid
                        ((DataRowView)(PaypalMethodsGrid.SelectedItem)).Row.Delete();
                        conn.Close();
                    }
                    catch (SqlException ex) {
                        Debug.WriteLine(ex);
                    }
                    

                }
                else if (CardMethodsGrid.SelectedItems.Count > 0 && ((DataRowView)(CardMethodsGrid.SelectedItem)) != null)
                {
                    string strarr = ((DataRowView)(CardMethodsGrid.SelectedItem)).Row.ItemArray.First().ToString();
                    Debug.WriteLine(strarr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM CreditCardMethods WHERE CardNumber = @str AND UserId = @userid";
                    cmd.Parameters.AddWithValue("@str", strarr);
                    cmd.Parameters.AddWithValue("@userid", userData.UserId);
                    cmd.ExecuteScalar();
                    ((DataRowView)(CardMethodsGrid.SelectedItem)).Row.Delete();
                    conn.Close();
                }
            }
            catch (Exception ex) { //avoid having the program crash if the user tries to delete an empty row
            
            }
            
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (fromDate.SelectedDate.HasValue && toDate.SelectedDate.HasValue)
            {
                DateTime endDate = DateTime.Parse(toDate.SelectedDate.Value.ToShortDateString());
                endDate = endDate.AddDays(1);
                dsOrders = bookOrder.GetOrderInfo(userData.UserId, DateTime.Parse(fromDate.SelectedDate.Value.ToShortDateString()), endDate);
            }
            else dsOrders = bookOrder.GetOrderInfo(userData.UserId);

            this.orderDataGrid.ItemsSource = dsOrders.Tables["Order"].DefaultView;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this.orderDataGrid.ItemsSource = null;
                DataRowView selectedRow = (DataRowView)this.orderDataGrid.SelectedItems[0];
                int mOrderID = Convert.ToInt32(selectedRow.Row.ItemArray[0].ToString());
                bookOrder = new BookOrder();
                dsOrdersItem = bookOrder.GetOrderItemInfo(mOrderID);
                this.orderDataGrid.ItemsSource = dsOrdersItem.Tables["OrderItem"].DefaultView;

            }
            catch (Exception)
            { }

        }


        private void FromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            changeValueDate();

        }

        private void ToDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            changeValueDate();
        }

        private void changeValueDate()
        {
            DateTime? selectedFromDate = fromDate.SelectedDate;
            DateTime? selectedToDate = toDate.SelectedDate;
            if (selectedFromDate.HasValue && selectedToDate.HasValue)
            {

                int result = DateTime.Compare(selectedFromDate.Value, selectedToDate.Value);
                if (result > 0)
                {
                    fromDate.SelectedDate = selectedToDate.Value;
                    toDate.SelectedDate = selectedFromDate.Value;
                }
            }
        }

    }
}
