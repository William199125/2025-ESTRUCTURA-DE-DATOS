// Representa un registro de Paciente
public class Paciente
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }

    public Paciente(string cedula, string nombre, string apellido, string telefono)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
    }

    public override string ToString()
    {
        return $"Paciente: {Nombre} {Apellido} (Cédula: {Cedula})";
    }
}