using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    public static class Ingresos
    {

        public static string IngresarCadena(string texto, int largoMin, int largoMax)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string ingreso = Console.ReadLine();

                if (ingreso.Length < largoMin || ingreso.Length > largoMax)
                {
                    Console.WriteLine($"Debe ingresar entre {largoMin} y {largoMax} caracteres.");
                    continue;
                }
                return ingreso;
            }
        }
       
        
        public static int IngresarNumeroRegistro(string texto, string error, int min, int max)
        {
            while (true)
            {

                int numero;

                Console.WriteLine(texto);

                var ingreso = Console.ReadLine();

                if (!int.TryParse(ingreso, out numero))
                {
                    Console.WriteLine(error);
                    continue;
                }
                if (numero < min || numero > max)
                {
                    Console.WriteLine($"Debe Ingresar un numero de registro entre {min} y {max}'");
                    continue;
                }
                return numero;
            }
        }

        public static int IngresarIntSimple(string texto, string error) 
        {
            while (true) 
            {
                int numero;
                Console.WriteLine(texto);
                var ingreso = Console.ReadLine();
                if(!int.TryParse(ingreso, out numero))
                {
                    Console.WriteLine(error);
                    continue;
                }
                return numero;
            }
        }




        //public static string IngresarCodMateria(string texto, string error, List<Curso> cursosPendientes)
        //{
        //    while (true)
        //    {
        //        int numero;
        //        bool existe = false;
        //        int posicion = 0;
        //        Console.WriteLine(texto);
        //        var ingreso = Console.ReadLine();
        //        if (!int.TryParse(ingreso, out numero))
        //        {
        //            Console.WriteLine(error);
        //            continue;
        //        }






        //    }

        //}
        public static int IngresarInt(string texto, string error, int min, int max)
        {
            while (true)
            {

                int numero;

                Console.WriteLine(texto);

                var ingreso = Console.ReadLine();

                if (!int.TryParse(ingreso, out numero))
                {
                    Console.WriteLine(error);
                    continue;
                }
                if (numero < min || numero > max)
                {
                    Console.WriteLine($"Debe Ingresar un numero entre {min} y {max}'");
                    continue;
                }
                return numero;
            }
        }

    }
}