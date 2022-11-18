using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio10
{
    public class Metodos
    {
        public static Random rnd = new Random();

        public static int randomNum(int minimo, int maximo)
        {
            int num = rnd.Next(minimo, maximo);
            return num;
        }
    }

    public class Carta
    {

        private int numero;
        private string palo;

        public static int maxnum = 12;
        public static string[] palosDisponibles = { "Oros", "Bastos", "Copas", "Espadas" };

        public Carta(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }
    }

    public class Baraja
    {

        private Carta[] carta;
        private int siguienteeCarta;

        public static int cantCartas = 40;

        public Baraja()
        {
            this.carta = new Carta[cantCartas];
            this.siguienteeCarta = 0;
            crearBaraja();
            barajar();
        }

        private void crearBaraja()
        {
            string[] palos = Carta.palosDisponibles;

            for (int i = 0; i < palos.Length; i++)
            {
                for (int j = 0; j < Carta.maxnum; j++)
                {
                    if (!(j == 7 || j == 8))
                    {
                        if (j >= 9)
                        {
                            carta[((i * (Carta.maxnum - 2)) + (j - 2))] = new Carta(j + 1, palos[i]);
                        }
                        else
                        {
                            carta[((i * (Carta.maxnum - 2)) + (j))] = new Carta(j + 1, palos[i]);
                        }
                    }
                }
            }
        }

        public void barajar()
        {
            int posAleatoria = 0;
            Carta c;

            for (int i = 0; i < carta.Length; i++)
            {
                posAleatoria = Metodos.randomNum(0, cantCartas - 1);
                c = carta[i];
                carta[i] = carta[posAleatoria];
                carta[posAleatoria] = c;
            }
            this.siguienteeCarta = 0;
        }

        public Carta siguienteCarta()
        {
            Carta c = null;

            if (siguienteeCarta == cantCartas)
            {
                Console.WriteLine("Ya no hay mas cartas, barajea de nuevo");
            }
            else
            {
                c = carta[siguienteeCarta++];
            }

            return c;
        }

        public Carta[] darCartas(int numCartas)
        {

            if (numCartas > cantCartas)
            {
                Console.WriteLine("No se pueden dar mas cartas");
            }
            else if (cartasDisponible() < numCartas)
            {
                Console.WriteLine("No hay suficientes cartas");
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

        public int cartasDisponible()
        {
            return cantCartas - siguienteeCarta;
        }

        public void cartasMonton()
        {
            if (cartasDisponible() == cantCartas)
            {
                Console.WriteLine("No se ha sacado ninguna carta");
            }
            else
            {
                int cantCartass = 0;
                for (int i = 0; i < siguienteeCarta; i++)
                {
                    cantCartass++;
                }
                Console.WriteLine(cantCartass);
            }
        }

        public void mostrarBaraja()
        {
            if (cartasDisponible() == 0)
            {
                Console.WriteLine("No hay cartas que mostrar");
            }
            else
            {
                for (int i = siguienteeCarta; i < carta.Length; i++)
                {
                    Console.WriteLine(carta[i]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Baraja b = new Baraja();

            Console.WriteLine("Cartas disponibles: " + b.cartasDisponible());
            b.siguienteCarta();
            b.darCartas(14);
            Console.WriteLine("Cartas disponibles: " + b.cartasDisponible());
            Console.WriteLine("Cartas sacadas por ahora: ");
            b.cartasMonton();

            b.barajar();

            Carta[] c = b.darCartas(19);
            Console.WriteLine("Cartas sacadas despues de barajar: ");

            int cantCartass = 0;

            for (int i = 0; i < c.Length; i++)
            {
                cantCartass++;
            }

            Console.WriteLine(cantCartass);

            Console.ReadKey();
        }
    }
}