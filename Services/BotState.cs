using System;
using OpenQA.Selenium;

namespace Botva2025;

/// <summary>
/// Central state holder replacing Form1._Form1 static references.
/// All business logic modules use this instead of Form1.
/// </summary>
public static class BotState
{
    public static IWebDriver? WebDriver { get; set; }
    public static bool IsPaused { get; set; } = true;
    public static bool IsRunning { get; set; }

    public static string[] UrlLogin { get; } = { "g1.", "g2.", "g3.", "turbo.", "avatar." };
}
