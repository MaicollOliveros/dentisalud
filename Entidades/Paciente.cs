using System;
using System.Collections.Generic;

namespace Entidades
{
  public class Paciente : Persona
  {
        public List<Cita> Citas { get; set; }
        public List<HistoriaClinica> HistoriasClinicas { get; set; }
    }
}
