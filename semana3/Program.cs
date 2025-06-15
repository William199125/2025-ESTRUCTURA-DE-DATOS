// Primero definimos un espacio de nombres para organizar nuestras clases.
namespace RegistroEstudiantil
{
    /// <summary>
    /// Clase que representa la plantilla para un objeto de tipo Estudiante.
    /// </summary>
    public class Estudiante
    {
        // Propiedades para almacenar los datos del estudiante.
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }

        // Array para almacenar 3 números de teléfono.
        public string[] Telefonos { get; set; }

        /// <summary>
        /// Constructor: Un método especial que se llama al crear un nuevo objeto Estudiante.
        /// </summary>
        public Estudiante()
        {
            // Inicializamos el array para evitar errores. Le asignamos espacio para 3 elementos.
            Telefonos = new string[3];
            // Inicializamos los strings para evitar que sean nulos.
            Nombres = "";
            Apellidos = "";
            Direccion = "";
        }
    }

    /// <summary>
    /// Clase principal que contiene el punto de entrada de la aplicación.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método Main: aquí comienza la ejecución del programa.
        /// </summary>
        public static void Main(string[] args)
        {
            // 1. Crear un nuevo objeto de tipo Estudiante.
            Estudiante miEstudiante = new Estudiante();

            // 2. Asignar datos a las propiedades del objeto.
            miEstudiante.Id = 10025;
            miEstudiante.Nombres = "William Patricio";
            miEstudiante.Apellidos = "Zapata Iza";
            miEstudiante.Direccion = "Machachi Urbanizacion El Porvenir";

            // 3. Asignar datos al array de teléfonos.
            miEstudiante.Telefonos[0] = "098877665"; // Teléfono 1
            miEstudiante.Telefonos[1] = "022998877";  // Teléfono 2
            miEstudiante.Telefonos[2] = "098521147";  // Teléfono 3 

            // 4. Imprimir los resultados en la consola.
            Console.WriteLine("--- DATOS DEL ESTUDIANTE (REGISTRO DESDE CMD) ---");
            Console.WriteLine($"ID: {miEstudiante.Id}");
            Console.WriteLine($"Estudiante: {miEstudiante.Nombres} {miEstudiante.Apellidos}");
            Console.WriteLine($"Direccion: {miEstudiante.Direccion}");
            Console.WriteLine("Telefonos:");
            Console.WriteLine($"   1: {miEstudiante.Telefonos[0]}");
            Console.WriteLine($"   2: {miEstudiante.Telefonos[1]}");
            Console.WriteLine($"   3: {miEstudiante.Telefonos[2]}");
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
