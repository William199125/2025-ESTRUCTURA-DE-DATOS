using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        AgendaService agenda = new AgendaService();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== Sistema de Agenda de Turnos de Clínica =====");
            Console.WriteLine("1. Agendar un nuevo turno");
            Console.WriteLine("2. Visualizar todos los turnos agendados");
            Console.WriteLine("3. Consultar turnos por Cédula de Paciente");
            Console.WriteLine("4. Consultar turnos por Médico");
            Console.WriteLine("5. Ver reporte de agenda del día (Matriz)");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgendarNuevoTurno(agenda);
                    break;
                case "2":
                    VisualizarTurnos(agenda.GetTodosLosTurnos());
                    break;
                case "3":
                    ConsultarPorPaciente(agenda);
                    break;
                case "4":
                    ConsultarPorMedico(agenda);
                    break;
                case "5":
                    agenda.GenerarReporteMatricialDiario(DateTime.Today);
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("\nGracias por usar el sistema. ¡Adiós!");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static void AgendarNuevoTurno(AgendaService agenda)
    {
        try
        {
            Console.WriteLine("\n--- Agendar Nuevo Turno ---");
            Console.Write("Ingrese la cédula del paciente: ");
            string cedula = Console.ReadLine();

            Console.WriteLine("\nMédicos disponibles:");
            foreach (var medico in agenda.GetMedicos())
            {
                Console.WriteLine($"ID: {medico.IdMedico} - {medico}");
            }
            Console.Write("Ingrese el ID del médico: ");
            int idMedico = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha y hora del turno (formato: dd/MM/yyyy HH:mm): ");
            DateTime fechaHora = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

            agenda.AgendarTurno(cedula, idMedico, fechaHora);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Formato de entrada incorrecto. Revise la fecha o el ID.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
        }
    }

    static void VisualizarTurnos(List<Turno> turnos)
    {
        Console.WriteLine("\n--- Lista de Todos los Turnos ---");
        if (turnos.Count == 0)
        {
            Console.WriteLine("No hay turnos agendados.");
        }
        else
        {
            foreach (var turno in turnos)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(turno);
            }
        }
    }

    static void ConsultarPorPaciente(AgendaService agenda)
    {
        Console.WriteLine("\n--- Consultar por Paciente ---");
        Console.Write("Ingrese la cédula del paciente a consultar: ");
        string cedula = Console.ReadLine();
        var turnos = agenda.ConsultarTurnosPorPaciente(cedula);
        VisualizarTurnos(turnos);
    }

    static void ConsultarPorMedico(AgendaService agenda)
    {
        Console.WriteLine("\n--- Consultar por Médico ---");
        Console.WriteLine("Médicos disponibles:");
         foreach (var medico in agenda.GetMedicos())
            {
                Console.WriteLine($"ID: {medico.IdMedico} - {medico}");
            }
        Console.Write("Ingrese el ID del médico a consultar: ");
        try
        {
            int idMedico = int.Parse(Console.ReadLine());
            var turnos = agenda.ConsultarTurnosPorMedico(idMedico);
            VisualizarTurnos(turnos);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: ID inválido.");
        }
    }
} 