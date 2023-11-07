using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;
using SnakeGame.Components;
using System.Drawing;

namespace SnakeGame;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping("BackgroundColor", (handler, view) =>
        {
            if (view is EndGameLabel)
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Yellow);
#endif
            }
        });

        return builder.Build();
	}
}
