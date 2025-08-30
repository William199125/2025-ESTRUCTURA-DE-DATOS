using System;
using System.Collections.Generic;
using System.Text;

// Espacio de nombres para organizar el código del proyecto.
namespace TraductorBasico
{
    // Clase principal que contiene la lógica del programa.
    class Program
    {
        // Declaramos el diccionario de forma estática para que sea accesible desde todos los métodos de la clase.
        // Usamos StringComparer.OrdinalIgnoreCase para que las búsquedas no distingan entre mayúsculas y minúsculas.
        static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        // Método principal que se ejecuta al iniciar la aplicación.
        static void Main(string[] args)
        {
            // Cargamos las palabras iniciales en el diccionario.
            InicializarDiccionario();

            // Variable para almacenar la opción del usuario.
            string opcion;

            // Bucle do-while para mostrar el menú hasta que el usuario elija salir (opción "0").
            do
            {
                // Limpiamos la consola para una presentación más limpia del menú.
                Console.Clear();
                Console.WriteLine("==================== MENÚ ====================");
                Console.WriteLine("     Traductor Básico Español <> Inglés     ");
                Console.WriteLine(" Por: William Zapata - 3er Semestre TICs UEA  ");
                Console.WriteLine("============================================");
                Console.WriteLine(" 1. Traducir una frase");
                Console.WriteLine(" 2. Agregar palabras al diccionario");
                Console.WriteLine(" 0. Salir");
                Console.WriteLine("============================================");
                Console.Write(" Seleccione una opción: ");
                
                opcion = Console.ReadLine();

                // Estructura switch para manejar la opción seleccionada por el usuario.
                switch (opcion)
                {
                    case "1":
                        TraducirFrase();
                        break;
                    case "2":
                        AgregarPalabra();
                        break;
                    case "0":
                        Console.WriteLine("\n¡Gracias por usar el traductor! Adiós. 👋");
                        break;
                    default:
                        Console.WriteLine("\n¡Opción no válida! Por favor, elige una opción del menú.");
                        break;
                }

                // Pausa para que el usuario pueda leer el resultado antes de volver al menú.
                if (opcion != "0")
                {
                    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != "0");
        }

        /// <summary>
        /// Carga el diccionario con una lista inicial de palabras en español y su traducción al inglés.
        /// </summary>
        static void InicializarDiccionario()
        {
            diccionario["tiempo"] = "time";
            diccionario["persona"] = "person";
            diccionario["año"] = "year";
            diccionario["camino"] = "way";
            diccionario["día"] = "day";
            diccionario["cosa"] = "thing";
            diccionario["hombre"] = "man";
            diccionario["mundo"] = "world";
            diccionario["vida"] = "life";
            diccionario["mano"] = "hand";
            diccionario["parte"] = "part";
            diccionario["niño"] = "child";
            diccionario["ojo"] = "eye";
            diccionario["mujer"] = "woman";
            diccionario["lugar"] = "place";
            diccionario["trabajo"] = "work";
            diccionario["semana"] = "week";
            diccionario["caso"] = "case";
            diccionario["punto"] = "point";
            diccionario["gobierno"] = "government";
            diccionario["empresa"] = "company";
        }

        /// <summary>
        /// Solicita al usuario una frase y la traduce palabra por palabra si se encuentra en el diccionario.
        /// </summary>
        static void TraducirFrase()
        {
            Console.Clear();
            Console.WriteLine("--- TRADUCIR FRASE ---");
            Console.Write("Ingresa la frase en español: ");
            string fraseOriginal = Console.ReadLine();

            // Si la frase está vacía o solo contiene espacios, no hacemos nada.
            if (string.IsNullOrWhiteSpace(fraseOriginal))
            {
                Console.WriteLine("No se ingresó ninguna frase.");
                return;
            }

            // Definimos los separadores para dividir la frase en palabras (espacios y signos de puntuación).
            char[] separadores = { ' ', ',', '.', ';', ':', '!', '?' };
            string[] palabras = fraseOriginal.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

            // Usamos StringBuilder para construir eficientemente la frase traducida.
            StringBuilder fraseTraducida = new StringBuilder();

            foreach (var palabra in palabras)
            {
                // Buscamos la palabra en el diccionario (ignorando mayúsculas/minúsculas).
                if (diccionario.TryGetValue(palabra, out string traduccion))
                {
                    // Si la encuentra, agrega la traducción.
                    fraseTraducida.Append(traduccion);
                }
                else
                {
                    // Si no, agrega la palabra original.
                    fraseTraducida.Append(palabra);
                }
                // Agrega un espacio después de cada palabra.
                fraseTraducida.Append(" ");
            }

            Console.WriteLine("\nTraducción esperada (parcial):");
            // Usamos .Trim() para eliminar el último espacio sobrante.
            Console.WriteLine(fraseTraducida.ToString().Trim());
        }

        /// <summary>
        /// Permite al usuario agregar un nuevo par de palabras (español-inglés) al diccionario.
        /// </summary>
        static void AgregarPalabra()
        {
            Console.Clear();
            Console.WriteLine("--- AGREGAR PALABRA AL DICCIONARIO ---");
            
            Console.Write("Ingresa la palabra en español: ");
            string palabraEspanol = Console.ReadLine().Trim().ToLower();

            // Verificamos que la palabra no esté vacía.
            if (string.IsNullOrEmpty(palabraEspanol))
            {
                Console.WriteLine("La palabra no puede estar vacía.");
                return;
            }

            // Comprobamos si la palabra ya existe.
            if (diccionario.ContainsKey(palabraEspanol))
            {
                Console.WriteLine($"La palabra '{palabraEspanol}' ya existe. Su traducción es '{diccionario[palabraEspanol]}'.");
                return;
            }
            
            Console.Write($"Ingresa la traducción de '{palabraEspanol}' al inglés: ");
            string palabraIngles = Console.ReadLine().Trim().ToLower();

            if (string.IsNullOrEmpty(palabraIngles))
            {
                Console.WriteLine("La traducción no puede estar vacía.");
                return;
            }

            // Agregamos la nueva palabra al diccionario.
            diccionario[palabraEspanol] = palabraIngles;
            Console.WriteLine("\n¡Palabra agregada con éxito! ✅");
        }
    }
} 
