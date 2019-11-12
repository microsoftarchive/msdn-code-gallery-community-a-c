#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Reflection;

#endregion

namespace BTL.DataAccess
{
    public class DataContext : DbContext
    {
        private readonly IDictionary<MethodInfo, object> _configurations;

        public DataContext(
            string nameOrConnectionString,
            IDictionary<MethodInfo, object> configurations)
            : base(nameOrConnectionString)
        {
            //Contract.Requires<ArgumentNullException>(configurations != null);

            _configurations = configurations;
        }

        public virtual void MarkAsModified<TEntity>(TEntity instance)
            where TEntity : class
        {
            Entry(instance).State = EntityState.Modified;
        }

        public virtual IDbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            foreach (var config in _configurations)
            {
                config.Key.Invoke(
                    modelBuilder.Configurations,
                    new[] {config.Value});
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}