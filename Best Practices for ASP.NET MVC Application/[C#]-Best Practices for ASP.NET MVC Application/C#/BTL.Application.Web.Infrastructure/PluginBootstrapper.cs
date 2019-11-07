using BTL.Infrastructure;
using BTL.Infrastructure.Plugins;

namespace BTL.Application.Web.Infrastructure
{
    public static class PluginBootstrapper
    {
        static PluginBootstrapper()
        {

        }

        public static void Initialize()
        {
            foreach (var assembly in PluginManager.Current.Modules.Values)
            {
                BoC.Web.Mvc.PrecompiledViews.ApplicationPartRegistry.Register(assembly);
            }
        }
    }
}