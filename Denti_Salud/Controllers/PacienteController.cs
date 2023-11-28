using System.Collections.Generic;
using System.Linq;
using Datos;
using Denti_Salud.Models;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Denti_Salud.Controllers
{
  //[Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class PacienteController : ControllerBase
  {
    private PacienteService pacienteService;
    public PacienteController(DentisaludContext context)
    {
      this.pacienteService = new PacienteService(context);
    }

        
        [HttpPost]
    public ActionResult<PacienteViewModel> postPaciente(PacienteInputModel pacienteInput)
    {
      var paciente = this.MapearPaciente(pacienteInput);
      var response = pacienteService.GuardarPaciente(paciente);
      if (response.Error)
      {
        ModelState.AddModelError("Guardar paciente", response.Mensaje);
        var problemDetais = new ValidationProblemDetails(ModelState)
        {
            Status = StatusCodes.Status400BadRequest,
        };
        return BadRequest(problemDetais);
      }
      
      var pacienteView = new PacienteViewModel(paciente);
      return Ok(pacienteView);
    }

    private Paciente MapearPaciente(PacienteInputModel pacienteInput)
    {
      var paciente = new Paciente()
      {
        Identificacion = pacienteInput.Identificacion,
        Nombre = pacienteInput.Nombre,
        Apellido = pacienteInput.Apellido,
        FechaNacimiento = pacienteInput.FechaNacimiento,
        TipoIdentificacion = pacienteInput.TipoIdentificacion,
        Correo = pacienteInput.Correo,
        Telefono = pacienteInput.Telefono,
        Genero = pacienteInput.Genero,
        Direccion = pacienteInput.Direccion,
      };
      return paciente;
    }
        [HttpGet]
    public ActionResult<IEnumerable<PacienteViewModel>> GetPacientes()
    {
      var response = pacienteService.ConsultarPacientes();
      if (!response.Error)
      {
        var pacientesView = response.Pacientes.Select(p => new PacienteViewModel(p));
        return Ok(pacientesView);
      }
      return BadRequest(response.Mensaje);
    }

  }
}