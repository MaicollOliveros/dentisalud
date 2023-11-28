using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Odontograma
    {
        [Key]
        public int IdDontograma { get; set; }
        public List<DienteOdontograma> DienteOdontogramas { get; set; }
    }
}
