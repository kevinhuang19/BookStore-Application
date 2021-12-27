using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using BookStoreLIB;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for EditCatelog.xaml
    /// </summary>
    public partial class EditCatelog : Window
    {
        BookCatalog bookCat;
        DataSet dsBookCat;
        SqlConnection sql = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");
        public EditCatelog()
        {
            InitializeComponent();
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            SqlCommand cmd = new SqlCommand("Select Title, ISBN, Author, Price, Year, Edition, Publisher, CategoryID from BookData", sql);
            DataTable dt = new DataTable();
            bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            this.DataContext = dsBookCat.Tables["Book"];
            sql.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sql.Close();
            DataGridEditStoreItems.ItemsSource = dt.DefaultView;  
        }


        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var sql = new SqlConnection("Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB21B1;Persist Security Info=True;User ID=AgileDB21B1;Password=AgileDB21B1#");

            try
            {
                if (DataGridEditStoreItems.SelectedItems.Count >0 )
                {
                   
                    try
                    {

                        //get unique value from Catalog
                       
                       string itemarr = ((DataRowView)(DataGridEditStoreItems.SelectedItem)).Row.ItemArray.First().ToString();
                       Debug.WriteLine(itemarr);
                   
                        sql.Open();
                        //delete record from database
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Delete from BookData Where ISBN = @str ";
                        cmd.Parameters.AddWithValue("@isbn", itemarr);
                        //delete record from the datagrid
                        ((DataRowView)(DataGridEditStoreItems.SelectedItem)).Row.Delete();
                        cmd.ExecuteScalar();
                        sql.Close();
                        updateDataGrid();
                        MessageBox.Show("Successfully Deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                        clearData();
                        
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex);
                    } 
                    
                }
                
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearData();

        }



        private void addItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into BookData(ISBN, Title," +
                    "Author, Price, Year, Edition, Publisher, CategoryID) Values(@ISBN, @Title," +
                    "@Author, @Price, @Year, @Edition, @Publisher, @CategoryID)", sql);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ISBN", isbn_txt.Text);
                cmd.Parameters.AddWithValue("@Title", title_txt.Text);
                cmd.Parameters.AddWithValue("@Author", author_txt.Text);
                cmd.Parameters.AddWithValue("@Year", year_txt.Text);
                cmd.Parameters.AddWithValue("@Edition", edition_txt.Text);
                cmd.Parameters.AddWithValue("@Publisher", publisher_txt.Text);
                cmd.Parameters.AddWithValue("@Price", price_txt.Text);
                cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(categoryid_txt.Text));

                sql.Open(); 
                cmd.ExecuteNonQuery();
                sql.Close();
                updateDataGrid();
                MessageBox.Show("Successfully Added", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                clearData();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void clearData()
        {
            title_txt.Clear();
            author_txt.Clear();
            publisher_txt.Clear();
            price_txt.Clear();
            edition_txt.Clear();
            year_txt.Clear();
            isbn_txt.Clear();
           
        }

        private void DataGridEditStoreItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this.DataGridEditStoreItems.ItemsSource = null;
                DataRowView selectedRow = (DataRowView)this.DataGridEditStoreItems.SelectedItems[0];
                        
                dsBookCat = bookCat.GetBookInfo();
                this.DataContext = dsBookCat.Tables["Book"];
               
                this.DataGridEditStoreItems.ItemsSource = dsBookCat.Tables["Book"].DefaultView;

            }
            catch (Exception)
            { }

        }
    }
}
