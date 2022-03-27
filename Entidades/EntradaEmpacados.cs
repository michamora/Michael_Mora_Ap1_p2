using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
      public class EntradaEmpacados // Entrada de productos empacados
    {
        [Key]
        public int EmpacadosId {get; set;}

        
        public DateTime Fecha {get; set;} = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar el concepto.")]
        public string? Concepto { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Campo obligatorio. Ingrese la cantidad utilizada del producto")]
        public float CantidadUtilizada {get; set;} // Cantidad Utilizada

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Campo obligatorio. Ingrese la cantidad a producir del producto")]
        public float CantidadProducida {get; set;} // Cantidad que se va a producir

        public float PesoTotal { get; set; }

          

        [ForeignKey("EmpacadosId")]

        public virtual List<EmpacadosDetalle> EmpacadosDetalle { get; set; } = new List<EmpacadosDetalle>();

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Seleccione un producto")]
        public int ProductoId {get; set;} 
        

    }
}