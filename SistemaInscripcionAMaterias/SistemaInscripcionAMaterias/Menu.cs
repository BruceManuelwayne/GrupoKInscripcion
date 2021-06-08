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
            Alumno sessionActiva = Alumno.AlumnoIngresado();  
            
           
            
            Console.WriteLine($"--------------Bienvenido {sessionActiva.Nombre}, {sessionActiva.Apellido} -----Legajo:{sessionActiva.Registro}---------------------------"); 
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
    }
}