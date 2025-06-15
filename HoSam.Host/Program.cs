using HoSam.Host;
using Serilog;
using SharpHook.Reactive;

try
{
    var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    Console.WriteLine($"HoSamo.Host started. Logs will be written to: {homeDir}/Library/Logs/hosam/hs-.log");

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.File($"{homeDir}/Library/Logs/hosam/hs-.log", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    Log.Information("HoSamo.Host started");

    var hook = new SimpleReactiveGlobalHook();
    hook.KeyPressed.Subscribe(KeyPressHandler.Handle);

    hook.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred during HoSamo.Host execution");
}
finally
{
    Log.Information("HoSamo.Host stopped");
    await Log.CloseAndFlushAsync();
}
