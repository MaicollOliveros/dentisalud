using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class Recepcionista : Persona
  {
    [Column(TypeName = "decimal(18,4)")]
    public decimal Salario { get; set; }

  }
}
