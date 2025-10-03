// Importamos los espacios de nombres necesarios.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// Nombre de la empresa y desarrollador.
/*****************************************
* EMPRESA: VUELOS SEGUROS EC           *
* DESARROLLADOR: William Zapata        *
* CURSO: Tercer Semestre de TICS       *
*****************************************/

namespace VuelosSegurosEC
{
    // 1. DEFINICIÓN DE LA ESTRUCTURA DE DATOS
    public class Vuelo
    {
        // SOLUCIÓN PARA CS8618: Inicializamos las propiedades a un valor no nulo por defecto.
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }

        public override string ToString()
        {
            return $"Origen: {Origen}, Destino: {Destino}, Fecha: {Fecha.ToShortDateString()}, Precio: ${Precio:F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vuelo> baseDeDatosVuelos = new List<Vuelo>
            {
                new Vuelo { Origen = "Quito", Destino = "Guayaquil", Fecha = new DateTime(2025, 11, 10), Precio = 85.50 },
                new Vuelo { Origen = "Quito", Destino = "Cuenca", Fecha = new DateTime(2025, 11, 12), Precio = 75.00 },
                new Vuelo { Origen = "Guayaquil", Destino = "Quito", Fecha = new DateTime(2025, 11, 15), Precio = 90.00 },
                new Vuelo { Origen = "Quito", Destino = "Galápagos", Fecha = new DateTime(2025, 12, 01), Precio = 250.75 },
                new Vuelo { Origen = "Cuenca", Destino = "Quito", Fecha = new DateTime(2025, 11, 20), Precio = 70.20 },
                new Vuelo { Origen = "Quito", Destino = "Guayaquil", Fecha = new DateTime(2025, 12, 05), Precio = 80.00 },
                new Vuelo { Origen = "Guayaquil", Destino = "Galápagos", Fecha = new DateTime(2025, 12, 10), Precio = 280.00 }
            };

            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- VUELOS SEGUROS EC ---");
                Console.WriteLine("Bienvenido al sistema de búsqueda de vuelos.");
                Console.WriteLine("1. Buscar Vuelo Más Barato");
                Console.WriteLine("2. Ver Todos los Vuelos Disponibles");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                // SOLUCIÓN PARA CS8600 (parcial): Leemos la opción del usuario.
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        BuscarVueloBarato(baseDeDatosVuelos);
                        break;
                    case "2":
                        MostrarTodosLosVuelos(baseDeDatosVuelos);
                        break;
                    case "3":
                        salir = true;
                        Console.WriteLine("Gracias por usar nuestro sistema. ¡Buen viaje! ✈️");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }

        static void BuscarVueloBarato(List<Vuelo> vuelos)
        {
            Console.Write("Ingrese la ciudad de origen: ");
            // SOLUCIÓN PARA CS8600 y CS8602: Asignamos un valor por defecto si la entrada es nula.
            string origen = Console.ReadLine()?.Trim() ?? string.Empty;
            
            Console.Write("Ingrese la ciudad de destino: ");
            string destino = Console.ReadLine()?.Trim() ?? string.Empty;

            // Verificamos si el usuario ingresó datos válidos
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
            {
                Console.WriteLine("El origen y el destino no pueden estar vacíos.");
                return; // Salimos del método si la entrada no es válida
            }

            // La consulta LINQ ya no genera advertencias porque 'origen' y 'destino' no son nulos.
            var vueloMasBarato = vuelos
                .Where(v => v.Origen.Equals(origen, StringComparison.OrdinalIgnoreCase) &&
                            v.Destino.Equals(destino, StringComparison.OrdinalIgnoreCase))
                .OrderBy(v => v.Precio)
                .FirstOrDefault();

            Console.WriteLine("\n--- RESULTADO DE LA BÚSQUEDA ---");
            if (vueloMasBarato != null)
            {
                Console.WriteLine("¡Vuelo más económico encontrado!");
                Console.WriteLine(vueloMasBarato);
            }
            else
            {
                Console.WriteLine($"No se encontraron vuelos de {origen} a {destino}.");
            }
        }

        static void MostrarTodosLosVuelos(List<Vuelo> vuelos)
        {
            Console.WriteLine("\n--- LISTA COMPLETA DE VUELOS ---");
            if (vuelos.Any())
            {
                foreach (var vuelo in vuelos)
                {
                    Console.WriteLine(vuelo);
                }
            }
            else
            {
                Console.WriteLine("No hay vuelos registrados en la base de datos.");
            }
        }
    }
} 