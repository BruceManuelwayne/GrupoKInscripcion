﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Curso
    {
        public string CodigoCurso { get; set; }

        public string Titular { get; set;  }

        public string NombreMateria { get; set;  } 

        public string Dias { get; set;  }

        public string Hora { get; set; }

  

        public Curso() { }
        // Formato de txt Oferta
        //Codigo Curso|Titular|Nombre Materia|Dias|Horario
        public Curso(string linea) 
        {
            var datos = linea.Split('|');
            CodigoCurso = datos[0];
            Titular = datos[1];
            NombreMateria = datos[2];
            Dias = datos[3];
            Hora = datos[4];


        }
    }
}
