 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public string IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public string IdOdontologo { get; set; }
        public Odontologo Odontologo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin {  get; set; }
        public string Motivo { get; set; }
        public string Observaciones { get; set; }
        public Cita()
        {
        }

        public Cita(int idCita, string idPaciente, Paciente paciente, string idOdontologo, Odontologo odontologo, DateTime horaInicio, DateTime horaFin, string motivo, string observaciones)
        {
            IdCita = idCita;
            IdPaciente = idPaciente;
            Paciente = paciente;
            IdOdontologo = idOdontologo;
            Odontologo = odontologo;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Motivo = motivo;
            Observaciones = observaciones;
        }
    }
}
