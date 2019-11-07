using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using VisualPlugin.Interfaces;

namespace VisualPlugin.UI.ViewModels
{
	public class PluginViewModel : ViewModel
	{
		private object _settingsView;

		public IVisualPlugin Plugin { get; private set; }

		public object SettingsView
		{
			get { return this._settingsView ?? (this._settingsView = this.Plugin.GetSettingsView()); }
		}

		public PluginViewModel(IVisualPlugin plugin)
		{
			this.Plugin = plugin;
		}
	}
}
