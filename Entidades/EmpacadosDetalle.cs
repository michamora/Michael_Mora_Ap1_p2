using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models;
public class EmpacadosDetalle // Detalle de la Entrada de productos empacados
{
        [Key]
        public int EmpacadosDetalleId {get; set;}
        public int EmpacadosId {get; set;}

        


        

        [ForeignKey("ProductoId")] 
        public Productos producto { get; set; } = new Productos();

        public EntradaEmpacados entradaEmpacado { get; set; } = new EntradaEmpacados();
        

        
    }
