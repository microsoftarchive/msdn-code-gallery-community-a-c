namespace PluginContracts
{
	public interface IPlugin
	{
		string Name { get; }
		void Do();
	}
}
