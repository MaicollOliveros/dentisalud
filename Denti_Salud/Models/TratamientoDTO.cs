using Entidades;
using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
    public class TratamientoInputModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; }
    }
    public class TratamientoViewModel
    {
        public int IdTratamiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TratamientoViewModel(Tratamiento tratamiento)
        {
            IdTratamiento = tratamiento.IdTratamiento;
            Nombre = tratamiento.Nombre;
            Descripcion = tratamiento.Descripcion;
        }
    }
}
