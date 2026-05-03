using System.Drawing;

namespace Botva2025;

/// <summary>
/// Stub for embedded resources. The original app used embedded images for icons.
/// On macOS we don't need these for the bot logic to work.
/// </summary>
public static class Resource
{
    public static Icon? Main => null;
    public static Image ico_gold => new();
    public static Image new_kri => new();
    public static Image pirash => new();
    public static Image _1 => new();
    public static Image _3 => new();
    public static Image _5 => new();
    public static Image vniz => new();
    public static Image vverh => new();
    public static Image nav_plain_red => new();
    public static Image nav_plain_green => new();
    // Add more as needed - these are just UI images
}

/// <summary>
/// Stub for ApplicationConfiguration (WinForms specific)
/// </summary>
public static class ApplicationConfiguration
{
    public static void Initialize() { }
}

/// <summary>
/// Cross-platform TaskbarProgress replacement (no-op on macOS)
/// </summary>
public static class TaskbarProgress
{
    public enum TaskbarStates { NoProgress, Indeterminate, Normal, Error = 4, Paused = 8 }

    public static void SetState(nint windowHandle, TaskbarStates taskbarState) { }
    public static void SetValue(nint windowHandle, double progressValue, double progressMax) { }
    public static void Reset(nint windowHandle) { }
    public static void DeleteTab(nint windowHandle) { }
    public static void ActivateTab(nint windowHandle) { }
}
