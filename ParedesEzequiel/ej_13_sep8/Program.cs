using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio13

{
    class Producto
    {
        string nombre;
        int precio;
        int cantidad;

        public Producto(string nombre, int precio, int cantidad)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
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

        public int Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }

        public virtual double calcular(int cantidad)
        {
            return precio*cantidad;
        }
    }
    
    class Perecedero : Producto
    {
        int diasACaducar;

        public Perecedero(string nombre, int precio, int cantidad, int diasACaducar) : base(nombre, precio, cantidad)
        {
            this.diasACaducar = diasACaducar;
        }

        public int DiasACaducar
        {
            set
            {
                diasACaducar = value;
            }
            get
            {
                return diasACaducar;
            }
        }

        public override double calcular(int cantidad)
        {
            double precioFinal = base.calcular(cantidad);

            switch (diasACaducar)
            {
                case 1:
                    precioFinal /= 4;
                    break;
                case 2:
                    precioFinal /= 3;
                    break;
                case 3:
                    precioFinal /= 2;
                    break;
            }
            return precioFinal;
        }
    }

    class NoPerecedero : Producto
    {
        string tipo;

        public NoPerecedero(string nombre, int precio, int cantidad, string tipo) : base(nombre, precio, cantidad)
        {
            this.tipo = tipo;
        }

        public string Tipo
        {
            set
            {
                tipo = value;
            }
            get
            {
                return tipo;
            }
        }


    }

        class Program
        {
            static void Main(string[] args)
            {

            Producto[] productos = new Producto[6];

            productos[0] = new Producto("Botella de detergente", 40, 1);
            productos[1] = new Perecedero("Paquete de galletitas", 30, 2, 3);
            productos[2] = new NoPerecedero("Paquete de fideos", 15, 4, "Spaghetti");
            productos[3] = new Producto("Botella de agua", 20, 6);
            productos[4] = new NoPerecedero("Paquete de arroz", 10, 3, "Integral");
            productos[5] = new Perecedero("Botella de gaseosa", 50, 2, 1);

            double totalCompra = 0;

            for (int i=0;i<productos.Length;i++)
            {
                totalCompra += productos[i].calcular(productos[i].Cantidad);
            }

            Console.WriteLine("El total de su compra es de: " + totalCompra + " pesos.");
            Console.ReadKey();
            }
        }
}
