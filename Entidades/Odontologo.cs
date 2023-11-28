using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Odontologo: Persona
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal Salario { get; set; }
        public string Cargo { get; set; }
        public List<HistoriaClinica> HistoriasClinicas { get; set; }
        public List<Cita> Citas { get; set; }
    }
}
