using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej06
{
    class Libro
    {
        int ISBN;
        string titulo;
        string autor;
        int numeroDePaginas;

        public Libro(int ISBN, string titulo, string autor, int numeroDePaginas)
        {
            this.ISBN = ISBN;
            this.titulo = titulo;
            this.autor = autor;
            this.numeroDePaginas = numeroDePaginas;
        }



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

        public string Autor
        {
            set
            {
                autor = value;
            }

            get
            {
                return autor;
            }
        }

        public int NDePaginas
        {
            set
            {
                numeroDePaginas = value;
            }
            get
            {
                return numeroDePaginas;
            }
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            Libro libro1 = new Libro(1112341246, "La cosa", "el papu", 69);
            Libro libro2 = new Libro(786399908, "La cosa 2", "el mike", 42);

            if (libro1.NDePaginas > libro2.NDePaginas)
            {
                Console.WriteLine("El " + libro1.Titulo + " tiene más páginas que " + libro2.Titulo);

            }
            else
            {
                Console.WriteLine("El " + libro2.Titulo + " tiene más páginas que " + libro1.Titulo);

            }
            Console.ReadKey();
        }
    }
}
