using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logical
{
    public class TratamientoService
    {
        private readonly DentisaludContext _context;
        public TratamientoService(DentisaludContext contex)
        {
            _context = contex;
        }

        public ResponseTratamiento GuardarTratamiento(Tratamiento tratamiento)
        {
            try
            {
                var tramientoBuscado = _context.Tratamientos.Find(tratamiento.IdTratamiento);
                if (tramientoBuscado == null)
                {
                    _context.Tratamientos.Add(tratamiento);
                    _context.SaveChanges();
                    return new ResponseTratamiento(tratamiento);
                }
                return new ResponseTratamiento("Error, el tratamiento ya existe");
            }
            catch (Exception ex)
            {
                return new ResponseTratamiento("Se ha presentado la siguiente excepcion: " + ex.Message);
            }

        }
        public ResponseTratamiento ConsultarTratamiento()
        {
            try
            {
                var tratamientos = _context.Tratamientos.ToList();
                return new ResponseTratamiento(tratamientos);
            }
            catch (Exception ex)
            {
                return new ResponseTratamiento("Se ha presentado la siguiente excepcion: " + ex.Message);
            }
        }

    }
    public class ResponseTratamiento
    {
        public Tratamiento Tratemiento { get; set; }
        public List<Tratamiento> Tratamientos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseTratamiento(Tratamiento tratamiento)
        {
            Tratemiento = tratamiento;
            Error = false;
        }

        public ResponseTratamiento(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseTratamiento(List<Tratamiento> tratamientos)
        {
            Tratamientos = tratamientos;
            Error = false;
        }

    }

}
