using Datos;
using Denti_Salud.Models;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Denti_Salud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private TratamientoService tratamientoService;
        public TratamientoController(DentisaludContext context)
        {
            this.tratamientoService = new TratamientoService(context);
        }
        [HttpPost]
        public ActionResult<TratamientoViewModel> postTratamiento(TratamientoInputModel tratamientoInput)
        {
            var tratamiento = this.MapearTratamiento(tratamientoInput);
            var response = tratamientoService.GuardarTratamiento(tratamiento);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar paciente", response.Mensaje);
                var problemDetais = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetais);
            }

            var tratamientoView = new TratamientoViewModel(tratamiento);
            return Ok(tratamientoView);
        }

        private Tratamiento MapearTratamiento(TratamientoInputModel tratamientoinput)
        {
            var tratamiento = new Tratamiento()
            {
                Nombre = tratamientoinput.Nombre,
                Descripcion = tratamientoinput.Descripcion
            };
            return tratamiento;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TratamientoViewModel>> GetTratamiento()
        {
            var response = tratamientoService.ConsultarTratamiento();
            if (!response.Error)
            {
                var tratamientoView = response.Tratamientos.Select(p => new TratamientoViewModel(p));
                return Ok(tratamientoView);
            }
            return BadRequest(response.Mensaje);
        }
    }
}
