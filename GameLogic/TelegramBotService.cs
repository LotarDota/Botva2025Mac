using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Botva2025;

public class TelegramBotService : IDisposable
{
	private readonly HttpClient _httpClient;

	private readonly string _botToken;

	private int _lastUpdateId;

	public TelegramBotService(string botToken)
	{
		_botToken = botToken ?? throw new ArgumentNullException("botToken");
		_httpClient = new HttpClient
		{
			BaseAddress = new Uri("https://api.telegram.org/"),
			Timeout = TimeSpan.FromSeconds(30L)
		};
	}

	public async Task<List<TelegramMessage>> GetLastMessages(int limit = 10)
	{
		List<TelegramMessage> messages = new List<TelegramMessage>();
		try
		{
			string requestUri = $"/bot{_botToken}/getUpdates?offset={_lastUpdateId + 1}&timeout=10";
			HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
			httpResponseMessage.EnsureSuccessStatusCode();
			using JsonDocument jsonDocument = JsonDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
			if (jsonDocument.RootElement.TryGetProperty("ok", out var value) && value.GetBoolean() && jsonDocument.RootElement.TryGetProperty("result", out var value2))
			{
				foreach (JsonElement item in value2.EnumerateArray())
				{
					if (!item.TryGetProperty("message", out var value3) || !value3.TryGetProperty("text", out var value4))
					{
						continue;
					}
					string text = value4.GetString();
					if (text == null || string.IsNullOrEmpty(text))
					{
						continue;
					}
					TelegramMessage telegramMessage = ParseMessage(value3);
					if (telegramMessage != null)
					{
						messages.Add(telegramMessage);
						if (item.TryGetProperty("update_id", out var value5))
						{
							_lastUpdateId = value5.GetInt32();
						}
						if (messages.Count >= limit)
						{
							break;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return messages;
	}

	private TelegramMessage ParseMessage(JsonElement messageElement)
	{
		try
		{
			TelegramMessage telegramMessage = new TelegramMessage();
			if (messageElement.TryGetProperty("message_id", out var value))
			{
				telegramMessage.MessageId = value.GetInt32();
			}
			if (messageElement.TryGetProperty("text", out var value2))
			{
				telegramMessage.Text = value2.GetString();
			}
			if (messageElement.TryGetProperty("date", out var value3))
			{
				telegramMessage.Date = DateTimeOffset.FromUnixTimeSeconds(value3.GetInt32()).DateTime;
			}
			if (messageElement.TryGetProperty("from", out var value4))
			{
				if (value4.TryGetProperty("id", out var value5))
				{
					telegramMessage.ChatId = value5.GetInt64();
				}
				if (value4.TryGetProperty("username", out var value6))
				{
					telegramMessage.Username = value6.GetString();
				}
				if (value4.TryGetProperty("first_name", out var value7))
				{
					telegramMessage.FirstName = value7.GetString();
				}
				if (value4.TryGetProperty("is_bot", out var value8))
				{
					telegramMessage.IsBot = value8.GetBoolean();
				}
			}
			if (messageElement.TryGetProperty("chat", out var value9) && value9.TryGetProperty("id", out var value10))
			{
				telegramMessage.ChatId = value10.GetInt64();
			}
			return telegramMessage;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public async Task<List<TelegramMessage>> GetMessagesFromChat(long chatId, int limit = 10)
	{
		List<TelegramMessage> messages = new List<TelegramMessage>();
		try
		{
			string requestUri = $"/bot{_botToken}/getUpdates?offset={_lastUpdateId + 1}";
			HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
			httpResponseMessage.EnsureSuccessStatusCode();
			using JsonDocument jsonDocument = JsonDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
			if (jsonDocument.RootElement.TryGetProperty("ok", out var value) && value.GetBoolean() && jsonDocument.RootElement.TryGetProperty("result", out var value2))
			{
				foreach (JsonElement item in value2.EnumerateArray())
				{
					if (!item.TryGetProperty("message", out var value3) || !value3.TryGetProperty("chat", out var value4) || !value4.TryGetProperty("id", out var value5) || value5.GetInt64() != chatId || !value3.TryGetProperty("text", out var value6))
					{
						continue;
					}
					string text = value6.GetString();
					if (text == null || string.IsNullOrEmpty(text))
					{
						continue;
					}
					TelegramMessage telegramMessage = ParseMessage(value3);
					if (telegramMessage != null)
					{
						messages.Add(telegramMessage);
						if (item.TryGetProperty("update_id", out var value7))
						{
							_lastUpdateId = value7.GetInt32();
						}
						if (messages.Count >= limit)
						{
							break;
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return messages;
	}

	public async Task<bool> SendMessage(long chatId, string text)
	{
		try
		{
			FormUrlEncodedContent content = new FormUrlEncodedContent(new KeyValuePair<string, string>[2]
			{
				new KeyValuePair<string, string>("chat_id", chatId.ToString()),
				new KeyValuePair<string, string>("text", text)
			});
			string requestUri = "/bot" + _botToken + "/sendMessage";
			return (await _httpClient.PostAsync(requestUri, content)).IsSuccessStatusCode;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<TelegramUser> GetBotInfo()
	{
		_ = 1;
		try
		{
			string requestUri = "/bot" + _botToken + "/getMe";
			HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri);
			httpResponseMessage.EnsureSuccessStatusCode();
			using JsonDocument jsonDocument = JsonDocument.Parse(await httpResponseMessage.Content.ReadAsStringAsync());
			if (jsonDocument.RootElement.TryGetProperty("ok", out var value) && value.GetBoolean() && jsonDocument.RootElement.TryGetProperty("result", out var value2))
			{
				return ParseUser(value2);
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	private TelegramUser ParseUser(JsonElement userElement)
	{
		try
		{
			TelegramUser telegramUser = new TelegramUser();
			if (userElement.TryGetProperty("id", out var value))
			{
				telegramUser.Id = value.GetInt64();
			}
			if (userElement.TryGetProperty("is_bot", out var value2))
			{
				telegramUser.IsBot = value2.GetBoolean();
			}
			if (userElement.TryGetProperty("first_name", out var value3))
			{
				telegramUser.FirstName = value3.GetString();
			}
			if (userElement.TryGetProperty("username", out var value4))
			{
				telegramUser.Username = value4.GetString();
			}
			return telegramUser;
		}
		catch (Exception)
		{
			return null;
		}
	}

	public void Dispose()
	{
		_httpClient?.Dispose();
		GC.SuppressFinalize(this);
	}
}
