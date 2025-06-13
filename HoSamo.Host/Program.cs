using HoSamo.Host;
using Serilog;
using SharpHook.Reactive;

try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Error()
        .WriteTo.File("logs/ho-samo-.log", rollingInterval: RollingInterval.Day)
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
