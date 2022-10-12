using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;



namespace Reto_imagen_Digimon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ___Descarga__Click(object sender, RoutedEventArgs e)
        {
            string digimon = Caja_texto.Text; 
            string url= url_digimon_nombre.Url_Api_digimon.GetContenidoJsonWeb(digimon);
            string nombre = digimon + ".png";
            if (File.Exists(@"C:\Digimon_imagenes\" + nombre) == true)
                { MessageBox.Show("Esta imagen ya la tienes descargada"); }
            if ((File.Exists(@"C:\Digimon_imagenes\" + nombre) == false) && (url != "Error url"))
            {
                Imagen_desde_url_name.Imagen_desde_url.descargarImagen(url, nombre);
                object foto2 = Mostrar_imagen_digimon_descargada.Mostrar_imagen_descargada.Mostrar_foto_pantalla(nombre);
                Imagen_digimon.Source = (ImageSource)foto2; //System.Windows.Media.ImageSource
            }

        }

        private void Caja_texto_TextChanged(object sender, TextChangedEventArgs e)
        {
            /* if (System.Text.RegularExpressions.Regex.IsMatch(Caja_texto.Text, "^[0-9,]*$") == false) 
             {
                 MessageBox.Show("Esto no es una URL válida");
                 Caja_texto.Text = string.Empty;
             }*/
        }

    }
}
