using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SkiShopAngular2.DAL
{
    public class Repository<T>: IRepository<T> where T: class
    {
        private SkiShopContext context = null;
        private DbSet<T> dbSet;

        public Repository(SkiShopContext contextPassed)
        {
            context = contextPassed;
            dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T,bool>> predicate = null)
        {
            if (predicate != null)
            {
                return dbSet.Where(predicate);
            }
            return dbSet;
        }

        public IQueryable<T> GetAllEager(Expression<Func<T, object>> property,
            Expression<Func<T, bool>> predicate = null)

        {
            if (predicate != null)
            {
                return dbSet.Include(property).Where(predicate);
            }
            return dbSet.Include(property);
        }
       
        public ReferenceEntry<T,object> GetReference(T entity, Expression<Func<T, object>> property)
        {
            return context.Entry(entity)
                .Reference(property);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public T GetEager(Expression<Func<T, object>> property, Expression<Func<T, bool>> predicate)
        {
            return dbSet.Include(property).FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State=EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Attach(entity); // in case the passed entity has not existed
            dbSet.Remove(entity);
        }

        public void DeleteById(int entityId)
        {
            var entity = dbSet.Find(entityId);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

    }

    public class Repository<T, T1> : IRepository<T, T1>
        where T1 : class
        where T : class
    {
        private SkiShopContext context = null;
        private DbSet<T> dbSet;

        public Repository(SkiShopContext contextPassed)
        {
            context = contextPassed;
            dbSet = context.Set<T>();
        }

        public IQueryable<T> GetAllEager(Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> property, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return dbSet.Include(joinProperty)
                    .ThenInclude(property)
                    .Where(predicate);

            }

            return dbSet.Include(joinProperty)
                .ThenInclude(property);
        }

        public IQueryable<T> GetAllEagerAll(Expression<Func<T, object>> property,
            Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> propertyOfJoin, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return dbSet.Include(property)
                    .Include(joinProperty)
                    .ThenInclude(propertyOfJoin)
                    .Where(predicate);
            }

            return dbSet.Include(property)
                .Include(joinProperty)
                .ThenInclude(propertyOfJoin);
        }

        public T GetEagerAll(Expression<Func<T, object>> property1, Expression<Func<T, object>> property2,
            Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> propertyOfJoin, Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return dbSet.Include(property1)
                    .Include(property2)
                    .Include(joinProperty)
                    .ThenInclude(propertyOfJoin)
                    .Where(predicate)
                    .FirstOrDefault();
            }

            return dbSet.Include(property1)
                    .Include(property2)
                    .Include(joinProperty)
                    .ThenInclude(propertyOfJoin)
                    .FirstOrDefault();
        }

        public CollectionEntry<T,T1> GetCollection(T entity, Expression<Func<T, IEnumerable<T1>>> property)
        {
            return context.Entry(entity)
                .Collection(property);
        }
    }
}
