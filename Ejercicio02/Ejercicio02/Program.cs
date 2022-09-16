using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    class Persona
    {
        private string nombre;
        private int edad;
        private Int32 dni;
        private char sexo;
        private int peso;
        private int altura;
        private float pesoIdeal;


        public Persona()
        {

        }

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        public Persona(string nombre, int edad, Int32 dni, char sexo, int peso, int altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = dni;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
        }

        public Persona(string nombre, int edad, char sexo, int peso, int altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
        }
        public void clacularIMC(float kg, int e)
        {
            pesoIdeal = kg / (altura * altura);
            if (pesoIdeal < 20)
            {
                e = -1;
                Console.WriteLine("Está por debajo del peso ideal.");
            }
            if (pesoIdeal >= 20 && pesoIdeal <= 25)
            {
                e = 0;
                Console.WriteLine("Está en su peso ideal.");
            }
            if (pesoIdeal > 25)
            {
                e = 1;
                Console.WriteLine("Está con sobrepeso.");
            }
        }

        public void esMayorDeEdad(int f)
        {
            f = edad;
            if (f >= 18)
            {
                Console.WriteLine("Es mayor de edad.");
            }
            else
            {
                Console.WriteLine("Es menor de edad.");
            }
        }

        public void comprobarSexo(char sexo)
        {
            if (sexo != 'H' | sexo == 'H')
            {
                sexo = 'H';
                Console.WriteLine("Género masculino.");
            }
            if (sexo == 'M')
            {
                Console.WriteLine("Género femenino.");
            }
        }

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

        public char Sexo
        {
            set
            {
                sexo = value;
            }

            get
            {
                return sexo;
            }
        }

        public int Peso
        {
            set
            {
                peso = value;
            }

            get
            {
                return peso;
            }
        }

        public int Altura
        {
            set
            {
                altura = value;
            }

            get
            {
                return altura;
            }
        }


    }
    class Program
    {
        static public Int32 generaDNI()
        {
            Random dni = new Random();
            return dni.Next(10000000, 99999999);
            ;
        }
        static void Main(string[] args)
        {
            Console.Write("Ingrese su nombre: ");
            string s = Console.ReadLine();

            Console.Write("Ingrese su edad: ");
            string f = Console.ReadLine();

            Console.Write("Ingrese su peso: ");
            string a = Console.ReadLine();

            Console.Write("Ingrese su altura: ");
            string b = Console.ReadLine();

            Console.Write("Ingrese su sexo: ");
            char d = Console.ReadKey().KeyChar;
            Console.WriteLine("");


            Persona persona1 = new Persona(s, int.Parse(f), d, int.Parse(a), int.Parse(b));

            Console.Write("Ingrese su nombre: ");
            string p = Console.ReadLine();

            Console.Write("Ingrese su edad: ");
            string i = Console.ReadLine();

            Console.Write("Ingrese su sexo: ");
            char n = Console.ReadKey().KeyChar;
            Console.WriteLine("");

            Console.WriteLine(persona1.Nombre + " " + persona1.Edad + " " + persona1.Sexo + " " + persona1.Peso + " " + persona1.Altura);

            persona1.clacularIMC(persona1.Peso, persona1.Altura);

            persona1.comprobarSexo(d);

            persona1.esMayorDeEdad(persona1.Edad);


            Persona persona2 = new Persona(p, int.Parse(i), n);


            Console.WriteLine(persona2.Nombre + " " + persona2.Edad + " " + persona2.Sexo + " " + persona2.Peso + " " + persona2.Altura);

            persona1.comprobarSexo(n);

            persona1.esMayorDeEdad(persona2.Edad);

            Persona persona3 = new Persona();

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}

