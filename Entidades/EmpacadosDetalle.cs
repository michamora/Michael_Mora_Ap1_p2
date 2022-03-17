using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models;
public class EmpacadosDetalle
{
     [Key]
        public int EmpacadosDetalleId {get; set;}
        public int EmpacadosId {get; set;}
    //  public int ProductoId {get; set;}  Pendiente
        public string Descripcion {get; set;}
        public int Cantidad {get; set; }
        
         public EmpacadosDetalle()
        {
                   
            this.EmpacadosId = 0;

            this.Descripcion = "";

            this.Cantidad = 0;
        }

        public EmpacadosDetalle(int empacadosid, string descripcion, int cantidad)
        {
            EmpacadosId = empacadosid;
            Descripcion = descripcion;
            Cantidad = cantidad;
                 
        }

        
        // [ForeignKey("ProductoId")] Pendiente 
        public virtual EntradaEmpacados? EntradaEmpacados { get; set; }

        //public virtual Productos? producto { get; set; }    Pendiente arreglar para agregar articulo a Utilizados
    }
