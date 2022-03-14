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
            return _contexto.EntradaEmpacados.AsNoTracking().
            Any(p => p.EmpacadosId == id);

        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Guardar(EntradaEmpacados entradaEmpacados)
    {

        try
        {
            var id = entradaEmpacados.EmpacadosId;
            return !Existe(id != null ? (int)id : 0) ?
            Insertar(entradaEmpacados) : Modificar(entradaEmpacados);
        }
        catch (Exception)
        {
            
            throw;
        }
    }

    public bool Insertar(EntradaEmpacados entradaEmpacados)
    {
        bool paso = false;
        try
        {
            _contexto.EntradaEmpacados.Add(entradaEmpacados);
                paso = _contexto.SaveChanges() > 0;
            } catch(Exception){
                throw;
            }
            return paso;
        }

    private bool Modificar(EntradaEmpacados entradaEmpacados)
    {

        try
        {
            _contexto.EntradaEmpacados.Update(entradaEmpacados);
            var response = _contexto.SaveChanges() > 0;
            return response;
        }
        catch (Exception)
        {
            throw;
        }
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

    public EntradaEmpacados? Buscar(int id)
    {

        try
        {
            return _contexto.EntradaEmpacados.Include(p => 
            p.PUtilizados).Include(p => p.PProducidos).ThenInclude(p =>
            p.Producto).FirstOrDefault(p => p.EmpacadosId == id);
        }
        catch (Exception)
        {
            throw;
        }

    }

    public List<EntradaEmpacados> GetList(Expression<Func<EntradaEmpacados, bool>> criterio)
    {

        try
        {
            return _contexto.EntradaEmpacados.Where(criterio).Include(p => 
            p.PUtilizados).AsNoTracking().ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

}