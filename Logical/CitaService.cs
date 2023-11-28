using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Logical
{
    public class CitaService
    {
        private readonly DentisaludContext _context;
        public CitaService(DentisaludContext contex)
        {
            _context = contex;
        }

        public ResponseCita GuardarCita(Cita cita)
        {
            try
            {
                var _paciete = _context.Pacientes.Find(cita.IdPaciente);
                var _odontologo = _context.Odontologos.Find(cita.IdOdontologo);
                var diferenciaFechas = cita.HoraFin - cita.HoraInicio;
                var diasTranscurridos = diferenciaFechas.Days;

                if (_paciete == null)
                {
                    return new ResponseCita("El paciente no existe ");
                }
                else
                {
                    cita.Paciente = _paciete;
                }
                if (_odontologo == null)
                {
                    return new ResponseCita("El odontologo no existe ");
                }
                else
                {
                    cita.Odontologo = _odontologo;
                }

                if(diasTranscurridos<=0)
                    return new ResponseCita("No es posible crear una fecha con ese limite de tiempo");

                _context.Citas.Add(cita);
                _context.SaveChanges();
                return new ResponseCita(cita);
            }
            catch (Exception e)
            {
                return new ResponseCita("Ocurrieron algunos errores:" + e.Message);
            }
        }

        public ResponseCita ConsultarTodo()
        {
            try
            {
                List<Cita> Citas = _context.Citas.Include(c => c.Paciente).Include(c=> c.Odontologo).ToList();
                return new ResponseCita(Citas);
            }
            catch (Exception e )
            {
                return new ResponseCita("Ocurrieron algunos errores:" + e.Message);
            }
        }

    }
}
public class ResponseCita{
    public Cita Cita { get; set; }
    public List<Cita> Citas { get; set; }
    public string Mensaje { get; set; }
    public bool Error { get; set; }

    public ResponseCita(Cita cita)
    {
        Cita = cita;
        Error = false;
    }

    public ResponseCita(string mensaje)
    {
        Mensaje = mensaje;
        Error = true;
    }
    public ResponseCita(List<Cita> citas)
    {
        Citas = citas;
        Error = false;
    }

}
