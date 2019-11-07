#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BTL.Domain;

#endregion

namespace BTL.DataAccess
{
    public class Repository<TAggregateRoot> :
        IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public Repository(DataContext context)
        {
            //Contract.Requires<ArgumentNullException>(context != null);

            Context = context;
        }

        protected DataContext Context { get; private set; }

        #region IRepository<TAggregateRoot> Members

        public virtual void Save(TAggregateRoot instance)
        {
            if (instance.Id == Guid.Empty)
            {
                instance.Id = Guid.NewGuid();
                instance.CreatedAt = DateTime.Now;
                CreateSet().Add(instance);
            }
            else
            {
                instance.UpdatedAt = DateTime.Now;
                Context.MarkAsModified(instance);
            }
        }

        public virtual void Remove(TAggregateRoot instance)
        {
            CreateSet().Remove(instance);
        }

        public virtual TAggregateRoot One(
            Expression<Func<TAggregateRoot, bool>> predicate = null,
            params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return (predicate == null)
                       ? set.FirstOrDefault()
                       : set.FirstOrDefault(predicate);
        }

        public virtual IQueryable<TAggregateRoot> All(
            Expression<Func<TAggregateRoot, bool>> predicate = null,
            params Expression<Func<TAggregateRoot, object>>[] includes)
        {
            var set = CreateIncludedSet(includes);

            return (predicate == null) ? set : set.Where(predicate);
        }

        public virtual bool Exists(
            Expression<Func<TAggregateRoot, bool>> predicate = null)
        {
            var set = CreateSet();

            return (predicate == null) ? set.Any() : set.Any(predicate);
        }

        public virtual int Count(
            Expression<Func<TAggregateRoot, bool>> predicate = null)
        {
            var set = CreateSet();

            return (predicate == null)
                       ? set.Count()
                       : set.Count(predicate);
        }

        #endregion

        private IDbSet<TAggregateRoot> CreateIncludedSet(
            IEnumerable<Expression<Func<TAggregateRoot, object>>> includes)
        {
            var set = CreateSet();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    set.Include(include);
                }
            }

            return set;
        }

        private IDbSet<TAggregateRoot> CreateSet()
        {
            return Context.CreateSet<TAggregateRoot>();
        }
    }
}