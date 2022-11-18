using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_10_sep8
{
    public class Metodos
    {
        public static Random rnd = new Random();
        public static int rndNumero(int minimo, int maximo)
        {
            int numero = rnd.Next(minimo, maximo);
            return numero;
        }
    }
    public class Carta
    {
        public int numero;
        string palo;
        public static string[] Palos = { "Espadas", "Oros", "Copas", "Bastos" };
        public static int limitePalos = 12;

        public Carta(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }
    }

    public class Baraja
    {
        Carta[] carta;
        public int siguienteCarta;
        public static int cantCartas = 40;

        public Baraja()
        {
            this.carta = new Carta[numCartas];
            this.siguienteCarta = 0;
            crearBaraja();
            barajar();
        }

        public void crearBaraja()
        {
            string[] palos = Carta.Palos;
            for (int i=0; i < palos.Length; i++)
            {
                for (int j = 0; j < Carta.limitePalos; j++)
                {
                    if (!(j == 7 || j == 8))
                    {
                        if (j >= 9)
                        {
                            carta[((i * (Carta.limitePalos - 2)) + (j - 2))] = new Carta(j + 1, palos[i]);
                        }
                        else
                        {
                            carta[((i * (Carta.limitePalos - 2)) + (j))] = new Carta(j + 1, palos[i]);
                        }
                    }
                }
            }
        }

        public void barajar()
        {
            int aleatorio = 0;
            Carta b;

            for (int i = 0; i < carta.Length; i++)
            {
                aleatorio = Metodos.rndNumero(0, numCartas - 1);
                b = carta[i];
                carta[i] = carta[aleatorio];
                carta[aleatorio] = b;
            }
            this.siguienteCarta = 0;
        }

        public Carta siguienteCarta()
        {
            Carta d = null;

            if (siguienteCarta == cantCartas)
            {
                Console.WriteLine("No hay más cartas, por favor, barajee de nuevo");
            }
            else
            {
                d = carta[siguienteCarta++];
            }
            return d;
        }

        public Carta[] darCartas(int numCartas)
        {
            if (numCartas > cantCartas)
            {
                Console.WriteLine("No se pueden dar más cartas.");
            }
            if (cartasDisponibles() < numCartas)
            {
                Console.WriteLine("No hay suficientes cartas.");
            }
            else
            {
                Carta[] cartasDar = new Carta[numCartas];
                for (int i = 0; i < cartasDar.Length; i++)
                {
                    cartasDar[i] = siguienteCarta();
                }
                return cartasDar;
            }
            return null;
        }

        public int cartasDisponibles()
        {
            return cantCartas - siguienteCarta;
        }

        public void cartasMonton()
        {
            if (cartasDisponibles() == cantCartas)
            {
                Console.WriteLine("No se ha sacado ninguna carta.");
            }
            else
            {
                int cantCartitas = 0;
                for (int i = 0; i < siguienteCarta; i++)
                {
                    cantCartitas++;
                }
                Console.WriteLine(cantCartitas);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
