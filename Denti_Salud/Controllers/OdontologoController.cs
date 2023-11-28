using Datos;
using Denti_Salud.Models;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Denti_Salud.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologoController : ControllerBase
    {
        private OdontologoService odontologoService;
        public OdontologoController(DentisaludContext context)
        {
            this.odontologoService = new OdontologoService(context);
        }
        [HttpPost]
        public ActionResult<OdontologoViewModel> post(OdontologoInputModel odontologoInput)
        {
            var odontologo = this.MapearOdontologo(odontologoInput);
            var response = odontologoService.GuardarOdontologo(odontologo);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar Odontologo", response.Mensaje);
                var problemDetais = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetais);
            }

            var odontologoView = new OdontologoViewModel(odontologo);
            return Ok(odontologoView);
        }

        private Odontologo MapearOdontologo(OdontologoInputModel odontologoInput)
        {
            var odontologo = new Odontologo()
            {
                TipoIdentificacion = odontologoInput.TipoIdentificacion,
                Identificacion = odontologoInput.Identificacion,
                Nombre = odontologoInput.Nombre,
                Apellido = odontologoInput.Apellido,
                FechaNacimiento = odontologoInput.FechaNacimiento,
                Correo = odontologoInput.Correo,
                Genero = odontologoInput.Genero,
                Direccion = odontologoInput.Direccion,
                Salario = odontologoInput.Salario,
                Cargo = odontologoInput.Cargo,
                Telefono = odontologoInput.Telefono,
            };
            return odontologo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OdontologoViewModel>> GetOdontologo()
        {
            var response = odontologoService.ConsultarOdontologos();
            if (!response.Error)
            {
                var odontologosView = response.Odontologos.Select(p => new OdontologoViewModel(p));
                return Ok(odontologosView);
            }
            return BadRequest(response.Mensaje);
        }

    }
}
