using System.Collections.Generic;

namespace ClickerGameProg
{
    internal class StudyService
    {
        public List<Education> Educations = new List<Education>()
        {
            new Education(){ PathImage=@"/Image\s.png" , Lavel = 1 , Name = "Школа" , CountDAY = 5 } ,
            new Education(){ PathImage=@"/Image\c.png" , Lavel = 2 , Name = "Коллед" , CountDAY = 10  } ,
            new Education(){ Lavel = 3 , Name = "Универ" , CountDAY =10 }
        };

        public List<MyListView> MyListView(User user)
        {
            List<MyListView> list = new List<MyListView>();

            foreach (var item in Educations)
            {
                var l = new MyListView();
                l.PathImage = item.PathImage;
                l.Name = item.Name;
                l.Value = item.CountDAY.ToString() + " Дней";
                l.Message = "Поступить";
                l.IsEnabled = true;
                l.MyObject = item;
                
                l.IsDelete = "Collapsed";

                if (user.Education != null)
                {
                    if (user.Education.Lavel >= item.Lavel)
                    {   
                        l.Message = "Не актуально";
                        l.IsEnabled = false;
                    }
                }

                if (user.Stydy != null && user.Stydy.education == item)
                {
                    l.Message = "вы учитесь";
                    l.IsEnabled = false;
                }

                if (user.Stydy != null && user.Stydy.education == item && user.Stydy.Status == false)
                {
                    l.Message = "вы заночили";
                    l.IsEnabled = false;
                }


                list.Add(l);
            }
            return list;
        }
    }
}