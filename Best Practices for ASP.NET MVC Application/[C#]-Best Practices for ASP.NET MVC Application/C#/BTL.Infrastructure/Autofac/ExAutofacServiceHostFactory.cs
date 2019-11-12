#region

using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;

#endregion

namespace BTL.Infrastructure.Autofac
{
    public class ExAutofacServiceHostFactory : AutofacServiceHostFactory
    {
        private readonly ContainerBuilder _containerBuilder;
        private readonly Action<ContainerBuilder> _initializeAction;

        public ExAutofacServiceHostFactory(Action<ContainerBuilder> initializeAction)
            : this(initializeAction, new ContainerBuilder())
        {
        }

        public ExAutofacServiceHostFactory(
            Action<ContainerBuilder> initializeAction,
            ContainerBuilder containerBuilder)
        {
            _initializeAction = initializeAction;
            _containerBuilder = containerBuilder;
        }

        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            Guard.MakeSureAllInstancesIsNullNot(_initializeAction);

            _initializeAction(_containerBuilder);

            var container = _containerBuilder.Build();
            Container = container;
            ObjectFactory.SetLifetimeScope(container);

            return base.CreateServiceHost(constructorString, baseAddresses);
        }
    }
}