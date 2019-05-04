using Dal.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UnitOfWork
{
    public class UnitOfWork
    {
    //    private Context _dbContex;
    //    private DbContextTransaction _transaction;


    //    private BiletServis biletServis;

    //    public UnitOfWork()
    //    {
    //        _dbContex = new Context();
    //    }


    //    public bool ApplyChanges()
    //    {
    //        bool isSuccess;
    //        _transaction = _dbContex.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
    //        try
    //        {
    //            _dbContex.SaveChanges();
    //            _transaction.Commit();
    //            isSuccess = true;
    //        }
    //        catch (Exception ex)
    //        {
                
    //            string hata = ex.Message;
    //            _transaction.Rollback();
    //            isSuccess = false;
    //        }
    //        finally
    //        {
    //            _transaction.Dispose();
    //        }
    //        return isSuccess;
    //    }
    //    public BiletServis BiletServis
    //    {
    //        get
    //        {
    //            if (biletServis == null)
    //            {
    //                biletServis = new BiletServis(_dbContex);
    //            }
    //            return biletServis;
    //        }
    //    }
    }


    
}
