// Representa la estructura de un Turno, vinculando Paciente y Medico
public class Turno
{
    public int IdTurno { get; set; }
    public DateTime FechaHora { get; set; }
    public Paciente PacienteAsignado { get; set; }
    public Medico MedicoAsignado { get; set; }
    public string Estado { get; set; } // "Agendado", "Cancelado", "Completado"

    public Turno(int idTurno, DateTime fechaHora, Paciente paciente, Medico medico)
    {
        IdTurno = idTurno;
        FechaHora = fechaHora;
        PacienteAsignado = paciente;
        MedicoAsignado = medico;
        Estado = "Agendado";
    }

    public override string ToString()
    {
        return $"ID Turno: {IdTurno} | Fecha: {FechaHora:dd/MM/yyyy HH:mm} | Estado: {Estado}\n" +
               $"  -> {PacienteAsignado}\n" +
               $"  -> {MedicoAsignado}";
    }
}