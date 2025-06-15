using System.Diagnostics;
using Serilog;
using SharpHook;
using SharpHook.Data;

public static class KeyPressHandler
{
    public static void Handle(HookEventArgs e)
    {
        try
        {
            if (e.RawEvent.Mask is SharpHook.Data.EventMask.LeftMeta or SharpHook.Data.EventMask.RightMeta &&
                e.RawEvent.Keyboard.KeyCode == KeyCode.VcEnter)
            {
                Log.Information($"[Cmd + Enter] - Openning alacritty...");

                Process.Start("open", "-na /Applications/Alacritty.app");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An error occurred while handling key press event");
        }
    }
}
