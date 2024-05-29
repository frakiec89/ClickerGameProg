using System.DirectoryServices.ActiveDirectory;
using System.Reflection;

namespace ClickerGameProg
{
    public abstract class  StatusUser : BaseObject
    {
        protected static double _minExperience;
        public abstract  bool Available( User user);

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
            Name = "Джун";
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

    public class Midle : StatusUser
    {
        
        public Midle ()
        {
            _minExperience = 500;
            Name = "Мидл";
        }

        public override bool Available(User us)
        {
            if (us.Experience < _minExperience)
                return false;
            else
                return true;
        }
        public override string ToString()
        {
            return base.ToString() + "Мидел (программист с опытом  разработки)";
        }
    }
}