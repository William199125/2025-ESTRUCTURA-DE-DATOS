// --------------------------------------------------------------------
// Título: Aplicación para Registro de Equipos y Jugadores
// Descripción: Gestiona un torneo de fútbol barrial usando diccionarios y conjuntos.
// Desarrollador: William Zapata
// Curso: Tercer semestre de TICs, UEA
// --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

// Definimos una clase para representar a un jugador con su dorsal y nombre.
// Usamos 'record' para obtener automáticamente la igualdad basada en valores.
public record Jugador(int Dorsal, string Nombre);

class Program
{
    // El mapa principal que relaciona el nombre del equipo (string) con su conjunto de jugadores (HashSet).
    static Dictionary<string, HashSet<Jugador>> torneo = new Dictionary<string, HashSet<Jugador>>();

    static void Main(string[] args)
    {
        // Configuramos la consola para que acepte caracteres especiales como tildes.
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        CargarDatosIniciales();

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("======================================================");
            Console.WriteLine("⚽ Aplicación de Registro de Fútbol Barrial Pichincha ⚽");
            Console.WriteLine("======================================================");
            Console.WriteLine("Desarrollado por: William Zapata (Tercer Semestre TICs, UEA)\n");
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Registrar un nuevo equipo");
            Console.WriteLine("2. Registrar un jugador en un equipo");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("3. Visualizar todos los equipos con sus jugadores");
            Console.WriteLine("4. Consultar los jugadores de un equipo específico");
            Console.WriteLine("5. Consultar a qué equipo pertenece un jugador");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("6. Mostrar estadísticas del torneo");
            Console.WriteLine("7. Salir");
            Console.WriteLine("======================================================");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarNuevoEquipo();
                    break;
                case "2":
                    RegistrarJugadorEnEquipo();
                    break;
                case "3":
                    VisualizarTodosLosEquipos();
                    break;
                case "4":
                    ConsultarJugadoresPorEquipo();
                    break;
                case "5":
                    ConsultarEquipoPorJugador();
                    break;
                case "6":
                    MostrarEstadisticas();
                    break;
                case "7":
                    salir = true;
                    Console.WriteLine("\n¡Gracias por usar la aplicación! Hasta luego.");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void CargarDatosIniciales()
    {
        torneo["Barcelona FC"] = new HashSet<Jugador>
        {
            new Jugador(9, "Robert Lewandowski"),
            new Jugador(8, "Pedri"),
            new Jugador(27, "Lamine Yamal"),
            new Jugador(1, "Marc-André ter Stegen"),
            new Jugador(21, "Frenkie de Jong")
        };

        torneo["Liverpool FC"] = new HashSet<Jugador>
        {
            new Jugador(11, "Mohamed Salah"),
            new Jugador(4, "Virgil van Dijk"),
            new Jugador(7, "Luis Díaz"),
            new Jugador(66, "Trent Alexander-Arnold"),
            new Jugador(10, "Alexis Mac Allister")
        };

        torneo["Arsenal"] = new HashSet<Jugador>
        {
            new Jugador(7, "Bukayo Saka"),
            new Jugador(8, "Martin Ødegaard"),
            new Jugador(41, "Declan Rice"),
            new Jugador(2, "William Saliba"),
            new Jugador(11, "Gabriel Martinelli")
        };

        torneo["Real Sociedad"] = new HashSet<Jugador>
        {
            new Jugador(10, "Mikel Oyarzabal"),
            new Jugador(14, "Takefusa Kubo"),
            new Jugador(8, "Mikel Merino"),
            new Jugador(23, "Brais Méndez"),
            new Jugador(1, "Álex Remiro")
        };

        torneo["Chelsea FC"] = new HashSet<Jugador>
        {
            new Jugador(20, "Cole Palmer"),
            new Jugador(25, "Moisés Caicedo"),
            new Jugador(8, "Enzo Fernández"),
            new Jugador(7, "Raheem Sterling"),
            new Jugador(27, "Malo Gusto")
        };
    }

    static void RegistrarNuevoEquipo()
    {
        Console.WriteLine("\n--- Registro de Nuevo Equipo ---");
        Console.Write("Ingrese el nombre del nuevo equipo: ");
        string? nombreEquipo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombreEquipo))
        {
            Console.WriteLine("El nombre del equipo no puede estar vacío.");
            return;
        }

        if (torneo.ContainsKey(nombreEquipo))
        {
            Console.WriteLine($"El equipo '{nombreEquipo}' ya está registrado.");
        }
        else
        {
            torneo[nombreEquipo] = new HashSet<Jugador>();
            Console.WriteLine($"¡Equipo '{nombreEquipo}' registrado con éxito!");
        }
    }

    static void RegistrarJugadorEnEquipo()
    {
        Console.WriteLine("\n--- Registro de Jugador en Equipo ---");
        Console.Write("Ingrese el nombre del equipo: ");
        string? nombreEquipo = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombreEquipo) || !torneo.ContainsKey(nombreEquipo))
        {
            Console.WriteLine($"Error: El equipo '{nombreEquipo}' no se encuentra registrado.");
            return;
        }

        Console.Write("Ingrese el nombre del jugador: ");
        string? nombreJugador = Console.ReadLine();

        Console.Write("Ingrese el dorsal (número) del jugador: ");
        if (!int.TryParse(Console.ReadLine(), out int dorsal))
        {
            Console.WriteLine("Dorsal inválido. Debe ser un número.");
            return;
        }

        if (string.IsNullOrWhiteSpace(nombreJugador))
        {
            Console.WriteLine("El nombre del jugador no puede estar vacío.");
            return;
        }
        
        var nuevoJugador = new Jugador(dorsal, nombreJugador);

        // El método Add de HashSet devuelve 'true' si el elemento se agregó
        // y 'false' si ya existía.
        if (torneo[nombreEquipo].Add(nuevoJugador))
        {
            Console.WriteLine($"Jugador '{nombreJugador}' con dorsal {dorsal} agregado a '{nombreEquipo}' con éxito.");
        }
        else
        {
            Console.WriteLine($"El jugador '{nombreJugador}' con el dorsal {dorsal} ya existe en el equipo '{nombreEquipo}'.");
        }
    }

    static void VisualizarTodosLosEquipos()
    {
        Console.WriteLine("\n--- Listado de Equipos y Jugadores ---");
        if (torneo.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados todavía.");
            return;
        }

        foreach (var equipo in torneo)
        {
            Console.WriteLine($"\n✅ Equipo: {equipo.Key}");
            if (equipo.Value.Count == 0)
            {
                Console.WriteLine("   (Este equipo no tiene jugadores registrados)");
            }
            else
            {
                foreach (var jugador in equipo.Value.OrderBy(j => j.Dorsal))
                {
                    Console.WriteLine($"   - Dorsal: {jugador.Dorsal}, Nombre: {jugador.Nombre}");
                }
            }
        }
    }

    static void ConsultarJugadoresPorEquipo()
    {
        Console.WriteLine("\n--- Consulta de Jugadores por Equipo ---");
        Console.Write("Ingrese el nombre del equipo que desea consultar: ");
        string? nombreEquipo = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nombreEquipo) && torneo.TryGetValue(nombreEquipo, out HashSet<Jugador>? jugadores))
        {
            Console.WriteLine($"\nJugadores del equipo '{nombreEquipo}':");
            if (jugadores.Count == 0)
            {
                Console.WriteLine("No hay jugadores registrados en este equipo.");
            }
            else
            {
                foreach (var jugador in jugadores.OrderBy(j => j.Dorsal))
                {
                    Console.WriteLine($"   - Dorsal: {jugador.Dorsal}, Nombre: {jugador.Nombre}");
                }
            }
        }
        else
        {
            Console.WriteLine($"El equipo '{nombreEquipo}' no fue encontrado.");
        }
    }

    static void ConsultarEquipoPorJugador()
    {
        Console.WriteLine("\n--- Consultar Equipo por Jugador ---");
        Console.Write("Ingrese el nombre del jugador a buscar: ");
        string? nombreJugadorBusqueda = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nombreJugadorBusqueda))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }

        string? equipoEncontrado = null;
        foreach (var equipo in torneo)
        {
            // Buscamos si algún jugador en el equipo tiene ese nombre (ignorando mayúsculas/minúsculas).
            if (equipo.Value.Any(j => j.Nombre.Equals(nombreJugadorBusqueda, StringComparison.OrdinalIgnoreCase)))
            {
                equipoEncontrado = equipo.Key;
                break;
            }
        }

        if (equipoEncontrado != null)
        {
            Console.WriteLine($"El jugador '{nombreJugadorBusqueda}' pertenece al equipo: {equipoEncontrado}.");
        }
        else
        {
            Console.WriteLine($"No se encontró al jugador '{nombreJugadorBusqueda}' en ningún equipo.");
        }
    }
    
    static void MostrarEstadisticas()
    {
        Console.WriteLine("\n--- Estadísticas del Torneo 📊 ---");

        // 1. Total de equipos
        int totalEquipos = torneo.Count;
        Console.WriteLine($"Total de equipos registrados: {totalEquipos}");

        // 2. Total de jugadores
        int totalJugadores = torneo.Values.Sum(jugadores => jugadores.Count);
        Console.WriteLine($"Total de jugadores registrados: {totalJugadores}");

        // 3. Equipo con más jugadores
        if (totalEquipos == 0)
        {
            Console.WriteLine("Equipo con más jugadores: N/A (no hay equipos)");
        }
        else
        {
            var equipoConMasJugadores = torneo.OrderByDescending(e => e.Value.Count).FirstOrDefault();
            Console.WriteLine($"Equipo con más jugadores: {equipoConMasJugadores.Key} ({equipoConMasJugadores.Value.Count} jugadores)");
        }
    }
} 