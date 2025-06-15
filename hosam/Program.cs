using Serilog;
using SharpHook.Reactive;

try
{
    LogConfiguration.Configure();

    Log.Information("Hosam started");

    var hook = new SimpleReactiveGlobalHook();
    hook.KeyPressed.Subscribe(KeyPressHandler.Handle);
    hook.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "An unhandled exception occurred during Hosam execution");
}
finally
{
    Log.Information("Hosam stopped");
    await Log.CloseAndFlushAsync();
}
