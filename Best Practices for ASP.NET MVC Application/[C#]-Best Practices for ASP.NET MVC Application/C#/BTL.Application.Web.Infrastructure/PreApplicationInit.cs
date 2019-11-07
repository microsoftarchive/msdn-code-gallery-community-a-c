#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using BTL.Application.Web.Infrastructure;
using BTL.Infrastructure;
using BTL.Infrastructure.Plugins;

#endregion

[assembly: PreApplicationStartMethod(typeof (PreApplicationInit), "Initialize")]

namespace BTL.Application.Web.Infrastructure
{
    public class PreApplicationInit
    {
        private static DirectoryInfo _tempCopyFolder;
        public static IEnumerable<Assembly> ReferencedPlugins { get; private set; }

        public static void Initialize()
        {
            // prevent app from starting altogether
            var pluginFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/Plugins"));
            _tempCopyFolder = new DirectoryInfo(HostingEnvironment.MapPath("~/Plugins/Temp"));

            var referencedPlugins = new List<Assembly>();

            var pluginFiles = Enumerable.Empty<FileInfo>();

            try
            {
                //ensure folders are created
                Directory.CreateDirectory(pluginFolder.FullName);
                Directory.CreateDirectory(_tempCopyFolder.FullName);

                //get list of all DLLs in bin
                foreach (var tempFile in _tempCopyFolder.GetFiles("*.*", SearchOption.AllDirectories))
                {
                    // make sure we not got exeption
                    try
                    {
                        tempFile.Delete();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                //copy files to temp folder
                foreach (var plug in pluginFolder.GetFiles("*.dll", SearchOption.AllDirectories))
                {
                    try
                    {
                        var di = Directory.CreateDirectory(_tempCopyFolder.FullName);
                        File.Copy(plug.FullName, Path.Combine(di.FullName, plug.Name), true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                var fail = new ApplicationException("Could not initialise plugin folder", ex);
                throw fail;
            }

            try
            {
                //get list of all DLLs in plugins (not in bin!)
                pluginFiles = _tempCopyFolder.GetFiles("*.dll", SearchOption.AllDirectories);
                //shadow copy files
                referencedPlugins.AddRange(pluginFiles.Select(PerformFileDeploy));
            }
            catch (Exception ex)
            {
                var fail = new ApplicationException("Could not initialise plugin folder", ex);
                throw fail;
            }

            // add to Plugin Manager
            foreach (var assembly in referencedPlugins.Where(a => a.FullName.ToLower().Contains("btl")))
            {
                var type = assembly.GetTypes().FirstOrDefault(
                    t => t.GetInterface(typeof (IModule).Name) != null
                         && IsAssembliesLoading(assembly));
                if (type == null) continue;

                //Add the modules to the PluginManager to manage them later
                if (!typeof (IModule).IsAssignableFrom(type)) continue;

                var module = (IModule) Activator.CreateInstance(type);

                if (!PluginManager.Current.Modules.ContainsKey(module))
                    PluginManager.Current.Modules.Add(module, assembly);
            }

            ReferencedPlugins = referencedPlugins;
        }

        private static bool IsAssembliesLoading(Assembly assembly)
        {
            return !assembly.FullName.ToLower().Contains("autofac")
                && !assembly.FullName.ToLower().Contains("membase");
        }

        private static Assembly PerformFileDeploy(FileInfo plug)
        {
            if (plug.Directory.Parent == null)
                throw new InvalidOperationException("The plugin directory for the " + plug.Name +
                                                    " file exists in a folder outside of the allowed Umbraco folder heirarchy");

            FileInfo shadowCopiedPlug;

            if (SystemUtilities.GetCurrentTrustLevel() != AspNetHostingPermissionLevel.Unrestricted)
            {
                //all plugins will need to be copied to ~/Plugins OR ~/Plugins/Temp
                //this is aboslutely required because all of this relies on probingPaths being set statically in the web.config
                var shadowCopyPlugFolderName = plug.Directory.Parent.Name == "Plugins"
                                                   ? "Plugins"
                                                   : "Temp";

                //were running in med trust, so copy to custom bin folder
                var shadowCopyPlugFolder =
                    Directory.CreateDirectory(Path.Combine(_tempCopyFolder.FullName, shadowCopyPlugFolderName));
                shadowCopiedPlug = InitializeMediumTrust(plug, shadowCopyPlugFolder);
            }
            else
            {
                //were running in full trust so copy to standard dynamic folder
                shadowCopiedPlug = InitializeFullTrust(plug, new DirectoryInfo(AppDomain.CurrentDomain.DynamicDirectory));
            }

            //we can now register the plugin definition
            var shadowCopiedAssembly = Assembly.Load(AssemblyName.GetAssemblyName(shadowCopiedPlug.FullName));

            //add the reference to the build manager
            BuildManager.AddReferencedAssembly(shadowCopiedAssembly);

            return shadowCopiedAssembly;
        }

        private static FileInfo InitializeFullTrust(FileInfo plug, DirectoryInfo shadowCopyPlugFolder)
        {
            var shadowCopiedPlug = new FileInfo(Path.Combine(shadowCopyPlugFolder.FullName, plug.Name));
            try
            {
                File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
            }
            catch (IOException)
            {
                //this occurs when the files are locked,
                //for some reason devenv locks plugin files some times and for another crazy reason you are allowed to rename them
                //which releases the lock, so that it what we are doing here, once it's renamed, we can re-shadow copy
                try
                {
                    var oldFile = shadowCopiedPlug.FullName + Guid.NewGuid().ToString("N") + ".old";
                    File.Move(shadowCopiedPlug.FullName, oldFile);
                }
                catch (IOException)
                {
                    throw;
                }
                //ok, we've made it this far, now retry the shadow copy
                File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
            }
            return shadowCopiedPlug;
        }

        private static FileInfo InitializeMediumTrust(FileInfo plug, DirectoryInfo shadowCopyPlugFolder)
        {
            var shouldCopy = true;
            var shadowCopiedPlug = new FileInfo(Path.Combine(shadowCopyPlugFolder.FullName, plug.Name));

            //check if a shadow copied file already exists and if it does, check if its updated, if not don't copy
            if (shadowCopiedPlug.Exists)
            {
                if (shadowCopiedPlug.CreationTimeUtc.Ticks == plug.CreationTimeUtc.Ticks)
                {
                    shouldCopy = false;
                }
            }

            if (shouldCopy)
            {
                try
                {
                    File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
                }
                catch (IOException)
                {
                    //this occurs when the files are locked,
                    //for some reason devenv locks plugin files some times and for another crazy reason you are allowed to rename them
                    //which releases the lock, so that it what we are doing here, once it's renamed, we can re-shadow copy
                    try
                    {
                        var oldFile = shadowCopiedPlug.FullName + Guid.NewGuid().ToString("N") + ".old";
                        File.Move(shadowCopiedPlug.FullName, oldFile);
                    }
                    catch (IOException)
                    {
                        throw;
                    }
                    //ok, we've made it this far, now retry the shadow copy
                    File.Copy(plug.FullName, shadowCopiedPlug.FullName, true);
                }
            }

            return shadowCopiedPlug;
        }
    }

    public static class SystemUtilities
    {
        public static AspNetHostingPermissionLevel GetCurrentTrustLevel()
        {
            foreach (var trustLevel in new[]
                                           {
                                               AspNetHostingPermissionLevel.Unrestricted,
                                               AspNetHostingPermissionLevel.High,
                                               AspNetHostingPermissionLevel.Medium,
                                               AspNetHostingPermissionLevel.Low,
                                               AspNetHostingPermissionLevel.Minimal
                                           })
            {
                try
                {
                    new AspNetHostingPermission(trustLevel).Demand();
                }
                catch (SecurityException)
                {
                    continue;
                }

                return trustLevel;
            }

            return AspNetHostingPermissionLevel.None;
        }
    }
}