using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Botva2025.Services;

namespace Botva2025;

public static class ControlExtenstionMethods
{
    public static void TryADD<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        dictionary[key] = value;
    }

    public static void LogThread(this WebBrowser _webBrowser, string _st)
    {
        LogService.LogHtml(_st);
    }

    public static void AddTextCrossThread(this Control control, string text)
    {
        LogService.LogConsole(text);
    }
}
