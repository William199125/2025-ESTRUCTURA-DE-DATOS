using System;

namespace EjerciciosCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido a la colección de ejercicios en C#!");

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Menú de Ejercicios ---");
                Console.WriteLine("1. Ejercicio 2: Asignaturas que estudio");
                Console.WriteLine("2. Ejercicio 4: Números ganadores de la lotería");
                Console.WriteLine("3. Ejercicio 5: Números del 1 al 10 en orden inverso");
                Console.WriteLine("4. Ejercicio 6: Asignaturas a repetir");
                Console.WriteLine("5. Ejercicio 9: Conteo de vocales en una palabra");
                Console.WriteLine("0. Salir");
                Console.Write("Por favor, selecciona el número del ejercicio que deseas ejecutar (0 para salir): ");

                string? opcionStr = Console.ReadLine();
                if (int.TryParse(opcionStr, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            new Ejercicio2().Ejecutar();
                            break;
                        case 2:
                            new Ejercicio4().Ejecutar();
                            break;
                        case 3:
                            new Ejercicio5().Ejecutar();
                            break;
                        case 4:
                            new Ejercicio6().Ejecutar();
                            break;
                        case 5:
                            new Ejercicio9().Ejecutar();
                            break;
                        case 0:
                            salir = true;
                            Console.WriteLine("¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número.");
                }
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpia la consola para una mejor experiencia
            }
        }
    }
} 