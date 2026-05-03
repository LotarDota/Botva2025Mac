using System;
using System.IO;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V143.Network;

namespace Botva2025;

public static class WebCrome
{
    public static IWebDriver? Driver { get; private set; }

    public static void BrauzerVisibleNew()
    {
        try
        {
            var webCrom = BotState.WebDriver;
            if (webCrom == null) return;
            // Cross-platform: just ensure window is not minimized
            var window = webCrom.Manage().Window;
            // No P/Invoke on macOS, just set a reasonable size
        }
        catch { }
    }

    public static IWebDriver? InitializeBrowser()
    {
        string[] servers = { "g1.", "g2.", "g3.", "turbo.", "avatar." };
        var chromeOptions = new ChromeOptions();
        var chromeDriverService = ChromeDriverService.CreateDefaultService();
        string server = servers[AppSettings.Get("userServer", 0)];

        chromeDriverService.HideCommandPromptWindow = true;
        chromeOptions.AddArgument("--log-level=3");
        chromeOptions.AddExcludedArgument("enable-automation");
        chromeOptions.AddArgument("--disable-popup-blocking");
        chromeOptions.AddArgument("--disable-notifications");
        chromeOptions.AddUserProfilePreference("safebrowsing.enabled", false);
        chromeOptions.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
        chromeOptions.AddUserProfilePreference("password_manager_leak_detection", false);
        chromeOptions.AddArgument("--password-store=basic");
        chromeOptions.AddArgument("--disable-features=PasswordLeakDetection");
        chromeOptions.AddArgument("--no-sandbox");
        chromeOptions.AddArgument("--disable-dev-shm-usage");
        chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
        chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
        chromeOptions.AddArguments("--disable-extensions", "--disable-popup-blocking", "--disable-notifications");
        chromeOptions.AddArguments("--disable-background-timer-throttling");
        chromeOptions.AddArguments("--disable-backgrounding-occluded-windows");
        chromeOptions.AddArguments("--disable-renderer-backgrounding");

        // Cross-platform Chrome profile path
        string profileDir = GetChromeProfilePath(AppSettings.Get("userName", ""));
        chromeOptions.AddArgument($"user-data-dir={profileDir}");
        chromeOptions.AddArgument($"--app=https://{server}botva.ru/");
        chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
        chromeOptions.AddUserProfilePreference("credentials_enable_service", false);

        Driver = null;
        try
        {
            Driver = new ChromeDriver(chromeDriverService, chromeOptions);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);

            var devToolsSession = ((ChromeDriver)Driver).GetDevToolsSession();
            devToolsSession.SendCommand(new EnableCommandSettings());

            string[] urls = {
                "https://vk.com", "https://analytics.google.com", "https://mc.yandex.ru",
                "https://www.googletagmanager.com", "https://stat.clickfrog.ru",
                "https://www.google-analytics.com", "https://td.doubleclick.net",
                "https://battle.botva.ru/wsproxy", "https://counter.yadro.ru"
            };
            devToolsSession.SendCommand(new SetBlockedURLsCommandSettings { Urls = urls });
            return Driver;
        }
        catch (Exception ex)
        {
            Services.LogService.LogConsole($"Ошибка WebDriver: {ex.Message}");
            Services.LogService.LogConsole("Попробуйте закрыть все процессы Chrome и ChromeDriver");
            Driver?.Dispose();
            Driver = null;
            return null;
        }
    }

    private static string GetChromeProfilePath(string userName)
    {
        string basePath;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library", "Application Support", "Botva2025");
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "Botva2025");
        else
            basePath = Path.Combine("c:\\Temp", "ChromeProfile");

        string profilePath = Path.Combine(basePath, $"{userName}_profile");
        Directory.CreateDirectory(profilePath);
        return profilePath;
    }
}
