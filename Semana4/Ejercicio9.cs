using System;
using System.Collections.Generic;
using System.Linq; // Necesario para ToLower()

namespace EjerciciosCSharp
{
    public class Ejercicio9
    {
        public void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 9: Conteo de vocales en una palabra ---");

            Console.Write("Por favor, ingresa una palabra: ");
            string? palabra = Console.ReadLine();

            if (string.IsNullOrEmpty(palabra))
            {
                Console.WriteLine("No ingresaste ninguna palabra.");
                return;
            }

            // Convertir la palabra a minúsculas para un conteo no sensible a mayúsculas/minúsculas
            palabra = palabra.ToLower();

            // Usar un diccionario para almacenar el conteo de cada vocal
            Dictionary<char, int> conteoVocales = new Dictionary<char, int>
            {
                {'a', 0},
                {'e', 0},
                {'i', 0},
                {'o', 0},
                {'u', 0}
            };

            foreach (char caracter in palabra)
            {
                if (conteoVocales.ContainsKey(caracter))
                {
                    conteoVocales[caracter]++;
                }
            }

            Console.WriteLine($"\nConteo de vocales en la palabra \"{palabra}\":");
            foreach (var vocal in conteoVocales)
            {
                Console.WriteLine($"- La vocal '{vocal.Key}' aparece {vocal.Value} veces.");
            }
        }
    }
} 