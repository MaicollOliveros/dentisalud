using Entidades;
using System.Collections.Generic;

namespace Denti_Salud.Models
{
    public class OdontogramaViewModel
    {
        public int IdDontograma { get; set; }

        public OdontogramaViewModel(Odontograma o)
        {
            IdDontograma = o.IdDontograma;         
        }
    }


}
