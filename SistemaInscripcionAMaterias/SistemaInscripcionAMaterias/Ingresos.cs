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
        public static int IngresarNumero(string texto, string error)
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
                return numero;
            }
        }
        public static string IngresarCodMateria(string texto, int largoMin, int largoMax)
        {
            while (true)
            {
                Console.WriteLine(texto);
                string ingreso = Console.ReadLine();

                if (ingreso.Length < largoMin || ingreso.Length > largoMax)
                {
                    Console.WriteLine($"Debe ingresar un codigo de materia ejemplo '252/'");
                    continue;
                }
                return ingreso;
            }
        }

    }
}