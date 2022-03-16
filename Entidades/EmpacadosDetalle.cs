using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models;
public class EmpacadosDetalle
{
     [Key]
        public int EmpacadosDetalleId {get; set;}
        public int EmpacadosId {get; set;}

        public string Descripcion {get; set;}
        public int Cantidad {get; set; }
        public float Peso {get; set; }

        
         public Productos? _producto {get; set;}

        public EmpacadosDetalle? _productosEmpacadosDetalle {get; set;}

       
        
        public EmpacadosDetalle(int empacadosid, string descripcion, int cantidad, float peso)
        {
            EmpacadosId = empacadosid;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Peso = peso;
            
        }

         public EmpacadosDetalle()
        {
            


        }

        public EntradaEmpacados? EntradaEmpacados { get; set; }
    }
