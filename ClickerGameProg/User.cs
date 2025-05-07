using System;
using System.Collections.Generic;
// track
namespace ClickerGameProg
{
    public class BaseObject
    {
        private const string _pathEmpty = @"/Image\No.jpg";
        private string _pathImage = string.Empty;
        public string Name { get; set; }

        public bool GameIver { get; set; }
        public string PathImage
        {
            get
            {
                if (_pathImage == string.Empty)
                    return _pathEmpty;
                else
                    return _pathImage;
            }
            set => _pathImage = value;
        }
    }

    public class User : BaseObject
    {
        
        /// <summary>
        /// опыт
        /// </summary>
        public double Experience
        {
           get ; set;
        }
        public double Cash {  get; set; }   
        public StatusUser StatusUser { get; set; }  
        public Education Education { get; set; } 

        /// <summary>
        /// Учиться
        /// </summary>
        public Stydy Stydy { get; set; }


        /// <summary>
        /// метод меняет статус пользователя
        /// </summary>
        /// <param name="status"></param>
        /// <exception cref="Exception">Если не хватает показателей </exception>
        public void ApplyNewStatus (StatusUserType status )
        {
            switch (status)
            {
                case StatusUserType.Junior: 
                    var j = new Junior();
                    if (j.Available(this) == true)
                        StatusUser = j;
                    else
                        throw new Exception($"Вы не можете претендовать на должность {j.Name}");
                    break;

                case StatusUserType.Midle:

                    var us = new Midle();
                    if (us.Available(this) == true)
                        StatusUser = us;
                    else
                        throw new Exception($"Вы не можете претендовать на должность {us.Name}");
                    break;
                default:
                    break;
            }
        }

        public List<Book> Books { get; set; } = new List<Book>();


        public void GameOver (Action<string> message)
        {
            if (Cash < 0)
            {
                message("Деньги закончились");
                GameIver = true;
            }
        }
    }

    public class Stydy
    {
        public bool Status {  get; set; }
        public Education education;
        public int StatusDay { get; private set; } = 0;

        public void GoStudy ()
        {
            StatusDay++;
        }

        public bool IsEnd ()
        {
            if (StatusDay >= education.CountDAY)
                return true;
            return false;
        }
    }
}
