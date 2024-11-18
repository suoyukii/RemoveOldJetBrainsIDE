using System.Diagnostics;

namespace RemoveOldJetBrainsIDE;

public static class Language
{
    // public static string[] Get() => CultureInfo.CurrentUICulture.Name switch
    public static string[] Get() => FixGetCultureName() switch
    {
        "zh-cn" =>
        [
            "清除旧版本的 JetBrains IDE",
            "清除中...",
            "清除结束，这个窗口可以关闭了"
        ],
        _ =>
        [
            "Remove Old JetBrains IDE",
            "Removing...",
            "Remove is complete, the window can be closed."
        ],
    };

    private static string FixGetCultureName()
    {
        var p = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = "(Get-UICulture).Name",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        p.Start();
        var lang = p.StandardOutput.ReadLine().ToLower();
        p.WaitForExit();
        return lang;
    }
}