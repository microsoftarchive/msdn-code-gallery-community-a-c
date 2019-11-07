using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace VisualPlugin.UI
{
	public class PluginLoader<T> : IDisposable
	{
		private readonly CompositionContainer _container;

		[ImportMany]
		public IEnumerable<T> Plugins { get; set; }

		public PluginLoader(string path)
		{
			var catalog = new DirectoryCatalog(path);

			this._container = new CompositionContainer(catalog);
			this._container.ComposeParts(this);
		}

		public void Dispose()
		{
			this._container.Dispose();
		}
	}
}
