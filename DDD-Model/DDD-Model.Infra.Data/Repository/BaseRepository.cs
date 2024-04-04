using DDD_Model.Domain.Entities;
using DDD_Model.Domain.Interfaces;
using DDD_Model.Infra.Data.Context;

namespace DDD_Model.Infra.Data.Repository;
public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly SqlServerContext _sqlServerContext;

    public BaseRepository(SqlServerContext sqlServerContext)
    {
        _sqlServerContext = sqlServerContext;
    }

    public void Insert(TEntity obj)
    {
        _sqlServerContext.Set<TEntity>().Add(obj);
        _sqlServerContext.SaveChanges();
    }

    public void Update(TEntity obj)
    {
        _sqlServerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _sqlServerContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _sqlServerContext.Set<TEntity>().Remove(Select(id));
        _sqlServerContext.SaveChanges();
    }

    public IList<TEntity> Select() =>
        _sqlServerContext.Set<TEntity>().ToList();

    public TEntity Select(int id)
    {
        var entity = _sqlServerContext.Set<TEntity>().Find(id);

        return entity is null ? throw new Exception("Id not found.") : entity;
    }
}
