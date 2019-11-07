using System;
using Microsoft.EntityFrameworkCore;

namespace SkiShopAngular2.DAL
{
    public class UnitOfWork<T> : IDisposable where T : class
    {
        private SkiShopContext context;

        private Repository<T> repository;

        private bool ifDispose;

        public UnitOfWork(SkiShopContext contextPass, bool ifDisposeContext=true)
        {
            context = contextPass;
            ifDispose = ifDisposeContext;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException Exception)  // DbEntityValidationException is not supported yet
            {
                throw;
            }
            
        }

        public Repository<T> Repository
        {
            get
            {
                if (repository == null)
                {
                    return repository= new Repository<T>(context);
                }
                return repository;
            }
        }

        public void Dispose()
        {
            if (ifDispose)
            {
                context?.Dispose();
            }
            
        }
    }

    public class UnitOfWork<T,T1> : UnitOfWork<T>, IDisposable 
        where T1: class 
        where T : class
    {
        private SkiShopContext context;

        private Repository<T,T1> repositoryMany;

        private bool ifDispost;

        public UnitOfWork(SkiShopContext contextPass, bool ifDisposeContext = true) : base(contextPass,ifDisposeContext)
        {
            context = contextPass;
            ifDispost = ifDisposeContext;
        }

        public Repository<T,T1> RepositoryMany
        {
            get
            {
                if (repositoryMany == null)
                {
                    return repositoryMany = new Repository<T,T1>(context);
                }
                return repositoryMany;
            }
        }

    }
}
