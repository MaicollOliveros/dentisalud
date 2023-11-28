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
     [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaClinicaController : ControllerBase
    {
        private HistoriaClinicaService historiaService;
        public HistoriaClinicaController(DentisaludContext context)
        {
            this.historiaService = new HistoriaClinicaService(context);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<HistoriaClinicaViewModel>> Get()
        {
            var response = historiaService.ConsultarTodo();
            if (!response.Error)
            {
                var HistoriaClinicaViewModels = response.HistoriasClinicas.Select(h => new HistoriaClinicaViewModel(h));
                return Ok(HistoriaClinicaViewModels);
            }
            return BadRequest(response.Mensaje);
        }

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST api/<ValuesController>
        [HttpPost]
        public ActionResult<HistoriaInputModel> Post(HistoriaInputModel historiaInputModel)
        {

            var historia = MapearHistoriaClinica(historiaInputModel);
            var response = historiaService.GuardarHistoriaClinica(historia);
            if (!response.Error)
            {
                var HistoriaClinicaViewModel = new HistoriaClinicaViewModel(historia);
                return Ok(HistoriaClinicaViewModel);
            }
            return BadRequest(response.Mensaje);
        }
        private HistoriaClinica MapearHistoriaClinica(HistoriaInputModel historiaInput)
        {
            var historia = new HistoriaClinica()
            {

                IdPaciente = historiaInput.IdPaciente,
                IdOdontologo = historiaInput.IdOdontologo,
                FechaCita = historiaInput.FechaCita,
                Observaciones = historiaInput.Observaciones,

            };
            return historia;
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
