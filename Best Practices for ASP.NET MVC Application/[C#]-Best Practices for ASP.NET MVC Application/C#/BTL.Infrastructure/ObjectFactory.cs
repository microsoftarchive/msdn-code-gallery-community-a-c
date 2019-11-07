#region

using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Integration.Web;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Infrastructure
{
    public class ObjectFactory
    {
        private static ContainerProvider _containerProvider;

        // prevent initialized twice times
        private ObjectFactory()
        {
        }

        public static void SetLifetimeScope(IContainer container)
        {
            _containerProvider = new ContainerProvider(container);
        }

        public static T GetType<T>()
        {
            T instance;

            _containerProvider.ApplicationContainer.TryResolve(out instance);

            return instance;
        }

        public static object GetType(Type type)
        {
            return _containerProvider.ApplicationContainer.TryResolve(out type);
        }

        public static IEnumerable<T> GetTypes<T>()
        {
            return _containerProvider.ApplicationContainer.ResolveAll<T>();
        }
    }
}