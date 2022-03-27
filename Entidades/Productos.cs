using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
    public class Productos // Registro de productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la descripcion")]
        public string Descripcion { get; set; }

        public DateTime FechaVencimiento { get; set; } = DateTime.Now;

        
        [Required(ErrorMessage = "Es obligatorio introducir la existencia del producto")]
        public float Existencia { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Campo obligatorio. Se debe indicar el peso del producto")]
        public float Peso { get; set; }
         
        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Campo obligatorio. Se debe indicar el costo del producto")]
        public float Costo { get; set; }

         [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Campo obligatorio. Se debe indicar el precio")]
        public double Precio { get; set; }
        public double Ganancia { get; set; }
        public float ValorInventario { get; set; }

        public Productos() { Descripcion = string.Empty; }

 
        [ForeignKey("ProductoId")]

        public virtual List<ProductosDetalle> ProductosDetalle { get; set; } = new List<ProductosDetalle>(); 
    
    }
}