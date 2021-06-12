using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Solicitud
    {
        const string NombreArchivo = "Solicitudes.txt";
        public int Registro { get; set; }
        public int CodigoCarrera { get; set; } 

        public int CodigoMateria { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoCursoAlt { get; set; }
        public DateTime Fecha { get; set; }

        List<Solicitud> solicitudes = new List<Solicitud>();

        public Solicitud() 
        {

        }

        public Solicitud(int registro, int codigoCarrera, int codigoMateria, int codigoCurso, int codigoCursoAlt, DateTime fecha) 
        {
            Registro = registro;
            CodigoCarrera = codigoCarrera;
            CodigoMateria = codigoMateria;
            CodigoCurso = codigoCurso;
            CodigoCursoAlt = codigoCursoAlt;
            Fecha = fecha; 
        }

        public Solicitud(string linea) 
        {
            var datos = linea.Split('|');
            Registro = int.Parse(datos[0]);
            CodigoCarrera = int.Parse(datos[1]);
            CodigoMateria = int.Parse(datos[2]);
            CodigoCurso = int.Parse(datos[3]);
            CodigoCursoAlt = int.Parse(datos[4]);
            Fecha = DateTime.Parse(datos[5]); 

        }

        public void generarArchivo()
        {
            if (File.Exists(NombreArchivo))
            {
                using (var reader = new StreamReader(NombreArchivo))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        if (linea == "Registro|Codigo Carrera|Codigo Materia|Codigo Curso|Curso Alternativo|Fecha")
                        {
                            continue;
                        }
                        else
                        {
                            var solicitud = new Solicitud(linea);
                            solicitudes.Add(solicitud);
                        }
                    }
                }
            }
        }

        // si uiero generar un codigo legajo
        public int contarLineas() 
        {
            int count = 0;
            using (StreamReader reader = File.OpenText(NombreArchivo))
            {
                while (reader.ReadLine() != null)
                {
                    count++;
                }
            }
            return count;
        }
        public void Guardar() 
        {
            using (var writer = new StreamWriter(NombreArchivo, append: false)) 
            {
                writer.WriteLine("Registro|Codigo Carrera|Codigo Materia|Codigo Curso|Curso Alternativo|Fecha");
                foreach (var solicitud in solicitudes) 
                {
                    var linea = solicitud.ObtenerLineaDatos();
                    writer.WriteLine(linea); 
                }
            }
        }
        public bool BuscarSolicitud(int registro) 
        {
            int posicion = 0;
            bool seEncontro = false;
            while (posicion < solicitudes.Count && !seEncontro)
            {
                if (solicitudes[posicion].Registro == registro)
                {
                    seEncontro = true;
                }
                else
                {
                    posicion++; 
                }

            }
            return seEncontro; 
        }
        public void AgregarSolicitud(List<Solicitud> solicitudActual) 
        {
            foreach (Solicitud solicitud in solicitudActual) 
            {
                solicitudes.Add(solicitud); 
            }
        }
        public string  ObtenerLineaDatos() => $"{Registro}|{CodigoCarrera}|{CodigoMateria}|{CodigoCurso}|{CodigoCursoAlt}|{Fecha}";
    }
}
