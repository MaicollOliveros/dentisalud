using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistoriaClinica
    {
        [Key]
        public int IdHistoriaClinica { get; set; }
        public string IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdOdontograma { get; set; }
        public Odontograma Odontograma { get; set; }
        public string IdOdontologo { get; set; }
        public Odontologo Odontologo { get; set; }
        public DateTime FechaCita { get; set; }
        public string Observaciones { get; set; }
        List<Tratamiento> Tratamientos { get; set; }   

        public HistoriaClinica()
        {

        }

        public HistoriaClinica(int idHistoriaClinica, string idPaciente, Paciente paciente, Odontograma odontograma, string idOdontologo, Odontologo odontologo, DateTime fechaCita, string observaciones, List<Tratamiento> tratamientos)
        {
            IdHistoriaClinica = idHistoriaClinica;
            IdPaciente = idPaciente;
            Paciente = paciente;
            Odontograma = odontograma;
            IdOdontologo = idOdontologo;
            Odontologo = odontologo;
            FechaCita = fechaCita;
            Observaciones = observaciones;
            Tratamientos = tratamientos;
        }
    }
}
