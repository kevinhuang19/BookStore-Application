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
    public partial class OrderDetailDialog : Window
    {
        public OrderDetailDialog()
        {
            InitializeComponent();
        }
        int orderID = 0;
        public OrderDetailDialog(int mOrderID)
        {
            InitializeComponent();
            orderID = mOrderID;
        }
        DataTable dtOrders;
        DataSet dsOrdersItem;
        BookOrder bookOrder;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bookOrder = new BookOrder();
                dtOrders = bookOrder.GetOrderInfoByID(orderID);

                if (dtOrders.Rows.Count > 0)
                {
                    txtOrderID.Text = dtOrders.Rows[0]["OrderID"].ToString();
                    txtOrderDate.Text = dtOrders.Rows[0]["OrderDate"].ToString();
                    txtUser.Text = dtOrders.Rows[0]["FullName"].ToString();

                    dsOrdersItem = bookOrder.GetOrderItemInfo(orderID);
                    this.orderListView.ItemsSource = dsOrdersItem.Tables["OrderItem"].DefaultView;
                    double total = 0;
                    for (int i = 0; i < this.orderListView.Items.Count; i++)
                    {
                        DataRowView rowItem = (DataRowView)this.orderListView.Items[i];
                        total += double.Parse(rowItem.Row.ItemArray[3].ToString());
                    }
                    txtTotal.Text = String.Format("{0:n2}", total);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
