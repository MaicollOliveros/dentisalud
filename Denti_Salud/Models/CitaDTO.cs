using Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Denti_Salud.Models
{
    public class CitaInputModel
    {
        [Required(ErrorMessage = "La identificacion del paciente es requerido")]
        [Range(1, 9999999999, ErrorMessage = "La identificación debe ser mayor que 1 y menor que 10")]
        public string IdPaciente { get; set; }

        [Required(ErrorMessage = "La identificacion del odontologo es requerido")]
        [Range(1, 9999999999, ErrorMessage = "La identificación debe ser mayor que 1 y menor que 10")]
        public string IdOdontologo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime HoraInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime HoraFin { get; set; }

        [MotivoValidacion(ErrorMessage = "Debe elegir un motivo valido (PV,TR,UR,PyP)")]
        public string Motivo { get; set; }

        //Opcionales
        public string Observaciones { get; set; }
    }
    public class CitaViewModel
    {
        public int IdCita { get; set; }
        public string IdPaciente { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public string IdOdontologo { get; set; }
        public OdontologoViewModel Odontologo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }

        public CitaViewModel(Cita cita)
        {
            IdCita = cita.IdCita;
            IdPaciente = cita.IdPaciente;
            Paciente = new PacienteViewModel(cita.Paciente) ;
            IdOdontologo = cita.IdOdontologo;
            Odontologo = new OdontologoViewModel(cita.Odontologo);
            HoraInicio = cita.HoraInicio;
            HoraFin = cita.HoraFin;
            Motivo = cita.Motivo;
            Observaciones = cita.Observaciones;
        }
    }
}
