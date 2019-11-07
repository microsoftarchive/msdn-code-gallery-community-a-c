#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using Autofac;
using Autofac.Integration.Mvc;
using BTL.Infrastructure;
using BTL.Infrastructure.Extensions;
using BTL.Infrastructure.Helpers;

#endregion

namespace BTL.Application.Web.Infrastructure
{
    public class ConfigureContainer
    {
        private readonly IContainer _container;

        public ConfigureContainer(Action<IContainer> registerResolver)
        {
            var builder = new ContainerBuilder();

            // load module in plugin folder (if have)
            foreach (var referencedPlugin in PreApplicationInit.ReferencedPlugins)
            {
                builder.RegisterAssemblyModules(referencedPlugin);
            }

            // load all modules in bin folder
            var assemblies = AssemblyHelper.GetDllsInPath(HostingEnvironment.MapPath("~/bin/"));
            foreach (var assembly in assemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.Register(c => new Logger()).As<ILogger>().InstancePerHttpRequest();
            builder.RegisterFilterProvider();

            _container = builder.Build();

            registerResolver(_container);
        }

        public IContainer GetContainerInstance()
        {
            Guard.Assert(_container == null, "IoC container is null");

            return _container;
        }

        //private static IEnumerable<Assembly> GetDllsInPath(string extensionsPath)
        //{
        //    var fileNames = Directory.GetFiles(extensionsPath, "*.dll", SearchOption.AllDirectories);

        //    return fileNames.Select(Assembly.LoadFile);

        //    // TODO: we will refactoring to use MEF here
        //    //var catalog = new DirectoryCatalog(extensionsPath);
        //    //var compositionContainer = new CompositionContainer(catalog);

        //    //var modules = compositionContainer.GetExports<IAutoScan>();
        //    //return modules.Select(m => m.GetType().Assembly).Distinct();
        //}
    }
}