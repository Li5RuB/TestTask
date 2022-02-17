using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Settings
{
    public interface IAppSettings
    {
        public string OnlinerLink { get; set; }   
        
        public string YandexLink { get; set; }    

        public string LentaLink { get; set; }

        public int NumberOfThreads { get; set; }
    }
}
