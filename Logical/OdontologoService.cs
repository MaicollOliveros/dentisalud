using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class OdontologoService
    {
        private readonly DentisaludContext _context;
        public OdontologoService(DentisaludContext contex)
        {
            _context = contex;
        }

        public ResponseOdontologo GuardarOdontologo(Odontologo odontologo)
        {
            try
            {
                var odontologoBuscado = _context.Pacientes.Find(odontologo.Identificacion);
                if (odontologoBuscado == null)
                {
                    _context.Odontologos.Add(odontologo);
                    _context.SaveChanges();
                    return new ResponseOdontologo(odontologo);
                }
                return new ResponseOdontologo("Error, la identificacion ingresada ya se encuentra registrada");
            }
            catch (System.Exception ex)
            {
                return new ResponseOdontologo("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }
        public ResponseOdontologo ConsultarOdontologos()
        {
            try
            {
                var odontologos = _context.Odontologos.ToList();
                return new ResponseOdontologo(odontologos);
            }
            catch (System.Exception ex)
            {
                return new ResponseOdontologo("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }


    }

    public class ResponseOdontologo
    {
        public Odontologo Odontologo { get; set; }
        public List<Odontologo> Odontologos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseOdontologo(Odontologo odontologo)
        {
            Odontologo = odontologo;
            Error = false;
        }

        public ResponseOdontologo(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseOdontologo(List<Odontologo> odontologos)
        {
            Odontologos = odontologos;
            Error = false;
        }

    }
}
