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

namespace Juego_de_preguntas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JuegoPreguntasVM vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new JuegoPreguntasVM();
            this.DataContext = vm;
        }

        private void ValidarButton_Click(object sender, RoutedEventArgs e)
        {
            if (respuesta_textbox.Text.ToUpper() == vm.PreguntaSeleccionada.Respuesta)
            {
                Error_Label.Visibility = Visibility.Collapsed;
                switch (vm.PreguntaSeleccionada.Categoria)
                {
                    case Categoria.Arte:
                        vm.CategoriaAGris(vm.PreguntaSeleccionada.Categoria);
                        break;
                    case Categoria.Historia:
                        
                        break;
                    case Categoria.Musica:
                        
                        break;
                    case Categoria.Geografia:
                        
                        break;
                }
                respuesta_textbox.Text = String.Empty;
                expander_expander.IsExpanded = false;
                vm.siguientePregunta();
            }
            else
            {
                respuesta_textbox.Text = String.Empty;
                Error_Label.Visibility = Visibility.Visible;
            }


        }


        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            vm.nuevaPartida();
            vm.categoriaAColor();
            
        }
    }
}
