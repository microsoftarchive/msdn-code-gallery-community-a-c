/*
   Copyright 2013 Christoph Gattnar

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFPlugin
{
	public class GenericMEFPluginLoader<T>
	{
		private CompositionContainer _Container;

		[ImportMany]
		public IEnumerable<T> Plugins
		{
			get;
			set;
		}

		public GenericMEFPluginLoader(string path)
		{
			DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);

			//An aggregate catalog that combines multiple catalogs
			var catalog = new AggregateCatalog(directoryCatalog);

			// Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
			_Container = new CompositionContainer(catalog);

			//Fill the imports of this object
			_Container.ComposeParts(this);
		}
	}
}
