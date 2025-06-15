using Serilog;

public static class LogConfiguration
{
    public static void Configure()
    {
        var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.File($"{homeDir}/Library/Logs/hosam/hs-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}
