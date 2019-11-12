#region

using Autofac;
using BTL.Infrastructure.Cache;
using BTL.Infrastructure.Cache.CouchBase;
using BTL.Infrastructure.Configuration;
using BTL.Infrastructure.Encryptions;
using Couchbase;

#endregion

namespace BTL.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterType<MemcachedClient>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<ExEnyimMemCached>().As<IExCache>().InstancePerDependency();

            builder.RegisterType<CouchbaseClient>().AsSelf().SingleInstance();
            builder.RegisterType<ExCouchbaseMemCached>().As<IExCache>().SingleInstance();
            builder.RegisterType<CacheProvider>().As<ICacheProvider>().SingleInstance();
            builder.RegisterType<ExConfigurationManager>().As<IExConfigurationManager>().SingleInstance();
            builder.RegisterType<Encryptor>().As<IEncryptor>().SingleInstance();
        }
    }
}