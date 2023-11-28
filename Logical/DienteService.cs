using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class DienteService
    {
        private readonly DentisaludContext _context;
        public DienteService(DentisaludContext contex)
        {
            _context = contex;
        }
        public ResponseDiente GuardarDiente(Diente diente)
        {
            try
            {
                _context.Dientes.Add(diente);
                _context.SaveChanges();
                return new ResponseDiente(diente);
            }
            catch (Exception ex)
            {
                return new ResponseDiente("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }

        public ResponseDiente ConsultarDientes()
        {
            try
            {
                var dientes = _context.Dientes.ToList();
                return new ResponseDiente(dientes);
            }
            catch (Exception ex)
            {
                return new ResponseDiente("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }
    }
    public class ResponseDiente
    {
        public Diente Diente { get; set; }
        public List<Diente> Dientes { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseDiente(Diente diente)
        {
            Diente = diente;
            Error = false;
        }

        public ResponseDiente(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseDiente(List<Diente> dientes)
        {
            Dientes = dientes;
            Error = false;
        }

    }
}
