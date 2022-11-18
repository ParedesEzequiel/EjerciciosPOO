using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_05_sep8
{
    public class Serie : Entregable
    {
        string titulo;
        int temporadas = 3;
        bool entregado = false;
        string genero;
        string creador;

        public Serie()
        {

        }

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.creador = creador;
        }

        public Serie(string titulo, string creador, int temporadas, string genero)
        {
            this.titulo = titulo;
            this.creador = creador;
            this.temporadas = temporadas;
            this.genero = genero;
        }
        public string Titulo
        {
            get
            {
                return titulo;
            }
        }

        public int Temporadas
        {
            get
            {
                return temporadas;
            }
        }

        public bool Entregado
        {
            get
            {
                return entregado;
            }
        }

        public string Genero
        {
            get
            {
                return genero;
            }
        }

        public string Creador
        {
            get
            {
                return creador;
            }
        }

        public void mostrarInfoSerie()
        {
            Console.WriteLine(titulo + " fue creado por " + creador + " tiene " + temporadas + " temporadas y pertenece al género " + genero);
        }

        public void entregar()
        {
            entregado = true;
        }

        public void devolver()
        {
            entregado = false;
        }

        public bool isEntregado()
        {
            return entregado;
        }

        public void compareTo(Object a)
        {
            var serie = (Serie)a;

            if (serie.Temporadas > 3)
            {
                mostrarInfoSerie();
            }
        }

    }

    public class Videojuego : Entregable
    {
        int horasEstimadas = 10;
        public bool entregado = false;
        string compania;

        public Videojuego()
        {

        }

        public Videojuego(string titulo, int horasEstimadas)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
        }

        public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.Genero = genero;
            this.compania = compania;
        }
        public string titulo { get; set; }

        public int HorasEstimadas { get; set; } = 10;
        public string Genero { get; set; }
        public string Compania { get; set; }

        public void mostrarInfoJuego()
        {
            Console.WriteLine(titulo + " tiene " + horasEstimadas + " horas estimadas de uso, pertenece al género " + Genero + " y fue desarrollado por la compañia " + compania);
        }

        public void mostrarInfoJuegoMasHorasEstimadas()
        {
            Console.WriteLine(titulo + " tiene " + horasEstimadas + " horas estimadas de uso, pertenece al género " + Genero + " y fue desarrollado por la compañia " + compania);
        }

        public void entregar()
        {
            this.entregado = true;
        }

        public void devolver()
        {
            entregado = false;
        }

        public bool isEntregado()
        {
            return entregado;
        }

        public void compareTo(Object a)
        {
            var videojuego = (Videojuego)a;

            if (videojuego.horasEstimadas > 10)
            {
                mostrarInfoJuegoMasHorasEstimadas();
            }
        }
    }

    interface Entregable
    {
        void entregar();
        void devolver();
        bool isEntregado();
        void compareTo(Object a);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Serie serie1 = new Serie("serie1", "creador1", 2, "genero1");
            Serie serie2 = new Serie("serie2", "creador2", 1, "genero2");
            Serie serie3 = new Serie("serie3", "creador3", 4, "genero3");
            Serie serie4 = new Serie("serie4", "creador4", 3, "genero4");
            Serie serie5 = new Serie("serie5", "creador5", 7, "genero5");
            Serie serie6 = new Serie("serie6", "creador6", 1, "genero6");

            Videojuego videojuego1 = new Videojuego("juego1", 20, "genero1", "compania1");
            Videojuego videojuego2 = new Videojuego("juego2", 10, "genero2", "compania2");
            Videojuego videojuego3 = new Videojuego("juego3", 16, "genero3", "compania3");
            Videojuego videojuego4 = new Videojuego("juego4", 4, "genero4", "compania4");
            Videojuego videojuego5 = new Videojuego("juego5", 2, "genero5", "compania5");
            Videojuego videojuego6 = new Videojuego("juego6", 8, "genero6", "compania6");

            Serie[] serie = { serie1, serie2, serie3, serie4, serie5, serie6 };

            Videojuego[] videojuegos = { videojuego1, videojuego2, videojuego3, videojuego4, videojuego5, videojuego6 };

            Console.WriteLine("Los videojuegos disponibles son:");
            Console.WriteLine("");
            videojuego1.entregar();
            videojuego1.mostrarInfoJuego();
            Console.WriteLine("");
            videojuego2.devolver();
            videojuego2.mostrarInfoJuego();
            Console.WriteLine("");
            videojuego3.entregar();
            videojuego3.mostrarInfoJuego();
            Console.WriteLine("");
            videojuego4.isEntregado();
            videojuego4.mostrarInfoJuego();
            Console.WriteLine("");
            videojuego5.devolver();
            videojuego5.mostrarInfoJuego();
            Console.WriteLine("");
            videojuego6.entregar();
            videojuego6.mostrarInfoJuego();

            Console.WriteLine("Las series disponibles son:");
            Console.WriteLine("");
            serie1.devolver();
            serie1.mostrarInfoSerie();
            Console.WriteLine("");
            serie2.entregar();
            serie2.mostrarInfoSerie();
            Console.WriteLine("");
            serie3.devolver();
            serie3.mostrarInfoSerie();
            Console.WriteLine("");
            serie4.isEntregado();
            serie4.mostrarInfoSerie();
            Console.WriteLine("");
            serie5.entregar();
            serie5.mostrarInfoSerie();
            Console.WriteLine("");
            serie6.entregar();
            serie6.mostrarInfoSerie();

            int juegosEntregados = 0;
            int juegosNoEntregados = 0;
            int seriesEntregadas = 0;
            int seriesNoEntregadas = 0;

            for (int i = 0; i < videojuegos.Length; i++)
            {
                if (videojuegos[i].entregado)
                {
                    juegosEntregados++;
                }
                else
                {
                    juegosNoEntregados++;
                }
            }

            for (int i=0; i < serie.Length; i++)
            {
                if (serie[i].Entregado)
                {
                    seriesEntregadas++;
                }
                else
                {
                    seriesNoEntregadas++;
                }
            }

            Console.WriteLine("Los juegos entregados son: " + juegosEntregados);
            Console.WriteLine("Los juegos no entregados son: " + juegosNoEntregados);
            Console.WriteLine("Las series entregadas son: " + seriesEntregadas);
            Console.WriteLine("Las series no entregadas son: " + seriesNoEntregadas);

            Console.ReadKey();
        }
    }
}
