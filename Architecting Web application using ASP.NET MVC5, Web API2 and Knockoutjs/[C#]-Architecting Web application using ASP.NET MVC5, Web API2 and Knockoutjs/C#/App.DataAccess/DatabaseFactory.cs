using System;
using System.Configuration;
using App.DataAccess.Interfaces;

namespace App.DataAccess
{

    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private CemexDb db;

        public CemexDb Get()
        {
            return db ?? (db = new CemexDb(ConfigurationManager.ConnectionStrings["CemexDb"].ConnectionString));
        }

        public CemexDb Create()
        {
            return new CemexDb(ConfigurationManager.ConnectionStrings["CemexDb"].ConnectionString);
        }

        protected override void DisposeCore()
        {
            if (db != null) db.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }

}