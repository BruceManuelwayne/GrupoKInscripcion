using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Alumno
    {
        public string Nombre { get; set;  }  
        public string Apellido { get; set;  }
        public int Registro { get; set;  }




     


        public string InfoAlumno => $"{Nombre}, {Apellido} - Registro {Registro}";

        public Alumno() { }
        public static Alumno AlumnoIngresado() 
        {
            var alumnoLogeado = new Alumno();

            alumnoLogeado.Nombre = "Nicolas";
            alumnoLogeado.Apellido = "Lopez";
          
            alumnoLogeado.Registro = 877301;
  
            //alumnoLogeado.InfoAlumno(alumnoLogeado.Nombre, alumnoLogeado.Apellido, alumnoLogeado.Legajo);

            return alumnoLogeado; 

        }

    }
}
