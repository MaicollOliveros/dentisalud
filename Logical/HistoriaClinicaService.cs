using Datos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class HistoriaClinicaService
    {
        private readonly DentisaludContext _context;
        public HistoriaClinicaService(DentisaludContext contex)
        {
            _context = contex;
        }

        public ResponseHistoriaClinica GuardarHistoriaClinica(HistoriaClinica historiaClinica)
        {
            try
            {
                var _paciete = _context.Pacientes.Find(historiaClinica.IdPaciente);
                var _odontologo = _context.Odontologos.Find(historiaClinica.IdOdontologo);
                var _odontograma = _context.Odontogramas.Find(historiaClinica.IdOdontograma);
                if (_paciete == null)
                {
                    return new ResponseHistoriaClinica("El paciente no existe ");
                }
                else
                {
                    historiaClinica.Paciente = _paciete;
                }
                if (_odontologo == null)
                {
                    return new ResponseHistoriaClinica("El odontologo no existe ");
                }
                else
                {
                    historiaClinica.Odontologo = _odontologo;
                }
                if (_odontograma == null)
                {
                    return new ResponseHistoriaClinica("El odontograma no existe ");
                }
                else
                {
                    historiaClinica.Odontograma = _odontograma;
                }
                _context.HistoriasClinicas.Add(historiaClinica);
                _context.SaveChanges();
                return new ResponseHistoriaClinica(historiaClinica);
            }
            catch (Exception e)
            {
                return new ResponseHistoriaClinica("Ocurrieron algunos errores:" + e.Message);
            }
        }

        public ResponseHistoriaClinica ConsultarTodo()
        {
            try
            {
                List<HistoriaClinica> HistoriasClinicas = _context.HistoriasClinicas.Include(c => c.Paciente).Include(c => c.Odontologo).ToList();
                return new ResponseHistoriaClinica(HistoriasClinicas);
            }
            catch (Exception e)
            {
                return new ResponseHistoriaClinica("Ocurrieron algunos errores:" + e.Message);
            }
        }

    }
    public class ResponseHistoriaClinica
    {
        public HistoriaClinica HistoriaClinica { get; set; }
        public List<HistoriaClinica> HistoriasClinicas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseHistoriaClinica(HistoriaClinica historiaClinica)
        {
            HistoriaClinica = historiaClinica;
            Error = false;
        }

        public ResponseHistoriaClinica(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseHistoriaClinica(List<HistoriaClinica> historiasClinicas)
        {
            HistoriasClinicas = historiasClinicas;
            Error = false;
        }


    }
}
