using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace ej_04_sep8
{
    public class Electrodomestico
    {
        int precioBase;
        const int precioDefecto = 100;
        string color;
        const string colorDefecto = "Blanco";
        char consumo;
        const char consumoDefecto = 'F';
        int peso;
        const int pesoDefecto = 5;

        public Electrodomestico()
        {
        }

        public Electrodomestico(int precioBase, int peso)
        {
            this.precioBase = precioBase;
            this.peso = peso;
        }

        public Electrodomestico(int precioBase, int peso, char consumo, string color)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            this.consumo = consumo;
            this.color = color;
            comprobarConsumo(consumo);
            comprobarColor(color);
        }

        private void comprobarColor(string c)
        {
            c = color;
            string[] colores = { "Blanco", "Negro", "Rojo", "Azul", "Gris" };
            bool encontrado = false;
            for (int i = 0; i < colores.Length && !encontrado; i++)
            {
                if (colores[i].Equals(color))
                {
                    encontrado = true;
                }
                else
                {
                    color = colorDefecto;
                }
            }

        }

        private void comprobarConsumo(char f)
        {
            f = consumo;
            if (consumo>=65 && consumo<=70)
            {
                f = consumo;
            }
            else
            {
                this.consumo = consumoDefecto;
            }
        }

        public int PrecioBase
        {
            set
            {
                precioBase = value;
            }
            get
            {
                return precioBase;
            }
        }

        public string Color
        {
            set
            {
                color = value;
            }
            get
            {
                return color;
            }
        }

        public char Consumo
        {
            set
            {
                consumo = value;
            }
            get
            {
                return consumo;
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

        public virtual double precioFinal()
        {
            double plus = 0;
            switch (consumo)
            {
                case 'A':
                    plus += 100;
                    break;
                case 'B':
                    plus += 80;
                    break;
                case 'C':
                    plus += 60;
                    break;
                case 'D':
                    plus += 50;
                    break;
                case 'E':
                    plus += 30;
                    break;
                case 'F':
                    plus += 10;
                    break;
            }

            if (peso >= 0 && peso < 19)
            {
                plus += 10;
            }
            else if (peso >= 20 && peso < 49)
            {
                plus += 50;
            }
            else if (peso >= 50 && peso <= 79)
            {
                plus += 80;
            }
            else if (peso >= 80)
            {
                plus += 100;
            }

            return precioBase + plus;
        }
    }

    public class Lavadero : Electrodomestico
    {
        int carga;
        const int cargaDefecto = 5;

        public Lavadero() : base()
        {
            
        }

        public Lavadero(int precioBase, int peso) : base()
        {
            this.PrecioBase = precioBase;
            this.Peso = peso;
        }

        public Lavadero(int carga) : base()
        {
            this.carga = carga;
        }

        public int Carga
        {
            set
            {
                carga = value;
            }
            
            get
            {
                return carga;
            }
        }


        public override double precioFinal()
        {
            double plus = base.precioFinal();
            if (carga>30)
            {
                plus += 50;                
            }
            return plus;
        }

        

    }
    public class Television : Electrodomestico
    {
        int resolucion;
        const int resolucionDefecto = 20;
        bool sintonizadorTDT;
        const bool sintonizadorDefecto = false;

        public Television() : base()
        {

        }

        public Television(int precioBase, int peso) : base()
        {
            this.PrecioBase = precioBase;
            this.Peso = peso;
        }

        public Television(int resolucion, bool sintonizadorTDT) : base()
        {
            this.resolucion = resolucion;
            this.sintonizadorTDT = sintonizadorTDT;
        }

        public int Resolucion
        {
            set
            {
                resolucion = value;
            }

            get
            {
                return resolucion;
            }
        }

        public bool SintonizadorTDT
        {
            set
            {
                sintonizadorTDT = value;
            }

            get
            {
                return sintonizadorTDT;
            }
        }

        public override double precioFinal()
        {
            double plus = base.precioFinal();
            if (resolucion>40)
            {
                plus += PrecioBase * 0.3;
            }
            if (sintonizadorTDT == true)
            {
                plus += 50;
            }
            return plus;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico lavadero0 = new Lavadero(100, 38);
            Electrodomestico lavadero1 = new Lavadero(24);
            Electrodomestico lavadero2 = new Lavadero(800, 24);
            Electrodomestico lavadero3 = new Lavadero(27);
            Electrodomestico lavadero4 = new Lavadero(820, 69);
            Electrodomestico television0 = new Television(56, true);
            Electrodomestico television1 = new Television(600, 120);
            Electrodomestico television2 = new Television(23, false);
            Electrodomestico television3 = new Television(8000, 58);
            Electrodomestico television4 = new Television(37, true);

            Electrodomestico[] electrodomesticos = {lavadero0, lavadero1, lavadero2, lavadero3, lavadero4, television0, television1, television2, television3, television4};

            double sumaElectrodomesticos = 0;
            double sumaTelevisiones = 0;
            double sumaLavaderos = 0;

            for (int i=0;i<electrodomesticos.Length;i++)
            {
                if (electrodomesticos[i] is Lavadero)
                {
                    sumaLavaderos += electrodomesticos[i].precioFinal();
                }
                if (electrodomesticos[i] is Television)
                {
                    sumaTelevisiones += electrodomesticos[i].precioFinal();
                }
                else if (electrodomesticos[i] is Electrodomestico)
                {
                    sumaElectrodomesticos += electrodomesticos[i].PrecioBase;
                }
            }

            Console.WriteLine("La suma del precio de todos los electrodomésticos es de: " + sumaElectrodomesticos);
            Console.WriteLine("La suma del precio de todos los lavaderos es de: " + sumaLavaderos);
            Console.WriteLine("La suma del precio de todas las televisiones es de: " + sumaTelevisiones);
            Console.ReadKey();
        }
    }
}

