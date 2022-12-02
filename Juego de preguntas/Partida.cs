using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas
{   
    class Partida : INotifyCollectionChanged, INotifyPropertyChanged
    {
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Random semilla = new Random();
        private ObservableCollection<Pregunta> preguntasPartida;

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ObservableCollection<Pregunta> PreguntasPartida
        {
            get { return preguntasPartida; }
            set { preguntasPartida = value;
                this.NotifyPropertyChanged("PreguntasPartida");
            }
        }

        public Partida(Dificultad dificultad)
        {
            Preguntas = Pregunta.GetSamples();
            
            List<Pregunta> Arte = Preguntas.Where(n => n.Categoria == Categoria.Arte && n.Dificultad == dificultad).ToList();
            List<Pregunta> Geografia = Preguntas.Where(n => n.Categoria == Categoria.Geografia && n.Dificultad == dificultad).ToList();
            List<Pregunta> Historia = Preguntas.Where(n => n.Categoria == Categoria.Historia && n.Dificultad == dificultad).ToList();
            List<Pregunta> Musica = Preguntas.Where(n => n.Categoria == Categoria.Musica && n.Dificultad == dificultad).ToList();

            PreguntasPartida = new ObservableCollection<Pregunta>();
            PreguntasPartida.Add(Arte[semilla.Next(0, Arte.Count - 1)]);
            PreguntasPartida.Add(Geografia[semilla.Next(0, Geografia.Count - 1)]);
            PreguntasPartida.Add(Historia[semilla.Next(0, Historia.Count - 1)]);
            PreguntasPartida.Add(Musica[semilla.Next(0, Musica.Count - 1)]);
        }
        private ObservableCollection<Pregunta> preguntas;

        public ObservableCollection<Pregunta> Preguntas
        {
            get { return preguntas; }
            set
            {
                preguntas = value;
                this.NotifyPropertyChanged("Preguntas");
            }
        }
    }
}
