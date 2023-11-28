using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class RecepcionistaService
    {
        private readonly DentisaludContext _context;
        public RecepcionistaService(DentisaludContext contex)
        {
            _context = contex;
        }
        public ResponseRecepcionista GuardarRecepcionista(Recepcionista recepcionista)
        {
            try
            {
                var recepcionistaBuscado = _context.Recepcionistas.Find(recepcionista.Identificacion);
                if (recepcionistaBuscado == null)
                {
                    _context.Recepcionistas.Add(recepcionista);
                    _context.SaveChanges();
                    return new ResponseRecepcionista(recepcionista);
                }
                return new ResponseRecepcionista("Error, la identificacion ingresada ya se encuentra registrada");
            }
            catch (Exception ex)
            {
                return new ResponseRecepcionista("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }
        public ResponseRecepcionista ConsultarRecepcionista()
        {
            try
            {
                var recepcionistas = _context.Recepcionistas.ToList();
                return new ResponseRecepcionista(recepcionistas);
            }
            catch (Exception ex)
            {
                return new ResponseRecepcionista("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }
    }

    public class ResponseRecepcionista
    {
        public Recepcionista Recepcionista { get; set; }
        public List<Recepcionista> Recepcionistas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseRecepcionista(Recepcionista recepcionista)
        {
            Recepcionista = recepcionista;
            Error = false;
        }

        public ResponseRecepcionista(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseRecepcionista(List<Recepcionista> recepcionistas)
        {
            Recepcionistas = recepcionistas;
            Error = false;
        }

    }
}
