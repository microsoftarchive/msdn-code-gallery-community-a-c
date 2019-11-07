using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Livet;
using VisualPlugin.Interfaces;

namespace VisualPlugin.Sample1
{
	[Export(typeof(IVisualPlugin))]
	public class Sample1Plugin : NotificationObject, IVisualPlugin
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

		public string Message { get; set; }


		public Sample1Plugin()
		{
			this.Name = "Sample 1";
			this.Message = "Hello world!";
		}

		public void Proc()
		{
			MessageBox.Show(this.Message, this.Name);
		}

		public object GetSettingsView()
		{
			return new Settings
			{
				DataContext = this
			};
		}
	}
}
