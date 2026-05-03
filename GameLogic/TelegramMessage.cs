using System;

namespace Botva2025;

public class TelegramMessage
{
	public int MessageId { get; set; }

	public long ChatId { get; set; }

	public string Username { get; set; }

	public string FirstName { get; set; }

	public string Text { get; set; }

	public DateTime Date { get; set; }

	public bool IsBot { get; set; }
}
