using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class EntityBaseRepository<TEntity, TContext> : IRepository<TEntity>
         where TEntity : BaseEntity, new()
         where TContext : DbContext, new()
    {


        //private Context _dbContext;

        //public EntityBaseRepository(Context dbContext)
        //{
        //    _dbContext = dbContext;
        //}


        //private readonly DbContext _dbContext;
        //private readonly DbSet<TEntity> _dbSet;

        //public EntityBaseRepository(Context dbContext)
        //{
        //    if (dbContext == null)
        //        throw new ArgumentNullException("dbContext can not be null.");

        //    _dbContext = dbContext;
        //    _dbSet = dbContext.Set<TEntity>();
        //}










        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
