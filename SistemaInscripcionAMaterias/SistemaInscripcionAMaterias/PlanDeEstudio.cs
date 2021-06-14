using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class PlanDeEstudio
    {
        const string NombreArchivo = "PlanCarrera.txt";
        public int CodigoCarrera { get; set; }
        public int CodigoMateria { get; set; }
        
        public string NombreCarrera { get; set; }
        public string Titular { get; set; }

        public string NombreMateria { get; set; }



        public string Dias { get; set; }

        public string Hora { get; set; }

        List<PlanDeEstudio> PlanTodasCarrera = new List<PlanDeEstudio>();
        List<PlanDeEstudio> PlanSegunCarrera = new List<PlanDeEstudio>();



        public PlanDeEstudio() { }
        // Formato de txt Oferta
        //Codigo Materia|Codigo Curso|Titular|Nombre Materia|Dias|Horario
        public PlanDeEstudio(string linea)
        {
            var datos = linea.Split('|');
            CodigoCarrera = int.Parse(datos[0]);
            NombreCarrera = datos[1];
            CodigoMateria = int.Parse(datos[2]);
            NombreMateria = datos[3];
          


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
                        if (linea == "CodCarrera|Carrera|CodMateria|Materia")
                        {
                            continue;
                        }
                        else
                        {
                            var plan = new PlanDeEstudio(linea);
                            PlanTodasCarrera.Add(plan);
                        }
                    }
                }
            }
        }

        public List<PlanDeEstudio>MateriasDadoCarrera(int carrera) 
        {
            foreach (PlanDeEstudio plan in PlanTodasCarrera) 
            {
                if (plan.CodigoCarrera == carrera) 
                {
                    PlanSegunCarrera.Add(plan); 
                }
                
            }
            return PlanSegunCarrera;
        }

        public int CountMateriasCarrera(List<PlanDeEstudio>PlanAlumno)
        {
            int cantidadMaterias = 0;
            cantidadMaterias=PlanAlumno.Count();
            //foreach (Curso c in PlanAlumno) 
            //{
            //    CantidadMaterias++;   
            //}
            return cantidadMaterias;
        }
    }
}
