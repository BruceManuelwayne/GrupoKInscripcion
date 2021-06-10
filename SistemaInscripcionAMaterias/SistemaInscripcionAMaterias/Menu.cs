using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    public static class Menu
    {


        public static bool MostrarMenu()
        {   
             
            
           
            
           
            Console.WriteLine("---------------------------------Inscirpcion Regular---------------------------------");
            Console.WriteLine("Presiona cualquier tecla para iniciar la Inscripcion Regular o ingrese exit para salir");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            string ingreso = Console.ReadLine().ToUpperInvariant();

            if (ingreso == "EXIT")
            {
                return false;
            }
            else 
            {
                Inscripcion Iniciar = new Inscripcion();
                return true;
            }

           
            
            
        }
        public static void SeleccionCarreraMenu() 
        {
            Console.WriteLine("Selecione la carrera:");

            Console.WriteLine("1 - Sistemas De Informaccion");
            Console.WriteLine("2 - Contabilidad");
            Console.WriteLine("3 - Admin. De Empresas");
            Console.WriteLine("4 - Economia");
            Console.WriteLine("5 - Actuario");
            Console.WriteLine("9 - Salir ");

            Console.WriteLine("Ingrese una opción y presione [Enter]");
          
            }
    }
}