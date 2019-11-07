using CRUDWithWebAPI.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CRUDWithWebAPI.Helper
{
    public class NHibernateHelper
    {

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }


        private static ISessionFactory _sessionFactory;
        const string ConnectionString = @"data source=GAURAV-ARORA;initial catalog=crudwepapi;integrated security=True;";
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ServerData>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
        }
    }
}