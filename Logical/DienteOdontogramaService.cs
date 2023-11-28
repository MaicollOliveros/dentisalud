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
    public class DienteOdontogramaService
    {
        private readonly DentisaludContext _context;
        public DienteOdontogramaService(DentisaludContext contex)
        {
            _context = contex;
        }

        public ResponseDienteOdontograma GuardarDienteOdontograma(DienteOdontograma diente_odontograma)
        {
            try
            {
                var _odontograma = _context.Odontogramas.Find(diente_odontograma.IdOdontograma);
                var _diente = _context.Dientes.Find(diente_odontograma.IdDiente);

                if (_odontograma == null)
                {
                    return new ResponseDienteOdontograma("El odontograma no existe ");
                }
                else
                {
                    diente_odontograma.Odontograma = _odontograma;
                }
                if (_diente == null)
                {
                    return new ResponseDienteOdontograma("El diente no existe ");
                }
                else
                {
                    diente_odontograma.Diente = _diente;
                }
                _context.DienteOdontogramas.Add(diente_odontograma);
                _context.SaveChanges();
                return new ResponseDienteOdontograma(diente_odontograma);
            }
            catch (Exception e)
            {
                return new ResponseDienteOdontograma("Ocurrieron algunos errores:" + e.Message);
            }
        }

        public ResponseDienteOdontograma ConsultarTodo()
        {
            try
            {
                List<DienteOdontograma> DientesOdontogramas = _context.DienteOdontogramas.Include(c => c.Odontograma).Include(c => c.Diente).ToList();
                return new ResponseDienteOdontograma(DientesOdontogramas);
            }
            catch (Exception e)
            {
                return new ResponseDienteOdontograma("Ocurrieron algunos errores:" + e.Message);
            }
        }

    }
    public class ResponseDienteOdontograma
    {
        public DienteOdontograma DienteOdontograma { get; set; }
        public List<DienteOdontograma> DientesOdontogramas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }

        public ResponseDienteOdontograma(DienteOdontograma dienteodontograma)
        {
            DienteOdontograma = dienteodontograma;
            Error = false;
        }

        public ResponseDienteOdontograma(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ResponseDienteOdontograma(List<DienteOdontograma> dientesodontogramas)
        {
            DientesOdontogramas = dientesodontogramas;
            Error = false;
        }

    }
}
