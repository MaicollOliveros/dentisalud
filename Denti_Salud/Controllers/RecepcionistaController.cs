using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Denti_Salud.Hubs;
using Denti_Salud.Models;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Denti_Salud.Controllers
{
  // [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class RecepcionistaController : ControllerBase
  {
    private RecepcionistaService recepcionistaService;
    private readonly IHubContext<SignalHub> _hubContext;
    public RecepcionistaController(DentisaludContext context, IHubContext<SignalHub>hubContext)
    {
      _hubContext = hubContext;
      this.recepcionistaService = new RecepcionistaService(context);
    }
    [HttpPost]
    public async Task <ActionResult<RecepcionistaViewModel>> postRecepcionista(RecepcionistaInputModel recepcionistaInput)
    {
      var recepcionista = this.MapearRecepcionista(recepcionistaInput);
      var response = recepcionistaService.GuardarRecepcionista(recepcionista);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar recepcionista", response.Mensaje);
                var problemDetais = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetais);
            }
            await _hubContext.Clients.All.SendAsync("SignalMessageReceived", recepcionistaInput);
            var recepcionistaView = new RecepcionistaViewModel(recepcionista);
            return Ok(recepcionistaView);
        }

    private Recepcionista MapearRecepcionista(RecepcionistaInputModel recepcionistaInput)
    {
      var recepcionista = new Recepcionista()
      {
        TipoIdentificacion = recepcionistaInput.TipoIdentificacion,
        Identificacion = recepcionistaInput.Identificacion,
        Nombre = recepcionistaInput.Nombre,
        Apellido = recepcionistaInput.Apellido,
        FechaNacimiento = recepcionistaInput.FechaNacimiento,
        Correo = recepcionistaInput.Correo,
        Genero = recepcionistaInput.Genero,
        Direccion = recepcionistaInput.Direccion,
        Salario = recepcionistaInput.Salario,
        Telefono = recepcionistaInput.Telefono,
      };
      return recepcionista;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RecepcionistaViewModel>> GetRecepcionista()
    {
      var response = recepcionistaService.ConsultarRecepcionista();
      if (!response.Error)
      {
        var recepcionistaView = response.Recepcionistas.Select(e => new RecepcionistaViewModel(e));
        return Ok(recepcionistaView);
      }
      return BadRequest(response.Mensaje);
    }


  }
}