using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Livet;

namespace VisualPlugin.UI.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		#region Plugins 変更通知プロパティ

		private ObservableCollection<PluginViewModel> _Plugins;

		public ObservableCollection<PluginViewModel> Plugins
		{
			get { return this._Plugins; }
			set
			{
				if (this._Plugins != value)
				{
					this._Plugins = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public MainWindowViewModel()
		{
			this.Plugins = new ObservableCollection<PluginViewModel>(App.Plugins.Select(x => new PluginViewModel(x)));
		}
	}
}
