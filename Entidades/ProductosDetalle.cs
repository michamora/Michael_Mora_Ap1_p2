using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
    public class ProductosDetalle
    {
        [Key]
        
        public int ProductoDetalleId { get; set; }
        
        [Required(ErrorMessage = "Es obligatorio introducir la Presentacion")]
        public string Presentacion { get; set; }
        
        [Required(ErrorMessage = "La Cantidad no puede estar vacia...")]
        [Range(1, float.MaxValue, ErrorMessage = "La Cantidad debe estar en un rango de {1} y {2}.")]
        public float? Cantidad { get; set; }

        [Required(ErrorMessage = "El Precio no puede estar vacio...")]
        [Range(1, float.MaxValue, ErrorMessage = "El Precio debe estar en un rango de {1} y {2}.")]
        public float? Precio { get; set; }
        public float? ExistenciaEmpacada { get; set; }

        public ProductosDetalle()
        {
            

            this.ProductoDetalleId = 0;

            this.Presentacion = "";

            this.Cantidad = 0;

            this.Precio = 0;
        }

        public ProductosDetalle(int id, string presentacion, float cantidad, float precio)
        {
            
            this.ProductoDetalleId = id; 
            
            this.Presentacion = presentacion;

            this.Cantidad = cantidad;
            
            this.Precio = precio;
        }
           
           
       public Productos? Producto { get; set; }

    }
}