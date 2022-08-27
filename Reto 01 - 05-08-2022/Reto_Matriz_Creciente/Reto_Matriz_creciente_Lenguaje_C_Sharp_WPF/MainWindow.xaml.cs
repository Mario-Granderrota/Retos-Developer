using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace $safeprojectname$
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Variables necesarias
            String texto1 = Caja_texto.Text;
			//MessageBox.Show("Mensaje  " + texto1);
			//List<int> nums = new List<int>(); --- No uso listas en este ejercicio
			int total_entradas = 0;
			var coma = 0;
			var numero_comas = 0;
			var texto3 = texto1;
			if (texto1.IndexOf(",") == 0) { total_entradas = 0; MessageBox.Show("Las comas están mal puestas. Revisalás, Por favor "); return; }
			//if (texto1.IndexOf(",") != 0) { total_entradas = 1; }
			for (int i=0; i<texto1.Length; i+=1) 
				{
				if (texto3.IndexOf(",") == 0) { numero_comas += 1; }
				if (texto3.IndexOf(",") == 0 && coma == 1) { MessageBox.Show("Las comas están mal puestas. Revisalás, Por favor "); return; }
				if (texto3.IndexOf(",") == 0 && coma==0)
					{
					coma = 1;
					}
				if (texto3.IndexOf(",") != 0)
					{ 
					coma = 0;
					}
				total_entradas += coma;
				texto3 = texto3.Remove(0, 1);
				}
			
		if (numero_comas!= total_entradas || coma==1) { MessageBox.Show("Las comas están mal puestas. Revisalás, Por favor "); return; } //¿Cómo se hace el exit correctamente?
		if (coma==0) 
				{
				total_entradas += 1;
				//MessageBox.Show("Comas: " + numero_comas.ToString() + " Entradas: " + total_entradas.ToString());
				
			}
			int[] nums = new int[total_entradas];
			texto3 = texto1;
			string b = "";
			for (int i = 0; i < total_entradas; i += 1)
				{
				b = texto3;
				if (b.IndexOf(",") > 0) 
					{
					var c = b.Length;
					b = b.Remove(b.IndexOf(","), c - b.IndexOf(","));
					//MessageBox.Show(b.ToString());
					texto3 = texto3.Remove(0, texto3.IndexOf(",")+1);
					}
				//MessageBox.Show("Texto b: " + b + " Texto3: " + texto3);
				nums[i] = Int32.Parse(b);
			}
		
			int[] matriz_prueba = new int[total_entradas-1];
			bool matriz_creciente = true;
			int cantidad_fallos = 0;
			int posicion_posible_fallo = 0;
			int posicion_fallo = 0;

			if (total_entradas < 2)
				{
				MessageBox.Show("Tienes que introducir mínimo dos valores para saber si la matriz es creciente");
				return;
			}

			//Funciones		
			void scr_posibles_fallos(int[] matriz)
				{
					total_entradas = matriz.Length;
					for (int i = 0; i < total_entradas; i += 1) //
						{
						if ((i == 0) && (matriz[i + 1] < matriz[i]))
							{
							posicion_posible_fallo = i;
							cantidad_fallos += 1;
							//Analizo si el fallo es de la posición actual o de la siguiente
							}
						if ( (i > 0) && (i<total_entradas) && (matriz[i - 1] >= matriz[i]) )
							{
							if (cantidad_fallos == 0) { posicion_posible_fallo = i; }
							cantidad_fallos += 1;
							if (i == 1 && cantidad_fallos== 2)
								{ cantidad_fallos -= 1; }
							}
						}
				}

			void scr_mensaje_correccion()
				{
					//total_entradas=string_length(nums)
					total_entradas = nums.Length;
					var pos = posicion_fallo;
					var matriz_mensaje = "["; //Para escribir la matriz como parte del mensaje
					for (int i = 0; i < total_entradas; i += 1)
						{
						if (i != pos) 
							{
							var miString = nums[i].ToString();
						matriz_mensaje += miString + ","; 
							}
						if (i == total_entradas - 1)
							{
							matriz_mensaje += "]";
							matriz_mensaje = matriz_mensaje.Replace(",]", "]");
							}
						}
					var miStringA = nums[pos].ToString();
					var miStringB = pos.ToString();
					MessageBox.Show("Esta matriz sería estrictamente creciente; si eliminásemos " + miStringA + " en el índice " + miStringB + " de nums, porque se convertiría en " + matriz_mensaje);
				}

			void scr_matriz_prueba_2(int fallo)
				{
					//Usando una nueva matriz
					//matriz_prueba[0] = 0;
					total_entradas = nums.Length;
					var pos = fallo;
					var a = 0;
					for (int i = 0; i < total_entradas; i += 1)
					{
						if (i != pos)
							{
							matriz_prueba[a] = nums[i];
							a += 1;
						}
					}
				}

			//Programa principal
			scr_posibles_fallos(nums);
			if (cantidad_fallos > 1) { cantidad_fallos = 2; }
			switch (cantidad_fallos)
				{
				case 0: //Sin errores
					{
						matriz_creciente = true;
						MessageBox.Show("Esta matriz es estrictamente creciente");
						//nums = -1;
						break;
					}
				case 1: //Un error chiquitito en la matriz creciente (máximo un merror)
					{
						matriz_creciente = true;
						if (total_entradas == 2)
							{
							MessageBox.Show("Hay un error. Analiza qué dato de los dos quieres quitar.");
                            //nums = -1;
                            //break;
							}
                        if (total_entradas > 2) //Aquí recae la intringulis del problema
							{
                            posicion_fallo = posicion_posible_fallo;
                            cantidad_fallos = 0;
                            scr_matriz_prueba_2(posicion_fallo);
                            scr_posibles_fallos(matriz_prueba);
                            if (cantidad_fallos == 0) { scr_mensaje_correccion(); return; } //exit;
                            if (cantidad_fallos > 0 && posicion_posible_fallo < total_entradas)
								{
                                cantidad_fallos = 0;
                                posicion_fallo = posicion_posible_fallo + 1;
                                scr_matriz_prueba_2(posicion_fallo);
                                scr_posibles_fallos(matriz_prueba);
                                if (cantidad_fallos == 0) { scr_mensaje_correccion(); return; } //exit;
								}
                            if (cantidad_fallos > 0 && posicion_posible_fallo > 0)
								{
                                cantidad_fallos = 0;
                                posicion_fallo = posicion_posible_fallo - 1;
                                scr_matriz_prueba_2(posicion_fallo);
                                scr_posibles_fallos(matriz_prueba);
                                if (cantidad_fallos == 0) { scr_mensaje_correccion(); return; } //exit;
								}
                            if (cantidad_fallos > 0) { MessageBox.Show("Me da que esta matriz no es estrictamente creciente"); }
                            //Array.Clear(matriz_prueba, 0, nums.Length);//Borro esta matriz
                            //break;
                        }
						break;
					}
                case 2: //Matriz no creciente -> Caca de vaca
					{
						matriz_creciente = false;
						MessageBox.Show("Me da que esta matriz no es estrictamente creciente");
						break;
					}
				}
		}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
			if (System.Text.RegularExpressions.Regex.IsMatch(Caja_texto.Text, "^[0-9,]*$") ==false) //"^[0-9]*$"
			{
				MessageBox.Show("Introduce sólo números y/o comas para separarlos");
				Caja_texto.Text = string.Empty;
			}
		}
    }
}
