using Entidades;
using System;

namespace Denti_Salud.Models
{
    public class HistoriaInputModel
    {
        public string IdPaciente { get; set; }
        public string IdOdontologo { get; set; }
        public DateTime FechaCita { get; set; }
        public string Observaciones { get; set; }
    }
    public class HistoriaClinicaViewModel 
    {
        public int IdHistoriaClinica { get; set; }
        public string IdPaciente { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public string IdOdontologo { get; set; }
        public OdontologoViewModel Odontologo { get; set; }
        public DateTime FechaCita { get; set; }
        public string Observaciones { get; set; }

        public HistoriaClinicaViewModel(HistoriaClinica historiaClinica)
        {
            IdHistoriaClinica = historiaClinica.IdHistoriaClinica;
            IdPaciente = historiaClinica.IdPaciente;
            Paciente = new PacienteViewModel(historiaClinica.Paciente);
            IdOdontologo = historiaClinica.IdOdontologo;
            Odontologo = new OdontologoViewModel(historiaClinica.Odontologo);
            FechaCita = historiaClinica.FechaCita;
            Observaciones = historiaClinica.Observaciones;
        }
    }
}
