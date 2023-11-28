using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Diente
    {
        [Key]
        public int IdDiente { get; set; }
        public string Name { get; set; }
    }
}
