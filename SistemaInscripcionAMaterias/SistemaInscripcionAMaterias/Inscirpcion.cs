using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    public class Inscripcion

    {
        public int NumeroLegajo { get; set; }

        public int LegajoAlumno { get; set;  }

        public string InstanciaInscirpcion { get; set;  }

        //public static List<Materias>[3] materias  
        //pedir carrera
        //mostrar materias segun carrera
        public Inscripcion() 
        {
            bool salir = false;
            do
            {
                Console.WriteLine("Selecione la carrera:");

                Console.WriteLine("1 - Sistemas De Informaccion");
                Console.WriteLine("2 - Contabilidad");
                Console.WriteLine("3 - Admin. De Empresas");
                Console.WriteLine("4 - Economia");
                Console.WriteLine("5 - Actuario");
                Console.WriteLine("9 - Salir ");

                Console.WriteLine("Ingrese una opción y presione [Enter]");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        SeleccionCarrera();
                        break;

                    case "2":
                        //MostrarMaterias(opcion);
                        break;
                    case "3":
                        // MostrarMaterias(opcion);
                        break;
                    case "4":
                        //MostrarMaterias(opcion);
                        break;
                    case "5":

                        //MostrarMAterias(opcion); 
                        break;
                    case "9":
                        salir = true;
                        break; 
                    default:
                        Console.WriteLine("No ha ingresado una opción del menú");
                        break;
                }

            } while (!salir);
        }
       // necesitamos validar aca que carrera para despues mandar ese string para selecionar que arhivo vamos a leer, nuestro filtro abre cierto txt

        public void SeleccionCarrera() 
        {
            OfertaAcademica ofertaSistemas = new OfertaAcademica();
            ofertaSistemas.MostrarOferta();
            Console.ReadKey();
        }

    }
}