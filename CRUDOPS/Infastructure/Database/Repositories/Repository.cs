using CRUDOPS.Interfaces.Data;
using CRUDOPS.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUDOPS.Infastructure.Database.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly CrudOpsDbContext dbContext;

        public Repository(CrudOpsDbContext databaseContext)
        {
            dbContext = databaseContext;
        }

        public async Task<TEntity> GetAsync(long Id)
        {
            return await dbContext.Set<TEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
        public TEntity GetById(long Id)
        {
           return dbContext.Set<TEntity>().Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter != null ? dbContext.Set<TEntity>().Where(filter) : dbContext.Set<TEntity>()).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            PrepareEntityForAdd(entity);

            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                PrepareEntityForAdd(entity);
            }

            dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity, bool updateState = false)
        {
            if (entity is IEntityEditTrackable)
            {
                (entity as IEntityEditTrackable).ModifiedOn = DateTime.UtcNow;
            }

            if (updateState)
            {
                dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

            }
        }

        public void Remove(TEntity entity)
        {
            if (entity is IDeleteTrackable)
            {
                (entity as IDeleteTrackable).IsDeleted = true;
                Update(entity);
            }
            else
            {
                dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities.FirstOrDefault() is IDeleteTrackable)
            {
                foreach (var entity in entities)
                {
                    (entity as IDeleteTrackable).IsDeleted = true;
                    Update(entity);
                }
            }
            else
            {
                dbContext.Set<TEntity>().RemoveRange(entities);
            }
        }

        public void Attach(TEntity entity)
        {
            dbContext.Set<TEntity>().Attach(entity);
        }

        public void Detach(TEntity entity)
        {
            dbContext.Entry<TEntity>(entity).State = EntityState.Detached;
        }

        public List<TEntity> GetAllByPage(int page, int pageSize)
        {
           return dbContext.Set<TEntity>()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public List<TEntity> GetSorted(Expression<Func<TEntity, object>> orderBy, bool isAscending)
        {
            var query = dbContext.Set<TEntity>().AsQueryable();

            if (isAscending)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);

            return query.ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().ToList();
        }


        private void PrepareEntityForAdd(TEntity entity)
        {
            if (entity is IEntityCreateTrackable)
            {
                var currentdateTime = DateTime.UtcNow;

                (entity as IEntityCreateTrackable).CreatedOn = currentdateTime;
                (entity as IEntityEditTrackable).ModifiedOn = currentdateTime;
            }
        }
    }
}
