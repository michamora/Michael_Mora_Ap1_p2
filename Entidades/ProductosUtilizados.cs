using System.ComponentModel.DataAnnotations;
namespace Parcial2.Models;
public class ProductosUtilizados

{
    public int ProductosUtilizadosId { get; set; }
    public int? CantidadUtilizados { get; set; }
    public int? ProductoDetalleId { get; set; }

    public string Descripcion { get; set; }

}