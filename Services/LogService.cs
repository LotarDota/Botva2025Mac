using System;
using System.Collections.ObjectModel;
using Avalonia.Threading;

namespace Botva2025.Services;

public static class LogService
{
    public static ObservableCollection<string> ConsoleLines { get; } = new();
    public static ObservableCollection<string> HtmlLogLines { get; } = new();

    public static event Action<string>? OnConsoleLog;
    public static event Action<string>? OnHtmlLog;

    public static void LogConsole(string message)
    {
        string line = $"[{DateTime.Now:HH:mm:ss}] {message}";
        if (Dispatcher.UIThread.CheckAccess())
        {
            ConsoleLines.Add(line);
            TrimCollection(ConsoleLines, 500);
        }
        else
        {
            Dispatcher.UIThread.Post(() =>
            {
                ConsoleLines.Add(line);
                TrimCollection(ConsoleLines, 500);
            });
        }
        OnConsoleLog?.Invoke(line);
    }

    public static void LogHtml(string message)
    {
        string plain = System.Text.RegularExpressions.Regex.Replace(message, "<.*?>", "");
        string line = $"[{DateTime.Now:HH:mm:ss}] {plain}";
        if (Dispatcher.UIThread.CheckAccess())
        {
            HtmlLogLines.Add(line);
            TrimCollection(HtmlLogLines, 500);
        }
        else
        {
            Dispatcher.UIThread.Post(() =>
            {
                HtmlLogLines.Add(line);
                TrimCollection(HtmlLogLines, 500);
            });
        }
        OnHtmlLog?.Invoke(line);
    }

    private static void TrimCollection(ObservableCollection<string> col, int max)
    {
        while (col.Count > max)
            col.RemoveAt(0);
    }
}
