using System.Linq;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BookStoreGUI
{

    public partial class RegisterDialog : Window
    {
        public RegisterDialog()
        {
            InitializeComponent();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string usern = this.nameTextBox.Text;
            string pass = this.passwordTextBox.Password;
            string conf = this.confirmTextBox.Password;
            bool exists = false;
            //connection string
            string khConnectionString = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#";

            //checking if register name and password is valid
            if (usern == "" || pass == "" || conf == "")
            {
                MessageBox.Show("Please fill in all slots.");
            }
            else if (pass != conf)//checking if both fields are valid
            {
                MessageBox.Show("Please enter the same password in both fields.");
            }
            //password with requirements
                    else if (!pass.All(c => c >= 65 && c <= 90 || c >= 97 && c <= 122 || c >= 48 && c <= 57) ||
                   !pass.Any(c => c >= 48 && c <= 57) ||
                   pass.Length < 6 ||
                   !((int)pass[0] >= 65 && (int)pass[0] <= 90 || (int)pass[0] >= 97 && (int)pass[0] <= 122))
            {
                MessageBox.Show("A valid password needs to start with a letter and have at least six characters with both letters and numbers.");
            }
            /*
             * Username Requirements
             */
            // Max Length: 32
            else if (usern.Length > 32 || usern.Length < 6)
            {
                MessageBox.Show("Please write a username that is from 6 to 32 characters.");
            }
            // Only allow alphanumeric username with underscores
            else if (!new Regex(@"^([A-Za-z]|[0-9]|_)+$").IsMatch(usern))
            {
                MessageBox.Show("Please ensure your username only contains letters, numbers, and underscores.");
            }
            else
            {
                using (var con = new SqlConnection(khConnectionString))//connect to the database
                {
                    con.Open();
                    //first check if the username is existing
                    using (var cmd = new SqlCommand("select count(*) from UserData where UserName = @UserName", con))
                    {
                        cmd.Parameters.AddWithValue("@UserName", usern);
                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                    if (exists)
                    {
                        MessageBox.Show("Username is already in use, please try a different one.");
                    }

                    else
                    {
                        //insert the new username and password
                        using (var cmd = new SqlCommand("INSERT INTO UserData VALUES(@UserName, @Password,@Type,@Administrator,@FullName)", con))
                        {

                            cmd.Parameters.AddWithValue("@UserName", usern);
                            cmd.Parameters.AddWithValue("@Password", pass);
                            cmd.Parameters.AddWithValue("@Type", "RG");
                            cmd.Parameters.AddWithValue("@Administrator", false);
                            cmd.Parameters.AddWithValue("@FullName", "test");
                            cmd.ExecuteNonQuery();
                            con.Close();
                            this.DialogResult = true;
                        }
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
