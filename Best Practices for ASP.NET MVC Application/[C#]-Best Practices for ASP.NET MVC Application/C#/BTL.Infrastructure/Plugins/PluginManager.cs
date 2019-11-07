#region

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace BTL.Infrastructure.Plugins
{
    public class PluginManager
    {
        private static PluginManager _current;

        public PluginManager()
        {
            Modules = new Dictionary<IModule, Assembly>();
        }

        public static PluginManager Current
        {
            get { return _current ?? (_current = new PluginManager()); }
        }

        public Dictionary<IModule, Assembly> Modules { get; set; }

        public IEnumerable<IModule> GetModules()
        {
            return Modules.Select(m => m.Key).ToList();
        }

        public IModule GetModule(string name)
        {
            return GetModules().FirstOrDefault(m => m.Name == name);
        }
    }
}