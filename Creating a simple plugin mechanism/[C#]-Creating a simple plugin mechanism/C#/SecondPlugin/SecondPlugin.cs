using PluginContracts;

namespace SecondPlugin
{
	public class SecondPlugin : IPlugin
	{
		#region IPlugin Members

		public string Name
		{
			get
			{
				return "Second Plugin";
			}
		}

		public void Do()
		{
			System.Windows.MessageBox.Show("Do Something in Second Plugin");
		}

		#endregion
	}
}
