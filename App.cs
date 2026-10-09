// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Text.Json.Nodes;
using FirstConsoleApp;

class App
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		JSONConfig<AppConfig> config = new JSONConfig<AppConfig>("../../../config.json");
		if (config != null)
		{
			Console.WriteLine($"OSCTargets: {config.data?.oscTargets.Count}");
		}

		JSONSettings settings = new JSONSettings("../../../settings.json");
		settings.Save();
	}
}
