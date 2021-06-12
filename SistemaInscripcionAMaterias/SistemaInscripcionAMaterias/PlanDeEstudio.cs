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
        const string NombreArchivo = "PlanDeEstudio.txt"; 
        public int CodigoCarrera { get; set; }
        public string Carrera { get; set;  }

        public int CodigoMateria { get; set; }

        public string NombreMateria { get; set; }

        List<PlanDeEstudio> planes = new List<PlanDeEstudio>();

        List<PlanDeEstudio> PlanSegunCarrera = new List<PlanDeEstudio>();

        public PlanDeEstudio() 
        {
        }

        public PlanDeEstudio(string linea) 
        {
            var datos = linea.Split('|');
            CodigoCarrera = int.Parse(datos[0]);
            Carrera = datos[1];
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
                        if (linea == "Codigo Carrera|Carrera|Codigo Materia|Materia")
                        {
                            continue;
                        }
                        else
                        {
                            var plan = new PlanDeEstudio(linea);
                            planes.Add(plan);
                        }
                    }
                }
            }
        }

        public List<PlanDeEstudio>MateriasDadoCarrera(int carrera) 
        {
            foreach (PlanDeEstudio plan in planes) 
            {
                if (plan.CodigoCarrera == carrera) 
                {
                    PlanSegunCarrera.Add(plan); 
                }
                
            }
            return PlanSegunCarrera;
        }

    }
}
