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
            vm.ComprobarRespuesta();
        }


        private void NuevaPartida_Click(object sender, RoutedEventArgs e)
        {
            vm.nuevaPartida();
            vm.categoriaAColor();
            
        }

        private void Examinar_Button(object sender, RoutedEventArgs e)
        {
            vm.examinarArchivos();
        }

        private void AñadirPregunta_Click(object sender, RoutedEventArgs e)
        {
            vm.añadirPregunta();
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            vm.LimpiarDatos();
        }
    }
}
