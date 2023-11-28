using System;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
  public class DentisaludContext : DbContext
  {
    public DentisaludContext(DbContextOptions options) : base(options)
    { 
    }
     public DbSet<User> Users { get; set; }
     public DbSet<Paciente> Pacientes { get; set; }
     public DbSet<Recepcionista> Recepcionistas { get; set; }
     public DbSet<Odontologo> Odontologos { get; set; }
     public DbSet<Cita> Citas { get; set; }
     public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }    
     public DbSet<Tratamiento> Tratamientos { get; set; }
     public DbSet<Odontograma> Odontogramas { get; set; }
     public DbSet<Diente> Dientes { get; set; }
     public DbSet<DienteOdontograma> DienteOdontogramas { get; set; }
    }
}
