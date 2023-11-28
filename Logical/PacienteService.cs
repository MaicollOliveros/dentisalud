using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidades;

namespace Logical
{
  public class PacienteService
  {
    private readonly DentisaludContext _context;
    public PacienteService(DentisaludContext contex)
    {
      _context = contex;
    }

    public ResponsePaciente GuardarPaciente(Paciente paciente)
    {
      try
      {
        var pacienteBuscado = _context.Pacientes.Find(paciente.Identificacion);
        if (pacienteBuscado != null)
        {
            return new ResponsePaciente("Error, la identificacion ingresada ya se encuentra registrada");
        }
        _context.Pacientes.Add(paciente);
        _context.SaveChanges();
        return new ResponsePaciente(paciente);
      }
      catch (System.Exception ex)
      {
        return new ResponsePaciente("Se ha presentado la siguiente excepcion: " + ex.Message);
      }

    }
    public ResponsePaciente ConsultarPacientes()
    {
      try
      {
        var pacientes = _context.Pacientes.ToList();
        return new ResponsePaciente(pacientes);
      }
      catch (System.Exception ex)
      {
        return new ResponsePaciente("Se ha presentado la siguiente excepcion: " + ex.Message);
      }
    }

  }
  public class ResponsePaciente
  {
    public Paciente Paciente { get; set; }
    public List<Paciente> Pacientes { get; set; }
    public string Mensaje { get; set; }
    public bool Error { get; set; }

    public ResponsePaciente(Paciente paciente)
    {
      Paciente = paciente;
      Error = false;
    }

    public ResponsePaciente(string mensaje)
    {
      Mensaje = mensaje;
      Error = true;
    }
    public ResponsePaciente(List<Paciente> pacientes)
    {
      Pacientes = pacientes;
      Error = false;
    }

  }

}