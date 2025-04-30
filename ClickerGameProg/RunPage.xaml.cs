using System;
using System.IO;
using System.Linq;
using System.Windows;
// track

namespace ClickerGameProg
{
    /// <summary>
    /// Логика взаимодействия для RunPage.xaml
    /// </summary>
    public partial class RunPage : Window
    {
        public string Path { get; set; }
        public bool IsRun { get; set; }
        public RunPage()
        {
            InitializeComponent();
            btnRun.Click += BtnRun_Click;
            IsRun = false;
            Loaded += RunPage_Loaded;
        }

        private void RunPage_Loaded(object sender, RoutedEventArgs e)
        {
            string basePath = @$"{AppDomain.CurrentDomain.BaseDirectory}\save";

            var  getFiles = Directory.GetFiles(basePath).ToList();

            if(getFiles.Count > 0 )
                lbRun.ItemsSource = getFiles;



        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            if(lbRun.SelectedItem != null)
            {
                Path = lbRun.SelectedItem.ToString();
                IsRun = true;
                this.Close();
            }
        }
    }
}
