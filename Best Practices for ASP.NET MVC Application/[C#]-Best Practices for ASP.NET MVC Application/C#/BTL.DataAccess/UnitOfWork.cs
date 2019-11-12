#region

using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;

#endregion

namespace BTL.DataAccess
{
    public class UnitOfWork
    {
        public UnitOfWork(DataContext context)
        {
            //Contract.Requires<ArgumentNullException>(context != null);

            Context = context;
        }

        protected DataContext Context { get; private set; }

        public virtual void Commit()
        {
            if (Context.ChangeTracker.Entries().Any(HasChanged))
            {
                Context.SaveChanges();
            }
        }

        private static bool HasChanged(DbEntityEntry entity)
        {
            return IsState(entity, EntityState.Added) ||
                   IsState(entity, EntityState.Deleted) ||
                   IsState(entity, EntityState.Modified);
        }

        private static bool IsState(DbEntityEntry entity, EntityState state)
        {
            return (entity.State & state) == state;
        }
    }
}