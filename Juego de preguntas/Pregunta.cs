using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas
{
    public enum Categoria { Historia, Arte, Musica, Geografia };
    public enum Dificultad { Dificil, Medio, Facil }
    class Pregunta : INotifyPropertyChanged
    {
        public Pregunta()
        {

        }
        public Pregunta(Categoria categoria, Dificultad dificultad, string pregunta, string respuesta, string imagen)
        {
            this.Categoria = categoria;
            this.Dificultad = dificultad;
            this.PreguntaTexto = pregunta;
            this.Respuesta = respuesta;
            this.Imagen = imagen;
            this.Pista = RespuestaAPista(respuesta);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Categoria categoria;

        public Categoria Categoria
        {
            get { return categoria; }
            set { categoria = value;
                this.NotifyPropertyChanged("Categoria");
            }
        }

        private string preguntaTexto;

        public string PreguntaTexto
        {
            get { return preguntaTexto; }
            set { preguntaTexto = value;
                this.NotifyPropertyChanged("Pregunta");
            }
        }

        private Dificultad dificultad;

        public Dificultad Dificultad
        {
            get { return dificultad; }
            set { dificultad = value;
                this.NotifyPropertyChanged("Dificultad");
            }
        }

        private string respuesta;

        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value;
                this.NotifyPropertyChanged("Respuesta");
            }
        }

        private string pista;

        public string Pista
        {
            get { return pista; }
            set { pista = value;
                this.NotifyPropertyChanged("Pista");
            }
        }

        private string imagen;

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value;
                this.NotifyPropertyChanged("Imagen");
            }
        }

        public static ObservableCollection<Pregunta> GetSamples()
        {
            ObservableCollection<Pregunta> lista = new ObservableCollection<Pregunta>();
            lista.Add(new Pregunta(Categoria.Geografia, Dificultad.Facil, "¿En qué continente se encuentra Noruega?", "EUROPA", "../../assets/noruega.png"));
            lista.Add(new Pregunta(Categoria.Geografia, Dificultad.Medio, "Capital de Portugal", "LISBOA", "../../assets/portugal.jpg"));
            lista.Add(new Pregunta(Categoria.Geografia, Dificultad.Dificil, "Capital de España", "MADRID", "../../assets/españa.png"));
            lista.Add(new Pregunta(Categoria.Musica, Dificultad.Facil, "¿Quién escribío la quinta sinfonia?", "BEETHOVEN", "../../assets/musicaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Musica, Dificultad.Medio, "¿Quién escribío el Cuarteto de las Disonancias?", "MOZART", "../../assets/musicaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Musica, Dificultad.Dificil, "¿En que año nacío Beethoven?", "1770", "../../assets/musicaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Historia, Dificultad.Facil, "Nombre del imperio más grande", "IMPERIO BRITANICO", "../../assets/historiaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Historia, Dificultad.Medio, "¿En que año surgió la revolución Francesa?", "1789", "../../assets/historiaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Historia, Dificultad.Dificil, "¿Quién mató a Cesar?", "MARCO BRUTO", "../../assets/historiaPregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Arte, Dificultad.Facil, "¿Quién pintó la Mona Lisa?", "LEONARDO DA VINCI", "../../assets/artePregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Arte, Dificultad.Medio, "¿Quién pintó el Guernica?", "PABLO PICASSO", "../../assets/artePregunta.jpg"));
            lista.Add(new Pregunta(Categoria.Arte, Dificultad.Dificil, "Cuadro más famoso de Edvard Munch", "EL GRITO", "../../assets/artePregunta.jpg"));

            return lista;
        }

        public string RespuestaAPista(string respuesta)
        {
            char[] pista = respuesta.ToCharArray();
            for (int i = 0; i < pista.Length / 2; i++)
            {
                Random semilla = new Random();
                int sem = semilla.Next(0, pista.Length - 1);
                while (pista[sem] == '*')
                {
                    sem = semilla.Next(0, pista.Length - 1);
                }
                if(pista[sem] != ' ')
                {
                    pista[sem] = '*';
                }
                
            }
            string p = "";
            foreach(char c in pista)
            {
                p += c;
            }
            return p;
        }

    }
}
