using System;
using System.Collections.Generic;
using System.Threading;

public class Persona
{
    public string NombreCompleto { get; private set; }
    public DateTime HoraLlegada { get; private set; }

    public Persona(string nombreCompleto)
    {
        NombreCompleto = nombreCompleto;
        HoraLlegada = DateTime.Now;
    }

    public override string ToString()
    {
        return $"[Nombre: {NombreCompleto}, Llegada: {HoraLlegada:dd/MM/yyyy HH:mm:ss}]";
    }
}

public class Atraccion
{
    private Queue<Persona> filaDeEspera;
    private const int CapacidadMaxima = 30;

    public int AsientosDisponibles => CapacidadMaxima - filaDeEspera.Count;
    public int PersonasEnCola => filaDeEspera.Count;

    public Atraccion()
    {
        filaDeEspera = new Queue<Persona>();
    }

    public void FormarPersona(string nombreCompleto)
    {
        if (AsientosDisponibles > 0)
        {
            var persona = new Persona(nombreCompleto);
            filaDeEspera.Enqueue(persona);
            Console.WriteLine($"✅ ¡{persona.NombreCompleto} se ha formado en la cola!");
        }
        else
        {
            Console.WriteLine($"❌ LO SENTIMOS: La atracción está llena ({CapacidadMaxima} personas).");
        }
    }

    public void IniciarCicloAtraccion()
    {
        Console.WriteLine("\n🚀 ¡Iniciando ciclo de la atracción!");
        Console.WriteLine("-------------------------------------------------");

        if (filaDeEspera.Count == 0)
        {
            Console.WriteLine("ℹ️ La cola está vacía. No se puede iniciar el ciclo.");
            return;
        }

        Console.WriteLine("Asignando asientos y calculando tiempo de espera...");

        while (filaDeEspera.Count > 0)
        {
            Persona pasajero = filaDeEspera.Dequeue();

            TimeSpan tiempoDeEspera = DateTime.Now - pasajero.HoraLlegada;

            Console.WriteLine($"   -> Asiento para {pasajero.NombreCompleto}. " +
                              $"Tiempo de espera: {tiempoDeEspera.Hours} h, {tiempoDeEspera.Minutes} min, {tiempoDeEspera.Seconds} seg.");

            Thread.Sleep(150);
        }

        Console.WriteLine("\n🎉 ¡Todos a bordo! La atracción ha comenzado.");
        Thread.Sleep(2500);
        Console.WriteLine("🏁 ¡El ciclo ha terminado! Los pasajeros han desembarcado.");
        Console.WriteLine("-------------------------------------------------\n");
    }

    public void ConsultarEstadoDeLaCola()
    {
        Console.WriteLine("\n--- 🔎 Reporte de la Cola de Espera ---");
        Console.WriteLine($"Asientos Disponibles: {AsientosDisponibles}");
        Console.WriteLine($"Personas en Cola: {PersonasEnCola}");

        if (PersonasEnCola == 0)
        {
            Console.WriteLine("La cola está actualmente vacía.");
        }
        else
        {
            Console.WriteLine("\nPersonas en orden de llegada:");
            int posicion = 1;
            foreach (var persona in filaDeEspera)
            {
                Console.WriteLine($"   {posicion++}. {persona}");
            }
        }
        Console.WriteLine("------------------------------------\n");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Atraccion miAtraccion = new Atraccion();
        bool salir = false;

        Console.WriteLine("🎡 ¡Bienvenido al Sistema de Gestión de 'El Desafío Amazónico'!");

        while (!salir)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine($"Estado: {miAtraccion.PersonasEnCola} personas en cola | {miAtraccion.AsientosDisponibles} asientos disponibles.");
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("  1. Formar nueva persona en la cola");
            Console.WriteLine("  2. Iniciar ciclo de la atracción");
            Console.WriteLine("  3. Ver estado detallado de la cola");
            Console.WriteLine("  4. Salir");
            Console.Write("Opción: ");

            string? opcion = Console.ReadLine();
            Console.Clear();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre y apellido de la persona: ");
                    string? nombre = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(nombre))
                    {
                        nombre = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombre.Trim().ToLower());
                        miAtraccion.FormarPersona(nombre);
                    }
                    else
                    {
                        Console.WriteLine("❌ Nombre no válido.");
                    }
                    break;

                case "2":
                    miAtraccion.IniciarCicloAtraccion();
                    break;

                case "3":
                    miAtraccion.ConsultarEstadoDeLaCola();
                    break;

                case "4":
                    salir = true;
                    Console.WriteLine("👋 Gracias por usar el sistema. ¡Hasta pronto!");
                    break;

                default:
                    Console.WriteLine("❌ Opción no válida. Por favor, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
} 
 