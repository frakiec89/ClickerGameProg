using System;
// track
namespace ClickerGameProg
{
    public class BaseObject
    {
        private const string _pathEmpty = "No";
        private string _pathImage;
        public string Name { get; set; }
        public string PathImage
        {
            get
            {
                if (_pathEmpty == string.Empty)
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
    }
}
