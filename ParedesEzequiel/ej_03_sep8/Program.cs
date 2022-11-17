using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ej_03_sep8
{
    class password
    {
        private int longitud;


        public password()
        {

        }

        public password(int longitud)
        {
            this.longitud = longitud;
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

        private string crearPassword(int largo)
        {
            largo = longitud;

            char[] letras = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
                            'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                            'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random random = new Random();

            char[] chars = new char[largo];
            for (int i = 0; i < largo; i++)
            {
                letras[i] = letras[random.Next(largo)];
            }
 
            return letras.ToString();
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                password contraseña = new password(15);
                Console.WriteLine(contraseña.crearPassword(16));
                Console.ReadKey();
            }
        }
    }
}