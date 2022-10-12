using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Windows;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

//Esta librería es de uso personal; no se hace uso de ella en MainWindow
namespace url_digimon_name
{
    public class Url_digimon
    {
   
        public static string GetContenidoWeb(string digimon)
        {
            string baseUri = "https://www.granderrota.com/Blog/Reto_digimon/?digimon=" + digimon;
            var textFromFile = (new WebClient()).DownloadString(baseUri);
            return textFromFile;
        }
    }
}
