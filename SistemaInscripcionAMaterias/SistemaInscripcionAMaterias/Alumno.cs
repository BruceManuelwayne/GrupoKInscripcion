using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Registro { get; set; }

        public int CodigoCarrera{get; set;}

        public string Condicion { get; set;  }

        List<Alumno> alumnos = new List<Alumno>(); 

        List<MateriasAprobadas> MateriasAprobadas = new List<MateriasAprobadas>();

        public Alumno(string nombre, string apellido, int registro, int codigoCarrera, string condicion) 
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Registro = registro;
            this.CodigoCarrera = codigoCarrera;
            this.Condicion = condicion; 
        }
     


        public string InfoAlumno => $"{Nombre}, {Apellido} - Registro {Registro}";

        public Alumno() { }
        //registo|nombre|apellido|codigo carrera
        public Alumno(string linea) 
        {
            var datos = linea.Split('|');
            Registro = int.Parse(datos[0]);
            Nombre = datos[1];
            Apellido = datos[2];
            CodigoCarrera = int.Parse(datos[3]);
            Condicion = datos[4];


        }
        public void generarArchivo() 
        {
            if (File.Exists("Alumnos.txt")) 
            {
                using (var reader = new StreamReader("Alumnos.txt")) 
                {
                    while (!reader.EndOfStream) 
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Registo|Nombre|Apellido|Codigo carrera")
                        {
                            continue;
                        }
                        else 
                        {
                            var alumno = new Alumno(linea);
                            alumnos.Add(alumno); 
                        }
                    }
                }
            }
        }

        //public static Alumno AlumnoIngresado()
        //{
        //    var alumnoLogeado = new Alumno();

        //    alumnoLogeado.Nombre = "Nicolas";
        //    alumnoLogeado.Apellido = "Lopez";

        //    alumnoLogeado.Registro = 877301;

        //    alumnoLogeado.CodigoCarrera = 1;

        //    //alumnoLogeado.InfoAlumno(alumnoLogeado.Nombre, alumnoLogeado.Apellido, alumnoLogeado.Legajo);

        //    return alumnoLogeado;

        //}

    }
}
