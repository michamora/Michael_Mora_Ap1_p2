using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models
{
public class EntradaEmpacados
{

    [Key]
    public int EmpacadosId { get; set; }

    [Required]
    [MaxLength(80, ErrorMessage = "El concepto no puede exceder {1} caracteres")]
    [MinLength(3, ErrorMessage = "El concepto debe tener al menos {1} caracteres")]
    public string? Concepto { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required]

    public ICollection<PresentacionDetalles> PresentacionDetalles { get; set; }
    public ICollection<ProductosUtilizados> PUtilizados { get; set; }

    public ProductosDetalle? PProducidos { get; set; }
}
}