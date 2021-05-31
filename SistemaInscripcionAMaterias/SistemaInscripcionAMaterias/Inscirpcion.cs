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

        public int Registro { get; set; }

        public int CodigoCurso { get; set; }

        public int CodCursoAlternativo { get; set; }
        
        public string InstanciaInscirpcion { get; set; }


        public DateTime Fecha { get; set;  }

       

        public Inscripcion(int legajo,int registro, string instancia,  int codigoCurso, int codCursoAlt, DateTime fecha) 
        {
            NumeroLegajo = legajo;
            Registro = registro;
            InstanciaInscirpcion = instancia; 
            CodigoCurso = codigoCurso;
            CodCursoAlternativo = codCursoAlt; 


        }


        
        List<Curso> cursos = new List<Curso>(4);  
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
                        SeleccionCarrera("OfertaRegularSistemas.txt");
                        break;

                    case "2":
                        SeleccionCarrera("OfertaRegularContador.txt");
                        break;
                    case "3":
                        SeleccionCarrera("OfertaRegularAdmin.txt"); 
                        break;
                    case "4":
                        SeleccionCarrera("OfertaRegularEconomia.txt");
                        break;
                    case "5":

                        SeleccionCarrera("OfertaRegularActuario.txt");
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

        public void SeleccionCarrera(string archivo) 
        {
            OfertaAcademica ofertaSistemas = new OfertaAcademica(archivo);
            ofertaSistemas.MostrarOferta();
            Console.ReadKey();
        }

        public void SeleccionMateria(string codigo) 
        {
            

        }
    }
}