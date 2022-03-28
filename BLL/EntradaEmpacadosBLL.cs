using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2.DAL;
using Parcial2.Models;

#nullable disable // Para quitar el aviso de nulls

namespace Parcial2.BLL;

public class EntradaEmpacadosBLL // BLL para la Entrada de Productos Empacados
{

    private Contexto _contexto;

    public EntradaEmpacadosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int id) // Existe
    {
        bool existe = false;
        try
        {
            existe = _contexto.EntradaEmpacados
           .Any(e => e.EmpacadosId == id);

        }
        catch (Exception)
        {
            throw;
        }
        return existe;
    }

    public bool Guardar(EntradaEmpacados entradaEmpacados) // Guardar
    {
                 
        if (!Existe(entradaEmpacados.EmpacadosId))
             {
                return  Insertar(entradaEmpacados);
             }
            else
             {
                return Modificar(entradaEmpacados);
             }
    }

    private bool Insertar(EntradaEmpacados entradaEmpacados)
     {
            
             bool paso = false;
            try
            {
                
                foreach (var item in entradaEmpacados.EmpacadosDetalle) 
                {
                    _contexto.Entry(item).State = EntityState.Added;
                    _contexto.Entry(item.producto).State = EntityState.Modified;

                    // Actualiza la existencia reduciendola y el valor inventario - Utilizado
                    item.producto.Existencia -= entradaEmpacados.CantidadUtilizada;
                    item.producto.ValorInventario = item.producto.Costo * item.producto.Existencia; 
                }
                var itemm = _contexto.Productos.Find(entradaEmpacados.ProductoId); 
                
                if(itemm!=null)
                {
                // Actualiza la existencia aumentandola y el valor inventario - Producido
                itemm.Existencia += entradaEmpacados.CantidadProducida;
                itemm.ValorInventario = itemm.Costo * itemm.Existencia;
            }
                _contexto.EntradaEmpacados.Add(entradaEmpacados);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

    private bool Modificar(EntradaEmpacados entradaEmpacados) // Modificar Existencia, Valor Inventario
    {
             bool paso = false;

            try
            {
                var lista = _contexto.EntradaEmpacados
                .Where(x => x.EmpacadosId == entradaEmpacados.EmpacadosId)
                .Include(x => x.EmpacadosDetalle)
                .ThenInclude(x => x.producto)
                .AsNoTracking()
                .SingleOrDefault();

            if(lista!=null)
            {

            foreach (var item in lista.EmpacadosDetalle)
              {
                item.producto.Existencia += entradaEmpacados.CantidadUtilizada; // Actualizando la existencia utilizada
                item.producto.ValorInventario = item.producto.Costo * item.producto.Existencia; // Actualizando el valor inventario
              }
                    
              var itemm = _contexto.Productos.Find(entradaEmpacados.ProductoId);

                if(itemm!=null)
                {

                itemm.Existencia -= entradaEmpacados.CantidadProducida; 
                itemm.ValorInventario = itemm.Costo* itemm.Existencia;

                }

                _contexto.Database.ExecuteSqlRaw($"Delete FROM EmpacadosDetalle where EmpacadosId={entradaEmpacados.EmpacadosId}");



            foreach (var item in entradaEmpacados.EmpacadosDetalle)
               {
                 _contexto.Entry(item).State = EntityState.Added;
                _contexto.Entry(item.producto).State = EntityState.Modified;

                item.producto.Existencia -= entradaEmpacados.CantidadUtilizada;
                item.producto.ValorInventario = item.producto.Costo * item.producto.Existencia;

               }

                var producido = _contexto.Productos.Find(entradaEmpacados.ProductoId);

                if(producido!=null)
                {
                    producido.Existencia += entradaEmpacados.CantidadProducida; 
                    producido.ValorInventario = producido.Costo * producido.Existencia;
                }

                    _contexto.Entry(entradaEmpacados).State = EntityState.Modified;
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

         public EntradaEmpacados Buscar(int id) // Buscar
        {
            EntradaEmpacados entradaEmpacados;

            try
            {
                entradaEmpacados = _contexto.EntradaEmpacados
                .Include( e => e.EmpacadosDetalle)
                .Where( e => e.EmpacadosId == id).Include( x => x.EmpacadosDetalle)
                .ThenInclude( x => x.producto).ThenInclude( x => x.ProductosDetalle)
                .AsNoTracking().SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return entradaEmpacados;
        }
  
    public bool Eliminar(int id) // Eliminar
        {
           bool paso = false;

            try
            {
            var entradaEmpacado = _contexto.EntradaEmpacados.Find(id);
            if (entradaEmpacado != null){
                 

            var item = _contexto.Productos.Find(entradaEmpacado.ProductoId);
            if(item != null)

            {

             item.Existencia -= entradaEmpacado.CantidadProducida;
             item.ValorInventario = item.Existencia * item.Costo;

            }

            foreach (var itemm in entradaEmpacado.EmpacadosDetalle)

            {
                _contexto.Entry(itemm.entradaEmpacado).State = EntityState.Modified;
                _contexto.Entry(itemm.producto).State = EntityState.Modified;

                itemm.producto.Existencia += entradaEmpacado.CantidadUtilizada;
                itemm.producto.ValorInventario  = itemm.producto.Existencia * itemm.producto.Costo;
            }

                _contexto.EntradaEmpacados.Remove(entradaEmpacado);

                paso = _contexto.SaveChanges() > 0;

                }

            }

            catch (Exception)
            {
                throw;
            }
            return paso;
        }


    public List<EntradaEmpacados> GetListEmpacados(Expression<Func<EntradaEmpacados, bool>> criterio)
    {
           List<EntradaEmpacados> lista = new List<EntradaEmpacados>();  // Lista de los productos empacados
            try
            {
                lista = _contexto.EntradaEmpacados

                .Include(x => x.EmpacadosDetalle)
                .ThenInclude(x => x.producto) .ThenInclude(x => x.ProductosDetalle).Where(criterio)
                .AsNoTracking()
                .ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }      
           
    }
