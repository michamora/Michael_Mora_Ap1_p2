using Microsoft.EntityFrameworkCore;
using Parcial2.Models;

#nullable disable // Para quitar el aviso de nulls

namespace Parcial2.DAL
   {
    public class Contexto : DbContext
    {
  
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
        public DbSet<Productos> Productos { get; set; }
        public DbSet<EntradaEmpacados> EntradaEmpacados { get; set; }  
     
    }
}