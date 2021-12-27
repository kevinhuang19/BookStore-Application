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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        public static bool isValid(String password)
        {

            // for checking if password length atleast 6
            if (!(password.Length >= 6))
            {
                return false;
            }
            if (true)
            {
                int count = 0;

                // checking capital letters
                for (int i = 65; i <= 90; i++)
                {

                    // type casting
                    char c = (char)i;

                    String str1 = c.ToString();
                    if (password.Contains(str1))
                    {
                        count = 1;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
            }

            // all conditions fails then
            return true;
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}