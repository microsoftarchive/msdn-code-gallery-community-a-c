using App.DataAccess.Interfaces;

namespace App.DataAccess
{

    public abstract class RepositoryBase
    {
        private CemexDb cemexDb;

        public RepositoryBase(IDatabaseFactory DbFactory)
        {
            DatabaseFactory = DbFactory;
        }

        public RepositoryBase()
        {
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected CemexDb CemexDb
        {
            get { return cemexDb ?? (cemexDb = DatabaseFactory.Get()); }
        }
    }

}