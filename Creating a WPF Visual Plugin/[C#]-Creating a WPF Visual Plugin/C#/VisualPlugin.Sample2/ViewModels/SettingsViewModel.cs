using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using Livet.Messaging.IO;

namespace VisualPlugin.Sample2.ViewModels
{
	public class SettingsViewModel : ViewModel
	{
		public Sample2Plugin Plugin { get; private set; }

		public SettingsViewModel(Sample2Plugin owner)
		{
			this.Plugin = owner;
		}

		public void FileDialogCallback(OpeningFileSelectionMessage message)
		{
			if (message.Response != null && message.Response.Length > 0)
			{
				this.Plugin.ImagePath = message.Response[0];
			}
		}
	}
}
