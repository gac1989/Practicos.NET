using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {

            ManejadorPersonas manejador = new ManejadorPersonas();
            string nombre = "";
            string documento = "";
            string fNac="";
            string opcion = "";
            List<string> personas = null;
            
            do
            {
                mostrarMenu();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        personas = manejador.listarPersonas().Select(x=>x.toString()).ToList();
                        if (personas.Count > 0 )
                        {
                            Console.Clear();
                            personas.ForEach(x =>
                                {
                                    Console.WriteLine(x);
                                });
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("No hay personas ingresadas");
                        }
                        break;
                    case "2":
                        try
                        { 
                            Console.WriteLine("Ingresa tu nombre");
                            nombre = Console.ReadLine();
                            Console.WriteLine("Ingresa tu documento");
                            documento = Console.ReadLine();
                            Console.WriteLine("Ingresa tu fecha de nacimiento (dd-mm-aaaa)");
                            fNac = Console.ReadLine();
                            manejador.ingresarPersona(nombre, documento, fNac);
                            Console.Clear();
                         }
                        catch(Exception e)
                        {   
                            Console.Clear();
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "3":
                        try
                        { 
                            Console.WriteLine("Ingresa tu nombre");
                            nombre = Console.ReadLine();
                            Console.WriteLine("Ingresa tu documento");
                            documento = Console.ReadLine();
                            personas = manejador.filtrarPersonas(nombre, documento).Select(x => x.toString()).ToList();
                            if (personas.Count > 0)
                            {
                                Console.Clear();
                                personas.ForEach(x =>
                                {
                                    Console.WriteLine(x);
                                });
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No hay personas ingresadas con esos datos");
                            }
                        }
                        catch(Exception e)
                        {   
                            Console.Clear();
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Ingresa una opcion valida");
                        break;

                }

            } while (opcion != "4");

            

        }

        public static void mostrarMenu()
        {
            Console.WriteLine("********MENU********");
            Console.WriteLine("-------------------");
            Console.WriteLine("1- Listar Personas");
            Console.WriteLine("2- Ingresar Persona");
            Console.WriteLine("3- Filtrar y Listar");
            Console.WriteLine("4- Salir");
            Console.WriteLine("-------------------");
            Console.WriteLine("Seleccione una opcion");
        }

    }
}