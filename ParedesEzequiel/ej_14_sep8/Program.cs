using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio14
{
    class Bebida
    {
        static int idActual = 1;
        int id;
        int litros;
        public double precio;
        public string marca;

        public Bebida(string marca, int litros, int precio)
        {
            this.id = idActual++;
            this.marca = marca;
            this.litros = litros;
            this.precio = precio;
        }

        public int ID
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public string Marca
        {
            set
            {
                marca = value;
            }
            get
            {
                return marca;
            }
        }

        public int Litros
        {
            set
            {
                litros = value;
            }
            get
            {
                return litros;
            }
        }

        public double Precio
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
    }

    class AguaMineral : Bebida
    {
        string lugarOrigen;

        public AguaMineral(string marca, int litros, int precio, string lugarOrigen) : base(marca, litros, precio)
        {
            this.lugarOrigen = lugarOrigen;
        }

        public string LugarOrigen
        {
            set
            {
                lugarOrigen = value;
            }
            get
            {
                return lugarOrigen;
            }
        }

    }

    class BebidaAzucarada : Bebida
    {
        double porcentajeAzucar;
        bool promocion;

        public BebidaAzucarada(string marca, int litros, int precio, double porcentajeAzucar, bool promocion) : base(marca, litros, precio)
        {
            this.porcentajeAzucar = porcentajeAzucar;
            this.promocion = promocion;
        }

        public double PorcentajeAzucar
        {
            set
            {
                porcentajeAzucar = value;
            }
            get
            {
                return porcentajeAzucar;
            }
        }

        public bool Promocion
        {
            set
            {
                promocion = value;
            }
            get
            {
                return promocion;
            }
        }

        public double precioDescuento(bool e)
        {
            e = promocion;
            if (promocion == true)
            {
                base.precio = base.precio * 0.9;
                return base.precio;
            }
            else
            {
                return base.precio;
            }
        }

    }

    class Almacen
    {
        const int filas = 5;
        const int columnas = 5;
        Bebida[,] estanteria = new Bebida[filas, columnas];

        public Almacen(int filas, int columnas)
        {
            estanteria = new Bebida[filas, columnas];
        }

        public Almacen()
        {
            estanteria = new Bebida[5, 5];
        }

        public void agregarBebida(Bebida a)
        {
            bool encontrado = false;
            for (int i = 0; i < estanteria.GetLength(0) && !encontrado; i++)
            {
                for (int j = 0; j < estanteria.GetLength(0) && !encontrado; j++)
                {
                    if (estanteria[i, j] == null)
                    {
                        estanteria[i, j] = a;
                        encontrado = true;
                    }
                }
            }

            if (encontrado)
            {
                Console.WriteLine("La bebida ha sido añadida.");
            }
            else
            {
                Console.WriteLine("La bebida no ha podido añadirse al estante.");
            }
        }


        public void eliminarBebida(int id)
        {
            bool encontrado = false;
            for (int i = 0; i < estanteria.GetLength(0) && !encontrado; i++)
            {
                for (int j = 0; j < estanteria.GetLength(0) && !encontrado; j++)
                {
                    if (estanteria[i, j] != null)
                    {
                        if (estanteria[i, j].ID == id)
                        {
                            estanteria[i, j] = null;
                            encontrado = true;
                        }
                    }
                }
            }

            if (encontrado)
            {
                Console.WriteLine("La bebida ha sido eliminada.");
            }
            else
            {
                Console.WriteLine("La bebida no ha sido encontrada dentro del estante.");
            }
        }

        public void mostrarBebidas()
        {
            for (int i = 0; i < estanteria.GetLength(0); i++)
            {
                for (int j = 0; j < estanteria.GetLength(0); j++)
                {
                    if (estanteria[i, j] != null)
                    {
                        Console.WriteLine("Fila " + i + ", columna " + j + " bebida: " + estanteria[i, j].marca);
                    }
                }
            }
        }

        public double calcularPrecioBebidas()
        {
            double precioTotal = 0;
            for (int i = 0; i < estanteria.GetLength(0); i++)
            {
                for (int j = 0; j < estanteria.GetLength(0); j++)
                {
                    if (estanteria[i, j] != null)
                    {
                        precioTotal += estanteria[i, j].Precio;
                    }
                }
            }
            return precioTotal;
        }

        public double calcularPrecioBebidas(String marca)
        {
            double precioTotal = 0;
            for (int i = 0; i < estanteria.GetLength(0); i++)
            {
                for (int j = 0; j < estanteria.GetLength(0); j++)
                {
                    if (estanteria[i, j] != null)
                    {
                        if (estanteria[i, j].Marca.Equals(marca))
                        {
                            precioTotal += estanteria[i, j].Precio;
                        }
                    }
                }
            }
            return precioTotal;
        }

        public double calcularPrecioBebidas(int columna)
        {
            double precioTotal = 0;
            if (columna >= 0 && columna < estanteria.GetLength(0))
            {
                for (int i = 0; i < estanteria.GetLength(0); i++)
                {
                    if (estanteria[i, columna] != null)
                    {
                        precioTotal += estanteria[i, columna].Precio;
                    }
                }
            }
            else
            {
                Console.WriteLine("La columna debe estar entre 0 y " + estanteria.GetLength(0));
            }
            return precioTotal;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Almacen jorgito = new Almacen();

            Bebida s;

            for (int i = 0; i < 10; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        s = new AguaMineral("Villavicencio", 2, 40, "riachuelo");
                        jorgito.agregarBebida(s);
                        break;
                    case 1:
                        s = new BebidaAzucarada("Pepsi", 1, 60, 0.9, true);
                        jorgito.agregarBebida(s);
                        break;
                }
            }


            jorgito.mostrarBebidas();

            Console.WriteLine("Los precios de todas las bebidas disponibles son: " + jorgito.calcularPrecioBebidas());

            jorgito.eliminarBebida(3);

            jorgito.mostrarBebidas();

            Console.WriteLine("Ahora, los precios de todas las bebidas disponibles son: " + jorgito.calcularPrecioBebidas());

            Console.WriteLine("El precio de las bebidas de la marca villavicencio es de: " + jorgito.calcularPrecioBebidas("Villavicencio"));

            Console.WriteLine("El precio de todas las bebidas de la primer columna es: " + jorgito.calcularPrecioBebidas(0));

            Console.ReadKey();
        }
    }
}