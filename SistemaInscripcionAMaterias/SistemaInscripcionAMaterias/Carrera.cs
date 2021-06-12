using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Carrera
    {
        public int CodigoCarrera { get; set; }

        public string NombreArchivo { get; set; }

        public Carrera() { }
        
        public string devolverNombreArchivo(int seleccion) 
        {
            string NombreArchivo=""; 
            switch (seleccion) 
            {
                case 1:
                    NombreArchivo = "OfertaRegularSistemas.txt";
                    break;
                case 2:
                    NombreArchivo = "OfertaRegularContador.txt";
                    break;
                case 3:
                    NombreArchivo = "OfertaRegularAdministracion.txt";
                    break;
                case 4:
                    NombreArchivo = " OfertaRegularEconomia.txt";
                    break;
                case 5:
                    NombreArchivo = "OfertaRegularActuario.txt";
                    break;
                case 6:
                    NombreArchivo = "OfertaREgularActuarioEco.txt";
                    break; 
            }
            return NombreArchivo;
            
        }
    }
}
