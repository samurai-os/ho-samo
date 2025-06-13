using System.Diagnostics;
using Serilog;
using SharpHook;
using SharpHook.Data;

namespace HoSamo.Host;

public static class KeyPressHandler
{
    public static void Handle(HookEventArgs e)
    {
        var hashCode = e.GetHashCode();

        try
        {
            if (e.RawEvent.Mask is SharpHook.Data.EventMask.LeftMeta or SharpHook.Data.EventMask.RightMeta &&
                e.RawEvent.Keyboard.KeyCode == KeyCode.VcEnter)
            {
                Log.Debug($"[{hashCode}] > Key Pressed: {e.RawEvent}");
                Log.Information($"[{hashCode}] > Enter key pressed");

                Process.Start("open", "-na /Applications/Alacritty.app/Contents/MacOS/alacritty");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"[{hashCode}] > An error occurred while handling key press event");
        }
        finally
        {
            Log.Debug($"[{hashCode}] > Key Pressed: {e.RawEvent}");
        }
    }
}
