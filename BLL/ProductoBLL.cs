using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Parcial2.DAL;
using Parcial2.Models;

#nullable disable // Para quitar el aviso de nulls


namespace Parcial2.BLL // BLL para Productos
{  
    public class ProductoBLL
    {
        private Contexto _contexto;

        public ProductoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int id) // Existe
        {
            
            bool encontrado = false;

            try
            {
                 encontrado = _contexto.Productos
                .Any(p => p.ProductoId == id);
            }
           catch (Exception)
            {
                throw;
            }
 
            return encontrado;
        }

        public  bool Guardar(Productos producto) // Guardar
        {
           producto.ValorInventario = producto.Costo * producto.Existencia;
           producto.Ganancia =  Convert.ToInt32(((producto.Precio - producto.Costo) / producto.Costo) * 100);
            
            if (!Existe(producto.ProductoId))
             {
                return  Insertar(producto);
             }
            else
             {
                return Modificar(producto);
             }
        }


        private bool Modificar(Productos producto) // Modificar
        {
    
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductosDetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.ProductosDetalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                    _contexto.Entry(producto).State = EntityState.Modified;

                    paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Productos producto) // Insertar
        {
            
           bool paso = false;

            try{
                
                 _contexto.Productos.Add(producto);
                 paso = _contexto.SaveChanges() > 0;

            } catch(Exception)
            {
                throw;
            }
            return paso;
        }

        public Productos Buscar(int id) // Buscar
        {
            Productos producto;

            try
            {           
                producto = _contexto.Productos
               .Include(x => x.ProductosDetalle)
               .Where(p => p.ProductoId == id)
               .AsNoTracking()
               .SingleOrDefault();
            }
            catch(Exception)
            {
                throw;
            }
            return producto;
        }

         public bool Eliminar(int Id) // Eliminar
        {
            bool paso = false;

            try
            {
                var producto = _contexto.Productos.Find(Id);

                if (producto != null)
                {
                    _contexto.Productos.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

 
        public List<Productos> GetListaProductos(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>(); // Lista de los productos

           try
            {
                lista = _contexto.Productos
                .Include(x => x.ProductosDetalle)
                .Where(criterio)
                .AsNoTracking().ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        
   
        
    }

    
}