using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SkiShopAngular2.DAL
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll(Expression<Func<T,bool>> predicate =null);

        // Eager loading: for one-to-one and one-to-many
        IQueryable<T> GetAllEager(Expression<Func<T, object>> property, Expression<Func<T, bool>> predicate);

        // Explicit loading
        ReferenceEntry<T,object> GetReference(T entity, Expression<Func<T, object>> property);

        T Get(Expression<Func<T, bool>> predicate);

        T GetEager(Expression<Func<T, object>> property, Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        void DeleteById(int entityId);
    }

    public interface IRepository<T, T1>
        where T1 : class 
        where T : class

    {
        // Eager loading: many-to-many
        IQueryable<T> GetAllEager(Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> property, Expression<Func<T, bool>> predicate = null);

        // Eager loading: one-to-many & many-to-many
        IQueryable<T> GetAllEagerAll(Expression<Func<T, object>> property,
            Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> propertyOfJoin, Expression<Func<T, bool>> predicate = null);

        T GetEagerAll(Expression<Func<T, object>> property1, Expression<Func<T, object>> property2,
            Expression<Func<T, ICollection<T1>>> joinProperty,
            Expression<Func<T1, object>> propertyOfJoin, Expression<Func<T, bool>> predicate = null);
        
        // Explicit loading

        CollectionEntry<T,T1> GetCollection(T entity, Expression<Func<T, IEnumerable<T1>>> property);

    }
}
