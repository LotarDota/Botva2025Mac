using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Timers;

namespace Botva2025;

public static class AppSettings
{
	private static Dictionary<string, object> _settings;

	private static string _configPath;

	private static Timer _saveTimer;

	private static readonly object _lockObject;

	static AppSettings()
	{
		_lockObject = new object();
		_configPath = Path.Combine(AppContext.BaseDirectory, "Config.json");
		_saveTimer = new Timer(2000.0);
		_saveTimer.AutoReset = false;
		_saveTimer.Elapsed += SaveTimerElapsed;
		LoadSettings();
	}

	public static void SaveSettings()
	{
		lock (_lockObject)
		{
			_saveTimer.Stop();
			_saveTimer.Start();
		}
	}

	public static void LoadSettings()
	{
		try
		{
			if (File.Exists(_configPath))
			{
				string json = File.ReadAllText(_configPath);
				_settings = JsonSerializer.Deserialize<Dictionary<string, object>>(json) ?? new Dictionary<string, object>();
			}
			else
			{
				_settings = new Dictionary<string, object>();
				File.WriteAllText(_configPath, "{}");
			}
		}
		catch (Exception)
		{
			_settings = new Dictionary<string, object>();
		}
	}

	private static void SaveTimerElapsed(object sender, ElapsedEventArgs e)
	{
		try
		{
			string contents = JsonSerializer.Serialize(_settings, new JsonSerializerOptions
			{
				WriteIndented = true
			});
			File.WriteAllText(_configPath, contents);
		}
		catch (Exception)
		{
		}
	}

	public static T Get<T>(string key, T defaultValue = default(T))
	{
		if (key != null && _settings.ContainsKey(key))
		{
			try
			{
				object obj = _settings[key];
				if (typeof(T) == typeof(DateTime))
				{
					if (obj is DateTime dateTime)
					{
						return (T)(object)dateTime;
					}
					if (obj is string s && DateTime.TryParse(s, out var result))
					{
						return (T)(object)result;
					}
					if (obj is JsonElement jsonElement)
					{
						string s2 = jsonElement.GetRawText().Trim('"');
						if (DateTime.TryParse(s2, out var result2))
						{
							return (T)(object)result2;
						}
					}
				}
				if (obj is JsonElement jsonElement2)
				{
					return JsonSerializer.Deserialize<T>(jsonElement2.GetRawText());
				}
				return (T)Convert.ChangeType(obj, typeof(T));
			}
			catch
			{
				return defaultValue;
			}
		}
		return defaultValue;
	}

	public static void Set(string key, object value)
	{
		_settings[key] = value;
		SaveSettings();
	}

	public static bool ContainsKey(string key)
	{
		return FindKeyIgnoreCase(key) != null;
	}

	private static string FindKeyIgnoreCase(string key)
	{
		foreach (string key2 in _settings.Keys)
		{
			if (string.Equals(key2, key, StringComparison.OrdinalIgnoreCase))
			{
				return key2;
			}
		}
		return null;
	}

	public static void PrintAllSettings()
	{
		foreach (KeyValuePair<string, object> setting in _settings)
		{
		}
	}
}
