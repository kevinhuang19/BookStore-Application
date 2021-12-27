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
using System.Windows.Threading;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            media.Source = new Uri(Environment.CurrentDirectory + @"\book.gif");
            loads();
        }
        DispatcherTimer timer = new DispatcherTimer();

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {

        }
        private void timer_tick(object sender, EventArgs e)
        {
            
            timer.Stop();
            
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }
        void loads()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();
        }
    }
}
