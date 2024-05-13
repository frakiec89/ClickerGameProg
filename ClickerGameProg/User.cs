using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

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

    }
}
