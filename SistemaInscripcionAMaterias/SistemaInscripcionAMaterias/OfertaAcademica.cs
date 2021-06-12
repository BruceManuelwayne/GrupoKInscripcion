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
        //public List<MateriasAprobadas> materiasAprobadasAlumno= new List<MateriasAprobadas>


        

        public OfertaAcademica(string archivo) 
        {
            
            if (File.Exists(archivo)) 
            {
                using (var reader = new StreamReader(archivo)) 
                {
                    while (!reader.EndOfStream) 
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Codigo Carrera|Codigo Materia|Codigo Curso|Titular|Materia|Dias|Horarios")
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
        public OfertaAcademica() 
        {
        }
        public void MostrarOferta() 
        {
            Console.WriteLine("****************\nOferta Academica:\n****************");
            foreach(Curso curso in cursos)
            {
                Console.WriteLine($" Codigo Mat: {curso.CodigoMateria} - Codigo Curso: {curso.CodigoCurso} - Nombre Materia: {curso.NombreMateria} - Horarios {curso.Hora} - Dias {curso.Dias}"); 
            }
        }

        public  bool ValidarCurso(int codigo) 
        {
            foreach (Curso curso in cursos) 
            {
                if (curso.CodigoCurso == codigo) 
                {
                    return true;
                     
                }
                Console.WriteLine("Codigo Materia Ingresado inexistente , ingrese otro codigo Materia");
                
            }
            return false;
        }

        
    }
}
