using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
    public class OdontologoInputModel
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [TipoIdentificacionValidacion(ErrorMessage = "La identificacion debe ser CC, TI o RC")]
        public string TipoIdentificacion { get; set; }

        [Required(ErrorMessage = "La identificacion debe tener entre 8 y 10 digitos")]
        [Range(99999999,9999999999, ErrorMessage = "La identificación debe ser mayor que 1 y menor que 10")]
        public string Identificacion { get; set; }

        [Range(100000, 999999999999999999, ErrorMessage = "Recuerda, el pago para el empleado debe ser mayor a 100.000COP")]
        public decimal Salario { get; set; }

        [SexoValidacion(ErrorMessage = "El Sexo de ser F o M")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [Range(99999999, 9999999999, ErrorMessage ="Si es celular debe tener 10 digitos, si es telefono, debe tener 8 digitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email no valido.")]
        public string Correo { get; set; }
        
        [Required(ErrorMessage = "El cargo es requerido")]
        public string Cargo { get; set; }

    }
    public class OdontologoViewModel:OdontologoInputModel
    {
        public OdontologoViewModel(Odontologo odontologo)
        {
            Nombre = odontologo.Nombre;
            Apellido = odontologo.Apellido;
            FechaNacimiento = odontologo.FechaNacimiento;
            TipoIdentificacion = odontologo.TipoIdentificacion;
            Identificacion = odontologo.Identificacion;
            Salario = odontologo.Salario;
            Genero = odontologo.Genero;
            Telefono = odontologo.Telefono;
            Direccion = odontologo.Direccion;
            Correo = odontologo.Correo;
            Cargo = odontologo.Cargo;
        }
    }
}
