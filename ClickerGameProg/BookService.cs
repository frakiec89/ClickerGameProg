using System.Collections.Generic;
using System.Linq;

namespace ClickerGameProg
{
    internal class BookService
    {
        List<Book> books = new List<Book>()
        {
                new Book() { Name="test1" , Price=10 , Experience=5 } ,
                new Book() { Name="test2" , Price=10 , Experience=50 } ,
                new Book() { Name="test3" , Price=10 , Experience=50 } ,
                new Book() { Name="test5" , Price=10 , Experience=50 } ,
                new Book() { Name="test6" , Price=10 , Experience=15 } ,
                new Book() { Name="test7" , Price=10 , Experience=15 } ,
                new Book() { Name="test8" , Price=10 , Experience=15 } ,
                new Book() { Name="test9" , Price=10 , Experience=10 } ,
                new Book() { Name="test10" , Price=50 , Experience=25 } ,
                new Book() { Name="test11" , Price=50 , Experience=25 } ,
                new Book() { Name="test12" , Price=50 , Experience=100 } ,
                new Book() { Name="test13" , Price=50 , Experience=100 } ,
                new Book() { Name="test14" , Price=100 , Experience=1000 } ,
                new Book() { Name="test15" , Price=100 , Experience=1000 } ,
                new Book() { Name="test16" , Price=100 , Experience=1000 } ,
                new Book() { Name="test17" , Price=100 , Experience=1000 } ,
                new Book() { Name="test18" , Price=100 , Experience=1000 } ,
                new Book() { Name="test19" , Price=100 , Experience=1000 } ,
        };

        public List<MyListView> GetMyListViews (User user)
        {
            List<MyListView> myLists = new List<MyListView>();  
            
            foreach (Book book in books)
            {
                var  l = new MyListView();
                l.Name = book.Name;
                l.Value = book.Price.ToString()+" руб.";
                l.MyObject = book;
                
                if(user.Books.Any(x=>x.Name == book.Name))
                {
                    l.Message = "куплена";
                    l.IsEnabled= false;
                }
                else
                {
                    l.Message = "Купить";
                    l.IsEnabled = true;
                }
                myLists.Add(l);
            }
            return myLists;
        }
    }
}