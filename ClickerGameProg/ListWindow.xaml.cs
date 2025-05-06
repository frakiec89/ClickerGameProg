using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ClickerGameProg
{
    /// <summary>
    /// Логика взаимодействия для ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {

        public Func<Object , string > Func {  get; set; }
        public Func<Object , string > FuncDelete {  get; set; }
        public List<MyListView> Views {  get; set; }

        public ListWindow(List<MyListView> views , Func<Object, string> func  , Func<Object, string> funcDelete = null)
        {
            InitializeComponent();
            Views = views;
            Func = func;
            FuncDelete = funcDelete;
            list.ItemsSource = Views;
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            
            var b = e.OriginalSource as Button;
            var r = b.DataContext as MyListView;

            if ( r != null )
            {
               MessageBox.Show ( Func(r.MyObject));
               list.ItemsSource = Views;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var b = e.OriginalSource as Button;
            var r = b.DataContext as MyListView;

            if (r != null && FuncDelete!=null)
            {
                MessageBox.Show(FuncDelete(r.MyObject));
                list.ItemsSource = Views;
            }
        }
    }
}
