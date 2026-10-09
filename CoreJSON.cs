using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FirstConsoleApp;


public class AppConfig
{
	public class ConfigOSCTarget
	{
		public string name { get; set; }
		public string ipAddress { get; set; }

		//
		public ConfigOSCTarget()
		{
			name = string.Empty;
			ipAddress = string.Empty;
		}
	}

	public string filePath { get; set; }
	public string audioPath { get; set; }
	public string messageWindow { get; set; }
	public int midiDevice { get; set; }
	public int midiChannel { get; set; }
	public int midiLightingDevice { get; set; }
	public int midiLightingChannel { get; set; }
	public List<ConfigOSCTarget> oscTargets { get; set; }
	
	//
	public AppConfig()
	{
		filePath = string.Empty;
		audioPath = string.Empty;
		messageWindow = string.Empty;

		midiDevice = 0;
		midiChannel = 0;
		midiLightingDevice = 0;
		midiLightingChannel = 0;

		oscTargets = new List<ConfigOSCTarget>();
	}
}

// JSONConfig
// rigid/structured data
public class JSONConfig<T>
{
	public T? data { get; private set; }

	public JSONConfig(string filename)
	{
		string jsonText = File.ReadAllText(filename);

		Console.WriteLine("JSONConfig() got JSON data:");
		Console.WriteLine(jsonText);

		data = JsonSerializer.Deserialize<T>(jsonText);
		if (data != null)
		{
			Console.WriteLine("JSON read successfully!");
		}
		else
		{
			Console.WriteLine("JSON failed to load...");
		}
	}
}

// JSONSettings
// fluid/dynamic data
public class JSONSettings
{
	public JsonNode? data { get; private set; }

	private string filename;

	public JSONSettings(string filename)
	{
		this.filename = filename;

		string jsonText = File.ReadAllText(filename);

		Console.WriteLine("JSONSettings() got JSON data:");
		Console.WriteLine(jsonText);

		data = JsonNode.Parse(jsonText);

		Console.WriteLine($"JSON blob: {data!.ToJsonString()}");
	}

	// write the data
	public bool Save(string? saveTo = null)
	{
		string? outfile = saveTo ?? filename ?? null;
		if (outfile != null)
		{
			var options = new JsonSerializerOptions{
				WriteIndented = true,
				IndentSize = 1,
				IndentCharacter = '\t'
			};
			string jsonText = data!.ToJsonString(options);

			Console.WriteLine($"Would write to file ${outfile}: ${jsonText}");
			// TODO: try/catch this?
			File.WriteAllText(outfile, jsonText);

			return true;
		}

		return false;
	}

	//
	public JsonNode? ValueForKey(string key)
	{
		return null;
	}

	//
	public JsonNode? ValueForKey<T>(string key)
	{
		return null;
	}
}
