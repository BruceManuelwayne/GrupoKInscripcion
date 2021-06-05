using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Curso
    {
        public int CodigoMateria { get; set; }
        public int CodigoCurso { get; set; }

        public string Titular { get; set;  }

        public string NombreMateria { get; set;  } 

        

        public string Dias { get; set;  }

        public string Hora { get; set; }

  

        public Curso() { }
        // Formato de txt Oferta
        //Codigo Materia|Codigo Curso|Titular|Nombre Materia|Dias|Horario
        public Curso(string linea) 
        {
            var datos = linea.Split('|');
            CodigoMateria = int.Parse(datos[0]);
            CodigoCurso = int.Parse(datos[1]);
            Titular = datos[2];
            NombreMateria = datos[3];
            Dias = datos[4];
            Hora = datos[5];


        }
    }
}
