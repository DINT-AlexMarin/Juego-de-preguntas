using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Juego_de_preguntas
{
    class JuegoPreguntasVM : INotifyCollectionChanged, INotifyPropertyChanged
    {
        Random semilla = new Random();
        int numPregunta = 0;
        Partida partida;
        private string dificultadElegida;
        private Image categoriaArte;

        public Image CategoriaArte
        {
            get { return categoriaArte; }
            set { categoriaArte = value;
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
            CategoriaArte = new Image();
            CategoriaArte.Source = new BitmapImage(new Uri("./assets/arteCat.jpg", UriKind.Relative));
            CategoriaMusica = new Image();
            CategoriaMusica.Source = new BitmapImage(new Uri("./assets/musicaCat.jpg", UriKind.Relative));
            CategoriaGeografia = new Image();
            CategoriaGeografia.Source = new BitmapImage(new Uri("./assets/geografiaCat.jpg", UriKind.Relative));
            CategoriaHistoria = new Image();
            CategoriaHistoria.Source = new BitmapImage(new Uri("./assets/historiaCat.jpg", UriKind.Relative));
            DificultadElegida = "Facil";
            Dificultades = new ObservableCollection<string>();
            Dificultad dificultad = Dificultad.Facil;
            partida = new Partida(dificultad);
            PreguntaSeleccionada = partida.PreguntasPartida[numPregunta];
            Dificultades.Add("Facil");
            Dificultades.Add("Medio");
            Dificultades.Add("Dificil");


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
            switch(categoria)
            {
                case Categoria.Arte:
                    myBitmapImage.UriSource = new Uri("../../assets/arteCat.jpg", UriKind.Relative);
                    break;
                case Categoria.Musica:
                    myBitmapImage.UriSource = new Uri("../../assets/musicaCat.jpg", UriKind.Relative);
                    break;
                case Categoria.Historia:
                    myBitmapImage.UriSource = new Uri("../../assets/historiaCat.jpg", UriKind.Relative);
                    break;
                case Categoria.Geografia:
                    myBitmapImage.UriSource = new Uri("../../assets/geografiaCat.jpg", UriKind.Relative);
                    break;
            }
            
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            FormatConvertedBitmap newFormatedBitmapSource = new FormatConvertedBitmap();
            newFormatedBitmapSource.BeginInit();
            newFormatedBitmapSource.Source = myBitmapImage;
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            newFormatedBitmapSource.EndInit();
            CategoriaArte.Source = newFormatedBitmapSource;
        }
        public void siguientePregunta()
        {
            if (numPregunta < partida.PreguntasPartida.Count - 1)
            {
                numPregunta++;
                PreguntaSeleccionada = partida.PreguntasPartida[numPregunta];
            }

        }

        public void añadirPregunta(Pregunta pregunta)
        {
            partida.Preguntas.Add(pregunta);
        }

        public void nuevaPartida()
        {
            if (Enum.TryParse<Dificultad>(DificultadElegida, out Dificultad dif))
            {
                partida = new Partida(dif);
            }
            numPregunta = 0;
            PreguntaSeleccionada = partida.PreguntasPartida[numPregunta];
        }
        public void categoriaAColor()
        {
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri("./assets/arteCat.jpg", UriKind.Relative);
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            CategoriaArte.Source = myBitmapImage;
        }
    }
}

