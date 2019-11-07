#region

using Autofac;

#endregion

namespace BTL.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DataContextFactory>()
                .WithParameter(new NamedParameter("nameOrConnectionString", "DefaultConnection")).
                InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DataContextFactory>().GetContext()).As<DataContext>();

            builder.RegisterGeneric(typeof (Repository<>)).As(typeof (IRepository<>));
            builder.RegisterType<UnitOfWork>().AsSelf();
        }
    }
}