using Datos;
using Denti_Salud.Models;
using Logical;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Denti_Salud.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OdontogramaController : ControllerBase
    {
        private OdontogramaService odontogramaService;
        public OdontogramaController(DentisaludContext context)
        {
            this.odontogramaService = new OdontogramaService(context);
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<OdontogramaViewModel>> Get()
        {
            var response = odontogramaService.ConsultarOdontograma();
            if (!response.Error)
            {
                var HistoriaClinicaViewModels = response.Odontogramas.Select(h => new OdontogramaViewModel(h));
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

        // POST api/<ValuesController>
        //[HttpPost]
        //public ActionResult<HistoriaInputModel> Post(HistoriaInputModel historiaInputModel)
        //{

        //    var historia = MapearHistoriaClinica(historiaInputModel);
        //    var response = odontogramaService.GuardarHistoriaClinica(historia);
        //    if (!response.Error)
        //    {
        //        var HistoriaClinicaViewModel = new HistoriaClinicaViewModel(historia);
        //        return Ok(HistoriaClinicaViewModel);
        //    }
        //    return BadRequest(response.Mensaje);
        //}
        //private HistoriaClinica MapearHistoriaClinica(HistoriaInputModel historiaInput)
        //{
        //    var historia = new HistoriaClinica()
        //    {

        //        IdPaciente = historiaInput.IdPaciente,
        //        IdOdontologo = historiaInput.IdOdontologo,
        //        FechaCita = historiaInput.FechaCita,
        //        Observaciones = historiaInput.Observaciones,

        //    };
        //    return historia;
        //}
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
