using System;
using System.Collections.Generic;

namespace EjerciciosCSharp
{
    public class Ejercicio6
    {
        public void Ejecutar()
        {
            Console.WriteLine("\n--- Ejercicio 6: Asignaturas a repetir ---");

            // Almacenar las asignaturas en una lista
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Usaremos una copia para iterar y otra para eliminar, o una lista para guardar las aprobadas
            List<string> asignaturasPendientes = new List<string>();

            Console.WriteLine("Por favor, ingresa la nota obtenida en cada asignatura.");
            Console.WriteLine("Consideraremos 7 como nota mínima para aprobar.");

            foreach (string asignatura in asignaturas)
            {
                Console.Write($"¿Qué nota sacaste en {asignatura}?: ");
                string? notaStr = Console.ReadLine();

                if (double.TryParse(notaStr, out double nota))
                {
                    if (nota < 7.0) // Si la nota es menor a 7, la asignatura está reprobada
                    {
                        asignaturasPendientes.Add(asignatura);
                    }
                }
                else
                {
                    Console.WriteLine("Nota no válida. Esta asignatura se considerará pendiente.");
                    asignaturasPendientes.Add(asignatura); // Si la entrada es inválida, se asume pendiente
                }
            }

            Console.WriteLine("\n--- Asignaturas que tienes que repetir ---");
            if (asignaturasPendientes.Count > 0)
            {
                foreach (string pendiente in asignaturasPendientes)
                {
                    Console.WriteLine(pendiente);
                }
            }
            else
            {
                Console.WriteLine("¡Felicidades! Has aprobado todas las asignaturas.");
            }
        }
    }
} 