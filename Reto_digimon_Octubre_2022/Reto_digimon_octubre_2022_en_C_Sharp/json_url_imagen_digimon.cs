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
using System.Text.Json;
using System.Text.Json.Serialization;


namespace url_digimon_nombre
{
    public class Url_Api_digimon
    {
        public static string href= "Error url";
        public static string GetContenidoJsonWeb(string digimon)
        {
            string baseUri = "https://www.digi-api.com/api/v1/digimon/" + digimon;
            try
                { var textFromFile_control = (new WebClient()).DownloadString(baseUri); href = ""; }
            catch
                { MessageBox.Show("Hay un error en el nombre o en la web"); }
            if (href != "Error url") //"https://digimon-api.com/images/digimon/w/Garummon.png"
            {
                var textFromFile = (new WebClient()).DownloadString(baseUri);
                //MessageBox.Show(textFromFile);
                using (JsonDocument doc = JsonDocument.Parse(textFromFile))
                {
                    JsonElement root = doc.RootElement;
                    JsonElement images = root.GetProperty("images");
                    JsonElement hrefobj = images[0].GetProperty("href");
                    href = hrefobj.GetString();
                }
            }
           return href;
        }
    }
}