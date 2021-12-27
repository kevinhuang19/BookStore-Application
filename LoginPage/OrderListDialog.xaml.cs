using BookStoreLIB;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for OrderListDialog.xaml
    /// </summary>
    public partial class OrderListDialog : Window
    {
        public OrderListDialog()
        {
            InitializeComponent();
        }
        int userID = 0;
        public OrderListDialog(int mUserID)
        {
            InitializeComponent();
            userID = mUserID;
        }
        DataSet dsOrders;
        BookOrder bookOrder;
      

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                detailButton.Visibility = Visibility.Hidden;
                DataRowView selectedRow = (DataRowView)this.orderDataGrid.SelectedItems[0];
                int mOrderID = Convert.ToInt32(selectedRow.Row.ItemArray[0].ToString());
                if (mOrderID > 0) detailButton.Visibility = Visibility.Visible;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                bookOrder = new BookOrder();
                if (fromDate.SelectedDate.HasValue && toDate.SelectedDate.HasValue)
                {
                    DateTime endDate = DateTime.Parse(toDate.SelectedDate.Value.ToShortDateString());
                    endDate = endDate.AddDays(1);
                    dsOrders = bookOrder.GetOrderInfo(userID, DateTime.Parse(fromDate.SelectedDate.Value.ToShortDateString()), endDate);
                }
                else dsOrders = bookOrder.GetOrderInfo(userID);
                this.orderDataGrid.ItemsSource = dsOrders.Tables["Order"].DefaultView;
                totalCostAllOrder();
            }
            catch (Exception)
            { }
        }

        private void totalCostAllOrder()
        {
            double total = 0;
            for (int i = 0; i < this.orderDataGrid.Items.Count; i++)
            {
                DataRowView rowItem = (DataRowView)this.orderDataGrid.Items[i];
                total += double.Parse(rowItem.Row.ItemArray[3].ToString());
            }
            txtTotal.Text = String.Format("{0:n2}", total);
        }

        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView selectedRow = (DataRowView)this.orderDataGrid.SelectedItems[0];
                int mOrderID = Convert.ToInt32(selectedRow.Row.ItemArray[0].ToString());
                OrderDetailDialog orderDetailDialog = new OrderDetailDialog(mOrderID);
                orderDetailDialog.ShowDialog();
            }
            catch (Exception)
            { }
        }
    }
}
