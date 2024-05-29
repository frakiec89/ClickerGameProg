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

namespace ClickerGameProg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        User user;

        public MainWindow()
        {
            InitializeComponent();
            user = GetTestUser();
            this.Loaded += MainWindow_Loaded;
        }

        private User? GetTestUser()
        {
            User user = new User() { Name = "Test", Experience = 10, Cash = 100, StatusUser = null };
            return user;    
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            gridUser.DataContext = user;
        }

        private void Button_Click_NextStatus(object sender, RoutedEventArgs e)
        {

            var b  =e.Source as Button;
            if (b != null)
            {
                try
                {
                    switch (b.Name)
                    {
                        case "btnJun": user.ApplyNewStatus(StatusUserType.Junior); break;
                        case "btnMidle": user.ApplyNewStatus(StatusUserType.Midle); break;
                        default:
                            MessageBox.Show("No"); // todo реализовать  отдельный интерфейс 
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                 gridUser.DataContext = null;
                gridUser.DataContext = user;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Experience++;
            user.Cash--;
            gridUser.DataContext = null; // todo  применить интерфейс 
            gridUser.DataContext = user;
        }
    }
}
