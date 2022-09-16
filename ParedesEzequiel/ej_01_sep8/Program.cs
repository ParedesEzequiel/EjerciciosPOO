namespace ej_01_sep8
{
    class Cuenta
    {
        private string titular;
        private double cantidad;
        private double cantidadRetiro;

        public Cuenta(string titular)
        {
            this.titular = titular;
        }

        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        public void ingresar(float e)
        {

            if (e >= 0)
            {
                cantidad += e;
            }
        }

        public void retirar(float f)
        {
            cantidadRetiro = cantidad - f;
            if (cantidadRetiro < 0)
            {
                cantidad = 0;
                cantidadRetiro = 0;
            }
        }
        public string Titular
        {
            get
            {
                return titular;
            }
            set
            {
                titular = value;
            }
        }

        public double Cantidad
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

        public double CantidadRetiro
        {
            set
            {
                cantidadRetiro = value;
            }
            get
            {
                return cantidadRetiro;
            }
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Cuenta cuenta1 = new Cuenta("elpepe", 250.03);

            cuenta1.retirar(300);

            Console.WriteLine(cuenta1.Titular + " " + cuenta1.Cantidad);

            cuenta1.ingresar(400);
            cuenta1.ingresar(-200);

            Console.WriteLine(cuenta1.Titular + " " + cuenta1.Cantidad);


            Console.ReadKey();


        }
    }
}
