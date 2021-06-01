using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class OfertaAcademica
    {
        //public static Dictionary<int, Curso> cursos;
        public List<Curso> cursos = new List<Curso>(); 

       

        public OfertaAcademica(string archivo) 
        {
            
            if (File.Exists(archivo)) 
            {
                using (var reader = new StreamReader(archivo)) 
                {
                    while (!reader.EndOfStream) 
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Codigo Curso|Titular|Nombre Materia|Dias|Horarios")
                        {
                            continue;
                        }
                        else 
                        {
                            var curso = new Curso(linea);
                            cursos.Add(curso);
                        }
                         
                    }
                }
            }
            
        }
        public void MostrarOferta() 
        {
            Console.WriteLine("****************\nOferta Academica:\n****************");
            foreach(Curso curso in cursos)
            {
                Console.WriteLine($"Codigo Curso: {curso.CodigoCurso} - Nombre Materia: {curso.NombreMateria}"); 
            }
        }

        public bool ValidarCurso(string codigo) 
        {
            foreach (Curso curso in cursos) 
            {
                if (curso.CodigoCurso == codigo) 
                {
                    return true;
                     
                }
                Console.WriteLine("Codigo Ingresado inexistente , ingrese otro codigo");
                
            }
            return false;
        }
    }
}
