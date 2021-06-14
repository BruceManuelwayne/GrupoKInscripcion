﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInscripcionAMaterias
{
    class Inscripcion

    {
        public Inscripcion() { }

        Correlativas correlativas = new Correlativas();
        Carrera carrera = new Carrera();
        Alumno alumnoLogeado = new Alumno();
        Solicitud alumnoSolicitud = new Solicitud();
        PlanDeEstudio alumnoPlan = new PlanDeEstudio();

        int loginRegistro;
        int codigoCarrera;
        int codigoMateria;
        int codigoCurso;
        int codigoCursoAlt;
        bool solicitudPendiente = false;

        List<Solicitud> listaSolicitudActual = new List<Solicitud>();
        MateriasAprobadas alumnoMatApro = new MateriasAprobadas();
        List<Correlativas> listaCarreraCorr = new List<Correlativas>();
        List<PlanDeEstudio> planSegunCarrera = new List<PlanDeEstudio>();
  
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
                    salir = false;
                    do
                    {

                        loginRegistro = Ingresos.IngresarNumeroRegistro($"Para ingresar, ingrese su numero de Registro", "No es un numero, intente de nuevo.", 100000, 900000);//TODO: hacer que tenga opcion de seguir o no
                        bool loginValido = alumnoLogeado.ExisteAlumno(loginRegistro);
                        if (loginValido == true)
                        {
                            alumnoLogeado = alumnoLogeado.BuscarAlumno(loginRegistro);

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
                                    solicitudPendiente = alumnoSolicitud.ExisteSolicitud(alumnoLogeado.Registro);
                                    if (solicitudPendiente == false)
                                    {
                                        List<MateriasAprobadas> listaMatApro = alumnoMatApro.ListaAlumno(loginRegistro);
                                        int cantidadMaterFaltantes = CalcularMateriasPendientes(alumnoLogeado.CodigoCarrera, listaMatApro);
                                        if (cantidadMaterFaltantes <= 4)
                                        {
                                            for (int i = 0; i < 4; i++)
                                            {
                                                Console.WriteLine("Actualmente estas cursando las ultimas 4 materias");
                                                Console.WriteLine("Tu cuarta materia regular esta habilitada!");
                                                Console.WriteLine("------------------------------------------------------------------------");
                                                codigoCarrera = SeleccionCarrera();
                                                InscripcionMaterias(codigoCarrera);
                                                if (i < 2)
                                                {
                                                    Console.WriteLine("Desea elegir otra materia para la inscripcion?(S/N)");
                                                    var key = Console.ReadKey(intercept: true);
                                                    if (key.Key == ConsoleKey.S)
                                                    {

                                                    }
                                                    if (key.Key == ConsoleKey.N)

                                                    {
                                                        i = 4;
                                                    }
                                                }
                                                if (i < 3)
                                                {
                                                    Console.WriteLine("Desea elegir otra materia para la inscripcion?(S/N)");
                                                    var key = Console.ReadKey(intercept: true);
                                                    if (key.Key == ConsoleKey.S)
                                                    {

                                                    }
                                                    if (key.Key == ConsoleKey.N)

                                                    {
                                                        i = 4;
                                                    }

                                                }

                                            }
                                            alumnoSolicitud.AgregarSolicitud(listaSolicitudActual);
                                            GuardarSolicitud(listaSolicitudActual);
                                            salir = true;
                                        }
                                        else 
                                        {
                                            for (int i = 0; i < 3; i++)
                                            {

                                                codigoCarrera = SeleccionCarrera();
                                                InscripcionMaterias(codigoCarrera);
                                                if (i < 2)
                                                {
                                                    Console.WriteLine("Desea elegir otra materia para la inscripcion?(S/N)");
                                                    var key = Console.ReadKey(intercept: true);
                                                    if (key.Key == ConsoleKey.S)
                                                    {

                                                    }
                                                    if (key.Key == ConsoleKey.N)

                                                    {
                                                        i = 3;
                                                    }
                                                }

                                            }
                                            alumnoSolicitud.AgregarSolicitud(listaSolicitudActual);
                                            GuardarSolicitud(listaSolicitudActual);
                                            salir = true;

                                        }

                                    }
                                    else
                                    {
                                        break;
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
                        }
                        else
                        {
                            continue;
                        }

                        Console.WriteLine("Saliendo del portal, hasta luego!");
                        salir = true;
                        break;

                    } while (!salir);

                } while (!salir) ;

            } while (!salir);
        }


        public void GenerarArchivos()
        {
            alumnoLogeado.generarArchivo();
            alumnoMatApro.GenerarArchivo();
            correlativas.GenerarArchivo();
            alumnoSolicitud.generarArchivo();
            alumnoPlan.GenerarArchivo();


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
        public void InscripcionMaterias(int codCarrera)
        {


            string nombreArchivo = carrera.devolverNombreArchivo(codigoCarrera);
            OfertaAcademica alumnoOferta = new OfertaAcademica(nombreArchivo);

            List<MateriasAprobadas> listaMatApro = alumnoMatApro.ListaAlumno(loginRegistro);

            listaCarreraCorr = correlativas.CorreSegunCarrera(codigoCarrera);
            List<Correlativas> CorrelativasFaltantes = new List<Correlativas>();

            CorrelativasFaltantes = correlativas.listaAlumnoCorr(listaMatApro, listaCarreraCorr);
            List<Curso> OfertaSinCorrelativasFaltantes = new List<Curso>();
            OfertaSinCorrelativasFaltantes = alumnoOferta.FiltrarOfertaCorrelativas(CorrelativasFaltantes);

            List<Curso> OfertaSinCorreSinMatApro = new List<Curso>();
            OfertaSinCorreSinMatApro = alumnoOferta.FiltrarMatAprobadas(listaMatApro, OfertaSinCorrelativasFaltantes);
            alumnoOferta.MostrarOfertaFiltrada(OfertaSinCorreSinMatApro);
            List<int> materiasSelecionadas = new List<int>();

            while (true)
            {
                bool existe = false;
                codigoMateria = Ingresos.IngresarIntSimple("Ingrese codigo de materia para inscripcion:", "El codigo de materia debe ser un numero:");
                existe = ExisteMateria(codigoMateria, OfertaSinCorreSinMatApro);
                if (existe == false)
                {
                    Console.WriteLine($"El codigo {codigoMateria} no existe en la oferta, intente de nuevo");
                }
                else
                {
                    existe = true;
                    break;
                }



            }

            alumnoOferta.MostrarSegunMateria(OfertaSinCorreSinMatApro, codigoMateria);
            while (true)
            {
                bool existe = false;
                codigoCurso = Ingresos.IngresarIntSimple("Para elegir el curso , ingrese el codigo de curso", "Debe ser un numero el codigo:");
                existe = ExisteCurso(codigoCurso, OfertaSinCorreSinMatApro);
                if (existe == false)
                {
                    Console.WriteLine($"El codigo {codigoCurso} no existe en la oferta, intente de nuevo");
                }
                else
                {
                    existe = true;
                    break;
                }

            }
         
            Console.WriteLine($"Desea agregar un curso alternativo?(S/N)\n");
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.S)
            {
                while (true)
                {
                    bool existe = false;
                    codigoCursoAlt = Ingresos.IngresarIntSimple("Para elegir el curso , ingrese el codigo de curso", "Debe ingresar un numero, intente de nuevo:");
                    existe = ExisteCurso(codigoCursoAlt, OfertaSinCorreSinMatApro);
                    if (existe == false)
                    {
                        Console.WriteLine($"El codigo {codigoCurso} no existe en la oferta, intente de nuevo");
                    }
                    if (codigoCurso == codigoCursoAlt)
                    {
                        Console.WriteLine("El curso alternativo no puede ser igual al curso elegido, ingrese otro: ");
                    }
                    else
                    {
                        existe = true;
                        break;
                    }

                }
            }
            else
            {
                codigoCursoAlt = 0;
            }

            alumnoSolicitud = CrearSolicitud(loginRegistro, codigoCarrera, codigoMateria, codigoCurso, codigoCursoAlt);
            bool confirma = ConfirmarSeleccion();
            if (confirma == true)
            {

                listaSolicitudActual.Add(alumnoSolicitud);

            }

        }
        public bool ConfirmarSeleccion()
        {
            bool confirma = false; ;
            Console.WriteLine($"Confirmas Seleccion de materia?(S/N)\n");
            var key = Console.ReadKey(intercept: true);
            do
            {
                if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Su seleccion ha sido procesada");
                    confirma = true;
                    break;
                }
                if (key.Key == ConsoleKey.N)
                {
                    confirma = false;
                    Console.WriteLine("No fue procesada tu seleccion");
                    break;
                }


            } while (key.Key == ConsoleKey.S || key.Key == ConsoleKey.N);

            return confirma;
        }

        public void GuardarSolicitud(List<Solicitud> listaSolParaGuardar)
        {
            foreach (Solicitud s in listaSolParaGuardar)
            {
                s.Guardar();
            }
            Console.WriteLine("\n-------------------------Lista de solicitud registrada!-------------------------------------\n");
            ClearLists();
        }
        public Solicitud CrearSolicitud(int registro, int carrera, int materia, int curso, int cursoAlterantivo)
        {
            DateTime fecha = DateTime.Now;
            Solicitud nuevaSolicitud = new Solicitud(registro, carrera, materia, curso, cursoAlterantivo, fecha);
            return nuevaSolicitud;
        }
        public void ClearLists()
        {
            listaCarreraCorr.Clear();
            planSegunCarrera.Clear();

        }
       
        public bool ExisteMateria(int codigo, List<Curso> oferta)
        {

            int posicion = 0;
            bool seEncontro = false;
            while (posicion < oferta.Count && !seEncontro)
            {
                if (oferta[posicion].CodigoMateria == codigo)
                {
                    seEncontro = true;


                }
                else
                {
                    posicion++;
                }

            }
            return seEncontro;
        }
        public int CalcularMateriasPendientes(int codCarreraAlumno, List<MateriasAprobadas>listaAlumnoMateriasAprobadas) 
        {
            int cantidadTotalMat;
            int cantidadTotalAprobadas;
            List<PlanDeEstudio> MateriasSegunCarrera = new List<PlanDeEstudio>();
            MateriasSegunCarrera = alumnoPlan.MateriasDadoCarrera(codCarreraAlumno);
            cantidadTotalMat = alumnoPlan.CountMateriasCarrera(MateriasSegunCarrera);
            cantidadTotalAprobadas = listaAlumnoMateriasAprobadas.Count();
            int diferencia = cantidadTotalMat - cantidadTotalAprobadas;
            return diferencia;

        }
        public bool ExisteCurso(int codigo, List<Curso> oferta)
        {
            int posicion = 0;
            bool seEncontro = false;
            while (posicion < oferta.Count && !seEncontro)
            {
                if (oferta[posicion].CodigoCurso == codigo)
                {
                    seEncontro = true;


                }
                else
                {
                    posicion++;
                }

            }
            return seEncontro;

        }
    }
}



       
       
       

