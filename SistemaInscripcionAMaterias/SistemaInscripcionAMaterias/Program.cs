using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Program
    {
        static void Main(string[] args) 
        {

            //bool mostrarMenu = true;
            //while (mostrarMenu) 
            //{

            //    mostrarMenu = Menu.MostrarMenu(); 

            //}
            //funcionando
            Inscripcion iniciar = new Inscripcion();
            iniciar.GenerarArchivos();

            iniciar.Login();
            Console.ReadKey();

            //me choque con generar que oferta mostarar , y que onda plan de estudio???? tengo que validar eso no entiendo .




        }

    }
}

   
