using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Inscripcion

    {
        public Inscripcion() { }


        Carrera carrera = new Carrera();
        Alumno alumnoLogeado = new Alumno();
        PlanDeEstudio planDeEstudio = new PlanDeEstudio();
        int loginRegistro;
        int codigoCarrera;
        Solicitud alumnoSolicitud = new Solicitud();
        List<Solicitud> listaSolicitud = new List<Solicitud>();
        MateriasAprobadas alumnoMatApro = new MateriasAprobadas();
        List<Curso> OfertaSinMateriasAprobadas = new List<Curso>();
        
        



        public void Login()
        {
            bool salir = false;
            do
            {
                Console.WriteLine("-----------------------------Bienvenido-------------------------------");
                Console.WriteLine("------------------------Al Portal De Alumnos--------------------------");
                Console.WriteLine("----------------------------------------------------------------------\n");
                Console.WriteLine();
                Console.WriteLine("Presiona cualquier tecla para seguir o ingrese exit para salir");
                string ingreso = Console.ReadLine().ToUpperInvariant();
                if (ingreso == "EXIT")
                {
                    salir = true;
                    break;
                }
                else
                {
                    bool alumnoNoExiste = false;
                    do
                    {
                        loginRegistro = Ingresos.IngresarNumeroRegistro($"Para ingresar, ingrese su numero de Registro", "No es un numero, intente de nuevo.", 100000, 900000);//TODO: hacer que tenga opcion de seguir o no
                        alumnoLogeado = alumnoLogeado.BuscarAlumno(loginRegistro);
                        if (alumnoLogeado.Registro == 0)
                        {
                            Console.WriteLine($"El registro: {loginRegistro} no se encuentra en el sistema. Intente de nuevo:");
                            alumnoNoExiste = true;
                            break;
                            // TODO: no corta bien revisar como mejorar. 


                        }
                        else
                        {
                            Console.WriteLine($"Bienvenido {alumnoLogeado.Nombre} {alumnoLogeado.Apellido}\nNumero de registro:{alumnoLogeado.Registro}");
                            Console.WriteLine("-------------------------------------------------------------------------------------");

                            int opcionMenu = Ingresos.IngresarInt("Selecione la instancia de inscricpion:" +
                                                 "\n1 - Inscirpcion Regular\n" +
                                                 "2 - Inscirpcion Cobertura de Vacantes\n" +
                                                 "3 - Inscirpcion curso intensivo\n" +
                                                 "4 - Salir\n", "Debe ingresar un numero, intente de nuevo:", 1, 4);

                            Console.WriteLine("---------------------------------------------------------------------------------------");
                            switch (opcionMenu)
                            {
                                case 1:
                                    if (!alumnoSolicitud.BuscarSolicitud(loginRegistro))
                                    {
                                        codigoCarrera = SeleccionCarrera();

                                        string nombreArchivo = carrera.devolverNombreArchivo(codigoCarrera);
                                        OfertaAcademica alumnoOferta = new OfertaAcademica(nombreArchivo);

                                        List<MateriasAprobadas> listaMatApro = alumnoMatApro.ListaAlumno(loginRegistro);

                                        
                                        //listaMatApro = alumnoMatApro.ListaAlumno(loginRegistro);
                                     

                                        foreach (MateriasAprobadas m in listaMatApro) 
                                        {
                                            Console.WriteLine(m.CodigoMateria);

                                        }
                                        Console.ReadKey();

                                        //alumnoOferta.MostrarOferta(); 





                                        Console.WriteLine("Actualmente estas cursando las ultimas 4 materias? (Ingrese S para si y N para no)"); // falta validacion armar clase carrera con sus datos dada cada carrera. 



                                    }
                                    else
                                    {
                                        Console.WriteLine("Usted ya tiene una solicitud de inscripcion pendiente, presione cualquier tecla para volver");
                                        
                                    }
                                    break;
                                    
                                case 2:
                                    Console.WriteLine("Esta instancia de inscripcion no esta habilitada en este momento, por favor revise el calendario academico.");
                                    break;
                                case 3:
                                    Console.WriteLine("Esta instancia de inscripcion no esta habilitada en este momento, por favor revise el calendario academico.");
                                    break;
                                case 4:
                                    break; 
                            }



                            string ingreso2 = Console.ReadLine().ToUpperInvariant();

                            if (ingreso == "EXIT")//revisar estructura no corta al ingresar exit.
                            {
                                salir = true;
                                break;
                            }
                            else
                            {

                                Console.WriteLine("Ingrese el codigo de carrera:");
                                codigoCarrera = Ingresos.IngresarInt("Ingrese Codigo de carrera", "Debe ser un numero, intente de nuevo:", 1, 6);



                            }
                            Console.WriteLine("Saliendo del portal, hasta luego!");
                            salir = true;
                            break;

                        }

                    } while (!alumnoNoExiste);


                }


            } while (!salir);
        }


        public void GenerarArchivos()
        {
            alumnoLogeado.generarArchivo();
            alumnoMatApro.GenerarArchivo();

        }
        public int SeleccionCarrera()
        {
            int carrera = Ingresos.IngresarInt("\nIngrese la carrera:\n" +
                                                "\n1 - Sistemas\n" +
                                                "2 - Contador\n" +
                                                "3 - Administración\n" +
                                                "4 - Economía\n" +
                                                "5 - Actuario en Administración\n" +
                                                "6 - Actuario en Economía\n", "Debe ser un numero, intente de nuevo", 1, 6);
            return carrera;

        }


        public void MostrarOferta(string archivo)
        {
            OfertaAcademica ofertaSistemas = new OfertaAcademica(archivo);
            ofertaSistemas.MostrarOferta();



        }

        public void seleccionmateria()
        {
            int materiaselecionada = Ingresos.IngresarInt("ingrese codigo de materia", "el codigo debe ser un numero, ingrese otro:", 1, 9);


            //var existe = ofertasistemas.validarcurso(materiaselecionada);

        }

        //public int NumeroLegajo { get; set; }

        //public int Registro { get; set; }

        //public int CodigoCurso { get; set; }

        //public int CodCursoAlternativo { get; set; }

        //public string InstanciaInscripcion { get; set; }


        //public DateTime Fecha { get; set;  }



        //public Inscripcion(int legajo,int registro, string instancia,  int codigoCurso, int codCursoAlt, DateTime fecha) 
        //{
        //    NumeroLegajo = legajo;
        //    Registro = registro;
        //    InstanciaInscripcion = instancia; 
        //    CodigoCurso = codigoCurso;
        //    CodCursoAlternativo = codCursoAlt; 


        //}


        //List<Oferta> ofertaCarrera = new List<Oferta>();





        //pedir carrera
        //mostrar materias segun carrera
        //public Inscripcion() 
        //{

        //    bool salir = false;
        //    do
        //    {


        //    } while (!salir);

    }
}
        // necesitamos validar aca que carrera para despues mandar ese string para selecionar que arhivo vamos a leer, nuestro filtro abre cierto txt

       
       
       

