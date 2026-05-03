using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace Botva2025;

public class HardwareInfo
{
    public static string UniqueHardwareIDv2()
    {
        try
        {
            string machineId = GetMachineId();
            return GetHash(machineId);
        }
        catch
        {
            return string.Empty;
        }
    }

    private static string GetMachineId()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return ExecuteCommand("ioreg", "-rd1 -c IOPlatformExpertDevice")
                   + ExecuteCommand("sysctl", "-n machdep.cpu.brand_string");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            try { return File.ReadAllText("/etc/machine-id").Trim(); } catch { }
            return Environment.MachineName;
        }
        else
        {
            return ExecuteCommand("powershell", "-Command \"Get-WmiObject Win32_Processor | Select-Object -ExpandProperty ProcessorId\"");
        }
    }

    private static string ExecuteCommand(string fileName, string arguments)
    {
        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using var process = Process.Start(startInfo);
            if (process != null)
            {
                using var reader = process.StandardOutput;
                return reader.ReadToEnd()?.Trim() ?? string.Empty;
            }
        }
        catch { }
        return string.Empty;
    }

    private static string GetHash(string input)
    {
        byte[] array = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        var sb = new StringBuilder();
        foreach (byte b in array)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }

    public static string Encrypt(string text, string key)
    {
        using Aes aes = Aes.Create();
        byte[] salt = Encoding.UTF8.GetBytes("SaltIsGoodForYou");
        byte[] derived = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(key), salt, 10000, HashAlgorithmName.SHA256, 48);
        aes.Key = derived[..32];
        aes.IV = derived[32..];
        ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
        using MemoryStream ms = new MemoryStream();
        using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
        {
            using StreamWriter writer = new StreamWriter(cs);
            writer.Write(text);
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    public static string Decrypt(string cipherText, string key)
    {
        using Aes aes = Aes.Create();
        byte[] salt = Encoding.UTF8.GetBytes("SaltIsGoodForYou");
        byte[] derived = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(key), salt, 10000, HashAlgorithmName.SHA256, 48);
        aes.Key = derived[..32];
        aes.IV = derived[32..];
        ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
        using MemoryStream stream = new MemoryStream(Convert.FromBase64String(cipherText));
        using CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Read);
        using StreamReader reader = new StreamReader(cs);
        return reader.ReadToEnd();
    }
}
