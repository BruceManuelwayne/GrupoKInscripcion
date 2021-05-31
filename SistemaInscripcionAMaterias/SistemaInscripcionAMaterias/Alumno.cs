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

        public string Status { get; set; }

        public int Legajo { get; set;  }

        public int Dni { get; set;  }

       public string Telefono { get; set;  }

       public string Domicilio { get; set;  }

        public string Localidad { get; set; }

        public int CodigoPostal { get; set;  }

        public string InfoAlumno => $"{Nombre}, {Apellido} - Legajo {Legajo}";

        public Alumno() { }
        public static Alumno AlumnoIngresado() 
        {
            var alumnoLogeado = new Alumno();

            alumnoLogeado.Nombre = "Nicolas";
            alumnoLogeado.Apellido = "Lopez";
            alumnoLogeado.Domicilio = "123 Wallaby syndey";
            alumnoLogeado.Legajo = 877301;
            alumnoLogeado.Dni = 123456789;
            alumnoLogeado.Telefono = "45614561";
            //alumnoLogeado.InfoAlumno(alumnoLogeado.Nombre, alumnoLogeado.Apellido, alumnoLogeado.Legajo);

            return alumnoLogeado; 

        }

    }
}
