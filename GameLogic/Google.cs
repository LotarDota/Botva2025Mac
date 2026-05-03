using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Botva2025.Services;
using OpenQA.Selenium;

namespace Botva2025;

public class Google
{
	private const string spreadsheetId = "1tRhZ2V0RUafePgBOiGcxOk8ZHND8gS_SJgbgaTpKxBU";

	private const string apiKey = "AIzaSyA7E9T6FyaEOWSP4GhLDX5c-0a5xxDhCzI";

	private const string FormUrl = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScVFqXMkrk-I668DDbJzivzx3JZl9XBWmvVsDFF7rr_uHmnew/formResponse";

	private static System.Timers.Timer _timer;

	private static DateTime _endTime;

	private static readonly HttpClient client = new HttpClient();

	private static DateTime DateTimeGoogle = DateTime.Now;

	private static bool boolFlag = false;

	public static async Task SendToGoogleSheetsBBZ(string st)
	{
		string requestUri = "https://script.google.com/macros/s/AKfycbx6fEwQ0A6ZqUOjP0sdQvs9qM1WKOvqi-W8cuZhfoe4EfQB7GAKytb4iuP0-Qi9dFPz/exec";
		string botToken = "8102163053:AAEwe-6qpU0E27lWOJeCnQOPSjQ5hk-avGc";
		string chatId = "-1001603664340";
		using HttpClient client = new HttpClient();
		var value = new
		{
			Date = st,
			BotToken = botToken,
			ChatId = chatId
		};
		string content = JsonSerializer.Serialize(value);
		StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
		try
		{
			HttpResponseMessage response = await client.PostAsync(requestUri, content2);
			await response.Content.ReadAsStringAsync();
			_ = response.IsSuccessStatusCode;
		}
		catch (Exception)
		{
		}
	}

	public static async Task GoogleVhodDostup()
	{
		string requestUri = "https://script.google.com/macros/s/AKfycbz04orJRUJJg50E8vaKcbJbBGDMbjbmvfRVkuJXPzOvqpSUutUDvSYwZY39BmvVA7T0EQ/exec";
		string id = UniqueHardwareIDv1();
		string text = AppSettings.Get("userName", "");
		string text2 = AppSettings.Get("userPass", "");
		string id2 = HardwareInfo.Encrypt(text2, text);
		string version = FileVersion();
		string nik = BotState.WebDriver.nikName();
		using HttpClient client = new HttpClient();
		var value = new
		{
			Id = id,
			Name = text,
			Id1 = id2,
			Version = version,
			Nik = nik
		};
		string content = JsonSerializer.Serialize(value);
		StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
		try
		{
			HttpResponseMessage response = await client.PostAsync(requestUri, content2);
			string json = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				Dictionary<string, JsonElement> dictionary = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
				if (dictionary != null && dictionary.ContainsKey("status"))
				{
					string text3 = dictionary["status"].ToString();
					if (text3 == "success" && dictionary.ContainsKey("data"))
					{
						string s = dictionary["data"].ToString();
						DateTime dateTime = DateTime.Parse(s);
						AppSettings.Set("dateTimeKey", dateTime);
					}
					else
					{
						string st = (dictionary.ContainsKey("message") ? dictionary["message"].ToString() : "Неизвестная ошибка");
						Find.WebBrowserLog(st);
					}
				}
				else
				{
					string st2 = (dictionary.ContainsKey("message") ? dictionary["message"].ToString() : "Неизвестная ошибка");
					Find.WebBrowserLog(st2);
				}
			}
			else
			{
				Find.WebBrowserLog("HTTP ошибка: " + response.StatusCode);
			}
		}
		catch (Exception)
		{
		}
	}

	public static async Task MainGoogleAsync(IWebDriver _driver)
	{
		while (true)
		{
			string text = AppSettings.Get("userName", "");
			string text2 = _driver.nikName();
			string value = (string.IsNullOrEmpty(text) ? text2 : text);
			if (!string.IsNullOrEmpty(value))
			{
				break;
			}
			await Task.Delay(TimeSpan.FromMinutes(1L));
		}
		await GoogleVhodDostup();
		StartCountdown(AppSettings.Get("dateTimeKey", DateTime.MinValue));
	}

	public static async Task MainGoogleAsync(string login)
	{
		if (!boolFlag && !(DateTimeGoogle < DateTime.Now))
		{
			DateTimeGoogle = DateTime.Now.AddMinutes(15.0);
			await VhodGoogleGPT(login);
			await DostupAsync(login);
			StartCountdown(AppSettings.Get("dateTimeKey", DateTime.MinValue));
			boolFlag = true;
		}
	}

	public static void StartCountdown(DateTime endTime)
	{
		if (endTime < DateTime.Now)
		{
			endTime = DateTime.Now.AddMinutes(10.0);
		}
		_endTime = endTime;
		_timer = new System.Timers.Timer(1000.0);
		_timer.Elapsed += OnTimerElapsed;
		_timer.Start();
	}

	private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
	{
		TimeSpan timeSpan = _endTime - DateTime.Now;
		if (timeSpan <= TimeSpan.Zero)
		{
			_timer.Stop();
			UpdateLabel("Время вышло!");
			Task task = Task.Run(delegate
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				DialogResult result = (DialogResult)0;
				Thread thread = new Thread((ThreadStart)delegate
				{
					//IL_000e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0013: Unknown result type (might be due to invalid IL or missing references)
					result = MessageBox.Show("Время вышло, бот закрывается", "Таймаут", (MessageBoxButtons)0, (MessageBoxIcon)48);
				});
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
				if (!thread.Join(5000))
				{
					try
					{
						_ = thread.IsAlive;
					}
					catch
					{
					}
				}
				Application.Exit();
			});
			return;
		}
		string text = ((timeSpan.Days > 0) ? $"{timeSpan.Days}.{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}" : $"{timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}");
		if (timeSpan.Days < 2)
		{
			UpdateLabel(text);
		}
		UpdateTool(text);
	}

	private static void UpdateTool(string text)
	{
		Button buttonBrauzer = (Application.OpenForms[0] as Form1)?.buttonBrauzer;
		if (buttonBrauzer == null)
		{
			return;
		}
		if (((Control)buttonBrauzer).InvokeRequired)
		{
			((Control)buttonBrauzer).Invoke((Action)delegate
			{
				Form1 obj2 = Application.OpenForms[0] as Form1;
				if (obj2 != null)
				{
					obj2.toolTip1.SetToolTip((Control)(object)buttonBrauzer, text);
				}
			});
		}
		else
		{
			Form1 obj = Application.OpenForms[0] as Form1;
			if (obj != null)
			{
				obj.toolTip1.SetToolTip((Control)(object)buttonBrauzer, text);
			}
		}
	}

	private static void UpdateLabel(string text)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		Button buttonBrauzer = (Application.OpenForms[0] as Form1)?.buttonBrauzer;
		if (buttonBrauzer == null)
		{
			return;
		}
		if (((Control)buttonBrauzer).InvokeRequired)
		{
			((Control)buttonBrauzer).Invoke((Delegate)(System.Windows.Forms.MethodInvoker)delegate
			{
				((Control)buttonBrauzer).Text = text;
			});
		}
		else
		{
			((Control)buttonBrauzer).Text = text;
		}
	}

	public static async Task VhodGoogleGPT(string login)
	{
		string text = AppSettings.Get("userPass", "");
		string bHash = HardwareInfo.Encrypt(text, login);
		string input;
		try
		{
			input = await client.GetStringAsync("https://docs.google.com/forms/u/0/d/e/1FAIpQLScVFqXMkrk-I668DDbJzivzx3JZl9XBWmvVsDFF7rr_uHmnew/formResponse");
		}
		catch (HttpRequestException)
		{
			return;
		}
		MatchCollection matchCollection = Regex.Matches(input, "\\[\\[(\\d+),null");
		if (matchCollection.Count < 5)
		{
			return;
		}
		string[,] array = new string[5, 2]
		{
			{
				"entry." + matchCollection[0].Groups[1].Value,
				UniqueHardwareIDv1()
			},
			{
				"entry." + matchCollection[1].Groups[1].Value,
				login
			},
			{
				"entry." + matchCollection[2].Groups[1].Value,
				bHash
			},
			{
				"entry." + matchCollection[3].Groups[1].Value,
				NowCalc()
			},
			{
				"entry." + matchCollection[4].Groups[1].Value,
				FileVersion()
			}
		};
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.GetLength(0); i++)
		{
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(2, 2, stringBuilder2);
			handler.AppendFormatted(Uri.EscapeDataString(array[i, 0]));
			handler.AppendLiteral("=");
			handler.AppendFormatted(Uri.EscapeDataString(array[i, 1]));
			handler.AppendLiteral("&");
			stringBuilder2.Append(ref handler);
		}
		try
		{
			StringContent content = new StringContent(stringBuilder.ToString().TrimEnd('&'), Encoding.UTF8, "application/x-www-form-urlencoded");
			HttpResponseMessage httpResponseMessage = await client.PostAsync("https://docs.google.com/forms/u/0/d/e/1FAIpQLScVFqXMkrk-I668DDbJzivzx3JZl9XBWmvVsDFF7rr_uHmnew/formResponse", content);
			httpResponseMessage.EnsureSuccessStatusCode();
			await httpResponseMessage.Content.ReadAsStringAsync();
		}
		catch (HttpRequestException)
		{
		}
	}

	public static async Task DostupAsync(string login)
	{
		string value = "Dostup";
		string uniqueHardwareIDv1 = UniqueHardwareIDv1();
		string requestUri = $"https://sheets.googleapis.com/v4/spreadsheets/{"1tRhZ2V0RUafePgBOiGcxOk8ZHND8gS_SJgbgaTpKxBU"}/values/{value}?key={"AIzaSyA7E9T6FyaEOWSP4GhLDX5c-0a5xxDhCzI"}";
		CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30L));
		try
		{
			HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUri, cancellationTokenSource.Token);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				string text = await httpResponseMessage.Content.ReadAsStringAsync();
				if (text.Contains("\"values\":"))
				{
					string text2 = text.Substring(text.IndexOf("\"values\":") + 9);
					text2 = text2.TrimStart(new char[4] { ' ', '{', '[', '"' });
					text2 = text2.TrimEnd(new char[3] { '}', ']', '"' });
					string[] array = text2.Split(new string[1] { "],[" }, StringSplitOptions.None);
					string[] array2 = array;
					foreach (string text3 in array2)
					{
						string[] array3 = text3.Trim(new char[3] { '[', ']', '"' }).Split(new char[1] { ',' }, StringSplitOptions.None);
						string text4 = string.Join(", ", array3);
						if ((text4.Contains(uniqueHardwareIDv1) || text4.Contains(login)) && DateTime.TryParseExact(array3[4].Trim('"'), "dd.MM.yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out var result) && result > DateTime.Now)
						{
							AppSettings.Set("dateTimeKey", result);
							return;
						}
					}
				}
			}
		}
		catch (TaskCanceledException) when (cancellationTokenSource.Token.IsCancellationRequested)
		{
		}
		catch (TaskCanceledException)
		{
		}
		catch (HttpRequestException)
		{
		}
		AppSettings.Set("dateTimeKey", DateTime.Now.AddMinutes(45.0));
	}

	private static string UniqueHardwareIDv1()
	{
		return HardwareInfo.UniqueHardwareIDv2();
	}

	private static string NowCalc()
	{
		return DateTime.Now.ToString();
	}

	private static string FileVersion()
	{
		return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0.0";
	}
}
