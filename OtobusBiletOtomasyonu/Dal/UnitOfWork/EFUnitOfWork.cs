using Dal.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;

        public EFUnitOfWork(Context dbContext)
        {
            Database.SetInitializer<Context>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext null olamaz.");

            _dbContext = dbContext;

        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
             
                return _dbContext.SaveChanges();
            }
            catch
            {
                
                throw;
            }
        }
        #endregion

        #region IDisposable Members
       
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
