using System;
using System.Collections.Generic;
using System.Linq; // Necesario para Reverse()

namespace EjerciciosCSharp
{
    public class Ejercicio5
    {
        public void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 5: Números del 1 al 10 en orden inverso ---");

            // Almacenar los números del 1 al 10 en una lista
            List<int> numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }

            // Mostrar los números en orden inverso separados por comas
            // Opción 1: Iterar en reversa
            Console.Write("Números en orden inverso (Opción 1): ");
            for (int i = numeros.Count - 1; i >= 0; i--)
            {
                Console.Write(numeros[i]);
                if (i > 0)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();

            // Opción 2: Usar Reverse() y String.Join()
            numeros.Reverse(); // Invierte la lista en su lugar
            Console.WriteLine($"Números en orden inverso (Opción 2): {string.Join(", ", numeros)}");
        }
    }
} 