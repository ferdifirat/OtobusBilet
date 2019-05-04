using Dal.Repository;
using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UnitOfWork
{
    //public class UnitOfWork2 :IUnitOfWork
    //{
    //    private readonly Context _dbContext;

    //    public UnitOfWork2(Context dbContext)
    //    {
    //        Database.SetInitializer<Context>(null);

    //        if (dbContext == null)
    //            throw new ArgumentNullException("dbContext can not be null.");

    //        _dbContext = dbContext;

    //        // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
    //        //_dbContext.Configuration.LazyLoadingEnabled = false;
    //        //_dbContext.Configuration.ValidateOnSaveEnabled = false;
    //        //_dbContext.Configuration.ProxyCreationEnabled = false;
    //    }

    //    #region IUnitOfWork Members
    //    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
    //    {
    //        return new EntityBaseRepository<TEntity,Context>(_dbContext);
    //    }

    //    public int SaveChanges()
    //    {
    //        try
    //        {
    //            // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
    //            // sadece değişen alanları güncellemeyide sağlayabiliriz.
    //            return _dbContext.SaveChanges();
    //        }
    //        catch
    //        {
    //            // Burada DbEntityValidationException hatalarını handle edebiliriz.
    //            throw;
    //        }
    //    }
    //    #endregion

    //    #region IDisposable Members
    //    // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
    //    private bool disposed = false;
    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                _dbContext.Dispose();
    //            }
    //        }

    //        this.disposed = true;
    //    }
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //    #endregion
    //}
}
