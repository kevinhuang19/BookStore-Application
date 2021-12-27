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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for AddPaymentDialog.xaml
    /// </summary>



    public partial class AddPaymentDialog : Window
    {

        UserData userData;

        public AddPaymentDialog()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userData = MainWindow.userData;
        }

        private void AddPaypal_Click(object sender, RoutedEventArgs e)
        {
            AddPaypalDialog APP_dlg = new AddPaypalDialog();
            APP_dlg.Owner = this;
            APP_dlg.ShowDialog();
            if (APP_dlg.DialogResult == true)
            {
                if (userData.addPaypalPaymentMethod(APP_dlg.emailTextBox.Text, APP_dlg.passwordTextBox.Password) > 0)
                {
                    string message = "Payment method successfully activated.";
                    MessageBox.Show(message);
                }

                else
                {
                    string message = "Payment method activation failed.";
                    MessageBox.Show(message);
                }

            }
        }

        private void AddCreditCard_Click(object sender, RoutedEventArgs e)
        {
            AddCreditCardDialog ACC_dlg = new AddCreditCardDialog();
            ACC_dlg.Owner = this;
            ACC_dlg.ShowDialog();

            if (ACC_dlg.DialogResult == true)
            {
                if (userData.addCardPaymentMethod(ACC_dlg.cardnumTextBox.Text, ACC_dlg.cvcTextBox.Text, ACC_dlg.expdateTextBox.Text) > 0)
                {
                    string message = "Payment method successfully activated.";
                    MessageBox.Show(message);
                }

                else
                {
                    string message = "Payment method activation failed.";
                    MessageBox.Show(message);
                }

            }
        }
    }
}
