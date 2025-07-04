// Habilita el contexto de nulabilidad para un código más seguro y moderno.
#nullable enable

using System.Globalization;

/// <summary>
/// Representa un vehículo con sus datos principales.
/// Las propiedades de tipo string se inicializan para evitar advertencias de nulabilidad.
/// </summary>
public class Vehiculo
{
    public string Placa { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Año { get; set; }
    public decimal Precio { get; set; }

    public override string ToString()
    {
        // Formatea el precio como moneda local (ej. $15,000.00)
        string precioFormateado = Precio.ToString("C", CultureInfo.CurrentCulture);
        return $"Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}, Año: {Año}, Precio: {precioFormateado}";
    }
}

/// <summary>
/// Representa un nodo (un espacio) en la lista enlazada del estacionamiento.
/// </summary>
public class Nodo
{
    public Vehiculo DatosVehiculo { get; set; }
    // El siguiente nodo puede ser nulo, por eso el '?'
    public Nodo? Siguiente { get; set; }

    public Nodo(Vehiculo vehiculo)
    {
        this.DatosVehiculo = vehiculo;
        this.Siguiente = null;
    }
}

/// <summary>
/// Gestiona la lista enlazada de vehículos del estacionamiento.
/// </summary>
public class EstacionamientoListaEnlazada
{
    // El 'cabeza' es el primer vehículo en la lista. Puede ser nulo si está vacía.
    private Nodo? cabeza;

    /// <summary>
    /// Agrega un nuevo vehículo al inicio de la lista (es la forma más eficiente).
    /// </summary>
    public void AgregarVehiculo(Vehiculo vehiculo)
    {
        Nodo nuevoNodo = new Nodo(vehiculo);
        // El nuevo nodo ahora apunta al que antes era el primero.
        nuevoNodo.Siguiente = this.cabeza;
        // La cabeza de la lista ahora es el nuevo nodo.
        this.cabeza = nuevoNodo;
        Console.WriteLine("✅ Vehículo agregado correctamente al estacionamiento.");
    }

    /// <summary>
    /// Busca un vehículo específico por su número de placa.
    /// </summary>
    /// <returns>El vehículo si se encuentra, de lo contrario devuelve null.</returns>
    public Vehiculo? BuscarPorPlaca(string placa)
    {
        Nodo? actual = this.cabeza;
        while (actual != null)
        {
            // Comparamos las placas ignorando mayúsculas/minúsculas.
            if (actual.DatosVehiculo.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                return actual.DatosVehiculo; // ¡Encontrado!
            }
            actual = actual.Siguiente;
        }
        return null; // No se encontró el vehículo.
    }

    /// <summary>
    /// Muestra todos los vehículos que coinciden con un año específico.
    /// </summary>
    public void VerVehiculosPorAño(int año)
    {
        Nodo? actual = this.cabeza;
        bool encontrados = false;
        Console.WriteLine($"\n--- 🚙 Vehículos del año {año} ---");
        while (actual != null)
        {
            if (actual.DatosVehiculo.Año == año)
            {
                Console.WriteLine(actual.DatosVehiculo);
                encontrados = true;
            }
            actual = actual.Siguiente;
        }

        if (!encontrados)
        {
            Console.WriteLine($"ℹ️ No se encontraron vehículos registrados del año {año}.");
        }
    }

    /// <summary>
    /// Muestra todos los vehículos registrados en el estacionamiento.
    /// </summary>
    public void VerTodosLosVehiculos()
    {
        Nodo? actual = this.cabeza;
        if (actual == null)
        {
            Console.WriteLine("ℹ️ El estacionamiento está vacío.");
            return;
        }

        Console.WriteLine("\n--- 🅿️ Todos los Vehículos en el Estacionamiento ---");
        while (actual != null)
        {
            Console.WriteLine(actual.DatosVehiculo);
            actual = actual.Siguiente;
        }
    }

    /// <summary>
    /// Elimina un vehículo de la lista usando su número de placa.
    /// </summary>
    /// <returns>True si se eliminó, false si no se encontró.</returns>
    public bool EliminarVehiculo(string placa)
    {
        if (this.cabeza == null) return false; // La lista está vacía.

        // Caso especial: el vehículo a eliminar es el primero.
        if (this.cabeza.DatosVehiculo.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
        {
            this.cabeza = this.cabeza.Siguiente;
            return true;
        }

        // Caso general: el vehículo está en medio o al final de la lista.
        Nodo? actual = this.cabeza;
        while (actual.Siguiente != null)
        {
            if (actual.Siguiente.DatosVehiculo.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                // Se encontró. "Saltamos" el nodo a eliminar.
                actual.Siguiente = actual.Siguiente.Siguiente;
                return true;
            }
            actual = actual.Siguiente;
        }

        return false; // No se encontró el vehículo para eliminar.
    }
}

/// <summary>
/// Clase principal que ejecuta el menú de interacción con el usuario.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        EstacionamientoListaEnlazada estacionamiento = new EstacionamientoListaEnlazada();
        string opcion = "";

        Console.WriteLine("--- BIENVENIDO AL SISTEMA DE ESTACIONAMIENTO UEA (ING. TICS) ---");

        do
        {
            Console.WriteLine("\n==================== MENÚ UEA ====================");
            Console.WriteLine("a. Agregar vehículo");
            Console.WriteLine("b. Buscar vehículo por placa");
            Console.WriteLine("c. Ver vehículos por año");
            Console.WriteLine("d. Ver todos los vehículos registrados");
            Console.WriteLine("e. Eliminar carro registrado");
            Console.WriteLine("s. Salir del sistema");
            Console.Write("Por favor, seleccione una opción: ");

            // Leemos la opción del usuario y la convertimos a minúscula.
            // '?? ""' asegura que no sea nulo si el usuario presiona Ctrl+Z.
            opcion = Console.ReadLine()?.ToLower() ?? "";

            switch (opcion)
            {
                case "a":
                    try
                    {
                        Vehiculo nuevoVehiculo = new Vehiculo();
                        Console.Write("Ingrese la Placa: ");
                        nuevoVehiculo.Placa = Console.ReadLine() ?? "";
                        Console.Write("Ingrese la Marca: ");
                        nuevoVehiculo.Marca = Console.ReadLine() ?? "";
                        Console.Write("Ingrese el Modelo: ");
                        nuevoVehiculo.Modelo = Console.ReadLine() ?? "";

                        // Validación para entradas numéricas
                        Console.Write("Ingrese el Año: ");
                        if (!int.TryParse(Console.ReadLine(), out int año))
                        {
                            Console.WriteLine("Año inválido. Por favor ingrese un número.");
                            continue;
                        }
                        nuevoVehiculo.Año = año;

                        Console.Write("Ingrese el Precio: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
                        {
                            Console.WriteLine("Precio inválido. Por favor ingrese un número.");
                            continue;
                        }
                        nuevoVehiculo.Precio = precio;

                        if (string.IsNullOrWhiteSpace(nuevoVehiculo.Placa) || string.IsNullOrWhiteSpace(nuevoVehiculo.Marca))
                        {
                             Console.WriteLine("La placa y la marca son campos obligatorios.");
                             continue;
                        }

                        estacionamiento.AgregarVehiculo(nuevoVehiculo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                    }
                    break;

                case "b":
                    Console.Write("Ingrese la placa del vehículo a buscar: ");
                    string placaBuscar = Console.ReadLine() ?? "";
                    Vehiculo? vehiculoEncontrado = estacionamiento.BuscarPorPlaca(placaBuscar);
                    if (vehiculoEncontrado != null)
                    {
                        Console.WriteLine("Vehículo encontrado:");
                        Console.WriteLine(vehiculoEncontrado);
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado en el estacionamiento.");
                    }
                    break;

                case "c":
                    Console.Write("Ingrese el año de los vehículos que desea ver: ");
                    if (int.TryParse(Console.ReadLine(), out int añoVer))
                    {
                        estacionamiento.VerVehiculosPorAño(añoVer);
                    }
                    else
                    {
                        Console.WriteLine("Año inválido. Debe ingresar un número.");
                    }
                    break;

                case "d":
                    estacionamiento.VerTodosLosVehiculos();
                    break;

                case "e":
                    Console.Write("Ingrese la placa del vehículo a eliminar: ");
                    string placaEliminar = Console.ReadLine() ?? "";
                    if (estacionamiento.EliminarVehiculo(placaEliminar))
                    {
                        Console.WriteLine("Vehículo eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se encontró un vehículo con esa placa para eliminar.");
                    }
                    break;

                case "s":
                    Console.WriteLine("👋 Gracias por usar el sistema. ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }

        } while (opcion != "s");
    }
} 
