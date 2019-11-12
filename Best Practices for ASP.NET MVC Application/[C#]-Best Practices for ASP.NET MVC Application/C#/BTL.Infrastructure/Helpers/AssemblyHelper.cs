using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BTL.Infrastructure.Helpers
{
    public class AssemblyHelper
    {
        public static IEnumerable<Assembly> GetDllsInPath(string extensionsPath)
        {
            var fileNames = Directory.GetFiles(extensionsPath, "*.dll", SearchOption.AllDirectories);

            return fileNames.Select(Assembly.LoadFile);

            // TODO: we will refactoring to use MEF here
            //var catalog = new DirectoryCatalog(extensionsPath);
            //var compositionContainer = new CompositionContainer(catalog);

            //var modules = compositionContainer.GetExports<IAutoScan>();
            //return modules.Select(m => m.GetType().Assembly).Distinct();
        } 
    }
}