using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualPlugin.Interfaces
{
	public interface IVisualPlugin : INotifyPropertyChanged
	{
		string Name { get; }

		void Proc();

		object GetSettingsView();
	}
}
