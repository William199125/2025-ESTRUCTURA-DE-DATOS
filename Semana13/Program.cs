// Importamos las librerías necesarias.
using System;
using System.Collections.Generic; // Necesario para usar List<T>
using System.Threading; // Para pausas pequeñas y mejorar la experiencia

/*******************************************************
* Catálogo: “LA NUEVA GENERACIÓN”
* Autor: William Zapata (Estudiante de TICs, EUA)
* Editorial: Cosmo
* Objetivo: Gestionar y buscar en un catálogo de revistas.
********************************************************/

/// <summary>
/// Representa una revista con su título y descripción.
/// </summary>
public class Revista
{
    // Propiedades auto-implementadas para el título y la descripción.
    public string Titulo { get; set; }
    public string Descripcion { get; set; }

    /// <summary>
    /// Constructor para crear una nueva instancia de Revista.
    /// </summary>
    /// <param name="titulo">El nombre de la revista.</param>
    /// <param name="descripcion">Una breve descripción de la revista.</param>
    public Revista(string titulo, string descripcion)
    {
        Titulo = titulo;
        Descripcion = descripcion;
    }
}

/// <summary>
/// Gestiona la colección de revistas, incluyendo la inicialización y la búsqueda.
/// </summary>
public class Catalogo
{
    // Usamos una Lista para almacenar las revistas, es flexible y fácil de usar.
    private List<Revista> revistas;

    /// <summary>
    /// Constructor que inicializa la lista y la llena con los datos iniciales.
    /// </summary>
    public Catalogo()
    {
        revistas = new List<Revista>();
        InicializarCatalogo();
    }

    /// <summary>
    /// Método privado para agregar las 12 revistas predefinidas al catálogo.
    /// </summary>
    private void InicializarCatalogo()
    {
        revistas.Add(new Revista("Muy Interesante", "Ciencia y divulgación científica."));
        revistas.Add(new Revista("National Geographic España", "Naturaleza, ciencia y cultura."));
        revistas.Add(new Revista("Hola", "Entretenimiento y celebridades."));
        revistas.Add(new Revista("Semana", "Actualidad y noticias (principalmente en Colombia)."));
        revistas.Add(new Revista("Revista Cambio", "Política y actualidad (México/Latinoamérica)."));
        revistas.Add(new Revista("Quo", "Ciencia, tecnología y curiosidades."));
        revistas.Add(new Revista("Cosas", "Estilo de vida y sociedad (principalmente en Chile)."));
        revistas.Add(new Revista("Cinemanía", "Cine, series y entretenimiento."));
        revistas.Add(new Revista("Elle España", "Moda, belleza y estilo de vida."));
        revistas.Add(new Revista("Rolling Stone (Edición España)", "Música, cultura y entretenimiento."));
        revistas.Add(new Revista("GQ España", "Moda y estilo masculino."));
        revistas.Add(new Revista("Muy Historia", "Historia y divulgación histórica."));
    }

    /// <summary>
    /// Realiza una búsqueda iterativa (lineal) en el catálogo.
    /// La búsqueda no distingue entre mayúsculas y minúsculas para mayor comodidad.
    /// </summary>
    /// <param name="tituloBuscado">El título de la revista a encontrar.</param>
    /// <returns>Verdadero si la revista se encuentra, Falso en caso contrario.</returns>
    public bool BuscarRevistaIterativo(string tituloBuscado)
    {
        // Recorremos cada revista en la lista una por una.
        foreach (var revista in revistas)
        {
            // Comparamos el título de la revista actual con el título buscado.
            // StringComparison.OrdinalIgnoreCase hace que "Hola" y "hola" sean iguales.
            if (revista.Titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true; // ¡Encontrado! Terminamos la búsqueda y devolvemos true.
            }
        }
        return false; // Si terminamos el bucle y no la encontramos, devolvemos false.
    }

    /// <summary>
    /// Muestra en la consola la lista completa de revistas en el catálogo.
    /// Esta es la función adicional solicitada.
    /// </summary>
    public void MostrarTodas()
    {
        Console.Clear();
        Console.WriteLine("📚 --- Catálogo Completo: LA NUEVA GENERACIÓN --- 📚");
        foreach (var revista in revistas)
        {
            Console.WriteLine("\n-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" Título: {revista.Titulo}");
            Console.ResetColor();
            Console.WriteLine($"   └─ Descripción: {revista.Descripcion}");
        }
        Console.WriteLine("\n-------------------------------------------------");
    }
}

/// <summary>
/// Clase principal que contiene el punto de entrada del programa y la lógica del menú.
/// </summary>
public class Program
{
    /// <summary>
    /// Método principal que se ejecuta al iniciar la aplicación.
    /// </summary>
    public static void Main(string[] args)
    {
        // Creamos una instancia de nuestro catálogo.
        Catalogo miCatalogo = new Catalogo();

        // Bucle infinito para que el menú se muestre repetidamente hasta que el usuario decida salir.
        while (true)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Lógica para buscar una revista
                    Console.Clear();
                    Console.WriteLine("======================================");
                    Console.WriteLine("🔎     BUSCAR TÍTULO DE REVISTA     🔎");
                    Console.WriteLine("======================================\n");
                    Console.Write(">> Ingrese el título exacto que desea buscar: ");
                    string titulo = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(titulo))
                    {
                        if (miCatalogo.BuscarRevistaIterativo(titulo))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nResultado: ¡Título Encontrado! 👍");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nResultado: Título No encontrado en el catálogo. 👎");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nAdvertencia: No ingresó ningún título.");
                        Console.ResetColor();
                    }
                    EsperarTecla();
                    break;

                case "2":
                    // Lógica para mostrar todo el catálogo
                    miCatalogo.MostrarTodas();
                    EsperarTecla();
                    break;

                case "3":
                    // Salir del programa
                    Console.WriteLine("\nCerrando el programa... ¡Gracias por usar el catálogo! 👋");
                    Thread.Sleep(1500); // Pequeña pausa antes de cerrar
                    return;

                default:
                    // Opción no válida
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n❌ Opción no válida. Por favor, elija una opción del 1 al 3.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    /// <summary>
    /// Limpia la consola y muestra el menú principal de forma creativa.
    /// </summary>
    public static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    ╔══════════════════════════════════════════════════╗
    ║                                                  ║
    ║         BIENVENIDO AL CATÁLOGO DE REVISTAS         ║
    ║              “LA NUEVA GENERACIÓN”                 ║
    ║                                                  ║
    ╚══════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("\n    Autor: William Zapata (Estudiante de TICs, EUA)");
        Console.WriteLine("    Editorial: Cosmo\n");

        Console.WriteLine("    ------------------- MENÚ PRINCIPAL -------------------");
        Console.WriteLine("       [1] Buscar una revista por título 🔎");
        Console.WriteLine("       [2] Mostrar todo el catálogo 📚");
        Console.WriteLine("       [3] Salir del programa 🚪");
        Console.WriteLine("    ------------------------------------------------------");
        Console.Write("\n    Por favor, elija una opción: ");
    }

    /// <summary>
    /// Muestra un mensaje y espera a que el usuario presione una tecla para continuar.
    /// </summary>
    public static void EsperarTecla()
    {
        Console.WriteLine("\n\nPulse cualquier tecla para volver al menú principal...");
        Console.ReadKey();
    }
} 
