using Datos;
using Denti_Salud.Models;
using Entidades;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Denti_Salud.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private CitaService citaService;
        public CitaController(DentisaludContext context)
        {
            this.citaService = new CitaService(context);
        }
        // GET: api/<ValuesController>
        // [Authorize(Roles = "adm")]
        // [Authorize(Roles = "rcp")]
        // [Authorize(Roles = "odn")]
        // [Authorize(Roles = "pcn")]
        [HttpGet]
        public ActionResult<IEnumerable<CitaViewModel>> GetPagos()
        {
            var response = citaService.ConsultarTodo();
            if (!response.Error)
            {
                var CitaViewModels = response.Citas.Select(c => new CitaViewModel(c));
                return Ok(CitaViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<CitaViewModel> PostPago(CitaInputModel citaInput)
        {

            var cita = MapearCita(citaInput);
            var response = citaService.GuardarCita(cita);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar cita", response.Mensaje);
                var problemDetais = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetais);
            }

            var citaView = new CitaViewModel(cita);
            return Ok(citaView);
        }
        private Cita MapearCita(CitaInputModel citaInput)
        {
            var cita = new Cita()
            {

                IdPaciente = citaInput.IdPaciente,
                IdOdontologo = citaInput.IdOdontologo,
                HoraInicio = citaInput.HoraInicio,
                HoraFin = citaInput.HoraFin,
                Motivo = citaInput.Motivo,
                Observaciones = citaInput.Observaciones,
                
            };
            return cita;
        }
        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
