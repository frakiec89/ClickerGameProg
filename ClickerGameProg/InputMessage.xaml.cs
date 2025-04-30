using System.Windows;

// track
namespace ClickerGameProg
{
    /// <summary>
    /// Логика взаимодействия для InputMessage.xaml
    /// </summary>
    public partial class MyInputMessage : Window
    {
        public string Content  { get; set; }
        public bool IsTrye {  get; set; }

        public MyInputMessage(string message)
        {
            InitializeComponent();
            labelMesaage.Content = message;
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
           Content = tbContent.Text;
           IsTrye = true;
           this.Close();
        }
    }
}
