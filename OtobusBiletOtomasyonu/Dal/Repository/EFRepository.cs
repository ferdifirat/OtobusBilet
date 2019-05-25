using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(Context dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        #region IRepository Members
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        { 
               
           DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);
            
           _dbSet.Attach(entity);
          _dbSet.Remove(entity);
                
            
        }

        //public void Delete(int id)
        //{
        //    var entity = GetById(id);
        //    if (entity == null) return;
        //    else
        //    {
        //        if (entity.GetType().GetProperty("IsDelete") != null)
        //        {
        //            T _entity = entity;
        //            _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

        //            this.Update(_entity);
        //        }
        //        else
        //        {
        //            Delete(entity);
        //        }
        //    }
        //}

        public void Delete(int id)
        {
            var entity = GetById(id);
            
                Delete(entity);
        }

        public void AddRange(List<T> entities)
        {
            _dbSet.AddRange(entities);

        }
        #endregion
    }
}
