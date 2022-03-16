using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
public class EntradaEmpacados
{
        [Key]
        public int EmpacadosId {get; set;}
        public int EmpacadosDetalleId {get; set;}
        
      

        [Required(ErrorMessage = "Campo obligatorio. colocar fecha actual.")]
        public DateTime Fecha {get; set;} = DateTime.Now;

        [Required(ErrorMessage = "Campo obligatorio. Se debe indicar concepto. ")]
        [MinLength(3, ErrorMessage = "El concepto debe tener almenos {1} caracteres.")]
        [MaxLength(35, ErrorMessage = "El concepto no debe pasar de {1} caracteres. ")]
        public string? Concepto { get; set; }

        public int CantidadUtilizada {get; set;}

        public int CantidadProducida {get; set;}

   

        [ForeignKey("EmpacadosId")]

       public ICollection<EmpacadosDetalle> EmpacadosDetalle { get; set; } 

    }
}