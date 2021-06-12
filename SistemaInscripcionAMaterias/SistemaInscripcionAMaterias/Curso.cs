using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Curso
    {
        public int CodigoCarrera { get; set; }
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
            CodigoCarrera = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            CodigoCurso = int.Parse(datos[2]);
            Titular = datos[3];
            NombreMateria = datos[4];
            Dias = datos[5];
            Hora = datos[6];


        }
    }
}
