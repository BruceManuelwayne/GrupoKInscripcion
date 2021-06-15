using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Correlativas
    {
        public int CodigoCarrera { get; set; }

        public int CodigoMateria { get; set; }

        public int Requisito { get; set; }

        const string NombreArchivo = "Correlativas.txt"; 

        List<Correlativas> correlativas = new List<Correlativas>();
        List<Correlativas> correlavtivasCarrera = new List<Correlativas>();
   

        public Correlativas() { }

        public Correlativas(string linea) 
        {
            var datos = linea.Split('|');
            CodigoCarrera = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]);
            Requisito = int.Parse(datos[2]);
        }

        public void GenerarArchivo() 
        {

            if (File.Exists(NombreArchivo)) 
            {
                using (var reader = new StreamReader(NombreArchivo)) 
                {
                    while (!reader.EndOfStream) 
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Codigo Carrera|Codigo Materia|Requisito")
                        {
                            continue;
                        }
                        else 
                        {
                            var correlativa = new Correlativas(linea);
                            correlativas.Add(correlativa);
                        }
                    }

                }
            }
        }

        public List<Correlativas> CorreSegunCarrera(int codigoCarrera) 
        {
            foreach (Correlativas mat in correlativas) 
            {
                if (mat.CodigoCarrera == codigoCarrera) 
                {
                    correlavtivasCarrera.Add(mat); 
                }
            }
            return correlavtivasCarrera;
        }

        public List<Correlativas> listaAlumnoCorr(List<MateriasAprobadas> materiasAlumno, List<Correlativas> correlativasCarrera)
        {
            //materiasFiltradas = cursos.Where(x => !materiasAproAlumno.Any(y => y.CodigoMateria == x.CodigoMateria)).ToList();
            List<Correlativas> listaCorrePendientes = new List<Correlativas>();
            //return materiasFiltradas;
            listaCorrePendientes = correlavtivasCarrera.Where(x => !materiasAlumno.Any(y => y.CodigoMateria == x.Requisito)).ToList();

            return listaCorrePendientes;
        }

       
    }
}
