using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Maui_Workaround13572;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    /// <summary>
    /// Context
    /// </summary>
    public static Context Context { get; private set; }

    /// <summary>
    /// Attach base context
    /// </summary>
    /// <param name="base">base context</param>
    protected override void AttachBaseContext(Context @base)
    {
        Context = @base;

        base.AttachBaseContext(@base);
    }
}
