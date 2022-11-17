using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ej_03_sep8
{
    class Password
    {
        private int longitud;

        private string contraseña;


        public Password(int longitud)
        {
            this.longitud = longitud;
            contraseña = generarPassword();
        }

        public int Longitud
        {
            set
            {
                longitud = value;
            }
            get
            {
                return longitud;
            }
        }

        public string Contraseña
        {
            get
            {
                return contraseña;
            }
        }
        public string generarPassword()
        {
            string password = "";
            char[] letras = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
                            'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random random = new Random();

            for (int i = 0; i < this.longitud; i++)
            {
                int Letras = random.Next(letras.Length);
                password += letras[Letras];
            }
 
            return password;
        }

        public bool esFuerte()
        {
            int cantidadNumeros = 0;
            int cantidadMinusculas = 0;
            int cantidadMayusculas = 0;

            for (int i = 0; i < contraseña.Length; i++)
            {
                if(contraseña[i] >= 97 && contraseña[i] <= 122)
                {
                    cantidadMinusculas += 1;
                }
                else
                {
                    if (contraseña[i] >= 65 && contraseña[i] <= 90)
                    {
                        cantidadMayusculas += 1;
                    }
                    else
                    {
                        cantidadNumeros += 1;
                    }
                }
            }
            if (cantidadNumeros > 5 && cantidadMinusculas > 1 && cantidadMayusculas > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca un tamaño para el array de la contraseña: ");
            string constraseña = Console.ReadLine();
            int contraseñaParse = Int32.Parse(constraseña);

            Console.Write("Ahora, introduzca la longitud de la contraseña: ");
            string longitudContraseña = Console.ReadLine();
            int longitudContraseñaParse = Int32.Parse(longitudContraseña);

            Password[] listaContraseñas = new Password[contraseñaParse];
            bool[] esFuerteContraseña = new bool[contraseñaParse];

            for (int i = 0; i < listaContraseñas.Length; i++)
            {
                Password contraseña = new Password(longitudContraseñaParse);
                listaContraseñas[i] = contraseña;
                esFuerteContraseña[i] = listaContraseñas[i].esFuerte();
                Console.WriteLine(listaContraseñas[i].Contraseña + " " + esFuerteContraseña[i]);
            }
            Console.ReadKey();
        }
    }
}