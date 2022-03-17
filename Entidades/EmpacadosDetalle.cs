using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models;
public class EmpacadosDetalle
{
     [Key]
        public int EmpacadosDetalleId {get; set;}
        public int EmpacadosId {get; set;}
        public int ProductoId {get; set;}  
        public int Cantidad {get; set; }
        
         public EmpacadosDetalle()
        {
                   
             
        }

        public EmpacadosDetalle(int empacadosdetalleid,  int cantidad)
        {
            EmpacadosDetalleId = empacadosdetalleid;
            
            Cantidad = cantidad;
                 
        }

        
         
        public virtual EntradaEmpacados EntradaEmpacados { get; set; }

        public virtual Productos producto { get; set; }  
    }
