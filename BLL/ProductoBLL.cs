using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using Parcial2.DAL;
using Parcial2.Models;


namespace Parcial2.BLL // BLL
{
    public class ProductoBLL
    {
        private readonly Contexto _contexto;

        public ProductoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        

        public bool Existe(int id)
        {
            
            

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Productos.Any(p => p.ProductoId == id);
            }
           catch (Exception)
            {
                throw;
            }
              
            
            return encontrado;
        }

        public  bool Guardar(Productos producto)
        {
           
            
            if (!Existe(producto.ProductoId))
             {
                return  Insertar(producto);
             }
            else
             {
                return Modificar(producto);
             }
        }

        private bool Insertar(Productos producto)
        {
            
           bool paso = false;

            try{
                
                 _contexto.Productos.Add(producto);
                paso = _contexto.SaveChanges() > 0;
            } catch(Exception){
                throw;
            }
            return paso;
        }
  
        private bool Modificar(Productos producto)
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

       public bool Eliminar(int Id)
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


               public Productos Buscar(int id)
        {
            Productos producto;

            try
            {
                
               producto = _contexto.Productos.Include(x => 
               x.ProductosDetalle).Where(p => p.ProductoId == id).SingleOrDefault();

            }
            catch(Exception)
            {
                throw;
            }
            return producto;
        }

      
        
        public List<Productos> GetLista(Expression<Func<Productos, bool>> critero)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = _contexto.Productos.Where(critero).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

    

    public List<ProductosDetalle> GetDetalles(Expression<Func<ProductosDetalle, bool>> criterio)
        {
            List<ProductosDetalle> lista = new List<ProductosDetalle>();

            try
            {
                lista = _contexto.ProductosDetalle.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
    }

    
}