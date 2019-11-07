using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VisualPlugin.Interfaces;

namespace VisualPlugin.UI
{
	public partial class App
	{
		private static PluginLoader<IVisualPlugin> visualPluginLoader;

		public static IEnumerable<IVisualPlugin> Plugins
		{
			get { return visualPluginLoader.Plugins; }
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			visualPluginLoader = new PluginLoader<IVisualPlugin>("Plugin");
		}

		protected override void OnExit(ExitEventArgs e)
		{
			base.OnExit(e);

			visualPluginLoader.Dispose();
		}
	}
}
