using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace ClickerGameProg
{
    public class Save : BaseObject
    {
        public DateTime Date { get; set; }
        public string Path { get; set; }

    }


    public class SaveService : BaseObject
    {
        List<Save> Saves { get; set; } = new List<Save>();

        public SaveService ()
        {
            string basePath = @$"{AppDomain.CurrentDomain.BaseDirectory}\save";

            var getFiles = Directory.GetFiles(basePath).ToList();

            foreach (var item in getFiles)
            {
                FileInfo fileInfo = new FileInfo(item);

                var s = new Save()
                {
                    Date = fileInfo.CreationTime,
                    Name = fileInfo.Name,
                    Path = item
                };

                Saves .Add(s);
            }
            Saves = Saves.OrderBy(s => s.Date).ToList();
        }

        public List <MyListView> MyListView ()
        {
            List <MyListView>  list = new List<MyListView>();

            foreach (var item in Saves)
            {
                var l = new MyListView();
                l.Name = item.Name;
                l.Value = item.Date.ToShortDateString();
                l.Message = "Загрузить";
                l.IsEnabled = true;
                l.MyObject = item;
                list.Add(l);
            }
            return list;
        }
    }
}
