using DDD_Model.Domain.Entities;

namespace DDD_Model.Domain.Interfaces;
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    void Insert(TEntity obj);
    void Update(TEntity obj);
    void Delete(int id);
    IList<TEntity> Select();
    TEntity Select(int id);
}
