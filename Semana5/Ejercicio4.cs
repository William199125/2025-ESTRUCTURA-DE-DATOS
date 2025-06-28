using System;
using System.Collections.Generic;
using System.Linq; // Necesario para el método OrderBy

namespace EjerciciosCSharp
{
    public class Ejercicio4
    {
        public void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 4: Números ganadores de la lotería ---");

            List<int> numerosLoteria = new List<int>();
            Console.WriteLine("Por favor, ingresa los números ganadores de la lotería primitiva (uno por uno).");
            Console.WriteLine("Ingresa 'fin' cuando hayas terminado.");

            while (true)
            {
                Console.Write("Número: ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "fin")
                {
                    break;
                }

                if (int.TryParse(input, out int numero))
                {
                    numerosLoteria.Add(numero);
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingresa un número entero o 'fin'.");
                }
            }

            // Ordenar los números de menor a mayor
            numerosLoteria.Sort(); // Otra opción es: numerosLoteria = numerosLoteria.OrderBy(n => n).ToList();

            Console.WriteLine("\nLos números ganadores de la lotería (ordenados de menor a mayor) son:");
            foreach (int numero in numerosLoteria)
            {
                Console.Write($"{numero} ");
            }
            Console.WriteLine(); // Para un salto de línea al final
        }
    }
} 