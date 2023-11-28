using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DienteOdontograma
    {
        [Key]
        public int IdDienteOdontograma { get; set; }
        public int IdOdontograma { get; set; }
        public Odontograma Odontograma { get; set; }
        public int IdDiente { get; set; }
        public Diente Diente { get; set; }
        public string Preferencias { get; set; }
    }
}
