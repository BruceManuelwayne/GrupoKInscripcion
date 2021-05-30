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

            if (ingreso == "FIN")
            {
                return false;
            }
            else 
            {
                var iniciar=Inscirpcion.IniciarInscripcion(); 
                return true;
            }

           
            
            
        }
    }
}