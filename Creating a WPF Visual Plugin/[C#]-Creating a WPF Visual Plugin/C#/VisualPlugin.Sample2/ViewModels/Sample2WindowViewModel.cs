using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;


namespace VisualPlugin.Sample2.ViewModels
{
	public class Sample2WindowViewModel : ViewModel
	{
		private Sample2Plugin owner;


		#region Source 変更通知プロパティ

		private Uri _Source;

		public Uri Source
		{
			get { return this._Source; }
			set
			{
				if (this._Source != value)
				{
					this._Source = value;
					this.RaisePropertyChanged();
				}
			}
		}

		#endregion


		public Sample2WindowViewModel(Sample2Plugin owner)
		{
			this.owner = owner;

			this.CompositeDisposable.Add(new PropertyChangedEventListener(owner)
			{
				{ "ImagePath", (sender, args) => {}}
			});

			this.UpdateSource();
		}

		public void Initialize()
		{
		}

		private void UpdateSource()
		{
			Uri uri;
			if (Uri.TryCreate(owner.ImagePath, UriKind.RelativeOrAbsolute, out uri))
			{
				this.Source = uri;
			}
		}
	}
}
