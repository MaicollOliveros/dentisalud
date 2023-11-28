using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
  public class RecepcionistaInputModel
  {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [TipoIdentificacionValidacion(ErrorMessage = "La identificacion debe ser CC, TI o RC")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La identificacion es requerida un número mayor que 0 y menor que 10")]
        [Range(1, 9999999999, ErrorMessage = "La identificación debe ser mayor que 1 y menor que 10")]
        public string Identificacion { get; set; }

        [Range(100000, 999999999999999999, ErrorMessage = "Recuerda, el pago para el empleado debe ser mayor a 100.000COP")]
        public decimal Salario { get; set; }

        [SexoValidacion(ErrorMessage = "El Sexo de ser F o M")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [Range(99999999, 9999999999, ErrorMessage = "Si es celular debe tener 10 digitos, si es telefono, debe tener 8 digitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email no valido.")]
        public string Correo { get; set; }

  }
  public class RecepcionistaViewModel : RecepcionistaInputModel
  {
        public RecepcionistaViewModel(Recepcionista recepcionista)
        {
            TipoIdentificacion = recepcionista.TipoIdentificacion;
            Identificacion = recepcionista.Identificacion;
            Nombre = recepcionista.Nombre;
            Apellido = recepcionista.Apellido;
            FechaNacimiento = recepcionista.FechaNacimiento;
            Correo = recepcionista.Correo;
            Genero = recepcionista.Genero;
            Telefono = recepcionista.Telefono;
            Direccion = recepcionista.Direccion;
            Salario = recepcionista.Salario;
        }

    }
}
