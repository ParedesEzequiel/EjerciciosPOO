using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_07_sep8
{
    public class Raices
    {
        double a;
        double b;
        double c;

        public Raices(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double getDiscriminante()
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }

        public bool tieneRaices()
        {
            return getDiscriminante() > 0;
        }

        public bool tieneRaiz()
        {
            return getDiscriminante() == 0;
        }

        public void obtenerRaices()
        {
            double raiz1 = (-b + Math.Sqrt(getDiscriminante())) / (2 * a);
            double raiz2 = (-b - Math.Sqrt(getDiscriminante())) / (2 * a);

            Console.WriteLine("La primera raíz tiene el valor de: " + raiz1);
            Console.WriteLine("La segunda raíz tiene el valor de: " + raiz2);
        }

        public void obtenerRaiz()
        {
            double unicaRaiz = (-b) / (2 * a);

            Console.WriteLine("La única  raíz tiene el valor de: " + unicaRaiz);
        }

        public void calcular()
        {
            if (tieneRaices())
            {
                obtenerRaices();
            }
            if (tieneRaiz())
            {
                obtenerRaiz();
            }
            else
            {
                Console.WriteLine("No existe una solución.");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write
        }
    }
}
