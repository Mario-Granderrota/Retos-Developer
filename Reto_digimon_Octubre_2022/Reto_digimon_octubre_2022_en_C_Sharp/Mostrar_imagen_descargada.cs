using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Documents;
using Reto_imagen_Digimon;

namespace Mostrar_imagen_digimon_descargada
{
    public class Mostrar_imagen_descargada
    {
        public static object Mostrar_foto_pantalla(string nombre)
        {
                BitmapImage foto = new BitmapImage();
                foto.BeginInit();
                foto.UriSource = new Uri(@"C:\Digimon_imagenes\" + nombre);
                foto.EndInit();
                foto.Freeze();
                //Imagen_digimon.Source = foto; -> desde MainWindow
                return foto;
        }

    }
}
