using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class OdontogramaService
    {
        private readonly DentisaludContext _context;
        public OdontogramaService(DentisaludContext contex)
        {
            _context = contex;
        }
        public ResponseOdontograma GuardarOdontograma(Odontograma odontograma)
        {
            try
            {
                _context.Odontogramas.Add(odontograma);
                _context.SaveChanges();
                return new ResponseOdontograma(odontograma);
            }
            catch (Exception ex)
            {
                return new ResponseOdontograma("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }

        public ResponseOdontograma ConsultarOdontograma()
        {
            try
            {
                var odontogramas = _context.Odontogramas.ToList();
                return new ResponseOdontograma(odontogramas);
            }
            catch (Exception ex)
            {
                return new ResponseOdontograma("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }
    }
    public class ResponseOdontograma
    {
        public Odontograma Odontograma { get; set; }
        public List<Odontograma> Odontogramas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseOdontograma(Odontograma odontograma)
        {
            Odontograma = odontograma;
            Error = false;
        }

        public ResponseOdontograma(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseOdontograma(List<Odontograma> odontogramas)
        {
            Odontogramas = odontogramas;
            Error = false;
        }

    }
}
