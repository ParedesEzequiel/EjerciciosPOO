using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ej_08_sep8
{
    public abstract class Persona
    {
        string nombre;
        char sexo;
        int edad;
        bool asistencia;

        private static string[] Chicos = { "José", "Pepe", "Quijote", "Oscar" };
        private static string[] Chicas = { "Clotilde", "Mariana", "Pirulo", "Pirula" };
        private static int Chico = 0;
        private static int Chica = 1;

        public Persona()
        {
            int determinar_sexo = Metodos.numeroAleatorio(0, 1);

            if (determinar_sexo == Chico)
            {
                nombre = Chicos[Metodos.numeroAleatorio(0, 4)];
                sexo = 'H';
            }
            else
            {
                nombre = Chicas[Metodos.numeroAleatorio(0, 4)];
                sexo = 'M';
            }

            disponibilidad();
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
        public char getSexo()
        {
            return sexo;
        }
        public void setSexo(char sexo)
        {
            this.sexo = sexo;
        }
        public int getEdad()
        {
            return edad;
        }
        public void setEdad(int edad)
        {
            this.edad = edad;
        }
        public bool isAsistencia()
        {
            return asistencia;
        }
        public void setAsistencia(bool asistencia)
        {
            this.asistencia = asistencia;
        }

        public abstract void disponibilidad();
    }

    public class Alumno : Persona
    {
        int nota;

        public Alumno() : base()
        {
            nota = Metodos.numeroAleatorio(0, 10);
            base.setEdad(Metodos.numeroAleatorio(12, 15));
        }

        public int getNota()
        {
            return nota;
        }
        public void setNota(int nota)
        {
            this.nota = nota;
        }

        public override void disponibilidad()
        {
            int prob = Metodos.numeroAleatorio(0, 100);

            if (prob < 50)
            {
                base.setAsistencia(false);
            }
            else
            {
                base.setAsistencia(true);
            }
        }


    }

    public class Profesor : Persona
    {
        string materia;

        public Profesor() : base()
        {
            base.setEdad(Metodos.numeroAleatorio(25, 50));
            materia = Constantes.Materias[Metodos.numeroAleatorio(0, 2)];


        }

        public string getMateria()
        {
            return materia;
        }

        public void setMateria(string materia)
        {
            this.materia = materia;
        }

        public override void disponibilidad()
        {
            int prob = Metodos.numeroAleatorio(0, 100);
            if (prob < 20)
            {
                base.setAsistencia(false);
            }
            else
            {
                base.setAsistencia(true);
            }
        }
    }

    public class Aula
    {
        int id;
        Profesor profesor;
        Alumno[] alumnos;
        string materia;
        static int maxAlumnos = 20;

        public Aula()
        {
            id = 1;

            profesor = new Profesor();
            alumnos = new Alumno[maxAlumnos];
            creaAlumnos();
            materia = Constantes.Materias[Metodos.numeroAleatorio(0, 2)];
        }

        private void creaAlumnos()
        {
            for (int i = 0; i < alumnos.Length; i++)
            {
                alumnos[i] = new Alumno();
            }
        }

        private bool asistenciaAlumnos()
        {
            int cuentaAsistencia = 0;
            for (int i = 0; i < alumnos.Length; i++)
            {
                if (alumnos[i].isAsistencia())
                {
                    cuentaAsistencia++;
                }
            }
            Console.WriteLine("Hay " + cuentaAsistencia + " alumnos.");
            return cuentaAsistencia >= ((int)(alumnos.Length / 2));
        }

        public bool darClase()
        {
            if (!profesor.isAsistencia())
            {
                Console.WriteLine("El profesor no está, por lo tanto, no se puede dar la clase.");
                return false;
            }
            if (!profesor.getMateria().Equals(materia))
            {
                Console.WriteLine("La materia del profesor y del aula no es la misma, por lo que no se puede dar la clase.");
                return false;
            }
            if (!asistenciaAlumnos())
            {
                Console.WriteLine("La asistencia no es suficiente, por lo que no se puede dar la clase.");
                return false;
            }
            Console.WriteLine("Se puede dar la clase.");
            return true;
        }

        public void notas()
        {
            int chicosApro = 0;
            int chicasApro = 0;

            for (int i = 0; i < alumnos.Length; i++)
            {
                if (alumnos[i].getNota() >= 5)
                {
                    if (alumnos[i].getSexo() == 'H')
                    {
                        chicosApro++;
                    }
                    else
                    {
                        chicasApro++;
                    }
                    
                }
            }
            Console.WriteLine("Hay " + chicosApro + " chicos y " + chicasApro + " chicas aprobados/as.");
        }
    }

    public class Constantes
    {
        public static string[] Materias = { "Matemática", "Historia", "Inglés" };
    }

    public class Metodos
    {
        public static Random rnd = new Random();    
        public static int numeroAleatorio(int minimo, int maximo)
        {
            int num = rnd.Next(minimo, maximo);
            return num;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Aula aula1 = new Aula();

            if (aula1.darClase())
            {
                aula1.notas();
            }

            Console.ReadKey();
        }
    }
}
