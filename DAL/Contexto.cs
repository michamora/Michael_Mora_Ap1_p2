using Microsoft.EntityFrameworkCore;
using Parcial2.Models;

namespace Parcial2.DAL
   {
    public class Contexto : DbContext
    {
  
        public Contexto(DbContextOptions<Contexto> options) : base(options){}
        public DbSet<Productos> Productos { get; set; }
        public DbSet<ProductosDetalle> ProductosDetalle { get; set; }
        public DbSet<EntradaEmpacados> EntradaEmpacados { get; set; }
  
        public DbSet<EmpacadosDetalle> EmpacadosDetalle { get; set; }
        
        
   
    }
}