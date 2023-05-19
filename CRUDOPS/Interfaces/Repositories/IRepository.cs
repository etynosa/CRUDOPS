using CRUDOPS.Interfaces.Data;
using System.Linq.Expressions;

namespace CRUDOPS.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> GetAsync(long Id);

        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity, bool updateState = false);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Attach(TEntity entity);

        void Detach(TEntity entity);

        List<TEntity> GetSorted(Expression<Func<TEntity, object>> orderBy, bool isAscending);

        List<TEntity> GetAllByPage(int page, int pageSize);

        IEnumerable<TEntity> GetAll();
        TEntity GetById(long Id);
    }
}

