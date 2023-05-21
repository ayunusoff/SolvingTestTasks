using AltPoint.Domain.Entities;

namespace AltPoint.Domain.Interfaces
{
    public interface IRepo<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> GetAllSoftDeleted();
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
