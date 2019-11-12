using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Livet;
using VisualPlugin.Interfaces;
using VisualPlugin.Sample2.ViewModels;
using VisualPlugin.Sample2.Views;

namespace VisualPlugin.Sample2
{
	[Export(typeof(IVisualPlugin))]
	public class Sample2Plugin : NotificationObject, IVisualPlugin
	{
		#region Name 変更通知プロパティ

		private string _Name;

		public string Name
		{
			get { return this._Name; }
			set
			{
				if (this._Name != value)
				{
					this._Name = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion

		#region ImagePath 変更通知プロパティ

		private string _ImagePath;

		public string ImagePath
		{
			get { return this._ImagePath; }
			set
			{
				if (this._ImagePath != value)
				{
					this._ImagePath = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public Sample2Plugin()
		{
			this.Name = "Sample 2";
		}

		public void Proc()
		{
			var window = new Sample2Window
			{
				DataContext = new Sample2WindowViewModel(this)
			};

			window.Show();
		}

		public object GetSettingsView()
		{
			return new Settings
			{
				DataContext = new SettingsViewModel(this)
			};
		}
	}
}
