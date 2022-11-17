using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_12_sep8
{
    public class Revolver
    {
        int posicionBalaActual;
        int posicionBala;

        public Revolver()
        {
            posicionBalaActual = Metodos.generaNumeroAleatorio(1, 6);
            posicionBala = Metodos.generaNumeroAleatorio(1, 6);
        }

        public bool Disparar()
        {
            bool exito = false;
            if (posicionBala == posicionBalaActual)
            {
                exito = true;
            }

            siguienteBala();

            return exito;
        }

        public void siguienteBala()
        {
            if (posicionBalaActual == 6)
            {
                posicionBalaActual = 1;
            }
            else
            {
                posicionBalaActual++;
            }
        }
    }

    public class Jugador
    {
        int id;
        string nombre;
        bool vivo;

        public Jugador(int id)
        {
            this.id = id;
            this.nombre = "Jugador " + id;
            this.vivo = true;
        }

        public void Disparar(Revolver r)
        {
            Console.WriteLine("El " + nombre + " se apunta con la pistola.");
            if (r.Disparar())
            {
                this.vivo = false;
                Console.WriteLine(nombre + " ha muerto.");
            }
            else
            {
                Console.WriteLine(nombre + " ha sobrevivido.");
            }
        }

        public bool isVivo()
        {
            return vivo;
        }
    }

    public class Metodos
    {
        
        public static int generaNumeroAleatorio(double minimo, double maximo)
        {
            Random rnd = new Random();
            int num = (int) Math.Floor(rnd.Next() * (maximo - minimo + 1) + (minimo));
            return num;
        }
    }

    public class Juego
    {
        Jugador[] jugadores;
        Revolver revolver;

        public Juego(int numJugadores)
        {
            jugadores = new Jugador[comprobarJugadores(numJugadores)];

            crearJugadores();

            revolver = new Revolver();

        }

        private int comprobarJugadores(int numJugadores)
        {
            if (!(numJugadores >= 1 && numJugadores <= 6))
            {
                numJugadores = 6;
            }
            return numJugadores;
        }

        private void crearJugadores()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                jugadores[i] = new Jugador(i + 1);
            }
        }

        public bool finJuego()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (!jugadores[i].isVivo())
                {
                    return true;
                }
            }
            return false;
        }

        public void Ronda()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                jugadores[i].Disparar(revolver);
            }
        }

        public void Ronda2()
        {
            for (int i = 0; i < jugadores.Length; i++)
            {
                jugadores[i].Disparar(revolver);
                if (!jugadores[i].isVivo())
                {
                    return;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Juego juego = new Juego(2);

            while (!juego.finJuego())
            {
                juego.Ronda();
            }
            Console.WriteLine("El juego ha concluido.");
            Console.ReadKey();
        }
    }
}
