using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2.DAL;
using Parcial2.Models;

namespace Parcial2.BLL;

public class EntradaEmpacadosBLL // BLL para los Productos Empacados
{

    private Contexto _contexto;

    public EntradaEmpacadosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int id)
    {
        try
        {
            return _contexto.EntradaEmpacados.AsNoTracking()
            .Any(p => p.EmpacadosId == id);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Guardar(EntradaEmpacados entradaEmpacados)
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

    public bool Insertar(EntradaEmpacados entradaEmpacados)
     {
            
           bool paso = false;

            try{
                
                 _contexto.EntradaEmpacados.Add(entradaEmpacados);
                paso = _contexto.SaveChanges() > 0;
            } catch(Exception){
                throw;
            }
            return paso;
        }

    private bool Modificar(EntradaEmpacados entradaEmpacados)
    {

            
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductosDetalle WHERE ProductoId={entradaEmpacados.EmpacadosId}");

                foreach (var Anterior in entradaEmpacados.EmpacadosDetalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(entradaEmpacados).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

    public bool Eliminar(int id)
    {
        var entradaEmpacado = Buscar(id);

        if (entradaEmpacado is not null)
        {
            try
            {
                _contexto.Entry(entradaEmpacado).State 
                = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        return false;
    }

    public EntradaEmpacados Buscar(int id)
    {
        EntradaEmpacados entradaEmpacados;
        try
        {
            entradaEmpacados = _contexto.EntradaEmpacados.Include(x =>
            x.EmpacadosDetalle).Where(p => p.EmpacadosId ==
            id).AsNoTracking().SingleOrDefault();
        }
        catch (Exception)
        {
            throw;
        }

        return entradaEmpacados;

    }

    public List<EntradaEmpacados> GetList(Expression<Func<EntradaEmpacados, bool>> criterio)
    {
           List<EntradaEmpacados> lista = new List<EntradaEmpacados>();
            try
            {
                lista = _contexto.EntradaEmpacados.Where(criterio).AsNoTracking().ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public List<EmpacadosDetalle> GetEmpacados(Expression<Func<EmpacadosDetalle, bool>> criterio)
           {
               List<EmpacadosDetalle> lista = new List<EmpacadosDetalle>();
               try
               {
                   return _contexto.EmpacadosDetalle.Where(criterio).AsNoTracking().ToList();
                   

               }
               catch (Exception)
               {
                   throw;
               }
               
                
           }
    }
