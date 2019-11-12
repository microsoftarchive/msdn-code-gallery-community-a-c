using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Customer_Entities context = null;
        private DbSet<T> entities = null;

        public GenericRepository(Customer_Entities context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        /// <summary>
        /// Get Data From Database
        /// <para>Use it when to retive data through a stored procedure</para>
        /// </summary>
        public IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters)
        {
            using (context = new Customer_Entities())
            {
                return context.Database.SqlQuery<T>(spQuery, parameters).ToList();
            }
        }

        /// <summary>
        /// Get Single Data From Database
        /// <para>Use it when to retive single data through a stored procedure</para>
        /// </summary>
        public T ExecuteQuerySingle(string spQuery, object[] parameters)
        {
            using (context = new Customer_Entities())
            {
                return context.Database.SqlQuery<T>(spQuery, parameters).FirstOrDefault();
            }
        }

        /// <summary>
        /// Insert/Update/Delete Data To Database
        /// <para>Use it when to Insert/Update/Delete data through a stored procedure</para>
        /// </summary>
        public int ExecuteCommand(string spQuery, object[] parameters)
        {
            int result = 0;
            try
            {
                using (context = new Customer_Entities())
                {
                    result = context.Database.SqlQuery<int>(spQuery, parameters).FirstOrDefault();
                }
            }
            catch { }
            return result;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}