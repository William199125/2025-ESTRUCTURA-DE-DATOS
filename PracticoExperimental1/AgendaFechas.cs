using System.Collections.Generic;
using System.Linq;
using System;

// Clase que gestiona la lógica de la agenda
public class AgendaService
{
    // Uso de List<T> como un vector dinámico para almacenar los registros
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Medico> medicos = new List<Medico>();
    private List<Turno> turnos = new List<Turno>();
    private int proximoIdTurno = 1;

    public AgendaService()
    {
        // Precargar datos para demostración
        CargarDatosIniciales();
    }

    private void CargarDatosIniciales()
    {
        // Vectores de Pacientes
        pacientes.Add(new Paciente("050123789", "Kevin", "Zapata", "0987654321"));
        pacientes.Add(new Paciente("1784561292", "Alicia", "Iza", "0991234567"));
        pacientes.Add(new Paciente("0503628620", "William", "Zapata", "0991350317"));
        pacientes.Add(new Paciente("0507894564", "Grabriel", "Estrada", "0984561475"));

        // Vectores de Medicos
        medicos.Add(new Medico(1, "Pablo Salazar", "Medico General"));
        medicos.Add(new Medico(2, "Sofia Zapata", "Pediatría"));
        medicos.Add(new Medico(3, "Diana Paucar", "Ginecologa"));
        medicos.Add(new Medico(4, "Pedro Castro", "Traumatologo")); 
    }

    public void AgendarTurno(string cedulaPaciente, int idMedico, DateTime fechaHora)
    {
        Paciente paciente = pacientes.FirstOrDefault(p => p.Cedula == cedulaPaciente);
        Medico medico = medicos.FirstOrDefault(m => m.IdMedico == idMedico);

        if (paciente == null)
        {
            Console.WriteLine("Error: Paciente no encontrado.");
            return;
        }
        if (medico == null)
        {
            Console.WriteLine("Error: Médico no encontrado.");
            return;
        }

        // Validar que no haya otro turno a la misma hora para el mismo médico
        bool turnoOcupado = turnos.Any(t => t.MedicoAsignado.IdMedico == idMedico && t.FechaHora == fechaHora && t.Estado == "Agendado");
        if(turnoOcupado)
        {
            Console.WriteLine("Error: El médico ya tiene un turno agendado a esa hora.");
            return;
        }

        Turno nuevoTurno = new Turno(proximoIdTurno++, fechaHora, paciente, medico);
        turnos.Add(nuevoTurno);
        Console.WriteLine("\n>> Turno agendado exitosamente. <<");
        Console.WriteLine(nuevoTurno);
    }

    public List<Medico> GetMedicos() => medicos;
    public List<Turno> GetTodosLosTurnos() => turnos;

    public List<Turno> ConsultarTurnosPorPaciente(string cedula)
    {
        return turnos.Where(t => t.PacienteAsignado.Cedula == cedula).ToList();
    }
    
    public List<Turno> ConsultarTurnosPorMedico(int idMedico)
    {
        return turnos.Where(t => t.MedicoAsignado.IdMedico == idMedico).ToList();
    }
    
    // Reportería usando una estructura de datos de Matriz
    public void GenerarReporteMatricialDiario(DateTime dia)
    {
        Console.WriteLine($"\n--- Reporte de Agenda para el día: {dia:dd/MM/yyyy} ---");
        
        // Horas de atención (de 8 AM a 5 PM)
        List<TimeSpan> horarios = new List<TimeSpan>();
        for(int i = 8; i <= 17; i++)
        {
            horarios.Add(new TimeSpan(i, 0, 0));
        }

        // Creamos la matriz: Filas = Horas, Columnas = Medicos
        string[,] matrizAgenda = new string[horarios.Count, medicos.Count];

        // Llenar la matriz con la información de los turnos
        for (int i = 0; i < horarios.Count; i++) // Recorrer filas (horas)
        {
            for (int j = 0; j < medicos.Count; j++) // Recorrer columnas (médicos)
            {
                DateTime fechaBusqueda = dia.Date + horarios[i];
                var medicoActual = medicos[j];

                Turno turnoEncontrado = turnos.FirstOrDefault(t => t.MedicoAsignado.IdMedico == medicoActual.IdMedico &&
                                                                   t.FechaHora == fechaBusqueda &&
                                                                   t.Estado == "Agendado");
                
                if (turnoEncontrado != null)
                {
                    matrizAgenda[i, j] = $"Ocupado (P: {turnoEncontrado.PacienteAsignado.Nombre})";
                }
                else
                {
                    matrizAgenda[i, j] = "Libre";
                }
            }
        }

        // Imprimir la matriz en la consola
        Console.Write("{0,-10}", "Hora");
        foreach(var medico in medicos)
        {
            Console.Write("| {0,-25}", medico.NombreCompleto);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 10 + (28 * medicos.Count)));

        for(int i=0; i< horarios.Count; i++)
        {
            Console.Write("{0,-10}", horarios[i].ToString(@"hh\:mm"));
            for(int j=0; j < medicos.Count; j++)
            {
                Console.Write($"| {matrizAgenda[i, j], -25}");
            }
            Console.WriteLine();
        }
    }
} 