using System.DirectoryServices.ActiveDirectory;

namespace ClickerGameProg
{
    public abstract class  StatusUser : BaseObject
    {
        protected double _minExperience;
        public abstract bool Available( User user);

        public override string ToString()
        {
            return $"Статус игрока {Name}: ";
        }
    }

    public class Junior  : StatusUser
    {
        public Junior ()
        {
            _minExperience = 100 ;
        }

        public override bool Available(User us)
        {

            // todo  - добавить образование 

            if ( us.Experience < _minExperience)
                return false;
            else
                return true ;
        }

        public override string ToString()
        {
            return base.ToString() + "Джун (начинаюший программист разработчик)" ;
        }
    }

}