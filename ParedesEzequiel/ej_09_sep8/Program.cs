using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_09_sep8
{
    class Espectador
    {
        string nombre;
        int edad;
        int dinero;

        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public int Edad
        {
            set
            {
                edad = value;
            }
            get
            {
                return edad;
            }
        }
        public int Dinero
        {
            set
            {
                dinero = value;
            }
            get
            {
                return dinero;
            }
        }

        public Espectador(string nombre, int edad, int dinero)
        {
            Edad = edad;
            Dinero = dinero;
            Nombre = nombre;
        }
    }
    class Cine
    {
        int precio;
        Pelicula pelicula;
        public int Precio
        {
            set
            {
                precio = value;
            }
            get
            {
                return precio;
            }
        }
        public Pelicula Pelicula
        {
            set
            {
                pelicula = value;
            }
            get
            {
                return pelicula;
            }
        }

        public Cine(int precio, Pelicula peli)
        {
            Precio = precio;
            Pelicula = peli;
        }
    }
    class Sala
    {
        int columna = 0;
        int fila = 0;
        char[] letra = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public List<string> Asiento = new List<string>();
        public List<string> AsientoOcupados = new List<string>();

        static Random rnd = new Random();
        public int Columna { get { return columna; } set { columna = value; } }
        public int Fila { get { return fila; } set { fila = value; } }

        public Sala(int columna, int fila)
        {
            Columna = columna;
            Fila = fila;
            int cont = 0;
            for (int a = 0; a < fila; a++)
            {
                cont++;
                for (int b = 0; b < columna; b++)
                {
                    Asiento.Add($"{array[fila - cont]}{letra[b]}");
                }
            }
        }
        public void simulacion()
        {
            int cont = 0;
            for (int a = 0; a < fila; a++)
            {
                for (int b = 0; b < columna; b++)
                {
                    Console.Write(Asiento[cont] + "   ");
                    cont++;
                }
                Console.WriteLine("\n");
            }
        }
        public void ocuparRandom(Espectador espectador)
        {
            int probabilidad = rnd.Next(columna * fila);
            if (Asiento[probabilidad] != "ocupado")
            {
                AsientoOcupados.Add($"{Asiento[probabilidad]} ocupado por: {espectador.Nombre}");
                AsientoOcupados.Add($"{Asiento[probabilidad]} ocupado por: {espectador.Nombre}");
                Asiento.Insert(probabilidad, "ocupado");
                Asiento.RemoveAt(probabilidad + 1);
            }
            else
            {
                int cont = 0;
                foreach (string item in Asiento)
                {
                    if (Asiento[cont] != "ocupado")
                    {
                        AsientoOcupados.Add($"{Asiento[cont]} ocupado por: {espectador.Nombre}");
                        Asiento.Insert(cont, "ocupado");
                        Asiento.RemoveAt(cont + 1);
                        break;
                    }
                    cont++;
                }
            }
        }
    }
    class Pelicula
    {
        string titulo;
        int duracion;
        int edad;
        string director;

        public string Titulo
        {
            set
            {
                titulo = value;
            }
            get
            {
                return titulo;
            }
        }
        public int Duracion
        {
            set
            {
                duracion = value;
            }
            get
            {
                return duracion;
            }
        }
        public int Edad
        {
            set
            {
                edad = value;
            }
            get
            {
                return edad;
            }
        }
        public string Director
        {
            set
            {
                director = value;
            }
            get
            {
                return director;
            }
        }

        public Pelicula(int edad)
        {
            Edad = edad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int cont = 0;
            List<Espectador> cineastas = new List<Espectador>();
            Espectador per1 = new Espectador("Marolio", 80, 3000000);
            Espectador per2 = new Espectador("Etesech", 3, 0);
            Espectador per3 = new Espectador("Tilin", 99, 10);
            Espectador per4 = new Espectador("Manolo", 77, 420);
            Espectador per5 = new Espectador("Fulano", 5, 999999999);
            Espectador per6 = new Espectador("Quijote", 60, 10000);
            Espectador per7 = new Espectador("Moño", 100, 2);
            Espectador per8 = new Espectador("Wilfredo", 14, 77777777);
            cineastas.Add(per1);
            cineastas.Add(per2);
            cineastas.Add(per3);
            cineastas.Add(per4);
            cineastas.Add(per5);
            cineastas.Add(per6);
            cineastas.Add(per7);
            cineastas.Add(per8);

            Sala sala1 = new Sala(9, 5);
            Pelicula pelicula = new Pelicula(20);
            Cine cine1 = new Cine(200, pelicula);

            foreach (Espectador espectador in cineastas)
            {
                if (espectador.Edad > cine1.Pelicula.Edad)
                {
                    if (espectador.Dinero >= cine1.Precio)
                    {
                        sala1.ocuparRandom(espectador);
                        Console.WriteLine("El asiento " + sala1.AsientoOcupados[cont]);
                        Console.WriteLine("");
                        cont++;
                    }
                    else
                    {
                        Console.WriteLine(espectador.Nombre + " no tiene el dinero suficiente");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("{0} no tiene la edad suficiente para ver la pelicula", espectador.Nombre);
                    Console.WriteLine("");
                }
            }
            sala1.simulacion();
            Console.ReadKey();
        }
    }
}
public bool acertoApuesta(string[] resultados_partidos)
{

    for (int i = 0; i < resultado.Length; i++)
    {
        if (!resultado[i].Equals(resultados_partidos[i]))
        {
            return false;
        }
    }
    return true;

}
for (int j = 0; j < jugadores.GetLength(0); j++)
{
    if (jugadores[j].acertoApuesta(partidos))
    {
        jugadores[j].ganarApuesta(bote);
        vaciarApuestaAcumulada();
    }
}