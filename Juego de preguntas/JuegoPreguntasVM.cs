using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Juego_de_preguntas
{
    class JuegoPreguntasVM : INotifyCollectionChanged, INotifyPropertyChanged
    {
        Random semilla = new Random();
        private bool expanded;
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                expanded = value;
                this.NotifyPropertyChanged("Expanded");
            }
        }
        ObservableCollection<int> numPreguntasRealizadas = new ObservableCollection<int>();

        private ObservableCollection<string> elegirCategorias;

        public ObservableCollection<string> ElegirCategorias
        {
            get { return elegirCategorias; }
            set
            {
                elegirCategorias = value;
                NotifyPropertyChanged("ElegirCategorias");
            }
        }

        private string categoriaElegida;

        public string CategoriaElegida
        {
            get { return categoriaElegida; }
            set
            {
                categoriaElegida = value;
                NotifyPropertyChanged("CategoriaElegida");
            }
        }



        int numPregunta;
        private Partida partidaActual;

        public Partida PartidaActual
        {
            get { return partidaActual; }
            set { partidaActual = value;
                NotifyPropertyChanged("PartidaActual");
            }
        }
        ;


        private Label error;

        public Label Error
        {
            get { return error; }
            set
            {
                error = value;
                this.NotifyPropertyChanged("Error");
            }
        }

        private TextBox respuesta;
        public TextBox Respuesta
        {
            get { return respuesta; }
            set
            {
                respuesta = value;
                this.NotifyPropertyChanged("Respuesta");
            }
        }

        private string dificultadElegida;
        private Image categoriaArte;

        public Image CategoriaArte
        {
            get { return categoriaArte; }
            set
            {
                categoriaArte = value;
                this.NotifyPropertyChanged("CategoriaArte");
            }
        }
        private Image categoriaHistoria;

        public Image CategoriaHistoria
        {
            get { return categoriaHistoria; }
            set
            {
                categoriaHistoria = value;
                this.NotifyPropertyChanged("CategoriaHistoria");
            }
        }
        private Image categoriaMusica;

        public Image CategoriaMusica
        {
            get { return categoriaMusica; }
            set
            {
                categoriaMusica = value;
                this.NotifyPropertyChanged("CategoriaMusica");
            }
        }
        private Image categoriaGeografia;

        public Image CategoriaGeografia
        {
            get { return categoriaGeografia; }
            set
            {
                categoriaGeografia = value;
                this.NotifyPropertyChanged("CategoriaGeografia");
            }
        }



        public string DificultadElegida
        {
            get { return dificultadElegida; }
            set
            {
                dificultadElegida = value;
                this.NotifyPropertyChanged("DificultadElegida");
            }
        }

        public JuegoPreguntasVM()
        {
            PreguntaAñadir = new Pregunta();
            Respuesta = new TextBox();
            Error = new Label();
            ErrorAñadirPregunta = new Label();
            ErrorAñadirPregunta.Visibility = Visibility.Collapsed;
            Error.Visibility = System.Windows.Visibility.Collapsed;
            CategoriaArte = new Image();
            CategoriaArte.Source = new BitmapImage(new Uri("./assets/arteCat.jpg", UriKind.Relative));
            CategoriaMusica = new Image();
            CategoriaMusica.Source = new BitmapImage(new Uri("./assets/musicaCat.jpg", UriKind.Relative));
            CategoriaGeografia = new Image();
            CategoriaGeografia.Source = new BitmapImage(new Uri("./assets/geografiaCat.jpg", UriKind.Relative));
            CategoriaHistoria = new Image();
            CategoriaHistoria.Source = new BitmapImage(new Uri("./assets/historiaCat.jpg", UriKind.Relative));
            Dificultades = new ObservableCollection<string>();
            ElegirCategorias = new ObservableCollection<string>();
            Dificultad dificultad = Dificultad.Facil;
            partida = new Partida(dificultad);
            siguientePregunta();
            Dificultades.Add("Facil");
            Dificultades.Add("Medio");
            Dificultades.Add("Dificil");
            ElegirCategorias.Add("Geografia");
            ElegirCategorias.Add("Historia");
            ElegirCategorias.Add("Musica");
            ElegirCategorias.Add("Arte");


        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<string> dificultades;

        public ObservableCollection<string> Dificultades
        {
            get { return dificultades; }
            set
            {
                dificultades = value;
                this.NotifyPropertyChanged("Dificultades");
            }
        }

        private Pregunta preguntaSeleccionada;
        public Pregunta PreguntaSeleccionada
        {
            get { return preguntaSeleccionada; }
            set
            {
                preguntaSeleccionada = value;
                this.NotifyPropertyChanged("PreguntaSeleccionada");
            }

        }
        public void CategoriaAGris(Categoria categoria)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            switch (categoria)
            {
                case Categoria.Arte:
                    myBitmapImage.UriSource = new Uri("../../assets/arteCat.jpg", UriKind.Relative);
                    FormatConvertedBitmap n1 = colorGrisCambio(myBitmapImage);
                    CategoriaArte.Source = n1;
                    break;
                case Categoria.Musica:
                    myBitmapImage.UriSource = new Uri("../../assets/musicaCat.jpg", UriKind.Relative);
                    FormatConvertedBitmap n2 = colorGrisCambio(myBitmapImage);
                    CategoriaMusica.Source = n2;
                    break;
                case Categoria.Historia:
                    myBitmapImage.UriSource = new Uri("../../assets/historiaCat.jpg", UriKind.Relative);
                    FormatConvertedBitmap n3 = colorGrisCambio(myBitmapImage);
                    CategoriaHistoria.Source = n3;
                    break;
                case Categoria.Geografia:
                    myBitmapImage.UriSource = new Uri("../../assets/geografiaCat.jpg", UriKind.Relative);
                    FormatConvertedBitmap n4 = colorGrisCambio(myBitmapImage);
                    CategoriaGeografia.Source = n4;
                    break;
            }



        }

        public FormatConvertedBitmap colorGrisCambio(BitmapImage myBitmapImage)
        {
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = myBitmapImage;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatedBitmapSource.EndInit();
            return newFormatedBitmapSource;
        }
        public void siguientePregunta()
        {
            int value = semilla.Next(0, 4);
            while (numPreguntasRealizadas.Contains(value) && numPreguntasRealizadas.Count < 4)
            {
                value = semilla.Next(0, 4);
            }
            if (numPreguntasRealizadas.Count >= 4)
            {
                MessageBox.Show("Has ganado", "GANADOR");
            }
            else
            {
                numPregunta = value;
                numPreguntasRealizadas.Add(value);
                PreguntaSeleccionada = partida.PreguntasPartida[numPregunta];
            }


        }
        private Label errorAñadirPregunta;

        public Label ErrorAñadirPregunta
        {
            get { return errorAñadirPregunta; }
            set
            {
                errorAñadirPregunta = value;
                NotifyPropertyChanged("ErrorAñadirPregunta");
            }
        }


        public void examinarArchivos()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                PreguntaAñadir.Imagen = filename;
            }
        }

        public void añadirPregunta()
        {

            if (PreguntaAñadir.PreguntaTexto == null || PreguntaAñadir.Respuesta == null || preguntaAñadir.Imagen == null)
            {
                ErrorAñadirPregunta.Visibility = Visibility.Visible;
            }
            else
            {
                Partida.Preguntas.Add(PreguntaAñadir);
                ErrorAñadirPregunta.Visibility = Visibility.Collapsed;
                MessageBox.Show("Pregunta añadida correctamente");
            }

        }

        public void nuevaPartida()
        {
            if (Enum.TryParse<Dificultad>(DificultadElegida, out Dificultad dif))
            {
                partida = new Partida(dif);
            }
            numPreguntasRealizadas.Clear();
            siguientePregunta();
            PreguntaSeleccionada = partida.PreguntasPartida[numPregunta];
        }


        private Pregunta preguntaAñadir;

        public Pregunta PreguntaAñadir
        {
            get { return preguntaAñadir; }
            set
            {
                preguntaAñadir = value;
                NotifyPropertyChanged("PreguntaAñadir");
            }
        }


        public void LimpiarDatos()
        {
            PreguntaAñadir.Imagen = null;
            PreguntaAñadir.PreguntaTexto = null;
            PreguntaAñadir.Respuesta = null;
        }
        public void categoriaAColor()
        {
            BitmapImage myBitmapImage = colorCambio("./assets/arteCat.jpg");
            CategoriaArte.Source = myBitmapImage;
            myBitmapImage = colorCambio("./assets/geografiaCat.jpg");
            CategoriaGeografia.Source = myBitmapImage;
            myBitmapImage = colorCambio("./assets/musicaCat.jpg");
            CategoriaMusica.Source = myBitmapImage;
            myBitmapImage = colorCambio("./assets/historiaCat.jpg");
            CategoriaHistoria.Source = myBitmapImage;

        }
        public BitmapImage colorCambio(string rutaImagen)
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(rutaImagen, UriKind.Relative);
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            return myBitmapImage;
        }

        public void vaciarTexto()
        {
            Respuesta.Text = String.Empty;
        }


        public void ComprobarRespuesta()
        {
            if (Respuesta.Text.ToUpper() == PreguntaSeleccionada.Respuesta)
            {
                Error.Visibility = System.Windows.Visibility.Collapsed;
                CategoriaAGris(PreguntaSeleccionada.Categoria);
                vaciarTexto();
                Expanded = false;
                siguientePregunta();
            }
            else
            {
                vaciarTexto();
                Error.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}

