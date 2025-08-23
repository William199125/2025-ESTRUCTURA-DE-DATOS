// --------------------------------------------------------------------------------
// Universidad Estatal Amazónica (UEA)
// Carrera de Tecnologías de la Información
// Tercer Semestre
//
// Asignatura: Estructura de Datos
// Deber: Aplicación de Teoría de Conjuntos con Menú Interactivo
//
// Autor: William Zapata
// Fecha: 23 de agosto de 2025
//
// Descripción:
// Versión mejorada del programa de análisis de vacunación. Este código
// implementa un menú interactivo que permite al usuario seleccionar y consultar
// los diferentes listados generados a través de operaciones de teoría de conjuntos.
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Se define un 'record' para representar a un ciudadano.
/// Esto facilita las operaciones de conjunto, ya que la igualdad se basa
/// automáticamente en los valores de sus propiedades (Id y Nombre).
/// </summary>
public record Ciudadano(int Id, string Nombre);

public class CampanaVacunacionInteractiva
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=======================================================================");
        Console.WriteLine(" ANÁLISIS DE CAMPAÑA DE VACUNACIÓN COVID-19 - MINISTERIO DE SALUD");
        Console.WriteLine("=======================================================================");
        Console.WriteLine("                  Realizado por: William Zapata\n");

        // --- PASO 1: GENERACIÓN Y CÁLCULO DE DATOS (Se hace una sola vez) ---
        
        // CONJUNTO UNIVERSAL (U)
        var universoCiudadanos = new HashSet<Ciudadano>();
        for (int i = 1; i <= 500; i++)
        {
            universoCiudadanos.Add(new Ciudadano(i, $"Ciudadano {i}"));
        }

        // SUBCONJUNTO A: Vacunados con Pfizer
        var vacunadosPfizer = new HashSet<Ciudadano>();
        for (int i = 1; i <= 75; i++)
        {
            vacunadosPfizer.Add(new Ciudadano(i, $"Ciudadano {i}"));
        }

        // SUBCONJUNTO B: Vacunados con AstraZeneca
        var vacunadosAstraZeneca = new HashSet<Ciudadano>();
        for (int i = 51; i <= 125; i++) // Solapamiento del 51 al 75
        {
            vacunadosAstraZeneca.Add(new Ciudadano(i, $"Ciudadano {i}"));
        }

        // --- CÁLCULO DE LISTADOS MEDIANTE TEORÍA DE CONJUNTOS ---

        // Unión (A U B)
        var todosLosVacunados = new HashSet<Ciudadano>(vacunadosPfizer);
        todosLosVacunados.UnionWith(vacunadosAstraZeneca);

        // Diferencia (U - (A U B))
        var noVacunados = new HashSet<Ciudadano>(universoCiudadanos);
        noVacunados.ExceptWith(todosLosVacunados);
        
        // Intersección (A ∩ B)
        var conAmbasDosis = new HashSet<Ciudadano>(vacunadosPfizer);
        conAmbasDosis.IntersectWith(vacunadosAstraZeneca);

        // Diferencia (A - B)
        var soloPfizer = new HashSet<Ciudadano>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);
        
        // Diferencia (B - A)
        var soloAstraZeneca = new HashSet<Ciudadano>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);


        // --- PASO 2: MENÚ INTERACTIVO ---
        bool salir = false;
        while (!salir)
        {
            Console.Clear(); // Limpia la consola para mostrar el menú
            Console.WriteLine("====================== MENÚ DE CONSULTAS ======================");
            Console.WriteLine("          Seleccione el listado que desea consultar:\n");
            Console.WriteLine("   1. Ver ciudadanos que NO se han vacunado");
            Console.WriteLine("   2. Ver ciudadanos que han recibido AMBAS dosis");
            Console.WriteLine("   3. Ver ciudadanos que han recibido SOLO la vacuna de Pfizer");
            Console.WriteLine("   4. Ver ciudadanos que han recibido SOLO la vacuna de AstraZeneca");
            Console.WriteLine("   5. Ver resumen general de la campaña");
            Console.WriteLine("   6. Salir del programa");
            Console.WriteLine("===============================================================");
            Console.Write("\n   Ingrese su opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ImprimirListado("Listado 1: Ciudadanos que NO se han vacunado", noVacunados);
                    break;
                case "2":
                    ImprimirListado("Listado 2: Ciudadanos que han recibido AMBAS dosis", conAmbasDosis);
                    break;
                case "3":
                    ImprimirListado("Listado 3: Ciudadanos que han recibido SOLO Pfizer", soloPfizer);
                    break;
                case "4":
                    ImprimirListado("Listado 4: Ciudadanos que han recibido SOLO AstraZeneca", soloAstraZeneca);
                    break;
                case "5":
                    MostrarResumen(universoCiudadanos.Count, vacunadosPfizer.Count, vacunadosAstraZeneca.Count, todosLosVacunados.Count);
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("\nCerrando el programa. ¡Hasta pronto!\n");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
            }
        }
    }

    /// <summary>
    /// Función para mostrar de forma ordenada los ciudadanos de cada listado.
    /// </summary>
    public static void ImprimirListado(string titulo, IEnumerable<Ciudadano> listado)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------------------------------------------");
        Console.WriteLine($"{titulo} -> Total: {listado.Count()}");
        Console.WriteLine("-----------------------------------------------------------------------");

        if (!listado.Any())
        {
            Console.WriteLine("No se encontraron ciudadanos para este listado.");
            return;
        }

        // Muestra los primeros 15 resultados para dar más detalle.
        foreach (var ciudadano in listado.Take(15))
        {
            Console.WriteLine($"- ID: {ciudadano.Id}, Nombre: {ciudadano.Nombre}");
        }

        if (listado.Count() > 15)
        {
            Console.WriteLine($"... y {listado.Count() - 15} más.");
        }
    }

    /// <summary>
    /// Muestra un resumen con las cifras totales de la campaña.
    /// </summary>
    public static void MostrarResumen(int total, int pfizer, int astra, int vacunados)
    {
        Console.Clear();
        Console.WriteLine("------------------- RESUMEN GENERAL DE LA CAMPAÑA -------------------");
        Console.WriteLine($"   Total de ciudadanos en el sistema: {total}");
        Console.WriteLine($"   Total de dosis Pfizer administradas: {pfizer}");
        Console.WriteLine($"   Total de dosis AstraZeneca administradas: {astra}");
        Console.WriteLine($"   Total de ciudadanos con al menos una dosis: {vacunados}");
        Console.WriteLine("-----------------------------------------------------------------------");
    }
} 