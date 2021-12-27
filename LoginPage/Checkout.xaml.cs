using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        
        public string paymentMethod { set; get; }
        public string deliveryMethod { set; get; }
        public string deliveryTime { set; get; }

        public Checkout()
        {

            InitializeComponent();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            
            paymentMethod = list1.SelectedItem.ToString();
            string[] str = paymentMethod.Split(':');
            paymentMethod = str[1];

            deliveryMethod = list2.SelectedItem.ToString();
            str = deliveryMethod.Split(':');
            deliveryMethod = str[1];

            deliveryTime = list3.SelectedItem.ToString();
            str = deliveryTime.Split(':');
            deliveryTime = str[1];

            this.DialogResult = true;

        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        

    }
}
