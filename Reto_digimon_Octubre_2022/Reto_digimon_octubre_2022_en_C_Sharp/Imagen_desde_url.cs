using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;


namespace Imagen_desde_url_name
{
    public class Imagen_desde_url
    {
            public static void descargarImagen(string UrlImagen, string nombre) 
            {
            string File_local = @"C:\Digimon_imagenes\"+ nombre;
            using (WebClient client = new WebClient())
                {
                    client.DownloadFile(UrlImagen, File_local);
                }
            }
    }
}
