// Representa un registro de Medico
public class Medico
{
    public int IdMedico { get; set; }
    public string NombreCompleto { get; set; }
    public string Especialidad { get; set; }

    public Medico(int idMedico, string nombreCompleto, string especialidad)
    {
        IdMedico = idMedico;
        NombreCompleto = nombreCompleto;
        Especialidad = especialidad;
    }

    public override string ToString()
    {
        return $"Dr(a). {NombreCompleto} - Especialidad: {Especialidad}";
    }
} 