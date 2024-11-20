using System.Globalization;

namespace RemoveOldJetBrainsIDE;

public static class Language
{
    public static string[] Get()
    {
        return CultureInfo.CurrentUICulture.Name switch
        {
            "zh-CN" =>
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
            ]
        };
    }
}