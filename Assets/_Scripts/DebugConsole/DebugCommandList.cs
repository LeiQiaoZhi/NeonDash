using UnityEngine;

public static class DebugCommandList
{
    public static DebugCommand TestCommand =
        new DebugCommand("test", (console) =>
        {
            XLogger.LogWarning(Category.DebugConsole, "TEST COMMAND");
            return "TEST COMMAND";
        });
    
    public static DebugCommand QuitCommand =
        new DebugCommand("quit", (console) =>
        {
            console.console.SetActive(false);
            XLogger.LogWarning(Category.DebugConsole, "Close Debug Console");
            return "Console Closed";
        });
    
    public static DebugCommand HelpCommand =
        new DebugCommand("help", (console) =>
        {
            XLogger.LogWarning(Category.DebugConsole, "Help Command");
            var help = "Actions: [Tab] to toggle debug console; [Enter] to enter command\n" +
                       "Commands: help -- show help, quit -- close console, stats -- show stats";
            return help;
        });
    
    public static DebugCommand StatsCommand =
        new DebugCommand("stats", (console) =>
        {
            XLogger.LogWarning(Category.DebugConsole, "Stats Command");
            return PowerupManager.Instance.GetStatsSummary();
        });

}