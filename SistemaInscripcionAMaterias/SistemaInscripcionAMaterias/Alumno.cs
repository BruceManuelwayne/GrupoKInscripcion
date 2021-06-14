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

        public Alumno(int registro, string nombre, string apellido, int codigoCarrera, string condicion) 
        {
            Registro = registro;
            Nombre = nombre;
            Apellido = apellido;
            CodigoCarrera = codigoCarrera;
            Condicion = condicion; 
        }
     


        public string InfoAlumno => $"{Nombre}, {Apellido} - Registro {Registro}";

        public Alumno() { }
        //registo|nombre|apellido|codigo carrera|condicion
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
                        if (linea == "Registro|Nombre|Apellido|Codigo carrera|Condicion")
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
        public Alumno BuscarAlumno(int registro) 
        {
            int posicion = 0;
            bool seEncontro = false;
            Alumno alumnoEncontrado = new Alumno();
            while (posicion < alumnos.Count && !seEncontro) 
            {
                if (alumnos[posicion].Registro == registro)
                {
                    seEncontro = true;
                    alumnoEncontrado.Nombre = alumnos[posicion].Nombre;
                    alumnoEncontrado.Apellido = alumnos[posicion].Apellido;
                    alumnoEncontrado.Registro = alumnos[posicion].Registro;
                    alumnoEncontrado.Condicion = alumnos[posicion].Condicion;
                }
               
                else
                {
                    posicion++;
                }    
            }   
            return alumnoEncontrado;
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
