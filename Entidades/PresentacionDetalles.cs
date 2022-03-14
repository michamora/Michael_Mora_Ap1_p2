using System.ComponentModel.DataAnnotations;

namespace Parcial2.Models;
public class PresentacionDetalles
{
     [Key]  
    public int ProductoDetallesId { get; set; }
    public string Descripcion { get; set; }
    public string Presentacion { get; set; }
    public float Cantidad { get; set; }
    public float Precio { get; set; }
    public float PesoTotal { get; set; }
    public int ProductoId { get; set; }
    public float ExistenciaEmpacada { get; set; }

}