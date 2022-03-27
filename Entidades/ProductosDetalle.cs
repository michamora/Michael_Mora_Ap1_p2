using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable // Para quitar el aviso de nulls

namespace Parcial2.Models
{
    public class ProductosDetalle // Detalle del Registro de Productos
    {
        [Key]
        public int ProductoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public string Presentacion { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
    
        public ProductosDetalle(){}

        public ProductosDetalle(string presentacion, float cantidad, float precio)
        {
            
            this.Presentacion = presentacion;

            this.Cantidad = cantidad;
            
            this.Precio = precio;
        }
           
            
        //public virtual Productos Producto { get; set; } = new Productos();

    }
}