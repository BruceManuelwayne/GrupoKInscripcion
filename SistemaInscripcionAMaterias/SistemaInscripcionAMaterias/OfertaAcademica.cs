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

        //TODO: que pasa si devuelve nada? 
        public List<Curso> FiltrarMatAprobadas(List<MateriasAprobadas> materiasAproAlumno, List<Curso> ofertaCursoFiltradaCorre)
        {
            
            List<Curso> materiasFiltradasFinal = new List<Curso>();
            

            materiasFiltradasFinal = ofertaCursoFiltradaCorre.Where(x => !materiasAproAlumno.Any(y => y.CodigoMateria == x.CodigoMateria)).ToList();

            return materiasFiltradasFinal;
            
        }
        public void MostrarSegunMateria(List<Curso> oferta, int codigoMat) 
        {
            List<Curso> ListaCodigoMateria = new List<Curso>();

            ListaCodigoMateria = oferta.Where(x => x.CodigoMateria == codigoMat).ToList();
            MostrarOfertaFiltrada(ListaCodigoMateria);
            
        }

        public List<Curso> FiltrarOfertaCorrelativas(List<Correlativas> alumnoCorreFaltantes)
        {
            List<Curso> ofertaFiltradaCorr = new List<Curso>();
            ofertaFiltradaCorr = cursos.Where(x => !alumnoCorreFaltantes.Any(y => y.CodigoMateria == x.CodigoMateria)).ToList();
            return ofertaFiltradaCorr;
        }
        public void MostrarOfertaFiltrada(List<Curso> cursosFiltrados)
        {
            Console.WriteLine("****************\nOferta Academica:\n****************");
            foreach (Curso curso in cursosFiltrados)
            {
                Console.WriteLine($" Codigo Mat: {curso.CodigoMateria} - Codigo Curso: {curso.CodigoCurso} - Nombre Materia: {curso.NombreMateria} - Horarios {curso.Hora} - Dias {curso.Dias}");
            }
        }
    }
        //public List<int> ValidarRequisitos(List<Curso> MateriasSinAprobar, List<Correlativas> MateriasConCorrelativas) 
        //{
        //    List<int> requisitosFaltantes = new List<int>();

        //}

        


 }

