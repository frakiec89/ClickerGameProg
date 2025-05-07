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
        BookService bookService;
        SaveService SaveService;
        StudyService StudyService;
        User user;
        ListWindow listWindow;
        public MainWindow()
        {
            InitializeComponent();
            user = GetTestUser();
            this.Loaded += MainWindow_Loaded;
            btnRun.Click += BtnRun_Click;
            btnSave.Click += BtnSave_Click;
            btnBooks.Click += BtBooks_Click;
            btnStudy.Click += BtnStudy_Click;
            bookService = new BookService();
            SaveService =new SaveService();
            StudyService =new StudyService();
        }

        private void BtnStudy_Click(object sender, RoutedEventArgs e)
        {
            listWindow = new ListWindow(StudyService.MyListView(user), Study);
            listWindow.ShowDialog();
            gridUser.DataContext = null;
            gridUser.DataContext = user;

            string Study(object arg)
            {
                var e = arg as Education;

                if (user.Education == null && e.Lavel > 1)
                {
                    return $"вы не можите поступить в {e.Name}";
                }

                if (user.Education != null)
                {
                    if (e.Lavel - user.Education.Lavel > 1)
                        return $"вы не можите поступить в {e.Name}";
                }

                user.Stydy = new Stydy {  education = e, Status = true };

                listWindow.Views = StudyService.MyListView(user);
                return "вы  поступили";
            }
        }

        private void BtBooks_Click(object sender, RoutedEventArgs e)
        {
            listWindow = new ListWindow(bookService.GetMyListViews(user) , ByeBook);
            listWindow.ShowDialog();
            gridUser.DataContext = null;
            gridUser.DataContext = user;
        }

        private string ByeBook (object book )
        {
            var  b  = book as Book;

            if(user.Cash >= b.Price)
            {
                user.Books.Add(b);
                user.Cash -=b.Price;
                user.Experience += b.Experience;

                listWindow.Views = bookService.GetMyListViews(user);
             
                return "Книга куплена";
            }
            else
            {
                return "У вас не хватает денег";
            }
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
            SaveService = new SaveService();
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            var sl =  SaveService.MyListView();
            listWindow = new ListWindow(sl , RunFunc , DeleteFunc);
            listWindow.ShowDialog();

            string RunFunc(object save)
            {
                Save s = save as Save;
                var jsUser = File.ReadAllText(s.Path);
                user = JsonConvert.DeserializeObject<User>(jsUser);
                gridUser.DataContext = user;
                return "Успешно";
            }

            string DeleteFunc(object save)
            {
                var s = save as Save;
                File.Delete(s.Path);
                SaveService = new SaveService();
                listWindow.Views = SaveService.MyListView();
                return "Успешно";
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

            user.GameOver((x) => MessageBox.Show(x));

            if (user.GameIver)
            {
                this.Title = "ВСЕЕЕЕ";
                return;
            }


            if(user.Stydy!=null  && user.Stydy.Status==true)
            {
                user.Stydy.GoStudy();
                if (user.Stydy.IsEnd())
                {
                    user.Education = user.Stydy.education;
                    MessageBox.Show($"Вы закончили {user.Education}");
                    user.Stydy.Status = false;
                }
            }

            user.GameOver((x)=>MessageBox.Show(x));
            
            user.Experience++;
            user.Cash--;
            gridUser.DataContext = null; 
            gridUser.DataContext = user;
        }
    }
}
