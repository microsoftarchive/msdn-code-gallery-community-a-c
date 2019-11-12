#region

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

#endregion

namespace BTL.Infrastructure.Extensions
{
    public static class ContainerExtension
    {
        public static void RegisterAssemblyModules(this ContainerBuilder builder, Assembly assembly)
        {
            var scanningBuilder = new ContainerBuilder();

            scanningBuilder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof (IModule).IsAssignableFrom(t) && t.FullName.ToLower().Contains("btl"))
                .As<IModule>();

            using (var scanningContainer = scanningBuilder.Build())
            {
                foreach (var module in scanningContainer.Resolve<IEnumerable<IModule>>())
                    builder.RegisterModule(module);
            }
        }

        /// <summary>
        /// http://stackoverflow.com/questions/4959148/is-it-possible-in-autofac-to-resolve-all-services-for-a-type-even-if-they-were
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IEnumerable<T> ResolveAll<T>(this IContainer container)
        {
            // We're going to find each service which was registered
            // with a key, and for those which match the type T we'll store the key
            // and later supplement the default output with individual resolve calls to those
            // keyed services
            var allKeys = new List<object>();
            foreach (var componentRegistration in container.ComponentRegistry.Registrations)
            {
                // Get the services which match the KeyedService type
                var typedServices = componentRegistration.Services.Where(x => x is KeyedService).Cast<KeyedService>();
                // Add the key to our list so long as the registration is for the correct type T
                allKeys.AddRange(typedServices.Where(y => y.ServiceType == typeof(T)).Select(x => x.ServiceKey));
            }

            // Get the default resolution output which resolves all un-keyed services
            var allUnKeyedServices = new List<T>(container.Resolve<IEnumerable<T>>());
            // Add the ones which were registered with a key
            allUnKeyedServices.AddRange(allKeys.Select(key => container.ResolveKeyed<T>(key)));

            // Return the total resultset
            return allUnKeyedServices;
        }
    }
}