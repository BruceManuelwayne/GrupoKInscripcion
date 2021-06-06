using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class MateriasAprobadas
    {
        public int Registro { get; set; }

        public int CodigoMateria { get; set; }

        const string MA = "MateriasAprobadas.txt";

        List<MateriasAprobadas> materiasaprobadas = new List<MateriasAprobadas>();
        List<MateriasAprobadas> materiasAprobadasAlumno = new List<MateriasAprobadas>(); 
     
        public MateriasAprobadas(string linea) 
        {
            var datos = linea.Split('|');
            Registro = int.Parse(datos[0]);
            CodigoMateria = int.Parse(datos[1]); 
        }
        public MateriasAprobadas() { }

        public void GenerarArchivo() 
        {
            if (File.Exists(MA)) 
            {
                using (var reader = new StreamReader(MA)) 
                {
                    while (!reader.EndOfStream) 
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Registro|Codigo Materia")
                        {
                            continue;
                        }
                        else
                        {
                            var materiaApro = new MateriasAprobadas(linea);
                            materiasaprobadas.Add(materiaApro); 
                        }
                    }
                }
            }
        }
        public List<MateriasAprobadas> ListaAlumno(int registro) 
        {
            foreach (MateriasAprobadas m in materiasaprobadas) 
            {
                if (m.Registro == registro) 
                {
                    materiasAprobadasAlumno.Add(m);
                }
            }
            return materiasAprobadasAlumno;
        }
        
            
        
        
        
    }
}
