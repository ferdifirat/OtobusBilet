using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;
using Data;

namespace Dal.UnitOfWork
{
//    public class EFUnitOfWork : IUnitOfWork
//    {
//        private readonly Context _context;
//        public EFUnitOfWork(Context context)
//        {Database.SetInitializer<Context>(null);

//            if (context == null)
//                throw new ArgumentNullException("dbContext can not be null.");

//            _context = context;
//        }
//        //public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
//        //{
//        //    return new EntityBaseRepository<TEntity,Context>(_context);
//        //}
//        public int SaveChanges()
//        {
//            try
//            {
//                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
//                // sadece değişen alanları güncellemeyide sağlayabiliriz.
//                return _context.SaveChanges();
//            }
//            catch
//            {
//                // Burada DbEntityValidationException hatalarını handle edebiliriz.
//                throw;
//            }
//        }


//        private bool disposed = false;
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposed)
//            {
//                if (disposing)
//                {
//                    _context.Dispose();
//                }
//            }

//            this.disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//    }
}
