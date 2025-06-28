using System;
using System.Collections.Generic;

namespace EjerciciosCSharp
{
    public class Ejercicio2
    {
        public void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 2: Asignaturas que estudio ---");

            // Almacenar las asignaturas en una lista
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Mostrar el mensaje por pantalla
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine($"Yo estudio {asignatura}");
            }
        }
    }
} 