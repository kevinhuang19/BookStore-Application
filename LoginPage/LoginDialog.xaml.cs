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
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();
        }


        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RegisterDialog dlg = new RegisterDialog();
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                MessageBox.Show("Registration is successful, please login.");
            }
            this.ShowDialog();
        }
    }
}
