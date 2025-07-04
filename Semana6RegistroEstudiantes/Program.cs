// Habilita el contexto de nulabilidad para que el compilador nos ayude
#nullable enable

using System;

/// <summary>
/// Representa a un estudiante con sus datos personales y su nota.
/// Se inicializan las propiedades para evitar advertencias de nulabilidad.
/// </summary>
public class Estudiante
{
    public string Cedula { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public double NotaDefinitiva { get; set; }

    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre} {Apellido}, Correo: {Correo}, Nota: {NotaDefinitiva}";
    }
}

/// <summary>
/// Representa un nodo dentro de la lista enlazada.
/// </summary>
public class Nodo
{
    public Estudiante Datos { get; set; }
    // CAMBIO: El siguiente nodo puede ser nulo (si es el final de la lista).
    public Nodo? Siguiente { get; set; }

    public Nodo(Estudiante estudiante)
    {
        Datos = estudiante;
        Siguiente = null;
    }
}

/// <summary>
/// Gestiona las operaciones de la lista enlazada de estudiantes.
/// </summary>
public class ListaEnlazada
{
    // CAMBIO: La cabeza y la cola pueden ser nulas si la lista está vacía.
    private Nodo? cabeza;
    private Nodo? cola;

    public ListaEnlazada()
    {
        cabeza = null;
        cola = null;
    }

    /// <summary>
    /// Agrega un nuevo estudiante a la lista.
    /// Aprobados (nota >= 5) al inicio, Reprobados (< 5) al final.
    /// </summary>
    public void AgregarEstudiante(Estudiante estudiante)
    {
        Nodo nuevoNodo = new Nodo(estudiante);
        if (estudiante.NotaDefinitiva >= 5) // Aprobado
        {
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza = nuevoNodo;
            }
        }
        else // Reprobado
        {
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                // La cola no puede ser nula en este punto, usamos el operador '!'
                // para indicarle al compilador que estamos seguros de ello.
                cola!.Siguiente = nuevoNodo;
                cola = nuevoNodo;
            }
        }
        Console.WriteLine("✅ Estudiante agregado exitosamente.");
    }

    /// <summary>
    /// Busca un estudiante por su cédula.
    /// CAMBIO: Puede devolver nulo si no se encuentra el estudiante.
    /// </summary>
    /// <returns>El Estudiante o null.</returns>
    public Estudiante? BuscarEstudiante(string cedula)
    {
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.Cedula == cedula)
            {
                return actual.Datos;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

    /// <summary>
    /// Elimina un estudiante de la lista usando su cédula.
    /// </summary>
    public bool EliminarEstudiante(string cedula)
    {
        if (cabeza == null) return false;

        if (cabeza.Datos.Cedula == cedula)
        {
            cabeza = cabeza.Siguiente;
            if (cabeza == null)
            {
                cola = null;
            }
            return true;
        }

        Nodo? actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Datos.Cedula != cedula)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            // Si el nodo a eliminar es la cola, actualizamos la referencia de la cola.
            if (actual.Siguiente == cola)
            {
                cola = actual;
            }
            actual.Siguiente = actual.Siguiente.Siguiente;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Calcula el total de estudiantes aprobados.
    /// </summary>
    public int TotalEstudiantesAprobados()
    {
        int count = 0;
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.NotaDefinitiva >= 5)
            {
                count++;
            }
            actual = actual.Siguiente;
        }
        return count;
    }

    /// <summary>
    /// Calcula el total de estudiantes reprobados.
    /// </summary>
    public int TotalEstudiantesReprobados()
    {
        int count = 0;
        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Datos.NotaDefinitiva < 5)
            {
                count++;
            }
            actual = actual.Siguiente;
        }
        return count;
    }

    /// <summary>
    /// Muestra todos los estudiantes registrados.
    /// </summary>
    public void MostrarEstudiantes()
    {
        Nodo? actual = cabeza;
        if (actual == null)
        {
            Console.WriteLine("ℹ️ No hay estudiantes registrados.");
            return;
        }
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        while (actual != null)
        {
            Console.WriteLine(actual.Datos);
            actual = actual.Siguiente;
        }
        Console.WriteLine("--------------------------");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ListaEnlazada listaRedes = new ListaEnlazada();
        string opcion = "";

        do
        {
            Console.WriteLine("\n---  Registro de Estudiantes Estructura de Datos C  ---");
            Console.WriteLine("a. Agregar estudiante");
            Console.WriteLine("b. Buscar estudiante por cédula");
            Console.WriteLine("c. Eliminar un estudiante");
            Console.WriteLine("d. Total estudiantes aprobados");
            Console.WriteLine("e. Total estudiantes reprobados");
            Console.WriteLine("f. Mostrar todos los estudiantes");
            Console.WriteLine("s. Salir");
            Console.Write("Seleccione una opción: ");
            
            // CAMBIO: Console.ReadLine() puede devolver null. Usamos '?? ""' para
            // asegurar que 'opcion' nunca sea nulo y evitar advertencias.
            opcion = Console.ReadLine()?.ToLower() ?? "";

            switch (opcion)
            {
                case "a":
                    try
                    {
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine() ?? "";
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine() ?? "";
                        Console.Write("Apellido: ");
                        string apellido = Console.ReadLine() ?? "";
                        Console.Write("Correo: ");
                        string correo = Console.ReadLine() ?? "";
                        
                        // Validamos que la entrada no esté vacía antes de agregar
                        if (string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(nombre))
                        {
                            Console.WriteLine("La cédula y el nombre no pueden estar vacíos.");
                            continue;
                        }

                        Console.Write("Nota Definitiva (Escala 1-10): ");
                        double nota = Convert.ToDouble(Console.ReadLine());
                        
                        if (nota < 1 || nota > 10)
                        {
                            Console.WriteLine("Nota inválida. Debe estar en la escala de 1 a 10.");
                            continue;
                        }
                        listaRedes.AgregarEstudiante(new Estudiante { Cedula = cedula, Nombre = nombre, Apellido = apellido, Correo = correo, NotaDefinitiva = nota });
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: El formato de la nota no es válido. Intente de nuevo.");
                    }
                    break;
                case "b":
                    Console.Write("Ingrese la cédula a buscar: ");
                    string cedulaBuscar = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(cedulaBuscar))
                    {
                        Estudiante? estBuscado = listaRedes.BuscarEstudiante(cedulaBuscar);
                        if (estBuscado != null)
                        {
                            Console.WriteLine("Estudiante encontrado: " + estBuscado);
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("La cédula no puede estar vacía.");
                    }
                    break;
                case "c":
                    Console.Write("Ingrese la cédula a eliminar: ");
                    string cedulaEliminar = Console.ReadLine() ?? "";
                     if (!string.IsNullOrEmpty(cedulaEliminar))
                    {
                        if (listaRedes.EliminarEstudiante(cedulaEliminar))
                        {
                            Console.WriteLine("Estudiante eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo encontrar y eliminar al estudiante.");
                        }
                    }
                     else
                    {
                        Console.WriteLine("La cédula no puede estar vacía.");
                    }
                    break;
                case "d":
                    Console.WriteLine($"Total de estudiantes aprobados: {listaRedes.TotalEstudiantesAprobados()}");
                    break;
                case "e":
                    Console.WriteLine($"Total de estudiantes reprobados: {listaRedes.TotalEstudiantesReprobados()}");
                    break;
                case "f":
                    listaRedes.MostrarEstudiantes();
                    break;
                case "s":
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != "s");
    }
}  