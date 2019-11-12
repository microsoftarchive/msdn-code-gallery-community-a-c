using PluginContracts;

namespace FirstPlugin
{
	public class FirstPlugin : IPlugin
	{
		#region IPlugin Members

		public string Name
		{
			get
			{
				return "First Plugin";
			}
		}

		public void Do()
		{
			System.Windows.MessageBox.Show("Do Something in First Plugin");
		}

		#endregion
	}
}
