using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
// track

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
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            MyInputMessage message = new MyInputMessage("Укажите название сохранениия");
            message.ShowDialog();
            
            if (message.IsTrye == false)
                return;

            string jsUser = JsonConvert.SerializeObject(user);

            string basePath = AppDomain.CurrentDomain.BaseDirectory; 
            string saveFolder = Path.Combine(basePath, "save");

            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);

            string filePath = Path.Combine(saveFolder, $"{message.Content}.txt");
            File.WriteAllText(filePath, jsUser);

            File.WriteAllText($@"save//{message.Content}.txt", jsUser);
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {

            RunPage runPage = new RunPage();
            runPage.ShowDialog();

            if(runPage.IsRun == true)
            {
                var jsUser = File.ReadAllText(runPage.Path);
                user = JsonConvert.DeserializeObject<User>(jsUser);
                gridUser.DataContext = user;
            }

           
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
            gridUser.DataContext = null; 
            gridUser.DataContext = user;
        }
    }
}
