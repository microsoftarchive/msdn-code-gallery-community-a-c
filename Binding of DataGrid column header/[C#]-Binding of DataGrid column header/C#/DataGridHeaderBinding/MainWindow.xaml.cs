using System.Collections.Generic;
using System.Windows;

namespace DataGridHeaderBinding
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Data data = new Data();
			data.HeaderNameText = "Header2";
			data.Items = new List<string>() { "Item1", "Item2" };

			this.DataContext = data;
		}
	}
}
