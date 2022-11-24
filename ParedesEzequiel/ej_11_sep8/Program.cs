using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_11_sep8
{
    public class Jugador
    {
        string nombre;
        double dinero;
        int porras;
        public string[] resultado;
        public const int numeroJornadas = 3;
        public const int partidosNumero = 2;
        public const double dineroInicial = 35;
        public const int dineroPorPartido = 10;
        public const int resultadoPartidoMinimo = 0;
        public const int resultadoPartidoMaximo = 3;
        public static Jugador[] jugadores = { new Jugador("Gerardo"), new Jugador("Mariano"), new Jugador("Claudio"), new Jugador("Teófilo") };

        public Jugador(string nombre)
        {
            this.nombre = nombre;
            this.dinero = dineroInicial;
            this.porras = 0;
            this.resultado = new string[partidosNumero];
        }

        public Jugador()
        {

        }
        public void reiniciarResultados()
        {

            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                resultado[i] = "";
            }

        }
        public bool tieneDinero()
        {
            if (dinero >= dineroPorPartido)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void apostarDinero()
        {
            dinero = dinero - dineroInicial;
            Console.WriteLine("El jugador " + nombre + " ha apostado " + dineroPorPartido + " pesos, quedándole " + dinero);
        }

        public void ganarApuesta(double apuesta)
        {
            dinero = dinero + apuesta;
            porras++;
            Console.WriteLine("El jugador " + nombre + " ha ganado " + apuesta + " pesos, quedándole " + dinero);
        }

        public void generarResultados()
        {
            int golesLocal;
            int golesVisitante;

            for (int i=0; i < resultado.Length; i++)
            {
                golesLocal = Metodos.randomNum(resultadoPartidoMinimo, resultadoPartidoMaximo);
                golesVisitante = Metodos.randomNum(resultadoPartidoMinimo, resultadoPartidoMaximo);

                resultado[i] = golesLocal + " - " + golesVisitante;
                Console.WriteLine("El jugador " + nombre + " ha elegido el resultado " + resultado[i]);
            }
            Console.WriteLine("");
            
        }
        public bool acertoApuesta(string[] resultado)
        {
            
            for (int i = 0; i < resultado.Length; i++)
            {
                if (!resultado[i].Equals(resultado[i]))
                {
                    return false;
                }
            }
            return true;

        }


    }
    public class Porra : Jugador
    {
       
        double bote;

        public Porra() 
        {
            bote = 0;
        }

        public void aumentarApuestaAcumulada(double dinero)
        {
            bote += dinero;
        }

        public void vaciarApuestaAcumulada()
        {
            bote = 0;
        }
        public void jornadas()
        {
            Resultado resultados = new Resultado();
            string[] partidos;

            for(int i = 0; i < numeroJornadas; i++)
            {
                Console.WriteLine("Jornada N° " + (i+1));
                Console.WriteLine("");

                for (int j = 0; i < jugadores.GetLength(0); i++)
                {
                    if (jugadores[j].tieneDinero())
                    {
                        jugadores[j].apostarDinero();
                        jugadores[j].generarResultados();
                        aumentarApuestaAcumulada(dineroPorPartido);
                    }
                    else
                    {
                        jugadores[j].reiniciarResultados();
                    }
                }

                resultados.generarResultados();
                partidos = resultados.getPartidos();

                for (int j = 0; j < jugadores.GetLength(0); j++)
                {
                    if (jugadores[j].acertoApuesta(partidos))
                    {
                        jugadores[j].ganarApuesta(bote);
                        vaciarApuestaAcumulada();
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("");
            }
            
        }
    }

    public class Metodos
    {
        public static Random rnd = new Random();

        public static int randomNum(int minimo, int maximo)
        {
            int num = rnd.Next(minimo, maximo);
            return num;
        }
    }

    public class Resultado
    {
        string[] partidos;
        public int partidosNumero = 2;
        public double dineroInicial = 35;
        public int dineroPorPartido = 10;
        public int resultadoPartidoMinimo = 0;
        public int resultadoPartidoMaximo = 3;
        public Resultado()
        {
            partidos = new string[partidosNumero];
        }

        public void generarResultados()
        {
            int golesLocal;
            int golesVisitante;

            for (int i = 0; i < partidos.GetLength(0); i++)
            {
                golesLocal = Metodos.randomNum(resultadoPartidoMinimo, resultadoPartidoMaximo);
                golesVisitante = Metodos.randomNum(resultadoPartidoMinimo, resultadoPartidoMaximo);

                partidos[i] = golesLocal + " - " + golesVisitante;
                Console.WriteLine("El partido " + (i+1) + " tuvo el resultado " + partidos[i]);
            }
            
        }
        public string[] getPartidos()
        {
            return partidos;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Porra porra = new Porra();
            porra.jornadas();
            Console.ReadKey();
        }
    }
}
