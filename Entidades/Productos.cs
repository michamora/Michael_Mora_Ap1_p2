using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        [MinLength(3, ErrorMessage = "La descripcion debe tener al menos {1} caracteres")]
        [MaxLength(50, ErrorMessage = "La descripcion no puede exceder {1} caracteres")]
        public string? Descripcion { get; set; }

        
        [Required(ErrorMessage ="Campo obligatorio. poner fecha de vencimiento.")]
        public DateTime FechaVencimiento { get; set; }
        
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "La existencia debe ser mayor a {1} y menor a {2}")]
        public float Existencia { get; set; }
        
        [Required]
        [Range(0, float.MaxValue, ErrorMessage = "El costo debe ser mayor a {1} y menor a {2}")]

        public float Costo { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor a {1} y menor a {2}")]
        
        public double Precio { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La ganancia debe ser mayor entre 1 y 100")]
        public double Ganancia { get; set; }
        public float ValorInventario { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Se debe indicar el peso del producto en gramos.")]
        public double Peso {get; set; }
        
        [ForeignKey("ProductoId")]
        
          public ICollection<EntradaEmpacados> EntradaEmpacados { get; set; }
          public ICollection<ProductosDetalle> ProductosDetalle { get; set; }
  
    
    }
}